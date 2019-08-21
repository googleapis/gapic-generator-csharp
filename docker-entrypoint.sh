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

protoc --proto_path=/protos/ --proto_path=/in/ \
  --plugin=protoc-gen-csharp_gapic=/usr/src/gapic-generator-csharp/Google.Api.Generator/bin/Release/netcoreapp2.2/linux-x64/publish/Google.Api.Generator \
  --csharp_gapic_out=/out/ \
  $(find /in/ -name '*.proto')
