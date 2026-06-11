#!/bin/bash

# This script:
# - Builds the Generator solution in Release mode
# - Runs unit tests for the Generator projects in Release mode

set -ex

# To avoid printing the dotnet CLI welcome message
export DOTNET_NOLOGO=true

echo "Building the solution in Release mode"
dotnet build Generator.sln -c Release

echo "Unit testing Generator projects in Release mode"
# Using --no-build since we already built the whole solution above
dotnet test --no-build -c Release Google.Api.Generator.Utils.Tests
dotnet test --no-build -c Release Google.Api.Generator.Tests
dotnet test --no-build -c Release Google.Api.Generator.Rest.Tests

echo "Build and unit testing completed"
