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

if [ ! -f gapic-showcase ] && [ ! -f gapic-showcase.exe ]; then
  echo "Resolving the latest GAPIC Showcase version for $OS-$ARCH..."
  SHOWCASE_VERSION=$(curl -s https://api.github.com/repos/googleapis/gapic-showcase/releases/latest | sed -n 's/.*"tag_name": "v\([^"]*\)".*/\1/p' || true)
  if [[ -z "$SHOWCASE_VERSION" ]]; then
    # Fallback to known stable version if GitHub API rate limit is exceeded
    SHOWCASE_VERSION="0.43.0"
    echo "Warning: Failed to resolve latest GAPIC Showcase version from GitHub; falling back to v${SHOWCASE_VERSION}." >&2
  fi

  echo "Downloading gapic-showcase-${SHOWCASE_VERSION}-${OS}-${ARCH}..."
  curl -sSL -f https://github.com/googleapis/gapic-showcase/releases/download/v${SHOWCASE_VERSION}/gapic-showcase-${SHOWCASE_VERSION}-${OS}-${ARCH}.tar.gz | tar -zx
fi

if [ $# -eq 0 ]; then
  set -- --port :7469
fi

if [[ "$OS" == "windows" ]]; then
  ./gapic-showcase.exe run "$@" > showcase.log 2>&1 &
else
  ./gapic-showcase run "$@" > showcase.log 2>&1 &
fi

# Write the PID to a file so the caller can easily tear it down
echo $! > showcase.pid
echo "Showcase started with PID $!"
sleep 2
if ! kill -0 "$!" 2>/dev/null; then
  echo "gapic-showcase failed to start. Please check showcase.log for details." >&2
  cat showcase.log >&2 || true
  exit 1
fi
