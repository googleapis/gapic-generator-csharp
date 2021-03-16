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
using Grpc.Core;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Moq;
using Moq.Language;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Google.Api.Generator.Utils.Roslyn.Modifier;
using static Google.Api.Generator.Utils.Roslyn.RoslynBuilder;

namespace Google.Api.Generator.Generation
{
    internal class UnitTestCodeGeneration
    {
        public static CompilationUnitSyntax Generate(SourceFileContext ctx, ServiceDetails svc) =>
            new UnitTestCodeGeneration(ctx, svc).Generate();

        private UnitTestCodeGeneration(SourceFileContext ctx, ServiceDetails svc) => (_ctx, _svc) = (ctx, svc);

        private readonly SourceFileContext _ctx;
        private readonly ServiceDetails _svc;

        private CompilationUnitSyntax Generate()
        {
            var ns = Namespace(_svc.UnitTestsNamespace);
            using (_ctx.InNamespace(ns))
            {
                var cls = Class(Public | Sealed, _svc.UnitTestsTyp).WithXmlDoc(XmlDoc.Summary("Generated unit tests."));
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
                // TODO: Test of non-"normal" methods. E.g. LRO.
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
                }
            }
        }

        private class MethodDef
        {
            private static MD5 s_md5 = MD5.Create();

            public MethodDef(SourceFileContext ctx, ServiceDetails svc, MethodDetails method) =>
                (Ctx, Svc, Method) = (ctx, svc, method);

            private SourceFileContext Ctx { get; }
            private ServiceDetails Svc { get; }
            private MethodDetails Method { get; }

            private LocalDeclarationStatementSyntax MockGrpcClient => Local(Ctx.Type(Typ.Generic(typeof(Mock<>), Svc.GrpcClientTyp)), "mockGrpcClient");
            private LocalDeclarationStatementSyntax Client => Local(Ctx.Type(Svc.ClientAbstractTyp), "client");
            private LocalDeclarationStatementSyntax Request => Local(Ctx.Type(Method.RequestTyp), "request");
            private LocalDeclarationStatementSyntax ExpectedResponse => Local(Ctx.Type(Method.ResponseTyp), "expectedResponse");
            private LocalDeclarationStatementSyntax Response => Local(Ctx.Type(Method.ResponseTyp), "response");
            private LocalDeclarationStatementSyntax ResponseCallSettings => Local(Ctx.Type(Method.ResponseTyp), "responseCallSettings");
            private LocalDeclarationStatementSyntax ResponseCancellationToken => Local(Ctx.Type(Method.ResponseTyp), "responseCancellationToken");

            private ParameterSyntax X => Parameter(null, "x");

