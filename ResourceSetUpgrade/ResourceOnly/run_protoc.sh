#!/bin/sh

# This will only work on Chris' machine ;)
../../tools/protoc.exe --csharp_out=. --plugin=protoc-gen-grpc="C:\Users\chrisbacon\bin\grpc_csharp_plugin.exe" --plugin=protoc-gen-gapic="C:\chrisdunelm\gapic-generator-csharp\Google.Api.Generator\bin\Debug\netcoreapp2.2\win-x64\publish\Google.Api.Generator.exe" --grpc_out=. --gapic_out=. -I. -I../../api-common-protos -I../../protobuf/src Logging.proto
