#!/bin/bash

set -e

if [[ -z "$1" ]]
then
  echo Please specify the NuGet package version to fetch.
  exit 1
fi

# Bash on Windows seems to have odd behavior when copying/moving
# executables with the same name but different extensions.
# If the files both exist to start with, it's fine.
touch protoc
touch protoc.exe

rm -rf tmp
mkdir tmp
cd tmp

curl -sSL https://www.nuget.org/api/v2/package/Google.Protobuf.Tools/$1 --output tmp.zip
unzip -q tmp.zip

mv tools/windows_x64/protoc.exe ..
mv tools/linux_x64/protoc ..
mv tools/macosx_x64/protoc ../protoc_macosx_x64
cp tools/google/protobuf/* ../protos/google/protobuf

cd ..
rm -rf tmp
