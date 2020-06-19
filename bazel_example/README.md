# Bazel example

This directory contains a simple example of using the C# gapic client
library generator.

To build this example, ensure [bazel](https://bazel.build/) is installed
on your machine.

Then execute the following bazel build command in this directory:

```bash
$ bazel build :example_csharp_pkg
```

The full C# source code for the client library will be generator into the
`./bazel-bin/example_pkg/` directory; and zipped into
`./bazel-bin/example_pkg.tar.gz`

This is currently only supported on the `linux-x64` platform.
