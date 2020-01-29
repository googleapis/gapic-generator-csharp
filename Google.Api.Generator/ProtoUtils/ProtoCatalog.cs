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
using System.Collections.Immutable;
using System.Linq;

namespace Google.Api.Generator.ProtoUtils
{
    /// <summary>
    /// A catalog of all loaded proto messages.
    /// </summary>
    internal class ProtoCatalog
    {
        public ProtoCatalog(string defaultPackage, IEnumerable<FileDescriptor> descs, IEnumerable<CommonResources> commonResourcesConfigs)
        {
            _defaultPackage = defaultPackage;
            descs = descs.ToList();
            _msgs = descs.SelectMany(desc => desc.MessageTypes).SelectMany(MsgPlusNested).ToDictionary(x => x.FullName);
            _resourcesByFileName = ResourceDetails.LoadResourceDefinitionsByFileName(descs, commonResourcesConfigs).GroupBy(x => x.FileName)
                .ToImmutableDictionary(x => x.Key, x => (IReadOnlyList<ResourceDetails.Definition>)x.ToImmutableList());
            var resourcesByUrt = _resourcesByFileName.Values.SelectMany(x => x).ToDictionary(x => x.UnifiedResourceTypeName);
            var resourcesByPattern = _resourcesByFileName.Values.SelectMany(x => x)
                .SelectMany(def => def.Patterns.Where(x => !x.IsWildcard).Select(x => (x.PatternString, def)))
                .GroupBy(x => x.PatternString, x => x.def)
                .ToImmutableDictionary(x => x.Key, x => (IReadOnlyList<ResourceDetails.Definition>)x.ToImmutableList());
            _resourcesByFieldName = descs
                .SelectMany(desc => desc.MessageTypes)
                .SelectMany(MsgPlusNested)
                .SelectMany(msg => msg.Fields.InFieldNumberOrder().Select(field =>
                    (field, res: (IReadOnlyList<ResourceDetails.Field>)ResourceDetails.LoadResourceReference(msg, field, resourcesByUrt, resourcesByPattern).ToList()))
                    .Where(x => x.res.Any()))
                .ToDictionary(x => x.field.FullName, x => x.res);

            IEnumerable<MessageDescriptor> MsgPlusNested(MessageDescriptor msgDesc) => msgDesc.NestedTypes.SelectMany(MsgPlusNested).Append(msgDesc);
        }

        private readonly string _defaultPackage;
        private readonly IReadOnlyDictionary<string, MessageDescriptor> _msgs;
        private readonly IReadOnlyDictionary<string, IReadOnlyList<ResourceDetails.Field>> _resourcesByFieldName;
        private readonly IReadOnlyDictionary<string, IReadOnlyList<ResourceDetails.Definition>> _resourcesByFileName;

        public MessageDescriptor GetMessageByName(string name) =>
            _msgs.GetValueOrDefault($"{_defaultPackage}.{name}") ?? _msgs.GetValueOrDefault(name);

        public IReadOnlyList<ResourceDetails.Field> GetResourceDetailsByField(FieldDescriptor fieldDesc) => _resourcesByFieldName.GetValueOrDefault(fieldDesc.FullName);

        public IEnumerable<ResourceDetails.Definition> GetResourceDefsByFile(FileDescriptor fileDesc) =>
            _resourcesByFileName.GetValueOrDefault(fileDesc.Name, ImmutableList<ResourceDetails.Definition>.Empty);
    }
}
