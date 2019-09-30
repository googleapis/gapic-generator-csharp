#!/bin/bash

# Copyright 2019 Google LLC
#
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
#
#     https://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
#
# THIS SCRIPT IS MEANT ONLY TO BE USED IN THE GAPIC-GENERATOR-CSHARP DOCKER IMAGE

GRPC_SERVICE_CONFIG=
COMMON_RESOURCES_CONFIG=

# enable extended globbing for flag pattern matching
shopt -s extglob

# Parse options.
while true; do
  case "$1" in
    --grpc-service-config ) GRPC_SERVICE_CONFIG="grpc-service-config=/conf/$2"; shift 2;;
    --common-resources-config ) COMMON_RESOURCES_CONFIG="common-resources-config=/conf/$2"; shift 2;;
    --* | +([[:word:][:punct:]]) ) shift ;;
    * ) break ;;
  esac
done

protoc \
  --proto_path=/protos/ \
  --proto_path=/in/ \
  --plugin=protoc-gen-csharp_gapic=/usr/src/gapic-generator-csharp/Google.Api.Generator/bin/Release/netcoreapp2.2/linux-x64/publish/Google.Api.Generator \
  --csharp_gapic_out=/out/ \
  --csharp_gapic_opt="$GRPC_SERVICE_CONFIG" \
  --csharp_gapic_opt="$COMMON_RESOURCES_CONFIG" \
  $(find /in/ -name '*.proto')
