#!/bin/bash

# This script:
# - Builds the Generator solution in Release mode
# - Starts GAPIC Showcase
# - Runs integration tests for the Generator projects in Release mode
# - Tears down GAPIC Showcase on exit

set -e

cd "$(dirname "$0")"

export DOTNET_NOLOGO=true

CONFIG=Release
DOTNET_BUILD_ARGS="-c $CONFIG"
DOTNET_TEST_ARGS="--no-build $DOTNET_BUILD_ARGS"

echo "Building the solution in $CONFIG mode"
dotnet build $DOTNET_BUILD_ARGS Generator.sln

cleanup() {
  echo "Tearing down GAPIC Showcase"
  if [ -f showcase.pid ]; then
    kill "$(cat showcase.pid)" 2>/dev/null || true
    rm -f showcase.pid
  fi
  rm -f gapic-showcase gapic-showcase.exe
}
trap cleanup EXIT

echo "Setup GAPIC Showcase for standard integration tests"
./startshowcase.sh --port :7469

export SHOWCASE_ENDPOINT=http://localhost:7469
dotnet test $DOTNET_TEST_ARGS Google.Api.Generator.IntegrationTests

echo "Setup GAPIC Showcase with TLS for PQC integration tests"
./startshowcase.sh --port :7469 --tls

export SHOWCASE_ENDPOINT=https://localhost:7469
dotnet test $DOTNET_TEST_ARGS Google.Api.Generator.IntegrationTests --filter "FullyQualifiedName~Pqc"

echo "Integration testing completed"
