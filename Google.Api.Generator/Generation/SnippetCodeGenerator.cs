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
using Google.Api.Generator.Utils;
using Google.Api.Generator.Utils.Formatting;
using Google.Api.Generator.Utils.Roslyn;
using Google.Cloud.Tools.SnippetGen.SnippetIndex.V1;
using Google.LongRunning;
using Google.Protobuf;
using Google.Protobuf.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Google.Api.Generator.Utils.Roslyn.Modifier;
using static Google.Api.Generator.Utils.Roslyn.RoslynBuilder;
using static Google.Cloud.Tools.SnippetGen.SnippetIndex.V1.Snippet.Types.Segment.Types;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using ApiMetadata = Google.Cloud.Tools.SnippetGen.SnippetIndex.V1.Api;
using ServiceMetadata = Google.Cloud.Tools.SnippetGen.SnippetIndex.V1.Service;
using SnippetIndex = Google.Cloud.Tools.SnippetGen.SnippetIndex.V1.Index;
using SnippetMetadata = Google.Cloud.Tools.SnippetGen.SnippetIndex.V1.Snippet;

namespace Google.Api.Generator.Generation
{
    internal class SnippetCodeGenerator
    {
        public static string GenerateSnippetIndexJson(IEnumerable<SnippetMetadata> snippets, ServiceDetails serviceDetails) =>
            new SnippetIndex
            {
                ClientLibrary = new ClientLibrary
                {
                    Name = serviceDetails.Namespace,
                    Language = Language.CSharp,
                    Apis = { new ApiMetadata
                    {
                        Id = serviceDetails.ProtoPackage,
                        Version = serviceDetails.PackageVersion ?? ""
                    }}
                },
                Snippets = { snippets.OrderBy(snippet => snippet.ClientMethod.Method.Service.ShortName, StringComparer.Ordinal) }
            }.ToFormattedJson();

        public static CompilationUnitSyntax Generate(SourceFileContext ctx, ServiceDetails svc)
        {
            var ns = Namespace(svc.SnippetsNamespace);
            using (ctx.InNamespace(ns))
            {
                var cls = Class(Public | Sealed, svc.ServiceSnippetsTyp)
                    .MaybeWithAttribute(svc.IsDeprecated, () => ctx.Type<ObsoleteAttribute>())()
                    .WithXmlDoc(XmlDoc.Summary("Generated snippets."));
                using (ctx.InClass(cls))
                {
                    cls = cls.AddMembers(Snippets(ctx, svc).Select(snippetDef => snippetDef.GenerateMethod(ctx)).ToArray());
                }
                ns = ns.AddMembers(cls);
            }
            return ctx.CreateCompilationUnit(ns);
        }

        public static IEnumerable<SnippetCodeGenerator> SnippetsGenerators(ServiceDetails svc) =>
            Snippets(null, svc).Select(snippetDef => new SnippetCodeGenerator(snippetDef));

        private static IEnumerable<SnippetDef> Snippets(SourceFileContext ctx, ServiceDetails svc)
        {
            foreach (var method in svc.Methods)
            {
                var methodDef = new MethodDef(ctx, svc, method);
                switch (method)
                {
                    case MethodDetails.Normal _:
                        yield return methodDef.SyncRequestSnippet;
                        yield return methodDef.AsyncRequestSnippet;
                        foreach (var signature in methodDef.Signatures)
                        {
                            yield return signature.SyncSnippet;
                            yield return signature.AsyncSnippet;
                            foreach (var resourceName in signature.ResourceNames)
                            {
                                yield return resourceName.SyncSnippet;
                                yield return resourceName.AsyncSnippet;
                            }
                        }
                        break;
                    case MethodDetails.Lro _:
                        yield return methodDef.SyncLroRequestSnippet;
                        yield return methodDef.AsyncLroRequestSnippet;
                        foreach (var signature in methodDef.Signatures)
                        {
                            yield return signature.SyncLroSnippet;
                            yield return signature.AsyncLroSnippet;
                            foreach (var resourceName in signature.ResourceNames)
                            {
                                yield return resourceName.SyncLroSnippet;
                                yield return resourceName.AsyncLroSnippet;
                            }
                        }
                        break;
                    case MethodDetails.Paginated _:
                        yield return methodDef.SyncPaginatedRequestSnippet;
                        yield return methodDef.AsyncPaginatedRequestSnippet;
                        foreach (var signature in methodDef.Signatures)
                        {
                            yield return signature.SyncPaginatedSnippet;
                            yield return signature.AsyncPaginatedSnippet;
                            foreach (var resourceName in signature.ResourceNames)
                            {
                                yield return resourceName.SyncPaginatedSnippet;
                                yield return resourceName.AsyncPaginatedSnippet;
                            }
                        }
                        break;
                    case MethodDetails.ServerStreaming _:
                        yield return methodDef.ServerStreamingRequestSnippet;
                        foreach (var signature in methodDef.Signatures)
                        {
                            yield return signature.ServerStreamingSnippet;
                            foreach (var resourceName in signature.ResourceNames)
                            {
                                yield return resourceName.ServerStreamingSnippet;
                            }
                        }
                        break;
                    case MethodDetails.BidiStreaming _:
                        yield return methodDef.BidiStreamingSnippet;
                        break;
                }
            }
        }

        private SnippetCodeGenerator(SnippetDef snippetDef) =>
            Snippet = snippetDef;

        private SnippetDef Snippet { get; }
        public string SnippetMethodName => Snippet.SnippetMethodName;

        public (string, SnippetMetadata) Generate(SourceFileContext ctx)
        {
            var (snippetCode, snippetMetadata) = Snippet.FullSnippet(ctx);
            // We now need to format the code to make sure that we extract segment line numbers correctly.
            var formattedCode = CodeFormatter.Format(ctx.CreateCompilationUnit(snippetCode));

            SnippetSegmentFinder.UpdateMetadataWithSegmentInfo(formattedCode, snippetMetadata);

            // Let's return the string so that the code is not formatted or otherwise changed further.
            return (formattedCode.ToFullString(), snippetMetadata);
        }

        private class SnippetDef
        {
            private static readonly string[] GeneratedNotice = new string[]
            {
                "This snippet has been automatically generated and should be regarded as a code template only.",
                "It will require modifications to work:",
                "- It may require correct/in-range values for request initialization.",
                "- It may require specifying regional endpoints when creating the service client as shown in",
                "  https://cloud.google.com/dotnet/docs/reference/help/client-configuration#endpoint."
            };

            private MethodDetails TargetMethod { get; }
            private bool Sync { get; }
            public string SnippetMethodName { get; }
            private string TargetMethodName => Sync ? TargetMethod.SyncMethodName : TargetMethod.AsyncMethodName;
            private string RegionTagDisambiguation { get; }
            // TODO: Reconsider this ugly hack when refactoring after removing the service-per-file snippets.
            private bool Canonical => RegionTagDisambiguation is null;
            private IEnumerable<ClientMethod.Types.Parameter> ClientMethodParameters { get; }
            private Func<SourceFileContext, bool, MethodDeclarationSyntax> MethodGenerator { get; }

