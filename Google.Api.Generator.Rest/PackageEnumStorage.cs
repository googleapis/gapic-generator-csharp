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

using Newtonsoft.Json;
using System.Collections.Generic;

namespace Google.Api.Generator.Rest
{
    /// <summary>
    /// The stored values of enums for parameters within a package model.
    /// These need to be persisted so that we can avoid taking breaking changes if the Discovery doc
    /// reorders enum values over time.
    /// </summary>
    public class PackageEnumStorage
    {
        // Note: this is sorted just to keep things idempotent.
        private readonly SortedDictionary<string, List<string>> _nameToValuesMap;

        private PackageEnumStorage(SortedDictionary<string, List<string>> nameToValuesMap) =>
            _nameToValuesMap = nameToValuesMap;

        /// <summary>
        /// Returns the numeric value to use for the given text value. This is drawn from the existing
        /// values if the text value is already present, or added to the internal representation and
        /// given the next available numeric value otherwise.
        /// </summary>
        /// <param name="key">The key associated with the enum. This must be unique (and always generated in the same way)
        /// but otherwise has no specific meaning.</param>
        /// <param name="originalTextValue">The original text value in the Discovery doc</param>
        /// <returns>The value to assign to the enum member.</returns>
        internal int GetOrAddEnumValue(string key, string originalTextValue)
        {
            if (!_nameToValuesMap.TryGetValue(key, out var list))
            {
                _nameToValuesMap[key] = list = new List<string>();
            }
            int index = list.IndexOf(originalTextValue);
            if (index != -1)
            {
                return index;
            }
            list.Add(originalTextValue);
            return list.Count - 1;
        }

        internal static PackageEnumStorage FromJson(string json)
        {
            var dictionary = JsonConvert.DeserializeObject<SortedDictionary<string, List<string>>>(json);
            return new PackageEnumStorage(dictionary);
        }

        internal string ToJson() => JsonConvert.SerializeObject(_nameToValuesMap, Formatting.Indented);
    }
}
