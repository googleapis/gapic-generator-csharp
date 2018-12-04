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

using Google.Protobuf.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace Google.Api.Generator.ProtoUtils
{
    /// <summary>
    /// A catalog of all loaded proto messages.
    /// </summary>
    class ProtoCatalog
    {
        public ProtoCatalog(string defaultPackage, IEnumerable<FileDescriptor> descs)
        {
            _defaultPackage = defaultPackage;
            _msgs = descs.SelectMany(desc => desc.MessageTypes).ToDictionary(x => x.FullName);
        }

        private readonly string _defaultPackage;
        private readonly IReadOnlyDictionary<string, MessageDescriptor> _msgs;

        public MessageDescriptor GetMessageByName(string name) =>
            _msgs[name.Contains('.') ? name : $"{_defaultPackage}.{name}"];
    }
}
