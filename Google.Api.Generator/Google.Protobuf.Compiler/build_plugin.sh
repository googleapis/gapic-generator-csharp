#!/bin/sh

../../tools/protoc.exe \
  --csharp_out=. \
  -I../../tools/protos \
  -I. \
  plugin.proto
