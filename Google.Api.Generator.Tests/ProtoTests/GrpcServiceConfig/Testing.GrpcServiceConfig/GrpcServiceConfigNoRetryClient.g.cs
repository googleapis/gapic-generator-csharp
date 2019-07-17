﻿// Copyright 2019 Google LLC
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

using gax = Google.Api.Gax;
using gaxgrpc = Google.Api.Gax.Grpc;
using grpccore = Grpc.Core;
using sys = System;

namespace Testing.GrpcServiceConfig
{
    public sealed partial class GrpcServiceConfigNoRetrySettings : gaxgrpc::ServiceSettingsBase
    {
        // TEST_START
        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>GrpcServiceConfigNoRetryClient.NoRetryMethod</c> and <c>GrpcServiceConfigNoRetryClient.NoRetryMethodAsync</c>
        /// .
        /// </summary>
        /// <remarks>By default, retry will not be attempted.</remarks>
        public gaxgrpc::CallSettings NoRetryMethodSettings { get; set; }
        // TEST_END
    }
}
