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
using Google.Api.Generator.Utils.Roslyn;
using Google.Api.Generator.Utils;
using Google.LongRunning;
using Grpc.ServiceConfig;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Google.Api.Generator.ProtoUtils;
using Google.Protobuf.Reflection;
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
                    //Debugger.Launch();
                    throw new InvalidOperationException("Paginated request should have either page_size or max_results field.");
                }

                using (ctx.InClass(partialInterfaceCls))
                {
                    var underlyingProperty = Property(DontCare, ctx.TypeDontCare, "MaxResults");

                    var assignmentVal = ProtoTyp.Of(maxResMessage) == Typ.Of<int>() 
                        ? Value
                        : Cast(ctx.Type(ProtoTyp.Of(maxResMessage)), Value);

                    var property =  Property(Public, ctx.Type<Int32>(), "PageSize")
                        .WithSetBody(underlyingProperty.Assign(assignmentVal));
                    partialInterfaceCls = partialInterfaceCls.AddMembers(property);
                }
            }

            return partialInterfaceCls;
        }


        private static IEnumerable<MemberDeclarationSyntax> LroPartialClasses(SourceFileContext ctx, ServiceDetails svc)
        {
            if (svc.Methods.Any(m => m is MethodDetails.Lro))
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
        }
    }
}
