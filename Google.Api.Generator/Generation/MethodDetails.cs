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
using Grpc.ServiceConfig;
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
                ResourceTyp = ProtoTyp.Of(responseResourceField, forceRepeated: false);
                // For map fields, ResourceTyp is a constructed KeyValuePair<,> type: we need the open type in a cref.
                ResourceTypForCref = responseResourceField.IsMap
                    ? Typ.Generic(typeof(KeyValuePair<,>), Typ.GenericParam("TKey"), Typ.GenericParam("TValue"))
                    : ResourceTyp;
                ApiCallTyp = Typ.Generic(typeof(ApiCall<,>), RequestTyp, ResponseTyp);
                SyncReturnTyp = Typ.Generic(typeof(PagedEnumerable<,>), ResponseTyp, ResourceTyp);
                AsyncReturnTyp = Typ.Generic(typeof(PagedAsyncEnumerable<,>), ResponseTyp, ResourceTyp);
                SyncGrpcType = Typ.Generic(typeof(GrpcPagedEnumerable<,,>), RequestTyp, ResponseTyp, ResourceTyp);
                AsyncGrpcType = Typ.Generic(typeof(GrpcPagedAsyncEnumerable<,,>), RequestTyp, ResponseTyp, ResourceTyp);
                ResourcesFieldName = responseResourceField.CSharpPropertyName();
                PageSizeFieldNumber = pageSizeFieldNumber;
                PageTokenFieldNumber = pageTokenFieldNumber;
            }
            public override Typ ApiCallTyp { get; }
            public override Typ SyncReturnTyp { get; }
            public override Typ AsyncReturnTyp { get; }
            public Typ ResourceTyp { get; }
            /// <summary>
            /// The resource type, but using open generic types instead of constructed ones where necessary,
            /// so they're suitable for cref attributes.
            /// </summary>
            public Typ ResourceTypForCref { get; }
            public Typ SyncGrpcType { get; }
            public Typ AsyncGrpcType { get; }
            public string ResourcesFieldName { get; }
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
                OperationInfo lroData = desc.GetExtension(OperationsExtensions.OperationInfo);
                if (lroData is null)
                {
                    throw new InvalidOperationException("LRO method must contain a `google.api.operation` option.");
                }
                ApiCallTyp = Typ.Generic(typeof(ApiCall<,>), RequestTyp, Typ.Of<Operation>());
                if (string.IsNullOrEmpty(lroData.ResponseType) || string.IsNullOrEmpty(lroData.MetadataType))
                {
                    throw new InvalidOperationException($"Both response-type and metadata-type must be present for method: '{desc.FullName}'.");
                }
                var responseTypeMsg = svc.Catalog.GetMessageByName(lroData.ResponseType);
                var metadataTypeMsg = svc.Catalog.GetMessageByName(lroData.MetadataType);
                if (responseTypeMsg is null || metadataTypeMsg is null)
                {
                    throw new InvalidOperationException(
                        $"Response-type and Metadata-type must both exist in method '{desc.FullName}': '{lroData.ResponseType}', '{lroData.MetadataType}'.");
                }
                OperationResponseTyp = ProtoTyp.Of(responseTypeMsg);
                OperationMetadataTyp = ProtoTyp.Of(metadataTypeMsg);
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
                    Typ = ProtoTyp.Of(lastDesc);
                    IsMap = lastDesc.IsMap;
                    IsRepeated = lastDesc.IsRepeated;
                    IsWrapperType = ProtoTyp.IsWrapperType(lastDesc);
                    IsRequired = lastDesc.GetExtension(FieldBehaviorExtensions.FieldBehavior).Any(x => x == FieldBehavior.Required);
                    ParameterName = lastDesc.CSharpFieldName();
                    PropertyName = lastDesc.CSharpPropertyName();
                    IsDeprecated = Descs.Any(x => x.IsDeprecated());
                    DocLines = lastDesc.Declaration.DocLines();
                    FieldResources = svc.Catalog.GetResourceDetailsByField(lastDesc);
                }
                public IReadOnlyList<FieldDescriptor> Descs { get; }
                public Typ Typ { get; }
                public bool IsMap { get; }
                public bool IsRepeated { get; }
                public bool IsRequired { get; }
                public bool IsWrapperType { get; }
                public string ParameterName { get; }
                public string PropertyName { get; }
                public bool IsDeprecated { get; }
                public IEnumerable<string> DocLines { get; }
                /// <summary>Resource details if this field represents a resource. Null if not a resource field.</summary>
                public IReadOnlyList<ResourceDetails.Field> FieldResources { get; }
            }
            public Signature(ServiceDetails svc, MessageDescriptor msg , string sig)
            {
                Fields = sig.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(fieldName => new Field(svc, msg, fieldName.Trim())).ToList();
            }
            public IEnumerable<Field> Fields { get; }
            public bool HasDeprecatedField => Fields.Any(field => field.IsDeprecated);
        }

        public sealed class RoutingHeader
        {
            public RoutingHeader(string encodedName, IEnumerable<FieldDescriptor> fields) => (EncodedName, Fields) = (encodedName, fields);
            public string EncodedName { get; }
            public IEnumerable<FieldDescriptor> Fields { get; }
        }

        public static MethodDetails Create(ServiceDetails svc, MethodDescriptor desc) =>
            DetectPagination(svc, desc) ?? (
            desc.IsClientStreaming && desc.IsServerStreaming ? new BidiStreaming(svc, desc) :
            desc.IsServerStreaming ? new ServerStreaming(svc, desc) :
            desc.IsClientStreaming ? throw new NotImplementedException() :
            // Any LRO-returning methods within the LRO package itself should be treated normally. Anywhere else, they get special treatment.
            desc.OutputType.FullName == "google.longrunning.Operation" && desc.File.Package != "google.longrunning" ? new Lro(svc, desc) :
            (MethodDetails)new Normal(svc, desc));

        private static MethodDetails DetectPagination(ServiceDetails svc, MethodDescriptor desc)
        {
            if (desc.File.Package == "google.cloud.talent.v4beta1" && (desc.Name == "SearchProfiles" || desc.Name == "SearchJobs"))
            {
                // TODO: remove this once the next version of the Talent API is published.
                // This is a workaround to disable auto-pagination for specifc RPCs in
                // Talent v4beta1. The API team will make their API non-conforming in the
                // next version.
                // This should not be done for any other API.
                return null;
            }

            var input = desc.InputType;
            var output = desc.OutputType;

            var pageSizeCandidate = FindPageSizeCandidate(input);
            var pageTokenCandidate = input.FindFieldByName("page_token");
            var nextPageTokenCandidate = output.FindFieldByName("next_page_token");

            var mapCandidates = output.Fields.InDeclarationOrder().Where(f => f.IsMap).ToList();
            var repeatedCandidatesByDeclOrder = output.Fields.InDeclarationOrder().Where(IsRepeatedCandidate).ToList();
            var repeatedCandidatesByNumOrder = output.Fields.InFieldNumberOrder().Where(IsRepeatedCandidate).ToList();

            var hasMapOrRepeatedCandidates = mapCandidates.Count == 1 || repeatedCandidatesByNumOrder.Count >= 1;

            if (pageSizeCandidate is null || pageTokenCandidate is null || nextPageTokenCandidate is null || !hasMapOrRepeatedCandidates)
            {
                return null;
            }

            // At this point the method is a candidate for pagination since its input has page_size/max_results + page_token 
            // and its output has next_page_token and at least one map or repeated field

            if (!IsValidPageSizeCandidate(pageSizeCandidate))
            {
                throw new InvalidOperationException($"{pageSizeCandidate.Name} must be of type int32/uint32");
            }

            if (pageTokenCandidate.FieldType != FieldType.String || pageTokenCandidate.IsRepeated)
            {
                throw new InvalidOperationException("page_token must be of type string");
            }

            if (nextPageTokenCandidate.FieldType != FieldType.String || nextPageTokenCandidate.IsRepeated)
            {
                throw new InvalidOperationException("next_page_token must be of type string");
            }

            // GRPC case first.
            // - PageSizeCandidate should be named page_size
            // - The repeated candidate should be the first in both orders
            // - There should be 0 or more than 1 map candidates, to disambiguate with DiREGapic single-map case
            //   OR The repeated candidate should have a field number of 1 
            if (pageSizeCandidate.Name == "page_size" && repeatedCandidatesByDeclOrder[0] == repeatedCandidatesByNumOrder[0] && 
                (repeatedCandidatesByNumOrder[0].FieldNumber == 1 || mapCandidates.Count != 1))
            {
                return new Paginated(svc, desc, repeatedCandidatesByDeclOrder[0], pageSizeCandidate.FieldNumber, pageTokenCandidate.FieldNumber);
            }

            // DiREGapic case where a return message has exactly one map
            if (mapCandidates.Count == 1)
            {
                return new Paginated(svc, desc, mapCandidates.Single(), pageSizeCandidate.FieldNumber,
                    pageTokenCandidate.FieldNumber);
            }

            // DiREGapic case where a return message has exactly one repeated field
            // (pageSizeCandidate's name can be either "page_size" or "max_results")
            if (repeatedCandidatesByDeclOrder.Count == 1 && !mapCandidates.Any())
            {
                return new Paginated(svc, desc, repeatedCandidatesByDeclOrder.Single(), pageSizeCandidate.FieldNumber, pageTokenCandidate.FieldNumber);
            }

            var errMsg = $"The method {desc.FullName} is selected as a pagination candidate " +
                         $"but the configuration of the item response field candidates " +
                         $"does not match any of the configurations we can generate.";
                              
            throw new InvalidOperationException(errMsg);

            bool IsRepeatedCandidate(FieldDescriptor field) =>
                field.IsRepeated && !field.IsMap && (field.FieldType == FieldType.Message || field.FieldType == FieldType.String);
        }

        /// <summary>
        /// Finds an appropriate candidate for a `page size`/`max results` request field.
        /// That is a field that is named "page_size" or "max_results" and has a non-repeated Int32 type, if any.
        /// If no such field exists, then simply a field that is named "page_size" or "max_results".
        /// </summary>
        private static FieldDescriptor FindPageSizeCandidate(MessageDescriptor input)
        {
            // Has the int32 page_size or int32 max_results field which defines the maximum number of paginated resources to return in the response
            var pageSizeCandidate = input.FindFieldByName("page_size");
            var maxResultsCandidate = input.FindFieldByName("max_results");

            // If both candidates are invalid, this might return a non-null 'invalid' candidate.
            // An exception should be thrown, but only if method has _all_ candidates, which we will only know later.
            return IsValidPageSizeCandidate(pageSizeCandidate) ? pageSizeCandidate
                : IsValidPageSizeCandidate(maxResultsCandidate) ? maxResultsCandidate
                : pageSizeCandidate ?? maxResultsCandidate;
        }

        /// <summary>
        /// The non-name criteria for a field to be a suitable candidate for a `page size`/`max results` request field.
        /// </summary>
        private static bool IsValidPageSizeCandidate(FieldDescriptor field) =>
            field != null && ((field.FieldType == FieldType.Int32 || field.FieldType == FieldType.UInt32) && !field.IsRepeated);

        private MethodDetails(ServiceDetails svc, MethodDescriptor desc)
        {
            Svc = svc;
            ProtoRpcName = desc.Name;
            SyncMethodName = desc.Name;
            SyncSnippetMethodName = $"{desc.Name}RequestObject";
            SyncTestMethodName = $"{desc.Name}RequestObject";
            AsyncMethodName = $"{desc.Name}Async";
            AsyncSnippetMethodName = $"{desc.Name}RequestObjectAsync";
            AsyncTestMethodName = $"{desc.Name}RequestObjectAsync";
            SettingsName = $"{desc.Name}Settings";
            RequestTyp = ProtoTyp.Of(desc.InputType);
            ResponseTyp = ProtoTyp.Of(desc.OutputType);
            ApiCallFieldName = $"_call{desc.Name}";
            ModifyApiCallMethodName = $"Modify_{desc.Name}ApiCall";
            ModifyRequestMethodName = $"Modify_{RequestTyp.Name}";
            DocLines = desc.Declaration.DocLines().ToList();
            Signatures = desc.GetExtension(ClientExtensions.MethodSignature).Select(sig => new Signature(svc, desc.InputType, sig)).ToList();
            RequestMessageDesc = desc.InputType;
            ResponseMessageDesc = desc.OutputType;
            var http = desc.GetExtension(AnnotationsExtensions.Http);
            RoutingHeaders = ReadRoutingHeaders(http, desc.InputType).ToList();
            (MethodRetry, MethodRetryStatusCodes, Expiration) = LoadTiming(svc, desc);
            // The method is considered deprecated if the RPC, request or response messages are deprecated.
            // In reality, it would be very odd to deprecate the messages without deprecating the RPC, but this makes it consistent.
            IsDeprecated = desc.IsDeprecated() || RequestMessageDesc.IsDeprecated() || ResponseMessageDesc.IsDeprecated();
        }

        private (RetrySettings, IEnumerable<StatusCode>, Expiration) LoadTiming(ServiceDetails svc, MethodDescriptor desc)
        {
            var config = svc.MethodGrpcConfigsByName.GetValueOrDefault($"{svc.ServiceFullName}/{desc.Name}") ??
                svc.MethodGrpcConfigsByName.GetValueOrDefault($"{svc.ServiceFullName}/");
            if (config == null)
            {
                return default;
            }
            RetrySettings retry;
            IReadOnlyList<StatusCode> statusCodes;
            if (config.RetryOrHedgingPolicyCase == MethodConfig.RetryOrHedgingPolicyOneofCase.RetryPolicy)
            {
                var rp = config.RetryPolicy;
                // `retry` is the delay duration between calls.
                // float -> double conversion via string to avoid unpleasent results from unrepresentable floats (e.g. 1.3 -> 1.2999999523162842)
                var multiplier = double.Parse(rp.BackoffMultiplier.ToString());
                // gRPC uses maxAttempts = 0 to mean unlimited; GAX wants a positive number. int.MaxValue is fine.
                int maxAttempts = rp.MaxAttempts == 0 ? int.MaxValue : (int)rp.MaxAttempts;
                // The retry filter here is irrelevant. We'll generate code with the right status codes later.
                retry = RetrySettings.FromExponentialBackoff(maxAttempts, rp.InitialBackoff.ToTimeSpan(), rp.MaxBackoff.ToTimeSpan(), multiplier, error => false);
                // `Google.Rpc.Code` and `Grpc.Core.StatusCode` enums are identically defined.
                statusCodes = rp.RetryableStatusCodes.Select(x => (StatusCode)x).ToList();
            }
            else
            {
                retry = null;
                statusCodes = ImmutableList<StatusCode>.Empty;
            }
            var expiration = config.Timeout is null ? null : Expiration.FromTimeout(config.Timeout.ToTimeSpan());
            return (retry, statusCodes, expiration);
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
                        var fields = new List<FieldDescriptor>();
                        FieldDescriptor finalField = null;
                        foreach (var fieldName in path.Split('.'))
                        {
                            var field = finalField = desc.FindFieldByName(fieldName);
                            desc = field.FieldType == FieldType.Message ? field.MessageType : null;
                            if (field == null)
                            {
                                throw new InvalidOperationException($"Invalid path in http url: '{path}'. '{fieldName}' does not exist.");
                            }
                            fields.Add(field);
                        }
                        if (finalField.FieldType != FieldType.String)
                        {
                            throw new InvalidOperationException($"Path in http url must resolve to a string field: '{path}'.");
                        }
                        yield return new RoutingHeader(WebUtility.UrlEncode(path), fields);
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

        /// <summary>The name of this method in the method descriptor</summary>
        public string ProtoRpcName { get; }

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

        /// <summary>Expiration for this method; null if no expiration available.</summary>
        public Expiration Expiration { get; }

        /// <summary>If retry is specified, the status codes on which to retry.</summary>
        public IEnumerable<StatusCode> MethodRetryStatusCodes { get; }

        /// <summary>Whether the RPC is deprecated.</summary>
        public bool IsDeprecated { get; }
    }
}
