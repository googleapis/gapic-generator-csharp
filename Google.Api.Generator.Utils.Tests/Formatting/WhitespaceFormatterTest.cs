// Copyright 2018 Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

// This test loads this source file during the test, parses it into
// Roslyn, removes all trivia, passes it through the Whitespace formatter,
// then checks that the input source and re-formatted source are identical.
// Code between the TEST_SOURCE_START and TEST_SOURCE_END comments are used
// as source for this test.
// So some of the source code looks a bit odd, as it needs to test every
// code construct is formatted correctly.
// TODO: Add further code as WhitespaceFormatter adds more formatting.

// TODO: Consider splitting this test into multiple files; possibly
// putting the test source separately, or splitting the test source
// into multiple source files, and/or multiple tests.

// TEST_SOURCE_START
using Google.Api.Generator.Testing;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xunit;
using SYS = System;

namespace Google.Api.Generator.Utils.Formatting.Tests
{
    [Description("ClassDescription")]
    public class WhitespaceFormatterTest
    {
        // Test nested class; base-list with multiple items.
        // Test aliased type.
        private class Inner : List<SYS::String>, IEnumerable<string>, IList<string>
        {
            // Test ctor with no parameters.
            // Test ctor calling another ctor with multiple parameters.
            // Test empty bock body.
            public Inner() : this(0, 1, 2)
            {
            }

            // Test ctor with single parameter.
            // Test ctor calling ctor with no args.
            // Test expression body.
            public Inner(int a) : this() => _a = a + 1;

            // Test ctor with multiple parameters.
            // Test non-empty block body.
            public Inner(int a, int b, int c)
            {
                // Test assignment.
                _a = a;
                // Test binary operator.
                _b = b + c;
            }

            // Test instance field with an initializer.
            private readonly int _a = -1;

            // Test instance field with no intializer.
            private readonly int _b;

            // Test get-only auto-property.
            public string P1 { get; }

            // Test get/set auto-property with initializer.
            public string P2 { get; set; } = "Hello_world!";

            // Test get-only expression-bodied property.
            public string P3
            {
                get => "Hello_another_world!";
            }

            private string _p4 = "";

            // Test get/set expression-bodied property.
            public string P4
            {
                get => _p4 + _p4;
                set => _p4 = value;
            }

            // Test get/set block-bodied property.
            public string P5
            {
                get
                {
                    return _p4 + _p4;
                }
                set
                {
                    _p4 = value;
                }
            }

            public class ObjectWithProperties
            {
                public string S { get; set; }

                public ObjectWithProperties O { get; set; }

                public List<int> List { get; }

                public Dictionary<int, string> Dict { get; }

                public Dictionary<string, string> Dict2 { get; }
            }

            // Test property with initializer using nested object initialization.
            // Test object collection initialization.
            public ObjectWithProperties P6 { get; set; } = new ObjectWithProperties
            {
                S = "A_string",
                O = new ObjectWithProperties
                {
                    S = "Another_string",
                },
                List = { 1, 2, 3, },
                Dict = { { 0, "0" }, { 1, "1" }, },
                Dict2 =
                {
                    { "a_string", "" },
                    {
                        "A_really_long_key_string,_to_make_sure_the_key_and_value_end_up_on_different_lines",
                        "A_similarly_long_value_string,_to_test_the_key/value_strings_end_up_formatted_correctly."
                    },
                },
            };

            // Test attribute with no arguments on a method.
            [Obsolete]
            public void M1()
            {
                // Test named argument
                string.Join(separator: ',', values: "a");
            }

            // Test expression-bodied method
            // Test `new` keyword
            // Test `return` statement.
            public object GetObject()
            {
                return new object();
            }

            // Test `new` array with size.
            public string[] GetStringArrayWithSize() => new string[0];

            // Test `new` array without size, with initializer.
            public string[] GetStringArrayWithInitializer() => new string[] { "one", };

            // Test expression containing `await`.
            // Test `if` and `else` statement.
            // Test void `return`.
            public async Task Yield(bool yield)
            {
                if (yield)
                {
                    await Task.Yield();
                }
                else
                {
                    return;
                }
            }

            // Test `throw` expression.
            public void ThrowExpression(Exception e) => throw e;

            // Test `throw` statement.
            public void ThrowStatement(Exception e)
            {
                throw e;
            }

            // Test generic field type.
            public Dictionary<int, string> _genericField = null;

            // Test generic parameters and generic constraints.
            public void GenericMethod<A, B>(A a, B b) where A : class, IList<B> where B : struct, IList<A>
            {
            }

            // Test `ref` parameter and `ref` arg.
            public void WithRef(ref int a) => WithRef(ref a);

            // Test wrapping of long expression-bodied method, with correct multi-line indent.
            public object MethodWithLongNameSoTheExpressionBodyWillWrapToTheNextLine(string aParameter, string anotherParameter, string aThirdParameter) =>
                new List<int> { 18, };

            // Test conditional operator.
            public int Conditional(bool b) => b ? 1 : 2;

            // Test `out var`.
            public bool OutVar() => _genericField.TryGetValue(0, out var value);

