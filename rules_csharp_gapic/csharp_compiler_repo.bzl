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

def _csharp_compiler_impl(ctx):
    ctx.download_and_extract(
        url="https://download.visualstudio.microsoft.com/download/pr/8db2b522-7fa2-4903-97ec-d6d04d297a01/f467006b9098c2de256e40d2e2f36fea/dotnet-sdk-3.1.301-linux-x64.tar.gz",
        sha256="a0c416bb57f7e16a4767e7cd4dbeab80386fffc354ee7cdc68d367694bc40269",
        output="dotnet_compiler",
    )
    ctx.file(
        "BUILD",
        """exports_files(glob(include = ["dotnet_compiler/**"], exclude_directories = 0))"""
    )

csharp_compiler = repository_rule(
    implementation = _csharp_compiler_impl,
)

def _dotnet_restore_impl(ctx):
    if ctx.attr.src_base and ctx.attr.csproj_name:
        if ctx.attr.csproj:
          fail("csproj cannot be specified as well as src_base and csproj_name")
        # See: https://github.com/bazelbuild/bazel/issues/3901
        csproj = ctx.path(Label(str(ctx.attr.src_base) + "/" + ctx.attr.csproj_name))
        src_base_path = str(csproj.dirname)
        csproj_name = ctx.attr.csproj_name
    elif ctx.attr.csproj:
        if ctx.attr.src_base or ctx.attr.csproj_name:
            fail("csproj cannot be specified as well as src_base and csproj_name")
        csproj = ctx.path(ctx.attr.csproj)
        src_base_path = str(csproj.dirname)
        csproj_name = csproj.basename
    else:
        fail("no csproj specified")
    csharp_compiler_path = ctx.path(ctx.attr.csharp_compiler)
    # The entire directory tree should really be copied,
    # but doing so causes a bazel error.
    # So only copy the single csproj for now.
    ctx.execute(["cp", src_base_path+"/"+csproj_name, "."])
    ctx.execute(["mkdir", "packages"])
    ctx.execute(["mkdir", "local_tmp"])
    if ctx.attr.runtime:
        runtime_arg = ["--runtime=" + ctx.attr.runtime]
    else:
        runtime_arg = []
    res = ctx.execute(
        [
            csharp_compiler_path,
            "restore",
            csproj_name,
            "--verbosity=quiet",
            "--packages=packages",
        ] + runtime_arg,
        environment = {
            "DOTNET_CLI_HOME": "./local_tmp/",
            "DOTNET_SKIP_FIRST_TIME_EXPERIENCE": "1",
            "DOTNET_CLI_TELEMETRY_OPTOUT": "1",
        },
    )
    if res.return_code != 0:
        fail("Failed to execute command: `{command}`\nExit Code: {code}\nSTDERR: {stderr}\n".format(
            command = "dotnet",
            code = res.return_code,
            stderr = res.stderr,
        ))
    ctx.file(
        "BUILD",
        """exports_files(glob(include = ["packages/**", "obj/**"], exclude_directories = 0))"""
    )

dotnet_restore = repository_rule(
    implementation = _dotnet_restore_impl,
    attrs = {
        "csharp_compiler": attr.label(default=Label("@csharp_compiler//:dotnet_compiler/dotnet"), allow_single_file=True, executable=True, cfg="host"),
        # Specify src_base and csproj_name or only csproj
        "src_base": attr.label(allow_single_file=True),
        "csproj_name": attr.string(), # Must be directly in `src_base` directory.
        "csproj": attr.label(allow_single_file=True),
        "runtime": attr.string(), # Empty to not build a specific native runtime
    },
)
