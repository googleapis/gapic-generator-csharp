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
set -e

mkdir local_tmp
ln -s {restore}/packages .
cp -r {restore}/src .

export DOTNET_CLI_HOME="$(pwd)/local_tmp"
export XDG_DATA_HOME="$(pwd)/local_tmp"
export DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1
export DOTNET_CLI_TELEMETRY_OPTOUT=1
export DOTNET_NOLOGO=1
export DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1

# Running this command twice, if the first invocation fails, try once more
# [virost, 03/2021] temporarily until I figure out what causes intermittent Kokoro failures
cmd="{csharp_compiler}/dotnet build src/{csproj_relative} \
  --framework {framework} --configuration {configuration} \
  --no-restore --nologo --verbosity=quiet --packages packages"

$cmd || $cmd

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
set -e

export DOTNET_CLI_HOME="$(pwd)/local_tmp"
export XDG_DATA_HOME="$(pwd)/local_tmp"
export DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1
export DOTNET_CLI_TELEMETRY_OPTOUT=1
export DOTNET_NOLOGO=1
export DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1

# Running this command twice, if the first invocation fails, try once more
# [virost, 03/2021] temporarily until I figure out what causes intermittent Kokoro failures
cmd="$(dirname $0)/run.sh.runfiles/$(basename $(pwd))/{csharp_compiler}/dotnet run \
  --project $(dirname $0)/run.sh.runfiles/$(basename $(pwd))/{out}/{csproj_relative} \
  --no-restore --no-build"

$cmd || $cmd
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
        "framework": attr.string(default="net6.0"),
        "configuration": attr.string(default="Debug"),
    },
    executable = True,
)
