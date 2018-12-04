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

## Common-protos submodule

Currently the new-style proto annotations are only available in the
`input-contract` branch of the `/googleapis/api-common-protos`
GitHub repo.
These annotations are required for the test protos.

Once these annotations have been merged into `master`, the submodule
will be updated to refer to the `master` branch.
