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


def _csharp_binary_impl(ctx):
    out_dir = ctx.actions.declare_directory("out")
    out_run_sh = ctx.actions.declare_file("run.sh")
    csproj_relative = ctx.file.csproj.path[len(ctx.attr.csproj.label.workspace_root):].strip("/")
    command = """
mkdir local_tmp
ln -s {restore}/packages .
cp -r {restore}/src .
DOTNET_CLI_HOME="$(pwd)/local_tmp" \
DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1 \
DOTNET_CLI_TELEMETRY_OPTOUT=1 \
DOTNET_NOLOGO=1 \
{csharp_compiler}/dotnet build src/{csproj_relative} \
  --framework {framework} --configuration {configuration} \
  --no-restore --nologo --verbosity=quiet --packages packages
cp -r src/* {out}/
    """.format(
        restore = ctx.file.restore.path,
        csharp_compiler = ctx.file.csharp_compiler.path,
        csproj_relative = csproj_relative,
        framework = ctx.attr.framework,
        configuration = ctx.attr.configuration,
        out = out_dir.path,
    )
    ctx.actions.run_shell(
        tools = [ctx.file.csharp_compiler],
        inputs = [ctx.file.restore],
        outputs = [out_dir],
        command = command,
    )
    run_sh = """#!/bin/bash
DOTNET_CLI_HOME="$(pwd)/local_tmp" \
DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1 \
DOTNET_CLI_TELEMETRY_OPTOUT=1 \
DOTNET_NOLOGO=1 \
$(dirname $0)/run.sh.runfiles/__main__/{csharp_compiler}/dotnet run \
  --project $(dirname $0)/run.sh.runfiles/__main__/{out}/{csproj_relative} \
  --no-restore --no-build
    """.format(
        csharp_compiler = ctx.file.csharp_compiler.short_path,
        out = out_dir.short_path,
        csproj_relative = csproj_relative,
    )
    ctx.actions.write(out_run_sh, run_sh, is_executable=True)
    return [DefaultInfo(
        files=depset([out_dir]),
        runfiles=ctx.runfiles([out_run_sh, out_dir, ctx.file.csharp_compiler]),
        executable=out_run_sh,
    )]

csharp_binary = rule(
    implementation = _csharp_binary_impl,
    attrs = {
        "csharp_compiler": attr.label(default=Label("@csharp_compiler//:dotnet_compiler"), allow_single_file=True, executable=True, cfg="host"),
        "restore": attr.label(allow_single_file=True),
        "csproj": attr.label(allow_single_file=True),
        "framework": attr.string(default="netcoreapp3.1"),
        "configuration": attr.string(default="Debug"),
    },
    executable = True,
)
