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
using System.Linq;

namespace Google.Api.Generator.ProtoUtils
{
    internal class ResourceDetails
    {
        public class Definition
        {
            public class OneDef
            {
                public OneDef(Typ resourceNameTyp, Resource resource)
                {
                    Pattern = resource.Pattern;
                    ResourceNameTyp = IsWildcard ? Typ.Of<IResourceName>() : resourceNameTyp;
                    Template = IsWildcard ? null : new PathTemplate(resource.Pattern);
                }
                /// <summary>The typ of the generated resource-name class.</summary>
                public Typ ResourceNameTyp { get; }
                /// <summary>The resource pattern.</summary>
                public string Pattern { get; }
                /// <summary>Template built from pattern; null if wildcard.</summary>
                public PathTemplate Template { get; }
                public bool IsWildcard => Pattern == "*";
            }

            public class SetDef
            {
                // TODO: Set support.
                /// <summary>The typ of the generated resource-set-name class.</summary>
                public Typ ResourceNameTyp { get; }
            }

            public Definition(string ns, string fullSymbol, Resource resource, ResourceSet resourceSet)
            {
                FullSymbol = fullSymbol;
                var symbolShortName = fullSymbol.Split('.').Last();
                DocName = symbolShortName;
                FieldName = symbolShortName.ToLowerCamelCase();
                var oneResourceNameTyp = Typ.Manual(ns, $"{symbolShortName}Name");
                One = new OneDef(oneResourceNameTyp, resource);
                // TODO: Set support.
            }

            /// <summary>The fully-package-qualified symbol name of the resource. E.g. `google.api.Project`.</summary>
            public string FullSymbol { get; }

            /// <summary>The name of this resource, suitable for use as a C# field or parameter. I.e. lower-camel-cased.</summary>
            public string FieldName { get; }

            /// <summary>The name of this resource, as used in XmlDoc.</summary>
            public string DocName { get; }

            /// <summary>Definition of resource that is not a set. Null if only a set.</summary>
            public OneDef One { get; }

            /// <summary>Definition of resource that is a set. Null if not a set.</summary>
            public SetDef Set { get; }
        }

        /// <summary>
        /// Details about a resource usage by a proto field.
        /// </summary>
        public class Field
        {
            public Field(FieldDescriptor fieldDesc, Definition resourceDefinition)
            {
                // TODO: Support resource-sets.
                UnderlyingPropertyName = fieldDesc.CSharpPropertyName();
                // This naming logic is copied directly from the Java generator.
                // TODO: Make sure it's correct for all combinations - I'm not sure it is!
                var typName = resourceDefinition.One.IsWildcard ? "ResourceName" : resourceDefinition.One.ResourceNameTyp.Name;
                var requireIdentifier = !((fieldDesc.IsRepeated && fieldDesc.Name.ToLowerInvariant() == "names") ||
                    (!fieldDesc.IsRepeated && fieldDesc.Name.ToLowerInvariant() == "name"));
                var requireAs = requireIdentifier || resourceDefinition.One.IsWildcard;
                var requirePlural = fieldDesc.IsRepeated;
                var name = requireIdentifier ? UnderlyingPropertyName : "";
                name += requireAs ? "As" : "";
                name += typName;
                name += requirePlural ? "s" : "";
                ResourcePropertyName = name;
                ResourceDefinition = resourceDefinition;
            }

            /// <summary>The C# name of the string-typed property underlying this resource.</summary>
            public string UnderlyingPropertyName { get; }

            /// <summary>The C# name of the resource property.</summary>
            public string ResourcePropertyName { get; }

            /// <summary>The resource definition for this field.</summary>
            public Definition ResourceDefinition { get; }
        }

        public static IEnumerable<Definition> LoadResourceDefinitions(FileDescriptor fileDesc)
        {
            // TODO: Resource sets.
            // Load file-level resource definitions.
            var resourcesBySymbol1 = fileDesc.CustomOptions.TryGetRepeatedMessage<Resource>(ProtoConsts.FileOption.ResourceDefinition, out var resources) ?
                resources.Select(resource => (symbol: MakeFullSymbol(fileDesc, null, resource.Symbol), resource)).ToList() :
                Enumerable.Empty<(string symbol, Resource resource)>();
            // Load message-level (shortcut) resource definitions.
            var resourcesBySymbol2 = fileDesc.MessageTypes.SelectMany(msg =>
                msg.Fields.InFieldNumberOrder().Select(field =>
                    field.CustomOptions.TryGetMessage<Resource>(ProtoConsts.FieldOption.Resource, out var resource) ? resource : null)
                    .Where(x => x != null)
                    .Select(resource => (symbol: MakeFullSymbol(null, msg, resource.Symbol), resource)))
                .ToList();
            // Check no duplicates.
            var duplicateSymbols = resourcesBySymbol1.Select(x => x.symbol).Concat(resourcesBySymbol2.Select(x => x.symbol))
                .GroupBy(x => x).Where(x => x.Count() > 1).Select(x => x.Key).ToList();
            if (duplicateSymbols.Any())
            {
                throw new InvalidOperationException($"Duplicate resources: {string.Join(", ", duplicateSymbols)}");
            }
            // Final result.
            return resourcesBySymbol1.Concat(resourcesBySymbol2).Select(x => new Definition(fileDesc.CSharpNamespace(), x.symbol, x.resource, null));
        }

        public static Field LoadResourceReference(MessageDescriptor msgDesc, FieldDescriptor fieldDesc, IReadOnlyDictionary<string, Definition> resourcesByFullSymbol)
        {
            // TODO: Resource sets.
            var hasResource = fieldDesc.CustomOptions.TryGetMessage<Resource>(ProtoConsts.FieldOption.Resource, out var resource);
            var hasResourceRef = fieldDesc.CustomOptions.TryGetString(ProtoConsts.FieldOption.ResourceReference, out var resourceRef);
            if (hasResource && hasResourceRef)
            {
                throw new InvalidOperationException($"Cannot have both `resource` and `resource_reference` options on field: {fieldDesc.FullName}");
            }
            string fullSymbol;
            if (hasResource)
            {
                fullSymbol = MakeFullSymbol(null, msgDesc, resource.Symbol);
            }
            else if (hasResourceRef)
            {
                fullSymbol = MakeFullSymbol(msgDesc.File, null, resourceRef);
            }
            else
            {
                return null;
            }
            if (!resourcesByFullSymbol.TryGetValue(fullSymbol, out var resourceDefinition))
            {
                throw new InvalidOperationException($"Invalid reference to non-existant resource: {fullSymbol}");
            }
            return new Field(fieldDesc, resourceDefinition);
        }

        private static string MakeFullSymbol(FileDescriptor file, MessageDescriptor msg, string symbol) =>
            string.IsNullOrEmpty(symbol) ?
                msg?.FullName ?? throw new InvalidOperationException("Symbol must be set in a file-level resource") :
                symbol.Contains('.') ? symbol : $"{(file ?? msg.File).Package}.{symbol}";
    }
}
