// Copyright 2019 Google Inc. All Rights Reserved.
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
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using static Google.Api.Generator.RoslynUtils.Modifier;
using static Google.Api.Generator.RoslynUtils.RoslynBuilder;

namespace Google.Api.Generator.Generation
{
    internal partial class ServiceMethodGenerator
    {
        private partial class MethodDef
        {
            // Method signature

            public class Signature
            {
                private class ParameterInfo
                {
                    public ParameterInfo(ParameterSyntax parameter, ObjectInitExpr initExpr,
                        DocumentationCommentTriviaSyntax xmlDoc) => (Parameter, InitExpr, XmlDoc) = (parameter, initExpr, xmlDoc);
                    public ParameterSyntax Parameter { get; }
                    public ObjectInitExpr InitExpr { get; }
                    public DocumentationCommentTriviaSyntax XmlDoc { get; }
                }

                public Signature(MethodDef def, MethodDetails.Signature sig) => (_def, _sig) = (def, sig);

                private MethodDef _def;
                private MethodDetails.Signature _sig;

                private SourceFileContext Ctx => _def.Ctx;
                private MethodDetails MethodDetails => _def.MethodDetails;

                private ObjectInitExpr InitExpr(MethodDetails.Signature.Field field, ParameterSyntax param, bool treatAsResource = false, bool isResourceSet = false)
                {
                    // Type                  | Single optional | Single required | Repeated optional | Repeated required
                    // ----------------------|-----------------|-----------------|-------------------|------------------
                    // Primitive             | nothing to do   | nothing to do   | null -> empty     | check not null
                    // string                | null -> ""      | check not empty | null -> empty     | check not null
                    // bytes                 | null -> byte[0] | check not null  | null -> empty     | check not null
                    // message               | null ok         | check not null  | null -> empty     | check not null
                    // resourcename (string) | null -> ""      | check not null  | null -> empty     | check not null
                    // resourcenames use the generated partial resource-name-typde properties, which perform the string conversion.
                    var resourceField = field.FieldResource; // Null if not a resource field.
                    object code;
                    if (field.IsRepeated)
                    {
                        if (treatAsResource)
                        {
                            if (isResourceSet)
                            {
                                throw new NotImplementedException(); // TODO: Resource sets.
                            }
                            else
                            {
                                code = CollectionInitializer(field.Required ?
                                    Ctx.Type(typeof(GaxPreconditions)).Call(nameof(GaxPreconditions.CheckNotNull))(param, Nameof(param)) :
                                    param.NullCoalesce(Ctx.Type(typeof(Enumerable)).Call(
                                        nameof(Enumerable.Empty), Ctx.Type(field.FieldResource.ResourceDefinition.One.ResourceNameTyp))()));
                            }
                        }
                        else
                        {
                            code = CollectionInitializer(field.Required ?
                                Ctx.Type(typeof(GaxPreconditions)).Call(nameof(GaxPreconditions.CheckNotNull))(param, Nameof(param)) :
                                param.NullCoalesce(Ctx.Type(typeof(Enumerable)).Call(nameof(Enumerable.Empty), Ctx.Type(field.Typ.GenericArgTyps.First()))()));
                        }
                    }
                    else
                    {
                        if (treatAsResource)
                        {
                            if (isResourceSet)
                            {
                                throw new NotImplementedException(); // TODO: Resource set.
                            }
                            else
                            {
                                code = field.Required ?
                                    Ctx.Type(typeof(GaxPreconditions)).Call(nameof(GaxPreconditions.CheckNotNull))(param, Nameof(param)) :
                                    (object)param;
                            }
                        }
                        else if (field.Typ.IsPrimitive)
                        {
                            code = param;
                        }
                        else if (field.Typ.FullName == typeof(string).FullName)
                        {
                            code = field.Required ?
                                Ctx.Type(typeof(GaxPreconditions)).Call(nameof(GaxPreconditions.CheckNotNullOrEmpty))(param, Nameof(param)) :
                                param.NullCoalesce("");
                        }
                        else if (field.Typ.FullName == typeof(ByteString).FullName)
                        {
                            code = field.Required ?
                                Ctx.Type(typeof(GaxPreconditions)).Call(nameof(GaxPreconditions.CheckNotNull))(param, Nameof(param)) :
                                param.NullCoalesce(Ctx.Type<ByteString>().Access(nameof(ByteString.Empty)));
                        }
                        else
                        {
                            code = field.Required ?
                                Ctx.Type(typeof(GaxPreconditions)).Call(nameof(GaxPreconditions.CheckNotNull))(param, Nameof(param)) :
                                (object)param;
                        }
                    }

                    return new ObjectInitExpr(treatAsResource ? resourceField.ResourcePropertyName : field.PropertyName, code);
                }

