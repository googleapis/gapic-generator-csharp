
load("@com_google_api_codegen//rules_gapic:gapic.bzl", "proto_custom_library")

def _full_gapic_impl(ctx):
    out_dir = ctx.actions.declare_directory('full')
    ctx.actions.run_shell(
        inputs = [ctx.file.proto, ctx.file.grpc, ctx.file.gapic],
        outputs = [out_dir],
        tools = [ctx.executable._zipper],
        command = """
{zipper} x {gapic} -d {out}
CLIENT_NAME=$(ls -1 {out} | head -n 1)
{zipper} x {proto} -d {out}/$CLIENT_NAME
{zipper} x {grpc} -d {out}/$CLIENT_NAME
""".format(
            zipper = ctx.executable._zipper.path,
            proto = ctx.file.proto.path,
            grpc = ctx.file.grpc.path,
            gapic = ctx.file.gapic.path,
            out = out_dir.path,
        )
    )
    return [DefaultInfo(
        files = depset(direct = [out_dir])
    )]

full_gapic = rule(
    implementation = _full_gapic_impl,
    attrs = {
        "proto": attr.label(allow_single_file=True),
        "grpc": attr.label(allow_single_file=True),
        "gapic": attr.label(allow_single_file=True),
        "_zipper": attr.label(default = Label("@bazel_tools//tools/zip:zipper"), cfg = "host", executable=True),
    },
)

def csharp_proto_library(name, deps, **kwargs):
    # Build zip file of protoc output
    proto_custom_library(
        name = name,
        deps = deps,
        output_type = "csharp",
        output_suffix = ".zip",
        extra_args = [
            "--include_source_info",
        ],
        **kwargs
    )

def csharp_grpc_library(name, srcs, **kwargs):
    # Build zip file of grpc output
    proto_custom_library(
        name = name,
        deps = srcs,
        plugin = Label("@com_github_grpc_grpc//src/compiler:grpc_csharp_plugin"),
        output_type = "grpc",
        output_suffix = ".zip",
        extra_args = [
            "--include_source_info",
        ],
        **kwargs
    )

def csharp_gapic_library(name, srcs, proto = None, grpc = None, **kwargs):
    # Build zip file of gapic-generator output
    proto_custom_library(
        name = name,
        deps = srcs,
        plugin = Label("//rules_csharp_gapic:generator_binary"),
        output_type = "gapic",
        output_suffix = ".zip",
        extra_args = [
            "--include_source_info",
        ],
        **kwargs
    )
    if proto and grpc:
        # Build 'full' output of proto+grpc+gapic output, with all files in the correct locations
        # for building. This target is named '{name}_full' is created in the 'full/' directory.
        full_gapic(
            name = "{name}_full".format(name = name),
            proto = proto,
            grpc = grpc,
            gapic = name,
        )
    elif proto or grpc:
        fail('Both `proto` and `grpc` must be specified.')
