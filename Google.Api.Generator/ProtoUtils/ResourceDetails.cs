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
            public class Pattern
            {
                public Pattern(string pattern) => (PatternString, Template) = (pattern, new PathTemplate(pattern));

                public string PatternString { get; }
                public PathTemplate Template { get; }
            }

            public static Definition UnknownResource { get; } = new Definition();

            // Ctor for wildcard only.
            private Definition() => ResourceNameTyp = Typ.Of<IResourceName>();

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
                IsCommon = common != null;
                if (!patterns.All(x => x == "*"))
                {
                    // Not a wildcard.
                    if (patterns.Any(x => x == "*"))
                    {
                        throw new InvalidOperationException("A wildcard pattern must be the only pattern in a resource.");
                    }
                    Patterns = patterns.Select(x => new Pattern(x)).ToList();
                    ResourceNameTyp = common == null ?
                        Typ.Manual(fileDesc.CSharpNamespace(), $"{ShortName}Name") :
                        Typ.Manual(common.CsharpNamespace, common.CsharpClassName);
                }
                else
                {
                    // Wildcard resource.
                    ResourceNameTyp = Typ.Of<IResourceName>();
                }
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

            public bool IsWildcard => Patterns == null;

            public Typ ResourceNameTyp { get; }
        }

        /// <summary>
        /// Details about a resource usage by a proto field.
        /// </summary>
        public class Field
        {
            public Field(FieldDescriptor fieldDesc, Definition resourceDef)
            {
                UnderlyingPropertyName = fieldDesc.CSharpPropertyName();
                ResourceDefinition = resourceDef;

                // This naming logic is copied directly from the Java generator.
                // TODO: Make sure it's correct for all combinations - I'm not sure it is!
                var requireIdentifier = !((fieldDesc.IsRepeated && fieldDesc.Name.ToLowerInvariant() == "names") ||
                    (!fieldDesc.IsRepeated && fieldDesc.Name.ToLowerInvariant() == "name"));
                var requireAs = requireIdentifier;
                var requirePlural = fieldDesc.IsRepeated;
                var name = requireIdentifier ? UnderlyingPropertyName : "";
                name += requireAs ? "As" : "";
                name += resourceDef.IsWildcard ? "ResourceName" : resourceDef.ResourceNameTyp.Name;
                name += requirePlural ? "s" : "";
                ResourcePropertyName = name;
            }

            /// <summary>The C# name of the string-typed property underlying this resource.</summary>
            public string UnderlyingPropertyName { get; }

            /// <summary>The C# name of the resource property.</summary>
            public string ResourcePropertyName { get; }

            /// <summary>The resource definition for this field.</summary>
            public Definition ResourceDefinition { get; }
        }

        public static IReadOnlyList<Definition> LoadResourceDefinitionsByFileName(IEnumerable<FileDescriptor> descs, IEnumerable<CommonResources> commonResourcesConfigs)
        {
            var commonsByType = commonResourcesConfigs?.SelectMany(x => x.CommonResources_).ToImmutableDictionary(x => x.Type) ??
                ImmutableDictionary<string, CommonResource>.Empty;
            // TODO: Support new (Sept 2019) `name_descriptor` way of specifying resource-names.
            var msgsFromProtoMsgs = descs
                .SelectMany(fileDesc => fileDesc.MessageTypes.Select(msgDesc =>
                    (fileDesc, msgDesc, resDesc: msgDesc.SafeGetOption(ResourceExtensions.Resource))))
                .Where(x => x.resDesc != null)
                .Select(x => (x.fileDesc, x.msgDesc, x.resDesc, shortName: GetShortName(x.resDesc)));
            var msgsFromFileAnnotation = descs
                .SelectMany(fileDesc =>
                    fileDesc.SafeGetOption(ResourceExtensions.ResourceDefinition)
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
        }

        public static Field LoadResourceReference(MessageDescriptor msgDesc, FieldDescriptor fieldDesc,
            IReadOnlyDictionary<string, Definition> resourcesByUrt, IReadOnlyDictionary<ImmutableHashSet<string>, Definition> resourcesByPatterns)
        {
            // Is this field the name-field of a resource descriptor?
            var resourceDesc = msgDesc.SafeGetOption(ResourceExtensions.Resource);
            if (resourceDesc is object)
            {
                var def = resourcesByUrt[resourceDesc.Type];
                if (fieldDesc.Name == def.NameField)
                {
                    return new Field(fieldDesc, def);
                }
            }
            // Is this field a resource reference?
            var resourceRef = fieldDesc.SafeGetOption(ResourceExtensions.ResourceReference);
            if (resourceRef is null)
            {
                return null;
            }
            if (!string.IsNullOrEmpty(resourceRef.Type))
            {
                if (resourceRef.Type == "*" || resourceRef.Type == "**")
                {
                    // Resource is `IUnknownResource`.
                    return new Field(fieldDesc, Definition.UnknownResource);
                }
                if (!resourcesByUrt.TryGetValue(resourceRef.Type, out var def))
                {
                    throw new InvalidOperationException($"No resource type with name: '{resourceRef.Type}' for field {msgDesc.Name}.{fieldDesc.Name}");
                }
                return new Field(fieldDesc, def);
            }
            else if (!string.IsNullOrEmpty(resourceRef.ChildType))
            {
                if (!resourcesByUrt.TryGetValue(resourceRef.ChildType, out var childDef))
                {
                    throw new InvalidOperationException($"No resource type with child name: '{resourceRef.ChildType}' for field {msgDesc.Name}.{fieldDesc.Name}");
                }
                if (childDef.IsWildcard)
                {
                    // The parent of a wildcard pattern is another wildcard.
                    return new Field(fieldDesc, Definition.UnknownResource);
                }
                var parentPatterns = childDef.Patterns.Select(x => ParentPattern(x.PatternString)).ToImmutableHashSet();
                if (resourcesByPatterns.TryGetValue(parentPatterns, out var parentDef))
                {
                    // Return existing resource; no auto-generated required.
                    return new Field(fieldDesc, parentDef);
                }
                // It is invalid to ask for a parent that is not already defined.
                // This may change in the future, to allow auto-generating parent resource-names, but this is not currently allowed.
                throw new InvalidOperationException(
                    $"Cannot refer to child-type '{resourceRef.ChildType}' in field {msgDesc.Name}.{fieldDesc.Name} because the child patterns are not already defined in a resource.");
            }
            throw new InvalidOperationException("type or child_type must be set.");

            string ParentPattern(string pattern)
            {
                var lastIndex = pattern.LastIndexOf('}');
                var last2Index = pattern.LastIndexOf('}', startIndex: Math.Max(lastIndex - 1, 0));
                if (lastIndex < 0 || last2Index < 0)
                {
                    throw new InvalidOperationException("Cannot create the parent of a single-piece resource name.");
                }
                return pattern.Substring(0, last2Index + 1);
            }
        }
    }
}
