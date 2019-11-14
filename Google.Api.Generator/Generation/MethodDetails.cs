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
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net;
using System.Text;
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
            public Normal(ServiceDetails svc, MethodDescriptor desc) : base(svc, desc)
            {
                ApiCallTyp = Typ.Generic(typeof(ApiCall<,>), RequestTyp, ResponseTyp);
                SyncReturnTyp = ResponseTyp.FullName == typeof(Empty).FullName ? Typ.Void : ResponseTyp;
            }
            public override Typ SyncReturnTyp { get; }
            public override Typ ApiCallTyp { get; }
        }

        /// <summary>
        /// Details about a paginated method.
        /// </summary>
        public sealed class Paginated : MethodDetails
        {
            public Paginated(ServiceDetails svc, MethodDescriptor desc,
                FieldDescriptor responseResourceField, int pageSizeFieldNumber, int pageTokenFieldNumber) : base(svc, desc)
            {
                var resourceDetails = svc.Catalog.GetResourceDetailsByField(responseResourceField);
                if (resourceDetails is null)
                {
                    ResourceTyp = Typ.Of(responseResourceField, forceRepeated: false);
                }
                else
                {
                    var resourceDef = resourceDetails.ResourceDefinition;
                    if (resourceDef.Single != null && resourceDef.Multi != null)
                    {
                        // TODO: Figure out what to do in this situation.
                        throw new InvalidOperationException("Cannot handle pagination when the resource type is both a single and multi resource-name.");
                    }
                    ResourceTyp = resourceDef.Single?.ResourceNameTyp ?? resourceDef.Multi.ContainerTyp;
                }
                ApiCallTyp = Typ.Generic(typeof(ApiCall<,>), RequestTyp, ResponseTyp);
                SyncReturnTyp = Typ.Generic(typeof(PagedEnumerable<,>), ResponseTyp, ResourceTyp);
                AsyncReturnTyp = Typ.Generic(typeof(PagedAsyncEnumerable<,>), ResponseTyp, ResourceTyp);
                SyncGrpcType = Typ.Generic(typeof(GrpcPagedEnumerable<,,>), RequestTyp, ResponseTyp, ResourceTyp);
                AsyncGrpcType = Typ.Generic(typeof(GrpcPagedAsyncEnumerable<,,>), RequestTyp, ResponseTyp, ResourceTyp);
                ResourcesFieldName = responseResourceField.CSharpPropertyName();
                ResourcesFieldResourceName = svc.Catalog.GetResourceDetailsByField(responseResourceField);
                PageSizeFieldNumber = pageSizeFieldNumber;
                PageTokenFieldNumber = pageTokenFieldNumber;
            }
            public override Typ ApiCallTyp { get; }
            public override Typ SyncReturnTyp { get; }
            public override Typ AsyncReturnTyp { get; }
            public Typ ResourceTyp { get; }
            public Typ SyncGrpcType { get; }
            public Typ AsyncGrpcType { get; }
            public string ResourcesFieldName { get; }
            public ResourceDetails.Field ResourcesFieldResourceName { get; }
            public int PageSizeFieldNumber { get; }
            public int PageTokenFieldNumber { get; }
        }

        /// <summary>
        /// Details about an LRO method.
        /// </summary>
        public sealed class Lro : MethodDetails
        {
            public Lro(ServiceDetails svc, MethodDescriptor desc) : base(svc, desc)
            {
                if (!desc.CustomOptions.TryGetMessage<OperationInfo>(ProtoConsts.MethodOption.OperationInfo, out var lroData))
                {
                    throw new InvalidOperationException("LRO method must contain a `google.api.operation` option.");
                }
                ApiCallTyp = Typ.Generic(typeof(ApiCall<,>), RequestTyp, Typ.Of<Operation>());
                OperationResponseTyp = Typ.Of(svc.Catalog.GetMessageByName(lroData.ResponseType));
                OperationMetadataTyp = Typ.Of(svc.Catalog.GetMessageByName(lroData.MetadataType));
                SyncReturnTyp = Typ.Generic(typeof(Operation<,>), OperationResponseTyp, OperationMetadataTyp);
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
            public Typ OperationResponseTyp { get; }
            public Typ OperationMetadataTyp { get; }
        }

        public interface IStreaming
        {
            Typ AsyncEnumeratorTyp { get; }
        }

        public sealed class BidiStreaming : MethodDetails, IStreaming
        {
            public BidiStreaming(ServiceDetails svc, MethodDescriptor desc) : base(svc, desc)
            {
                ApiCallTyp = Typ.Generic(typeof(ApiBidirectionalStreamingCall<,>), RequestTyp, ResponseTyp);
                AbstractStreamTyp = Typ.Nested(svc.ClientAbstractTyp, $"{SyncMethodName}Stream");
                ImplStreamTyp = Typ.Nested(svc.ClientImplTyp, $"{SyncMethodName}StreamImpl");
                StreamingSettingsName = $"{desc.Name}StreamingSettings";
                ModifyStreamingCallSettingsMethodName = $"Modify_{RequestTyp.Name}CallSettings";
                ModifyStreamingRequestMethodName = $"Modify_{RequestTyp.Name}Request";
                AsyncEnumeratorTyp = Typ.Generic(typeof(AsyncResponseStream<>), ResponseTyp);
            }
            public override Typ ApiCallTyp { get; }
            public override Typ SyncReturnTyp => AbstractStreamTyp;
            public Typ AbstractStreamTyp { get; }
            public Typ ImplStreamTyp { get; }
            public string StreamingSettingsName { get; }
            public string ModifyStreamingCallSettingsMethodName { get; }
            public string ModifyStreamingRequestMethodName { get; }
            public Typ AsyncEnumeratorTyp { get; }
        }

        public sealed class ServerStreaming : MethodDetails, IStreaming
        {
            public ServerStreaming(ServiceDetails svc, MethodDescriptor desc) : base(svc, desc)
            {
                ApiCallTyp = Typ.Generic(typeof(ApiServerStreamingCall<,>), RequestTyp, ResponseTyp);
                AbstractStreamTyp = Typ.Nested(svc.ClientAbstractTyp, $"{SyncMethodName}Stream");
                ImplStreamTyp = Typ.Nested(svc.ClientImplTyp, $"{SyncMethodName}StreamImpl");
                AsyncEnumeratorTyp = Typ.Generic(typeof(AsyncResponseStream<>), ResponseTyp);
            }
            public override Typ ApiCallTyp { get; }
            public override Typ SyncReturnTyp => AbstractStreamTyp;
            public Typ AbstractStreamTyp { get; }
            public Typ ImplStreamTyp { get; }
            public Typ AsyncEnumeratorTyp { get; }
        }

        public sealed class Signature
        {
            public sealed class Field
            {
                public Field(ServiceDetails svc, MessageDescriptor msg, string fieldName)
                {
                    Descs = fieldName.Split('.').Aggregate((msg, result: ImmutableList<FieldDescriptor>.Empty), (acc, part) =>
                    {
                        // TODO: Check nested fields aren't repeated.
                        var fieldDesc = acc.msg.FindFieldByName(part);
                        if (fieldDesc == null)
                        {
                            throw new InvalidOperationException($"Field '{part}' does not exist in message: {acc.msg.FullName}");
                        }
                        return (fieldDesc.FieldType == FieldType.Message ? fieldDesc.MessageType : null, acc.result.Add(fieldDesc));
                    }, acc => acc.result);
                    var lastDesc = Descs.Last();
                    Typ = Typ.Of(lastDesc);
                    IsRepeated = lastDesc.IsRepeated;
                    IsWrapperType = Typ.IsWrapperType(lastDesc);
                    IsRequired = lastDesc.CustomOptions.TryGetRepeatedEnum<FieldBehavior>(ProtoConsts.FieldOption.FieldBehavior, out var behaviors) &&
                        behaviors.Any(x => x == FieldBehavior.Required);
                    ParameterName = lastDesc.CSharpFieldName();
                    PropertyName = lastDesc.CSharpPropertyName();
                    DocLines = lastDesc.Declaration.DocLines();
                    FieldResource = svc.Catalog.GetResourceDetailsByField(lastDesc);
                }
                public IReadOnlyList<FieldDescriptor> Descs { get; }
                public Typ Typ { get; }
                public bool IsRepeated { get; }
                public bool IsRequired { get; }
                public bool IsWrapperType { get; }
                public string ParameterName { get; }
                public string PropertyName { get; }
                public IEnumerable<string> DocLines { get; }
                /// <summary>Resource details if this field respresents a resource. Null if not a resource field.</summary>
                public ResourceDetails.Field FieldResource { get; }
            }
            public Signature(ServiceDetails svc, MessageDescriptor msg , string sig)
            {
                Fields = sig.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(fieldName => new Field(svc, msg, fieldName.Trim())).ToList();
            }
            public IEnumerable<Field> Fields { get; }
        }

        public sealed class RoutingHeader
        {
            public RoutingHeader(string encodedName, IEnumerable<string> propertyNames) => (EncodedName, PropertyNames) = (encodedName, propertyNames);
            public string EncodedName { get; }
            public IEnumerable<string> PropertyNames { get; }
        }

        public static MethodDetails Create(ServiceDetails svc, MethodDescriptor desc) =>
            DetectPagination(svc, desc) ?? (
            desc.IsClientStreaming && desc.IsServerStreaming ? new BidiStreaming(svc, desc) :
            desc.IsServerStreaming ? new ServerStreaming(svc, desc) :
            desc.IsClientStreaming ? throw new NotImplementedException() :
            desc.OutputType.FullName == "google.longrunning.Operation" ? new Lro(svc, desc) :
            (MethodDetails)new Normal(svc, desc));

        private static MethodDetails DetectPagination(ServiceDetails svc, MethodDescriptor desc)
        {
            var input = desc.InputType;
            var output = desc.OutputType;
            var pageSize = input.FindFieldByName("page_size");
            var pageToken = input.FindFieldByName("page_token");
            var nextPageToken = output.FindFieldByName("next_page_token");
            var itemsByDeclOrder = output.Fields.InDeclarationOrder().Where(IsCandidateField).ToList();
            var itemsByNumOrder = output.Fields.InFieldNumberOrder().Where(IsCandidateField).ToList();
            if (pageSize != null && pageToken != null && nextPageToken != null && itemsByDeclOrder.Count > 0)
            {
                if (pageSize.FieldType != FieldType.Int32 || pageSize.IsRepeated)
                {
                    throw new InvalidOperationException("page_size must be of type int32");
                }
                if (pageToken.FieldType != FieldType.String || pageToken.IsRepeated)
                {
                    throw new InvalidOperationException("page_token must be of type string");
                }
                if (nextPageToken.FieldType != FieldType.String || nextPageToken.IsRepeated)
                {
                    throw new InvalidOperationException("next_page_token must be of type string");
                }
                if (itemsByDeclOrder[0] != itemsByNumOrder[0])
                {
                    throw new InvalidOperationException("Item response field must be first by declaration and field-number order.");
                }
                return new Paginated(svc, desc, itemsByDeclOrder[0], pageSize.FieldNumber, pageToken.FieldNumber);
            }
            return null;

            bool IsCandidateField(FieldDescriptor field) =>
                field.IsRepeated && !field.IsMap && (field.FieldType == FieldType.Message || field.FieldType == FieldType.String);
        }

        private MethodDetails(ServiceDetails svc, MethodDescriptor desc)
        {
            Svc = svc;
            SyncMethodName = desc.Name;
            SyncSnippetMethodName = $"{desc.Name}_RequestObject";
            SyncTestMethodName = $"{desc.Name}RequestObject";
            AsyncMethodName = $"{desc.Name}Async";
            AsyncSnippetMethodName = $"{desc.Name}Async_RequestObject";
            AsyncTestMethodName = $"{desc.Name}RequestObjectAsync";
            SettingsName = $"{desc.Name}Settings";
            RequestTyp = Typ.Of(desc.InputType);
            ResponseTyp = Typ.Of(desc.OutputType);
            ApiCallFieldName = $"_call{desc.Name}";
            ModifyApiCallMethodName = $"Modify_{desc.Name}ApiCall";
            ModifyRequestMethodName = $"Modify_{RequestTyp.Name}";
            DocLines = desc.Declaration.DocLines().ToList();
            Signatures = desc.CustomOptions.TryGetRepeatedString(ProtoConsts.MethodOption.MethodSignature, out var sigs) ?
                sigs.Select(sig => new Signature(svc, desc.InputType, sig)).ToList() : (IReadOnlyList<Signature>)new Signature[0];
            RequestMessageDesc = desc.InputType;
            ResponseMessageDesc = desc.OutputType;
            desc.CustomOptions.TryGetMessage<HttpRule>(ProtoConsts.MethodOption.HttpRule, out var http);
            RoutingHeaders = ReadRoutingHeaders(http, desc.InputType).ToList();
            (MethodRetry, MethodRetryStatusCodes) = LoadRetry(svc, desc);
        }

        private (RetrySettings, IEnumerable<StatusCode>) LoadRetry(ServiceDetails svc, MethodDescriptor desc)
        {
            var config = svc.MethodGrpcConfigsByName.GetValueOrDefault($"{svc.ServiceFullName}/{desc.Name}") ??
                svc.MethodGrpcConfigsByName.GetValueOrDefault($"{svc.ServiceFullName}/");
            if (config == null)
            {
                return default;
            }
            var rp = config.RetryPolicy;
            // `retry` is the delay duration between calls.
            var retry = new BackoffSettings(rp.InitialBackoff.ToTimeSpan(), rp.MaxBackoff.ToTimeSpan(), rp.BackoffMultiplier);
            // `timeout` is the timeout duration of a single RPC.
            var timeout = new BackoffSettings(config.Timeout.ToTimeSpan(), config.Timeout.ToTimeSpan(), 1.0); 
            var totalExpiration = Expiration.FromTimeout(config.Timeout.ToTimeSpan());
            // `Google.Rpc.Code` and `Grpc.Core.StatusCode` enums are identically defined.
            var statusCodes = rp.RetryableStatusCodes.Select(x => (StatusCode)x).ToList();
            var retrySettings = new RetrySettings(retry, timeout, totalExpiration);
            return (retrySettings, statusCodes);
        }

        private IEnumerable<RoutingHeader> ReadRoutingHeaders(HttpRule http, MessageDescriptor requestDesc)
        {
            if (http != null)
            {
                // Read routing headers(s) from any of the http urls
                var url =
                    !string.IsNullOrEmpty(http.Get) ? http.Get :
                    !string.IsNullOrEmpty(http.Post) ? http.Post :
                    !string.IsNullOrEmpty(http.Put) ? http.Put :
                    !string.IsNullOrEmpty(http.Patch) ? http.Patch :
                    !string.IsNullOrEmpty(http.Delete) ? http.Delete : null;
                if (url != null)
                {
                    foreach (var path in ExtractBracedPaths(url))
                    {
                        var desc = requestDesc;
                        var propertyNames = new List<string>();
                        FieldDescriptor finalField = null;
                        foreach (var fieldName in path.Split('.'))
                        {
                            var field = finalField = desc.FindFieldByName(fieldName);
                            desc = field.FieldType == FieldType.Message ? field.MessageType : null;
                            if (field == null)
                            {
                                throw new InvalidOperationException($"Invalid path in http url: '{path}'. '{fieldName}' does not exist.");
                            }
                            propertyNames.Add(field.CSharpPropertyName());
                        }
                        if (finalField.FieldType != FieldType.String)
                        {
                            throw new InvalidOperationException($"Path in http url must resolve to a string field: '{path}'.");
                        }
                        yield return new RoutingHeader(WebUtility.UrlEncode(path), propertyNames);
                    }
                }
            }

            IEnumerable<string> ExtractBracedPaths(string s)
            {
                var sb = new StringBuilder();
                int i = 0;
                while (i < s.Length)
                {
                    while (i < s.Length && s[i] != '{')
                    {
                        i++;
                    }
                    i++;
                    while (i < s.Length && s[i] != '=' && s[i] != '}')
                    {
                        sb.Append(s[i++]);
                    }
                    if (sb.Length > 0)
                    {
                        yield return sb.ToString();
                        sb.Clear();
                    }
                }
            }
        }

        /// <summary>The service in which this method is defined.</summary>
        public ServiceDetails Svc { get; }

        /// <summary>The sync name for this method.</summary>
        public string SyncMethodName { get; }

        /// <summary>The sync name for the snippet method.</summary>
        public string SyncSnippetMethodName { get; }

        /// <summary>The sync name for the unit test method.</summary>
        public string SyncTestMethodName { get; }

        /// <summary>The async name for this method.</summary>
        public string AsyncMethodName { get; }

        /// <summary>The async name for the snippet method.</summary>
        public string AsyncSnippetMethodName { get; }

        /// <summary>The async name for the unit test method.</summary>
        public string AsyncTestMethodName { get; }

        /// <summary>The per-method settings property name.</summary>
        public string SettingsName { get; }

        /// <summary>The typ of the method request.</summary>
        public Typ RequestTyp { get; }

        /// <summary>The typ of the method response.</summary>
        public Typ ResponseTyp { get; }

        /// <summary>The sync return typ for this method.</summary>
        public abstract Typ SyncReturnTyp { get; }

        /// <summary>The async return typ for this method.</summary>
        public virtual Typ AsyncReturnTyp => SyncReturnTyp is Typ.VoidTyp ? Typ.Of<Task>() : Typ.Generic(typeof(Task<>), SyncReturnTyp);

        /// <summary>The Gax ApiCall<> typ for this method.</summary>
        public abstract Typ ApiCallTyp { get; }

        /// <summary>The name of the ApiCall<> field.</summary>
        public string ApiCallFieldName { get; }

        /// <summary>The name of the per-method partial method to modify the ApiCall.</summary>
        public string ModifyApiCallMethodName { get; }

        /// <summary>The name of the per-request-type partial method to modify the request.</summary>
        public string ModifyRequestMethodName { get; }

        /// <summary>The lines of method documentation from the proto.</summary>
        public IEnumerable<string> DocLines { get; }

        /// <summary>Method signatures.</summary>
        public IReadOnlyList<Signature> Signatures { get; }

        /// <summary>The proto descriptor of the request message.</summary>
        public MessageDescriptor RequestMessageDesc { get; }

        /// <summary>The proto descriptor of the response message.</summary>
        public MessageDescriptor ResponseMessageDesc { get; }

        /// <summary>Routing headers extracted from http annotation.</summary>
        public IEnumerable<RoutingHeader> RoutingHeaders { get; }

        /// <summary>Retry settings for this method; null if no retry settings available.</summary>
        public RetrySettings MethodRetry { get; }

        /// <summary>If retry is specified, the status codes on which to retry.</summary>
        public IEnumerable<StatusCode> MethodRetryStatusCodes { get; }
    }
}
