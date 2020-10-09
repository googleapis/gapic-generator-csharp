#!/bin/sh

set -e

# Generates all REST APIs present in a google-api-dotnet-client repo
# using Google.Api.Generator.Rest, and compares the results with the
# Python-generated code.

if [[ -z "$1" ]]
then
  echo "Required argument: path to root directory of google-api-dotnet-client repo"
  exit 1
fi

declare -r CLIENT_REPO=$(realpath $1)

rm -rf tmp
mkdir tmp

dotnet build -nologo -clp:NoSummary -v quiet Google.Api.Generator.Rest

# Generate all the code with the C# generator, into a "Src/Generated" directory
# to make it easier to run the existing post-generation patching code.
for json in $CLIENT_REPO/DiscoveryJson/*.json
do
  echo "Generating $(basename $json)"
  dotnet run --no-build -p Google.Api.Generator.Rest -- $json tmp/Src/Generated

  # Run a post-generation script if there is one
  IFS='/'; names=($json); unset IFS
  name=$(echo ${names[-1]} | sed 's/.json//g')
  if [[ -f $CLIENT_REPO/PostGeneration/$name.sh ]]
  then
    echo "Running post-generation step for $name"
    $(cd tmp && $CLIENT_REPO/PostGeneration/$name.sh)
  fi
done

# Put the generated-by-C# code into a more obvious directory
mv tmp/Src/Generated tmp/csharp
rm -rf tmp/Src

# Copy the Python-generated code
for package_dir in tmp/csharp/*
do
  package=$(basename $package_dir)
  if [[ ! -d $CLIENT_REPO/Src/Generated/${package} ]]
  then
    echo "Python directory for ${package} does not exist; deleting C# code"
    rm -rf $package_dir
  else
    echo "Copying Python code for ${package}"
    mkdir -p tmp/python/$package
    cp $CLIENT_REPO/Src/Generated/${package}/*.cs tmp/python/$package
    cp $CLIENT_REPO/Src/Generated/${package}/*.config tmp/python/$package
    cp $CLIENT_REPO/Src/Generated/${package}/*.csproj tmp/python/$package
  fi
done

# Normalize files from both generators in order to make diffing simpler
dotnet run -p Google.Api.Generator.DiffSimplifier -- tmp/csharp tmp/python

echo "Generated and normalized code. Diff tmp/csharp with tmp/python"
