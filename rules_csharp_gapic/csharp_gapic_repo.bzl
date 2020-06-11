
def _gapic_generator_src_impl(ctx):
    ctx.download_and_extract(
        url = "https://github.com/googleapis/gapic-generator-csharp/archive/v1.0.0-beta06.tar.gz",
        stripPrefix = "gapic-generator-csharp-1.0.0-beta06",
        sha256 = "93d2499651b35b43a122253aea060beeaf91fdcbcb9f7993863b1d3ae02bfd5e",
        output = "gen_dest",
    )
    ctx.file(
        "BUILD",
        """exports_files(glob(include = ["gen_dest/**"], exclude_directories = 0))""",
    )

gapic_generator_src = repository_rule(
    implementation = _gapic_generator_src_impl,
)
