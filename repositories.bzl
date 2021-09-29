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
    # This is where the C# generator is bringing in the rules_gapic.
    # We can comment the existing rule and bring up an alternative version
    
    # For local development just getting one from a neighboring folder is the most convenient.
    # (this aproach is commented out below)
    #
    # But if it's a review on gh, we can also use a commit id (this is what I have uncommented below).
    
    # Alternatively we can bring the version we want to test right at the beginning of the 
    # bazel_example's WORKSPACE.bazel (see comnments in that file.)
    
    # Then we can cd to the `bazel_example` and test the change by running 
    # `bazel build example_csharp_pkg`
    # ❯ (cd bazel_example && bazel build example_csharp_pkg)
    # ...
    # Target //:example_csharp_pkg up-to-date:
    #  bazel-bin/example_csharp_pkg.tar.gz
    # ...
    # INFO: Build completed successfully, 3 total actions

    # Now the file it created for us can be unpacked and inspected
    # ❯ (cd bazel_example && tar -zxf bazel-bin/example_csharp_pkg.tar.gz && tree example_csharp_pkg)
    # ...
    # ├── Example
    # │   ├── ExampleClient.g.cs
    # │   ├── Example.csproj
    # │   ├── Example.g.cs
    # ...
    # 
    # This seems to satisfy.
    #
    # In the future we will update the _rules_gapic_version and _rules_gapic_sha256 here.
    #

    # native.local_repository(
    #     name = "rules_gapic",
    #     path = "../../rules_gapic",
    # )

    _rules_gapic_commit = "276a0504584c56ee93d573add0540a65afb6e8d0"
    http_archive(
        name = "rules_gapic",
        urls = ["https://github.com/googleapis/rules_gapic/archive/%s.zip" % _rules_gapic_commit],
        strip_prefix = "rules_gapic-%s" % _rules_gapic_commit,
    )

    # _rules_gapic_version = "0.7.0"
    # _rules_gapic_sha256 = "3536ddd6d03b80733fd4dbde98d9f5be784dc0a38aba14ad2f7ac2e0209a15f8"

    # maybe(
    #     http_archive,
    #     name = "rules_gapic",
    #     sha256 = _rules_gapic_sha256,
    #     strip_prefix = "rules_gapic-%s" % _rules_gapic_version,
    #     urls = ["https://github.com/googleapis/rules_gapic/archive/v%s.tar.gz" % _rules_gapic_version],
    # )

    maybe(
        csharp_compiler,
        name = "csharp_compiler",
    )
    maybe(
        dotnet_restore,
        name = "gapic_generator_restore",
        csproj = "@gapic_generator_csharp//:Google.Api.Generator/Google.Api.Generator.csproj",
    )