            public SnippetDef(
                MethodDetails targetMethod, bool sync, string snippetMethodName, IEnumerable<ClientMethod.Types.Parameter> clientMethodParameters,
                string regionTagDisambiguation, Func<SourceFileContext, bool, MethodDeclarationSyntax> methodGenerator) =>
                (TargetMethod, Sync, SnippetMethodName, ClientMethodParameters, RegionTagDisambiguation, MethodGenerator) =
                (targetMethod, sync, snippetMethodName, clientMethodParameters, regionTagDisambiguation, methodGenerator);

            public MethodDeclarationSyntax GenerateMethod(SourceFileContext ctx) =>
                // Include doc markers.
                MethodGenerator(ctx, true)
                    .WithXmlDoc(XmlDoc.Summary($"Snippet for {TargetMethodName}"));

            private SnippetMetadata GenerateMetadata() =>
                new SnippetMetadata
                {
                    Title = SnippetMethodName,
                    Description = $"Snippet for {TargetMethodName}",
                    Language = Language.CSharp,
                    Canonical = Canonical,
                    Origin = SnippetMetadata.Types.Origin.ApiDefinition,
                    ClientMethod = new ClientMethod
                    {
                        ShortName = TargetMethodName,
                        FullName = $"{TargetMethod.Svc.ClientAbstractTyp.FullName}.{TargetMethodName}",
                        Async = !Sync,
                        Parameters = { ClientMethodParameters },
                        ResultType = Sync
                            ? TargetMethod.SyncReturnTyp is Typ.VoidTyp ? "" : TargetMethod.SyncReturnTyp.FullName
                            : TargetMethod.AsyncReturnTyp.FullName,
                        Client = new ServiceClient
                        {
                            ShortName = TargetMethod.Svc.ClientAbstractTyp.Name,
                            FullName = TargetMethod.Svc.ClientAbstractTyp.FullName
                        },
                        Method = new Method
                        {
                            ShortName = TargetMethod.ProtoRpcName,
                            FullName = $"{TargetMethod.Svc.ServiceFullName}.{TargetMethod.ProtoRpcName}",
                            Service = new ServiceMetadata
                            {
                                ShortName = TargetMethod.Svc.OriginalServiceName,
                                FullName = TargetMethod.Svc.ServiceFullName
                            }
                        }
                    }
                };

            public (NamespaceDeclarationSyntax, SnippetMetadata) FullSnippet(SourceFileContext ctx)
            {
                var ns = Namespace(TargetMethod.Svc.SnippetsNamespace);
                using (ctx.InNamespace(ns))
                {
                    // We can't apply the Obsolete attribute multiple times on a class, so instead
                    // we apply it to each snippet.
                    var cls = Class(Public | Sealed | Partial, TargetMethod.Svc.SnippetsTyp);
                    using (ctx.InClass(cls))
                    {
                        cls = cls.AddMembers(
                            // Do not include doc markers. Full snippets use region tags and metadata.
                            MethodGenerator(ctx, false)
                                .MaybeWithAttribute(TargetMethod.Svc.IsDeprecated, () => ctx.Type<ObsoleteAttribute>())()
                                .WithXmlDoc(
                                    XmlDoc.Summary($"Snippet for {TargetMethodName}"),
                                    XmlDoc.RemarksPreFormatted(GeneratedNotice)));
                    }
                    ns = ns.AddMembers(cls);
                }
                SnippetMetadata metadata = GenerateMetadata();
                return (WithRegionTag(ns, metadata), metadata);
            }

            private NamespaceDeclarationSyntax WithRegionTag(NamespaceDeclarationSyntax ns, SnippetMetadata metadata)
            {
                string effectiveShortName = TargetMethod.Svc.DefaultHostServiceName ?? "unknown";
                string effectiveVersion = TargetMethod.Svc.PackageVersion is null ? "" : $"_{TargetMethod.Svc.PackageVersion}";
                string syncText = Sync ? "sync" : "async";
                string effectiveDisambiguation = RegionTagDisambiguation is null ? "" : $"_{RegionTagDisambiguation}";

                string regionTagName =
                    // {apishortname}_{apiVersion}_generated_{serviceName}_{rpcName}_{sync|async}_{disambiguation}
                    $"{effectiveShortName}{effectiveVersion}_generated_{TargetMethod.Svc.OriginalServiceName}_{TargetMethod.ProtoRpcName}_{syncText}{effectiveDisambiguation}";

                metadata.RegionTag = regionTagName;

                // We define these consts here instead of using the literals directly so that snippet-bot-checker
                // doesn't recognize the interpolated string as a malformed region tag.
                const string start = "START";
                const string end = "END";

                return ns
                    .WithOpenBraceToken(ns.OpenBraceToken.WithTrailingTrivia(Comment($"// [{start} {regionTagName}]")
                        .WithAdditionalAnnotations(SnippetSegmentFinder.FullSegmentStart)))
                    .WithCloseBraceToken(ns.CloseBraceToken.WithLeadingTrivia(Comment($"// [{end} {regionTagName}]")
                        .WithAdditionalAnnotations(SnippetSegmentFinder.FullSegmentEnd)));
            }
        }

        private class MethodDef
        {
            public MethodDef(SourceFileContext ctx, ServiceDetails svc, MethodDetails method, bool includeDocMarkers = true) =>
                (Ctx, Svc, Method, IncludeDocMarkers) = (ctx, svc, method, includeDocMarkers);

            public MethodDef WithSourceFileContext(SourceFileContext ctx) =>
                ctx == Ctx ? this : new MethodDef(ctx, Svc, Method, IncludeDocMarkers);

            public MethodDef WithIncludeDocMarkers(bool includeDocMarkers) =>
                includeDocMarkers == IncludeDocMarkers ? this : new MethodDef(Ctx, Svc, Method, includeDocMarkers);

            private SourceFileContext Ctx { get; }
            private ServiceDetails Svc { get; }
            private MethodDetails Method { get; }
            private MethodDetails.Lro MethodLro => (MethodDetails.Lro) Method;
            private MethodDetails.Paginated MethodPaginated => (MethodDetails.Paginated) Method;
            private MethodDetails.IStreaming MethodStreaming => (MethodDetails.IStreaming) Method;
            private bool IncludeDocMarkers { get; }

            // Common properties for "Call the client method, suppressing obsolete warnings if necessary".
            private ArgumentsFunc<InvocationExpressionSyntax> SyncClientMethodCall => Client.MaybeObsoleteCall(Method.SyncMethodName, Method.IsDeprecated);
            private ArgumentsFunc<InvocationExpressionSyntax> AsyncClientMethodCall => Client.MaybeObsoleteCall(Method.AsyncMethodName, Method.IsDeprecated);

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

