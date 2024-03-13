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

using Google.Api.Gax;
using Google.Api.Generator.ProtoUtils;
using Google.Api.Generator.Utils;
using Google.Api.Generator.Utils.Roslyn;
using Google.Cloud;
using Google.LongRunning;
using Google.Protobuf.Reflection;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using static Google.Api.Generator.Utils.Roslyn.Modifier;
using static Google.Api.Generator.Utils.Roslyn.RoslynBuilder;
using static Google.Api.Generator.Utils.Roslyn.RoslynExtensions;

namespace Google.Api.Generator.Generation
{
    /// <summary>
    /// Generate all code in the "{File}LroAdaptation.cs" file. These are partial classes for
    /// proto messages:
    /// 
    /// - Initial request messages (e.g. InsertAddressRequest):
    ///   - PopulatePollRequestFields(PollRequest) method
    /// - Poll request messages (e.g. GetRegionOperationRequest):
    ///   - s_operationNameTemplate field used by other methods
    ///   - GetRegionOperationRequest ParseLroRequest(lro::GetOperationRequest) method
    ///   - GetRegionOperationRequest FromInitialResponse(NonStandardOperation) method
    ///   - string ToLroOperationName() method
    /// - Local operation messages (e.g. NonStandardOperation) - unimplemented as yet
    ///   - lro::Operation ToLroResponse(string name) method
    /// </summary>
    internal class LroAdaptationGenerator
    {
        public static (CompilationUnitSyntax, int) Generate(ProtoCatalog catalog, SourceFileContext ctx, FileDescriptor fileDesc) =>
            new LroAdaptationGenerator(catalog, ctx, fileDesc).Generate();

        private LroAdaptationGenerator(ProtoCatalog catalog, SourceFileContext ctx, FileDescriptor fileDesc) =>
            (_catalog, _ctx, _fileDesc) = (catalog, ctx, fileDesc);


        private readonly ProtoCatalog _catalog;
        private readonly SourceFileContext _ctx;
        private readonly FileDescriptor _fileDesc;

        private (CompilationUnitSyntax, int) Generate()
        {
            var ns = Namespace(_fileDesc.CSharpNamespace());
            using (_ctx.InNamespace(ns))
            {
                var initialRequestPartials = InitialRequestClasses().ToArray();
                var pollRequestPartials = PollRequestClasses().ToArray();
                var operationMessagePartials = OperationMessageClasses().ToArray();
                ns = ns.AddMembers(initialRequestPartials);
                ns = ns.AddMembers(pollRequestPartials);
                ns = ns.AddMembers(operationMessagePartials);
                return (_ctx.CreateCompilationUnit(ns), initialRequestPartials.Length + pollRequestPartials.Length + operationMessagePartials.Length);
            }
        }

        private IEnumerable<ClassDeclarationSyntax> InitialRequestClasses()
        {
            foreach (var service in _fileDesc.Services)
            {
                var serviceDetails = new ServiceDetails(_catalog, _ctx.Namespace, service, grpcServiceConfig: null, serviceConfig: null, transports: ApiTransports.None, librarySettings: null);
                // Assumption: each method has its own request type.
                foreach (var method in serviceDetails.Methods.OfType<MethodDetails.NonStandardLro>())
                {
                    var operationDetails = method.OperationServiceDetails;
                    var pollingRequestDescriptor = operationDetails.PollingRequestDescriptor;
                    var cls = Class(Public | Partial, ProtoTyp.Of(method.RequestMessageDesc));

                    using (_ctx.InClass(cls))
                    {
                        var param = Parameter(_ctx.Type(operationDetails.PollingRequestTyp), "pollRequest");
                        var assignments = method.RequestMessageDesc.Fields.InFieldNumberOrder()
                            .Select(field =>
                            {
                                string pollingRequestFieldName = field.GetExtension(ExtendedOperationsExtensions.OperationRequestField);
                                if (string.IsNullOrEmpty(pollingRequestFieldName))
                                {
                                    return null;
                                }
                                // Note: not using indexer on MessageDescriptor, as the code below provides more helpful diagnostics.
                                var pollingRequestField = pollingRequestDescriptor.Fields.InDeclarationOrder().FirstOrDefault(f => f.Name == pollingRequestFieldName);
                                if (pollingRequestField is null)
                                {
                                    throw new InvalidOperationException($"No field '{pollingRequestFieldName}' in message {pollingRequestDescriptor.FullName}");
                                }
                                return param.Access(pollingRequestField.CSharpPropertyName())
                                    .Assign(Property(Private, _ctx.TypeDontCare, field.CSharpPropertyName()));
                            })
                            .Where(x => x is object)
                            .ToArray<object>();

                        var populatePollRequestFieldsMethod = Method(Internal, VoidType, "PopulatePollRequestFields")(param)
                            .WithBody(assignments);
                        cls = cls.AddMembers(populatePollRequestFieldsMethod);
                    }
                    yield return cls;
                }
            }
        }

