#!/bin/sh

../../tools/protoc.exe -I. -I../../tools/protos -I../../googleapis --csharp_out=. *.proto
