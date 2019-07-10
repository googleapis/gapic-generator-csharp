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
            public class SingleDef
            {
                public SingleDef(string ns, string shortName, string pattern)
                {
                    Pattern = pattern;
                    if (IsWildcard)
                    {
                        ResourceNameTyp = Typ.Of<IResourceName>();
                        Template = null;
                    }
                    else
                    {
                        ResourceNameTyp = Typ.Manual(ns, $"{shortName}Name");
                        Template = new PathTemplate(Pattern);
                    }
                }
                public Typ ResourceNameTyp { get; }
                public string Pattern { get; }
                public PathTemplate Template { get; }
                public bool IsWildcard => Pattern == "*";
            }

            public class MultiDef
            {
                public MultiDef(string ns, string shortName, IEnumerable<SingleDef> oneDefs)
                {
                    ContainerTyp = Typ.Manual(ns, $"{shortName}NameOneOf");
                    Defs = oneDefs.ToList();
                }
                public Typ ContainerTyp { get; }
                public IReadOnlyList<SingleDef> Defs { get; }
            }

            public Definition(string fileName, ResourceDescriptor resourceDesc, SingleDef single, MultiDef multi)
            {
                FileName = fileName;
                UnifiedResourceTypeName = resourceDesc.Type;
                var typeNameParts = resourceDesc.Type.Split('/');
                if (typeNameParts.Length != 2)
                {
                    throw new InvalidOperationException($"Invalid unified resource name: '{resourceDesc.Type}'");
                }
                ShortName = typeNameParts[1];
                FieldName = ShortName.ToLowerCamelCase();
                NameField = string.IsNullOrEmpty(resourceDesc.NameField) ? "name" : resourceDesc.NameField;
                DocName = ShortName;
                Single = single;
                Multi = multi;
            }

            public string FileName { get; }

            public string UnifiedResourceTypeName { get; }

            public string ShortName { get; }

            /// <summary>The name of this resource, suitable for use as a C# field or parameter. I.e. lower-camel-cased.</summary>
            public string FieldName { get; }

            /// <summary>The name of the proto field that contains this resource name.</summary>
            public string NameField { get; }

            /// <summary>The name of this resource, as used in XmlDoc.</summary>
            public string DocName { get; }

            /// <summary>Definition of resource that is not a multi. Null if only a multi.</summary>
            public SingleDef Single { get; }

            /// <summary>Definition of resource that is a multi. Null if not a multi.</summary>
            public MultiDef Multi { get; }
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
                SingleResourcePropertyName = resourceDef.Single is null ? null : MakePropertyName(resourceDef.Single.ResourceNameTyp.Name, resourceDef.Single.IsWildcard);
                MultiResourcePropertyName = resourceDef.Multi is null ? null : MakePropertyName(resourceDef.Multi.ContainerTyp.Name, false);

                string MakePropertyName(string typName, bool isWildcard)
                {
                    // This naming logic is copied directly from the Java generator.
                    // TODO: Make sure it's correct for all combinations - I'm not sure it is!
                    var requireIdentifier = !((fieldDesc.IsRepeated && fieldDesc.Name.ToLowerInvariant() == "names") ||
                        (!fieldDesc.IsRepeated && fieldDesc.Name.ToLowerInvariant() == "name"));
                    var requireAs = requireIdentifier || isWildcard;
                    var requirePlural = fieldDesc.IsRepeated;
                    var name = requireIdentifier ? UnderlyingPropertyName : "";
                    name += requireAs ? "As" : "";
                    name += isWildcard ? "ResourceName" : typName;
                    name += requirePlural ? "s" : "";
                    return name;
                }
            }

            /// <summary>The C# name of the string-typed property underlying this resource.</summary>
            public string UnderlyingPropertyName { get; }

            /// <summary>The C# name of the single-pattern resource property.</summary>
            public string SingleResourcePropertyName { get; }

            /// <summary>The C# name of the multi-pattern resource property.</summary>
            public string MultiResourcePropertyName { get; }

            /// <summary>The resource definition for this field.</summary>
            public Definition ResourceDefinition { get; }
        }

        public static IReadOnlyList<Definition> LoadResourceDefinitionsByFileName(IEnumerable<FileDescriptor> descs)
        {
            // Singles:
            // Compatibility problems: none
            //
            // Multi: If pattern already exists, use it; otherwise create new single-def.
            //        Create name as concatenation of all ID parts, without "Id" suffixes.
            // Compatibility problems: Adding a new resource with the same pattern as one of a multi-pattern.
            //
            // Child: Find all children that need parents generating.
            //        Single/Container-name generated as "{ShortName}Parent"; unless a single already exists with same pattern.
            //        Multi-def parts constructed as in normal multis.
            // Compatibility problems: Adding a new resource with the same pattern as a single-pattern parent.
            //                         Adding a new resource with the same pattern as one of a multi-pattern parent.
            var msgs = descs
                .SelectMany(fileDesc => fileDesc.MessageTypes.Select(msg =>
                    (fileDesc, msg, resDesc: msg.CustomOptions.TryGetMessage<ResourceDescriptor>(ProtoConsts.MessageOption.Resource, out var resDesc) ? resDesc : null)))
                .Where(x => x.resDesc != null)
                .Select(x => (x.fileDesc, x.msg, x.resDesc, shortName: GetShortName(x.resDesc)))
                .ToImmutableList();
            var msgsByType = msgs.ToImmutableDictionary(x => x.resDesc.Type);
            // Load Singles.
            var singlesByType = msgs.Where(x => HasSingle(x.resDesc))
                .ToImmutableDictionary(x => x.resDesc.Type, x => (x.resDesc, single: new Definition.SingleDef(x.fileDesc.CSharpNamespace(), x.shortName, x.resDesc.Pattern[0])));
            var singlesByPattern = singlesByType.Values.ToImmutableDictionary(x => x.single.Pattern);
            // Load Multis.
            var multisByType = msgs.Where(x => HasMulti(x.resDesc)).Select(msg =>
            {
                var innerDefs = msg.resDesc.Pattern.Select(pattern =>
                {
                    if (singlesByPattern.TryGetValue(pattern, out var def))
                    {
                        return def.single;
                    }
                    var shortName = string.Join("", new PathTemplate(pattern).ParameterNames.Select(x => x.ToUpperCamelCase().RemoveSuffix("Id")));
                    return new Definition.SingleDef(msg.fileDesc.CSharpNamespace(), shortName, pattern);
                }).ToList();
                var multi = new Definition.MultiDef(msg.fileDesc.CSharpNamespace(), msg.shortName, innerDefs);
                return (msg.resDesc, multi);
            }).ToImmutableDictionary(x => x.resDesc.Type);
            // Load Parents.
            // TODO

            // Build return value.
            var fileNamesByType = msgs.ToImmutableDictionary(x => x.resDesc.Type, x => x.fileDesc.Name);
            return msgs.Select(x =>
            {
                var single = singlesByType.GetValueOrDefault(x.resDesc.Type).single;
                var multi = multisByType.GetValueOrDefault(x.resDesc.Type).multi;
                return new Definition(fileNamesByType[x.resDesc.Type], x.resDesc, single, multi);
            }).ToList();

            bool HasSingle(ResourceDescriptor resDesc) =>
                (resDesc.History & ResourceDescriptor.Types.History.FutureMultiPattern) == 0 &&
                    (resDesc.Pattern.Count == 1 || (resDesc.History & ResourceDescriptor.Types.History.OriginallySinglePattern) != 0);

            bool HasMulti(ResourceDescriptor resDesc) =>
                resDesc.Pattern.Count > 1 || (resDesc.History & ResourceDescriptor.Types.History.FutureMultiPattern) != 0;

            string GetShortName(ResourceDescriptor resDesc)
            {
                var typeParts = resDesc.Type.Split('/');
                if (typeParts.Length != 2)
                {
                    throw new InvalidOperationException($"Invalid Unified Resource Type: '{resDesc.Type}'");
                }
                return typeParts[1];
            }

            // TOOD: This will be used when child_type is handled.
            //string ParentPattern(string pattern)
            //{
            //    var lastIndex = pattern.LastIndexOf('}');
            //    var last2Index = pattern.LastIndexOf('}', startIndex: Math.Max(lastIndex - 1, 0));
            //    if (lastIndex < 0 || last2Index < 0)
            //    {
            //        throw new InvalidOperationException("Cannot create the parent of a single-piece resource name.");
            //    }
            //    return pattern.Substring(0, last2Index + 1);
            //}
        }

        public static Field LoadResourceReference(MessageDescriptor msgDesc, FieldDescriptor fieldDesc, IReadOnlyDictionary<string, Definition> resourcesByUrt)
        {
            // Is this field the name-field of a resource descriptor?
            if (msgDesc.CustomOptions.TryGetMessage<ResourceDescriptor>(ProtoConsts.MessageOption.Resource, out var resourceDesc))
            {
                var def = resourcesByUrt[resourceDesc.Type];
                if (fieldDesc.Name == def.NameField)
                {
                    return new Field(fieldDesc, def);
                }
            }
            // Is this field a resource reference?
            if (!fieldDesc.CustomOptions.TryGetMessage<ResourceReference>(ProtoConsts.FieldOption.ResourceReference, out var resourceRef))
            {
                return null;
            }
            if (!string.IsNullOrEmpty(resourceRef.Type))
            {
                if (!resourcesByUrt.TryGetValue(resourceRef.Type, out var def))
                {
                    throw new InvalidOperationException($"No resource type with name: '{resourceRef.Type}'");
                }
                return new Field(fieldDesc, def);
            }
            else if (!string.IsNullOrEmpty(resourceRef.ChildType))
            {
                // TODO
                throw new NotImplementedException();
            }
            throw new InvalidOperationException("type or child_type must be set.");
        }
    }
}
