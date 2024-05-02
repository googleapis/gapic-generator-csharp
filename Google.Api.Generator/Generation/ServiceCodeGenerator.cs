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

using Google.Api.Gax.Grpc;
using Google.Api.Generator.ProtoUtils;
using Google.Api.Generator.Utils;
using Google.Api.Generator.Utils.Roslyn;
using Google.LongRunning;
using Google.Protobuf.Reflection;
using Grpc.Core;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static Google.Api.Generator.Utils.Roslyn.Modifier;
using static Google.Api.Generator.Utils.Roslyn.RoslynBuilder;

namespace Google.Api.Generator.Generation
{
    /// <summary>
    /// Generate all code related to a proto-defined service.
    /// </summary>
    internal static class ServiceCodeGenerator
    {
        public static CompilationUnitSyntax Generate(SourceFileContext ctx, ServiceDetails svc, HashSet<Typ> seenPaginatedResponseTyps)
        {
            var ns = Namespace(svc.Namespace);
            using (ctx.InNamespace(ns))
            {
                var settingsClass = ServiceSettingsCodeGenerator.Generate(ctx, svc);
                var builderClass = ServiceBuilderCodeGenerator.Generate(ctx, svc);
                var abstractClientClass = ServiceAbstractClientClassCodeGenerator.Generate(ctx, svc);
                var implClientClass = ServiceImplClientClassGenerator.Generate(ctx, svc);
                ns = ns.AddMembers(settingsClass, builderClass, abstractClientClass, implClientClass);

                ns = ns.AddMembers(PaginatedPartialClasses(ctx, svc, seenPaginatedResponseTyps).ToArray());
                ns = ns.AddMembers(LroPartialClasses(ctx, svc).ToArray());
                ns = ns.AddMembers(MixinPartialClasses(ctx, svc).ToArray());
            }
            return ctx.CreateCompilationUnit(ns);
        }

        private static IEnumerable<MemberDeclarationSyntax> PaginatedPartialClasses(SourceFileContext ctx, ServiceDetails svc, HashSet<Typ> seenPaginatedResponseTyps)
        {
            var paginatedMethods = svc.Methods.OfType<MethodDetails.Paginated>();
            foreach (var representingMethod in paginatedMethods
                                                        .GroupBy(m => m.RequestTyp)
                                                        .Select(typMethodGrp => typMethodGrp.First()))
            {
                yield return PaginatedPartialInterfaceClass(ctx, representingMethod.RequestTyp, representingMethod.RequestMessageDesc);
            }

            foreach (var method in paginatedMethods)
            {
                if (seenPaginatedResponseTyps.Add(method.ResponseTyp))
                {
                    var cls = Class(Public | Partial, method.ResponseTyp, baseTypes: ctx.Type(Typ.Generic(typeof(IPageResponse<>), method.ResourceTyp)));
                    using (ctx.InClass(cls))
                    {
                        var propertyName = method.ResourcesFieldName;
                        var genericGetEnumerator = Method(Public, ctx.Type(Typ.Generic(typeof(IEnumerator<>), method.ResourceTyp)), "GetEnumerator")()
                            .WithBody(Property(Public, ctx.TypeDontCare, propertyName).Call(nameof(IEnumerable<int>.GetEnumerator))())
                            .WithXmlDoc(XmlDoc.Summary("Returns an enumerator that iterates through the resources in this response."));
                        var getEnumerator = Method(None, ctx.Type<IEnumerator>(), "GetEnumerator")()
                            .WithExplicitInterfaceSpecifier(ctx.Type<IEnumerable>())
                            .WithBody(This.Call(genericGetEnumerator)());
                        cls = cls.AddMembers(genericGetEnumerator, getEnumerator);
                    }
                    yield return cls;
                }
            }
        }

