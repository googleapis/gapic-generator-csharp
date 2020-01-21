#!/bin/sh

../../tools/protoc.exe -I. -I../../tools/protos -I../../api-common-protos --csharp_out=. *.proto