            // Test operator
            public static bool operator ==(Inner a, Inner b) => a.Equals(b);

            // Test parens.
            // Test unary prefix.
            public static bool operator !=(Inner a, Inner b) => !(a == b);

            // `Equals` and `GetHashCode` required as `==` and `!=` are defined.
            public override bool Equals(object obj) => false;

            public override int GetHashCode() => 0;

            // Test `foreach`
            public void ForEach(IEnumerable<string> strings)
            {
                foreach (string s in strings)
                {
                    Console.WriteLine(s);
                }
                int i = 0;
                while (i++ < 10)
                {
                    Console.WriteLine(i);
                }
            }

            // Test `for`
            public void For()
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(i);
                }
            }

            // Test a simple lambda expression.
            public IEnumerable<int> SimpleLambda() => new string[0].Select(x => x.Length);

            // Test a typed lambda expression.
            public IEnumerable<int> TypedLambda() => new string[0].Select((string x) => x.Length);

            // Test block-bodied simple lambda method
            // TODO: This formatting is not quite ideal. It doens't matter at the moment as there are no
            //       generated methods that have this form.
            public IEnumerable<int> SimpleBlockBodiedLambda1() =>
                new string[0].Select(x =>
                {
                    int length = x.Length;
                    return length;
                });

            // Test block-bodied typed lambda method
            public IEnumerable<int> TypedBlockBodiedLambda2() =>
                new string[0].Select((string x) =>
                {
                    int length = x.Length;
                    return length;
                });

            // Test async lambda
            private void AsyncLambdaParam(Func<Task> fn) => throw new NotImplementedException();

            public void AsyncLambda() => AsyncLambdaParam(async () => await Task.Yield());

            // Test switch statement
            public int Switch(int i)
            {
                switch (i)
                {
                    // Single-line case.
                    case 0: return 1;
                    case 1: return 0;
                    // Multi-line case.
                    case 1111:
                        int j = Switch(0);
                        return i + j;
                    default: return i;
                }
            }

            // Test aliasing of parameter and local
            public void AliasedLocal(SYS::Exception e)
            {
                SYS::Exception e2 = e;
                throw e2;
            }
        }

        // Test base-list with one item.
        private class EmptyInner : List<string>
        {
            // Test class that has no members.
        }

        // Test enum.
        public enum AnEnum
        {
            // Enum members with value.
            A = 1,

            B = 2,

            // Enum members without value.
            C,

            D,
        }

        // Test enum with attributes.
        [Flags]
        public enum AnEnumWithFlags
        {
            [Description("DescriptionA")]
            A = 1,

            [Description("DescriptionB")]
            B = 2,
        }
        // TEST_SOURCE_END

        private class TriviaRemover : CSharpSyntaxRewriter
        {
            public TriviaRemover() : base(visitIntoStructuredTrivia: false) { }
            public override SyntaxNode Visit(SyntaxNode node)
            {
                return base.Visit(node)?.WithoutTrivia();
            }
            public override SyntaxToken VisitToken(SyntaxToken token)
            {
                return base.VisitToken(token).WithoutTrivia();
            }
        }

        private static string ThisFilename([CallerFilePath] string filePath = null)
        {
            var utilTestDir = Path.Combine(PathUtils.GetRepoRoot(), "Google.Api.Generator.Utils.Tests");
            return Path.Combine(utilTestDir, "Formatting", Path.GetFileName(filePath));
        }

        [Fact]
        public void ThisSourceFile()
        {
            // Read source file and remove all ignored lines.
            var sourceLines = File.ReadAllLines(ThisFilename());
            var testSourceLines = sourceLines.Aggregate((ignoring: true, lines: new List<string>()), (acc, line) =>
            {
                var ignoring =
                    line.Trim() == "// TEST_SOURCE_END" ? true :
                    line.Trim() == "// TEST_SOURCE_START" ? false : (bool?) null;
                if (!acc.ignoring && ignoring != true && !line.Trim().StartsWith("//"))
                {
                    acc.lines.Add(line);
                }
                return (ignoring ?? acc.ignoring, acc.lines);
            });
            var testSource = string.Join(WhitespaceFormatterNewLine.NewLine.ToFullString(), testSourceLines.lines);
            // Parse source using Roslyn.
            var root = CSharpSyntaxTree.ParseText(testSource).GetCompilationUnitRoot();
            // Remove all trivia (including whitespace) from Roslyn tree.
            var rootWithoutWhitespace = new TriviaRemover().Visit(root);
            // Confirm that the source now contains no whitspace.
            var testSourceWithoutWhitespace = rootWithoutWhitespace.ToFullString();
            Assert.DoesNotContain(" ", testSourceWithoutWhitespace);
            Assert.DoesNotContain("\n", testSourceWithoutWhitespace);
            // Use the WhitespaceFormatter.
            var rootFormatter = new WhitespaceFormatter(maxLineLength: 120).Visit(rootWithoutWhitespace);
            var testSourceFormatter = rootFormatter.ToFullString();
            // Check that the sources are identical.
            Assert.Equal(testSource, testSourceFormatter);
        }
        // TEST_SOURCE_START
    }
}

// TEST_SOURCE_END
