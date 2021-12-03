// Copyright 2021 Google Inc. All Rights Reserved.
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

using Google.Protobuf;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Google.Api.Generator.ProtoUtils
{
    internal static class IMessageExtensions
    {
        internal static string ToFormattedJson(this IMessage messsage) =>
            JsonConvert.DeserializeObject<JObject>(
                messsage.ToString(), new JsonSerializerSettings { DateParseHandling = DateParseHandling.None })
            .ToString(Formatting.Indented) + "\n"; //trailing file newline to please github
    }
}
