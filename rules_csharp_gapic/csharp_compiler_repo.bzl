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
        url="https://download.visualstudio.microsoft.com/download/pr/d3e46476-4494-41b7-a628-c517794c5a6a/6066215f6c0a18b070e8e6e8b715de0b/dotnet-sdk-6.0.402-linux-x64.tar.gz",
        sha256="635f25082b1074f76dc6617062f339201908bb523d7fa6eba46795d6bca3ee85",
        output="dotnet_compiler",
    )
    ctx.file(
        "BUILD",
        """exports_files(glob(include = ["dotnet_compiler/**"], exclude_directories = 0))"""
    )

csharp_compiler = repository_rule(
    implementation = _csharp_compiler_impl,
)

def _find_ws_root(path):
    for _ in range(10):
        if path.get_child('WORKSPACE').exists or path.get_child('WORKSPACE.bazel').exists:
            return path
        path = path.dirname
    fail("Cannot find workspace root.")

def _dotnet_restore_impl(ctx):
    ws_path = _find_ws_root(ctx.path(ctx.attr.csproj).dirname)
    csproj_relative = str(ctx.path(ctx.attr.csproj))[len(str(ws_path)):]
    # Copy entire source workspace into the restored repo, then run `dotnet restore`.
    # The entire workspace is required, as the entry csproj may reference
    # arbitrary other files and projects.
    # This copy is also used during the build phase, as it has all files available
    # and arbitrary files may be accessed.
    ctx.execute(["mkdir", "restore"])
    ctx.execute(["mkdir", "restore/packages"])
    ctx.execute(["mkdir", "local_tmp"])
    ctx.execute(["cp", "-rHs", "--preserve=links", str(ws_path), "restore"])
    ctx.execute(["mv", "restore/" + ws_path.basename, "restore/src"])
    command = [
            str(ctx.path(ctx.attr.csharp_compiler)),
            "restore",
            "restore/src" + csproj_relative,
            "--packages=restore/packages",
            "--verbosity=quiet",
        ]
    for _ in range(3):
        # This is flakey for unknown reason(s).
        # So try it up to three times
        res = ctx.execute(
            command,
            environment = {
                "DOTNET_CLI_HOME": str(ctx.path('.')) + "/local_tmp/",
                "DOTNET_SKIP_FIRST_TIME_EXPERIENCE": "1",
                "DOTNET_CLI_TELEMETRY_OPTOUT": "1",
                "DOTNET_NOLOGO": "1",
                "DOTNET_SYSTEM_GLOBALIZATION_INVARIANT": "1",
            },
        )
        if res.return_code == 0:
            break
    if res.return_code != 0:
        fail("Failed to execute command: `{command}`\nExit Code: {code}\nSTDERR: {stderr}\nSTDOUT: {stdout}".format(
            command = " ".join(command),
            code = res.return_code,
            stderr = res.stderr,
            stdout = res.stdout,
        ))
    ctx.file(
        "BUILD",
        'exports_files(["restore"])'
    )

dotnet_restore = repository_rule(
    implementation = _dotnet_restore_impl,
    attrs = {
        "csharp_compiler": attr.label(default=Label("@csharp_compiler//:dotnet_compiler/dotnet"), allow_single_file=True, executable=True, cfg="host"),
        "csproj": attr.label(allow_single_file=True),
    },
)
