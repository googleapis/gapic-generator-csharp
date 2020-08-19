// Copyright 2020 Google LLC
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

using Google.Api.Generator.Utils;
using Google.Api.Generator.Utils.Roslyn;
using Google.Apis.Discovery.v1.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using static Google.Api.Generator.Utils.Roslyn.RoslynBuilder;

namespace Google.Api.Generator.Rest.Models
{
    public class ResourceModel
    {
        public PackageModel Package { get; }

        public string WireName { get; }

        /// <summary>
        /// The name as it appears as the key within the JSON dictionary.
        /// </summary>
        public string Name { get; }

        public string ClassName { get; }

        public string PropertyName { get; }

        public IReadOnlyList<MethodModel> Methods { get; }

        public Typ Typ { get; }

        public ResourceModel(PackageModel package, string name, RestResource discoveryResource)
        {
            Package = package;
            Name = name;
            Methods = discoveryResource.Methods?.ToReadOnlyList(pair => new MethodModel(package, pair.Key, pair.Value));
            PropertyName = package.ToClassName(name);
            ClassName = $"{PropertyName}Resource";
            Typ = Typ.Manual(package.PackageName, ClassName);
            WireName = "wirename";
        }

        public ClassDeclarationSyntax GenerateClass(SourceFileContext ctx)
        {
            var cls = Class(Modifier.Public, Typ.Manual(Package.PackageName, ClassName))
                // FIXME: Wirename is broken
                .WithXmlDoc(XmlDoc.Summary($"The {WireName} collection of methods."));
            return cls;
        }

    }
}
