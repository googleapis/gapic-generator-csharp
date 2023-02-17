#!/bin/bash

# Uses protoc and the gRPC plugin in tools to generate
# all the protos we use:
#
# - protoc compiler plugin
# - Generator config protos (e.g. service config, snippets)
# - GAPIC ShowCase
#
# Currently this script is hard-coded to use protoc.exe,
# so it only runs on Windows; we can use platform detection
# if that ever becomes an issue.

# Generator config protos
echo "Generating generator config protos"
tools/protoc.exe \
  --csharp_out=Google.Api.Generator/ConfigProtos \
  -Itools/protos \
  -Igoogleapis \
  -IGoogle.Api.Generator/ConfigProtos \
  Google.Api.Generator/ConfigProtos/*.proto

# GAPIC Showcase
echo "Generating GAPIC Showcase"
tools/protoc.exe \
  --csharp_out=Google.Api.Generator.Tests/ProtoTests/Showcase \
  --csharp_opt=file_extension=.g.cs \
  --plugin=protoc-gen-grpc=tools/grpc_csharp_plugin.exe \
  --grpc_out=Google.Api.Generator.Tests/ProtoTests/Showcase \
  --grpc_opt=file_suffix=Grpc.g.cs \
  -Itools/protos \
  -Igoogleapis \
  -IGoogle.Api.Generator.Tests/ProtoTests/Showcase \
  Google.Api.Generator.Tests/ProtoTests/Showcase/google/showcase/v1beta1/*.proto

echo "Done"
