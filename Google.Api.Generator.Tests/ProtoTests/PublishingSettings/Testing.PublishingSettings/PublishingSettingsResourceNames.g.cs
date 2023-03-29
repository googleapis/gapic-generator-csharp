// Copyright 2019 Google LLC
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

// Generated code. DO NOT EDIT!

#pragma warning disable CS8981
using gax = Google.Api.Gax;
using pn = PublishingSettingsCommon.Namespace;
using sys = System;
using tp = Testing.PublishingSettings;

namespace Testing.PublishingSettings
{
    /// <summary>Resource name for the <c>Resource</c> resource.</summary>
    public sealed partial class ResourceName : gax::IResourceName, sys::IEquatable<ResourceName>
    {
        /// <summary>The possible contents of <see cref="ResourceName"/>.</summary>
        public enum ResourceNameType
        {
            /// <summary>An unparsed resource name.</summary>
            Unparsed = 0,

            /// <summary>
            /// A resource name with pattern <c>projects/{project}/locations/{location}/resources/{resource}</c>.
            /// </summary>
            ProjectLocationResource = 1,
        }

        private static gax::PathTemplate s_projectLocationResource = new gax::PathTemplate("projects/{project}/locations/{location}/resources/{resource}");

        /// <summary>Creates a <see cref="ResourceName"/> containing an unparsed resource name.</summary>
        /// <param name="unparsedResourceName">The unparsed resource name. Must not be <c>null</c>.</param>
        /// <returns>
        /// A new instance of <see cref="ResourceName"/> containing the provided <paramref name="unparsedResourceName"/>
        /// .
        /// </returns>
        public static ResourceName FromUnparsed(gax::UnparsedResourceName unparsedResourceName) =>
            new ResourceName(ResourceNameType.Unparsed, gax::GaxPreconditions.CheckNotNull(unparsedResourceName, nameof(unparsedResourceName)));

