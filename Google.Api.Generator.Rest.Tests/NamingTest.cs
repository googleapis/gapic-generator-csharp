// Copyright 2025 Google LLC
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

using System;
using Google.Api.Generator.Rest.Models;
using Google.Api.Generator.Utils.Roslyn;
using Xunit;

namespace Google.Api.Generator.Rest.Tests
{
    public class NamingTest
    {
        [Fact]
        public void GoogleKeywordIsEscaped()
        {
            var name = "Google";
            var escapedName = Naming.ToMemberName(name);

            Assert.True(Keywords.IsReservedName(name));
            Assert.NotEqual(escapedName, name, StringComparer.OrdinalIgnoreCase);
            Assert.False(Keywords.IsReservedName(escapedName));
        }
    }
}
