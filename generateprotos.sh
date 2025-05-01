#!/bin/bash

# Uses protoc and the gRPC plugin in tools to generate
# all the protos we use:
#
# - protoc compiler plugin
# - Generator config protos (e.g. service config, snippets)
# - GAPIC ShowCase

# Cross-platform tools
case "$OSTYPE" in
  win* | msys* | cygwin*)
    protoc_executable="tools/protoc.exe" # default to Windows
    grpc_csharp_executable="tools/grpc_csharp_plugin.exe" # default to Windows
    ;; 
  linux*)
    protoc_executable="tools/protoc"
    grpc_csharp_executable="tools/grpc_csharp_plugin"
    ;;
  darwin*)
    protoc_executable="tools/protoc_macosx_x64"
    grpc_csharp_executable="tools/grpc_csharp_plugin_macosx_x64"
    chmod +x tools/protoc_macosx_x64
    chmod +x tools/grpc_csharp_plugin_macosx_x64
    ;;
  *)
    echo "Unknown OSTYPE: $OSTYPE"
    exit 1
esac

# Generator config protos
echo "Generating generator config protos"
"$protoc_executable" \
  --csharp_out=Google.Api.Generator/ConfigProtos \
  -Itools/protos \
  -Igoogleapis \
  -IGoogle.Api.Generator/ConfigProtos \
  Google.Api.Generator/ConfigProtos/*.proto

# GAPIC Showcase
echo "Generating GAPIC Showcase"
"$protoc_executable" \
  --csharp_out=Google.Api.Generator.Tests/ProtoTests/Showcase \
  --csharp_opt=file_extension=.g.cs \
  --plugin=protoc-gen-grpc="$grpc_csharp_executable" \
  --grpc_out=Google.Api.Generator.Tests/ProtoTests/Showcase \
  --grpc_opt=file_suffix=Grpc.g.cs \
  -Itools/protos \
  -Igoogleapis \
  -IGoogle.Api.Generator.Tests/ProtoTests/Showcase \
  Google.Api.Generator.Tests/ProtoTests/Showcase/google/showcase/v1beta1/*.proto

echo "Done"
