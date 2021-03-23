// Copyright 2021 Google LLC
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
using Xunit;

namespace Google.Api.Generator.Rest.Tests
{
    public class PackageEnumStorageTest
    {
        [Fact]
        public void SimulatedOrderingChange()
        {
            string key = Guid.NewGuid().ToString();

            // First run: values [ "zero", "one", "two" ]
            var storage = PackageEnumStorage.FromJson("{}");
            Assert.Equal(0, storage.GetOrAddEnumValue(key, "zero"));
            Assert.Equal(1, storage.GetOrAddEnumValue(key, "one"));
            Assert.Equal(2, storage.GetOrAddEnumValue(key, "two"));
            string json = storage.ToJson();

            // Second run: values [ "two", "zero", "one", "three" ]
            storage = PackageEnumStorage.FromJson(json);
            Assert.Equal(2, storage.GetOrAddEnumValue(key, "two"));
            Assert.Equal(0, storage.GetOrAddEnumValue(key, "zero"));
            Assert.Equal(1, storage.GetOrAddEnumValue(key, "one"));
            Assert.Equal(3, storage.GetOrAddEnumValue(key, "three"));
        }

        [Fact]
        public void KeysAreIndependent()
        {
            string key1 = Guid.NewGuid().ToString();
            string key2 = Guid.NewGuid().ToString();

            var storage = PackageEnumStorage.FromJson("{}");
            Assert.Equal(0, storage.GetOrAddEnumValue(key1, "x"));
            Assert.Equal(1, storage.GetOrAddEnumValue(key1, "y"));

            // The "y" value from key 1 shouldn't affect key 2
            Assert.Equal(0, storage.GetOrAddEnumValue(key2, "y"));
            Assert.Equal(1, storage.GetOrAddEnumValue(key2, "z"));

            // Back to key 1, where the "z" value from key 2 shouldn't
            // affect it
            Assert.Equal(2, storage.GetOrAddEnumValue(key1, "z"));
        }
    }
}
