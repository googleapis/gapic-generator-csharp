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
load("//rules_csharp_gapic:csharp_gapic_repo.bzl", "gapic_generator_src")

def gapic_generator_csharp_repositories():
    maybe(
        http_archive,
        name = "com_google_api_codegen",
        strip_prefix = "gapic-generator-a79e9ea3fcf686a80d92461a4788c5bcf55cea5a",
        urls = ["https://github.com/googleapis/gapic-generator/archive/a79e9ea3fcf686a80d92461a4788c5bcf55cea5a.zip"],
        sha256 = "c6a13fd221189458ad9eeb1de1f40e21bd80f0063bf05b9fa243722c18577f17",
    )
    maybe(
        csharp_compiler,
        name = "csharp_compiler",
    )
    maybe(
        gapic_generator_src,
        name = "gapic_generator_src",
    )
    maybe(
        dotnet_restore,
        name = "gapic_generator_restore",
        src_base = "@gapic_generator_src//:gen_dest/Google.Api.Generator",
        csproj_name = "Google.Api.Generator.csproj",
        runtime = "linux-x64",
    )
