# Copyright 2021 Google LLC
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

def _csharp_nongapic_assembly_pkg_impl(ctx):
    out_dir = ctx.actions.declare_directory(ctx.attr.package_dir)
    out_tar = ctx.actions.declare_file("{dir}.tar.gz".format(dir = ctx.attr.package_dir))
    extras = []
    for dep in ctx.attr.deps:
        extras = extras + dep.files.to_list()

    ctx.actions.run_shell(
        inputs = extras,
        outputs = [out_dir, out_tar],
        tools = [ctx.executable._zipper],
        command = """
for extra in {extras}; do
    {zipper} x $extra -d {out_dir}/{csharp_package}
done
tar -czhpf {out_tar} -C {out_dir}/.. {pkg_name}
        """.format(
            zipper = ctx.executable._zipper.path,
            extras = " ".join(["'%s'" % f.path for f in extras]),
            out_dir = out_dir.path,
            out_tar = out_tar.path,
            csharp_package = ctx.attr.csharp_package,
            pkg_name = ctx.attr.name,
        ),
    )
    return [DefaultInfo(
        files = depset(direct = [out_tar]),
    )]

_csharp_nongapic_assembly_pkg = rule(
    implementation = _csharp_nongapic_assembly_pkg_impl,
    attrs = {
        "deps": attr.label_list(mandatory = True, allow_files = True),
        "package_dir": attr.string(mandatory = True),
        "csharp_package": attr.string(mandatory = True),
        "_zipper": attr.label(default = Label("@bazel_tools//tools/zip:zipper"), cfg = "host", executable = True),
    },
)

def csharp_nongapic_assembly_pkg(name, deps, csharp_package, **kwargs):
    _csharp_nongapic_assembly_pkg(
        name = name,
        deps = deps,
        package_dir = name,
        csharp_package = csharp_package,
        **kwargs
    )
