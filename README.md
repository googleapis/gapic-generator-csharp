# API Client Generator for C#

A generator for protocol buffer described APIs for and in C#.

[![Travis build Status](https://api.travis-ci.org/googleapis/gapic-generator-csharp.svg?branch=master)](https://travis-ci.org/googleapis/gapic-generator-csharp)

This is a generator for API client libraries for APIs specified by protocol buffers, such as those inside Google.
It takes a protocol buffer (with particular annotations) and uses it to generate a client library, as specified at [aip.dev/client-libraries](https://google.aip.dev/client-libraries).

## Purpose

This generator replaces the [older monolithic generator](https://github.com/googleapis/gapic-generator),
and is suitable for production use.

## Bazel support

Bazel support is currently experimental, and may change without warning.
See [BAZEL.md](./BAZEL.md) for bazel usage instructions.
