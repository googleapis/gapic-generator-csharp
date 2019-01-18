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
            public Normal(ServiceDetails svc, MethodDescriptor desc) : base(svc, desc) { }
            public override Typ SyncReturnTyp => ResponseTyp;
            public override Typ ApiCallTyp => Typ.Generic(typeof(ApiCall<,>), RequestTyp, ResponseTyp);
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
                _lroResponseTyp = Typ.Of(svc.Catalog.GetMessageByName(lroData.ResponseType));
                _lroMetadataTyp = Typ.Of(svc.Catalog.GetMessageByName(lroData.MetadataType));
                ApiCallTyp = Typ.Generic(typeof(ApiCall<,>), RequestTyp, Typ.Of<Operation>());
                SyncReturnTyp = Typ.Generic(typeof(Operation<,>), _lroResponseTyp, _lroMetadataTyp);
                LroSettingsName = $"{desc.Name}OperationsSettings";
                LroClientName = $"{desc.Name}OperationsClient";
                SyncPollMethodName = $"PollOnce{SyncMethodName}";
                AsyncPollMethodName = $"PollOnce{AsyncMethodName}";
            }
            private readonly Typ _lroResponseTyp;
            private readonly Typ _lroMetadataTyp;
            public override Typ ApiCallTyp { get; }
            public override Typ SyncReturnTyp { get; }
            public string LroSettingsName { get; }
            public string LroClientName { get; }
            public string SyncPollMethodName { get; }
            public string AsyncPollMethodName { get; }
            public Typ OperationTyp => SyncReturnTyp;
        }

        // TODO: Nested classes for other method types: paged, streaming, LRO, ...

        public static MethodDetails Create(ServiceDetails svc, MethodDescriptor desc) =>
            // TODO: Create correct class for the method type (paged, streaming, ...)
            desc.OutputType.FullName == "google.longrunning.Operation" ? new Lro(svc, desc) :
            (MethodDetails)new Normal(svc, desc);

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
