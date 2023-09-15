# Running the Showcase tests

The Showcase integration tests have to be run against a
[GAPIC Showcase](https://github.com/googleapis/gapic-showcase)
server. This is available as a Docker image and individual
executables.

To run on Windows, without needing Docker desktop:
- Download the latest release asset ending with `-windows-amd64.tar.gz`
- Extract the `gapic-showcase.exe` executable using `tar xzf {downloaded-file}`
- Run `gapic-showcase.exe` in a console

Once the server is started, an environment variable
(`SHOWCASE_ENDPOINT`) is required so the integration tests know how
to connect to it. Assuming you're running in bash, using a GAPIC
Showcase server running on the local machine on the default port,
you need:

```sh
export SHOWCASE_ENDPOINT=http://localhost:7469
```

The `http://` part is required in order to make an unencrypted
connection.

When the environment variable has been set, the tests can be run
like any other tests, using `dotnet test` (in the same shell where
the environment variable has been specified).
