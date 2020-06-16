# BAZEL usage instructions

To build a C# gapic client library from a proto service description,
the following files are required:

`WORKSPACE.bazel`:

```bazel
load("@bazel_tools//tools/build_defs/repo:http.bzl", "http_archive")

http_archive(
    name = "com_google_protobuf",
    sha256 = "e5265d552e12c1f39c72842fa91d84941726026fa056d914ea6a25cd58d7bbf8",
    urls = ["https://github.com/protocolbuffers/protobuf/archive/v3.12.3.zip"],
    strip_prefix = "protobuf-3.12.3",
)
load("@com_google_protobuf//:protobuf_deps.bzl", "protobuf_deps")
protobuf_deps()

http_archive(
    name = "com_github_grpc_grpc",
    strip_prefix = "grpc-1.29.1",
    sha256 = "2afd3e20fd1d52d3d1a605a74befcdcb048a9213a4903880d9267856b063ae60",
    urls = ["https://github.com/grpc/grpc/archive/v1.29.1.zip"],
)
load("@com_github_grpc_grpc//bazel:grpc_deps.bzl", "grpc_deps")
grpc_deps()
load("@com_github_grpc_grpc//bazel:grpc_extra_deps.bzl", "grpc_extra_deps")
grpc_extra_deps()

http_archive(
    name = "rules_proto",
    sha256 = "602e7161d9195e50246177e7c55b2f39950a9cf7366f74ed5f22fd45750cd208",
    strip_prefix = "rules_proto-97d8af4dc474595af3900dd85cb3a29ad28cc313",
    urls = [
        "https://mirror.bazel.build/github.com/bazelbuild/rules_proto/archive/97d8af4dc474595af3900dd85cb3a29ad28cc313.tar.gz",
        "https://github.com/bazelbuild/rules_proto/archive/97d8af4dc474595af3900dd85cb3a29ad28cc313.tar.gz",
    ],
)
load("@rules_proto//proto:repositories.bzl", "rules_proto_dependencies", "rules_proto_toolchains")
rules_proto_dependencies()
rules_proto_toolchains()

local_repository(
    name = "com_googleapis_gapic_generator_csharp",
    path = "<path>/<to>/gapic-generator-csharp",
)

load("@com_googleapis_gapic_generator_csharp//:repositories.bzl", "com_googleapis_gapic_generator_csharp_repositories")
com_googleapis_gapic_generator_csharp_repositories()
```

`BUILD.bazel`:

```bazel
load("@com_googleapis_gapic_generator_csharp//rules_csharp_gapic:csharp_gapic.bzl", "csharp_proto_library", "csharp_grpc_library", "csharp_gapic_library")

proto_library(
    name = "example_src",
    srcs = [
        "example.proto",
    ],
)

csharp_proto_library(
    name = "example_proto",
    srcs = [
        ":example_src",
    ],
)

csharp_grpc_library(
    name = "example_grpc",
    srcs = [
        ":example_src",
    ],
)

# This also creates a "example_gapic_full" target, which will contain all required source, not just gapic source.
csharp_gapic_library(
    name = "example_gapic",
    srcs = [
        ":example_src",
    ],
    proto = ":example_proto",
    grpc = ":example_grpc",
)
```

`example.proto`:

```proto
syntax = "proto3";

package example;

service Example {
    rpc ExampleMethod(Request) returns(Response);
}

message Request {
    string name = 1;
}

message Response {
}
```

Invoke bazel in the same directory as these files:

```bash
$ bazel build :example_gapic_full
```

After a successful build, the generated C# source code for the client library
will be in `./bazel-bin/full/`
