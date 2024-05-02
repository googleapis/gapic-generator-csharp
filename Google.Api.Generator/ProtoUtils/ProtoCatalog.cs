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
using System;
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
        /// <summary>
        /// Creates a new catalog for a specific package.
        /// </summary>
        /// <param name="defaultPackage">The default package for unqualified message name.</param>
        /// <param name="allDescriptors">All the file descriptors that have been loaded.</param>
        /// <param name="requiredFileDescriptors">The file descriptors which *must* have their resource name fields resolved.</param>
        /// <param name="commonResourcesConfigs">The common resource name definitions.</param>
        /// <param name="serviceConfig">The service configuration, used for additional settings.</param>
        public ProtoCatalog(
            string defaultPackage, IEnumerable<FileDescriptor> allDescriptors,
            IEnumerable<FileDescriptor> requiredFileDescriptors, IEnumerable<CommonResources> commonResourcesConfigs, ClientLibrarySettings librarySettings)
        {
            _defaultPackage = defaultPackage;
            allDescriptors = allDescriptors.ToList();
            _msgs = allDescriptors.SelectMany(desc => desc.MessageTypes).SelectMany(MsgPlusNested).ToDictionary(x => x.FullName);
            _services = allDescriptors.SelectMany(desc => desc.Services).ToDictionary(x => x.FullName);
            _resourcesByFileName = ResourceDetails.LoadResourceDefinitionsByFileName(allDescriptors, commonResourcesConfigs, librarySettings).GroupBy(x => x.FileName)
                .ToImmutableDictionary(x => x.Key, x => (IReadOnlyList<ResourceDetails.Definition>) x.ToImmutableList());
            var allResources = _resourcesByFileName.Values.SelectMany(x => x);
            ValidateUniqueResourceTypeNames();
            var resourcesByUrt = allResources.ToDictionary(x => x.UnifiedResourceTypeName);
            var resourcesByPatternComparison = allResources
                .SelectMany(def => def.Patterns.Where(x => !x.IsWildcard).Select(x => (x.Template.ParentComparisonString, def)))
                .GroupBy(x => x.ParentComparisonString, x => x.def)
                .ToImmutableDictionary(x => x.Key, x => (IReadOnlyList<ResourceDetails.Definition>) x.ToImmutableList());
            _resourcesByFieldName = allDescriptors
                .SelectMany(desc => desc.MessageTypes)
                .SelectMany(MsgPlusNested)
                .SelectMany(msg => msg.Fields.InFieldNumberOrder().Select(field =>
                    (field, res: (IReadOnlyList<ResourceDetails.Field>) ResourceDetails.LoadResourceReference(
                        msg, field, resourcesByUrt, resourcesByPatternComparison, requiredFileDescriptors.Contains(msg.File)).ToList()))
                    .Where(x => x.res.Any()))
                .ToDictionary(x => x.field.FullName, x => x.res);

            IEnumerable<MessageDescriptor> MsgPlusNested(MessageDescriptor msgDesc) => msgDesc.NestedTypes.SelectMany(MsgPlusNested).Append(msgDesc);

            void ValidateUniqueResourceTypeNames()
            {
                var multiDefinitions = allResources
                    .GroupBy(x => x.UnifiedResourceTypeName)
                    .Where(g => g.Count() > 1)
                    .Select(g => g.Key)
                    .ToList();
                if (multiDefinitions.Any())
                {
                    throw new InvalidOperationException($"Multiple definitions found for the following resources: {string.Join(",", multiDefinitions)}");
                }
            }
        }

        private readonly string _defaultPackage;
        private readonly IReadOnlyDictionary<string, MessageDescriptor> _msgs;
        private readonly IReadOnlyDictionary<string, ServiceDescriptor> _services;
        private readonly IReadOnlyDictionary<string, IReadOnlyList<ResourceDetails.Field>> _resourcesByFieldName;
        private readonly IReadOnlyDictionary<string, IReadOnlyList<ResourceDetails.Definition>> _resourcesByFileName;

        public MessageDescriptor GetMessageByName(string name) =>
            _msgs.GetValueOrDefault($"{_defaultPackage}.{name}") ?? _msgs.GetValueOrDefault(name);

        public ServiceDescriptor GetServiceByName(string name) =>
            _services.GetValueOrDefault($"{_defaultPackage}.{name}") ?? _services.GetValueOrDefault(name);

        public IReadOnlyList<ResourceDetails.Field> GetResourceDetailsByField(FieldDescriptor fieldDesc) => _resourcesByFieldName.GetValueOrDefault(fieldDesc.FullName);

        public IEnumerable<ResourceDetails.Definition> GetResourceDefsByFile(FileDescriptor fileDesc) =>
            _resourcesByFileName.GetValueOrDefault(fileDesc.Name, ImmutableList<ResourceDetails.Definition>.Empty);
    }
}
