// Copyright 2019 Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Google.Api.Gax;
using Google.Api.Generator.Utils;
using Google.Protobuf.Reflection;
using Google.Protobuf.WellKnownTypes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Google.Api.Generator.ProtoUtils
{
    internal class ResourceDetails
    {
        public class Definition
        {
            public class TypeComparer : IEqualityComparer<Definition>
            {
                public static TypeComparer Instance { get; } = new TypeComparer();

                public bool Equals(Definition x, Definition y) => EqualityComparer<string>.Default.Equals(x.UnifiedResourceTypeName, y.UnifiedResourceTypeName);

                public int GetHashCode(Definition obj) => obj.UnifiedResourceTypeName.GetHashCode();
            }

            public class Pattern
            {
                public Pattern(string pattern)
                {
                    PatternString = pattern;
                    IsWildcard = pattern == "*";
                    if (!IsWildcard)
                    {
                        Template = new ResourcePattern(pattern);
                    }
                }

                public bool IsWildcard { get; }
                public string PatternString { get; }
                public ResourcePattern Template { get; }
            }

            public static Definition WildcardResource { get; } = new Definition();

            // Ctor for wildcard only.
            private Definition()
            {
                Patterns = new[] { new Pattern("*") };
                ResourceNameTyp = Typ.Of<IResourceName>();
                ResourceParserTyp = Typ.Of<UnparsedResourceName>();
                IsUnparsed = true;
            }

            public Definition(FileDescriptor fileDesc, MessageDescriptor msgDesc, string type, string nameField, CommonResource common, IEnumerable<string> patterns)
            {
                MsgDesc = msgDesc;
                FileName = fileDesc.Name;
                UnifiedResourceTypeName = type;
                var typeNameParts = type.Split('/');
                if (typeNameParts.Length != 2)
                {
                    throw new InvalidOperationException($"Invalid unified resource name: '{type}' used in message '{msgDesc?.Name}'");
                }
                ShortName = typeNameParts[1];
                FieldName = ShortName.ToLowerCamelCase();
                NameField = string.IsNullOrEmpty(nameField) ? "name" : nameField;
                DocName = ShortName;
                Patterns = patterns.Select(x => new Pattern(x)).ToList();
                if (patterns.Distinct().Count() != Patterns.Count)
                {
                    throw new InvalidOperationException("All patterns must be unique within a resource-name.");
                }
                IsCommon = common != null;
                ResourceNameTyp = IsCommon ?
                    Typ.Manual(common.CsharpNamespace, common.CsharpClassName) :
                    Typ.Manual(fileDesc.CSharpNamespace(), $"{ShortName}Name");
                ResourceParserTyp = ResourceNameTyp;
                IsUnparsed = false;
            }

            public MessageDescriptor MsgDesc { get; }

            public string FileName { get; }

            public string UnifiedResourceTypeName { get; }

            public string ShortName { get; }

            /// <summary>The name of this resource, suitable for use as a C# field or parameter. I.e. lower-camel-cased.</summary>
            public string FieldName { get; }

            /// <summary>The name of the proto field that contains this resource name.</summary>
            public string NameField { get; }

            /// <summary>The name of this resource, as used in XmlDoc.</summary>
            public string DocName { get; }

            public bool IsCommon { get; }

            public IReadOnlyList<Pattern> Patterns { get; }

            public bool HasWildcard => Patterns.Any(x => x.IsWildcard);

            public bool HasNotWildcard => Patterns.Any(x => !x.IsWildcard);

            public bool IsWildcardOnly => HasWildcard && !HasNotWildcard;

            public Typ ResourceNameTyp { get; }

            public Typ ResourceParserTyp { get; }

            public bool IsUnparsed { get; }
        }

        /// <summary>
        /// Details about a resource usage by a proto field.
        /// </summary>
        public class Field
        {
            public Field(FieldDescriptor fieldDesc, Definition resourceDef, IReadOnlyList<Definition> innerDefs = null, bool? containsWildcard = null)
            {
                // innerFields only non-null for the IResourceName property of child_type refs.
                IsRepeated = fieldDesc.IsRepeated;
                IsDeprecated = fieldDesc.IsDeprecated();
                UnderlyingPropertyName = fieldDesc.CSharpPropertyName();
                ResourceDefinition = resourceDef;
                var requireIdentifier = !((fieldDesc.IsRepeated && fieldDesc.Name.ToLowerInvariant() == "names") ||
                    (!fieldDesc.IsRepeated && fieldDesc.Name.ToLowerInvariant() == "name"));
                ResourcePropertyName = (requireIdentifier ? $"{UnderlyingPropertyName}As" : "") +
                    (resourceDef.IsWildcardOnly ? "ResourceName" : resourceDef.ResourceNameTyp.Name) + (fieldDesc.IsRepeated ? "s" : "");
                InnerDefs = innerDefs;
                ContainsWildcard = containsWildcard;
            }

            public bool IsRepeated { get; }

            public bool IsDeprecated { get; }

            /// <summary>The C# name of the string-typed property underlying this resource.</summary>
            public string UnderlyingPropertyName { get; }

            /// <summary>The C# name of the resource property.</summary>
            public string ResourcePropertyName { get; }

            /// <summary>The resource definition for this field.</summary>
            public Definition ResourceDefinition { get; }

            /// <summary>All the resource definitions that are possible for a child_type ref; only populated for an IResourceName parent field.</summary>
            public IReadOnlyList<Definition> InnerDefs { get; }

            /// <summary>If this is an IResourceName parent field, then does the parent contain a wildcard pattern.</summary>
            public bool? ContainsWildcard { get; }
        }

        public static IReadOnlyList<Definition> LoadResourceDefinitionsByFileName(IEnumerable<FileDescriptor> descs, IEnumerable<CommonResources> commonResourcesConfigs)
        {
            var commonsByType = commonResourcesConfigs?.SelectMany(x => x.CommonResources_).ToImmutableDictionary(x => x.Type) ??
                ImmutableDictionary<string, CommonResource>.Empty;
            // TODO: Support new (Sept 2019) `name_descriptor` way of specifying resource-names.
            var msgsFromProtoMsgs = descs
                .SelectMany(fileDesc => fileDesc.MessageTypes
                    .SelectMany(GetMessagesAndSelf)
                    .Select(msgDesc =>(fileDesc, msgDesc, resDesc: msgDesc.GetExtension(ResourceExtensions.Resource))))
                .Where(x => x.resDesc != null)
                .Select(x => (x.fileDesc, x.msgDesc, x.resDesc, shortName: GetShortName(x.resDesc)));
            var msgsFromFileAnnotation = descs
                .SelectMany(fileDesc =>
                    fileDesc.GetExtension(ResourceExtensions.ResourceDefinition)
                        .Select(resDesc => (fileDesc, msgDesc: (MessageDescriptor)null, resDesc, shortName: GetShortName(resDesc))));
            var msgs = msgsFromProtoMsgs.Concat(msgsFromFileAnnotation).ToImmutableList();
            return msgs.Select(x =>
            {
                commonsByType.TryGetValue(x.resDesc.Type, out var common);
                return new Definition(x.fileDesc, x.msgDesc, x.resDesc.Type, x.resDesc.NameField, common, x.resDesc.Pattern);
            }).ToList();

            string GetShortName(ResourceDescriptor resDesc)
            {
                var typeParts = resDesc.Type.Split('/');
                if (typeParts.Length != 2)
                {
                    throw new InvalidOperationException($"Invalid Unified Resource Type: '{resDesc.Type}'");
                }
                return typeParts[1];
            }

            // Recurses through a message's nested messages to get all descendant messages. This is required
            // in order to pick up resource definitions on nested types.
            // TODO: A test for this.
            IEnumerable<MessageDescriptor> GetMessagesAndSelf(MessageDescriptor message) =>
                message.NestedTypes.SelectMany(GetMessagesAndSelf).Append(message);
        }

        public static IEnumerable<Field> LoadResourceReference(MessageDescriptor msgDesc, FieldDescriptor fieldDesc,
            IReadOnlyDictionary<string, Definition> resourcesByUrt, IReadOnlyDictionary<string, IReadOnlyList<Definition>> resourcesByParentComparison)
        {
            // Is this field the name-field of a resource descriptor?
            var resourceDesc = msgDesc.GetExtension(ResourceExtensions.Resource);
            if (resourceDesc is object)
            {
                var def = resourcesByUrt[resourceDesc.Type];
                if (fieldDesc.Name == def.NameField)
                {
                    if (def.HasNotWildcard)
                    {
                        yield return new Field(fieldDesc, def);
                    }
                    if (def.HasWildcard)
                    {
                        yield return new Field(fieldDesc, Definition.WildcardResource, def.HasNotWildcard ? new[] { def } : null);
                    }
                    yield break;
                }
            }
            // Is this field a resource reference?
            var resourceRef = fieldDesc.GetExtension(ResourceExtensions.ResourceReference);
            if (resourceRef is object)
            {
                // Resource references must be string fields, or StringValue (well-known type) fields.
                // It's a relatively common error to put the annotation on a message field instead, which
                // will otherwise generate invalid code - better to fail generation.
                if (fieldDesc.FieldType != FieldType.String &&
                    !(fieldDesc.FieldType == FieldType.Message && fieldDesc.MessageType.FullName == StringValue.Descriptor.FullName))
                {
                    throw new InvalidOperationException($"Field {msgDesc.Name}.{fieldDesc.Name} has a resource reference annotation, but is not a string or StringValue field.");
                }
                if (!string.IsNullOrEmpty(resourceRef.Type))
                {
                    if (resourceRef.Type == "*" || resourceRef.Type == "**")
                    {
                        yield return new Field(fieldDesc, Definition.WildcardResource);
                        yield break;
                    }
                    if (!resourcesByUrt.TryGetValue(resourceRef.Type, out var def))
                    {
                        throw new InvalidOperationException($"No resource type with name: '{resourceRef.Type}' for field {msgDesc.Name}.{fieldDesc.Name}");
                    }
                    if (def.HasNotWildcard)
                    {
                        yield return new Field(fieldDesc, def);
                    }
                    if (def.HasWildcard)
                    {
                        yield return new Field(fieldDesc, Definition.WildcardResource, def.HasNotWildcard ? new[] { def } : null);
                    }
                }
                else if (!string.IsNullOrEmpty(resourceRef.ChildType))
                {
                    if (resourceRef.ChildType == "*" || resourceRef.ChildType == "**")
                    {
                        yield return new Field(fieldDesc, Definition.WildcardResource);
                        yield break;
                    }
                    if (!resourcesByUrt.TryGetValue(resourceRef.ChildType, out var childDef))
                    {
                        throw new InvalidOperationException($"No resource type with child name: '{resourceRef.ChildType}' for field {msgDesc.Name}.{fieldDesc.Name}");
                    }
                    // Find all resources in which the patterns are a subset of the child patterns; a wildcard matches a child wildcard.
                    // Verify that these resources together match all parent patterns of the child resource.
                    // Order by most-specific-parent first, then by order in child-type patterns (then alphabetically as a last resort, to keep it deterministic).
                    var parentPatterns = childDef.Patterns.Select(x => x.IsWildcard ? "*" : x.Template.Parent().ParentComparisonString).ToImmutableList();
                    var parentPatternsSet = parentPatterns.ToImmutableHashSet();
                    var parentDefs = parentPatterns
                        .SelectMany(x => resourcesByParentComparison.TryGetValue(x, out var defs) ? defs : Enumerable.Empty<Definition>())
                        .Where(def => def.Patterns.All(x => parentPatternsSet.Contains(x.Template.ParentComparisonString)))
                        .Distinct(Definition.TypeComparer.Instance)
                        .OrderBy(def => def.Patterns.Count)
                        .ThenBy(def => def.Patterns.Select(x => parentPatterns.IndexOf(x.Template.ParentComparisonString)).Where(x => x >= 0).Min())
                        .ThenBy(def => def.UnifiedResourceTypeName)
                        .ToImmutableList();
                    // "*" pattern is not required to be matched; all others are required.
                    if (parentPatternsSet.Except(parentDefs.SelectMany(x => x.Patterns).Select(x => x.Template.ParentComparisonString).Append("*")).Any())
                    {
                        throw new InvalidOperationException($"Not all patterns can be matched to a parent resource for field {msgDesc.Name}.{fieldDesc.Name}");
                    }
                    foreach (var parentDef in parentDefs)
                    {
                        yield return new Field(fieldDesc, parentDef);
                    }
                    if (parentDefs.Any(x => x.HasWildcard) || childDef.IsWildcardOnly || parentDefs.Count > 1)
                    {
                        yield return new Field(fieldDesc, Definition.WildcardResource, parentDefs.Count > 1 ? parentDefs : null, parentPatternsSet.Contains("*"));
                    }
                }
                else
                {
                    throw new InvalidOperationException("type or child_type must be set.");
                }
            }
        }
    }
}
