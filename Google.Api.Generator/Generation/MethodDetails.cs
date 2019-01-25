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
using Google.LongRunning;
using Google.Protobuf.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Google.Api.Generator.Generation
{
    /// <summary>
    /// Details of an RPC method within a proto-defined service.
    /// </summary>
    internal abstract class MethodDetails
    {
        /// <summary>
        /// Details about a "normal" method. I.e not paginated, streaming, LRO, ...
        /// </summary>
        public sealed class Normal : MethodDetails
        {
            public Normal(ServiceDetails svc, MethodDescriptor desc) : base(svc, desc) =>
                ApiCallTyp = Typ.Generic(typeof(ApiCall<,>), RequestTyp, ResponseTyp);
            public override Typ SyncReturnTyp => ResponseTyp;
            public override Typ ApiCallTyp { get; }
        }

        /// <summary>
        /// Details about a paginated method.
        /// </summary>
        public sealed class Paginated : MethodDetails
        {
            public Paginated(ServiceDetails svc, MethodDescriptor desc, FieldDescriptor responseResourceField) : base(svc, desc)
            {
                ResourceTyp = Typ.Of(responseResourceField, forceRepeated: false);
                ApiCallTyp = Typ.Generic(typeof(ApiCall<,>), RequestTyp, ResponseTyp);
                SyncReturnTyp = Typ.Generic(typeof(PagedEnumerable<,>), ResponseTyp, ResourceTyp);
                AsyncReturnTyp = Typ.Generic(typeof(PagedAsyncEnumerable<,>), ResponseTyp, ResourceTyp);
                SyncGrpcType = Typ.Generic(typeof(GrpcPagedEnumerable<,,>), RequestTyp, ResponseTyp, ResourceTyp);
                AsyncGrpcType = Typ.Generic(typeof(GrpcPagedAsyncEnumerable<,,>), RequestTyp, ResponseTyp, ResourceTyp);
                ResourcesFieldName = responseResourceField.CSharpName();
            }
            public override Typ ApiCallTyp { get; }
            public override Typ SyncReturnTyp { get; }
            public override Typ AsyncReturnTyp { get; }
            public Typ ResourceTyp { get; }
            public Typ SyncGrpcType { get; }
            public Typ AsyncGrpcType { get; }
            public string ResourcesFieldName { get; }
        }

        /// <summary>
        /// Details about an LRO method.
        /// </summary>
        public sealed class Lro : MethodDetails
        {
            public Lro(ServiceDetails svc, MethodDescriptor desc) : base(svc, desc)
            {
                if (!desc.CustomOptions.TryGetMessage<OperationData>(ProtoConsts.MethodOption.OperationTypes, out var lroData))
                {
                    throw new InvalidOperationException("LRO method must contain a `google.api.operation` option.");
                }
                ApiCallTyp = Typ.Generic(typeof(ApiCall<,>), RequestTyp, Typ.Of<Operation>());
                SyncReturnTyp = Typ.Generic(typeof(Operation<,>),
                    Typ.Of(svc.Catalog.GetMessageByName(lroData.ResponseType)),
                    Typ.Of(svc.Catalog.GetMessageByName(lroData.MetadataType)));
                LroSettingsName = $"{desc.Name}OperationsSettings";
                LroClientName = $"{desc.Name}OperationsClient";
                SyncPollMethodName = $"PollOnce{SyncMethodName}";
                AsyncPollMethodName = $"PollOnce{AsyncMethodName}";
            }
            public override Typ ApiCallTyp { get; }
            public override Typ SyncReturnTyp { get; }
            public string LroSettingsName { get; }
            public string LroClientName { get; }
            public string SyncPollMethodName { get; }
            public string AsyncPollMethodName { get; }
            public Typ OperationTyp => SyncReturnTyp;
        }

        public sealed class BidiStreaming : MethodDetails
        {
            public BidiStreaming(ServiceDetails svc, MethodDescriptor desc) : base(svc, desc)
            {
                ApiCallTyp = Typ.Generic(typeof(ApiBidirectionalStreamingCall<,>), RequestTyp, ResponseTyp);
                AbstractStreamTyp = Typ.Nested(svc.ClientAbstractTyp, $"{SyncMethodName}Stream");
                ImplStreamTyp = Typ.Nested(svc.ClientImplTyp, $"{SyncMethodName}StreamImpl");
                StreamingSettingsName = $"{desc.Name}StreamingSettings";
                ModifyStreamingCallSettingsMethodName = $"Modify_{RequestTyp.Name}CallSettings";
                ModifyStreamingRequestMethodName = $"Modify_{RequestTyp.Name}Request";
            }
            public override Typ ApiCallTyp { get; }
            public override Typ SyncReturnTyp => AbstractStreamTyp;
            public Typ AbstractStreamTyp { get; }
            public Typ ImplStreamTyp { get; }
            public string StreamingSettingsName { get; }
            public string ModifyStreamingCallSettingsMethodName { get; }
            public string ModifyStreamingRequestMethodName { get; }
        }

        public sealed class ServerStreaming : MethodDetails
        {
            public ServerStreaming(ServiceDetails svc, MethodDescriptor desc) : base(svc, desc)
            {
                ApiCallTyp = Typ.Generic(typeof(ApiServerStreamingCall<,>), RequestTyp, ResponseTyp);
                AbstractStreamTyp = Typ.Nested(svc.ClientAbstractTyp, $"{SyncMethodName}Stream");
                ImplStreamTyp = Typ.Nested(svc.ClientImplTyp, $"{SyncMethodName}StreamImpl");
            }
            public override Typ ApiCallTyp { get; }
            public override Typ SyncReturnTyp => AbstractStreamTyp;
            public Typ AbstractStreamTyp { get; }
            public Typ ImplStreamTyp { get; }
        }

        // TODO: Nested classes for other method types: paged, streaming, LRO, ...

        public static MethodDetails Create(ServiceDetails svc, MethodDescriptor desc) =>
            DetectPagination(svc, desc) ?? (
            desc.IsClientStreaming && desc.IsServerStreaming ? new BidiStreaming(svc, desc) :
            desc.IsServerStreaming ? new ServerStreaming(svc, desc) :
            desc.OutputType.FullName == "google.longrunning.Operation" ? new Lro(svc, desc) :
            (MethodDetails)new Normal(svc, desc));

        private static MethodDetails DetectPagination(ServiceDetails svc, MethodDescriptor desc)
        {
            var input = desc.InputType;
            var output = desc.OutputType;
            var pageSize = input.FindFieldByName("page_size");
            var pageToken = input.FindFieldByName("page_token");
            var nextPageToken = output.FindFieldByName("next_page_token");
            var items = output.Fields.InDeclarationOrder().Where(field =>
            {
                // TODO: Add support for "items" annotation when it is available
                return field.IsRepeated;
            }).ToList();
            if (pageSize != null && pageToken != null && nextPageToken != null && items.Count > 0)
            {
                if (pageSize.FieldType != FieldType.Int32)
                {
                    throw new InvalidOperationException("page_size must be of type int32");
                }
                if (pageToken.FieldType != FieldType.String)
                {
                    throw new InvalidOperationException("page_token must be of type string");
                }
                if (nextPageToken.FieldType != FieldType.String)
                {
                    throw new InvalidOperationException("next_page_token must be of type string");
                }
                if (items.Count > 1)
                {
                    throw new InvalidOperationException("Ambiguous item responces");
                }
                return new Paginated(svc, desc, items[0]);
            }
            return null;
        }

        private MethodDetails(ServiceDetails svc, MethodDescriptor desc)
        {
            Svc = svc;
            SyncMethodName = desc.Name;
            AsyncMethodName = $"{desc.Name}Async";
            SettingsName = $"{desc.Name}Settings";
            RequestTyp = Typ.Of(desc.InputType);
            ResponseTyp = Typ.Of(desc.OutputType);
            ApiCallFieldName = $"_call{desc.Name}";
            ModifyApiCallMethodName = $"Modify_{desc.Name}ApiCall";
            ModifyRequestMethodName = $"Modify_{RequestTyp.Name}";
            // Assume HTTP GET methods are idempotent; all others are non-idempotent.
            IsIdempotent = desc.CustomOptions.TryGetMessage<HttpRule>(
                ProtoConsts.MethodOption.HttpRule, out var http) ? !string.IsNullOrEmpty(http.Get) : false;
            DocLines = desc.Declaration.DocLines().ToList();
        }

        /// <summary>The service in which this method is defined.</summary>
        public ServiceDetails Svc { get; }

        /// <summary>The sync name for this method.</summary>
        public string SyncMethodName { get; }

        /// <summary>The async name for this method.</summary>
        public string AsyncMethodName { get; }

        /// <summary>The per-method settings property name.</summary>
        public string SettingsName { get; }

        /// <summary>The typ of the method request.</summary>
        public Typ RequestTyp { get; }

        /// <summary>The typ of the method response.</summary>
        public Typ ResponseTyp { get; }

        /// <summary>The sync return typ for this method.</summary>
        public abstract Typ SyncReturnTyp { get; }

        /// <summary>The async return typ for this method.</summary>
        public virtual Typ AsyncReturnTyp => Typ.Generic(typeof(Task<>), SyncReturnTyp);

        /// <summary>The Gax ApiCall<> typ for this method.</summary>
        public abstract Typ ApiCallTyp { get; }

        /// <summary>The name of the ApiCall<> field.</summary>
        public string ApiCallFieldName { get; }

        /// <summary>The name of the per-method partial method to modify the ApiCall.</summary>
        public string ModifyApiCallMethodName { get; }

        /// <summary>The name of the per-request-type partial method to modify the request.</summary>
        public string ModifyRequestMethodName { get; }

        /// <summary>Is this method idempotent?</summary>
        public bool IsIdempotent { get; }

        /// <summary>The lines of method documentation from the proto.</summary>
        public IEnumerable<string> DocLines { get; }
    }
}
