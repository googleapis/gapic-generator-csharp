# TODO

*Repo-level TODOs*

## Google.Protobuf dependency/submodule

Currently the `.csproj` from `Google.Protobuf` is referenced directly
using a submodule to the `protobuf` GitHub repo.
This is required because this project uses some protobuf features that
have not yet been released to nuget.

Once a nuget release contains these features, the submodule will be
removed, and a standard NuGet package reference used instead.

The required features include:

* `FileDescriptor.BuildFromByteString(...)` method.
* Support for reading proto comments.

## Google.Api.CommonProtosExtra project

This is required to add the new input-contract common protos.
Once GAX has been updated to include these, this project can be deleted,
and references to it removed.

## protoc executable

Consider installing the `Google.Protobuf.Tools` package, rather than having
the `protoc` executables directly in the repo.