        private static MemberDeclarationSyntax PaginatedPartialInterfaceClass(SourceFileContext ctx, Typ typ, MessageDescriptor messageDesc)
        {
            var partialInterfaceCls = Class(Public | Partial, typ, baseTypes: ctx.Type<IPageRequest>());

            if (messageDesc.FindFieldByName("page_size") is null)
            {
                //DiREGapic scenario where `max_results` is an option for a page size-semantic field.
                var maxResMessage = messageDesc.FindFieldByName("max_results");
                if (maxResMessage is null)
                {
                    throw new InvalidOperationException("Paginated request should have either page_size or max_results field.");
                }

                using (ctx.InClass(partialInterfaceCls))
                {
                    var underlyingProperty = Property(DontCare, ctx.TypeDontCare, "MaxResults");

                    var getBody = ProtoTyp.Of(maxResMessage) == Typ.Of<int>()
                        ? Return(underlyingProperty)
                        : Return(CheckedCast(ctx.Type<int>(), underlyingProperty));

                    var assignFrom = ProtoTyp.Of(maxResMessage) == Typ.Of<int>()
                        ? Value
                        : CheckedCast(ctx.Type(ProtoTyp.Of(maxResMessage)), Value);
                    var setBody = underlyingProperty.Assign(assignFrom);

                    var property = Property(Public, ctx.Type<int>(), "PageSize")
                        .WithGetBody(getBody)
                        .WithSetBody(setBody)
                        .WithXmlDoc(XmlDoc.InheritDoc);
                    partialInterfaceCls = partialInterfaceCls.AddMembers(property);
                }
            }

            return partialInterfaceCls;
        }


        private static IEnumerable<MemberDeclarationSyntax> LroPartialClasses(SourceFileContext ctx, ServiceDetails svc)
        {
            if (svc.Methods.Any(m => m is MethodDetails.StandardLro))
            {
                // Emit partial class to give access to an LRO operations client.
                var grpcOuterCls = Class(Public | Static | Partial, svc.GrpcClientTyp.DeclaringTyp);
                using (ctx.InClass(grpcOuterCls))
                {
                    var grpcInnerClass = Class(Public | Partial, svc.GrpcClientTyp);
                    using (ctx.InClass(grpcInnerClass))
                    {
                        var callInvoker = Property(Private, ctx.TypeDontCare, "CallInvoker");
                        var opTyp = ctx.Type<Operations.OperationsClient>();
                        var createOperationsClientMethod = Method(Public | Virtual, opTyp, "CreateOperationsClient")()
                            .WithBody(New(opTyp)(callInvoker))
                            .WithXmlDoc(
                                XmlDoc.Summary("Creates a new instance of ", opTyp, " using the same call invoker as this client."),
                                XmlDoc.Returns("A new Operations client for the same target as this client.")
                            );
                        grpcInnerClass = grpcInnerClass.AddMembers(createOperationsClientMethod);
                    }
                    grpcOuterCls = grpcOuterCls.AddMembers(grpcInnerClass);
                }
                yield return grpcOuterCls;
            }

            // Generate partial classes to delegate to other services handling operations
            if (svc.Methods.Any(m => m is MethodDetails.NonStandardLro))
            {
                var operationServices = svc.Methods.OfType<MethodDetails.NonStandardLro>().Select(lro => lro.OperationService).Distinct().ToList();

                // Emit partial class to give access to an LRO operations client.
                var grpcOuterCls = Class(Public | Static | Partial, svc.GrpcClientTyp.DeclaringTyp);
                using (ctx.InClass(grpcOuterCls))
                {
                    var grpcInnerClass = Class(Public | Partial, svc.GrpcClientTyp);
                    using (ctx.InClass(grpcInnerClass))
                    {
                        var callInvoker = Property(Private, ctx.TypeDontCare, "CallInvoker");
                        var opTyp = ctx.Type<Operations.OperationsClient>();

                        foreach (var operationService in operationServices)
                        {
                            var grpcClient = ctx.Type(Typ.Nested(Typ.Manual(ctx.Namespace, operationService), $"{operationService}Client"));
                            var createOperationsClientMethod = Method(Public | Virtual, opTyp, $"CreateOperationsClientFor{operationService}")()
                                .WithBody(grpcClient.Call("CreateOperationsClient")(callInvoker))
                                .WithXmlDoc(
                                    XmlDoc.Summary("Creates a new instance of ", opTyp, $" using the same call invoker as this client, delegating to {operationService}."),
                                    XmlDoc.Returns("A new Operations client for the same target as this client.")
                                );
                            grpcInnerClass = grpcInnerClass.AddMembers(createOperationsClientMethod);
                        }
                    }
                    grpcOuterCls = grpcOuterCls.AddMembers(grpcInnerClass);
                }
                yield return grpcOuterCls;
            }

            // Generate partial classes for the operation-handling services
            if (svc.NonStandardLro is ServiceDetails.NonStandardLroDetails lroDetails)
            {
                // Emit partial class to give access to an LRO operations client.
                var grpcOuterCls = Class(Public | Static | Partial, svc.GrpcClientTyp.DeclaringTyp);
                using (ctx.InClass(grpcOuterCls))
                {
                    var grpcInnerClass = Class(Public | Partial, svc.GrpcClientTyp);
                    using (ctx.InClass(grpcInnerClass))
                    {
                        var callInvoker = Parameter(ctx.Type<CallInvoker>(), "callInvoker");
                        var request = Parameter(ctx.TypeDontCare, "request");
                        var response = Parameter(ctx.TypeDontCare, "response");
                        var opTyp = ctx.Type<Operations.OperationsClient>();
                        var forwardingCallInvoker = Local(ctx.Type<CallInvoker>(), "forwardingCallInvoker");
                        var createOperationsClientMethod = Method(Internal | Static, opTyp, "CreateOperationsClient")(callInvoker)
                            .WithBody(
                                forwardingCallInvoker.WithInitializer(
                                    // Note: can't use Typ.Of<ForwardingCallInvoker<GetOperationRequest>> as it's a static class.
                                    ctx.Type(Typ.Generic(Typ.Of(typeof(ForwardingCallInvoker<>)), Typ.Of<GetOperationRequest>())).Call("Create")(
                                        callInvoker,
                                        "/google.longrunning.Operations/GetOperation",
                                        Property(Private, ctx.TypeDontCare, $"__Method_{lroDetails.PollingMethod.Name}"),
                                        ctx.Type(lroDetails.PollingRequestTyp).Access("ParseLroRequest"), // Method group conversion
                                        Lambda(request, response)(response.Call("ToLroResponse")(request.Access("Name")))
                                    )),
                                Return(New(opTyp)(forwardingCallInvoker)))
                            .WithXmlDoc(
                                XmlDoc.Summary(
                                    "Creates a new instance of ", opTyp, "using the specified call invoker, but ",
                                    $"redirecting Google.LongRunning RPCs to {lroDetails.Service.Name} RPCs."),
                                XmlDoc.Returns("A new Operations client for the same target as this client.")
                            );
                        grpcInnerClass = grpcInnerClass.AddMembers(createOperationsClientMethod);
                    }
                    grpcOuterCls = grpcOuterCls.AddMembers(grpcInnerClass);
                }
                yield return grpcOuterCls;
            }
        }

