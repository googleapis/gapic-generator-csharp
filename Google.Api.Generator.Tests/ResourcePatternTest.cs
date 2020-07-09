// Copyright 2020 Google Inc. All Rights Reserved.
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

using Google.Api.Generator.ProtoUtils;
using System;
using Xunit;

namespace Google.Api.Generator.Tests
{
    public class ResourcePatternTest
    {
        [Theory]
        [InlineData("as/{a}", new[] { "a" }, "as/{a}", new[] { "A" }, "as/A")]
        [InlineData("as/{a=*}", new[] { "a" }, "as/{a=*}", new[] { "A" }, "as/A")]
        [InlineData("as/{a=**}", new[] { "a" }, "as/{a=**}", new[] { "A/AA/AAA" }, "as/A/AA/AAA")]
        [InlineData("as/{a_1}~{a_2}.{a_3}", new[] { "a_1", "a_2", "a_3" }, "as/{a_1_a_2_a_3}", new[] { "A1", "A2", "A3" }, "as/A1~A2.A3")]
        [InlineData("as/{a_1=*}~{a_2=*}.{a_3=*}", new[] { "a_1", "a_2", "a_3" }, "as/{a_1_a_2_a_3}", new[] { "A1", "A2", "A3" }, "as/A1~A2.A3")]
        [InlineData("as/{a=*}/bs/{b_1}-{b_2}/cs/{c_1=*}_{c_2}/{d=**}", new[] { "a", "b_1", "b_2", "c_1", "c_2", "d" },
            "as/{a=*}/bs/{b_1_b_2}/cs/{c_1_c_2}/{d=**}", new[] { "A", "B1", "B2", "C1", "C2", "D" }, "as/A/bs/B1-B2/cs/C1_C2/D")]
        public void ValidPattern(string pattern, string[] paramNames, string pathTemplateString, string[] expandArgs, string expanded)
        {
            var pat = new ResourcePattern(pattern);
            Assert.Equal(paramNames, pat.ParameterNames);
            Assert.Equal(pathTemplateString, pat.PathTemplateString);
            Assert.Equal(expanded, pat.Expand(expandArgs));
        }

        [Theory]
        [InlineData("as/{~}")]
        [InlineData("as/{a=***}")]
        [InlineData("as/{a_1=**}.{a_2}")]
        [InlineData("as/{a_1}{a_2}")]
        [InlineData("as/{a_1}:{a_2}")]
        [InlineData("as/{a_1}.{a_2")]
        [InlineData("as/{a_1}.{")]
        [InlineData("as/{a_1}.")]
        [InlineData("as/{")]
        [InlineData("as/{}")]
        [InlineData("as/.{a_1}")]
        [InlineData("as/.")]
        [InlineData("as//")]
        [InlineData("/")]
        [InlineData("")]
        public void InvalidPattern(string pattern)
        {
            Assert.Throws<ArgumentException>(() => new ResourcePattern(pattern));
        }

        [Theory]
        [InlineData("as/{a}/bs/{b}", "as/{a}")]
        [InlineData("as/{a}/bs/{b}/cs/{c}", "as/{a}/bs/{b}")]
        [InlineData("as/{a_1}~{a_2}/bs/{b}", "as/{a_1}~{a_2}")]
        [InlineData("as/{a}/b", "as/{a}")]
        [InlineData("as/{a_1}.{a_2}/b", "as/{a_1}.{a_2}")]
        public void ValidParent(string pattern, string expectedParentPattern)
        {
            var pat = new ResourcePattern(pattern);
            var parent = pat.Parent();
            Assert.Equal(expectedParentPattern, parent.ToString());
        }

        [Theory]
        [InlineData("as/{a}")]
        [InlineData("as/{a_1}~{a_2}")]
        [InlineData("as")]
        public void InvalidParent(string pattern)
        {
            var pat = new ResourcePattern(pattern);
            Assert.Throws<InvalidOperationException>(() => pat.Parent());
        }
    }
}
