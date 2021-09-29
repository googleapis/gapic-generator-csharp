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
    _rules_gapic_version = "0.8.0"
    _rules_gapic_sha256 = "75705d03068ba07cc885a85bb4585e2a278414e31510e60577df8437a28a4ae1"

    maybe(
        http_archive,
        name = "rules_gapic",
        sha256 = _rules_gapic_sha256,
        strip_prefix = "rules_gapic-%s" % _rules_gapic_version,
        urls = ["https://github.com/googleapis/rules_gapic/archive/v%s.tar.gz" % _rules_gapic_version],
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
