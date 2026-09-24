#!/bin/bash

# This script:
# - Builds the Generator solution in Release mode
# - Starts GAPIC Showcase
# - Runs integration tests for the Generator projects in Release mode
# - Tears down GAPIC Showcase on exit

set -e

cd "$(dirname "$0")"

export DOTNET_NOLOGO=true

CONFIG=Release
DOTNET_BUILD_ARGS="-c $CONFIG"
DOTNET_TEST_ARGS="--no-build $DOTNET_BUILD_ARGS"

echo "Building the solution in $CONFIG mode"
dotnet build $DOTNET_BUILD_ARGS Generator.sln

cleanup() {
  echo "Tearing down GAPIC Showcase"
  if [ -f showcase.pid ]; then
    kill "$(cat showcase.pid)" 2>/dev/null || true
    rm -f showcase.pid
  fi
  if command -v certutil.exe >/dev/null 2>&1; then
    echo "Cleaning up Cert Store" # will only run on windows
    certutil -delstore Root "Showcase Auto TLS CA" >/dev/null 2>&1 || true
    certutil -user -delstore Root "Showcase Auto TLS CA" >/dev/null 2>&1 || true
  fi
  rm -f showcase-ca.pem gapic-showcase gapic-showcase.exe
}
trap cleanup EXIT

echo "Setup GAPIC Showcase with TLS for integration tests"
./startshowcase.sh --port :7469 --tls --ca-cert-output-file showcase-ca.pem

# We need to wait for the showcase cert to be created before running tests
# that relies on tls
for i in {1..50}; do
  [ -s showcase-ca.pem ] && break
  sleep 0.1
done

# Trust Showcase's self-signed CA for TLS:
# - Linux/macOS: .NET OpenSSL honors SSL_CERT_FILE without modifying OS stores.
# - Windows: SChannel requires importing the CA (LocalMachine for elevated CI, CurrentUser for local dev).
if [[ "$OSTYPE" == "linux-gnu"* || "$OSTYPE" == "darwin"* ]]; then
  export SSL_CERT_FILE="$PWD/showcase-ca.pem"
else
  certutil -f -addstore Root showcase-ca.pem >/dev/null 2>&1 || certutil -user -f -addstore Root showcase-ca.pem >/dev/null 2>&1 || true
fi

export SHOWCASE_ENDPOINT=https://localhost:7469
dotnet test $DOTNET_TEST_ARGS Google.Api.Generator.IntegrationTests

echo "Integration testing completed"
