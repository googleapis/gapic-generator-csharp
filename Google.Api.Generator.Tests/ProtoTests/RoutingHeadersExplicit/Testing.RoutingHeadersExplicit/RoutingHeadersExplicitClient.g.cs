// Copyright 2019 Google LLC
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

// Generated code. DO NOT EDIT!

using gaxgrpc = Google.Api.Gax.Grpc;
using mel = Microsoft.Extensions.Logging;
using proto = Google.Protobuf;
using sysnet = System.Net;
using sys = System;
using str = System.Text.RegularExpressions;

namespace Testing.RoutingHeadersExplicit
{
    public sealed partial class RoutingHeadersExplicitSettings : gaxgrpc::ServiceSettingsBase
    {
        public static RoutingHeadersExplicitSettings GetDefault() => throw new sys::NotImplementedException();
        public gaxgrpc::CallSettings NoRoutingSettings => throw new sys::NotImplementedException();
        public gaxgrpc::CallSettings PlainNoTemplateSettings => throw new sys::NotImplementedException();
        public gaxgrpc::CallSettings PlainNoExtractionSettings => throw new sys::NotImplementedException();
        public gaxgrpc::CallSettings PlainFullFieldSettings => throw new sys::NotImplementedException();
        public gaxgrpc::CallSettings PlainExtractSettings => throw new sys::NotImplementedException();
        public gaxgrpc::CallSettings NestedSettings => throw new sys::NotImplementedException();
        public gaxgrpc::CallSettings ComplexSettings => throw new sys::NotImplementedException();
    }

    public abstract class RoutingHeadersExplicitClient
    {

    }

    /// <summary>RoutingHeadersExplicit client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// </remarks>
    public sealed partial class RoutingHeadersExplicitClientImpl : RoutingHeadersExplicitClient
    {
        private readonly gaxgrpc::ApiCall<SimpleRequest, Response> _callNoRouting;

        private readonly gaxgrpc::ApiCall<SimpleRequest, Response> _callPlainNoTemplate;

        private readonly gaxgrpc::ApiCall<SimpleRequest, Response> _callPlainNoExtraction;

        private readonly gaxgrpc::ApiCall<SimpleRequest, Response> _callPlainFullField;

        private readonly gaxgrpc::ApiCall<SimpleRequest, Response> _callPlainExtract;

        private readonly gaxgrpc::ApiCall<NestedRequest, Response> _callNested;

        private readonly gaxgrpc::ApiCall<NestedRequest, Response> _callComplex;


        public RoutingHeadersExplicitClientImpl(RoutingHeadersExplicit.RoutingHeadersExplicitClient grpcClient, RoutingHeadersExplicitSettings settings, mel::ILogger logger)
        {
            // TEST_START
            GrpcClient = grpcClient;
            RoutingHeadersExplicitSettings effectiveSettings = settings ?? RoutingHeadersExplicitSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings, logger);
            _callNoRouting = clientHelper.BuildApiCall<SimpleRequest, Response>("NoRouting", grpcClient.NoRoutingAsync, grpcClient.NoRouting, effectiveSettings.NoRoutingSettings);
            Modify_ApiCall(ref _callNoRouting);
            Modify_NoRoutingApiCall(ref _callNoRouting);
            _callPlainNoTemplate = clientHelper.BuildApiCall<SimpleRequest, Response>("PlainNoTemplate", grpcClient.PlainNoTemplateAsync, grpcClient.PlainNoTemplate, effectiveSettings.PlainNoTemplateSettings).WithGoogleRequestParam("name", request => request.Name);
            Modify_ApiCall(ref _callPlainNoTemplate);
            Modify_PlainNoTemplateApiCall(ref _callPlainNoTemplate);
            _callPlainNoExtraction = clientHelper.BuildApiCall<SimpleRequest, Response>("PlainNoExtraction", grpcClient.PlainNoExtractionAsync, grpcClient.PlainNoExtraction, effectiveSettings.PlainNoExtractionSettings).WithGoogleRequestParam("name", request => request.Name);
            Modify_ApiCall(ref _callPlainNoExtraction);
            Modify_PlainNoExtractionApiCall(ref _callPlainNoExtraction);
            _callPlainFullField = clientHelper.BuildApiCall<SimpleRequest, Response>("PlainFullField", grpcClient.PlainFullFieldAsync, grpcClient.PlainFullField, effectiveSettings.PlainFullFieldSettings).WithExtractedGoogleRequestParam(new gaxgrpc::RoutingHeaderExtractor<SimpleRequest>().WithExtractedParameter("table_name", "^(projects/[^/]+/instances/[^/]+/tables/[^/]+)/?$", request => request.Name));
            Modify_ApiCall(ref _callPlainFullField);
            Modify_PlainFullFieldApiCall(ref _callPlainFullField);
            _callPlainExtract = clientHelper.BuildApiCall<SimpleRequest, Response>("PlainExtract", grpcClient.PlainExtractAsync, grpcClient.PlainExtract, effectiveSettings.PlainExtractSettings).WithExtractedGoogleRequestParam(new gaxgrpc::RoutingHeaderExtractor<SimpleRequest>().WithExtractedParameter("table_name", "^projects/[^/]+/instances/[^/]+/(tables/[^/]+)/?$", request => request.Name));
            Modify_ApiCall(ref _callPlainExtract);
            Modify_PlainExtractApiCall(ref _callPlainExtract);
            _callNested = clientHelper.BuildApiCall<NestedRequest, Response>("Nested", grpcClient.NestedAsync, grpcClient.Nested, effectiveSettings.NestedSettings).WithExtractedGoogleRequestParam(new gaxgrpc::RoutingHeaderExtractor<NestedRequest>().WithExtractedParameter("nest1.name", "^(.+)$", request => request.Nest1?.Name).WithExtractedParameter("nest1.nest2.name", "^(.+)$", request => request.Nest1?.Nest2?.Name));
            Modify_ApiCall(ref _callNested);
            Modify_NestedApiCall(ref _callNested);
            _callComplex = clientHelper.BuildApiCall<NestedRequest, Response>("Complex", grpcClient.ComplexAsync, grpcClient.Complex, effectiveSettings.ComplexSettings).WithExtractedGoogleRequestParam(new gaxgrpc::RoutingHeaderExtractor<NestedRequest>().WithExtractedParameter("table_location", "^projects/[^/]+/(instances/[^/]+)/tables/[^/]+/?$", request => request.TableName).WithExtractedParameter("table_location", "^(regions/[^/]+/zones/[^/]+)/tables/[^/]+/?$", request => request.TableName).WithExtractedParameter("routing_id", "^(projects/[^/]+)(?:/.*)?$", request => request.TableName).WithExtractedParameter("routing_id", "^(.+)$", request => request.AppProfileId).WithExtractedParameter("routing_id", "^profiles/([^/]+)/?$", request => request.AppProfileId));
            Modify_ApiCall(ref _callComplex);
            Modify_ComplexApiCall(ref _callComplex);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
            // TEST_END