            private static ClientMethod.Types.Parameter ParameterFromType<T>(string name) => new ClientMethod.Types.Parameter
            {
                Name = name,
                Type = typeof(T).FullName
            };

            private static ClientMethod.Types.Parameter ParameterFromNullableType<T>(string name) => new ClientMethod.Types.Parameter
            {
                Name = name,
                Type = $"{typeof(Nullable).FullName}[{typeof(T).FullName}]"
            };

            private static ClientMethod.Types.Parameter ParameterFromTyp(Typ typ, string name) => new ClientMethod.Types.Parameter
            {
                Name = name,
                Type = typ.FullName
            };

            private static ClientMethod.Types.Parameter CallSettingsParameter { get; } = ParameterFromType<CallSettings>("callSettings");

            private static IEnumerable<ClientMethod.Types.Parameter> BidiStreamingClientMethodParameters
            {
                get
                {
                    yield return CallSettingsParameter;
                    yield return ParameterFromType<BidirectionalStreamingSettings>("streamingSettings");
                }
            }

            private IEnumerable<ClientMethod.Types.Parameter> RequestClientMethodParameters
            {
                get
                {
                    yield return ParameterFromTyp(Method.RequestTyp, "request");
                    yield return CallSettingsParameter;
                }
            }

            private object DefaultValue(FieldDescriptor fieldDesc, HashSet<MessageDescriptor> seenMessages, Typ resourceTyp = null, bool topLevel = false)
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
                            (object) New(Ctx.Type<UnparsedResourceName>())("a/wildcard/resource") :
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
                        var keyValue = DefaultValue(parts[0], seenMessages);
                        var valueValue = DefaultValue(parts[1], seenMessages);
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
                            _ => New(Ctx.Type(ProtoTyp.Of(fieldDesc.MessageType)))().WithInitializer(InitMessage(fieldDesc.MessageType).ToArray())
                        },
                        FieldType.Enum => Ctx.Type(ProtoTyp.Of(fieldDesc.EnumType)).Access(fieldDesc.EnumType.Values.First().CSharpName()),
                        _ => throw new InvalidOperationException($"Cannot generate default for proto type: {fieldDesc.FieldType}"),
                    };
                    return fieldDesc.IsRepeated ? Collection(@default, null) : @default;
                }

                object Collection(object value, Typ typ) => topLevel ?
                    NewArray(Ctx.ArrayType(Typ.ArrayOf(typ ?? ProtoTyp.Of(fieldDesc).GenericArgTyps.First())))(value) :
                    (object) CollectionInitializer(value);

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

                IEnumerable<ObjectInitExpr> InitMessage(MessageDescriptor descriptor)
                {
                    if (!seenMessages.Contains(descriptor))
                    {
                        var seenMessagesAndMe = new HashSet<MessageDescriptor>(seenMessages.Append(descriptor));

                        foreach (var fieldDesc in descriptor.Fields.InFieldNumberOrder().Where(x => ShouldIncludeField(x, false)))
                        {
                            var resourceField = Svc.Catalog.GetResourceDetailsByField(fieldDesc)?[0];
                            yield return new ObjectInitExpr(resourceField?.ResourcePropertyName ?? fieldDesc.CSharpPropertyName(),
                                DefaultValue(fieldDesc, seenMessagesAndMe, resourceField?.ResourceDefinition.ResourceNameTyp));
                        }
                    }
                }
            }

            private IEnumerable<ObjectInitExpr> InitRequest()
            {
                var seenMessages = new HashSet<MessageDescriptor>
                {
                    Method.RequestMessageDesc
                };
                foreach (var fieldDesc in Method.RequestMessageDesc.Fields.InFieldNumberOrder().Where(x => ShouldIncludeField(x, true)))
                {
                    var resourceField = Svc.Catalog.GetResourceDetailsByField(fieldDesc)?[0];
                    yield return new ObjectInitExpr(resourceField?.ResourcePropertyName ?? fieldDesc.CSharpPropertyName(),
                        DefaultValue(fieldDesc, seenMessages, resourceField?.ResourceDefinition.ResourceNameTyp));
                }
            }
            // fieldDesc.RealContainingOneof != null &&
            // fieldDesc.Index != fieldDesc.RealContainingOneof.Fields[0].Index;
            
            private bool ShouldIncludeField(FieldDescriptor x, bool isRequestField)
            {
                return !IsAutopopulated() && !IsDeprecated() && !IsPaginationField() && (isRequestField || IsRequired() || IsFirstOneOf());

                bool IsAutopopulated() => Method.ServiceConfigMethodSettings.AutoPopulatedFields.Contains(x.Name);
                bool IsDeprecated() => x.IsDeprecated();
                bool IsPaginationField() => Method is MethodDetails.Paginated paged &&
                        (x.FieldNumber == paged.PageSizeFieldNumber || x.FieldNumber == paged.PageTokenFieldNumber);
                bool IsRequired() => x.IsRequired || x.GetExtension(FieldBehaviorExtensions.FieldBehavior)?.Contains(FieldBehavior.Required) == true;
                bool IsFirstOneOf() => x.RealContainingOneof is not null && x.Index == x.RealContainingOneof.Fields[0].Index;
            }


            private string SnippetTypes(IEnumerable<Typ> typs) => string.Join("", typs.Select(t => $"{Ctx.Type(t)}, "));

            private MethodDeclarationSyntax Sync(string methodName, IEnumerable<Typ> snippetTyps, object initRequest, object makeRequest) =>
                Method(Public, VoidType, methodName)()
                    .WithShortSnippetBody(
                        IncludeDocMarkers ? $"// Snippet: {Method.SyncMethodName}({SnippetTypes(snippetTyps)}{nameof(CallSettings)})" : null,
                        "// Create client",
                        Client.WithInitializer(Ctx.Type(Svc.ClientAbstractTyp).Call("Create")()),
                        snippetTyps.Any() ? "// Initialize request argument(s)" : null,
                        initRequest,
                        "// Make the request",
                        makeRequest,
                        IncludeDocMarkers ? "// End snippet" : null);

            private MethodDeclarationSyntax Async(string methodName, IEnumerable<Typ> snippetTyps, object initRequest, object makeRequest) =>
                Method(Public | Modifier.Async, Ctx.Type<Task>(), methodName)()
                    .WithShortSnippetBody(
                        IncludeDocMarkers ? $"// Snippet: {Method.AsyncMethodName}({SnippetTypes(snippetTyps)}{nameof(CallSettings)})" : null,
                        IncludeDocMarkers ? $"// Additional: {Method.AsyncMethodName}({SnippetTypes(snippetTyps)}{nameof(CancellationToken)})" : null,
                        "// Create client",
                        Client.WithInitializer(Await(Ctx.Type(Svc.ClientAbstractTyp).Call("CreateAsync")())),
                        snippetTyps.Any() ? "// Initialize request argument(s)" : null,
                        initRequest,
                        "// Make the request",
                        makeRequest,
                        IncludeDocMarkers ? "// End snippet" : null);

            private MethodDeclarationSyntax SyncLro(string methodName, IEnumerable<Typ> snippetTyps, object initRequest, object makeRequest) =>
                Method(Public, VoidType, methodName)()
                    .WithShortSnippetBody(
                        IncludeDocMarkers ? $"// Snippet: {Method.SyncMethodName}({SnippetTypes(snippetTyps)}{nameof(CallSettings)})" : null,
                        "// Create client",
                        Client.WithInitializer(Ctx.Type(Svc.ClientAbstractTyp).Call("Create")()),
                        snippetTyps.Any() ? "// Initialize request argument(s)" : null,
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
                        LroRetrievedResponse.WithInitializer(Client.MaybeObsoleteCall(MethodLro.SyncPollMethodName, Method.IsDeprecated)(LroOperationName)),
                        "// Check if the retrieved long-running operation has completed",
                        If(LroRetrievedResponse.Access(nameof(Operation<ProtoMsg, ProtoMsg>.IsCompleted)))
                            .Then(
                                "// If it has completed, then access the result",
                                LroRetrievedResult.WithInitializer(LroRetrievedResponse.Access(nameof(Operation<ProtoMsg, ProtoMsg>.Result)))),
                        IncludeDocMarkers ? "// End snippet" : null);

            private MethodDeclarationSyntax AsyncLro(string methodName, IEnumerable<Typ> snippetTyps, object initRequest, object makeRequest) =>
                Method(Public | Modifier.Async, Ctx.Type<Task>(), methodName)()
                    .WithShortSnippetBody(
                        IncludeDocMarkers ? $"// Snippet: {Method.AsyncMethodName}({SnippetTypes(snippetTyps)}{nameof(CallSettings)})" : null,
                        IncludeDocMarkers ? $"// Additional: {Method.AsyncMethodName}({SnippetTypes(snippetTyps)}{nameof(CancellationToken)})" : null,
                        "// Create client",
                        Client.WithInitializer(Await(Ctx.Type(Svc.ClientAbstractTyp).Call("CreateAsync")())),
                        snippetTyps.Any() ? "// Initialize request argument(s)" : null,
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
                        LroRetrievedResponse.WithInitializer(Await(Client.MaybeObsoleteCall(MethodLro.AsyncPollMethodName, Method.IsDeprecated)(LroOperationName))),
                        "// Check if the retrieved long-running operation has completed",
                        If(LroRetrievedResponse.Access(nameof(Operation<ProtoMsg, ProtoMsg>.IsCompleted)))
                            .Then(
                                "// If it has completed, then access the result",
                                LroRetrievedResult.WithInitializer(LroRetrievedResponse.Access(nameof(Operation<ProtoMsg, ProtoMsg>.Result)))),
                        IncludeDocMarkers ? "// End snippet" : null);

            private string PaginatedSnippetTypes(bool isSig) => isSig ? "string, int?, " : "";

            private MethodDeclarationSyntax SyncPaginated(string methodName, IEnumerable<Typ> snippetTyps, object initRequest, object makeRequest, bool isSig) =>
                Method(Public, VoidType, methodName)()
                    .WithShortSnippetBody(
                        IncludeDocMarkers ? $"// Snippet: {Method.SyncMethodName}({SnippetTypes(snippetTyps)}{PaginatedSnippetTypes(isSig)}{nameof(CallSettings)})" : null,
                        "// Create client",
                        Client.WithInitializer(Ctx.Type(Svc.ClientAbstractTyp).Call("Create")()),
                        snippetTyps.Any() ? "// Initialize request argument(s)" : null,
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
                        IncludeDocMarkers ? "// End snippet" : null);

            private MethodDeclarationSyntax AsyncPaginated(string methodName, IEnumerable<Typ> snippetTyps, object initRequest, object makeRequest, bool isSig) =>
                Method(Public | Modifier.Async, Ctx.Type<Task>(), methodName)()
                    .WithShortSnippetBody(
                        IncludeDocMarkers ? $"// Snippet: {Method.AsyncMethodName}({SnippetTypes(snippetTyps)}{PaginatedSnippetTypes(isSig)}{nameof(CallSettings)})" : null,
                        "// Create client",
                        Client.WithInitializer(Await(Ctx.Type(Svc.ClientAbstractTyp).Call("CreateAsync")())),
                        snippetTyps.Any() ? "// Initialize request argument(s)" : null,
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
                        IncludeDocMarkers ? "// End snippet" : null);

            private MethodDeclarationSyntax ServerStreaming(string methodName, IEnumerable<Typ> snippetTyps, object initRequest, LocalDeclarationStatementSyntax makeRequest) =>
                Method(Public | Modifier.Async, Ctx.Type<Task>(), methodName)()
                    .WithShortSnippetBody(
                        IncludeDocMarkers ? $"// Snippet: {Method.SyncMethodName}({SnippetTypes(snippetTyps)}{nameof(CallSettings)})" : null,
                        "// Create client",
                        Client.WithInitializer(Ctx.Type(Svc.ClientAbstractTyp).Call("Create")()),
                        snippetTyps.Any() ? "// Initialize request argument(s)" : null,
                        initRequest,
                        "// Make the request, returning a streaming response",
                        makeRequest.WithUsingKeyword(Token(SyntaxKind.UsingKeyword).WithTrailingSpace()),
                        BlankLine,
                        "// Read streaming responses from server until complete",
                        "// Note that C# 8 code can use await foreach",
                        ResponseStream.WithInitializer(Response.Call(nameof(ServerStreamingBase<int>.GetResponseStream))()),
                        While(Await(ResponseStream.Call(nameof(IAsyncEnumerator<int>.MoveNextAsync))()))(
                            ResponseItem.WithInitializer(ResponseStream.Access(nameof(IAsyncEnumerator<int>.Current))),
                            "// Do something with streamed response"),
                        "// The response stream has completed",
                        IncludeDocMarkers ? "// End snippet" : null);

            private object InitRequestObject => Request.WithInitializer(New(Ctx.Type(Method.RequestTyp))().WithInitializer(InitRequest().ToArray()));

            private MethodDeclarationSyntax SyncRequestMethod => Sync(Method.SyncSnippetMethodName, new[] { Method.RequestTyp },
                InitRequestObject, Method.SyncReturnTyp is Typ.VoidTyp ?
                    (object) SyncClientMethodCall(Request) :
                    Response.WithInitializer(SyncClientMethodCall(Request)));

            public SnippetDef SyncRequestSnippet => new SnippetDef(Method, true, Method.SyncSnippetMethodName, RequestClientMethodParameters, null,
                (ctx, includeDocMarkers) => WithSourceFileContext(ctx).WithIncludeDocMarkers(includeDocMarkers).SyncRequestMethod);

            private MethodDeclarationSyntax AsyncRequestMethod => Async(Method.AsyncSnippetMethodName, new[] { Method.RequestTyp },
                InitRequestObject, Method.SyncReturnTyp is Typ.VoidTyp ?
                    (object) Await(AsyncClientMethodCall(Request)) :
                    Response.WithInitializer(Await(AsyncClientMethodCall(Request))));

            public SnippetDef AsyncRequestSnippet => new SnippetDef(Method, false, Method.AsyncSnippetMethodName, RequestClientMethodParameters, null,
                (ctx, includeDocMarkers) => WithSourceFileContext(ctx).WithIncludeDocMarkers(includeDocMarkers).AsyncRequestMethod);

            private MethodDeclarationSyntax SyncLroRequestMethod => SyncLro(Method.SyncSnippetMethodName, new[] { Method.RequestTyp },
                InitRequestObject, Response.WithInitializer(SyncClientMethodCall(Request)));

            public SnippetDef SyncLroRequestSnippet => new SnippetDef(Method, true, Method.SyncSnippetMethodName, RequestClientMethodParameters, null,
                (ctx, includeDocMarkers) => WithSourceFileContext(ctx).WithIncludeDocMarkers(includeDocMarkers).SyncLroRequestMethod);

            private MethodDeclarationSyntax AsyncLroRequestMethod => AsyncLro(Method.AsyncSnippetMethodName, new[] { Method.RequestTyp },
                InitRequestObject, Response.WithInitializer(Await(AsyncClientMethodCall(Request))));

            public SnippetDef AsyncLroRequestSnippet => new SnippetDef(Method, false, Method.AsyncSnippetMethodName, RequestClientMethodParameters, null,
                (ctx, includeDocMarkers) => WithSourceFileContext(ctx).WithIncludeDocMarkers(includeDocMarkers).AsyncLroRequestMethod);

            private MethodDeclarationSyntax SyncPaginatedRequestMethod => SyncPaginated(Method.SyncSnippetMethodName, new[] { Method.RequestTyp },
                InitRequestObject, Response.WithInitializer(SyncClientMethodCall(Request)), isSig: false);

            public SnippetDef SyncPaginatedRequestSnippet => new SnippetDef(Method, true, Method.SyncSnippetMethodName, RequestClientMethodParameters, null,
                (ctx, includeDocMarkers) => WithSourceFileContext(ctx).WithIncludeDocMarkers(includeDocMarkers).SyncPaginatedRequestMethod);

            private MethodDeclarationSyntax AsyncPaginatedRequestMethod => AsyncPaginated(Method.AsyncSnippetMethodName, new[] { Method.RequestTyp },
                InitRequestObject, AsyncResponse.WithInitializer(AsyncClientMethodCall(Request)), isSig: false);

            public SnippetDef AsyncPaginatedRequestSnippet => new SnippetDef(Method, false, Method.AsyncSnippetMethodName, RequestClientMethodParameters, null,
                (ctx, includeDocMarkers) => WithSourceFileContext(ctx).WithIncludeDocMarkers(includeDocMarkers).AsyncPaginatedRequestMethod);

            private MethodDeclarationSyntax ServerStreamingRequestMethod => ServerStreaming(Method.SyncSnippetMethodName, new[] { Method.RequestTyp },
                InitRequestObject, Response.WithInitializer(SyncClientMethodCall(Request)));

            public SnippetDef ServerStreamingRequestSnippet => new SnippetDef(Method, true, Method.SyncSnippetMethodName, RequestClientMethodParameters, null,
                (ctx, includeDocMarkers) => WithSourceFileContext(ctx).WithIncludeDocMarkers(includeDocMarkers).ServerStreamingRequestMethod);

            private MethodDeclarationSyntax BidiStreamingMethod =>
                Method(Public | Modifier.Async, Ctx.Type<Task>(), Method.SyncMethodName)()
                    .WithShortSnippetBody(
                        IncludeDocMarkers ? $"// Snippet: {Method.SyncMethodName}({nameof(CallSettings)}, {nameof(BidirectionalStreamingSettings)})" : null,
                        "// Create client",
                        Client.WithInitializer(Ctx.Type(Svc.ClientAbstractTyp).Call("Create")()),
                        "// Initialize streaming call, retrieving the stream object",
                        Response.WithInitializer(SyncClientMethodCall()).WithUsingKeyword(Token(SyntaxKind.UsingKeyword).WithTrailingSpace()),
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
                        IncludeDocMarkers ? "// End snippet" : null);

            public SnippetDef BidiStreamingSnippet => new SnippetDef(Method, true, Method.SyncMethodName, BidiStreamingClientMethodParameters, null,
                (ctx, includeDocMarkers) => WithSourceFileContext(ctx).WithIncludeDocMarkers(includeDocMarkers).BidiStreamingMethod);

            public class Signature
            {
                public Signature(MethodDef def, MethodDetails.Signature sig, int? index) => (_def, _sig, _index) = (def, sig, index);

                public Signature WithSourceFileContext(SourceFileContext ctx) =>
                    ctx == Ctx ? this : new Signature(_def.WithSourceFileContext(ctx), _sig, _index);

                public Signature WithIncludeDocMarkers(bool includeDocMarkers) =>
                    includeDocMarkers == IncludeDocMarkers ? this : new Signature(_def.WithIncludeDocMarkers(includeDocMarkers), _sig, _index);

                private readonly MethodDef _def;
                private readonly MethodDetails.Signature _sig;
                private readonly int? _index;
                private SourceFileContext Ctx => _def.Ctx;
                private MethodDetails Method => _def.Method;
                private ServiceDetails Svc => _def.Svc;
                private bool IncludeDocMarkers => _def.IncludeDocMarkers;

                private string OverloadDisambiguation => _index is int index ? (index + 1).ToString() : "";
                private string RegionTagOverloadDisambiguation => $"flattened{OverloadDisambiguation}";


                private string SyncMethodName => Method.SyncMethodName + OverloadDisambiguation;
                private string AsyncMethodName => $"{Method.AsyncMethodName.Substring(0, Method.AsyncMethodName.Length - 5)}{OverloadDisambiguation}Async";

                private static ClientMethod.Types.Parameter ParameterFromField(MethodDetails.Signature.Field field) => ParameterFromTyp(field.Typ, field.ParameterName);

                private IEnumerable<ClientMethod.Types.Parameter> CoreClientMethodParameters => _sig.Fields.Select(ParameterFromField);

                private static IEnumerable<ClientMethod.Types.Parameter> WithCallSettings(IEnumerable<ClientMethod.Types.Parameter> parameters) =>
                    parameters.Append(CallSettingsParameter);

                private IEnumerable<ClientMethod.Types.Parameter> NormalClientMethodParameters => WithCallSettings(CoreClientMethodParameters);

                private static IEnumerable<ClientMethod.Types.Parameter> WithPaginationParameters(IEnumerable<ClientMethod.Types.Parameter> parameters) => parameters
                    .Append(ParameterFromType<string>("pageToken"))
                    .Append(ParameterFromNullableType<int>("pageSize"));

                private IEnumerable<ClientMethod.Types.Parameter> PaginatedClientMethodParameters => WithCallSettings(WithPaginationParameters(CoreClientMethodParameters));

                private ArgumentsFunc<InvocationExpressionSyntax> SyncClientMethodCall => _def.Client.MaybeObsoleteCall(Method.SyncMethodName, Method.IsDeprecated || _sig.HasDeprecatedField);
                private ArgumentsFunc<InvocationExpressionSyntax> AsyncClientMethodCall => _def.Client.MaybeObsoleteCall(Method.AsyncMethodName, Method.IsDeprecated || _sig.HasDeprecatedField);

                private Typ MaybeEnumerable(bool repeated, Typ typ) => !repeated || typ == null ? typ : Typ.Generic(typeof(IEnumerable<>), typ);
                private IEnumerable<LocalDeclarationStatementSyntax> InitRequestArgs(bool resourceNameAsString) =>
                    _sig.Fields.Select(f =>
                        Local(Ctx.Type(resourceNameAsString ? f.Typ : MaybeEnumerable(f.IsRepeated, f.FieldResources?[0].ResourceDefinition.ResourceNameTyp) ?? f.Typ),
                            f.Descs.Last().CSharpFieldName())
                        .WithInitializer(_def.DefaultValue(f.Descs.Last(), new HashSet<MessageDescriptor>(), null, topLevel: true)));
                private IEnumerable<LocalDeclarationStatementSyntax> InitRequestArgsNormal => InitRequestArgs(resourceNameAsString: true);

                private MethodDeclarationSyntax SyncMethod => _def.Sync(SyncMethodName, _sig.Fields.Select(f => f.Typ),
                    InitRequestArgsNormal, Method.SyncReturnTyp is Typ.VoidTyp ?
                        (object) SyncClientMethodCall(InitRequestArgsNormal.ToArray()) :
                        _def.Response.WithInitializer(SyncClientMethodCall(InitRequestArgsNormal.ToArray())));

                public SnippetDef SyncSnippet => new SnippetDef(Method, true, SyncMethodName, NormalClientMethodParameters, RegionTagOverloadDisambiguation,
                    (ctx, includeDocMarkers) => WithSourceFileContext(ctx).WithIncludeDocMarkers(includeDocMarkers).SyncMethod);

                private MethodDeclarationSyntax AsyncMethod => _def.Async(AsyncMethodName, _sig.Fields.Select(f => f.Typ),
                    InitRequestArgsNormal, Method.SyncReturnTyp is Typ.VoidTyp ?
                        (object) Await(AsyncClientMethodCall(InitRequestArgsNormal.ToArray())) :
                        _def.Response.WithInitializer(Await(AsyncClientMethodCall(InitRequestArgsNormal.ToArray()))));

                public SnippetDef AsyncSnippet => new SnippetDef(Method, false, AsyncMethodName, NormalClientMethodParameters, RegionTagOverloadDisambiguation,
                    (ctx, includeDocMarkers) => WithSourceFileContext(ctx).WithIncludeDocMarkers(includeDocMarkers).AsyncMethod);

                private MethodDeclarationSyntax SyncLroMethod => _def.SyncLro(SyncMethodName, _sig.Fields.Select(f => f.Typ),
                    InitRequestArgsNormal, _def.Response.WithInitializer(SyncClientMethodCall(InitRequestArgsNormal.ToArray())));

                public SnippetDef SyncLroSnippet => new SnippetDef(Method, true, SyncMethodName, NormalClientMethodParameters, RegionTagOverloadDisambiguation,
                    (ctx, includeDocMarkers) => WithSourceFileContext(ctx).WithIncludeDocMarkers(includeDocMarkers).SyncLroMethod);

                private MethodDeclarationSyntax AsyncLroMethod => _def.AsyncLro(AsyncMethodName, _sig.Fields.Select(f => f.Typ),
                    InitRequestArgsNormal, _def.Response.WithInitializer(Await(AsyncClientMethodCall(InitRequestArgsNormal.ToArray()))));

                public SnippetDef AsyncLroSnippet => new SnippetDef(Method, false, AsyncMethodName, NormalClientMethodParameters, RegionTagOverloadDisambiguation,
                    (ctx, includeDocMarkers) => WithSourceFileContext(ctx).WithIncludeDocMarkers(includeDocMarkers).AsyncLroMethod);

                private IEnumerable<object> PaginatedArgs(IEnumerable<LocalDeclarationStatementSyntax> args)
                {
                    if (_def.RequireFinalNamedArg(_sig))
                    {
                        var argN = args.Last();
                        return args.Cast<object>().SkipLast(1).Append((argN.Declaration.Variables[0].Identifier.Text, argN));
                    }
                    return args;
                }

                private MethodDeclarationSyntax SyncPaginatedMethod => _def.SyncPaginated(SyncMethodName, _sig.Fields.Select(f => f.Typ),
                    InitRequestArgsNormal, _def.Response.WithInitializer(SyncClientMethodCall(PaginatedArgs(InitRequestArgsNormal).ToArray())), isSig: true);

                public SnippetDef SyncPaginatedSnippet => new SnippetDef(Method, true, SyncMethodName, PaginatedClientMethodParameters, RegionTagOverloadDisambiguation,
                    (ctx, includeDocMarkers) => WithSourceFileContext(ctx).WithIncludeDocMarkers(includeDocMarkers).SyncPaginatedMethod);

                private MethodDeclarationSyntax AsyncPaginatedMethod => _def.AsyncPaginated(AsyncMethodName, _sig.Fields.Select(f => f.Typ),
                    InitRequestArgsNormal, _def.AsyncResponse.WithInitializer(AsyncClientMethodCall(PaginatedArgs(InitRequestArgsNormal).ToArray())), isSig: true);

                public SnippetDef AsyncPaginatedSnippet => new SnippetDef(Method, false, AsyncMethodName, PaginatedClientMethodParameters, RegionTagOverloadDisambiguation,
                    (ctx, includeDocMarkers) => WithSourceFileContext(ctx).WithIncludeDocMarkers(includeDocMarkers).AsyncPaginatedMethod);

                private MethodDeclarationSyntax ServerStreamingMethod => _def.ServerStreaming(SyncMethodName, _sig.Fields.Select(f => f.Typ),
                    InitRequestArgsNormal, _def.Response.WithInitializer(SyncClientMethodCall(InitRequestArgsNormal.ToArray())));

                public SnippetDef ServerStreamingSnippet => new SnippetDef(Method, true, SyncMethodName, NormalClientMethodParameters, RegionTagOverloadDisambiguation,
                    (ctx, includeDocMarkers) => WithSourceFileContext(ctx).WithIncludeDocMarkers(includeDocMarkers).ServerStreamingMethod);

                public class ResourceName
                {
                    public static IEnumerable<ResourceName> Create(Signature sig)
                    {
                        if (!sig._sig.Fields.Any(f => f.FieldResources is object))
                        {
                            return Enumerable.Empty<ResourceName>();
                        }
                        var allOverloads = sig._sig.Fields.Aggregate(ImmutableList.Create(ImmutableList<(Typ typ, string name)>.Empty), (overloads, f) =>
                        {
                            var parameters = f.FieldResources is null ? new[] { (f.Typ, f.ParameterName) }
                                : f.FieldResources.Where(resDetails => resDetails.ContainsWildcard != false).Select(x => (x.ResourceDefinition.ResourceNameTyp, f.ParameterName));
                            return overloads.SelectMany(overload => parameters.Select(parameter => overload.Add(parameter))).ToImmutableList();
                        }).ToList();
                        return allOverloads.Select((parameters, index) => new ResourceName(sig, parameters, allOverloads.Count > 1 ? (int?) (index + 1) : null));
                    }

                    public ResourceName WithSourceFileContext(SourceFileContext ctx) =>
                        ctx == Ctx ? this : new ResourceName(_sig.WithSourceFileContext(ctx), _parameters, _index);

                    public ResourceName WithIncludeDocMarkers(bool includeDocMarkers) =>
                        includeDocMarkers == IncludeDocMarkers ? this : new ResourceName(_sig.WithIncludeDocMarkers(includeDocMarkers), _parameters, _index);

                    private ResourceName(Signature sig, IReadOnlyList<(Typ typ, string name)> parameters, int? index) => (_sig, _parameters, _index) = (sig, parameters, index);

                    private readonly Signature _sig;
                    private readonly IReadOnlyList<(Typ typ, string name)> _parameters;
                    private readonly int? _index;
                    private SourceFileContext Ctx => _sig.Ctx;
                    private MethodDetails Method => _sig.Method;
                    private ServiceDetails Svc => _sig.Svc;
                    private IEnumerable<Typ> Typs => _parameters.Select(p => p.typ);

                    private string OverloadDisambiguation => _index?.ToString() ?? "";
                    private string RegionTagOverloadDisambiguation => $"{_sig.RegionTagOverloadDisambiguation}_resourceNames{OverloadDisambiguation}";

                    private IEnumerable<ClientMethod.Types.Parameter> CoreClientMethodParameters => _parameters.Select(p => ParameterFromTyp(p.typ, p.name));

                    private IEnumerable<ClientMethod.Types.Parameter> NormalClientMethodParameters => WithCallSettings(CoreClientMethodParameters);

                    private IEnumerable<ClientMethod.Types.Parameter> PaginatedClientMethodParameters => WithCallSettings(WithPaginationParameters(CoreClientMethodParameters));

                    private string SyncMethodName => $"{_sig.SyncMethodName}ResourceNames{OverloadDisambiguation}";
                    private string AsyncMethodName => $"{SyncMethodName}Async";
                    private bool IncludeDocMarkers => _sig.IncludeDocMarkers;

                    private IEnumerable<LocalDeclarationStatementSyntax> InitRequestArgs =>
                        _sig._sig.Fields.Zip(Typs, (f, typ) =>
                            Local(Ctx.Type(f.IsRepeated && f.FieldResources is object ? Typ.Generic(typeof(IEnumerable<>), typ) : typ),
                                f.Descs.Last().CSharpFieldName()).WithInitializer(_sig._def.DefaultValue(f.Descs.Last(), new HashSet<MessageDescriptor> (), typ, topLevel: true)));

                    private IEnumerable<Typ> SnippetTyps =>
                        _sig._sig.Fields.Zip(Typs, (f, typ) => f.IsRepeated && f.FieldResources is object ? Typ.Generic(typeof(IEnumerable<>), typ) : typ);

                    private MethodDeclarationSyntax SyncMethod => _sig._def.Sync(SyncMethodName, SnippetTyps, InitRequestArgs, Method.SyncReturnTyp is Typ.VoidTyp ?
                        (object) _sig.SyncClientMethodCall(InitRequestArgs.ToArray()) :
                        _sig._def.Response.WithInitializer(_sig.SyncClientMethodCall(InitRequestArgs.ToArray())));

                    public SnippetDef SyncSnippet => new SnippetDef(Method, true, SyncMethodName, NormalClientMethodParameters, RegionTagOverloadDisambiguation,
                        (ctx, includeDocMarkers) => WithSourceFileContext(ctx).WithIncludeDocMarkers(includeDocMarkers).SyncMethod);

                    private MethodDeclarationSyntax AsyncMethod => _sig._def.Async(AsyncMethodName, SnippetTyps, InitRequestArgs, Method.SyncReturnTyp is Typ.VoidTyp ?
                        (object) Await(_sig.AsyncClientMethodCall(InitRequestArgs.ToArray())) :
                        _sig._def.Response.WithInitializer(Await(_sig.AsyncClientMethodCall(InitRequestArgs.ToArray()))));

                    public SnippetDef AsyncSnippet => new SnippetDef(Method, false, AsyncMethodName, NormalClientMethodParameters, RegionTagOverloadDisambiguation,
                        (ctx, includeDocMarkers) => WithSourceFileContext(ctx).WithIncludeDocMarkers(includeDocMarkers).AsyncMethod);

                    private MethodDeclarationSyntax SyncLroMethod => _sig._def.SyncLro(SyncMethodName, SnippetTyps, InitRequestArgs,
                        _sig._def.Response.WithInitializer(_sig.SyncClientMethodCall(InitRequestArgs.ToArray())));

                    public SnippetDef SyncLroSnippet => new SnippetDef(Method, true, SyncMethodName, NormalClientMethodParameters, RegionTagOverloadDisambiguation,
                        (ctx, includeDocMarkers) => WithSourceFileContext(ctx).WithIncludeDocMarkers(includeDocMarkers).SyncLroMethod);

                    private MethodDeclarationSyntax AsyncLroMethod => _sig._def.AsyncLro(AsyncMethodName, SnippetTyps, InitRequestArgs,
                        _sig._def.Response.WithInitializer(Await(_sig.AsyncClientMethodCall(InitRequestArgs.ToArray()))));

                    public SnippetDef AsyncLroSnippet => new SnippetDef(Method, false, AsyncMethodName, NormalClientMethodParameters, RegionTagOverloadDisambiguation,
                        (ctx, includeDocMarkers) => WithSourceFileContext(ctx).WithIncludeDocMarkers(includeDocMarkers).AsyncLroMethod);

                    private MethodDeclarationSyntax SyncPaginatedMethod => _sig._def.SyncPaginated(SyncMethodName, SnippetTyps, InitRequestArgs,
                        _sig._def.Response.WithInitializer(_sig.SyncClientMethodCall(_sig.PaginatedArgs(InitRequestArgs).ToArray())), true);

                    public SnippetDef SyncPaginatedSnippet => new SnippetDef(Method, true, SyncMethodName, PaginatedClientMethodParameters, RegionTagOverloadDisambiguation,
                        (ctx, includeDocMarkers) => WithSourceFileContext(ctx).WithIncludeDocMarkers(includeDocMarkers).SyncPaginatedMethod);

                    private MethodDeclarationSyntax AsyncPaginatedMethod => _sig._def.AsyncPaginated(AsyncMethodName, SnippetTyps, InitRequestArgs,
                        _sig._def.AsyncResponse.WithInitializer(_sig.AsyncClientMethodCall(_sig.PaginatedArgs(InitRequestArgs).ToArray())), true);

                    public SnippetDef AsyncPaginatedSnippet => new SnippetDef(Method, false, AsyncMethodName, PaginatedClientMethodParameters, RegionTagOverloadDisambiguation,
                        (ctx, includeDocMarkers) => WithSourceFileContext(ctx).WithIncludeDocMarkers(includeDocMarkers).AsyncPaginatedMethod);

                    private MethodDeclarationSyntax ServerStreamingMethod => _sig._def.ServerStreaming(SyncMethodName, SnippetTyps, InitRequestArgs,
                        _sig._def.Response.WithInitializer(_sig.SyncClientMethodCall(InitRequestArgs.ToArray())));

                    public SnippetDef ServerStreamingSnippet => new SnippetDef(Method, true, SyncMethodName, NormalClientMethodParameters, RegionTagOverloadDisambiguation,
                        (ctx, includeDocMarkers) => WithSourceFileContext(ctx).WithIncludeDocMarkers(includeDocMarkers).ServerStreamingMethod);
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

            public IEnumerable<Signature> Signatures => Method.Signatures.Select((sig, i) => new Signature(this, sig, Method.Signatures.Count > 1 ? i : (int?) null));
        }
    }

    /// <summary>
    /// Recursively traverses a syntax element, (usually a single snippet compilation unit)
    /// looking for snippet segment annotations. It then uses the annotations to extract
    /// segment information, including segment type and segment start and end line numbers, and
    /// includes this information on the given snippet metadata.
    /// </summary>
    internal class SnippetSegmentFinder : CSharpSyntaxWalker
    {
        private static string SegmentAnnotationKind { get; } = "snippet-segment";

        public static SyntaxAnnotation ShortSegmentStart { get; } = AnnotationFor(SegmentType.Short, start: true, lineAddition: 2);
        public static SyntaxAnnotation ShortSegmentEnd { get; } = AnnotationFor(SegmentType.Short, start: false);

        public static SyntaxAnnotation FullSegmentStart { get; } = AnnotationFor(SegmentType.Full, start: true, lineAddition: 2);
        public static SyntaxAnnotation FullSegmentEnd { get; } = AnnotationFor(SegmentType.Full, start: false);

        private SnippetMetadata _snippetMedata;

        private SnippetSegmentFinder(SnippetMetadata snippetMetadata)
            : base(SyntaxWalkerDepth.StructuredTrivia) => _snippetMedata = snippetMetadata;

        public override void Visit(SyntaxNode node)
        {
            UpdateMetadata(node.GetAnnotations(SegmentAnnotationKind), node.SyntaxTree, node.Span);
            base.Visit(node);
        }

        public override void VisitToken(SyntaxToken token)
        {
            UpdateMetadata(token.GetAnnotations(SegmentAnnotationKind), token.SyntaxTree, token.Span);
            base.VisitToken(token);
        }

        public override void VisitTrivia(SyntaxTrivia trivia)
        {
            UpdateMetadata(trivia.GetAnnotations(SegmentAnnotationKind), trivia.SyntaxTree, trivia.Span);
            base.VisitTrivia(trivia);
        }

        // Note: Nodes, tokens and trivia may be annotated with segment annotations.
        // This method just works for all, as their corresponding types don't have a common base class.
        private void UpdateMetadata(IEnumerable<SyntaxAnnotation> annotations, SyntaxTree syntaxTree, TextSpan span)
        {
            foreach (var segmentAnnotation in annotations)
            {
                // Extract information from annotation
                var rawData = segmentAnnotation.Data.Split(';');
                var segmentType = System.Enum.Parse<SegmentType>(rawData[0]);
                var isStart = bool.Parse(rawData[1]);
                var lineAddition = int.Parse(rawData[2]);

                // We will encounter start and end segment markers in different visitis,
                // so let's check if the segment with partial information has
                // already been added to the metadata.
                var segment = _snippetMedata.Segments.FirstOrDefault(segment => segment.Type == segmentType);
                if (segment is null)
                {
                    segment = new SnippetMetadata.Types.Segment { Type = segmentType };
                    _snippetMedata.Segments.Add(segment);
                }

                // Get the line number
                var lineNumber = syntaxTree.GetLineSpan(span).StartLinePosition.Line + lineAddition;

                // Add the line number to the metadata
                if (isStart)
                {
                    segment.Start = lineNumber;
                }
                else
                {
                    segment.End = lineNumber;
                }
            }
        }

        private static SyntaxAnnotation AnnotationFor(SegmentType type, bool start, int lineAddition = 0) =>
            new SyntaxAnnotation(SegmentAnnotationKind, $"{type};{start};{lineAddition}");

        public static void UpdateMetadataWithSegmentInfo(CompilationUnitSyntax formattedCode, SnippetMetadata snippetMetadata)
        {
            var segmentFinder = new SnippetSegmentFinder(snippetMetadata);
            segmentFinder.Visit(formattedCode);
        }
    }

    internal static class RoslynSnippetExtensions
    {
        public static MethodDeclarationSyntax WithShortSnippetBody(this MethodDeclarationSyntax method, params object[] code)
        {
            method = method.WithBody(code);
            method = method.WithBody(
                method.Body.WithOpenBraceToken(
                    method.Body.OpenBraceToken.WithAdditionalAnnotations(SnippetSegmentFinder.ShortSegmentStart)));
            method = method.WithBody(
                method.Body.WithCloseBraceToken(
                    method.Body.CloseBraceToken.WithAdditionalAnnotations(SnippetSegmentFinder.ShortSegmentEnd)));
            return method;
        }
    }
}
