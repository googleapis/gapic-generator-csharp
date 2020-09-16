# Copyright 2020 Google LLC
#
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
#
#      https://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.

load("@bazel_tools//tools/build_defs/repo:http.bzl", "http_archive")
load("@bazel_tools//tools/build_defs/repo:utils.bzl", "maybe")
load("//rules_csharp_gapic:csharp_compiler_repo.bzl", "csharp_compiler", "dotnet_restore")

def gapic_generator_csharp_repositories():
    maybe(
        http_archive,
        name = "com_google_api_codegen",
        strip_prefix = "gapic-generator-2.2.0",
        urls = ["https://github.com/googleapis/gapic-generator/archive/v2.2.0.zip"],
        sha256 = "0633651c7e7cdbea16231025de8a8e55773c224ad840507a8f3b38f96461ad30"
    )
    maybe(
        csharp_compiler,
        name = "csharp_compiler",
    )
    maybe(
        dotnet_restore,
        name = "gapic_generator_restore",
        csproj = "@gapic_generator_csharp//:Google.Api.Generator/Google.Api.Generator.csproj",
    )
