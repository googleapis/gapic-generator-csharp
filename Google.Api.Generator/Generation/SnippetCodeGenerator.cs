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
using Google.Api.Generator.Utils.Roslyn;
using Google.Api.Generator.Utils;
using Google.LongRunning;
using Google.Protobuf;
using Google.Protobuf.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Google.Api.Generator.Utils.Roslyn.Modifier;
using static Google.Api.Generator.Utils.Roslyn.RoslynBuilder;

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
            var ns = Namespace(_svc.SnippetsNamespace);
            using (_ctx.InNamespace(ns))
            {
                var cls = Class(Public | Sealed, _svc.SnippetsTyp)
                    .WithXmlDoc(XmlDoc.Summary("Generated snippets."));
                using (_ctx.InClass(cls))
                {
                    cls = cls.AddMembers(GenerateMethods().ToArray());
                }
                ns = ns.AddMembers(cls);
            }
            return _ctx.CreateCompilationUnit(ns);
        }

        private IEnumerable<MethodDeclarationSyntax> GenerateMethods()
        {
            foreach (var method in _svc.Methods)
            {
                var methodDef = new MethodDef(_ctx, _svc, method);
                switch (method)
                {
                    case MethodDetails.Normal _:
                        yield return methodDef.SyncRequestMethod;
                        yield return methodDef.AsyncRequestMethod;
                        foreach (var signature in methodDef.Signatures)
                        {
                            yield return signature.SyncMethod;
                            yield return signature.AsyncMethod;
                            foreach (var resourceName in signature.ResourceNames)
                            {
                                yield return resourceName.SyncMethod;
                                yield return resourceName.AsyncMethod;
                            }
                        }
                        break;
                    case MethodDetails.Lro _:
                        yield return methodDef.SyncLroRequestMethod;
                        yield return methodDef.AsyncLroRequestMethod;
                        foreach (var signature in methodDef.Signatures)
                        {
                            yield return signature.SyncLroMethod;
                            yield return signature.AsyncLroMethod;
                            foreach (var resourceName in signature.ResourceNames)
                            {
                                yield return resourceName.SyncLroMethod;
                                yield return resourceName.AsyncLroMethod;
                            }
                        }
                        break;
                    case MethodDetails.Paginated _:
                        yield return methodDef.SyncPaginatedRequestMethod;
                        yield return methodDef.AsyncPaginatedRequestMethod;
                        foreach (var signature in methodDef.Signatures)
                        {
                            yield return signature.SyncPaginatedMethod;
                            yield return signature.AsyncPaginatedMethod;
                            foreach (var resourceName in signature.ResourceNames)
                            {
                                yield return resourceName.SyncPaginatedMethod;
                                yield return resourceName.AsyncPaginatedMethod;
                            }
                        }
                        break;
                    case MethodDetails.ServerStreaming _:
                        yield return methodDef.ServerStreamingRequestMethod;
                        foreach (var signature in methodDef.Signatures)
                        {
                            yield return signature.ServerStreamingMethod;
                            foreach (var resourceName in signature.ResourceNames)
                            {
                                yield return resourceName.ServerStreamingMethod;
                            }
                        }
                        break;
                    case MethodDetails.BidiStreaming _:
                        yield return methodDef.BidiStreamingMethod;
                        break;
                }
            }
        }

        private class MethodDef
        {
            public MethodDef(SourceFileContext ctx, ServiceDetails svc, MethodDetails method) =>
                (Ctx, Svc, Method) = (ctx, svc, method);

            private SourceFileContext Ctx { get; }
            private ServiceDetails Svc { get; }
            private MethodDetails Method { get; }
            private MethodDetails.Lro MethodLro => (MethodDetails.Lro)Method;
            private MethodDetails.Paginated MethodPaginated => (MethodDetails.Paginated)Method;
            private MethodDetails.IStreaming MethodStreaming => (MethodDetails.IStreaming)Method;

            private LocalDeclarationStatementSyntax Client => Local(Ctx.Type(Svc.ClientAbstractTyp), Svc.SnippetsClientName);
            private LocalDeclarationStatementSyntax Request => Local(Ctx.Type(Method.RequestTyp), "request");
            private LocalDeclarationStatementSyntax Response => Local(Ctx.Type(Method.SyncReturnTyp), "response");
            private LocalDeclarationStatementSyntax AsyncResponse => Local(Ctx.Type(Method.AsyncReturnTyp), "response");
            private LocalDeclarationStatementSyntax LroCompletedResponse => Local(Ctx.Type(MethodLro.OperationTyp), "completedResponse");
            private LocalDeclarationStatementSyntax LroResult => Local(Ctx.Type(MethodLro.OperationResponseTyp), "result");
            private LocalDeclarationStatementSyntax LroOperationName => Local(Ctx.Type<string>(), "operationName");
            private LocalDeclarationStatementSyntax LroRetrievedResponse => Local(Ctx.Type(MethodLro.OperationTyp), "retrievedResponse");
            private LocalDeclarationStatementSyntax LroRetrievedResult => Local(Ctx.Type(MethodLro.OperationResponseTyp), "retrievedResult");
            private LocalDeclarationStatementSyntax PageSize => Local(Ctx.Type<int>(), "pageSize");
            private LocalDeclarationStatementSyntax SinglePage => Local(Ctx.Type(Typ.Generic(typeof(Page<>), MethodPaginated.ResourceTyp)), "singlePage");
            private LocalDeclarationStatementSyntax NextPageToken => Local(Ctx.Type<string>(), "nextPageToken");
            private LocalDeclarationStatementSyntax ResponseStream => Local(Ctx.Type(MethodStreaming.AsyncEnumeratorTyp), "responseStream");
            private LocalDeclarationStatementSyntax ResponseItem => Local(Ctx.Type(Method.ResponseTyp), "responseItem");
            private LocalDeclarationStatementSyntax ResponseHandlerTask => Local(Ctx.Type<Task>(), "responseHandlerTask");
            private LocalDeclarationStatementSyntax Done => Local(Ctx.Type<bool>(), "done");

            private ParameterSyntax PaginatedItem => Parameter(Ctx.Type(MethodPaginated.ResourceTyp), "item");
            private ParameterSyntax PaginatedPage => Parameter(Ctx.Type(Method.ResponseTyp), "page");

            private object DefaultValue(FieldDescriptor fieldDesc, Typ resourceTyp = null, bool topLevel = false)
            {
                var resources = Svc.Catalog.GetResourceDetailsByField(fieldDesc);
                if (resources is object)
                {
                    var resource = resources.FirstOrDefault(x => x.ResourceDefinition.ResourceNameTyp == resourceTyp) ?? resources[0];
                    var def = resource.ResourceDefinition;
                    object @default;
                    var pattern = def.Patterns.FirstOrDefault(x => !x.IsWildcard);
                    if (resourceTyp is null)
                    {
                        @default = pattern is null ?
                            "a/wildcard/resource" :
                            pattern.Template.Expand(pattern.Template.ParameterNames.Select(x => $"[{x.ToUpperInvariant()}]").ToList());
                    }
                    else
                    {
                        @default = pattern is null ?
                            (object)New(Ctx.Type<UnparsedResourceName>())("a/wildcard/resource") :
                            Ctx.Type(resourceTyp).Call(FactoryMethodName(pattern))
                                (pattern.Template.ParameterNames.Select(x => $"[{x.ToUpperInvariant()}]"));
                    }
                    return fieldDesc.IsRepeated ? Collection(@default, resourceTyp) : @default;
                }
                else
                {
                    if (fieldDesc.IsMap)
                    {
                        // A map is modelled as a repeated message containing key/value fields.
                        var parts = fieldDesc.MessageType.Fields.InFieldNumberOrder();
                        var keyValue = DefaultValue(parts[0]);
                        var valueValue = DefaultValue(parts[1]);
                        var collectionInitializer = CollectionInitializer(ComplexElementInitializer(keyValue, valueValue));
                        return topLevel
                            ? New(Ctx.Type(Typ.Generic(typeof(Dictionary<,>), ProtoTyp.Of(fieldDesc).GenericArgTyps.ToArray())))()
                                // We want new Dictionary<int, int> { ... } rather than new Dictionary<int, int>() { ... }
                                .WithArgumentList(null)
                                .WithInitializer(collectionInitializer)
                            : (object) collectionInitializer;
                    }
                    // See https://developers.google.com/protocol-buffers/docs/proto3#scalar
                    // Switch cases are ordered as in this doc. Please do not re-order.
                    object @default = fieldDesc.FieldType switch
                    {
                        FieldType.Double => default(double),
                        FieldType.Float => default(float),
                        FieldType.Int32 => default(int),
                        FieldType.Int64 => default(long),
                        FieldType.UInt32 => default(uint),
                        FieldType.UInt64 => default(ulong),
                        FieldType.SInt32 => default(int),
                        FieldType.SInt64 => default(long),
                        FieldType.Fixed32 => default(uint),
                        FieldType.Fixed64 => default(ulong),
                        FieldType.SFixed32 => default(int),
                        FieldType.SFixed64 => default(long),
                        FieldType.Bool => default(bool),
                        FieldType.String => "",
                        FieldType.Bytes => Ctx.Type<ByteString>().Access(nameof(ByteString.Empty)),
                        FieldType.Message => fieldDesc.MessageType.FullName switch
                        {
                            "google.protobuf.DoubleValue" => default(double),
                            "google.protobuf.FloatValue" => default(float),
                            "google.protobuf.Int64Value" => default(long),
                            "google.protobuf.UInt64Value" => default(ulong),
                            "google.protobuf.Int32Value" => default(int),
                            "google.protobuf.UInt32Value" => default(uint),
                            "google.protobuf.BoolValue" => default(bool),
                            "google.protobuf.StringValue" => "",
                            "google.protobuf.BytesValue" => Ctx.Type<ByteString>().Access(nameof(ByteString.Empty)),
                            _ => New(Ctx.Type(ProtoTyp.Of(fieldDesc.MessageType)))()
                        },
                        FieldType.Enum => Ctx.Type(ProtoTyp.Of(fieldDesc.EnumType)).Access(fieldDesc.EnumType.Values.First().CSharpName()),
                        _ => throw new InvalidOperationException($"Cannot generate default for proto type: {fieldDesc.FieldType}"),
                    };
                    return fieldDesc.IsRepeated ? Collection(@default, null) : @default;
                }

                object Collection(object value, Typ typ) => topLevel ?
                    NewArray(Ctx.ArrayType(Typ.ArrayOf(typ ?? ProtoTyp.Of(fieldDesc).GenericArgTyps.First())))(value) :
                    (object)CollectionInitializer(value);

                string FactoryMethodName(ResourceDetails.Definition.Pattern pattern)
                {
                    // Use the parameter names as a suffix, or the pattern string instead if there are no parameters.
                    string suffix = string.Join("", pattern.Template.ParameterNames.Select(x => x.RemoveSuffix("_id").ToUpperCamelCase()));
                    if (suffix == "")
                    {
                        suffix = pattern.PatternString.ToUpperCamelCase();
                    }
                    return $"From{suffix}";
                }
            }

            private IEnumerable<ObjectInitExpr> InitRequest()
            {
                foreach (var fieldDesc in Method.RequestMessageDesc.Fields.InFieldNumberOrder().Where(x => !x.IsDeprecated()))
                {
                    if (!IsPaginationField())
                    {
                        var resourceField = Svc.Catalog.GetResourceDetailsByField(fieldDesc)?[0];
                        yield return new ObjectInitExpr(resourceField?.ResourcePropertyName ?? fieldDesc.CSharpPropertyName(),
                            DefaultValue(fieldDesc, resourceField?.ResourceDefinition.ResourceNameTyp));
                    }

                    bool IsPaginationField() => Method is MethodDetails.Paginated paged &&
                        (fieldDesc.FieldNumber == paged.PageSizeFieldNumber || fieldDesc.FieldNumber == paged.PageTokenFieldNumber);
                }
            }

            private string SnippetTypes(IEnumerable<Typ> typs) => string.Join("", typs.Select(t => $"{Ctx.Type(t).ToString()}, "));

            private MethodDeclarationSyntax Sync(string methodName, IEnumerable<Typ> snippetTyps, object initRequest, object makeRequest) =>
                Method(Public, VoidType, methodName)()
                    .WithBody(
                        $"// Snippet: {Method.SyncMethodName}({SnippetTypes(snippetTyps)}{nameof(CallSettings)})",
                        "// Create client",
                        Client.WithInitializer(Ctx.Type(Svc.ClientAbstractTyp).Call("Create")()),
                        snippetTyps.Any() ? "// Initialize request argument(s)" : null,
                        initRequest,
                        "// Make the request",
                        makeRequest,
                        "// End snippet")
                    .WithXmlDoc(XmlDoc.Summary($"Snippet for {Method.SyncMethodName}"));

            private MethodDeclarationSyntax Async(string methodName, IEnumerable<Typ> snippetTyps, object initRequest, object makeRequest) =>
                Method(Public | Modifier.Async, Ctx.Type<Task>(), methodName)()
                    .WithBody(
                        $"// Snippet: {Method.AsyncMethodName}({SnippetTypes(snippetTyps)}{nameof(CallSettings)})",
                        $"// Additional: {Method.AsyncMethodName}({SnippetTypes(snippetTyps)}{nameof(CancellationToken)})",
                        "// Create client",
                        Client.WithInitializer(Await(Ctx.Type(Svc.ClientAbstractTyp).Call("CreateAsync")())),
                        "// Initialize request argument(s)",
                        initRequest,
                        "// Make the request",
                        makeRequest,
                        "// End snippet")
                    .WithXmlDoc(XmlDoc.Summary($"Snippet for {Method.AsyncMethodName}"));

            private MethodDeclarationSyntax SyncLro(string methodName, IEnumerable<Typ> snippetTyps, object initRequest, object makeRequest) =>
                Method(Public, VoidType, methodName)()
                    .WithBody(
                        $"// Snippet: {Method.SyncMethodName}({SnippetTypes(snippetTyps)}{nameof(CallSettings)})",
                        "// Create client",
                        Client.WithInitializer(Ctx.Type(Svc.ClientAbstractTyp).Call("Create")()),
                        "// Initialize request argument(s)",
                        initRequest,
                        "// Make the request",
                        makeRequest,
                        BlankLine,
                        "// Poll until the returned long-running operation is complete",
                        LroCompletedResponse.WithInitializer(Response.Call(nameof(Operation<ProtoMsg, ProtoMsg>.PollUntilCompleted))()),
                        "// Retrieve the operation result",
                        LroResult.WithInitializer(LroCompletedResponse.Access(nameof(Operation<ProtoMsg, ProtoMsg>.Result))),
                        BlankLine,
                        "// Or get the name of the operation",
                        LroOperationName.WithInitializer(Response.Access(nameof(Operation<ProtoMsg, ProtoMsg>.Name))),
                        "// This name can be stored, then the long-running operation retrieved later by name",
                        LroRetrievedResponse.WithInitializer(Client.Call(MethodLro.SyncPollMethodName)(LroOperationName)),
                        "// Check if the retrieved long-running operation has completed",
                        If(LroRetrievedResponse.Access(nameof(Operation<ProtoMsg, ProtoMsg>.IsCompleted)))
                            .Then(
                                "// If it has completed, then access the result",
                                LroRetrievedResult.WithInitializer(LroRetrievedResponse.Access(nameof(Operation<ProtoMsg, ProtoMsg>.Result)))),
                        "// End snippet")
                    .WithXmlDoc(XmlDoc.Summary($"Snippet for {Method.SyncMethodName}"));

            private MethodDeclarationSyntax AsyncLro(string methodName, IEnumerable<Typ> snippetTyps, object initRequest, object makeRequest) =>
                Method(Public | Modifier.Async, Ctx.Type<Task>(), methodName)()
                    .WithBody(
                        $"// Snippet: {Method.AsyncMethodName}({SnippetTypes(snippetTyps)}{nameof(CallSettings)})",
                        $"// Additional: {Method.AsyncMethodName}({SnippetTypes(snippetTyps)}{nameof(CancellationToken)})",
                        "// Create client",
                        Client.WithInitializer(Await(Ctx.Type(Svc.ClientAbstractTyp).Call("CreateAsync")())),
                        "// Initialize request argument(s)",
                        initRequest,
                        "// Make the request",
                        makeRequest,
                        BlankLine,
                        "// Poll until the returned long-running operation is complete",
                        LroCompletedResponse.WithInitializer(Await(Response.Call(nameof(Operation<ProtoMsg, ProtoMsg>.PollUntilCompletedAsync))())),
                        "// Retrieve the operation result",
                        LroResult.WithInitializer(LroCompletedResponse.Access(nameof(Operation<ProtoMsg, ProtoMsg>.Result))),
                        BlankLine,
                        "// Or get the name of the operation",
                        LroOperationName.WithInitializer(Response.Access(nameof(Operation<ProtoMsg, ProtoMsg>.Name))),
                        "// This name can be stored, then the long-running operation retrieved later by name",
                        LroRetrievedResponse.WithInitializer(Await(Client.Call(MethodLro.AsyncPollMethodName)(LroOperationName))),
                        "// Check if the retrieved long-running operation has completed",
                        If(LroRetrievedResponse.Access(nameof(Operation<ProtoMsg, ProtoMsg>.IsCompleted)))
                            .Then(
                                "// If it has completed, then access the result",
                                LroRetrievedResult.WithInitializer(LroRetrievedResponse.Access(nameof(Operation<ProtoMsg, ProtoMsg>.Result)))),
                        "// End snippet")
                    .WithXmlDoc(XmlDoc.Summary($"Snippet for {Method.AsyncMethodName}"));

            private string PaginatedSnippetTypes(bool isSig) => isSig ? "string, int?, " : "";

            private MethodDeclarationSyntax SyncPaginated(string methodName, IEnumerable<Typ> snippetTyps, object initRequest, object makeRequest, bool isSig) =>
                Method(Public, VoidType, methodName)()
                    .WithBody(
                        $"// Snippet: {Method.SyncMethodName}({SnippetTypes(snippetTyps)}{PaginatedSnippetTypes(isSig)}{nameof(CallSettings)})",
                        "// Create client",
                        Client.WithInitializer(Ctx.Type(Svc.ClientAbstractTyp).Call("Create")()),
                        "// Initialize request argument(s)",
                        initRequest,
                        "// Make the request",
                        makeRequest,
                        BlankLine,
                        "// Iterate over all response items, lazily performing RPCs as required",
                        ForEach(Ctx.Type(MethodPaginated.ResourceTyp), PaginatedItem.Identifier, Response)(
                            "// Do something with each item",
                            Ctx.Type(typeof(Console)).Call(nameof(Console.WriteLine))(PaginatedItem)),
                        BlankLine,
                        "// Or iterate over pages (of server-defined size), performing one RPC per page",
                        ForEach(Ctx.Type(Method.ResponseTyp), PaginatedPage.Identifier, Response.Call(nameof(PagedEnumerable<ProtoMsg, int>.AsRawResponses))())(
                            "// Do something with each page of items",
                            Ctx.Type(typeof(Console)).Call(nameof(Console.WriteLine))("A page of results:"),
                            ForEach(Ctx.Type(MethodPaginated.ResourceTyp), PaginatedItem.Identifier, PaginatedPage)(
                                "// Do something with each item",
                                Ctx.Type(typeof(Console)).Call(nameof(Console.WriteLine))(PaginatedItem))
                            ),
                        BlankLine,
                        "// Or retrieve a single page of known size (unless it's the final page), performing as many RPCs as required",
                        PageSize.WithInitializer(10),
                        SinglePage.WithInitializer(Response.Call(nameof(PagedEnumerable<ProtoMsg, int>.ReadPage))(PageSize)),
                        "// Do something with the page of items",
                        Ctx.Type(typeof(Console)).Call(nameof(Console.WriteLine))(Dollar($"A page of {PageSize} results (unless it's the final page):")),
                        ForEach(Ctx.Type(MethodPaginated.ResourceTyp), PaginatedItem.Identifier, SinglePage)(
                            "// Do something with each item",
                            Ctx.Type(typeof(Console)).Call(nameof(Console.WriteLine))(PaginatedItem)),
                        "// Store the pageToken, for when the next page is required.",
                        NextPageToken.WithInitializer(SinglePage.Access(nameof(Page<int>.NextPageToken))),
                        "// End snippet")
                    .WithXmlDoc(XmlDoc.Summary($"Snippet for {Method.SyncMethodName}"));

            private MethodDeclarationSyntax AsyncPaginated(string methodName, IEnumerable<Typ> snippetTyps, object initRequest, object makeRequest, bool isSig) =>
                Method(Public | Modifier.Async, Ctx.Type<Task>(), methodName)()
                    .WithBody(
                        $"// Snippet: {Method.AsyncMethodName}({SnippetTypes(snippetTyps)}{PaginatedSnippetTypes(isSig)}{nameof(CallSettings)})",
                        "// Create client",
                        Client.WithInitializer(Await(Ctx.Type(Svc.ClientAbstractTyp).Call("CreateAsync")())),
                        "// Initialize request argument(s)",
                        initRequest,
                        "// Make the request",
                        makeRequest,
                        BlankLine,
                        "// Iterate over all response items, lazily performing RPCs as required",
                        Await(AsyncResponse.Call(Ctx.Import(typeof(AsyncEnumerable), nameof(AsyncEnumerable.ForEachAsync)))(LambdaTyped(PaginatedItem)(
                            "// Do something with each item",
                            Ctx.Type(typeof(Console)).Call(nameof(Console.WriteLine))(PaginatedItem)))),
                        BlankLine,
                        "// Or iterate over pages (of server-defined size), performing one RPC per page",
                        Await(AsyncResponse.Call(nameof(PagedEnumerable<ProtoMsg, int>.AsRawResponses))().Call(nameof(AsyncEnumerable.ForEachAsync))(LambdaTyped(PaginatedPage)(
                            "// Do something with each page of items",
                            Ctx.Type(typeof(Console)).Call(nameof(Console.WriteLine))("A page of results:"),
                            ForEach(Ctx.Type(MethodPaginated.ResourceTyp), PaginatedItem.Identifier, PaginatedPage)(
                                "// Do something with each item",
                                Ctx.Type(typeof(Console)).Call(nameof(Console.WriteLine))(PaginatedItem))
                            ))),
                        BlankLine,
                        "// Or retrieve a single page of known size (unless it's the final page), performing as many RPCs as required",
                        PageSize.WithInitializer(10),
                        SinglePage.WithInitializer(Await(AsyncResponse.Call(nameof(PagedAsyncEnumerable<ProtoMsg, int>.ReadPageAsync))(PageSize))),
                        "// Do something with the page of items",
                        Ctx.Type(typeof(Console)).Call(nameof(Console.WriteLine))(Dollar($"A page of {PageSize} results (unless it's the final page):")),
                        ForEach(Ctx.Type(MethodPaginated.ResourceTyp), PaginatedItem.Identifier, SinglePage)(
                            "// Do something with each item",
                            Ctx.Type(typeof(Console)).Call(nameof(Console.WriteLine))(PaginatedItem)),
                        "// Store the pageToken, for when the next page is required.",
                        NextPageToken.WithInitializer(SinglePage.Access(nameof(Page<int>.NextPageToken))),
                        "// End snippet")
                    .WithXmlDoc(XmlDoc.Summary($"Snippet for {Method.SyncMethodName}"));

            private MethodDeclarationSyntax ServerStreaming(string methodName, IEnumerable<Typ> snippetTyps, object initRequest, object makeRequest) =>
                Method(Public | Modifier.Async, Ctx.Type<Task>(), methodName)()
                    .WithBody(
                        $"// Snippet: {Method.SyncMethodName}({SnippetTypes(snippetTyps)}{nameof(CallSettings)})",
                        "// Create client",
                        Client.WithInitializer(Ctx.Type(Svc.ClientAbstractTyp).Call("Create")()),
                        snippetTyps.Any() ? "// Initialize request argument(s)" : null,
                        initRequest,
                        "// Make the request, returning a streaming response",
                        makeRequest,
                        BlankLine,
                        "// Read streaming responses from server until complete",
                        "// Note that C# 8 code can use await foreach",
                        ResponseStream.WithInitializer(Response.Call(nameof(ServerStreamingBase<int>.GetResponseStream))()),
                        While(Await(ResponseStream.Call(nameof(IAsyncEnumerator<int>.MoveNextAsync))()))(
                            ResponseItem.WithInitializer(ResponseStream.Access(nameof(IAsyncEnumerator<int>.Current))),
                            "// Do something with streamed response"),
                        "// The response stream has completed",
                        "// End snippet")
                    .WithXmlDoc(XmlDoc.Summary($"Snippet for {Method.SyncMethodName}"));

            private object InitRequestObject => Request.WithInitializer(New(Ctx.Type(Method.RequestTyp))().WithInitializer(InitRequest().ToArray()));

            public MethodDeclarationSyntax SyncRequestMethod => Sync(Method.SyncSnippetMethodName, new[] { Method.RequestTyp },
                InitRequestObject, Method.SyncReturnTyp is Typ.VoidTyp ?
                    (object)Client.Call(Method.SyncMethodName)(Request) :
                    Response.WithInitializer(Client.Call(Method.SyncMethodName)(Request)));

            public MethodDeclarationSyntax AsyncRequestMethod => Async(Method.AsyncSnippetMethodName, new[] { Method.RequestTyp },
                InitRequestObject, Method.SyncReturnTyp is Typ.VoidTyp ?
                    (object)Await(Client.Call(Method.AsyncMethodName)(Request)) :
                    Response.WithInitializer(Await(Client.Call(Method.AsyncMethodName)(Request))));

            public MethodDeclarationSyntax SyncLroRequestMethod => SyncLro(Method.SyncSnippetMethodName, new[] { Method.RequestTyp },
                InitRequestObject, Response.WithInitializer(Client.Call(Method.SyncMethodName)(Request)));

            public MethodDeclarationSyntax AsyncLroRequestMethod => AsyncLro(Method.AsyncSnippetMethodName, new[] { Method.RequestTyp },
                InitRequestObject, Response.WithInitializer(Await(Client.Call(Method.AsyncMethodName)(Request))));

            public MethodDeclarationSyntax SyncPaginatedRequestMethod => SyncPaginated(Method.SyncSnippetMethodName, new[] { Method.RequestTyp },
                InitRequestObject, Response.WithInitializer(Client.Call(Method.SyncMethodName)(Request)), isSig: false);

            public MethodDeclarationSyntax AsyncPaginatedRequestMethod => AsyncPaginated(Method.AsyncSnippetMethodName, new[] { Method.RequestTyp },
                InitRequestObject, AsyncResponse.WithInitializer(Client.Call(Method.AsyncMethodName)(Request)), isSig: false);

            public MethodDeclarationSyntax ServerStreamingRequestMethod => ServerStreaming(Method.SyncSnippetMethodName, new[] { Method.RequestTyp },
                InitRequestObject, Response.WithInitializer(Client.Call(Method.SyncMethodName)(Request)));

            public MethodDeclarationSyntax BidiStreamingMethod =>
                Method(Public | Modifier.Async, Ctx.Type<Task>(), Method.SyncMethodName)()
                    .WithBody(
                        $"// Snippet: {Method.SyncMethodName}({nameof(CallSettings)}, {nameof(BidirectionalStreamingSettings)})",
                        "// Create client",
                        Client.WithInitializer(Ctx.Type(Svc.ClientAbstractTyp).Call("Create")()),
                        "// Initialize streaming call, retrieving the stream object",
                        Response.WithInitializer(Client.Call(Method.SyncMethodName)()),
                        BlankLine,
                        "// Sending requests and retrieving responses can be arbitrarily interleaved",
                        "// Exact sequence will depend on client/server behavior",
                        BlankLine,
                        "// Create task to do something with responses from server",
                        ResponseHandlerTask.WithInitializer(Ctx.Type<Task>().Call(nameof(Task.Run))(LambdaTyped(null, async: true)(
                            "// Note that C# 8 code can use await foreach",
                            ResponseStream.WithInitializer(Response.Call(nameof(ServerStreamingBase<int>.GetResponseStream))()),
                            While(Await(ResponseStream.Call(nameof(IAsyncEnumerator<int>.MoveNextAsync))()))(
                                ResponseItem.WithInitializer(ResponseStream.Access(nameof(IAsyncEnumerator<int>.Current))),
                                "// Do something with streamed response"
                                ),
                            "// The response stream has completed"
                            ))),
                        BlankLine,
                        "// Send requests to the server",
                        Done.WithInitializer(false),
                        While(Not(Done))(
                            "// Initialize a request",
                            InitRequestObject,
                            "// Stream a request to the server",
                            Await(Response.Call(nameof(BidirectionalStreamingBase<int, int>.WriteAsync))(Request)),
                            "// Set \"done\" to true when sending requests is complete"),
                        BlankLine,
                        "// Complete writing requests to the stream",
                        Await(Response.Call(nameof(BidirectionalStreamingBase<int, int>.WriteCompleteAsync))()),
                        "// Await the response handler",
                        "// This will complete once all server responses have been processed",
                        Await(ResponseHandlerTask),
                        "// End snippet")
                    .WithXmlDoc(XmlDoc.Summary($"Snippet for {Method.SyncMethodName}"));

            public class Signature
            {
                public Signature(MethodDef def, MethodDetails.Signature sig, int? index) => (_def, _sig, _index) = (def, sig, index);

                private readonly MethodDef _def;
                private readonly MethodDetails.Signature _sig;
                private readonly int? _index;
                private SourceFileContext Ctx => _def.Ctx;
                private MethodDetails Method => _def.Method;

                private string SyncMethodName => Method.SyncMethodName + (_index is int index ? (index + 1).ToString() : "");
                private string AsyncMethodName => $"{Method.AsyncMethodName.Substring(0, Method.AsyncMethodName.Length - 5)}{(_index is int index ? (index + 1).ToString() : "")}Async";
                
                private Typ MaybeEnumerable(bool repeated, Typ typ) => !repeated || typ == null ? typ : Typ.Generic(typeof(IEnumerable<>), typ);
                private IEnumerable<LocalDeclarationStatementSyntax> InitRequestArgs(bool resourceNameAsString) =>
                    _sig.Fields.Select(f =>
                        Local(Ctx.Type(resourceNameAsString ? f.Typ : MaybeEnumerable(f.IsRepeated, f.FieldResources?[0].ResourceDefinition.ResourceNameTyp) ?? f.Typ),
                            f.Descs.Last().CSharpFieldName())
                        .WithInitializer(_def.DefaultValue(f.Descs.Last(), null, topLevel: true)));
                private IEnumerable<LocalDeclarationStatementSyntax> InitRequestArgsNormal => InitRequestArgs(resourceNameAsString: true);
                private IEnumerable<LocalDeclarationStatementSyntax> InitRequestArgsResourceNames => InitRequestArgs(resourceNameAsString: false);

                private IEnumerable<Typ> SnippetCommentResourceNameArgs => throw new NotImplementedException();

                public MethodDeclarationSyntax SyncMethod => _def.Sync(SyncMethodName, _sig.Fields.Select(f => f.Typ),
                    InitRequestArgsNormal, Method.SyncReturnTyp is Typ.VoidTyp ?
                        (object)_def.Client.Call(Method.SyncMethodName)(InitRequestArgsNormal.ToArray()) :
                        _def.Response.WithInitializer(_def.Client.Call(Method.SyncMethodName)(InitRequestArgsNormal.ToArray())));

                public MethodDeclarationSyntax AsyncMethod => _def.Async(AsyncMethodName, _sig.Fields.Select(f => f.Typ),
                    InitRequestArgsNormal, Method.SyncReturnTyp is Typ.VoidTyp ?
                        (object)Await(_def.Client.Call(Method.AsyncMethodName)(InitRequestArgsNormal.ToArray())) :
                        _def.Response.WithInitializer(Await(_def.Client.Call(Method.AsyncMethodName)(InitRequestArgsNormal.ToArray()))));

                public MethodDeclarationSyntax SyncLroMethod => _def.SyncLro(SyncMethodName, _sig.Fields.Select(f => f.Typ),
                    InitRequestArgsNormal, _def.Response.WithInitializer(_def.Client.Call(Method.SyncMethodName)(InitRequestArgsNormal.ToArray())));

                public MethodDeclarationSyntax AsyncLroMethod => _def.AsyncLro(AsyncMethodName, _sig.Fields.Select(f => f.Typ),
                    InitRequestArgsNormal, _def.Response.WithInitializer(Await(_def.Client.Call(Method.AsyncMethodName)(InitRequestArgsNormal.ToArray()))));

                private IEnumerable<object> PaginatedArgs(IEnumerable<LocalDeclarationStatementSyntax> args)
                {
                    if (_def.RequireFinalNamedArg(_sig))
                    {
                        var argN = args.Last();
                        return args.Cast<object>().SkipLast(1).Append((argN.Declaration.Variables[0].Identifier.Text, argN));
                    }
                    return args;
                }

                public MethodDeclarationSyntax SyncPaginatedMethod => _def.SyncPaginated(SyncMethodName, _sig.Fields.Select(f => f.Typ),
                    InitRequestArgsNormal, _def.Response.WithInitializer(_def.Client.Call(Method.SyncMethodName)(PaginatedArgs(InitRequestArgsNormal).ToArray())), isSig: true);

                public MethodDeclarationSyntax AsyncPaginatedMethod => _def.AsyncPaginated(AsyncMethodName, _sig.Fields.Select(f => f.Typ),
                    InitRequestArgsNormal, _def.AsyncResponse.WithInitializer(_def.Client.Call(Method.AsyncMethodName)(PaginatedArgs(InitRequestArgsNormal).ToArray())), isSig: true);

                public MethodDeclarationSyntax ServerStreamingMethod => _def.ServerStreaming(SyncMethodName, _sig.Fields.Select(f => f.Typ),
                    InitRequestArgsNormal, _def.Response.WithInitializer(_def.Client.Call(Method.SyncMethodName)(InitRequestArgsNormal.ToArray())));

                public class ResourceName
                {
                    public static IEnumerable<ResourceName> Create(Signature sig)
                    {
                        if (!sig._sig.Fields.Any(f => f.FieldResources is object))
                        {
                            return Enumerable.Empty<ResourceName>();
                        }
                        var allOverloads = sig._sig.Fields.Aggregate(ImmutableList.Create(ImmutableList<Typ>.Empty), (overloads, f) =>
                        {
                            var typs = f.FieldResources is null ? new[] { f.Typ }
                                : f.FieldResources.Where(resDetails => resDetails.ContainsWildcard != false).Select(x => x.ResourceDefinition.ResourceNameTyp);
                            return overloads.SelectMany(overload => typs.Select(typ => overload.Add(typ))).ToImmutableList();
                        }).ToList();
                        return allOverloads.Select((typs, index) => new ResourceName(sig, typs, allOverloads.Count > 1 ? (int?)(index + 1) : null));
                    }

                    private ResourceName(Signature sig, IReadOnlyList<Typ> typs, int? index) => (_sig, _typs, _index) = (sig, typs, index);

                    private readonly Signature _sig;
                    private readonly IReadOnlyList<Typ> _typs;
                    private readonly int? _index;
                    private SourceFileContext Ctx => _sig.Ctx;
                    private MethodDetails Method => _sig.Method;
                    private string SyncMethodName => $"{_sig.SyncMethodName}ResourceNames{(_index?.ToString() ?? "")}";
                    private string AsyncMethodName => $"{SyncMethodName}Async";

                    private IEnumerable<LocalDeclarationStatementSyntax> InitRequestArgs =>
                        _sig._sig.Fields.Zip(_typs, (f, typ) =>
                            Local(Ctx.Type(f.IsRepeated && f.FieldResources is object ? Typ.Generic(typeof(IEnumerable<>), typ) : typ),
                                f.Descs.Last().CSharpFieldName()).WithInitializer(_sig._def.DefaultValue(f.Descs.Last(), typ, topLevel: true)));

                    private IEnumerable<Typ> SnippetTyps =>
                        _sig._sig.Fields.Zip(_typs, (f, typ) => f.IsRepeated && f.FieldResources is object ? Typ.Generic(typeof(IEnumerable<>), typ) : typ);

                    public MethodDeclarationSyntax SyncMethod => _sig._def.Sync(SyncMethodName, SnippetTyps, InitRequestArgs, Method.SyncReturnTyp is Typ.VoidTyp ?
                        (object)_sig._def.Client.Call(Method.SyncMethodName)(InitRequestArgs.ToArray()) :
                        _sig._def.Response.WithInitializer(_sig._def.Client.Call(Method.SyncMethodName)(InitRequestArgs.ToArray())));

                    public MethodDeclarationSyntax AsyncMethod => _sig._def.Async(AsyncMethodName, SnippetTyps, InitRequestArgs, Method.SyncReturnTyp is Typ.VoidTyp ?
                        (object)Await(_sig._def.Client.Call(Method.AsyncMethodName)(InitRequestArgs.ToArray())) :
                        _sig._def.Response.WithInitializer(Await(_sig._def.Client.Call(Method.AsyncMethodName)(InitRequestArgs.ToArray()))));

                    public MethodDeclarationSyntax SyncLroMethod => _sig._def.SyncLro(SyncMethodName, SnippetTyps, InitRequestArgs,
                        _sig._def.Response.WithInitializer(_sig._def.Client.Call(Method.SyncMethodName)(InitRequestArgs.ToArray())));

                    public MethodDeclarationSyntax AsyncLroMethod => _sig._def.AsyncLro(AsyncMethodName, SnippetTyps, InitRequestArgs,
                        _sig._def.Response.WithInitializer(Await(_sig._def.Client.Call(Method.AsyncMethodName)(InitRequestArgs.ToArray()))));

                    public MethodDeclarationSyntax SyncPaginatedMethod => _sig._def.SyncPaginated(SyncMethodName, SnippetTyps, InitRequestArgs,
                        _sig._def.Response.WithInitializer(_sig._def.Client.Call(Method.SyncMethodName)(_sig.PaginatedArgs(InitRequestArgs).ToArray())), true);

                    public MethodDeclarationSyntax AsyncPaginatedMethod => _sig._def.AsyncPaginated(AsyncMethodName, SnippetTyps, InitRequestArgs,
                        _sig._def.AsyncResponse.WithInitializer(_sig._def.Client.Call(Method.AsyncMethodName)(_sig.PaginatedArgs(InitRequestArgs).ToArray())), true);

                    public MethodDeclarationSyntax ServerStreamingMethod => _sig._def.ServerStreaming(SyncMethodName, SnippetTyps, InitRequestArgs,
                        _sig._def.Response.WithInitializer(_sig._def.Client.Call(Method.SyncMethodName)(InitRequestArgs.ToArray())));
                }

                public IEnumerable<ResourceName> ResourceNames => ResourceName.Create(this);
            }

            private bool RequireFinalNamedArg(MethodDetails.Signature sig)
            {
                // The last argument must be named, if there is a signature with identical types and an extra string parameter.
                var stringTyp = Typ.Of<string>();
                var sigTyps = sig.Fields.Select(x => x.Typ).ToList();
                return Method.Signatures.Any(s => s.Fields.Select(x => x.Typ).Append(stringTyp).SequenceEqual(sigTyps));
            }

            public IEnumerable<Signature> Signatures => Method.Signatures.Select((sig, i) => new Signature(this, sig, Method.Signatures.Count > 1 ? i : (int?)null));
        }
    }
}