            private object TestValue(FieldDescriptor fieldDesc)
            {
                var resources = Svc.Catalog.GetResourceDetailsByField(fieldDesc);
                if (resources is object)
                {
                    var def = resources[0].ResourceDefinition;
                    var pattern = def.Patterns.FirstOrDefault(x => !x.IsWildcard);
                    object value = pattern is null ?
                        (object)New(Ctx.Type<UnparsedResourceName>())("a/wildcard/resource") :
                        Ctx.Type(def.ResourceNameTyp).Call(FactoryMethodName(pattern))
                                (pattern.Template.ParameterNames.Select(x => $"[{x.ToUpperInvariant()}]"));
                    return fieldDesc.IsRepeated ? CollectionInitializer(value) : value;
                }
                else
                {
                    if (fieldDesc.IsMap)
                    {
                        // A map is modelled as a repeated message containing key/value fields.
                        var parts = fieldDesc.MessageType.Fields.InFieldNumberOrder();
                        var keyValue = TestValue(parts[0]);
                        var valueValue = TestValue(parts[1]);
                        return CollectionInitializer(ComplexElementInitializer(keyValue, valueValue));
                    }
                    // See https://developers.google.com/protocol-buffers/docs/proto3#scalar
                    // Switch cases are ordered as in this doc. Please do not re-order.
                    object value = fieldDesc.FieldType switch
                    {
                        FieldType.Double => Double(),
                        FieldType.Float => (float)Double(),
                        FieldType.Int32 => Int(),
                        FieldType.Int64 => Long(),
                        FieldType.UInt32 => (uint)Int(),
                        FieldType.UInt64 => (ulong)Long(),
                        FieldType.SInt32 => Int(),
                        FieldType.SInt64 => Long(),
                        FieldType.Fixed32 => (uint)Int(),
                        FieldType.Fixed64 => (ulong)Long(),
                        FieldType.SFixed32 => Int(),
                        FieldType.SFixed64 => Long(),
                        FieldType.Bool => Int() >= 0,
                        FieldType.String => String(),
                        FieldType.Bytes => Ctx.Type<ByteString>().Call(nameof(ByteString.CopyFromUtf8))(String()),
                        FieldType.Message => fieldDesc.MessageType.FullName switch
                        {
                            "google.protobuf.DoubleValue" => Double(),
                            "google.protobuf.FloatValue" => (float)Double(),
                            "google.protobuf.Int64Value" => Long(),
                            "google.protobuf.UInt64Value" => (ulong)Long(),
                            "google.protobuf.Int32Value" => Int(),
                            "google.protobuf.UInt32Value" => (uint)Int(),
                            "google.protobuf.BoolValue" => Int() >= 0,
                            "google.protobuf.StringValue" => String(),
                            "google.protobuf.BytesValue" => Ctx.Type<ByteString>().Call(nameof(ByteString.CopyFromUtf8))(String()),
                            _ => New(Ctx.Type(ProtoTyp.Of(fieldDesc.MessageType)))()
                        },
                        FieldType.Enum => Ctx.Type(ProtoTyp.Of(fieldDesc.EnumType)).Access(fieldDesc.EnumType.Values[Math.Abs(Int()) % fieldDesc.EnumType.Values.Count].CSharpName()),
                        _ => throw new InvalidOperationException($"Cannot generate test value for proto type: {fieldDesc.FieldType}"),
                    };
                    return fieldDesc.IsRepeated ? CollectionInitializer(value) : value;
                }

                // Generate deterministic values, based on the field name.
                byte[] FieldHash() => s_md5.ComputeHash(Encoding.UTF8.GetBytes(fieldDesc.Name));
                int Int() => BitConverter.ToInt32(FieldHash());
                long Long() => BitConverter.ToInt64(FieldHash());
                double Double() => ((double)Long()) / 8;
                string String() => $"{fieldDesc.Name}{Int():x8}";

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

