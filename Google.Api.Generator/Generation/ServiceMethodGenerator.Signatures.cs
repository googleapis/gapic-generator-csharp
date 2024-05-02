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
using Google.Api.Generator.Utils;
using Google.Api.Generator.Utils.Roslyn;
using Google.Protobuf;
using Google.Protobuf.Reflection;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using static Google.Api.Generator.Utils.Roslyn.Modifier;
using static Google.Api.Generator.Utils.Roslyn.RoslynBuilder;

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
                    public ParameterInfo(IReadOnlyList<FieldDescriptor> fieldDescs, ParameterSyntax parameter, object initExpr,
                        string resourcePropertyName, DocumentationCommentTriviaSyntax xmlDoc) =>
                        (FieldDescs, Parameter, InitExpr, ResourcePropertyName, XmlDoc) = (fieldDescs, parameter, initExpr, resourcePropertyName, xmlDoc);
                    /// <summary>Nesting fields; null if none.</summary>
                    public IReadOnlyList<FieldDescriptor> FieldDescs { get; }
                    public ParameterSyntax Parameter { get; }
                    public object InitExpr { get; }
                    public string ResourcePropertyName { get; }
                    public DocumentationCommentTriviaSyntax XmlDoc { get; }
                }

                public Signature(MethodDef def, MethodDetails.Signature sig) => (_def, _sig) = (def, sig);

                private readonly MethodDef _def;
                private readonly MethodDetails.Signature _sig;

                private SourceFileContext Ctx => _def.Ctx;
                private MethodDetails MethodDetails => _def.MethodDetails;

                private object InitExpr(MethodDetails.Signature.Field field, ParameterSyntax param, ResourceDetails.Field treatAsResource = null)
                {
                    // Type                  | Single optional | Single required | Repeated optional | Repeated required
                    // ----------------------|-----------------|-----------------|-------------------|------------------
                    // Primitive & enum      | nothing to do   | nothing to do   | null -> empty     | check not null
                    // string                | null -> ""      | check not empty | null -> empty     | check not null
                    // bytes                 | null -> byte[0] | check not null  | null -> empty     | check not null
                    // message               | null ok         | check not null  | null -> empty     | check not null
                    // resourcename (string) | null -> ""      | check not null  | null -> empty     | check not null
                    // resourcenames use the generated partial resource-name-type properties, which perform the string conversion.
                    if (field.IsMap)
                    {
                        return CollectionInitializer(field.IsRequired ?
                            Ctx.Type(typeof(GaxPreconditions)).Call(nameof(GaxPreconditions.CheckNotNull))(param, Nameof(param)) :
                            param.NullCoalesce(New(Ctx.Type(Typ.Generic(typeof(Dictionary<,>),
                                field.Typ.GenericArgTyps.First(), field.Typ.GenericArgTyps.ElementAt(1))))()));
                    }
                    else if (field.IsRepeated)
                    {
                        if (treatAsResource is object)
                        {
                            return CollectionInitializer(field.IsRequired ?
                                Ctx.Type(typeof(GaxPreconditions)).Call(nameof(GaxPreconditions.CheckNotNull))(param, Nameof(param)) :
                                param.NullCoalesce(Ctx.Type(typeof(Enumerable)).Call(
                                    nameof(Enumerable.Empty), Ctx.Type(treatAsResource.ResourceDefinition.ResourceNameTyp))()));
                        }
                        else
                        {
                            return CollectionInitializer(field.IsRequired ?
                                Ctx.Type(typeof(GaxPreconditions)).Call(nameof(GaxPreconditions.CheckNotNull))(param, Nameof(param)) :
                                param.NullCoalesce(Ctx.Type(typeof(Enumerable)).Call(nameof(Enumerable.Empty), Ctx.Type(field.Typ.GenericArgTyps.First()))()));
                        }
                    }
                    else
                    {
                        if (treatAsResource is object)
                        {
                            return field.IsRequired ?
                                Ctx.Type(typeof(GaxPreconditions)).Call(nameof(GaxPreconditions.CheckNotNull))(param, Nameof(param)) :
                                (object) param;
                        }
                        else if (field.Typ.IsPrimitive || field.Typ.IsEnum)
                        {
                            return param;
                        }
                        else if (field.Typ.FullName == typeof(string).FullName)
                        {
                            return field.IsRequired ?
                                Ctx.Type(typeof(GaxPreconditions)).Call(
                                    field.IsWrapperType ? nameof(GaxPreconditions.CheckNotNull) : nameof(GaxPreconditions.CheckNotNullOrEmpty))(
                                    param, Nameof(param)) :
                                field.IsWrapperType ? param : (object) param.NullCoalesce("");
                        }
                        else if (field.Typ.FullName == typeof(ByteString).FullName)
                        {
                            return field.IsRequired ?
                                Ctx.Type(typeof(GaxPreconditions)).Call(nameof(GaxPreconditions.CheckNotNull))(param, Nameof(param)) :
                                field.IsWrapperType ? param : (object) param.NullCoalesce(Ctx.Type<ByteString>().Access(nameof(ByteString.Empty)));
                        }
                        else if (field.IsWrapperType)
                        {
                            return field.IsRequired ?
                                param.NullCoalesce(Throw(New(Ctx.Type<ArgumentNullException>())(Nameof(param)))) :
                                (object) param;
                        }
                        else
                        {
                            return field.IsRequired ?
                                Ctx.Type(typeof(GaxPreconditions)).Call(nameof(GaxPreconditions.CheckNotNull))(param, Nameof(param)) :
                                (object) param;
                        }
                    }
                }

                private IEnumerable<ParameterInfo> Parameters => _sig.Fields.Select(field =>
                {
                    var parameter = Parameter(Ctx.Type(field.Typ), field.ParameterName);
                    var initExpr = InitExpr(field, parameter);
                    var xmlDoc = XmlDoc.ParamPreFormatted(parameter, field.DocLines);
                    return new ParameterInfo(field.Descs, parameter, initExpr, null, xmlDoc);
                });

                private IEnumerable<ParameterInfo> PaginatedParameters(IEnumerable<ParameterInfo> coreParameters)
                {
                    var pageTokenParameter = Parameter(Ctx.Type<string>(), "pageToken", @default: Null);
                    var pageTokenInit = new ObjectInitExpr("PageToken", pageTokenParameter.NullCoalesce(""));
                    var pageTokenXmlDoc = XmlDoc.Param(pageTokenParameter,
                        "The token returned from the previous request. A value of ", null, " or an empty string retrieves the first page.");
                    var pageSizeParameter = Parameter(Ctx.Type<int?>(), "pageSize", @default: Null);
                    var pageSizeInit = new ObjectInitExpr("PageSize", pageSizeParameter.NullCoalesce(0));
                    var pageSizeXmlDoc = XmlDoc.Param(pageSizeParameter,
                        "The size of page to request. The response will not be larger than this, but may be smaller. A value of ", null, " or ", 0, " uses a server-defined page size.");
                    return coreParameters
                        .Append(new ParameterInfo(null, pageTokenParameter, pageTokenInit, null, pageTokenXmlDoc))
                        .Append(new ParameterInfo(null, pageSizeParameter, pageSizeInit, null, pageSizeXmlDoc));
                }

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
                                .MaybeWithAttribute(MethodDetails.IsDeprecated || _sig.HasDeprecatedField, () => Ctx.Type<ObsoleteAttribute>())()
                                .WithBody(This.Call(methodName)(New(Ctx.Type(MethodDetails.RequestTyp))()
                                    .WithInitializer(NestInit(parameters, 0).ToArray()), finalParam))
                                .WithXmlDoc(parameters.Select(x => x.XmlDoc).Prepend(_def.SummaryXmlDoc).Append(finalParamXmlDoc).Append(returnsXmlDoc).ToArray());
                        IEnumerable<ObjectInitExpr> NestInit(IEnumerable<ParameterInfo> ps, int ofs)
                        {
                            var byField = ps.GroupBy(x => (x.FieldDescs ?? Enumerable.Empty<FieldDescriptor>()).Skip(ofs).SkipLast(1).FirstOrDefault())
                                .OrderBy(x => x.Key?.Index);
                            foreach (var f in byField)
                            {
                                if (f.Key == null)
                                {
                                    // No more nesting, these are the actual fields that need filling.
                                    foreach (var param in f.OrderBy(x => x.FieldDescs?.Last().Index ?? int.MaxValue))
                                    {
                                        // Note: even if the signature includes a deprecated field, we don't indicate that in the
                                        // ObjectInitExpr, as we don't want or need the pragma when the method we're generating is obsolete.
                                        yield return (param.InitExpr as ObjectInitExpr) ??
                                            new ObjectInitExpr(param.ResourcePropertyName ?? param.FieldDescs.Last().CSharpPropertyName(), param.InitExpr);
                                    }
                                }
                                else
                                {
                                    // Nested field.
                                    var code = New(Ctx.Type(ProtoTyp.Of(f.Key)))().WithInitializer(NestInit(f, ofs + 1).ToArray());
                                    yield return new ObjectInitExpr(f.Key.CSharpPropertyName(), code);
                                }
                            }
                        }
                    }
                    else
                    {
                        return Method(Public | Virtual, Ctx.Type(returnTyp), methodName)(parameters.Select(x => x.Parameter).Append(finalParam).ToArray())
                                .MaybeWithAttribute(MethodDetails.IsDeprecated || _sig.HasDeprecatedField, () => Ctx.Type<ObsoleteAttribute>())()
                                .WithBody(This.Call(methodName)(parameters.Select(x => (object) x.Parameter).Append(
                                    Ctx.Type<CallSettings>().Call(nameof(CallSettings.FromCancellationToken))(finalParam))))
                                    .WithXmlDoc(parameters.Select(x => x.XmlDoc).Prepend(_def.SummaryXmlDoc).Append(finalParamXmlDoc).Append(returnsXmlDoc).ToArray());
                    }
                }

                public bool HasHandWrittenEquivalent => _sig.HasHandwrittenEquivalent;
                public MethodDeclarationSyntax AbstractSyncRequestMethod => AbstractRequestMethod(true, true, Parameters);
                public MethodDeclarationSyntax AbstractAsyncCallSettingsRequestMethod => AbstractRequestMethod(false, true, Parameters);
                public MethodDeclarationSyntax AbstractAsyncCancellationTokenRequestMethod => AbstractRequestMethod(false, false, Parameters);

                public MethodDeclarationSyntax AbstractSyncPaginatedRequestMethod => AbstractRequestMethod(true, true, PaginatedParameters(Parameters));
                public MethodDeclarationSyntax AbstractAsyncPaginatedCallSettingsRequestMethod => AbstractRequestMethod(false, true, PaginatedParameters(Parameters));

                public MethodDeclarationSyntax AbstractServerStreamSyncRequestMethod => AbstractRequestMethod(true, true, Parameters, _def.ReturnsServerStreamingXmlDoc);

                public class ResourceName
                {
                    internal static IEnumerable<ResourceName> Create(Signature signature)
                    {
                        var ctx = signature.Ctx;
                        var fields = signature._sig.Fields;
                        if (!fields.Any(f => f.FieldResources is object))
                        {
                            return Enumerable.Empty<ResourceName>();
                        }
                        if (fields.Aggregate(1, (acc, f) => acc * (f.FieldResources?.Count ?? 1)) > 32)
                        {
                            throw new InvalidOperationException($"Cannot generate >32 overloads for method signature: '{signature._def.MethodDetails.SyncMethodName}'");
                        }
                        var allOverloads = fields.Aggregate(ImmutableList.Create(ImmutableList<ParameterInfo>.Empty), (overloads, f) =>
                        {
                            IEnumerable<ParameterInfo> paramInfos;
                            if (f.FieldResources is null)
                            {
                                var parameter = Parameter(ctx.Type(f.Typ), f.ParameterName);
                                var xmlDoc = XmlDoc.ParamPreFormatted(parameter, f.DocLines);
                                paramInfos = new[] { new ParameterInfo(f.Descs, parameter, signature.InitExpr(f, parameter), null, xmlDoc) };
                            }
                            else
                            {
                                paramInfos = f.FieldResources.Where(resDetails => resDetails.ContainsWildcard != false).Select(resDetails =>
                                {
                                    var typ = f.IsRepeated ? Typ.Generic(typeof(IEnumerable<>), resDetails.ResourceDefinition.ResourceNameTyp) : resDetails.ResourceDefinition.ResourceNameTyp;
                                    var parameter = Parameter(ctx.Type(typ), f.ParameterName);
                                    var xmlDoc = XmlDoc.ParamPreFormatted(parameter, f.DocLines);
                                    return new ParameterInfo(f.Descs, parameter, signature.InitExpr(f, parameter, resDetails), resDetails.ResourcePropertyName, xmlDoc);
                                }).ToList();
                            }
                            return overloads.SelectMany(overload => paramInfos.Select(paramInfo => overload.Add(paramInfo))).ToImmutableList();
                        });
                        return allOverloads.Select(parameters => new ResourceName(signature, parameters));
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

                    public MethodDeclarationSyntax AbstractSyncPaginatedRequestMethod => _signature.AbstractRequestMethod(true, true, _signature.PaginatedParameters(_parameters));
                    public MethodDeclarationSyntax AbstractAsyncPaginatedCallSettingsRequestMethod => _signature.AbstractRequestMethod(false, true, _signature.PaginatedParameters(_parameters));

                    public MethodDeclarationSyntax AbstractServerStreamSyncRequestMethod => _signature.AbstractRequestMethod(true, true, _parameters, _signature._def.ReturnsServerStreamingXmlDoc);
                }

                public IEnumerable<ResourceName> ResourceNames => ResourceName.Create(this);
            }

            /// <summary>
            /// Where hand-written equivalents are provided, we don't generate overloads in the client.
            /// </summary>
            public IEnumerable<Signature> SignaturesToGenerate => Signatures.Where(sig => !sig.HasHandWrittenEquivalent);

            public IEnumerable<Signature> Signatures => MethodDetails.Signatures.Select(sig => new Signature(this, sig));
        }
    }
}
