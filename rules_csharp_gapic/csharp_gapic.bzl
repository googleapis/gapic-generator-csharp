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

load("@rules_gapic//:gapic.bzl", "GapicInfo", "proto_custom_library")
load("@rules_gapic//csharp:csharp_gapic.bzl", _csharp_proto_library="csharp_proto_library", _csharp_grpc_library="csharp_grpc_library")

def csharp_proto_library(name, deps, **kwargs):
    _csharp_proto_library(name, deps, **kwargs)

def csharp_grpc_library(name, srcs, deps, **kwargs):
    _csharp_grpc_library(name, srcs, deps, **kwargs)

def _csharp_gapic_library_add_gapicinfo_impl(ctx):
    return [
        DefaultInfo(files = depset(direct = [ctx.file.output])),
        GapicInfo(),
    ]

_csharp_gapic_library_add_gapicinfo = rule(
    implementation = _csharp_gapic_library_add_gapicinfo_impl,
    attrs = {
        "output": attr.label(allow_single_file = True),
    },
)

def csharp_gapic_library(
        name,
        srcs,
        deps,
        grpc_service_config = None,
        common_resources_config = None,
        service_yaml = None,
        rest_numeric_enums = False,
        generator_binary = "//rules_csharp_gapic:csharp_gapic_generator_binary",
        **kwargs):
    # Build zip file of gapic-generator output
    name_srcjar = "{name}_srcjar".format(name = name)
    plugin_file_args = {}
    if grpc_service_config:
        plugin_file_args[grpc_service_config] = "grpc-service-config"
    if common_resources_config:
        plugin_file_args[common_resources_config] = "common-resources-config"
    if service_yaml:
        plugin_file_args[service_yaml] = "service-config"
    if rest_numeric_enums:
        plugin_args.append("rest-numeric-enums")
    proto_custom_library(
        name = name_srcjar,
        deps = srcs,
        plugin = Label(generator_binary),
        plugin_file_args = plugin_file_args,
        output_type = "gapic",
        output_suffix = ".srcjar",
        **kwargs
    )
    _csharp_gapic_library_add_gapicinfo(
        name = name,
        output = ":{name_srcjar}".format(name_srcjar = name_srcjar),
    )
