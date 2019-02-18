// Copyright 2018 Google Inc. All Rights Reserved.
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
using Google.Api.Gax.Grpc;
using Google.Api.Generator.ProtoUtils;
using Google.Api.Generator.RoslynUtils;
using Google.Api.Generator.Utils;
using Google.Protobuf;
using Google.Protobuf.Reflection;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Google.Api.Generator.RoslynUtils.Modifier;
using static Google.Api.Generator.RoslynUtils.RoslynBuilder;

namespace Google.Api.Generator.Generation
{
    internal class SnippetCodeGenerator
    {
        public static CompilationUnitSyntax Generate(SourceFileContext ctx, ServiceDetails svc) =>
            new SnippetCodeGenerator(ctx, svc).Generate();

        private SnippetCodeGenerator(SourceFileContext ctx, ServiceDetails svc) => (_ctx, _svc) = (ctx, svc);

        private readonly SourceFileContext _ctx;
        private readonly ServiceDetails _svc;

        private CompilationUnitSyntax Generate()
        {
            var ns = Namespace(_svc.Namespace);
            using (_ctx.InNamespace(ns))
            {
                var cls = Class(Public | Sealed, _svc.SnippetsTyp)
                    .WithXmlDoc(XmlDoc.Summary("Generated snippets."));
                using (_ctx.InClass(cls))
                {
                    cls = cls.AddMembers(GenerateMethods().ToArray());
                }
                ns = ns.AddMembers(cls);
                //var settingsClass = ServiceSettingsCodeGenerator.Generate(ctx, svc);
                //var abstractClientClass = ServiceAbstractClientClassCodeGenerator.Generate(ctx, svc);
                //var implClientClass = ServiceImplClientClassGenerator.Generate(ctx, svc);
                //ns = ns.AddMembers(settingsClass, abstractClientClass, implClientClass);

                //ns = ns.AddMembers(PaginatedPartialClasses(ctx, svc).ToArray());
                //ns = ns.AddMembers(LroPartialClasses(ctx, svc).ToArray());
            }
            return _ctx.CreateCompilationUnit(ns);
        }

        private IEnumerable<MethodDeclarationSyntax> GenerateMethods()
        {
            foreach (var method in _svc.Methods)
            {
                IEnumerable<MethodDeclarationSyntax> methods;
                switch (method)
                {
                    case MethodDetails.Normal normal:
                        methods = GenerateNormalMethod(normal);
                        break;
                    default:
                        methods = Enumerable.Empty<MethodDeclarationSyntax>();
                        break;
                }
                foreach (var methodDecl in methods)
                {
                    yield return methodDecl;
                }
            }
        }

        private IEnumerable<ObjectInitExpr> InitRequest(MethodDetails method)
        {
            foreach (var fieldDesc in method.RequestMessageDesc.Fields.InFieldNumberOrder())
            {
                var resource = _svc.Catalog.GetResourceDetailsByField(fieldDesc);
                if (resource != null)
                {
                    // TODO: Resource-sets
                    var one = resource.ResourceDefinition.One;
                    object @default = one.IsWildcard ?
                        New(_ctx.Type<UnknownResourceName>())("a/wildcard/resource") :
                        New(_ctx.Type(one.ResourceNameTyp))(one.Template.ParameterNames.Select(x => $"[{x.ToUpperInvariant()}]"));
                    yield return new ObjectInitExpr(resource.ResourcePropertyName, fieldDesc.IsRepeated ? CollectionInitializer(@default) : @default);
                }
                else
                {
                    object @default;
                    if (fieldDesc.IsMap)
                    {
                        throw new NotImplementedException("Map types not yet implemented.");
                    }
                    switch (fieldDesc.FieldType)
                    {
                        case FieldType.Double: @default = default(double); break;
                        case FieldType.Float: @default = default(float); break;
                        case FieldType.Int32: @default = default(int); break;
                        case FieldType.Int64: @default = default(long); break;
                        case FieldType.UInt32: @default = default(uint); break;
                        case FieldType.UInt64: @default = default(ulong); break;
                        case FieldType.SInt32: @default = default(int); break;
                        case FieldType.SInt64: @default = default(long); break;
                        case FieldType.Fixed32: @default = default(uint); break;
                        case FieldType.Fixed64: @default = default(ulong); break;
                        case FieldType.SFixed32: @default = default(int); break;
                        case FieldType.SFixed64: @default = default(long); break;
                        case FieldType.Bool: @default = default(bool); break;
                        case FieldType.String: @default = ""; break;
                        case FieldType.Bytes: @default = _ctx.Type<ByteString>().Access(nameof(ByteString.Empty)); break;
                        case FieldType.Message: @default = New(_ctx.Type(Typ.Of(fieldDesc.MessageType)))(); break;
                        default: throw new InvalidOperationException($"Cannot generate default for proto type: {fieldDesc.FieldType}");

                    }
                    yield return new ObjectInitExpr(fieldDesc.CSharpPropertyName(), fieldDesc.IsRepeated ? CollectionInitializer(@default) : @default);
                }
            }
        }

        private IEnumerable<MethodDeclarationSyntax> GenerateNormalMethod(MethodDetails.Normal method)
        {
            var client = Local(_ctx.Type(_svc.ClientAbstractTyp), _svc.SnippetsClientName);
            // Sync request method
            var request = Local(_ctx.Type(method.RequestTyp), "request");
            var response = Local(_ctx.Type(method.ResponseTyp), "response");
            yield return Method(Public, VoidType, method.SyncSnippetMethodName)()
                .WithBody(
                    $"// Snippet: {method.SyncMethodName}({method.RequestTyp.Name}, {nameof(CallSettings)})",
                    "// Create client",
                    client.WithInitializer(_ctx.Type(_svc.ClientAbstractTyp).Call("Create")()),
                    "// Initialize request argument(s)",
                    request.WithInitializer(New(_ctx.Type(method.RequestTyp))().WithInitializer(InitRequest(method).ToArray())),
                    "// Make the request",
                    response.WithInitializer(client.Call(method.SyncMethodName)(request)),
                    "// End snippet")
                .WithXmlDoc(XmlDoc.Summary($"Snippet for {method.SyncMethodName}"));
            // Async request method
            yield return Method(Public | Async, _ctx.Type<Task>(), method.AsyncSnippetMethodName)()
                .WithBody(
                    $"// Snippet: {method.AsyncMethodName}({method.RequestTyp.Name}, {nameof(CallSettings)})",
                    $"// Additional: {method.AsyncMethodName}({method.RequestTyp.Name}, {nameof(CancellationToken)})",
                    "// Create client",
                    client.WithInitializer(Await(_ctx.Type(_svc.ClientAbstractTyp).Call("CreateAsync")())),
                    "// Initialize request argument(s)",
                    request.WithInitializer(New(_ctx.Type(method.RequestTyp))().WithInitializer(InitRequest(method).ToArray())),
                    "// Make the request",
                    response.WithInitializer(Await(client.Call(method.AsyncMethodName)(request))),
                    "// End snippet")
                .WithXmlDoc(XmlDoc.Summary($"Snippet for {method.AsyncMethodName}"));
        }
    }
}