            private IEnumerable<ObjectInitExpr> InitMessage(MessageDescriptor msgDesc, IEnumerable<MethodDetails.Signature.Field> onlyFields, int fieldDepth = 0)
            {
                if (onlyFields is null)
                {
                    // Generate all the non-paginated fields.
                    foreach (var fieldDesc in msgDesc.Fields.InFieldNumberOrder())
                    {
                        if (!IsPaginationField(fieldDesc))
                        {
                            var resourceField = Svc.Catalog.GetResourceDetailsByField(fieldDesc);
                            yield return new ObjectInitExpr(
                                resourceField?[0].ResourcePropertyName ?? fieldDesc.CSharpPropertyName(),
                                TestValue(fieldDesc), isDeprecated: fieldDesc.IsDeprecated());
                        }
                    }
                }
                else
                {
                    // Find all the field paths (x.y.z) which start with the same field.
                    // So for a signature with "x.y1.z1", "x.y1.z2", "x.y2", "abc",
                    // we'd get groups of { "x.y1.z1", "x.y1.z2", "x.y2" } and { "abc" }.
                    // We'd then create two initialization expressions: one for x (recursing to populate y1 and y2) and one for abc.
                    foreach (var fieldGroup in onlyFields.GroupBy(path => path.Descs[fieldDepth]).OrderBy(group => group.Key.FieldNumber))
                    {
                        var fieldDesc = fieldGroup.Key;
                        if (IsPaginationField(fieldDesc))
                        {
                            continue;
                        }
                        var resourceField = Svc.Catalog.GetResourceDetailsByField(fieldDesc);
                        var propertyName = resourceField?[0].ResourcePropertyName ?? fieldDesc.CSharpPropertyName();
                        // If we've reached the end of the path, just yield a single value.
                        if (fieldGroup.Count() == 1 && fieldGroup.Single().Descs.Count == fieldDepth + 1)
                        {
                            yield return new ObjectInitExpr(
                                propertyName,
                                TestValue(fieldDesc), isDeprecated: fieldDesc.IsDeprecated());
                        }
                        // Otherwise, create a new message, populated by all the fields.
                        else
                        {
                            yield return new ObjectInitExpr(
                                propertyName,
                                New(Ctx.Type(ProtoTyp.Of(fieldDesc.MessageType)))()
                                    .WithInitializer(InitMessage(fieldDesc.MessageType, fieldGroup, fieldDepth + 1).ToArray()));
                        }
                    }
                }

                bool IsPaginationField(FieldDescriptor fieldDesc) => Method is MethodDetails.Paginated paged &&
                    (fieldDesc.FieldNumber == paged.PageSizeFieldNumber || fieldDesc.FieldNumber == paged.PageTokenFieldNumber);
            }

            private IEnumerable<object> LroSetup()
            {
                if (Svc.Methods.Any(x => x is MethodDetails.Lro))
                {
                    yield return MockGrpcClient.Call(nameof(Mock<string>.Setup))(Lambda(X)(X.Call("CreateOperationsClient")()))
                        .Call(nameof(IReturns<string, int>.Returns))(New(Ctx.Type<Mock<Operations.OperationsClient>>())().Access(nameof(Mock.Object)));
                }
            }

            private MethodDeclarationSyntax Sync(string methodName, IEnumerable<MethodDetails.Signature.Field> requestFields, object requestMethodArgs)
            {
                var callAndVerify = Method.SyncReturnTyp is Typ.VoidTyp ?
                    new object[]
                    {
                        Client.Call(Method.SyncMethodName)(requestMethodArgs),
                    } :
                    new object[]
                    {
                        Response.WithInitializer(Client.Call(Method.SyncMethodName)(requestMethodArgs)),
                        Ctx.Type<Assert>().Call(nameof(Assert.Same))(ExpectedResponse, Response),
                    };
                return Method(Public, VoidType, methodName)()
                    .WithAttribute(Ctx.Type<FactAttribute>())()
                    .WithBody(
                        MockGrpcClient.WithInitializer(New(Ctx.Type(Typ.Generic(typeof(Mock<>), Svc.GrpcClientTyp)))(Ctx.Type<MockBehavior>().Access(MockBehavior.Strict))),
                        LroSetup(),
                        Request.WithInitializer(New(Ctx.Type(Method.RequestTyp))().WithInitializer(InitMessage(Method.RequestMessageDesc, requestFields).ToArray())),
                        ExpectedResponse.WithInitializer(New(Ctx.Type(Method.ResponseTyp))().WithInitializer(InitMessage(Method.ResponseMessageDesc, null).ToArray())),
                        MockGrpcClient.Call(nameof(Mock<string>.Setup))(
                            Lambda(X)(X.Call(Method.SyncMethodName)(Request, Ctx.Type(typeof(It)).Call(nameof(It.IsAny), Ctx.Type<CallOptions>())())))
                            .Call(nameof(IReturns<string, int>.Returns))(ExpectedResponse),
                        Client.WithInitializer(New(Ctx.Type(Svc.ClientImplTyp))(MockGrpcClient.Access(nameof(Mock.Object)), Null)),
                        callAndVerify,
                        MockGrpcClient.Call(nameof(Mock.VerifyAll))()
                    );
            }

