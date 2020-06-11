
load("@bazel_tools//tools/build_defs/repo:http.bzl", "http_archive")
load("@bazel_tools//tools/build_defs/repo:utils.bzl", "maybe")
load("//rules_csharp_gapic:csharp_compiler_repo.bzl", "csharp_compiler", "gapic_generator_src", "dotnet_restore")

def com_googleapis_gapic_generator_csharp_repositories():
    maybe(
        http_archive,
        name = "com_google_api_codegen",
        strip_prefix = "gapic-generator-a79e9ea3fcf686a80d92461a4788c5bcf55cea5a",
        urls = ["https://github.com/googleapis/gapic-generator/archive/a79e9ea3fcf686a80d92461a4788c5bcf55cea5a.zip"],
        sha256 = "c6a13fd221189458ad9eeb1de1f40e21bd80f0063bf05b9fa243722c18577f17",
    )
    maybe(
        csharp_compiler,
        name = "csharp_compiler",
    )
    maybe(
        gapic_generator_src,
        name = "gapic_generator_src",
    )
    maybe(
        dotnet_restore,
        name = "gapic_generator_restore",
        src_base = "@gapic_generator_src//:gen_dest/gapic-generator-csharp-1.0.0-beta05/Google.Api.Generator",
        csproj_name = "Google.Api.Generator.csproj",
        runtime = "linux-x64",
    )
