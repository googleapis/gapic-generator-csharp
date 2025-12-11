#!/bin/bash
# Copyright 2025 Google LLC
#
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
#
#     http://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.

set -eo pipefail

apt-get update -y
apt-get install -y jq

GAPIC_GENERATOR_COMMIT=$1
if [[ -z "${GAPIC_GENERATOR_COMMIT}" ]]
then
  echo "GAPIC_GENERATOR_COMMIT not set, trying default"
  echo "Usage: $0 <commit-sha>"
  exit 1
fi

git clone --depth=1 https://github.com/googleapis/googleapis
pushd googleapis

# debug bazel version
bazelisk --version

echo "Testing gapic-generator-csharp with ${GAPIC_GENERATOR_COMMIT}"

# update current version of gapic-generator-csharp
jq ".csharp.commit = \"${GAPIC_GENERATOR_COMMIT}\" | .csharp.version = null | .csharp.sha = null" generator-versions.json > generator-versions2.json
mv generator-versions2.json generator-versions.json
cat generator-versions.json

# determine where bazel will output files
BAZEL_BIN=$(bazelisk info bazel-bin)

# try generating the google/example/library/v1 csharp gapic library
bazelisk build //google/example/library/v1:google-cloud-example-library-v1-csharp

# ensure we created the tarball we expect
ls -al "${BAZEL_BIN}/google/example/library/v1/google-cloud-example-library-v1-csharp.tar.gz"

# try generating the google/ads/googleads/v20 csharp gapic library
bazelisk build //google/ads/googleads/v20:googleads-csharp

# ensure we created the tarball we expect
ls -al "${BAZEL_BIN}/google/ads/googleads/v20/googleads-csharp.tar.gz"

popd