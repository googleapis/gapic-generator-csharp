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
