#!/bin/bash
set -eo pipefail

cd "$(dirname "$0")"

if [[ "$OSTYPE" == "linux-gnu"* ]]; then OS="linux"; elif [[ "$OSTYPE" == "darwin"* ]]; then OS="darwin"; else OS="windows"; fi

ARCH="amd64"
if [[ "$OS" == "darwin" && $(uname -m) == "arm64" ]]; then
  ARCH="arm64"
fi

# Clean up any previously running instance
if [ -f showcase.pid ]; then
  kill "$(cat showcase.pid)" 2>/dev/null || true
  rm -f showcase.pid
fi
pkill -f "gapic-showcase run" 2>/dev/null || true
sleep 1

SHOWCASE_VERSION="0.44.2"

if [ ! -f gapic-showcase ] && [ ! -f gapic-showcase.exe ]; then
  echo "Downloading gapic-showcase-${SHOWCASE_VERSION}-${OS}-${ARCH}..."
  curl -sSL -f https://github.com/googleapis/gapic-showcase/releases/download/v${SHOWCASE_VERSION}/gapic-showcase-${SHOWCASE_VERSION}-${OS}-${ARCH}.tar.gz | tar -zx
fi

if [ $# -eq 0 ]; then
  set -- --port :7469
fi

SHOWCASE_BIN="./gapic-showcase"
if [[ "$OS" == "windows" ]]; then
  SHOWCASE_BIN="./gapic-showcase.exe"
fi

echo "GAPIC Showcase version: $($SHOWCASE_BIN --version 2>&1 || true)"
$SHOWCASE_BIN run "$@" > showcase.log 2>&1 &

# Write the PID to a file so the caller can easily tear it down
echo $! > showcase.pid
echo "Showcase started with PID $!"
sleep 2
if ! kill -0 "$!" 2>/dev/null; then
  echo "gapic-showcase failed to start. Please check showcase.log for details." >&2
  cat showcase.log >&2 || true
  exit 1
fi
