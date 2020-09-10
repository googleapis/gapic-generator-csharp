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
using Google.Apis.Services;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;
using static Google.Api.Generator.Utils.Roslyn.RoslynBuilder;

namespace Google.Api.Generator.Rest.Models
{
    public class MethodModel
    {
        private RestMethod _restMethod;

        public PackageModel Package { get; }
        /// <summary>
        /// Resource that owns this method, if any.
        /// </summary>
        public ResourceModel Resource { get; }
        
        public IReadOnlyList<ParameterModel> Parameters { get; }
        public Typ ParentTyp { get; }
        public Typ RequestTyp { get; }
        public string Name { get; }

        public MethodModel(PackageModel package, ResourceModel resource, string name, RestMethod restMethod)
        {
            Package = package;
            Resource = resource;
            Name = name.ToUpperCamelCase();
            ParentTyp = resource?.Typ ?? package.ServiceTyp;
            RequestTyp = Typ.Nested(ParentTyp, $"{Name}Request");
            Parameters = CreateParameterList(package, restMethod);
            _restMethod = restMethod;
        }

        private static IReadOnlyList<ParameterModel> CreateParameterList(PackageModel package, RestMethod restMethod)
        {
            var parameterOrder = restMethod.ParameterOrder ?? new List<string>();
            // TODO: Skip the Alt parameter
            // TODO: Handle the body parameter if restMethod.Request is non-null
            return (restMethod.Parameters ?? new Dictionary<string, JsonSchema>())
                .Select(pair => new ParameterModel(pair.Key, pair.Value))
                .OrderBy(p => !p.IsRequired)
                .ThenBy(p => parameterOrder.IndexOf(p.Name))
                .ToList()
                .AsReadOnly();
        }

        public IEnumerable<MemberDeclarationSyntax> GenerateDeclarations(SourceFileContext ctx)
        {
            yield return GenerateMethodDeclaration(ctx);
            yield return GenerateRequestType(ctx);
        }

        private MethodDeclarationSyntax GenerateMethodDeclaration(SourceFileContext ctx)
        {
            var docs = new List<DocumentationCommentTriviaSyntax>();
            var methodParameters = Parameters.TakeWhile(p => p.IsRequired).ToList();
            var parameterDeclarations = methodParameters.Select(p => Parameter(ctx.Type(p.Typ), p.Name)); 
            if (_restMethod.Description is object)
            {
                docs.Add(XmlDoc.Summary(_restMethod.Description));
            }
            docs.AddRange(methodParameters.Zip(parameterDeclarations).Select(pair => XmlDoc.Param(pair.Second, pair.First.Description)));

            var ctorArguments = new object[] { Field(0, ctx.Type<IClientService>(), "service") }
                .Concat(parameterDeclarations)
                .ToArray();
            var method = Method(Modifier.Public, ctx.Type(RequestTyp), Name)(parameterDeclarations.ToArray())
                .WithBlockBody(Return(New(ctx.Type(RequestTyp))(ctorArguments)))
                .WithXmlDoc(docs.ToArray());
            return method;
        }

        private ClassDeclarationSyntax GenerateRequestType(SourceFileContext ctx)
        {
            // FIXME: Need to specify the type argument for the base request type.
            var cls = Class(Modifier.Public, RequestTyp, ctx.Type(Package.BaseRequestTyp));
            return cls;
        }
    }
}
