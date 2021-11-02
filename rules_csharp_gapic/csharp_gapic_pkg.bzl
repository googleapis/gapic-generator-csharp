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

load("@rules_gapic//:gapic.bzl", "GapicInfo")

def _csharp_gapic_assembly_pkg_impl(ctx):
    out_dir = ctx.actions.declare_directory(ctx.attr.package_dir)
    out_tar = ctx.actions.declare_file("{dir}.tar.gz".format(dir = ctx.attr.package_dir))
    gapic_zip = None
    extras = []
    for dep in ctx.attr.deps:
        if GapicInfo in dep:
            gapic_zip = dep.files.to_list()[0]
        else:
            extras = extras + dep.files.to_list()

    command = ""
    inputs = None
    if ctx.attr.generate_nongapic_package:
        if not ctx.attr.package_name:
            err_msg = ("If `generate_nongapic_package` attribute is set to true, " +
                    "the `package_name` attribute has to be specified as well"
            )
            fail(err_msg)
    
        inputs = extras
        command =  """
for extra in {extras}; do
    {zipper} x $extra -d {out_dir}/{package_name}
done
tar -czhpf {out_tar} -C {out_dir}/.. {pkg_name}
            """.format(
                zipper = ctx.executable._zipper.path,
                extras = " ".join(["'%s'" % f.path for f in extras]),
                out_dir = out_dir.path,
                out_tar = out_tar.path,
                package_name = ctx.attr.package_name,
                pkg_name = ctx.attr.name,
            )
    else:
        if ctx.attr.package_name:
            err_msg = ("If `generate_nongapic_package` is not specified or set to false, " +
                    "the `package_name` attribute is redundant, because it will be inferred."
            )
            fail(err_msg)

        if gapic_zip == None:
            err_msg = ("If `generate_nongapic_package` is not specified or set to false, " +
                    "one of the dependencies should be an output of the csharp_gapic_library rule."
            )
            fail(err_msg)

        inputs =  [gapic_zip] + extras
        command = """
{zipper} x {gapic_zip} -d {out_dir}
CLIENT_NAME=$(ls -1 {out_dir} | sort | head -n 1)
for extra in {extras}; do
    {zipper} x $extra -d {out_dir}/$CLIENT_NAME
done
tar -czhpf {out_tar} -C {out_dir}/.. {pkg_name}
        """.format(
            zipper = ctx.executable._zipper.path,
            gapic_zip = gapic_zip.path,
            extras = " ".join(["'%s'" % f.path for f in extras]),
            out_dir = out_dir.path,
            out_tar = out_tar.path,
            pkg_name = ctx.attr.name,
        )
    
    ctx.actions.run_shell(
        inputs = inputs,
        outputs = [out_dir, out_tar],
        tools = [ctx.executable._zipper],
        command = command,
    )
    return [DefaultInfo(
        files = depset(direct = [out_tar]),
    )]

_csharp_gapic_assembly_pkg = rule(
    implementation = _csharp_gapic_assembly_pkg_impl,
    attrs = {
        "deps": attr.label_list(mandatory = True, allow_files = True),
        "package_dir": attr.string(mandatory = True),
        "package_name": attr.string(),
        "generate_nongapic_package": attr.bool(),
        "_zipper": attr.label(default = Label("@bazel_tools//tools/zip:zipper"), cfg = "host", executable = True),
    },
)

def csharp_gapic_assembly_pkg(name, deps, **kwargs):
    _csharp_gapic_assembly_pkg(
        name = name,
        deps = deps,
        package_dir = name,
        **kwargs
    )