            private MethodDeclarationSyntax Async(string methodName, IEnumerable<MethodDetails.Signature.Field> requestFields, object requestMethodArgs)
            {
                var callAndVerify = Method.SyncReturnTyp is Typ.VoidTyp ?
                    new object[]
                    {
                        Await(Client.Call(Method.AsyncMethodName)(requestMethodArgs,
                            Ctx.Type<CallSettings>().Call(nameof(CallSettings.FromCancellationToken))(Ctx.Type<CancellationToken>().Access(nameof(CancellationToken.None))))),
                        Await(Client.Call(Method.AsyncMethodName)(requestMethodArgs,
                            Ctx.Type<CancellationToken>().Access(nameof(CancellationToken.None)))),
                    } :
                    new object[]
                    {
                        ResponseCallSettings.WithInitializer(Await(Client.Call(Method.AsyncMethodName)(requestMethodArgs,
                            Ctx.Type<CallSettings>().Call(nameof(CallSettings.FromCancellationToken))(Ctx.Type<CancellationToken>().Access(nameof(CancellationToken.None)))))),
                        Ctx.Type<Assert>().Call(nameof(Assert.Same))(ExpectedResponse, ResponseCallSettings),
                        ResponseCancellationToken.WithInitializer(Await(Client.Call(Method.AsyncMethodName)(requestMethodArgs,
                            Ctx.Type<CancellationToken>().Access(nameof(CancellationToken.None))))),
                        Ctx.Type<Assert>().Call(nameof(Assert.Same))(ExpectedResponse, ResponseCancellationToken),
                    };
                return Method(Public | Modifier.Async, Ctx.Type<Task>(), methodName)()
                    .WithAttribute(Ctx.Type<FactAttribute>())()
                    .WithBody(
                        MockGrpcClient.WithInitializer(New(Ctx.Type(Typ.Generic(typeof(Mock<>), Svc.GrpcClientTyp)))(Ctx.Type<MockBehavior>().Access(MockBehavior.Strict))),
                        LroSetup(),
                        Request.WithInitializer(New(Ctx.Type(Method.RequestTyp))().WithInitializer(InitMessage(Method.RequestMessageDesc, requestFields).ToArray())),
                        ExpectedResponse.WithInitializer(New(Ctx.Type(Method.ResponseTyp))().WithInitializer(InitMessage(Method.ResponseMessageDesc, null).ToArray())),
                        MockGrpcClient.Call(nameof(Mock<string>.Setup))(
                            Lambda(X)(X.Call(Method.AsyncMethodName)(Request, Ctx.Type(typeof(It)).Call(nameof(It.IsAny), Ctx.Type<CallOptions>())())))
                            .Call(nameof(IReturns<string, int>.Returns))(New(Ctx.Type(Typ.Generic(typeof(AsyncUnaryCall<>), Method.ResponseTyp)))(
                                Ctx.Type<Task>().Call(nameof(Task.FromResult))(ExpectedResponse), Null, Null, Null, Null)),
                        Client.WithInitializer(New(Ctx.Type(Svc.ClientImplTyp))(MockGrpcClient.Access(nameof(Mock.Object)), Null)),
                        callAndVerify,
                        MockGrpcClient.Call(nameof(Mock.VerifyAll))()
                    );
            }

            public MethodDeclarationSyntax SyncRequestMethod => Sync(Method.SyncTestMethodName, null, Request);

            public MethodDeclarationSyntax AsyncRequestMethod => Async(Method.AsyncTestMethodName, null, Request);

            public class Signature
            {
                public Signature(MethodDef def, MethodDetails.Signature sig, int? index) => (_def, _sig, _index) = (def, sig, index);

                private readonly MethodDef _def;
                private readonly MethodDetails.Signature _sig;
                private readonly int? _index;

                private MethodDetails Method => _def.Method;