        private IEnumerable<ClassDeclarationSyntax> PollRequestClasses()
        {
            foreach (var service in _fileDesc.Services)
            {
                var serviceDetails = new ServiceDetails(_catalog, _ctx.Namespace, service, grpcServiceConfig: null, serviceConfig: null, transports: ApiTransports.None, librarySettings: null);
                // TODO: Use "is not" and continue when we can guarantee a recent enough version of C#.
                if (serviceDetails.NonStandardLro is ServiceDetails.NonStandardLroDetails lroDetails)
                {
                    var cls = Class(Public | Partial, ProtoTyp.Of(lroDetails.PollingRequestDescriptor));
                    using (_ctx.InClass(cls))
                    {
                        var operationNameFields = lroDetails.PollingRequestDescriptor.Fields.InFieldNumberOrder()
                            .Where(field => field.GetExtension(FieldBehaviorExtensions.FieldBehavior)?.Contains(FieldBehavior.Required) == true)
                            .ToList();

                        var pathTemplateField = Field(Private | Static, _ctx.Type<PathTemplate>(), "s_operationNameTemplate")
                            .WithInitializer(New(_ctx.Type<PathTemplate>())(string.Join("/", operationNameFields.Select(f => $"{f.JsonName}/{{{f.JsonName}}}"))));

                        cls = cls.AddMembers(pathTemplateField, ParseLroRequest(), FromInitialResponse(), ToLroOperationName());

                        MethodDeclarationSyntax ParseLroRequest()
                        {
                            var request = Parameter(_ctx.Type<GetOperationRequest>(), "request");
                            var parsedName = Local(_ctx.Type<TemplatedResourceName>(), "parsedName");
                            var assignments = operationNameFields.Select((field, index) => new ObjectInitExpr(field.CSharpPropertyName(), parsedName.ElementAccess(index))).ToArray();
                            return Method(Internal | Static, _ctx.Type(lroDetails.PollingRequestTyp), "ParseLroRequest")(request)
                                .WithBody(
                                    parsedName.WithInitializer(pathTemplateField.Call("ParseName")(request.Access("Name"))),
                                    Return(New(_ctx.Type(lroDetails.PollingRequestTyp))().WithInitializer(assignments)));
                        }

                        MethodDeclarationSyntax FromInitialResponse()
                        {
                            var parameter = Parameter(_ctx.Type(lroDetails.OperationTyp), "response");
                            var assignments = lroDetails.PollingRequestDescriptor.Fields.InFieldNumberOrder()
                                .Select(field =>
                                {
                                    var operationFieldName = field.GetExtension(ExtendedOperationsExtensions.OperationResponseField);
                                    if (string.IsNullOrEmpty(operationFieldName))
                                    {
                                        return null;
                                    }
                                    // Note: not using indexer on MessageDescriptor, as the code below provides more helpful diagnostics.
                                    var operationField = lroDetails.OperationDescriptor.Fields.InDeclarationOrder().FirstOrDefault(f => f.Name == operationFieldName);
                                    if (operationField is null)
                                    {
                                        throw new InvalidOperationException($"No field '{operationFieldName}' in message {lroDetails.OperationDescriptor.FullName}");
                                    }

                                    return new ObjectInitExpr(field.CSharpPropertyName(), parameter.Access(operationField.CSharpPropertyName()));
                                })
                                .Where(init => init is object)
                                .ToArray();
                            return Method(Internal | Static, _ctx.Type(lroDetails.PollingRequestTyp), "FromInitialResponse")(parameter)
                                .WithBody(New(_ctx.Type(lroDetails.PollingRequestTyp))().WithInitializer(assignments));
                        }

                        MethodDeclarationSyntax ToLroOperationName()
                        {
                            return Method(Internal, _ctx.Type<string>(), "ToLroOperationName")()
                                .WithBody(pathTemplateField.Call("Expand")(operationNameFields.Select(f => Property(Private, _ctx.TypeDontCare, f.CSharpPropertyName())).ToArray()));
                        }
                    }
                    yield return cls;
                }
            }
        }

        private IEnumerable<ClassDeclarationSyntax> OperationMessageClasses()
        {
            // TODO: implement
            yield break;
        }
    }
}
