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
using static Google.Api.Generator.Utils.Roslyn.RoslynBuilder;

namespace Google.Api.Generator.Rest.Models
{
    public class DataModel
    {
        private readonly JsonSchema _schema;

        public PackageModel Package { get; }

        // TODO: work out what this should be.
        public string Parent => null;
        public string Name { get; }
        public Typ Typ { get; }

        public DataModel(PackageModel package, string name, JsonSchema schema)
        {
            Package = package;
            Name = name;
            Typ = Typ.Manual(Package.PackageName, Name);
            _schema = schema;
        }

        public ClassDeclarationSyntax GenerateClass(SourceFileContext ctx)
        {
            var cls = Class(Modifier.Public, Typ);
            if (_schema.Description is string description)
            {
                cls = cls.WithXmlDoc(XmlDoc.Summary(description));
            }
            return cls;
        }

    }
}

