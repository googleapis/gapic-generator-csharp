#!/bin/bash

set -e

# Simple script to run the generator on the Translate and Webfonts APIs
# This is simply to aid development of the REST generator.

dotnet run -p Google.Api.Generator.Rest Google.Api.Generator.Rest.Tests/GoldenTestData/Google.Apis.Translate.v2/discovery.json tmp
dotnet run --no-build -p Google.Api.Generator.Rest Google.Api.Generator.Rest.Tests/GoldenTestData/Google.Apis.Webfonts.v1/discovery.json tmp
dotnet run --no-build -p Google.Api.Generator.Rest Google.Api.Generator.Rest.Tests/GoldenTestData/Google.Apis.Storage.v1/discovery.json tmp
