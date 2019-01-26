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
                    public DocumentationCommentTriviaSyntax XmlDoc { get; }//TODO
                }

                public Signature(MethodDef def, MethodDetails.Signature sig) => (_def, _sig) = (def, sig);

                private MethodDef _def;
                private MethodDetails.Signature _sig;

                private SourceFileContext Ctx => _def.Ctx;
                private MethodDetails MethodDetails => _def.MethodDetails;

                private ObjectInitExpr InitExpr(MethodDetails.Signature.Field field, ParameterSyntax param)
                {
                    // Type                  | Single optional | Single required | Repeated optional | Repeated required
                    // ----------------------|-----------------|-----------------|-------------------|------------------
                    // Primitive             | nothing to do   | nothing to do   | null -> empty     | check not null
                    // string                | null -> ""      | check not empty | null -> empty     | check not null
                    // bytes                 | null -> byte[0] | check not null  | null -> empty     | check not null
                    // message               | null ok         | check not null  | null -> empty     | check not null
                    // resourcename (string) | null -> ""      | check not empty | null -> empty     | check not null
                    object code;
                    if ($"{field.Typ.Namespace}.{field.Typ.Name}`1" == typeof(IEnumerable<>).FullName)
                    {
                        // Repeated
                        code = CollectionInitializer(field.Required ?
                            Ctx.Type(typeof(GaxPreconditions)).Call(nameof(GaxPreconditions.CheckNotNull))(param, Nameof(param)) :
                            param.NullCoalesce(Ctx.Type(typeof(Enumerable)).Call(nameof(Enumerable.Empty), Ctx.Type(field.Typ.GenericArgTyps.First()))()));

                    }
                    else
                    {
                        // Single (not repeated)
                        if (field.Typ.IsPrimitive)
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
                        // TODO: Resource-names.
                    }
                    return new ObjectInitExpr(field.PropertyName, code);
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

                public MethodDeclarationSyntax AbstractSyncRequestMethod =>
                    Method(Public | Virtual, Ctx.Type(MethodDetails.SyncReturnTyp), MethodDetails.SyncMethodName)(ParametersWithCallSettings.ToArray())
                        .WithBody(This.Call(MethodDetails.SyncMethodName)(New(Ctx.Type(MethodDetails.RequestTyp))()
                            .WithInitializer(Parameters.Select(x => x.InitExpr).ToArray()), _def.CallSettingsParam))
                            .WithXmlDoc(Parameters.Select(p => p.XmlDoc).Prepend(_def.SummaryXmlDoc).Append(_def.CallSettingsXmlDoc).Append(_def.ReturnsSyncXmlDoc).ToArray());

                public MethodDeclarationSyntax AbstractAsyncCallSettingsRequestMethod =>
                    Method(Public | Virtual, Ctx.Type(MethodDetails.AsyncReturnTyp), MethodDetails.AsyncMethodName)(ParametersWithCallSettings.ToArray())
                        .WithBody(This.Call(MethodDetails.AsyncMethodName)(New(Ctx.Type(MethodDetails.RequestTyp))()
                            .WithInitializer(Parameters.Select(x => x.InitExpr).ToArray()), _def.CallSettingsParam))
                            .WithXmlDoc(Parameters.Select(p => p.XmlDoc).Prepend(_def.SummaryXmlDoc).Append(_def.CallSettingsXmlDoc).Append(_def.ReturnsAsyncXmlDoc).ToArray());

                public MethodDeclarationSyntax AbstractAsyncCancellationTokenRequestMethod =>
                    Method(Public | Virtual, Ctx.Type(MethodDetails.AsyncReturnTyp), MethodDetails.AsyncMethodName)(ParametersWithCancellationToken.ToArray())
                        .WithBody(This.Call(MethodDetails.AsyncMethodName)(Parameters.Select(x => (object)x.Parameter).Append(
                            Ctx.Type<CallSettings>().Call(nameof(CallSettings.FromCancellationToken))(_def.CancellationTokenParam))))
                        .WithXmlDoc(Parameters.Select(p => p.XmlDoc).Prepend(_def.SummaryXmlDoc).Append(_def.CancellationTokenXmlDoc).Append(_def.ReturnsAsyncXmlDoc).ToArray());
            }

            public IEnumerable<Signature> Signatures => MethodDetails.Signatures.Select(sig => new Signature(this, sig));
        }
    }
}