                private string SyncMethodName => Method.SyncMethodName + (_index is int index ? (index + 1).ToString() : "");
                private string AsyncMethodName => $"{Method.AsyncMethodName.Substring(0, Method.AsyncMethodName.Length - 5)}{(_index is int index ? (index + 1).ToString() : "")}Async";

                private ExpressionSyntax Access(MemberAccessExpressionSyntax access, bool isDeprecated)
                {
                    if (isDeprecated)
                    {
                        access = access.WithName(access.Name.WithIdentifier(access.Name.Identifier.WithPragmaWarning(PragmaWarnings.Obsolete)));
                    }
                    return access;
                }

                private IEnumerable<object> SigArgs => _sig.Fields.Select(field => Access(
                    // Generate code to access the correct property, including nesting.
                    // field.Descs contains all proto FieldDescriptors from outermost to most-nested field, so aggregate Access(...)
                    // from the request proto (_def.Request) through all nesting fields.
                    // Note that often there will be no nested, so the aggregation will not be used. In this case
                    // this code is equivilent to: _def.Request.Access(field.Descs.First().CSharpPropertyName());
                    // i.e. access the required field within the request object.
                    field.Descs
                        .Skip(1)
                        .Aggregate(
                            _def.Request.Access(field.Descs.First().CSharpPropertyName()),
                            (acc, desc) => (MemberAccessExpressionSyntax)acc.Access(desc.CSharpPropertyName())),
                    field.IsDeprecated));

                public MethodDeclarationSyntax SyncMethod => _def.Sync(SyncMethodName, _sig.Fields, SigArgs);

                public MethodDeclarationSyntax AsyncMethod => _def.Async(AsyncMethodName, _sig.Fields, SigArgs);

                public class ResourceName
                {
                    public static IEnumerable<ResourceName> Create(Signature sig)
                    {
                        if (!sig._sig.Fields.Any(f => f.FieldResources is object))
                        {
                            return Enumerable.Empty<ResourceName>();
                        }
                        var allOverloads = sig._sig.Fields.Aggregate(ImmutableList.Create(ImmutableList<(string, bool)>.Empty), (overloads, f) =>
                        {
                            var names = f.FieldResources is null ? new[] { (f.PropertyName, f.IsDeprecated) }
                                : f.FieldResources.Where(resDetails => resDetails.ContainsWildcard != false).Select(x => (x.ResourcePropertyName, false));
                            return overloads.SelectMany(overload => names.Select(name => overload.Add(name))).ToImmutableList();
                        }).ToList();
                        return allOverloads.Select((properties, index) => new ResourceName(sig, properties, allOverloads.Count > 1 ? (int?)(index + 1) : null));
                    }

                    private ResourceName(Signature sig, IReadOnlyList<(string, bool)> properties, int? index) => (_sig, _properties, _index) = (sig, properties, index);

                    private readonly Signature _sig;
                    private readonly IReadOnlyList<(string name, bool isDeprecated)> _properties;
                    private readonly int? _index;
                    private string SyncMethodName => $"{_sig.SyncMethodName}ResourceNames{(_index?.ToString() ?? "")}";
                    private string AsyncMethodName => $"{SyncMethodName}Async";

                    public MethodDeclarationSyntax SyncMethod => _sig._def.Sync(SyncMethodName, _sig._sig.Fields,
                        _properties.Select(property => _sig.Access(_sig._def.Request.Access(property.name), property.isDeprecated)));

                    public MethodDeclarationSyntax AsyncMethod => _sig._def.Async(AsyncMethodName, _sig._sig.Fields,
                        _properties.Select(property => _sig.Access(_sig._def.Request.Access(property.name), property.isDeprecated)));
                }

                public IEnumerable<ResourceName> ResourceNames => ResourceName.Create(this);
            }

            public IEnumerable<Signature> Signatures => Method.Signatures.Select((sig, i) => new Signature(this, sig, Method.Signatures.Count > 1 ? i : (int?)null));
        }
    }
}