        /// <summary>
        /// Creates a <see cref="ResourceName"/> with the pattern
        /// <c>projects/{project}/locations/{location}/resources/{resource}</c>.
        /// </summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="locationId">The <c>Location</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="resourceId">The <c>Resource</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="ResourceName"/> constructed from the provided ids.</returns>
        public static ResourceName FromProjectLocationResource(string projectId, string locationId, string resourceId) =>
            new ResourceName(ResourceNameType.ProjectLocationResource, projectId: gax::GaxPreconditions.CheckNotNullOrEmpty(projectId, nameof(projectId)), locationId: gax::GaxPreconditions.CheckNotNullOrEmpty(locationId, nameof(locationId)), resourceId: gax::GaxPreconditions.CheckNotNullOrEmpty(resourceId, nameof(resourceId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="ResourceName"/> with pattern
        /// <c>projects/{project}/locations/{location}/resources/{resource}</c>.
        /// </summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="locationId">The <c>Location</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="resourceId">The <c>Resource</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="ResourceName"/> with pattern
        /// <c>projects/{project}/locations/{location}/resources/{resource}</c>.
        /// </returns>
        public static string Format(string projectId, string locationId, string resourceId) =>
            FormatProjectLocationResource(projectId, locationId, resourceId);

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="ResourceName"/> with pattern
        /// <c>projects/{project}/locations/{location}/resources/{resource}</c>.
        /// </summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="locationId">The <c>Location</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="resourceId">The <c>Resource</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="ResourceName"/> with pattern
        /// <c>projects/{project}/locations/{location}/resources/{resource}</c>.
        /// </returns>
        public static string FormatProjectLocationResource(string projectId, string locationId, string resourceId) =>
            s_projectLocationResource.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(projectId, nameof(projectId)), gax::GaxPreconditions.CheckNotNullOrEmpty(locationId, nameof(locationId)), gax::GaxPreconditions.CheckNotNullOrEmpty(resourceId, nameof(resourceId)));

        /// <summary>Parses the given resource name string into a new <see cref="ResourceName"/> instance.</summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>projects/{project}/locations/{location}/resources/{resource}</c></description></item>
        /// </list>
        /// </remarks>
        /// <param name="resourceName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="ResourceName"/> if successful.</returns>
        public static ResourceName Parse(string resourceName) => Parse(resourceName, false);

        /// <summary>
        /// Parses the given resource name string into a new <see cref="ResourceName"/> instance; optionally allowing an
        /// unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>projects/{project}/locations/{location}/resources/{resource}</c></description></item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="resourceName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <returns>The parsed <see cref="ResourceName"/> if successful.</returns>
        public static ResourceName Parse(string resourceName, bool allowUnparsed) =>
            TryParse(resourceName, allowUnparsed, out ResourceName result) ? result : throw new sys::ArgumentException("The given resource-name matches no pattern.");

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="ResourceName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>projects/{project}/locations/{location}/resources/{resource}</c></description></item>
        /// </list>
        /// </remarks>
        /// <param name="resourceName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="ResourceName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string resourceName, out ResourceName result) => TryParse(resourceName, false, out result);

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="ResourceName"/> instance; optionally
        /// allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>projects/{project}/locations/{location}/resources/{resource}</c></description></item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="resourceName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="ResourceName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string resourceName, bool allowUnparsed, out ResourceName result)
        {
            gax::GaxPreconditions.CheckNotNull(resourceName, nameof(resourceName));
            gax::TemplatedResourceName resourceName2;
            if (s_projectLocationResource.TryParseName(resourceName, out resourceName2))
            {
                result = FromProjectLocationResource(resourceName2[0], resourceName2[1], resourceName2[2]);
                return true;
            }
            if (allowUnparsed)
            {
                if (gax::UnparsedResourceName.TryParse(resourceName, out gax::UnparsedResourceName unparsedResourceName))
                {
                    result = FromUnparsed(unparsedResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        private ResourceName(ResourceNameType type, gax::UnparsedResourceName unparsedResourceName = null, string locationId = null, string projectId = null, string resourceId = null)
        {
            Type = type;
            UnparsedResource = unparsedResourceName;
            LocationId = locationId;
            ProjectId = projectId;
            ResourceId = resourceId;
        }

        /// <summary>
        /// Constructs a new instance of a <see cref="ResourceName"/> class from the component parts of pattern
        /// <c>projects/{project}/locations/{location}/resources/{resource}</c>
        /// </summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="locationId">The <c>Location</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="resourceId">The <c>Resource</c> ID. Must not be <c>null</c> or empty.</param>
        public ResourceName(string projectId, string locationId, string resourceId) : this(ResourceNameType.ProjectLocationResource, projectId: gax::GaxPreconditions.CheckNotNullOrEmpty(projectId, nameof(projectId)), locationId: gax::GaxPreconditions.CheckNotNullOrEmpty(locationId, nameof(locationId)), resourceId: gax::GaxPreconditions.CheckNotNullOrEmpty(resourceId, nameof(resourceId)))
        {
        }

        /// <summary>The <see cref="ResourceNameType"/> of the contained resource name.</summary>
        public ResourceNameType Type { get; }

        /// <summary>
        /// The contained <see cref="gax::UnparsedResourceName"/>. Only non-<c>null</c> if this instance contains an
        /// unparsed resource name.
        /// </summary>
        public gax::UnparsedResourceName UnparsedResource { get; }

        /// <summary>
        /// The <c>Location</c> ID. Will not be <c>null</c>, unless this instance contains an unparsed resource name.
        /// </summary>
        public string LocationId { get; }

        /// <summary>
        /// The <c>Project</c> ID. Will not be <c>null</c>, unless this instance contains an unparsed resource name.
        /// </summary>
        public string ProjectId { get; }

        /// <summary>
        /// The <c>Resource</c> ID. Will not be <c>null</c>, unless this instance contains an unparsed resource name.
        /// </summary>
        public string ResourceId { get; }

        /// <summary>Whether this instance contains a resource name with a known pattern.</summary>
        public bool IsKnownPattern => Type != ResourceNameType.Unparsed;

        /// <summary>The string representation of the resource name.</summary>
        /// <returns>The string representation of the resource name.</returns>
        public override string ToString()
        {
            switch (Type)
            {
                case ResourceNameType.Unparsed: return UnparsedResource.ToString();
                case ResourceNameType.ProjectLocationResource: return s_projectLocationResource.Expand(ProjectId, LocationId, ResourceId);
                default: throw new sys::InvalidOperationException("Unrecognized resource-type.");
            }
        }

        /// <summary>Returns a hash code for this resource name.</summary>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as ResourceName);

        /// <inheritdoc/>
        public bool Equals(ResourceName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(ResourceName a, ResourceName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(ResourceName a, ResourceName b) => !(a == b);
    }

    /// <summary>Resource name for the <c>RenamedDatabase</c> resource.</summary>
    public sealed partial class RenamedDatabaseName : gax::IResourceName, sys::IEquatable<RenamedDatabaseName>
    {
        /// <summary>The possible contents of <see cref="RenamedDatabaseName"/>.</summary>
        public enum ResourceNameType
        {
            /// <summary>An unparsed resource name.</summary>
            Unparsed = 0,

            /// <summary>A resource name with pattern <c>databases/{database}</c>.</summary>
            Database = 1,
        }

        private static gax::PathTemplate s_database = new gax::PathTemplate("databases/{database}");

        /// <summary>Creates a <see cref="RenamedDatabaseName"/> containing an unparsed resource name.</summary>
        /// <param name="unparsedResourceName">The unparsed resource name. Must not be <c>null</c>.</param>
        /// <returns>
        /// A new instance of <see cref="RenamedDatabaseName"/> containing the provided
        /// <paramref name="unparsedResourceName"/>.
        /// </returns>
        public static RenamedDatabaseName FromUnparsed(gax::UnparsedResourceName unparsedResourceName) =>
            new RenamedDatabaseName(ResourceNameType.Unparsed, gax::GaxPreconditions.CheckNotNull(unparsedResourceName, nameof(unparsedResourceName)));

        /// <summary>Creates a <see cref="RenamedDatabaseName"/> with the pattern <c>databases/{database}</c>.</summary>
        /// <param name="databaseId">The <c>Database</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="RenamedDatabaseName"/> constructed from the provided ids.</returns>
        public static RenamedDatabaseName FromDatabase(string databaseId) =>
            new RenamedDatabaseName(ResourceNameType.Database, databaseId: gax::GaxPreconditions.CheckNotNullOrEmpty(databaseId, nameof(databaseId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="RenamedDatabaseName"/> with pattern
        /// <c>databases/{database}</c>.
        /// </summary>
        /// <param name="databaseId">The <c>Database</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="RenamedDatabaseName"/> with pattern <c>databases/{database}</c>
        /// .
        /// </returns>
        public static string Format(string databaseId) => FormatDatabase(databaseId);

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="RenamedDatabaseName"/> with pattern
        /// <c>databases/{database}</c>.
        /// </summary>
        /// <param name="databaseId">The <c>Database</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="RenamedDatabaseName"/> with pattern <c>databases/{database}</c>
        /// .
        /// </returns>
        public static string FormatDatabase(string databaseId) =>
            s_database.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(databaseId, nameof(databaseId)));

        /// <summary>
        /// Parses the given resource name string into a new <see cref="RenamedDatabaseName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>databases/{database}</c></description></item></list>
        /// </remarks>
        /// <param name="renamedDatabaseName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="RenamedDatabaseName"/> if successful.</returns>
        public static RenamedDatabaseName Parse(string renamedDatabaseName) => Parse(renamedDatabaseName, false);

        /// <summary>
        /// Parses the given resource name string into a new <see cref="RenamedDatabaseName"/> instance; optionally
        /// allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>databases/{database}</c></description></item></list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="renamedDatabaseName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <returns>The parsed <see cref="RenamedDatabaseName"/> if successful.</returns>
        public static RenamedDatabaseName Parse(string renamedDatabaseName, bool allowUnparsed) =>
            TryParse(renamedDatabaseName, allowUnparsed, out RenamedDatabaseName result) ? result : throw new sys::ArgumentException("The given resource-name matches no pattern.");

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="RenamedDatabaseName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>databases/{database}</c></description></item></list>
        /// </remarks>
        /// <param name="renamedDatabaseName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="RenamedDatabaseName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string renamedDatabaseName, out RenamedDatabaseName result) =>
            TryParse(renamedDatabaseName, false, out result);

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="RenamedDatabaseName"/> instance;
        /// optionally allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>databases/{database}</c></description></item></list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="renamedDatabaseName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="RenamedDatabaseName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string renamedDatabaseName, bool allowUnparsed, out RenamedDatabaseName result)
        {
            gax::GaxPreconditions.CheckNotNull(renamedDatabaseName, nameof(renamedDatabaseName));
            gax::TemplatedResourceName resourceName;
            if (s_database.TryParseName(renamedDatabaseName, out resourceName))
            {
                result = FromDatabase(resourceName[0]);
                return true;
            }
            if (allowUnparsed)
            {
                if (gax::UnparsedResourceName.TryParse(renamedDatabaseName, out gax::UnparsedResourceName unparsedResourceName))
                {
                    result = FromUnparsed(unparsedResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        private RenamedDatabaseName(ResourceNameType type, gax::UnparsedResourceName unparsedResourceName = null, string databaseId = null)
        {
            Type = type;
            UnparsedResource = unparsedResourceName;
            DatabaseId = databaseId;
        }

        /// <summary>
        /// Constructs a new instance of a <see cref="RenamedDatabaseName"/> class from the component parts of pattern
        /// <c>databases/{database}</c>
        /// </summary>
        /// <param name="databaseId">The <c>Database</c> ID. Must not be <c>null</c> or empty.</param>
        public RenamedDatabaseName(string databaseId) : this(ResourceNameType.Database, databaseId: gax::GaxPreconditions.CheckNotNullOrEmpty(databaseId, nameof(databaseId)))
        {
        }

        /// <summary>The <see cref="ResourceNameType"/> of the contained resource name.</summary>
        public ResourceNameType Type { get; }

        /// <summary>
        /// The contained <see cref="gax::UnparsedResourceName"/>. Only non-<c>null</c> if this instance contains an
        /// unparsed resource name.
        /// </summary>
        public gax::UnparsedResourceName UnparsedResource { get; }

        /// <summary>
        /// The <c>Database</c> ID. Will not be <c>null</c>, unless this instance contains an unparsed resource name.
        /// </summary>
        public string DatabaseId { get; }

        /// <summary>Whether this instance contains a resource name with a known pattern.</summary>
        public bool IsKnownPattern => Type != ResourceNameType.Unparsed;

        /// <summary>The string representation of the resource name.</summary>
        /// <returns>The string representation of the resource name.</returns>
        public override string ToString()
        {
            switch (Type)
            {
                case ResourceNameType.Unparsed: return UnparsedResource.ToString();
                case ResourceNameType.Database: return s_database.Expand(DatabaseId);
                default: throw new sys::InvalidOperationException("Unrecognized resource-type.");
            }
        }

        /// <summary>Returns a hash code for this resource name.</summary>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as RenamedDatabaseName);

        /// <inheritdoc/>
        public bool Equals(RenamedDatabaseName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(RenamedDatabaseName a, RenamedDatabaseName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(RenamedDatabaseName a, RenamedDatabaseName b) => !(a == b);
    }

    public partial class ResourceRequest
    {
        /// <summary>
        /// <see cref="pn::CommonLocationName"/>-typed view over the <see cref="Parent"/> resource name property.
        /// </summary>
        public pn::CommonLocationName ParentAsCommonLocationName
        {
            get => string.IsNullOrEmpty(Parent) ? null : pn::CommonLocationName.Parse(Parent, allowUnparsed: true);
            set => Parent = value?.ToString() ?? "";
        }

        /// <summary>
        /// <see cref="RenamedDatabaseName"/>-typed view over the <see cref="Database"/> resource name property.
        /// </summary>
        public RenamedDatabaseName DatabaseAsRenamedDatabaseName
        {
            get => string.IsNullOrEmpty(Database) ? null : RenamedDatabaseName.Parse(Database, allowUnparsed: true);
            set => Database = value?.ToString() ?? "";
        }
    }

    public partial class Resource
    {
        /// <summary>
        /// <see cref="tp::ResourceName"/>-typed view over the <see cref="Name"/> resource name property.
        /// </summary>
        public tp::ResourceName ResourceName
        {
            get => string.IsNullOrEmpty(Name) ? null : tp::ResourceName.Parse(Name, allowUnparsed: true);
            set => Name = value?.ToString() ?? "";
        }
    }
}
