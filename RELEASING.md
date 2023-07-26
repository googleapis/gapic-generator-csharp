# Release process

The GAPIC generator is used by the .NET Google Cloud Libraries team
in two ways:

- From the [google-cloud-dotnet repo](https://github.com/googleapis/google-cloud-dotnet),
  for both developer-local generation and OwlBot-postprocessor-regeneration
- From the [googleapis repo](https://github.com/googleapis/googleapis)
  (which is synchronized from internal source control) for Bazel-based
  generation

When releasing a new version of the generator, these both need to be
taken into account.

Note that the version number is not part of the generator build
anywhere, so there is no "release PR" (as there is for libraries).
(This could potentially be changed in the future.)

The release process is therefore as described below.

## Creating the GitHub release

- Look at the [releases page](https://github.com/googleapis/gapic-generator-csharp/releases)
  to find the most recent release commit.
- Look at the [commit history](https://github.com/googleapis/gapic-generator-csharp/commits/main)
  to determine what's changed since the most recent release.
- Determine the new version number - we typically use a patch
  release; the generator version numbering is *not* SemVer. When
  updating to a new major version of GAX, it's worth bumping the minor
  version of the generator.
- Create a new release from the releases page:
  - The tag and title should both be of the form `v1.2.3`
  - Specify the changes since the last version
  - We don't use pre-releases/drafts for the generator

## Updating google-cloud-dotnet

Create a new PR to edit
[toolversions.sh in
google-cloud-dotnet](https://github.com/googleapis/google-cloud-dotnet/blob/main/toolversions.sh).

The only change needed should be the value for `GAPIC_GENERATOR_VERSION`.
Do not submit the PR yet.

## Updating Bazel

- Download the release from the generator release page using the
  "Source code (tar.gz)" link
- Run a SHA-256 tool (e.g. `sha256sum.exe` which comes with Git for
  Windows) to find the hash
- Modify WORKSPACE files:
  - In internal source control, find the Copybara source files for
    `WORKSPACE` in the googleapis repo.
  - Create a change to adjust `_gapic_generator_csharp_version` and
    `_gapic_generator_csharp_sha256` accordingly
  - Do not submit the change yet.

## Submitting changes

Once both changes have been approved, they should be
submitted/merged at roughly the same time, to avoid inconsistencies
between versions.

### (Optional) Reducing churn in google-cloud-dotnet

If a change affects many APIs (e.g. there's a change to generated
documentation for all resource name classes) it can be useful to
regenerate all APIs locally and create a single PR to explain that
change, rather than wait for Bazel-bot/OwlBot to regenerate all APIs
in chunks.

In this case, OwlBot will still create PRs, but they'll be closed
automatically after post-processing.

It should never be a problem to *not* do this - it can just save
some effort and leave a slightly clearer commit history.
