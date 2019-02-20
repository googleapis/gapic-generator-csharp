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
        [InlineData("enum", "not_the_same", "NotTheSame")]
        [InlineData("enum", "enum", "Enum")]
        [InlineData("enum", "enum_2", "_2")]
        [InlineData("enum_type", "enumtype_value", "Value")]
        [InlineData("enumtype", "enum_type_value", "Value")]
        [InlineData("enum_type", "ENUMTYPEVALUE", "Value")]
        [InlineData("enum_type", "ENUMTYPE_VALUE_2", "Value2")]
        public void RemoveEnumPrefix(string enumName, string valueName, string expectedCSharpName) =>
            Assert.Equal(expectedCSharpName, ProtoExtensions.RemoveEnumPrefix(enumName, valueName));
    }
}
