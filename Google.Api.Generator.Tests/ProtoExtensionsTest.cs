// Copyright 2019 Google Inc. All Rights Reserved.
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
using Xunit;

namespace Google.Api.Generator.Tests
{
    public class ProtoExtensionsTest
    {
        [Theory]
        [InlineData("enum_type", "enumtype_value", "Value")]
        [InlineData("enumtype", "enum_type_value", "Value")]
        [InlineData("enum_type", "ENUMTYPEVALUE", "Value")]
        [InlineData("enum_type", "ENUMTYPE_VALUE_2", "Value2")]
        // Tests from https://github.com/protocolbuffers/protobuf/blob/d9ccd0c0e6bbda9bf4476088eeb46b02d7dcd327/src/google/protobuf/compiler/csharp/csharp_generator_unittest.cc
        [InlineData("Foo", "BAR", "Bar")]
        [InlineData("Foo", "BAR_BAZ", "BarBaz")]
        [InlineData("Foo", "FOO_BAR", "Bar")]
        [InlineData("Foo", "FOO__BAR", "Bar")]
        [InlineData("Foo", "FOO_BAR_BAZ", "BarBaz")]
        [InlineData("Foo", "Foo_BarBaz", "BarBaz")]
        [InlineData("FO_O", "FOO_BAR", "Bar")]
        [InlineData("FOO", "F_O_O_BAR", "Bar")]
        [InlineData("Foo", "FOO", "Foo")]
        [InlineData("Foo", "FOO___", "Foo")]
        [InlineData("Foo", "FOO_2_BAR", "_2Bar")]
        [InlineData("Foo", "FOO___2", "_2")]
        public void RemoveEnumPrefix(string enumName, string valueName, string expectedCSharpName) =>
            Assert.Equal(expectedCSharpName, ProtoExtensions.RemoveEnumPrefix(enumName, valueName));
    }
}
