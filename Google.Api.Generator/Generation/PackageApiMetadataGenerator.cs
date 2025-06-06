// Copyright 2022 Google LLC
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

using Google.Api.Gax.Grpc;
using Google.Api.Generator.ProtoUtils;
using Google.Api.Generator.Utils;
using Google.Api.Generator.Utils.Roslyn;
using Google.Cloud.Location;
using Google.LongRunning;
using Google.Protobuf;
using Google.Protobuf.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using static Google.Api.Generator.Utils.Roslyn.Modifier;
using static Google.Api.Generator.Utils.Roslyn.RoslynBuilder;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using IAM = Google.Cloud.Iam.V1;

namespace Google.Api.Generator.Generation
{
    internal class PackageApiMetadataGenerator
    {
        // FileDescriptors required for mixins. This feels somewhat fragile as a new service could be introduced - but that seems
        // *very* unlikely for the existing mixins, and we don't expect to add any new mixin APIs. The alternative would be to scan
        // the types in the mixin libraries via reflection, but this feels preferable. If we miss a proto which doesn't contain a service
        // and isn't used in a google.protobuf.Any anywhere, we should be okay anyway.
        private static readonly Dictionary<string, FileDescriptor[]> MixinToFileDescriptors = new Dictionary<string, FileDescriptor[]>
        {
            { Operations.Descriptor.FullName, new[] { OperationsReflection.Descriptor } },
            { IAM::IAMPolicy.Descriptor.FullName, new[] { IAM::PolicyReflection.Descriptor, IAM::IamPolicyReflection.Descriptor, IAM::OptionsReflection.Descriptor } },
            { Locations.Descriptor.FullName, new[] { LocationsReflection.Descriptor } }
        };

        internal const string ClassName = "PackageApiMetadata";
        internal const string FileName = ClassName + ".g.cs";
        internal const string PropertyName = "ApiMetadata";

        public static CompilationUnitSyntax GeneratePackageApiMetadata(
            string ns, SourceFileContext ctx, IEnumerable<FileDescriptor> packageFileDescriptors,
            bool hasLro, IEnumerable<string> mixins, Service serviceConfig, bool requestNumericEnumJsonEncoding)
        {
            // Treat LRO as just another mixin in this context.
            if (hasLro)
            {
                mixins = mixins.Append(Operations.Descriptor.FullName);
            }

            var allFileDescriptors = packageFileDescriptors.Concat(mixins.SelectMany(mixin => MixinToFileDescriptors[mixin]));

            var namespaceDeclaration = Namespace(ns);
            using (ctx.InNamespace(namespaceDeclaration))
            {
                var descriptorClass = GenerateClass(ns, ctx, allFileDescriptors, mixins, serviceConfig, requestNumericEnumJsonEncoding);
                namespaceDeclaration = namespaceDeclaration.AddMembers(descriptorClass);
            }
            return ctx.CreateCompilationUnit(namespaceDeclaration);
        }

        private static ClassDeclarationSyntax GenerateClass(string ns, SourceFileContext ctx, IEnumerable<FileDescriptor> fileDescriptors, IEnumerable<string> mixins, Service serviceConfig, bool requestNumericEnumJsonEncoding)
        {
            var typ = Typ.Manual(ns, ClassName);
            var cls = Class(Internal | Static, typ)
                .WithXmlDoc(XmlDoc.Summary("Static class to provide common access to package-wide API metadata."));

            var yieldStatements = fileDescriptors
                .OrderBy(p => p.CSharpNamespace(), StringComparer.Ordinal)
                .ThenBy(p => p.Name, StringComparer.Ordinal)
                .Select(GenerateYieldStatement)
                .ToArray();
            var fileDescriptorMethod = Method(Private | Static, ctx.Type(Typ.Of<IEnumerable<FileDescriptor>>()), "GetFileDescriptors")()
                .WithBlockBody(yieldStatements);

            var apiMetadataType = ctx.Type<ApiMetadata>();
            ExpressionSyntax initializer = New(apiMetadataType)(ns, IdentifierName(fileDescriptorMethod.Identifier));
            if (requestNumericEnumJsonEncoding)
            {
                var invocation = initializer.Call(nameof(ApiMetadata.WithRequestNumericEnumJsonEncoding))(true);
                initializer = invocation.WithExpression(invocation.Expression.WithAdditionalAnnotations(Annotations.LineBreakAnnotation));
            }
            var httpOverrides = (serviceConfig?.Http?.Rules ?? Enumerable.Empty<HttpRule>())
                // We only care about overrides for mixins. (There probably won't be any others present
                // anyway, but we should ignore them.)
                .Where(rule => mixins.Any(mixin => rule.Selector.StartsWith(mixin)))
                .ToDictionary(rule => rule.Selector, rule => new HttpRule(rule) { Selector = "" })
                .OrderBy(pair => pair.Key, StringComparer.Ordinal)
                .ToList();

            if (httpOverrides.Any())
            {
                var dictionaryInitializers = httpOverrides
                    .Select(pair => new object[] { pair.Key, GetKeyValuePairValue(pair.Value) })
                    .ToArray<object>();
                var invocation = initializer.Call(nameof(ApiMetadata.WithHttpRuleOverrides))(New(ctx.Type<Dictionary<string, ByteString>>())().WithCollectionInitializer(dictionaryInitializers));
                initializer = invocation.WithExpression(invocation.Expression.WithAdditionalAnnotations(Annotations.LineBreakAnnotation));
            }

            var property = AutoProperty(Internal | Static, apiMetadataType, PropertyName)
                .WithInitializer(initializer)
                .WithXmlDoc(XmlDoc.Summary("The ", apiMetadataType, " for services in this package."));
            return cls.AddMembers(property, fileDescriptorMethod);

            YieldStatementSyntax GenerateYieldStatement(FileDescriptor descriptor)
            {
                var type = ctx.Type(ProtoTyp.OfReflectionClass(descriptor));
                return YieldStatement(SyntaxKind.YieldReturnStatement, type.Access("Descriptor"));
            }

            object GetKeyValuePairValue(HttpRule rule)
            {
                var json = rule.ToString();
                var base64 = rule.ToByteString().ToBase64();
                var fromBase64 = ctx.Type<ByteString>().Call(nameof(ByteString.FromBase64))(base64);
                return fromBase64.WithLeadingTrivia(Comment($"// {json}"));
            }
        }
    }
}