        private static IEnumerable<MemberDeclarationSyntax> MixinPartialClasses(SourceFileContext ctx, ServiceDetails svc)
        {
            if (svc.Mixins.Any())
            {
                // Emit partial class to give access to clients for mixin APIs.
                // (We may well have one of these *and* an LRO partial class, but that's okay.)
                var grpcOuterCls = Class(Public | Static | Partial, svc.GrpcClientTyp.DeclaringTyp);
                using (ctx.InClass(grpcOuterCls))
                {
                    var grpcInnerClass = Class(Public | Partial, svc.GrpcClientTyp);
                    using (ctx.InClass(grpcInnerClass))
                    {
                        var callInvoker = Property(Private, ctx.TypeDontCare, "CallInvoker");

                        foreach (var mixin in svc.Mixins)
                        {
                            var grpcClientType = ctx.Type(mixin.GrpcClientType);
                            var createClientMethod = Method(Public | Virtual, grpcClientType, "Create" + mixin.GrpcClientType.Name)()
                                .WithBody(New(grpcClientType)(callInvoker))
                                .WithXmlDoc(
                                    XmlDoc.Summary("Creates a new instance of ", grpcClientType, " using the same call invoker as this client."),
                                    XmlDoc.Returns("A new ", grpcClientType, " for the same target as this client.")
                                );
                            grpcInnerClass = grpcInnerClass.AddMembers(createClientMethod);
                        }
                    }
                    grpcOuterCls = grpcOuterCls.AddMembers(grpcInnerClass);
                }
                yield return grpcOuterCls;
            }
        }
    }
}
