# Test suggestions

Generators are primarily tested using "golden" files with the
expected generated code. (There is tooling in place to allow only
parts of generated code to be tested as well, but often it's not
worth customizing the tests that much.)

If a new feature or bug fix can be demonstrated without any new test
cases being added, only the diffs need to be checked (ideally in a
separate commit to the implementation). Otherwise (and assuming it's
possible), it can make sense to have a sequence of commits like this:

- Add the "manual" parts of the new test case (typically protos,
  fakes, and the unit test method).
- Add the generated code for the existing implementation, before
  the intended change.
- Production code for the change.
- Changes to generated code after the change; this is the commit that
  really shows the change in behavior.

The test runner stores all the generated code under the system temp
directory, in a dated subdirectory per run, e.g.
`GeneratorTests-20240212143049Z`. Finding the test-specific
subdirectory within that and copying the results to the expected
results in this repository is a quick way of updating the tests -
but the changes should be reviewed carefully, of course.
