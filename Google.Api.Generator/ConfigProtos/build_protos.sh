#!/bin/sh

../../tools/protoc.exe -I. -I../../protobuf/src -I../../api-common-protos --csharp_out=. *.proto