                private IEnumerable<ParameterInfo> Parameters => _sig.Fields.Select(field =>
                {
                    var parameter = Parameter(Ctx.Type(field.Typ), field.FieldName);
                    var initExpr = InitExpr(field, parameter);
                    var xmlDoc = XmlDoc.ParamPreFormatted(parameter, field.DocLines);
                    return new ParameterInfo(parameter, initExpr, xmlDoc);
                });

                private IEnumerable<ParameterSyntax> ParametersWithCallSettings => Parameters.Select(x => x.Parameter).Append(_def.CallSettingsParam);
                private IEnumerable<ParameterSyntax> ParametersWithCancellationToken => Parameters.Select(x => x.Parameter).Append(_def.CancellationTokenParam);

                private MethodDeclarationSyntax AbstractRequestMethod(bool sync, bool callSettings, IEnumerable<ParameterInfo> parameters, DocumentationCommentTriviaSyntax returnsXmlDoc = null)
                {
                    var returnTyp = sync ? MethodDetails.SyncReturnTyp : MethodDetails.AsyncReturnTyp;
                    var methodName = sync ? MethodDetails.SyncMethodName : MethodDetails.AsyncMethodName;
                    var finalParam = callSettings ? _def.CallSettingsParam : _def.CancellationTokenParam;
                    var finalParamXmlDoc = callSettings ? _def.CallSettingsXmlDoc : _def.CancellationTokenXmlDoc;
                    returnsXmlDoc = returnsXmlDoc ?? (sync ?
                        MethodDetails is MethodDetails.Paginated ? _def.ReturnsSyncPaginatedXmlDoc : _def.ReturnsSyncXmlDoc :
                        MethodDetails is MethodDetails.Paginated ? _def.ReturnsAsyncPaginatedXmlDoc : _def.ReturnsAsyncXmlDoc);
                    if (callSettings)
                    {
                        return Method(Public | Virtual, Ctx.Type(returnTyp), methodName)(parameters.Select(x => x.Parameter).Append(finalParam).ToArray())
                                .WithBody(This.Call(methodName)(New(Ctx.Type(MethodDetails.RequestTyp))()
                                    .WithInitializer(parameters.Select(x => x.InitExpr).ToArray()), finalParam))
                                    .WithXmlDoc(parameters.Select(x => x.XmlDoc).Prepend(_def.SummaryXmlDoc).Append(finalParamXmlDoc).Append(returnsXmlDoc).ToArray());
                    }
                    else
                    {
                        return Method(Public | Virtual, Ctx.Type(returnTyp), methodName)(parameters.Select(x => x.Parameter).Append(finalParam).ToArray())
                                .WithBody(This.Call(methodName)(parameters.Select(x => (object)x.Parameter).Append(
                                    Ctx.Type<CallSettings>().Call(nameof(CallSettings.FromCancellationToken))(finalParam))))
                                    .WithXmlDoc(parameters.Select(x => x.XmlDoc).Prepend(_def.SummaryXmlDoc).Append(finalParamXmlDoc).Append(returnsXmlDoc).ToArray());
                    }
                }

