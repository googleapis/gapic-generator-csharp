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
    obj_out_dir = ctx.actions.declare_directory("obj")
    bin_out_dir = ctx.actions.declare_directory("bin")
    if ctx.attr.runtime:
        verb = "publish"
        publish_args = "--self-contained --runtime=" + ctx.attr.runtime
    else:
        verb = "build"
        publish_args = ""
    if ctx.attr.src_base and ctx.attr.csproj_name:
        src_base_path = ctx.file.src_base.path
        csproj_name = ctx.attr.csproj_name
        inputs = [ctx.file.src_base]
        build_path = "build"
        command = """
mkdir local_tmp;
mkdir {build_path};
cp -r {src_base_path}/* {build_path};
cp -r {restore_packages_path} {build_path};
cp -rH {restore_obj_path} {build_path};
{csharp_compiler_path}/dotnet {verb} {build_path}/{csproj_name} --no-restore --nologo --verbosity=quiet --packages {restore_packages_path} {publish_args};
cp -r {build_path}/obj/* {obj_out_path};
cp -r {build_path}/bin/* {bin_out_path};
        """.format(
            build_path = build_path,
            src_base_path = src_base_path, #ctx.file.src_base.path,
            restore_packages_path = ctx.file.restore_packages.path,
            restore_obj_path = ctx.file.restore_obj.path,
            csproj_name = csproj_name, #ctx.attr.csproj_name,
            csharp_compiler_path = ctx.file.csharp_compiler.path,
            verb = verb,
            publish_args = publish_args,
            obj_out_path = obj_out_dir.path,
            bin_out_path = bin_out_dir.path,
        )
    elif ctx.attr.csproj:
        src_base_path = ctx.file.csproj.dirname
        csproj_name = ctx.file.csproj.basename
        inputs = ctx.files.srcs + [ctx.file.csproj]
        command = """
mkdir local_tmp;
cp -rH {restore_obj_path} .;
{csharp_compiler_path}/dotnet {verb} ./{csproj_name} --framework {framework} --configuration {configuration} --no-restore --nologo --verbosity=quiet --packages {restore_packages_path} {publish_args};
cp -r ./obj/* {obj_out_path};
cp -r ./bin/* {bin_out_path};
        """.format(
            restore_packages_path = ctx.file.restore_packages.path,
            restore_obj_path = ctx.file.restore_obj.path,
            csproj_name = csproj_name, #ctx.attr.csproj_name,
            csharp_compiler_path = ctx.file.csharp_compiler.path,
            verb = verb,
            framework = ctx.attr.framework,
            configuration = ctx.attr.configuration,
            publish_args = publish_args,
            obj_out_path = obj_out_dir.path,
            bin_out_path = bin_out_dir.path,
        )
    else:
        fail("no csproj specified")
    ctx.actions.run_shell(
        tools = [ctx.file.csharp_compiler],
        inputs = [ctx.file.restore_packages, ctx.file.restore_obj] + inputs,
        outputs = [obj_out_dir, bin_out_dir],
        env = {
            "DOTNET_CLI_HOME": "./local_tmp/",
            "DOTNET_SKIP_FIRST_TIME_EXPERIENCE": "1",
            "DOTNET_CLI_TELEMETRY_OPTOUT": "1",
        },
        command = command,
    )
    if ctx.attr.runtime:
        out_run_sh = ctx.actions.declare_file("run.sh")
        run_sh_contents = """#!/bin/bash
cd $(dirname $0)
bin/{configuration}/{framework}/{runtime}/publish/{exe_name}
        """.format(
            configuration = ctx.attr.configuration,
            framework = ctx.attr.framework,
            runtime = ctx.attr.runtime,
            exe_name = csproj_name[:csproj_name.rindex('.')], # remove tailing `.csproj`
        )
        ctx.actions.write(out_run_sh, run_sh_contents, is_executable=True)
        runfiles = ctx.runfiles(files=[out_run_sh, bin_out_dir])
    else:
        out_run_sh = ctx.actions.declare_file("run.sh")
        run_sh_contents = """#!/bin/bash
{csharp_compiler}/dotnet run --project ./{csproj} --no-restore --no-build
        """.format(
            csharp_compiler = ctx.file.csharp_compiler.path,
            csproj = ctx.file.csproj.path,
        )
        ctx.actions.write(out_run_sh, run_sh_contents, is_executable=True)
        runfiles = ctx.runfiles(files=[out_run_sh, obj_out_dir, bin_out_dir, ctx.file.csharp_compiler, ctx.file.csproj])

    return [DefaultInfo(
        files=depset(direct=[obj_out_dir, bin_out_dir]),
        runfiles=runfiles,
        executable=out_run_sh,
    )]

csharp_binary = rule(
    implementation = _csharp_binary_impl,
    attrs = {
        "csharp_compiler": attr.label(default=Label("@csharp_compiler//:dotnet_compiler"), allow_single_file=True, executable=True, cfg="host"),
        "restore_packages": attr.label(allow_single_file=True),
        "restore_obj": attr.label(allow_single_file=True),
        "src_base": attr.label(allow_single_file=True),
        "csproj_name": attr.string(), # Must be directly in `src_base` directory
        "srcs": attr.label_list(allow_files=True),
        "csproj": attr.label(allow_single_file=True),
        "runtime": attr.string(), # Empty to not build a specific runtime
        "framework": attr.string(default="netcoreapp3.1"),
        "configuration": attr.string(default="Debug"),
    },
    executable = True,
)