            // for the easier reading, the above calls but indented
            _callPlainNoTemplate = clientHelper.BuildApiCall<SimpleRequest, Response>("PlainNoTemplate", grpcClient.PlainNoTemplateAsync, grpcClient.PlainNoTemplate, effectiveSettings.PlainNoTemplateSettings)
                .WithGoogleRequestParam("name", request => request.Name);

            _callPlainNoExtraction = clientHelper
                .BuildApiCall<SimpleRequest, Response>("PlainNoExtraction", grpcClient.PlainNoExtractionAsync, grpcClient.PlainNoExtraction, effectiveSettings.PlainNoExtractionSettings)
                .WithGoogleRequestParam("name", request => request.Name);

            _callPlainFullField = clientHelper
                .BuildApiCall<SimpleRequest, Response>("PlainFullField", grpcClient.PlainFullFieldAsync, grpcClient.PlainFullField, effectiveSettings.PlainFullFieldSettings)
                .WithExtractedGoogleRequestParam(new gaxgrpc::RoutingHeaderExtractor<SimpleRequest>()
                    .WithExtractedParameter("table_name",
                        "^(projects/[^/]+/instances/[^/]+/tables/[^/]+)/?$", request => request.Name));

            _callPlainExtract = clientHelper
                .BuildApiCall<SimpleRequest, Response>("", grpcClient.PlainExtractAsync, grpcClient.PlainExtract, effectiveSettings.PlainExtractSettings)
                .WithExtractedGoogleRequestParam(new gaxgrpc::RoutingHeaderExtractor<SimpleRequest>()
                    .WithExtractedParameter("table_name",
                        "^projects/[^/]+/instances/[^/]+/(tables/[^/]+)/?$", request => request.Name));

            _callNested = clientHelper
                .BuildApiCall<NestedRequest, Response>("", grpcClient.NestedAsync, grpcClient.Nested, effectiveSettings.NestedSettings)
                .WithExtractedGoogleRequestParam(new gaxgrpc::RoutingHeaderExtractor<NestedRequest>()
                    .WithExtractedParameter("nest1.name",
                        "^(.+)$", request => request.Nest1?.Name)
                    .WithExtractedParameter("nest1.nest2.name",
                        "^(.+)$", request => request.Nest1?.Nest2?.Name));

            _callComplex = clientHelper
                .BuildApiCall<NestedRequest, Response>("", grpcClient.ComplexAsync, grpcClient.Complex, effectiveSettings.ComplexSettings)
                .WithExtractedGoogleRequestParam(new gaxgrpc::RoutingHeaderExtractor<NestedRequest>()
                    .WithExtractedParameter("table_location",
                        "^projects/[^/]+/(instances/[^/]+)/tables/[^/]+/?$", request => request.TableName)
                    .WithExtractedParameter("table_location",
                        "^(regions/[^/]+/zones/[^/]+)/tables/[^/]+/?$", request => request.TableName)
                    .WithExtractedParameter("routing_id",
                        "^(projects/[^/]+)(?:/.*)?$", request => request.TableName)
                    .WithExtractedParameter("routing_id",
                        "^(.+)$", request => request.AppProfileId)
                    .WithExtractedParameter("routing_id",
                        "^profiles/([^/]+)/?$", request => request.AppProfileId));
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_NoRoutingApiCall(ref gaxgrpc::ApiCall<SimpleRequest, Response> call);

        partial void Modify_PlainNoTemplateApiCall(ref gaxgrpc::ApiCall<SimpleRequest, Response> call);

        partial void Modify_PlainNoExtractionApiCall(ref gaxgrpc::ApiCall<SimpleRequest, Response> call);

        partial void Modify_PlainFullFieldApiCall(ref gaxgrpc::ApiCall<SimpleRequest, Response> call);

        partial void Modify_PlainExtractApiCall(ref gaxgrpc::ApiCall<SimpleRequest, Response> call);

        partial void Modify_NestedApiCall(ref gaxgrpc::ApiCall<NestedRequest, Response> call);

        partial void Modify_ComplexApiCall(ref gaxgrpc::ApiCall<NestedRequest, Response> call);

        partial void OnConstruction(RoutingHeadersExplicit.RoutingHeadersExplicitClient grpcClient, RoutingHeadersExplicitSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        RoutingHeadersExplicit.RoutingHeadersExplicitClient GrpcClient { get; }
    }
}