                public MethodDeclarationSyntax AbstractSyncRequestMethod => AbstractRequestMethod(true, true, Parameters);
                public MethodDeclarationSyntax AbstractAsyncCallSettingsRequestMethod => AbstractRequestMethod(false, true, Parameters);
                public MethodDeclarationSyntax AbstractAsyncCancellationTokenRequestMethod => AbstractRequestMethod(false, false, Parameters);

                public MethodDeclarationSyntax AbstractServerStreamSyncRequestMethod => AbstractRequestMethod(true, true, Parameters, _def.ReturnsServerStreamingXmlDoc);

                public class ResourceName
                {
                    internal static IEnumerable<ResourceName> Create(Signature signature)
                    {
                        var ctx = signature.Ctx;
                        var fields = signature._sig.Fields;
                        if (!fields.Any(f => f.FieldResource != null))
                        {
                            yield break;
                        }
                        var bothCount = fields.Count(f => f.FieldResource?.ResourceDefinition.One != null && f.FieldResource?.ResourceDefinition.Set != null);
                        if (bothCount > 4)
                        {
                            throw new InvalidOperationException($"Cannot generate >16 overloads for resource/resourceset method signature: '{signature._def.MethodDetails.SyncMethodName}'");
                        }
                        var overloadCount = 1 << bothCount;
                        for (int i = 0; i < overloadCount; i++)
                        {
                            var parameters = new List<ParameterInfo>();
                            int mask = 1;
                            foreach (var field in fields)
                            {
                                var fieldResource = field.FieldResource;
                                var oneDef = fieldResource?.ResourceDefinition.One;
                                var setDef = fieldResource?.ResourceDefinition.Set;
                                bool isSet = false;
                                if (oneDef != null && setDef != null)
                                {
                                    isSet = (i & mask) != 0;
                                    mask <<= 1;
                                }
                                else
                                {
                                    isSet = setDef != null;
                                }
                                var parameter = Parameter(ctx.Type(MaybeRepeated(isSet ? setDef?.ResourceNameTyp : oneDef?.ResourceNameTyp) ?? field.Typ), field.FieldName);
                                var initExpr = signature.InitExpr(field, parameter, fieldResource != null, isSet);
                                var xmlDoc = XmlDoc.ParamPreFormatted(parameter, field.DocLines);
                                parameters.Add(new ParameterInfo(parameter, initExpr, xmlDoc));
                                Typ MaybeRepeated(Typ typ) => field.IsRepeated ? Typ.Generic(typeof(IEnumerable<>), typ) : typ;
                            }
                            yield return new ResourceName(signature, parameters);
                        }
                    }

                    private ResourceName(Signature signature, IEnumerable<ParameterInfo> parameters)
                    {
                        _signature = signature;
                        _parameters = parameters;
                    }

                    private Signature _signature;
                    private IEnumerable<ParameterInfo> _parameters;

                    public MethodDeclarationSyntax AbstractSyncRequestMethod => _signature.AbstractRequestMethod(true, true, _parameters);
                    public MethodDeclarationSyntax AbstractAsyncCallSettingsRequestMethod => _signature.AbstractRequestMethod(false, true, _parameters);
                    public MethodDeclarationSyntax AbstractAsyncCancellationTokenRequestMethod => _signature.AbstractRequestMethod(false, false, _parameters);

                    public MethodDeclarationSyntax AbstractServerStreamSyncRequestMethod => _signature.AbstractRequestMethod(true, true, _parameters, _signature._def.ReturnsServerStreamingXmlDoc);
                }

                public IEnumerable<ResourceName> ResourceNames => ResourceName.Create(this);
            }

            public IEnumerable<Signature> Signatures => MethodDetails.Signatures.Select(sig => new Signature(this, sig));
        }
    }
}
