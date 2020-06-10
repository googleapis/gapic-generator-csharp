
def _csharp_compiler_impl(ctx):
    ctx.download_and_extract(
        url="https://download.visualstudio.microsoft.com/download/pr/f65a8eb0-4537-4e69-8ff3-1a80a80d9341/cc0ca9ff8b9634f3d9780ec5915c1c66/dotnet-sdk-3.1.201-linux-x64.tar.gz",
        sha256="222f5363d2ab9f2aa852846bc0745c449677d1cccf8c8407cd0a44d3299cc7be",
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
    if ctx.attr.runtime:
        runtime_arg = ["--runtime=" + ctx.attr.runtime]
    else:
        runtime_arg = []
    res = ctx.execute(
        [
            csharp_compiler_path,
            "restore",
            csproj_name,
            "--packages=packages",
        ] + runtime_arg,
        environment = {
            "DOTNET_CLI_HOME": "/tmp/",
            "DOTNET_SKIP_FIRST_TIME_EXPERIENCE": "1",
            "DOTNET_CLI_TELEMETRY_OPTOUT": "1",
        },
    )
    if res.return_code != 0:
        fail("""Failed to execute command: `{command}`{newline}Exit Code: {code}{newline}STDERR: {stderr}{newline}""".format(
            command = "dotnet",
            code = res.return_code,
            stderr = res.stderr,
            newline = "\n"
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
        "runtime": attr.string(), # Empty to for no runtime
    },
)

def _gapic_generator_src_impl(ctx):
    ctx.download_and_extract(
        url="https://github.com/googleapis/gapic-generator-csharp/archive/v1.0.0-beta05.tar.gz",
        sha256="08dc5ed561326d80ccce591bbb663a607bf6d3fc37211e75183474f1908206a1",
        output="gen_dest",
    )
    ctx.file(
        "BUILD",
        """exports_files(glob(include = ["gen_dest/**"], exclude_directories = 0))""",
    )

gapic_generator_src = repository_rule(
    implementation = _gapic_generator_src_impl,
)
