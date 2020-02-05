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

using gax = Google.Api.Gax;
using sys = System;

namespace Testing.ChildResource
{
    /// <summary>Resource name for the <c>Project</c> resource.</summary>
    public sealed partial class ProjectName : gax::IResourceName, sys::IEquatable<ProjectName>
    {
        /// <summary>The possible contents of <see cref="ProjectName"/>.</summary>
        public enum ResourceNameType
        {
            /// <summary>An unparsed resource name.</summary>
            Unparsed = 0,

            /// <summary>A resource name with pattern <c>projects/{project}</c>.</summary>
            Project = 1
        }

        private static gax::PathTemplate s_project = new gax::PathTemplate("projects/{project}");

        /// <summary>Creates a <see cref="ProjectName"/> containing an unparsed resource name.</summary>
        /// <param name="unparsedResourceName">The unparsed resource name. Must not be <c>null</c>.</param>
        /// <returns>
        /// A new instance of <see cref="ProjectName"/> containing the provided <paramref name="unparsedResourceName"/>.
        /// </returns>
        public static ProjectName FromUnparsed(gax::UnparsedResourceName unparsedResourceName) =>
            new ProjectName(ResourceNameType.Unparsed, gax::GaxPreconditions.CheckNotNull(unparsedResourceName, nameof(unparsedResourceName)));

        /// <summary>Creates a <see cref="ProjectName"/> with the pattern <c>projects/{project}</c>.</summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="ProjectName"/> constructed from the provided ids.</returns>
        public static ProjectName FromProject(string projectId) =>
            new ProjectName(ResourceNameType.Project, projectId: gax::GaxPreconditions.CheckNotNullOrEmpty(projectId, nameof(projectId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="ProjectName"/> with pattern
        /// <c>projects/{project}</c>.
        /// </summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="ProjectName"/> with pattern <c>projects/{project}</c>.
        /// </returns>
        public static string Format(string projectId) => FormatProject(projectId);

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="ProjectName"/> with pattern
        /// <c>projects/{project}</c>.
        /// </summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="ProjectName"/> with pattern <c>projects/{project}</c>.
        /// </returns>
        public static string FormatProject(string projectId) =>
            s_project.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(projectId, nameof(projectId)));

        /// <summary>Parses the given resource name string into a new <see cref="ProjectName"/> instance.</summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>projects/{project}</c></description></item></list>
        /// </remarks>
        /// <param name="projectName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="ProjectName"/> if successful.</returns>
        public static ProjectName Parse(string projectName) => Parse(projectName, false);

        /// <summary>
        /// Parses the given resource name string into a new <see cref="ProjectName"/> instance; optionally allowing an
        /// unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>projects/{project}</c></description></item></list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="projectName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <returns>The parsed <see cref="ProjectName"/> if successful.</returns>
        public static ProjectName Parse(string projectName, bool allowUnparsed) =>
            TryParse(projectName, allowUnparsed, out ProjectName result) ? result : throw new sys::ArgumentException("The given resource-name matches no pattern.");

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="ProjectName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>projects/{project}</c></description></item></list>
        /// </remarks>
        /// <param name="projectName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="ProjectName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string projectName, out ProjectName result) => TryParse(projectName, false, out result);

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="ProjectName"/> instance; optionally
        /// allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>projects/{project}</c></description></item></list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="projectName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="ProjectName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string projectName, bool allowUnparsed, out ProjectName result)
        {
            gax::GaxPreconditions.CheckNotNull(projectName, nameof(projectName));
            gax::TemplatedResourceName resourceName;
            if (s_project.TryParseName(projectName, out resourceName))
            {
                result = FromProject(resourceName[0]);
                return true;
            }
            if (allowUnparsed)
            {
                if (gax::UnparsedResourceName.TryParse(projectName, out gax::UnparsedResourceName unparsedResourceName))
                {
                    result = FromUnparsed(unparsedResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        private ProjectName(ResourceNameType type, gax::UnparsedResourceName unparsedResourceName = null, string projectId = null)
        {
            Type = type;
            UnparsedResource = unparsedResourceName;
            ProjectId = projectId;
        }

        /// <summary>
        /// Constructs a new instance of a <see cref="ProjectName"/> class from the component parts of pattern
        /// <c>projects/{project}</c>
        /// </summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c> or empty.</param>
        public ProjectName(string projectId) : this(ResourceNameType.Project, projectId: gax::GaxPreconditions.CheckNotNullOrEmpty(projectId, nameof(projectId)))
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
        /// The <c>Project</c> ID. Will not be <c>null</c>, unless this instance contains an unparsed resource name.
        /// </summary>
        public string ProjectId { get; }

        /// <inheritdoc/>
        public bool IsKnownPattern => Type != ResourceNameType.Unparsed;

        /// <inheritdoc/>
        public override string ToString()
        {
            switch (Type)
            {
                case ResourceNameType.Unparsed: return UnparsedResource.ToString();
                case ResourceNameType.Project: return s_project.Expand(ProjectId);
                default: throw new sys::InvalidOperationException("Unrecognized resource-type.");
            }
        }

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as ProjectName);

        /// <inheritdoc/>
        public bool Equals(ProjectName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(ProjectName a, ProjectName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(ProjectName a, ProjectName b) => !(a == b);
    }

    /// <summary>Resource name for the <c>SinglePattern</c> resource.</summary>
    public sealed partial class SinglePatternName : gax::IResourceName, sys::IEquatable<SinglePatternName>
    {
        /// <summary>The possible contents of <see cref="SinglePatternName"/>.</summary>
        public enum ResourceNameType
        {
            /// <summary>An unparsed resource name.</summary>
            Unparsed = 0,

            /// <summary>A resource name with pattern <c>projects/{project}/items/{item_id}</c>.</summary>
            ProjectItem = 1
        }

        private static gax::PathTemplate s_projectItem = new gax::PathTemplate("projects/{project}/items/{item_id}");

        /// <summary>Creates a <see cref="SinglePatternName"/> containing an unparsed resource name.</summary>
        /// <param name="unparsedResourceName">The unparsed resource name. Must not be <c>null</c>.</param>
        /// <returns>
        /// A new instance of <see cref="SinglePatternName"/> containing the provided
        /// <paramref name="unparsedResourceName"/>.
        /// </returns>
        public static SinglePatternName FromUnparsed(gax::UnparsedResourceName unparsedResourceName) =>
            new SinglePatternName(ResourceNameType.Unparsed, gax::GaxPreconditions.CheckNotNull(unparsedResourceName, nameof(unparsedResourceName)));

        /// <summary>
        /// Creates a <see cref="SinglePatternName"/> with the pattern <c>projects/{project}/items/{item_id}</c>.
        /// </summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="SinglePatternName"/> constructed from the provided ids.</returns>
        public static SinglePatternName FromProjectItem(string projectId, string itemId) =>
            new SinglePatternName(ResourceNameType.ProjectItem, projectId: gax::GaxPreconditions.CheckNotNullOrEmpty(projectId, nameof(projectId)), itemId: gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="SinglePatternName"/> with pattern
        /// <c>projects/{project}/items/{item_id}</c>.
        /// </summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="SinglePatternName"/> with pattern
        /// <c>projects/{project}/items/{item_id}</c>.
        /// </returns>
        public static string Format(string projectId, string itemId) => FormatProjectItem(projectId, itemId);

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="SinglePatternName"/> with pattern
        /// <c>projects/{project}/items/{item_id}</c>.
        /// </summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="SinglePatternName"/> with pattern
        /// <c>projects/{project}/items/{item_id}</c>.
        /// </returns>
        public static string FormatProjectItem(string projectId, string itemId) =>
            s_projectItem.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(projectId, nameof(projectId)), gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Parses the given resource name string into a new <see cref="SinglePatternName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>projects/{project}/items/{item_id}</c></description></item>
        /// </list>
        /// </remarks>
        /// <param name="singlePatternName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="SinglePatternName"/> if successful.</returns>
        public static SinglePatternName Parse(string singlePatternName) => Parse(singlePatternName, false);

        /// <summary>
        /// Parses the given resource name string into a new <see cref="SinglePatternName"/> instance; optionally
        /// allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>projects/{project}/items/{item_id}</c></description></item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="singlePatternName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <returns>The parsed <see cref="SinglePatternName"/> if successful.</returns>
        public static SinglePatternName Parse(string singlePatternName, bool allowUnparsed) =>
            TryParse(singlePatternName, allowUnparsed, out SinglePatternName result) ? result : throw new sys::ArgumentException("The given resource-name matches no pattern.");

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="SinglePatternName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>projects/{project}/items/{item_id}</c></description></item>
        /// </list>
        /// </remarks>
        /// <param name="singlePatternName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="SinglePatternName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string singlePatternName, out SinglePatternName result) =>
            TryParse(singlePatternName, false, out result);

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="SinglePatternName"/> instance;
        /// optionally allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>projects/{project}/items/{item_id}</c></description></item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="singlePatternName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="SinglePatternName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string singlePatternName, bool allowUnparsed, out SinglePatternName result)
        {
            gax::GaxPreconditions.CheckNotNull(singlePatternName, nameof(singlePatternName));
            gax::TemplatedResourceName resourceName;
            if (s_projectItem.TryParseName(singlePatternName, out resourceName))
            {
                result = FromProjectItem(resourceName[0], resourceName[1]);
                return true;
            }
            if (allowUnparsed)
            {
                if (gax::UnparsedResourceName.TryParse(singlePatternName, out gax::UnparsedResourceName unparsedResourceName))
                {
                    result = FromUnparsed(unparsedResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        private SinglePatternName(ResourceNameType type, gax::UnparsedResourceName unparsedResourceName = null, string itemId = null, string projectId = null)
        {
            Type = type;
            UnparsedResource = unparsedResourceName;
            ItemId = itemId;
            ProjectId = projectId;
        }

        /// <summary>
        /// Constructs a new instance of a <see cref="SinglePatternName"/> class from the component parts of pattern
        /// <c>projects/{project}/items/{item_id}</c>
        /// </summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        public SinglePatternName(string projectId, string itemId) : this(ResourceNameType.ProjectItem, projectId: gax::GaxPreconditions.CheckNotNullOrEmpty(projectId, nameof(projectId)), itemId: gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)))
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
        /// The <c>Item</c> ID. Will not be <c>null</c>, unless this instance contains an unparsed resource name.
        /// </summary>
        public string ItemId { get; }

        /// <summary>
        /// The <c>Project</c> ID. Will not be <c>null</c>, unless this instance contains an unparsed resource name.
        /// </summary>
        public string ProjectId { get; }

        /// <inheritdoc/>
        public bool IsKnownPattern => Type != ResourceNameType.Unparsed;

        /// <inheritdoc/>
        public override string ToString()
        {
            switch (Type)
            {
                case ResourceNameType.Unparsed: return UnparsedResource.ToString();
                case ResourceNameType.ProjectItem: return s_projectItem.Expand(ProjectId, ItemId);
                default: throw new sys::InvalidOperationException("Unrecognized resource-type.");
            }
        }

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as SinglePatternName);

        /// <inheritdoc/>
        public bool Equals(SinglePatternName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(SinglePatternName a, SinglePatternName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(SinglePatternName a, SinglePatternName b) => !(a == b);
    }

    /// <summary>Resource name for the <c>Org</c> resource.</summary>
    public sealed partial class OrgName : gax::IResourceName, sys::IEquatable<OrgName>
    {
        /// <summary>The possible contents of <see cref="OrgName"/>.</summary>
        public enum ResourceNameType
        {
            /// <summary>An unparsed resource name.</summary>
            Unparsed = 0,

            /// <summary>A resource name with pattern <c>orgs/{org}</c>.</summary>
            Org = 1
        }

        private static gax::PathTemplate s_org = new gax::PathTemplate("orgs/{org}");

        /// <summary>Creates a <see cref="OrgName"/> containing an unparsed resource name.</summary>
        /// <param name="unparsedResourceName">The unparsed resource name. Must not be <c>null</c>.</param>
        /// <returns>
        /// A new instance of <see cref="OrgName"/> containing the provided <paramref name="unparsedResourceName"/>.
        /// </returns>
        public static OrgName FromUnparsed(gax::UnparsedResourceName unparsedResourceName) =>
            new OrgName(ResourceNameType.Unparsed, gax::GaxPreconditions.CheckNotNull(unparsedResourceName, nameof(unparsedResourceName)));

        /// <summary>Creates a <see cref="OrgName"/> with the pattern <c>orgs/{org}</c>.</summary>
        /// <param name="orgId">The <c>Org</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="OrgName"/> constructed from the provided ids.</returns>
        public static OrgName FromOrg(string orgId) =>
            new OrgName(ResourceNameType.Org, orgId: gax::GaxPreconditions.CheckNotNullOrEmpty(orgId, nameof(orgId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="OrgName"/> with pattern <c>orgs/{org}</c>.
        /// </summary>
        /// <param name="orgId">The <c>Org</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>The string representation of this <see cref="OrgName"/> with pattern <c>orgs/{org}</c>.</returns>
        public static string Format(string orgId) => FormatOrg(orgId);

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="OrgName"/> with pattern <c>orgs/{org}</c>.
        /// </summary>
        /// <param name="orgId">The <c>Org</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>The string representation of this <see cref="OrgName"/> with pattern <c>orgs/{org}</c>.</returns>
        public static string FormatOrg(string orgId) =>
            s_org.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(orgId, nameof(orgId)));

        /// <summary>Parses the given resource name string into a new <see cref="OrgName"/> instance.</summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>orgs/{org}</c></description></item></list>
        /// </remarks>
        /// <param name="orgName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="OrgName"/> if successful.</returns>
        public static OrgName Parse(string orgName) => Parse(orgName, false);

        /// <summary>
        /// Parses the given resource name string into a new <see cref="OrgName"/> instance; optionally allowing an
        /// unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>orgs/{org}</c></description></item></list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="orgName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <returns>The parsed <see cref="OrgName"/> if successful.</returns>
        public static OrgName Parse(string orgName, bool allowUnparsed) =>
            TryParse(orgName, allowUnparsed, out OrgName result) ? result : throw new sys::ArgumentException("The given resource-name matches no pattern.");

        /// <summary>Tries to parse the given resource name string into a new <see cref="OrgName"/> instance.</summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>orgs/{org}</c></description></item></list>
        /// </remarks>
        /// <param name="orgName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="OrgName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string orgName, out OrgName result) => TryParse(orgName, false, out result);

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="OrgName"/> instance; optionally allowing
        /// an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>orgs/{org}</c></description></item></list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="orgName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="OrgName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string orgName, bool allowUnparsed, out OrgName result)
        {
            gax::GaxPreconditions.CheckNotNull(orgName, nameof(orgName));
            gax::TemplatedResourceName resourceName;
            if (s_org.TryParseName(orgName, out resourceName))
            {
                result = FromOrg(resourceName[0]);
                return true;
            }
            if (allowUnparsed)
            {
                if (gax::UnparsedResourceName.TryParse(orgName, out gax::UnparsedResourceName unparsedResourceName))
                {
                    result = FromUnparsed(unparsedResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        private OrgName(ResourceNameType type, gax::UnparsedResourceName unparsedResourceName = null, string orgId = null)
        {
            Type = type;
            UnparsedResource = unparsedResourceName;
            OrgId = orgId;
        }

        /// <summary>
        /// Constructs a new instance of a <see cref="OrgName"/> class from the component parts of pattern <c>orgs/{org}</c>
        /// </summary>
        /// <param name="orgId">The <c>Org</c> ID. Must not be <c>null</c> or empty.</param>
        public OrgName(string orgId) : this(ResourceNameType.Org, orgId: gax::GaxPreconditions.CheckNotNullOrEmpty(orgId, nameof(orgId)))
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
        /// The <c>Org</c> ID. Will not be <c>null</c>, unless this instance contains an unparsed resource name.
        /// </summary>
        public string OrgId { get; }

        /// <inheritdoc/>
        public bool IsKnownPattern => Type != ResourceNameType.Unparsed;

        /// <inheritdoc/>
        public override string ToString()
        {
            switch (Type)
            {
                case ResourceNameType.Unparsed: return UnparsedResource.ToString();
                case ResourceNameType.Org: return s_org.Expand(OrgId);
                default: throw new sys::InvalidOperationException("Unrecognized resource-type.");
            }
        }

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as OrgName);

        /// <inheritdoc/>
        public bool Equals(OrgName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(OrgName a, OrgName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(OrgName a, OrgName b) => !(a == b);
    }

    /// <summary>Resource name for the <c>Dept</c> resource.</summary>
    public sealed partial class DeptName : gax::IResourceName, sys::IEquatable<DeptName>
    {
        /// <summary>The possible contents of <see cref="DeptName"/>.</summary>
        public enum ResourceNameType
        {
            /// <summary>An unparsed resource name.</summary>
            Unparsed = 0,

            /// <summary>A resource name with pattern <c>depts/{dept}</c>.</summary>
            Dept = 1
        }

        private static gax::PathTemplate s_dept = new gax::PathTemplate("depts/{dept}");

        /// <summary>Creates a <see cref="DeptName"/> containing an unparsed resource name.</summary>
        /// <param name="unparsedResourceName">The unparsed resource name. Must not be <c>null</c>.</param>
        /// <returns>
        /// A new instance of <see cref="DeptName"/> containing the provided <paramref name="unparsedResourceName"/>.
        /// </returns>
        public static DeptName FromUnparsed(gax::UnparsedResourceName unparsedResourceName) =>
            new DeptName(ResourceNameType.Unparsed, gax::GaxPreconditions.CheckNotNull(unparsedResourceName, nameof(unparsedResourceName)));

        /// <summary>Creates a <see cref="DeptName"/> with the pattern <c>depts/{dept}</c>.</summary>
        /// <param name="deptId">The <c>Dept</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="DeptName"/> constructed from the provided ids.</returns>
        public static DeptName FromDept(string deptId) =>
            new DeptName(ResourceNameType.Dept, deptId: gax::GaxPreconditions.CheckNotNullOrEmpty(deptId, nameof(deptId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="DeptName"/> with pattern <c>depts/{dept}</c>
        /// .
        /// </summary>
        /// <param name="deptId">The <c>Dept</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="DeptName"/> with pattern <c>depts/{dept}</c>.
        /// </returns>
        public static string Format(string deptId) => FormatDept(deptId);

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="DeptName"/> with pattern <c>depts/{dept}</c>
        /// .
        /// </summary>
        /// <param name="deptId">The <c>Dept</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="DeptName"/> with pattern <c>depts/{dept}</c>.
        /// </returns>
        public static string FormatDept(string deptId) =>
            s_dept.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(deptId, nameof(deptId)));

        /// <summary>Parses the given resource name string into a new <see cref="DeptName"/> instance.</summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>depts/{dept}</c></description></item></list>
        /// </remarks>
        /// <param name="deptName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="DeptName"/> if successful.</returns>
        public static DeptName Parse(string deptName) => Parse(deptName, false);

        /// <summary>
        /// Parses the given resource name string into a new <see cref="DeptName"/> instance; optionally allowing an
        /// unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>depts/{dept}</c></description></item></list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="deptName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <returns>The parsed <see cref="DeptName"/> if successful.</returns>
        public static DeptName Parse(string deptName, bool allowUnparsed) =>
            TryParse(deptName, allowUnparsed, out DeptName result) ? result : throw new sys::ArgumentException("The given resource-name matches no pattern.");

        /// <summary>Tries to parse the given resource name string into a new <see cref="DeptName"/> instance.</summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>depts/{dept}</c></description></item></list>
        /// </remarks>
        /// <param name="deptName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="DeptName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string deptName, out DeptName result) => TryParse(deptName, false, out result);

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="DeptName"/> instance; optionally
        /// allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>depts/{dept}</c></description></item></list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="deptName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="DeptName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string deptName, bool allowUnparsed, out DeptName result)
        {
            gax::GaxPreconditions.CheckNotNull(deptName, nameof(deptName));
            gax::TemplatedResourceName resourceName;
            if (s_dept.TryParseName(deptName, out resourceName))
            {
                result = FromDept(resourceName[0]);
                return true;
            }
            if (allowUnparsed)
            {
                if (gax::UnparsedResourceName.TryParse(deptName, out gax::UnparsedResourceName unparsedResourceName))
                {
                    result = FromUnparsed(unparsedResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        private DeptName(ResourceNameType type, gax::UnparsedResourceName unparsedResourceName = null, string deptId = null)
        {
            Type = type;
            UnparsedResource = unparsedResourceName;
            DeptId = deptId;
        }

        /// <summary>
        /// Constructs a new instance of a <see cref="DeptName"/> class from the component parts of pattern
        /// <c>depts/{dept}</c>
        /// </summary>
        /// <param name="deptId">The <c>Dept</c> ID. Must not be <c>null</c> or empty.</param>
        public DeptName(string deptId) : this(ResourceNameType.Dept, deptId: gax::GaxPreconditions.CheckNotNullOrEmpty(deptId, nameof(deptId)))
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
        /// The <c>Dept</c> ID. Will not be <c>null</c>, unless this instance contains an unparsed resource name.
        /// </summary>
        public string DeptId { get; }

        /// <inheritdoc/>
        public bool IsKnownPattern => Type != ResourceNameType.Unparsed;

        /// <inheritdoc/>
        public override string ToString()
        {
            switch (Type)
            {
                case ResourceNameType.Unparsed: return UnparsedResource.ToString();
                case ResourceNameType.Dept: return s_dept.Expand(DeptId);
                default: throw new sys::InvalidOperationException("Unrecognized resource-type.");
            }
        }

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as DeptName);

        /// <inheritdoc/>
        public bool Equals(DeptName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(DeptName a, DeptName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(DeptName a, DeptName b) => !(a == b);
    }

    /// <summary>Resource name for the <c>TriplePattern</c> resource.</summary>
    public sealed partial class TriplePatternName : gax::IResourceName, sys::IEquatable<TriplePatternName>
    {
        /// <summary>The possible contents of <see cref="TriplePatternName"/>.</summary>
        public enum ResourceNameType
        {
            /// <summary>An unparsed resource name.</summary>
            Unparsed = 0,

            /// <summary>A resource name with pattern <c>projects/{project}/items/{item_id}</c>.</summary>
            ProjectItem = 1,

            /// <summary>A resource name with pattern <c>orgs/{org}/items/{item_id}</c>.</summary>
            OrgItem = 2,

            /// <summary>A resource name with pattern <c>depts/{dept}/items/{item_id}</c>.</summary>
            DeptItem = 3
        }

        private static gax::PathTemplate s_projectItem = new gax::PathTemplate("projects/{project}/items/{item_id}");

        private static gax::PathTemplate s_orgItem = new gax::PathTemplate("orgs/{org}/items/{item_id}");

        private static gax::PathTemplate s_deptItem = new gax::PathTemplate("depts/{dept}/items/{item_id}");

        /// <summary>Creates a <see cref="TriplePatternName"/> containing an unparsed resource name.</summary>
        /// <param name="unparsedResourceName">The unparsed resource name. Must not be <c>null</c>.</param>
        /// <returns>
        /// A new instance of <see cref="TriplePatternName"/> containing the provided
        /// <paramref name="unparsedResourceName"/>.
        /// </returns>
        public static TriplePatternName FromUnparsed(gax::UnparsedResourceName unparsedResourceName) =>
            new TriplePatternName(ResourceNameType.Unparsed, gax::GaxPreconditions.CheckNotNull(unparsedResourceName, nameof(unparsedResourceName)));

        /// <summary>
        /// Creates a <see cref="TriplePatternName"/> with the pattern <c>projects/{project}/items/{item_id}</c>.
        /// </summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="TriplePatternName"/> constructed from the provided ids.</returns>
        public static TriplePatternName FromProjectItem(string projectId, string itemId) =>
            new TriplePatternName(ResourceNameType.ProjectItem, projectId: gax::GaxPreconditions.CheckNotNullOrEmpty(projectId, nameof(projectId)), itemId: gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Creates a <see cref="TriplePatternName"/> with the pattern <c>orgs/{org}/items/{item_id}</c>.
        /// </summary>
        /// <param name="orgId">The <c>Org</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="TriplePatternName"/> constructed from the provided ids.</returns>
        public static TriplePatternName FromOrgItem(string orgId, string itemId) =>
            new TriplePatternName(ResourceNameType.OrgItem, orgId: gax::GaxPreconditions.CheckNotNullOrEmpty(orgId, nameof(orgId)), itemId: gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Creates a <see cref="TriplePatternName"/> with the pattern <c>depts/{dept}/items/{item_id}</c>.
        /// </summary>
        /// <param name="deptId">The <c>Dept</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="TriplePatternName"/> constructed from the provided ids.</returns>
        public static TriplePatternName FromDeptItem(string deptId, string itemId) =>
            new TriplePatternName(ResourceNameType.DeptItem, deptId: gax::GaxPreconditions.CheckNotNullOrEmpty(deptId, nameof(deptId)), itemId: gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="TriplePatternName"/> with pattern
        /// <c>projects/{project}/items/{item_id}</c>.
        /// </summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="TriplePatternName"/> with pattern
        /// <c>projects/{project}/items/{item_id}</c>.
        /// </returns>
        public static string Format(string projectId, string itemId) => FormatProjectItem(projectId, itemId);

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="TriplePatternName"/> with pattern
        /// <c>projects/{project}/items/{item_id}</c>.
        /// </summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="TriplePatternName"/> with pattern
        /// <c>projects/{project}/items/{item_id}</c>.
        /// </returns>
        public static string FormatProjectItem(string projectId, string itemId) =>
            s_projectItem.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(projectId, nameof(projectId)), gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="TriplePatternName"/> with pattern
        /// <c>orgs/{org}/items/{item_id}</c>.
        /// </summary>
        /// <param name="orgId">The <c>Org</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="TriplePatternName"/> with pattern <c>orgs/{org}/items/{item_id}</c>
        /// .
        /// </returns>
        public static string FormatOrgItem(string orgId, string itemId) =>
            s_orgItem.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(orgId, nameof(orgId)), gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="TriplePatternName"/> with pattern
        /// <c>depts/{dept}/items/{item_id}</c>.
        /// </summary>
        /// <param name="deptId">The <c>Dept</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="TriplePatternName"/> with pattern
        /// <c>depts/{dept}/items/{item_id}</c>.
        /// </returns>
        public static string FormatDeptItem(string deptId, string itemId) =>
            s_deptItem.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(deptId, nameof(deptId)), gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Parses the given resource name string into a new <see cref="TriplePatternName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>projects/{project}/items/{item_id}</c></description></item>
        /// <item><description><c>orgs/{org}/items/{item_id}</c></description></item>
        /// <item><description><c>depts/{dept}/items/{item_id}</c></description></item>
        /// </list>
        /// </remarks>
        /// <param name="triplePatternName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="TriplePatternName"/> if successful.</returns>
        public static TriplePatternName Parse(string triplePatternName) => Parse(triplePatternName, false);

        /// <summary>
        /// Parses the given resource name string into a new <see cref="TriplePatternName"/> instance; optionally
        /// allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>projects/{project}/items/{item_id}</c></description></item>
        /// <item><description><c>orgs/{org}/items/{item_id}</c></description></item>
        /// <item><description><c>depts/{dept}/items/{item_id}</c></description></item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="triplePatternName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <returns>The parsed <see cref="TriplePatternName"/> if successful.</returns>
        public static TriplePatternName Parse(string triplePatternName, bool allowUnparsed) =>
            TryParse(triplePatternName, allowUnparsed, out TriplePatternName result) ? result : throw new sys::ArgumentException("The given resource-name matches no pattern.");

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="TriplePatternName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>projects/{project}/items/{item_id}</c></description></item>
        /// <item><description><c>orgs/{org}/items/{item_id}</c></description></item>
        /// <item><description><c>depts/{dept}/items/{item_id}</c></description></item>
        /// </list>
        /// </remarks>
        /// <param name="triplePatternName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="TriplePatternName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string triplePatternName, out TriplePatternName result) =>
            TryParse(triplePatternName, false, out result);

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="TriplePatternName"/> instance;
        /// optionally allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>projects/{project}/items/{item_id}</c></description></item>
        /// <item><description><c>orgs/{org}/items/{item_id}</c></description></item>
        /// <item><description><c>depts/{dept}/items/{item_id}</c></description></item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="triplePatternName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="TriplePatternName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string triplePatternName, bool allowUnparsed, out TriplePatternName result)
        {
            gax::GaxPreconditions.CheckNotNull(triplePatternName, nameof(triplePatternName));
            gax::TemplatedResourceName resourceName;
            if (s_projectItem.TryParseName(triplePatternName, out resourceName))
            {
                result = FromProjectItem(resourceName[0], resourceName[1]);
                return true;
            }
            if (s_orgItem.TryParseName(triplePatternName, out resourceName))
            {
                result = FromOrgItem(resourceName[0], resourceName[1]);
                return true;
            }
            if (s_deptItem.TryParseName(triplePatternName, out resourceName))
            {
                result = FromDeptItem(resourceName[0], resourceName[1]);
                return true;
            }
            if (allowUnparsed)
            {
                if (gax::UnparsedResourceName.TryParse(triplePatternName, out gax::UnparsedResourceName unparsedResourceName))
                {
                    result = FromUnparsed(unparsedResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        private TriplePatternName(ResourceNameType type, gax::UnparsedResourceName unparsedResourceName = null, string deptId = null, string itemId = null, string orgId = null, string projectId = null)
        {
            Type = type;
            UnparsedResource = unparsedResourceName;
            DeptId = deptId;
            ItemId = itemId;
            OrgId = orgId;
            ProjectId = projectId;
        }

        /// <summary>
        /// Constructs a new instance of a <see cref="TriplePatternName"/> class from the component parts of pattern
        /// <c>projects/{project}/items/{item_id}</c>
        /// </summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        public TriplePatternName(string projectId, string itemId) : this(ResourceNameType.ProjectItem, projectId: gax::GaxPreconditions.CheckNotNullOrEmpty(projectId, nameof(projectId)), itemId: gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)))
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
        /// The <c>Dept</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string DeptId { get; }

        /// <summary>
        /// The <c>Item</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string ItemId { get; }

        /// <summary>
        /// The <c>Org</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string OrgId { get; }

        /// <summary>
        /// The <c>Project</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string ProjectId { get; }

        /// <inheritdoc/>
        public bool IsKnownPattern => Type != ResourceNameType.Unparsed;

        /// <inheritdoc/>
        public override string ToString()
        {
            switch (Type)
            {
                case ResourceNameType.Unparsed: return UnparsedResource.ToString();
                case ResourceNameType.ProjectItem: return s_projectItem.Expand(ProjectId, ItemId);
                case ResourceNameType.OrgItem: return s_orgItem.Expand(OrgId, ItemId);
                case ResourceNameType.DeptItem: return s_deptItem.Expand(DeptId, ItemId);
                default: throw new sys::InvalidOperationException("Unrecognized resource-type.");
            }
        }

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as TriplePatternName);

        /// <inheritdoc/>
        public bool Equals(TriplePatternName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(TriplePatternName a, TriplePatternName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(TriplePatternName a, TriplePatternName b) => !(a == b);
    }

    /// <summary>Resource name for the <c>TripleWildcardPattern</c> resource.</summary>
    public sealed partial class TripleWildcardPatternName : gax::IResourceName, sys::IEquatable<TripleWildcardPatternName>
    {
        /// <summary>The possible contents of <see cref="TripleWildcardPatternName"/>.</summary>
        public enum ResourceNameType
        {
            /// <summary>An unparsed resource name.</summary>
            Unparsed = 0,

            /// <summary>A resource name with pattern <c>projects/{project}/items/{item_id}</c>.</summary>
            ProjectItem = 1,

            /// <summary>A resource name with pattern <c>orgs/{org}/items/{item_id}</c>.</summary>
            OrgItem = 2,

            /// <summary>A resource name with pattern <c>depts/{dept}/items/{item_id}</c>.</summary>
            DeptItem = 3
        }

        private static gax::PathTemplate s_projectItem = new gax::PathTemplate("projects/{project}/items/{item_id}");

        private static gax::PathTemplate s_orgItem = new gax::PathTemplate("orgs/{org}/items/{item_id}");

        private static gax::PathTemplate s_deptItem = new gax::PathTemplate("depts/{dept}/items/{item_id}");

        /// <summary>Creates a <see cref="TripleWildcardPatternName"/> containing an unparsed resource name.</summary>
        /// <param name="unparsedResourceName">The unparsed resource name. Must not be <c>null</c>.</param>
        /// <returns>
        /// A new instance of <see cref="TripleWildcardPatternName"/> containing the provided
        /// <paramref name="unparsedResourceName"/>.
        /// </returns>
        public static TripleWildcardPatternName FromUnparsed(gax::UnparsedResourceName unparsedResourceName) =>
            new TripleWildcardPatternName(ResourceNameType.Unparsed, gax::GaxPreconditions.CheckNotNull(unparsedResourceName, nameof(unparsedResourceName)));

        /// <summary>
        /// Creates a <see cref="TripleWildcardPatternName"/> with the pattern <c>projects/{project}/items/{item_id}</c>
        /// .
        /// </summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// A new instance of <see cref="TripleWildcardPatternName"/> constructed from the provided ids.
        /// </returns>
        public static TripleWildcardPatternName FromProjectItem(string projectId, string itemId) =>
            new TripleWildcardPatternName(ResourceNameType.ProjectItem, projectId: gax::GaxPreconditions.CheckNotNullOrEmpty(projectId, nameof(projectId)), itemId: gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Creates a <see cref="TripleWildcardPatternName"/> with the pattern <c>orgs/{org}/items/{item_id}</c>.
        /// </summary>
        /// <param name="orgId">The <c>Org</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// A new instance of <see cref="TripleWildcardPatternName"/> constructed from the provided ids.
        /// </returns>
        public static TripleWildcardPatternName FromOrgItem(string orgId, string itemId) =>
            new TripleWildcardPatternName(ResourceNameType.OrgItem, orgId: gax::GaxPreconditions.CheckNotNullOrEmpty(orgId, nameof(orgId)), itemId: gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Creates a <see cref="TripleWildcardPatternName"/> with the pattern <c>depts/{dept}/items/{item_id}</c>.
        /// </summary>
        /// <param name="deptId">The <c>Dept</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// A new instance of <see cref="TripleWildcardPatternName"/> constructed from the provided ids.
        /// </returns>
        public static TripleWildcardPatternName FromDeptItem(string deptId, string itemId) =>
            new TripleWildcardPatternName(ResourceNameType.DeptItem, deptId: gax::GaxPreconditions.CheckNotNullOrEmpty(deptId, nameof(deptId)), itemId: gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="TripleWildcardPatternName"/> with pattern
        /// <c>projects/{project}/items/{item_id}</c>.
        /// </summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="TripleWildcardPatternName"/> with pattern
        /// <c>projects/{project}/items/{item_id}</c>.
        /// </returns>
        public static string Format(string projectId, string itemId) => FormatProjectItem(projectId, itemId);

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="TripleWildcardPatternName"/> with pattern
        /// <c>projects/{project}/items/{item_id}</c>.
        /// </summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="TripleWildcardPatternName"/> with pattern
        /// <c>projects/{project}/items/{item_id}</c>.
        /// </returns>
        public static string FormatProjectItem(string projectId, string itemId) =>
            s_projectItem.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(projectId, nameof(projectId)), gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="TripleWildcardPatternName"/> with pattern
        /// <c>orgs/{org}/items/{item_id}</c>.
        /// </summary>
        /// <param name="orgId">The <c>Org</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="TripleWildcardPatternName"/> with pattern
        /// <c>orgs/{org}/items/{item_id}</c>.
        /// </returns>
        public static string FormatOrgItem(string orgId, string itemId) =>
            s_orgItem.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(orgId, nameof(orgId)), gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="TripleWildcardPatternName"/> with pattern
        /// <c>depts/{dept}/items/{item_id}</c>.
        /// </summary>
        /// <param name="deptId">The <c>Dept</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="TripleWildcardPatternName"/> with pattern
        /// <c>depts/{dept}/items/{item_id}</c>.
        /// </returns>
        public static string FormatDeptItem(string deptId, string itemId) =>
            s_deptItem.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(deptId, nameof(deptId)), gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Parses the given resource name string into a new <see cref="TripleWildcardPatternName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>projects/{project}/items/{item_id}</c></description></item>
        /// <item><description><c>orgs/{org}/items/{item_id}</c></description></item>
        /// <item><description><c>depts/{dept}/items/{item_id}</c></description></item>
        /// </list>
        /// </remarks>
        /// <param name="tripleWildcardPatternName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="TripleWildcardPatternName"/> if successful.</returns>
        public static TripleWildcardPatternName Parse(string tripleWildcardPatternName) =>
            Parse(tripleWildcardPatternName, false);

        /// <summary>
        /// Parses the given resource name string into a new <see cref="TripleWildcardPatternName"/> instance;
        /// optionally allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>projects/{project}/items/{item_id}</c></description></item>
        /// <item><description><c>orgs/{org}/items/{item_id}</c></description></item>
        /// <item><description><c>depts/{dept}/items/{item_id}</c></description></item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="tripleWildcardPatternName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <returns>The parsed <see cref="TripleWildcardPatternName"/> if successful.</returns>
        public static TripleWildcardPatternName Parse(string tripleWildcardPatternName, bool allowUnparsed) =>
            TryParse(tripleWildcardPatternName, allowUnparsed, out TripleWildcardPatternName result) ? result : throw new sys::ArgumentException("The given resource-name matches no pattern.");

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="TripleWildcardPatternName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>projects/{project}/items/{item_id}</c></description></item>
        /// <item><description><c>orgs/{org}/items/{item_id}</c></description></item>
        /// <item><description><c>depts/{dept}/items/{item_id}</c></description></item>
        /// </list>
        /// </remarks>
        /// <param name="tripleWildcardPatternName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="TripleWildcardPatternName"/>, or <c>null</c> if parsing
        /// failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string tripleWildcardPatternName, out TripleWildcardPatternName result) =>
            TryParse(tripleWildcardPatternName, false, out result);

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="TripleWildcardPatternName"/> instance;
        /// optionally allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>projects/{project}/items/{item_id}</c></description></item>
        /// <item><description><c>orgs/{org}/items/{item_id}</c></description></item>
        /// <item><description><c>depts/{dept}/items/{item_id}</c></description></item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="tripleWildcardPatternName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="TripleWildcardPatternName"/>, or <c>null</c> if parsing
        /// failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string tripleWildcardPatternName, bool allowUnparsed, out TripleWildcardPatternName result)
        {
            gax::GaxPreconditions.CheckNotNull(tripleWildcardPatternName, nameof(tripleWildcardPatternName));
            gax::TemplatedResourceName resourceName;
            if (s_projectItem.TryParseName(tripleWildcardPatternName, out resourceName))
            {
                result = FromProjectItem(resourceName[0], resourceName[1]);
                return true;
            }
            if (s_orgItem.TryParseName(tripleWildcardPatternName, out resourceName))
            {
                result = FromOrgItem(resourceName[0], resourceName[1]);
                return true;
            }
            if (s_deptItem.TryParseName(tripleWildcardPatternName, out resourceName))
            {
                result = FromDeptItem(resourceName[0], resourceName[1]);
                return true;
            }
            if (allowUnparsed)
            {
                if (gax::UnparsedResourceName.TryParse(tripleWildcardPatternName, out gax::UnparsedResourceName unparsedResourceName))
                {
                    result = FromUnparsed(unparsedResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        private TripleWildcardPatternName(ResourceNameType type, gax::UnparsedResourceName unparsedResourceName = null, string deptId = null, string itemId = null, string orgId = null, string projectId = null)
        {
            Type = type;
            UnparsedResource = unparsedResourceName;
            DeptId = deptId;
            ItemId = itemId;
            OrgId = orgId;
            ProjectId = projectId;
        }

        /// <summary>The <see cref="ResourceNameType"/> of the contained resource name.</summary>
        public ResourceNameType Type { get; }

        /// <summary>
        /// The contained <see cref="gax::UnparsedResourceName"/>. Only non-<c>null</c> if this instance contains an
        /// unparsed resource name.
        /// </summary>
        public gax::UnparsedResourceName UnparsedResource { get; }

        /// <summary>
        /// The <c>Dept</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string DeptId { get; }

        /// <summary>
        /// The <c>Item</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string ItemId { get; }

        /// <summary>
        /// The <c>Org</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string OrgId { get; }

        /// <summary>
        /// The <c>Project</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string ProjectId { get; }

        /// <inheritdoc/>
        public bool IsKnownPattern => Type != ResourceNameType.Unparsed;

        /// <inheritdoc/>
        public override string ToString()
        {
            switch (Type)
            {
                case ResourceNameType.Unparsed: return UnparsedResource.ToString();
                case ResourceNameType.ProjectItem: return s_projectItem.Expand(ProjectId, ItemId);
                case ResourceNameType.OrgItem: return s_orgItem.Expand(OrgId, ItemId);
                case ResourceNameType.DeptItem: return s_deptItem.Expand(DeptId, ItemId);
                default: throw new sys::InvalidOperationException("Unrecognized resource-type.");
            }
        }

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as TripleWildcardPatternName);

        /// <inheritdoc/>
        public bool Equals(TripleWildcardPatternName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(TripleWildcardPatternName a, TripleWildcardPatternName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(TripleWildcardPatternName a, TripleWildcardPatternName b) => !(a == b);
    }

    /// <summary>Resource name for the <c>ProjectOverlap</c> resource.</summary>
    public sealed partial class ProjectOverlapName : gax::IResourceName, sys::IEquatable<ProjectOverlapName>
    {
        /// <summary>The possible contents of <see cref="ProjectOverlapName"/>.</summary>
        public enum ResourceNameType
        {
            /// <summary>An unparsed resource name.</summary>
            Unparsed = 0,

            /// <summary>A resource name with pattern <c>projects/{project}</c>.</summary>
            Project = 1,

            /// <summary>A resource name with pattern <c>overlaps/{overlap}</c>.</summary>
            Overlap = 2
        }

        private static gax::PathTemplate s_project = new gax::PathTemplate("projects/{project}");

        private static gax::PathTemplate s_overlap = new gax::PathTemplate("overlaps/{overlap}");

        /// <summary>Creates a <see cref="ProjectOverlapName"/> containing an unparsed resource name.</summary>
        /// <param name="unparsedResourceName">The unparsed resource name. Must not be <c>null</c>.</param>
        /// <returns>
        /// A new instance of <see cref="ProjectOverlapName"/> containing the provided
        /// <paramref name="unparsedResourceName"/>.
        /// </returns>
        public static ProjectOverlapName FromUnparsed(gax::UnparsedResourceName unparsedResourceName) =>
            new ProjectOverlapName(ResourceNameType.Unparsed, gax::GaxPreconditions.CheckNotNull(unparsedResourceName, nameof(unparsedResourceName)));

        /// <summary>Creates a <see cref="ProjectOverlapName"/> with the pattern <c>projects/{project}</c>.</summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="ProjectOverlapName"/> constructed from the provided ids.</returns>
        public static ProjectOverlapName FromProject(string projectId) =>
            new ProjectOverlapName(ResourceNameType.Project, projectId: gax::GaxPreconditions.CheckNotNullOrEmpty(projectId, nameof(projectId)));

        /// <summary>Creates a <see cref="ProjectOverlapName"/> with the pattern <c>overlaps/{overlap}</c>.</summary>
        /// <param name="overlapId">The <c>Overlap</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="ProjectOverlapName"/> constructed from the provided ids.</returns>
        public static ProjectOverlapName FromOverlap(string overlapId) =>
            new ProjectOverlapName(ResourceNameType.Overlap, overlapId: gax::GaxPreconditions.CheckNotNullOrEmpty(overlapId, nameof(overlapId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="ProjectOverlapName"/> with pattern
        /// <c>projects/{project}</c>.
        /// </summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="ProjectOverlapName"/> with pattern <c>projects/{project}</c>.
        /// </returns>
        public static string Format(string projectId) => FormatProject(projectId);

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="ProjectOverlapName"/> with pattern
        /// <c>projects/{project}</c>.
        /// </summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="ProjectOverlapName"/> with pattern <c>projects/{project}</c>.
        /// </returns>
        public static string FormatProject(string projectId) =>
            s_project.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(projectId, nameof(projectId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="ProjectOverlapName"/> with pattern
        /// <c>overlaps/{overlap}</c>.
        /// </summary>
        /// <param name="overlapId">The <c>Overlap</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="ProjectOverlapName"/> with pattern <c>overlaps/{overlap}</c>.
        /// </returns>
        public static string FormatOverlap(string overlapId) =>
            s_overlap.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(overlapId, nameof(overlapId)));

        /// <summary>
        /// Parses the given resource name string into a new <see cref="ProjectOverlapName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>projects/{project}</c></description></item>
        /// <item><description><c>overlaps/{overlap}</c></description></item>
        /// </list>
        /// </remarks>
        /// <param name="projectOverlapName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="ProjectOverlapName"/> if successful.</returns>
        public static ProjectOverlapName Parse(string projectOverlapName) => Parse(projectOverlapName, false);

        /// <summary>
        /// Parses the given resource name string into a new <see cref="ProjectOverlapName"/> instance; optionally
        /// allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>projects/{project}</c></description></item>
        /// <item><description><c>overlaps/{overlap}</c></description></item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="projectOverlapName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <returns>The parsed <see cref="ProjectOverlapName"/> if successful.</returns>
        public static ProjectOverlapName Parse(string projectOverlapName, bool allowUnparsed) =>
            TryParse(projectOverlapName, allowUnparsed, out ProjectOverlapName result) ? result : throw new sys::ArgumentException("The given resource-name matches no pattern.");

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="ProjectOverlapName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>projects/{project}</c></description></item>
        /// <item><description><c>overlaps/{overlap}</c></description></item>
        /// </list>
        /// </remarks>
        /// <param name="projectOverlapName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="ProjectOverlapName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string projectOverlapName, out ProjectOverlapName result) =>
            TryParse(projectOverlapName, false, out result);

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="ProjectOverlapName"/> instance;
        /// optionally allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>projects/{project}</c></description></item>
        /// <item><description><c>overlaps/{overlap}</c></description></item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="projectOverlapName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="ProjectOverlapName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string projectOverlapName, bool allowUnparsed, out ProjectOverlapName result)
        {
            gax::GaxPreconditions.CheckNotNull(projectOverlapName, nameof(projectOverlapName));
            gax::TemplatedResourceName resourceName;
            if (s_project.TryParseName(projectOverlapName, out resourceName))
            {
                result = FromProject(resourceName[0]);
                return true;
            }
            if (s_overlap.TryParseName(projectOverlapName, out resourceName))
            {
                result = FromOverlap(resourceName[0]);
                return true;
            }
            if (allowUnparsed)
            {
                if (gax::UnparsedResourceName.TryParse(projectOverlapName, out gax::UnparsedResourceName unparsedResourceName))
                {
                    result = FromUnparsed(unparsedResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        private ProjectOverlapName(ResourceNameType type, gax::UnparsedResourceName unparsedResourceName = null, string overlapId = null, string projectId = null)
        {
            Type = type;
            UnparsedResource = unparsedResourceName;
            OverlapId = overlapId;
            ProjectId = projectId;
        }

        /// <summary>
        /// Constructs a new instance of a <see cref="ProjectOverlapName"/> class from the component parts of pattern
        /// <c>projects/{project}</c>
        /// </summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c> or empty.</param>
        public ProjectOverlapName(string projectId) : this(ResourceNameType.Project, projectId: gax::GaxPreconditions.CheckNotNullOrEmpty(projectId, nameof(projectId)))
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
        /// The <c>Overlap</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string OverlapId { get; }

        /// <summary>
        /// The <c>Project</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string ProjectId { get; }

        /// <inheritdoc/>
        public bool IsKnownPattern => Type != ResourceNameType.Unparsed;

        /// <inheritdoc/>
        public override string ToString()
        {
            switch (Type)
            {
                case ResourceNameType.Unparsed: return UnparsedResource.ToString();
                case ResourceNameType.Project: return s_project.Expand(ProjectId);
                case ResourceNameType.Overlap: return s_overlap.Expand(OverlapId);
                default: throw new sys::InvalidOperationException("Unrecognized resource-type.");
            }
        }

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as ProjectOverlapName);

        /// <inheritdoc/>
        public bool Equals(ProjectOverlapName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(ProjectOverlapName a, ProjectOverlapName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(ProjectOverlapName a, ProjectOverlapName b) => !(a == b);
    }

    /// <summary>Resource name for the <c>OrgOverlap</c> resource.</summary>
    public sealed partial class OrgOverlapName : gax::IResourceName, sys::IEquatable<OrgOverlapName>
    {
        /// <summary>The possible contents of <see cref="OrgOverlapName"/>.</summary>
        public enum ResourceNameType
        {
            /// <summary>An unparsed resource name.</summary>
            Unparsed = 0,

            /// <summary>A resource name with pattern <c>orgs/{org}</c>.</summary>
            Org = 1,

            /// <summary>A resource name with pattern <c>overlaps/{overlap}</c>.</summary>
            Overlap = 2
        }

        private static gax::PathTemplate s_org = new gax::PathTemplate("orgs/{org}");

        private static gax::PathTemplate s_overlap = new gax::PathTemplate("overlaps/{overlap}");

        /// <summary>Creates a <see cref="OrgOverlapName"/> containing an unparsed resource name.</summary>
        /// <param name="unparsedResourceName">The unparsed resource name. Must not be <c>null</c>.</param>
        /// <returns>
        /// A new instance of <see cref="OrgOverlapName"/> containing the provided
        /// <paramref name="unparsedResourceName"/>.
        /// </returns>
        public static OrgOverlapName FromUnparsed(gax::UnparsedResourceName unparsedResourceName) =>
            new OrgOverlapName(ResourceNameType.Unparsed, gax::GaxPreconditions.CheckNotNull(unparsedResourceName, nameof(unparsedResourceName)));

        /// <summary>Creates a <see cref="OrgOverlapName"/> with the pattern <c>orgs/{org}</c>.</summary>
        /// <param name="orgId">The <c>Org</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="OrgOverlapName"/> constructed from the provided ids.</returns>
        public static OrgOverlapName FromOrg(string orgId) =>
            new OrgOverlapName(ResourceNameType.Org, orgId: gax::GaxPreconditions.CheckNotNullOrEmpty(orgId, nameof(orgId)));

        /// <summary>Creates a <see cref="OrgOverlapName"/> with the pattern <c>overlaps/{overlap}</c>.</summary>
        /// <param name="overlapId">The <c>Overlap</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="OrgOverlapName"/> constructed from the provided ids.</returns>
        public static OrgOverlapName FromOverlap(string overlapId) =>
            new OrgOverlapName(ResourceNameType.Overlap, overlapId: gax::GaxPreconditions.CheckNotNullOrEmpty(overlapId, nameof(overlapId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="OrgOverlapName"/> with pattern
        /// <c>orgs/{org}</c>.
        /// </summary>
        /// <param name="orgId">The <c>Org</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="OrgOverlapName"/> with pattern <c>orgs/{org}</c>.
        /// </returns>
        public static string Format(string orgId) => FormatOrg(orgId);

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="OrgOverlapName"/> with pattern
        /// <c>orgs/{org}</c>.
        /// </summary>
        /// <param name="orgId">The <c>Org</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="OrgOverlapName"/> with pattern <c>orgs/{org}</c>.
        /// </returns>
        public static string FormatOrg(string orgId) =>
            s_org.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(orgId, nameof(orgId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="OrgOverlapName"/> with pattern
        /// <c>overlaps/{overlap}</c>.
        /// </summary>
        /// <param name="overlapId">The <c>Overlap</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="OrgOverlapName"/> with pattern <c>overlaps/{overlap}</c>.
        /// </returns>
        public static string FormatOverlap(string overlapId) =>
            s_overlap.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(overlapId, nameof(overlapId)));

        /// <summary>Parses the given resource name string into a new <see cref="OrgOverlapName"/> instance.</summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>orgs/{org}</c></description></item>
        /// <item><description><c>overlaps/{overlap}</c></description></item>
        /// </list>
        /// </remarks>
        /// <param name="orgOverlapName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="OrgOverlapName"/> if successful.</returns>
        public static OrgOverlapName Parse(string orgOverlapName) => Parse(orgOverlapName, false);

        /// <summary>
        /// Parses the given resource name string into a new <see cref="OrgOverlapName"/> instance; optionally allowing
        /// an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>orgs/{org}</c></description></item>
        /// <item><description><c>overlaps/{overlap}</c></description></item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="orgOverlapName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <returns>The parsed <see cref="OrgOverlapName"/> if successful.</returns>
        public static OrgOverlapName Parse(string orgOverlapName, bool allowUnparsed) =>
            TryParse(orgOverlapName, allowUnparsed, out OrgOverlapName result) ? result : throw new sys::ArgumentException("The given resource-name matches no pattern.");

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="OrgOverlapName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>orgs/{org}</c></description></item>
        /// <item><description><c>overlaps/{overlap}</c></description></item>
        /// </list>
        /// </remarks>
        /// <param name="orgOverlapName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="OrgOverlapName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string orgOverlapName, out OrgOverlapName result) =>
            TryParse(orgOverlapName, false, out result);

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="OrgOverlapName"/> instance; optionally
        /// allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>orgs/{org}</c></description></item>
        /// <item><description><c>overlaps/{overlap}</c></description></item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="orgOverlapName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="OrgOverlapName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string orgOverlapName, bool allowUnparsed, out OrgOverlapName result)
        {
            gax::GaxPreconditions.CheckNotNull(orgOverlapName, nameof(orgOverlapName));
            gax::TemplatedResourceName resourceName;
            if (s_org.TryParseName(orgOverlapName, out resourceName))
            {
                result = FromOrg(resourceName[0]);
                return true;
            }
            if (s_overlap.TryParseName(orgOverlapName, out resourceName))
            {
                result = FromOverlap(resourceName[0]);
                return true;
            }
            if (allowUnparsed)
            {
                if (gax::UnparsedResourceName.TryParse(orgOverlapName, out gax::UnparsedResourceName unparsedResourceName))
                {
                    result = FromUnparsed(unparsedResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        private OrgOverlapName(ResourceNameType type, gax::UnparsedResourceName unparsedResourceName = null, string orgId = null, string overlapId = null)
        {
            Type = type;
            UnparsedResource = unparsedResourceName;
            OrgId = orgId;
            OverlapId = overlapId;
        }

        /// <summary>
        /// Constructs a new instance of a <see cref="OrgOverlapName"/> class from the component parts of pattern
        /// <c>orgs/{org}</c>
        /// </summary>
        /// <param name="orgId">The <c>Org</c> ID. Must not be <c>null</c> or empty.</param>
        public OrgOverlapName(string orgId) : this(ResourceNameType.Org, orgId: gax::GaxPreconditions.CheckNotNullOrEmpty(orgId, nameof(orgId)))
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
        /// The <c>Org</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string OrgId { get; }

        /// <summary>
        /// The <c>Overlap</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string OverlapId { get; }

        /// <inheritdoc/>
        public bool IsKnownPattern => Type != ResourceNameType.Unparsed;

        /// <inheritdoc/>
        public override string ToString()
        {
            switch (Type)
            {
                case ResourceNameType.Unparsed: return UnparsedResource.ToString();
                case ResourceNameType.Org: return s_org.Expand(OrgId);
                case ResourceNameType.Overlap: return s_overlap.Expand(OverlapId);
                default: throw new sys::InvalidOperationException("Unrecognized resource-type.");
            }
        }

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as OrgOverlapName);

        /// <inheritdoc/>
        public bool Equals(OrgOverlapName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(OrgOverlapName a, OrgOverlapName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(OrgOverlapName a, OrgOverlapName b) => !(a == b);
    }

    /// <summary>Resource name for the <c>AllOverlap</c> resource.</summary>
    public sealed partial class AllOverlapName : gax::IResourceName, sys::IEquatable<AllOverlapName>
    {
        /// <summary>The possible contents of <see cref="AllOverlapName"/>.</summary>
        public enum ResourceNameType
        {
            /// <summary>An unparsed resource name.</summary>
            Unparsed = 0,

            /// <summary>A resource name with pattern <c>projects/{project}</c>.</summary>
            Project = 1,

            /// <summary>A resource name with pattern <c>orgs/{org}</c>.</summary>
            Org = 2,

            /// <summary>A resource name with pattern <c>depts/{dept}</c>.</summary>
            Dept = 3,

            /// <summary>A resource name with pattern <c>overlaps/{overlap}</c>.</summary>
            Overlap = 4
        }

        private static gax::PathTemplate s_project = new gax::PathTemplate("projects/{project}");

        private static gax::PathTemplate s_org = new gax::PathTemplate("orgs/{org}");

        private static gax::PathTemplate s_dept = new gax::PathTemplate("depts/{dept}");

        private static gax::PathTemplate s_overlap = new gax::PathTemplate("overlaps/{overlap}");

        /// <summary>Creates a <see cref="AllOverlapName"/> containing an unparsed resource name.</summary>
        /// <param name="unparsedResourceName">The unparsed resource name. Must not be <c>null</c>.</param>
        /// <returns>
        /// A new instance of <see cref="AllOverlapName"/> containing the provided
        /// <paramref name="unparsedResourceName"/>.
        /// </returns>
        public static AllOverlapName FromUnparsed(gax::UnparsedResourceName unparsedResourceName) =>
            new AllOverlapName(ResourceNameType.Unparsed, gax::GaxPreconditions.CheckNotNull(unparsedResourceName, nameof(unparsedResourceName)));

        /// <summary>Creates a <see cref="AllOverlapName"/> with the pattern <c>projects/{project}</c>.</summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="AllOverlapName"/> constructed from the provided ids.</returns>
        public static AllOverlapName FromProject(string projectId) =>
            new AllOverlapName(ResourceNameType.Project, projectId: gax::GaxPreconditions.CheckNotNullOrEmpty(projectId, nameof(projectId)));

        /// <summary>Creates a <see cref="AllOverlapName"/> with the pattern <c>orgs/{org}</c>.</summary>
        /// <param name="orgId">The <c>Org</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="AllOverlapName"/> constructed from the provided ids.</returns>
        public static AllOverlapName FromOrg(string orgId) =>
            new AllOverlapName(ResourceNameType.Org, orgId: gax::GaxPreconditions.CheckNotNullOrEmpty(orgId, nameof(orgId)));

        /// <summary>Creates a <see cref="AllOverlapName"/> with the pattern <c>depts/{dept}</c>.</summary>
        /// <param name="deptId">The <c>Dept</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="AllOverlapName"/> constructed from the provided ids.</returns>
        public static AllOverlapName FromDept(string deptId) =>
            new AllOverlapName(ResourceNameType.Dept, deptId: gax::GaxPreconditions.CheckNotNullOrEmpty(deptId, nameof(deptId)));

        /// <summary>Creates a <see cref="AllOverlapName"/> with the pattern <c>overlaps/{overlap}</c>.</summary>
        /// <param name="overlapId">The <c>Overlap</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="AllOverlapName"/> constructed from the provided ids.</returns>
        public static AllOverlapName FromOverlap(string overlapId) =>
            new AllOverlapName(ResourceNameType.Overlap, overlapId: gax::GaxPreconditions.CheckNotNullOrEmpty(overlapId, nameof(overlapId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="AllOverlapName"/> with pattern
        /// <c>projects/{project}</c>.
        /// </summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="AllOverlapName"/> with pattern <c>projects/{project}</c>.
        /// </returns>
        public static string Format(string projectId) => FormatProject(projectId);

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="AllOverlapName"/> with pattern
        /// <c>projects/{project}</c>.
        /// </summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="AllOverlapName"/> with pattern <c>projects/{project}</c>.
        /// </returns>
        public static string FormatProject(string projectId) =>
            s_project.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(projectId, nameof(projectId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="AllOverlapName"/> with pattern
        /// <c>orgs/{org}</c>.
        /// </summary>
        /// <param name="orgId">The <c>Org</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="AllOverlapName"/> with pattern <c>orgs/{org}</c>.
        /// </returns>
        public static string FormatOrg(string orgId) =>
            s_org.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(orgId, nameof(orgId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="AllOverlapName"/> with pattern
        /// <c>depts/{dept}</c>.
        /// </summary>
        /// <param name="deptId">The <c>Dept</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="AllOverlapName"/> with pattern <c>depts/{dept}</c>.
        /// </returns>
        public static string FormatDept(string deptId) =>
            s_dept.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(deptId, nameof(deptId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="AllOverlapName"/> with pattern
        /// <c>overlaps/{overlap}</c>.
        /// </summary>
        /// <param name="overlapId">The <c>Overlap</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="AllOverlapName"/> with pattern <c>overlaps/{overlap}</c>.
        /// </returns>
        public static string FormatOverlap(string overlapId) =>
            s_overlap.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(overlapId, nameof(overlapId)));

        /// <summary>Parses the given resource name string into a new <see cref="AllOverlapName"/> instance.</summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>projects/{project}</c></description></item>
        /// <item><description><c>orgs/{org}</c></description></item>
        /// <item><description><c>depts/{dept}</c></description></item>
        /// <item><description><c>overlaps/{overlap}</c></description></item>
        /// </list>
        /// </remarks>
        /// <param name="allOverlapName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="AllOverlapName"/> if successful.</returns>
        public static AllOverlapName Parse(string allOverlapName) => Parse(allOverlapName, false);

        /// <summary>
        /// Parses the given resource name string into a new <see cref="AllOverlapName"/> instance; optionally allowing
        /// an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>projects/{project}</c></description></item>
        /// <item><description><c>orgs/{org}</c></description></item>
        /// <item><description><c>depts/{dept}</c></description></item>
        /// <item><description><c>overlaps/{overlap}</c></description></item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="allOverlapName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <returns>The parsed <see cref="AllOverlapName"/> if successful.</returns>
        public static AllOverlapName Parse(string allOverlapName, bool allowUnparsed) =>
            TryParse(allOverlapName, allowUnparsed, out AllOverlapName result) ? result : throw new sys::ArgumentException("The given resource-name matches no pattern.");

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="AllOverlapName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>projects/{project}</c></description></item>
        /// <item><description><c>orgs/{org}</c></description></item>
        /// <item><description><c>depts/{dept}</c></description></item>
        /// <item><description><c>overlaps/{overlap}</c></description></item>
        /// </list>
        /// </remarks>
        /// <param name="allOverlapName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="AllOverlapName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string allOverlapName, out AllOverlapName result) =>
            TryParse(allOverlapName, false, out result);

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="AllOverlapName"/> instance; optionally
        /// allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>projects/{project}</c></description></item>
        /// <item><description><c>orgs/{org}</c></description></item>
        /// <item><description><c>depts/{dept}</c></description></item>
        /// <item><description><c>overlaps/{overlap}</c></description></item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="allOverlapName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="AllOverlapName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string allOverlapName, bool allowUnparsed, out AllOverlapName result)
        {
            gax::GaxPreconditions.CheckNotNull(allOverlapName, nameof(allOverlapName));
            gax::TemplatedResourceName resourceName;
            if (s_project.TryParseName(allOverlapName, out resourceName))
            {
                result = FromProject(resourceName[0]);
                return true;
            }
            if (s_org.TryParseName(allOverlapName, out resourceName))
            {
                result = FromOrg(resourceName[0]);
                return true;
            }
            if (s_dept.TryParseName(allOverlapName, out resourceName))
            {
                result = FromDept(resourceName[0]);
                return true;
            }
            if (s_overlap.TryParseName(allOverlapName, out resourceName))
            {
                result = FromOverlap(resourceName[0]);
                return true;
            }
            if (allowUnparsed)
            {
                if (gax::UnparsedResourceName.TryParse(allOverlapName, out gax::UnparsedResourceName unparsedResourceName))
                {
                    result = FromUnparsed(unparsedResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        private AllOverlapName(ResourceNameType type, gax::UnparsedResourceName unparsedResourceName = null, string deptId = null, string orgId = null, string overlapId = null, string projectId = null)
        {
            Type = type;
            UnparsedResource = unparsedResourceName;
            DeptId = deptId;
            OrgId = orgId;
            OverlapId = overlapId;
            ProjectId = projectId;
        }

        /// <summary>
        /// Constructs a new instance of a <see cref="AllOverlapName"/> class from the component parts of pattern
        /// <c>projects/{project}</c>
        /// </summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c> or empty.</param>
        public AllOverlapName(string projectId) : this(ResourceNameType.Project, projectId: gax::GaxPreconditions.CheckNotNullOrEmpty(projectId, nameof(projectId)))
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
        /// The <c>Dept</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string DeptId { get; }

        /// <summary>
        /// The <c>Org</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string OrgId { get; }

        /// <summary>
        /// The <c>Overlap</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string OverlapId { get; }

        /// <summary>
        /// The <c>Project</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string ProjectId { get; }

        /// <inheritdoc/>
        public bool IsKnownPattern => Type != ResourceNameType.Unparsed;

        /// <inheritdoc/>
        public override string ToString()
        {
            switch (Type)
            {
                case ResourceNameType.Unparsed: return UnparsedResource.ToString();
                case ResourceNameType.Project: return s_project.Expand(ProjectId);
                case ResourceNameType.Org: return s_org.Expand(OrgId);
                case ResourceNameType.Dept: return s_dept.Expand(DeptId);
                case ResourceNameType.Overlap: return s_overlap.Expand(OverlapId);
                default: throw new sys::InvalidOperationException("Unrecognized resource-type.");
            }
        }

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as AllOverlapName);

        /// <inheritdoc/>
        public bool Equals(AllOverlapName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(AllOverlapName a, AllOverlapName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(AllOverlapName a, AllOverlapName b) => !(a == b);
    }

    /// <summary>Resource name for the <c>OverlapPattern</c> resource.</summary>
    public sealed partial class OverlapPatternName : gax::IResourceName, sys::IEquatable<OverlapPatternName>
    {
        /// <summary>The possible contents of <see cref="OverlapPatternName"/>.</summary>
        public enum ResourceNameType
        {
            /// <summary>An unparsed resource name.</summary>
            Unparsed = 0,

            /// <summary>A resource name with pattern <c>projects/{project}/items/{item_id}</c>.</summary>
            ProjectItem = 1,

            /// <summary>A resource name with pattern <c>orgs/{org}/items/{item_id}</c>.</summary>
            OrgItem = 2,

            /// <summary>A resource name with pattern <c>depts/{dept}/items/{item_id}</c>.</summary>
            DeptItem = 3,

            /// <summary>A resource name with pattern <c>overlaps/{overlap}/items/{item_id}</c>.</summary>
            OverlapItem = 4
        }

        private static gax::PathTemplate s_projectItem = new gax::PathTemplate("projects/{project}/items/{item_id}");

        private static gax::PathTemplate s_orgItem = new gax::PathTemplate("orgs/{org}/items/{item_id}");

        private static gax::PathTemplate s_deptItem = new gax::PathTemplate("depts/{dept}/items/{item_id}");

        private static gax::PathTemplate s_overlapItem = new gax::PathTemplate("overlaps/{overlap}/items/{item_id}");

        /// <summary>Creates a <see cref="OverlapPatternName"/> containing an unparsed resource name.</summary>
        /// <param name="unparsedResourceName">The unparsed resource name. Must not be <c>null</c>.</param>
        /// <returns>
        /// A new instance of <see cref="OverlapPatternName"/> containing the provided
        /// <paramref name="unparsedResourceName"/>.
        /// </returns>
        public static OverlapPatternName FromUnparsed(gax::UnparsedResourceName unparsedResourceName) =>
            new OverlapPatternName(ResourceNameType.Unparsed, gax::GaxPreconditions.CheckNotNull(unparsedResourceName, nameof(unparsedResourceName)));

        /// <summary>
        /// Creates a <see cref="OverlapPatternName"/> with the pattern <c>projects/{project}/items/{item_id}</c>.
        /// </summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="OverlapPatternName"/> constructed from the provided ids.</returns>
        public static OverlapPatternName FromProjectItem(string projectId, string itemId) =>
            new OverlapPatternName(ResourceNameType.ProjectItem, projectId: gax::GaxPreconditions.CheckNotNullOrEmpty(projectId, nameof(projectId)), itemId: gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Creates a <see cref="OverlapPatternName"/> with the pattern <c>orgs/{org}/items/{item_id}</c>.
        /// </summary>
        /// <param name="orgId">The <c>Org</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="OverlapPatternName"/> constructed from the provided ids.</returns>
        public static OverlapPatternName FromOrgItem(string orgId, string itemId) =>
            new OverlapPatternName(ResourceNameType.OrgItem, orgId: gax::GaxPreconditions.CheckNotNullOrEmpty(orgId, nameof(orgId)), itemId: gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Creates a <see cref="OverlapPatternName"/> with the pattern <c>depts/{dept}/items/{item_id}</c>.
        /// </summary>
        /// <param name="deptId">The <c>Dept</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="OverlapPatternName"/> constructed from the provided ids.</returns>
        public static OverlapPatternName FromDeptItem(string deptId, string itemId) =>
            new OverlapPatternName(ResourceNameType.DeptItem, deptId: gax::GaxPreconditions.CheckNotNullOrEmpty(deptId, nameof(deptId)), itemId: gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Creates a <see cref="OverlapPatternName"/> with the pattern <c>overlaps/{overlap}/items/{item_id}</c>.
        /// </summary>
        /// <param name="overlapId">The <c>Overlap</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="OverlapPatternName"/> constructed from the provided ids.</returns>
        public static OverlapPatternName FromOverlapItem(string overlapId, string itemId) =>
            new OverlapPatternName(ResourceNameType.OverlapItem, overlapId: gax::GaxPreconditions.CheckNotNullOrEmpty(overlapId, nameof(overlapId)), itemId: gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="OverlapPatternName"/> with pattern
        /// <c>projects/{project}/items/{item_id}</c>.
        /// </summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="OverlapPatternName"/> with pattern
        /// <c>projects/{project}/items/{item_id}</c>.
        /// </returns>
        public static string Format(string projectId, string itemId) => FormatProjectItem(projectId, itemId);

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="OverlapPatternName"/> with pattern
        /// <c>projects/{project}/items/{item_id}</c>.
        /// </summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="OverlapPatternName"/> with pattern
        /// <c>projects/{project}/items/{item_id}</c>.
        /// </returns>
        public static string FormatProjectItem(string projectId, string itemId) =>
            s_projectItem.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(projectId, nameof(projectId)), gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="OverlapPatternName"/> with pattern
        /// <c>orgs/{org}/items/{item_id}</c>.
        /// </summary>
        /// <param name="orgId">The <c>Org</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="OverlapPatternName"/> with pattern
        /// <c>orgs/{org}/items/{item_id}</c>.
        /// </returns>
        public static string FormatOrgItem(string orgId, string itemId) =>
            s_orgItem.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(orgId, nameof(orgId)), gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="OverlapPatternName"/> with pattern
        /// <c>depts/{dept}/items/{item_id}</c>.
        /// </summary>
        /// <param name="deptId">The <c>Dept</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="OverlapPatternName"/> with pattern
        /// <c>depts/{dept}/items/{item_id}</c>.
        /// </returns>
        public static string FormatDeptItem(string deptId, string itemId) =>
            s_deptItem.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(deptId, nameof(deptId)), gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="OverlapPatternName"/> with pattern
        /// <c>overlaps/{overlap}/items/{item_id}</c>.
        /// </summary>
        /// <param name="overlapId">The <c>Overlap</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="OverlapPatternName"/> with pattern
        /// <c>overlaps/{overlap}/items/{item_id}</c>.
        /// </returns>
        public static string FormatOverlapItem(string overlapId, string itemId) =>
            s_overlapItem.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(overlapId, nameof(overlapId)), gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Parses the given resource name string into a new <see cref="OverlapPatternName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>projects/{project}/items/{item_id}</c></description></item>
        /// <item><description><c>orgs/{org}/items/{item_id}</c></description></item>
        /// <item><description><c>depts/{dept}/items/{item_id}</c></description></item>
        /// <item><description><c>overlaps/{overlap}/items/{item_id}</c></description></item>
        /// </list>
        /// </remarks>
        /// <param name="overlapPatternName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="OverlapPatternName"/> if successful.</returns>
        public static OverlapPatternName Parse(string overlapPatternName) => Parse(overlapPatternName, false);

        /// <summary>
        /// Parses the given resource name string into a new <see cref="OverlapPatternName"/> instance; optionally
        /// allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>projects/{project}/items/{item_id}</c></description></item>
        /// <item><description><c>orgs/{org}/items/{item_id}</c></description></item>
        /// <item><description><c>depts/{dept}/items/{item_id}</c></description></item>
        /// <item><description><c>overlaps/{overlap}/items/{item_id}</c></description></item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="overlapPatternName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <returns>The parsed <see cref="OverlapPatternName"/> if successful.</returns>
        public static OverlapPatternName Parse(string overlapPatternName, bool allowUnparsed) =>
            TryParse(overlapPatternName, allowUnparsed, out OverlapPatternName result) ? result : throw new sys::ArgumentException("The given resource-name matches no pattern.");

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="OverlapPatternName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>projects/{project}/items/{item_id}</c></description></item>
        /// <item><description><c>orgs/{org}/items/{item_id}</c></description></item>
        /// <item><description><c>depts/{dept}/items/{item_id}</c></description></item>
        /// <item><description><c>overlaps/{overlap}/items/{item_id}</c></description></item>
        /// </list>
        /// </remarks>
        /// <param name="overlapPatternName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="OverlapPatternName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string overlapPatternName, out OverlapPatternName result) =>
            TryParse(overlapPatternName, false, out result);

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="OverlapPatternName"/> instance;
        /// optionally allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>projects/{project}/items/{item_id}</c></description></item>
        /// <item><description><c>orgs/{org}/items/{item_id}</c></description></item>
        /// <item><description><c>depts/{dept}/items/{item_id}</c></description></item>
        /// <item><description><c>overlaps/{overlap}/items/{item_id}</c></description></item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="overlapPatternName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="OverlapPatternName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string overlapPatternName, bool allowUnparsed, out OverlapPatternName result)
        {
            gax::GaxPreconditions.CheckNotNull(overlapPatternName, nameof(overlapPatternName));
            gax::TemplatedResourceName resourceName;
            if (s_projectItem.TryParseName(overlapPatternName, out resourceName))
            {
                result = FromProjectItem(resourceName[0], resourceName[1]);
                return true;
            }
            if (s_orgItem.TryParseName(overlapPatternName, out resourceName))
            {
                result = FromOrgItem(resourceName[0], resourceName[1]);
                return true;
            }
            if (s_deptItem.TryParseName(overlapPatternName, out resourceName))
            {
                result = FromDeptItem(resourceName[0], resourceName[1]);
                return true;
            }
            if (s_overlapItem.TryParseName(overlapPatternName, out resourceName))
            {
                result = FromOverlapItem(resourceName[0], resourceName[1]);
                return true;
            }
            if (allowUnparsed)
            {
                if (gax::UnparsedResourceName.TryParse(overlapPatternName, out gax::UnparsedResourceName unparsedResourceName))
                {
                    result = FromUnparsed(unparsedResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        private OverlapPatternName(ResourceNameType type, gax::UnparsedResourceName unparsedResourceName = null, string deptId = null, string itemId = null, string orgId = null, string overlapId = null, string projectId = null)
        {
            Type = type;
            UnparsedResource = unparsedResourceName;
            DeptId = deptId;
            ItemId = itemId;
            OrgId = orgId;
            OverlapId = overlapId;
            ProjectId = projectId;
        }

        /// <summary>
        /// Constructs a new instance of a <see cref="OverlapPatternName"/> class from the component parts of pattern
        /// <c>projects/{project}/items/{item_id}</c>
        /// </summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        public OverlapPatternName(string projectId, string itemId) : this(ResourceNameType.ProjectItem, projectId: gax::GaxPreconditions.CheckNotNullOrEmpty(projectId, nameof(projectId)), itemId: gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)))
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
        /// The <c>Dept</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string DeptId { get; }

        /// <summary>
        /// The <c>Item</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string ItemId { get; }

        /// <summary>
        /// The <c>Org</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string OrgId { get; }

        /// <summary>
        /// The <c>Overlap</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string OverlapId { get; }

        /// <summary>
        /// The <c>Project</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string ProjectId { get; }

        /// <inheritdoc/>
        public bool IsKnownPattern => Type != ResourceNameType.Unparsed;

        /// <inheritdoc/>
        public override string ToString()
        {
            switch (Type)
            {
                case ResourceNameType.Unparsed: return UnparsedResource.ToString();
                case ResourceNameType.ProjectItem: return s_projectItem.Expand(ProjectId, ItemId);
                case ResourceNameType.OrgItem: return s_orgItem.Expand(OrgId, ItemId);
                case ResourceNameType.DeptItem: return s_deptItem.Expand(DeptId, ItemId);
                case ResourceNameType.OverlapItem: return s_overlapItem.Expand(OverlapId, ItemId);
                default: throw new sys::InvalidOperationException("Unrecognized resource-type.");
            }
        }

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as OverlapPatternName);

        /// <inheritdoc/>
        public bool Equals(OverlapPatternName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(OverlapPatternName a, OverlapPatternName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(OverlapPatternName a, OverlapPatternName b) => !(a == b);
    }

    public partial class SingleParent
    {
        /// <summary><see cref="ProjectName"/>-typed view over the <see cref="Ref"/> resource name property.</summary>
        public ProjectName RefAsProjectName
        {
            get => string.IsNullOrEmpty(Ref) ? null : ProjectName.Parse(Ref, allowUnparsed: true);
            set => Ref = value?.ToString() ?? "";
        }

        /// <summary>
        /// <see cref="ProjectName"/>-typed view over the <see cref="RepeatedRef"/> resource name property.
        /// </summary>
        public gax::ResourceNameList<ProjectName> RepeatedRefAsProjectNames
        {
            get => new gax::ResourceNameList<ProjectName>(RepeatedRef, s => string.IsNullOrEmpty(s) ? null : ProjectName.Parse(s, allowUnparsed: true));
        }
    }

    public partial class WildcardParent
    {
        /// <summary>
        /// <see cref="gax::IResourceName"/>-typed view over the <see cref="Ref"/> resource name property.
        /// </summary>
        public gax::IResourceName RefAsResourceName
        {
            get => string.IsNullOrEmpty(Ref) ? null : gax::UnparsedResourceName.Parse(Ref);
            set => Ref = value?.ToString() ?? "";
        }

        /// <summary>
        /// <see cref="gax::IResourceName"/>-typed view over the <see cref="RepeatedRef"/> resource name property.
        /// </summary>
        public gax::ResourceNameList<gax::IResourceName> RepeatedRefAsResourceNames
        {
            get => new gax::ResourceNameList<gax::IResourceName>(RepeatedRef, s => string.IsNullOrEmpty(s) ? null : gax::UnparsedResourceName.Parse(s));
        }

        /// <summary>
        /// <see cref="gax::IResourceName"/>-typed view over the <see cref="RefSugar"/> resource name property.
        /// </summary>
        public gax::IResourceName RefSugarAsResourceName
        {
            get => string.IsNullOrEmpty(RefSugar) ? null : gax::UnparsedResourceName.Parse(RefSugar);
            set => RefSugar = value?.ToString() ?? "";
        }

        /// <summary>
        /// <see cref="gax::IResourceName"/>-typed view over the <see cref="RepeatedRefSugar"/> resource name property.
        /// </summary>
        public gax::ResourceNameList<gax::IResourceName> RepeatedRefSugarAsResourceNames
        {
            get => new gax::ResourceNameList<gax::IResourceName>(RepeatedRefSugar, s => string.IsNullOrEmpty(s) ? null : gax::UnparsedResourceName.Parse(s));
        }
    }

    public partial class TripleParent
    {
        /// <summary><see cref="ProjectName"/>-typed view over the <see cref="Ref"/> resource name property.</summary>
        public ProjectName RefAsProjectName
        {
            get => string.IsNullOrEmpty(Ref) ? null : ProjectName.Parse(Ref, allowUnparsed: true);
            set => Ref = value?.ToString() ?? "";
        }

        /// <summary><see cref="OrgName"/>-typed view over the <see cref="Ref"/> resource name property.</summary>
        public OrgName RefAsOrgName
        {
            get => string.IsNullOrEmpty(Ref) ? null : OrgName.Parse(Ref, allowUnparsed: true);
            set => Ref = value?.ToString() ?? "";
        }

        /// <summary><see cref="DeptName"/>-typed view over the <see cref="Ref"/> resource name property.</summary>
        public DeptName RefAsDeptName
        {
            get => string.IsNullOrEmpty(Ref) ? null : DeptName.Parse(Ref, allowUnparsed: true);
            set => Ref = value?.ToString() ?? "";
        }

        /// <summary>
        /// <see cref="gax::IResourceName"/>-typed view over the <see cref="Ref"/> resource name property.
        /// </summary>
        public gax::IResourceName RefAsResourceName
        {
            get
            {
                if (string.IsNullOrEmpty(Ref))
                {
                    return null;
                }
                if (ProjectName.TryParse(Ref, out ProjectName project))
                {
                    return project;
                }
                if (OrgName.TryParse(Ref, out OrgName org))
                {
                    return org;
                }
                if (DeptName.TryParse(Ref, out DeptName dept))
                {
                    return dept;
                }
                return gax::UnparsedResourceName.Parse(Ref);
            }
            set => Ref = value?.ToString() ?? "";
        }

        /// <summary>
        /// <see cref="ProjectName"/>-typed view over the <see cref="RepeatedRef"/> resource name property.
        /// </summary>
        public gax::ResourceNameList<ProjectName> RepeatedRefAsProjectNames
        {
            get => new gax::ResourceNameList<ProjectName>(RepeatedRef, s => string.IsNullOrEmpty(s) ? null : ProjectName.Parse(s, allowUnparsed: true));
        }

        /// <summary>
        /// <see cref="OrgName"/>-typed view over the <see cref="RepeatedRef"/> resource name property.
        /// </summary>
        public gax::ResourceNameList<OrgName> RepeatedRefAsOrgNames
        {
            get => new gax::ResourceNameList<OrgName>(RepeatedRef, s => string.IsNullOrEmpty(s) ? null : OrgName.Parse(s, allowUnparsed: true));
        }

        /// <summary>
        /// <see cref="DeptName"/>-typed view over the <see cref="RepeatedRef"/> resource name property.
        /// </summary>
        public gax::ResourceNameList<DeptName> RepeatedRefAsDeptNames
        {
            get => new gax::ResourceNameList<DeptName>(RepeatedRef, s => string.IsNullOrEmpty(s) ? null : DeptName.Parse(s, allowUnparsed: true));
        }

        /// <summary>
        /// <see cref="gax::IResourceName"/>-typed view over the <see cref="RepeatedRef"/> resource name property.
        /// </summary>
        public gax::ResourceNameList<gax::IResourceName> RepeatedRefAsResourceNames
        {
            get => new gax::ResourceNameList<gax::IResourceName>(RepeatedRef, s =>
            {
                if (string.IsNullOrEmpty(s))
                {
                    return null;
                }
                if (ProjectName.TryParse(s, out ProjectName project))
                {
                    return project;
                }
                if (OrgName.TryParse(s, out OrgName org))
                {
                    return org;
                }
                if (DeptName.TryParse(s, out DeptName dept))
                {
                    return dept;
                }
                return gax::UnparsedResourceName.Parse(s);
            });
        }
    }

    public partial class TripleWildcardParent
    {
        /// <summary><see cref="ProjectName"/>-typed view over the <see cref="Ref"/> resource name property.</summary>
        public ProjectName RefAsProjectName
        {
            get => string.IsNullOrEmpty(Ref) ? null : ProjectName.Parse(Ref, allowUnparsed: true);
            set => Ref = value?.ToString() ?? "";
        }

        /// <summary><see cref="OrgName"/>-typed view over the <see cref="Ref"/> resource name property.</summary>
        public OrgName RefAsOrgName
        {
            get => string.IsNullOrEmpty(Ref) ? null : OrgName.Parse(Ref, allowUnparsed: true);
            set => Ref = value?.ToString() ?? "";
        }

        /// <summary><see cref="DeptName"/>-typed view over the <see cref="Ref"/> resource name property.</summary>
        public DeptName RefAsDeptName
        {
            get => string.IsNullOrEmpty(Ref) ? null : DeptName.Parse(Ref, allowUnparsed: true);
            set => Ref = value?.ToString() ?? "";
        }

        /// <summary>
        /// <see cref="gax::IResourceName"/>-typed view over the <see cref="Ref"/> resource name property.
        /// </summary>
        public gax::IResourceName RefAsResourceName
        {
            get
            {
                if (string.IsNullOrEmpty(Ref))
                {
                    return null;
                }
                if (ProjectName.TryParse(Ref, out ProjectName project))
                {
                    return project;
                }
                if (OrgName.TryParse(Ref, out OrgName org))
                {
                    return org;
                }
                if (DeptName.TryParse(Ref, out DeptName dept))
                {
                    return dept;
                }
                return gax::UnparsedResourceName.Parse(Ref);
            }
            set => Ref = value?.ToString() ?? "";
        }

        /// <summary>
        /// <see cref="ProjectName"/>-typed view over the <see cref="RepeatedRef"/> resource name property.
        /// </summary>
        public gax::ResourceNameList<ProjectName> RepeatedRefAsProjectNames
        {
            get => new gax::ResourceNameList<ProjectName>(RepeatedRef, s => string.IsNullOrEmpty(s) ? null : ProjectName.Parse(s, allowUnparsed: true));
        }

        /// <summary>
        /// <see cref="OrgName"/>-typed view over the <see cref="RepeatedRef"/> resource name property.
        /// </summary>
        public gax::ResourceNameList<OrgName> RepeatedRefAsOrgNames
        {
            get => new gax::ResourceNameList<OrgName>(RepeatedRef, s => string.IsNullOrEmpty(s) ? null : OrgName.Parse(s, allowUnparsed: true));
        }

        /// <summary>
        /// <see cref="DeptName"/>-typed view over the <see cref="RepeatedRef"/> resource name property.
        /// </summary>
        public gax::ResourceNameList<DeptName> RepeatedRefAsDeptNames
        {
            get => new gax::ResourceNameList<DeptName>(RepeatedRef, s => string.IsNullOrEmpty(s) ? null : DeptName.Parse(s, allowUnparsed: true));
        }

        /// <summary>
        /// <see cref="gax::IResourceName"/>-typed view over the <see cref="RepeatedRef"/> resource name property.
        /// </summary>
        public gax::ResourceNameList<gax::IResourceName> RepeatedRefAsResourceNames
        {
            get => new gax::ResourceNameList<gax::IResourceName>(RepeatedRef, s =>
            {
                if (string.IsNullOrEmpty(s))
                {
                    return null;
                }
                if (ProjectName.TryParse(s, out ProjectName project))
                {
                    return project;
                }
                if (OrgName.TryParse(s, out OrgName org))
                {
                    return org;
                }
                if (DeptName.TryParse(s, out DeptName dept))
                {
                    return dept;
                }
                return gax::UnparsedResourceName.Parse(s);
            });
        }
    }

    public partial class OverlapParent
    {
        /// <summary><see cref="ProjectName"/>-typed view over the <see cref="Ref"/> resource name property.</summary>
        public ProjectName RefAsProjectName
        {
            get => string.IsNullOrEmpty(Ref) ? null : ProjectName.Parse(Ref, allowUnparsed: true);
            set => Ref = value?.ToString() ?? "";
        }

        /// <summary><see cref="OrgName"/>-typed view over the <see cref="Ref"/> resource name property.</summary>
        public OrgName RefAsOrgName
        {
            get => string.IsNullOrEmpty(Ref) ? null : OrgName.Parse(Ref, allowUnparsed: true);
            set => Ref = value?.ToString() ?? "";
        }

        /// <summary><see cref="DeptName"/>-typed view over the <see cref="Ref"/> resource name property.</summary>
        public DeptName RefAsDeptName
        {
            get => string.IsNullOrEmpty(Ref) ? null : DeptName.Parse(Ref, allowUnparsed: true);
            set => Ref = value?.ToString() ?? "";
        }

        /// <summary>
        /// <see cref="ProjectOverlapName"/>-typed view over the <see cref="Ref"/> resource name property.
        /// </summary>
        public ProjectOverlapName RefAsProjectOverlapName
        {
            get => string.IsNullOrEmpty(Ref) ? null : ProjectOverlapName.Parse(Ref, allowUnparsed: true);
            set => Ref = value?.ToString() ?? "";
        }

        /// <summary>
        /// <see cref="OrgOverlapName"/>-typed view over the <see cref="Ref"/> resource name property.
        /// </summary>
        public OrgOverlapName RefAsOrgOverlapName
        {
            get => string.IsNullOrEmpty(Ref) ? null : OrgOverlapName.Parse(Ref, allowUnparsed: true);
            set => Ref = value?.ToString() ?? "";
        }

        /// <summary>
        /// <see cref="AllOverlapName"/>-typed view over the <see cref="Ref"/> resource name property.
        /// </summary>
        public AllOverlapName RefAsAllOverlapName
        {
            get => string.IsNullOrEmpty(Ref) ? null : AllOverlapName.Parse(Ref, allowUnparsed: true);
            set => Ref = value?.ToString() ?? "";
        }

        /// <summary>
        /// <see cref="gax::IResourceName"/>-typed view over the <see cref="Ref"/> resource name property.
        /// </summary>
        public gax::IResourceName RefAsResourceName
        {
            get
            {
                if (string.IsNullOrEmpty(Ref))
                {
                    return null;
                }
                if (ProjectName.TryParse(Ref, out ProjectName project))
                {
                    return project;
                }
                if (OrgName.TryParse(Ref, out OrgName org))
                {
                    return org;
                }
                if (DeptName.TryParse(Ref, out DeptName dept))
                {
                    return dept;
                }
                if (ProjectOverlapName.TryParse(Ref, out ProjectOverlapName projectOverlap))
                {
                    return projectOverlap;
                }
                if (OrgOverlapName.TryParse(Ref, out OrgOverlapName orgOverlap))
                {
                    return orgOverlap;
                }
                if (AllOverlapName.TryParse(Ref, out AllOverlapName allOverlap))
                {
                    return allOverlap;
                }
                return gax::UnparsedResourceName.Parse(Ref);
            }
            set => Ref = value?.ToString() ?? "";
        }

        /// <summary>
        /// <see cref="ProjectName"/>-typed view over the <see cref="RepeatedRef"/> resource name property.
        /// </summary>
        public gax::ResourceNameList<ProjectName> RepeatedRefAsProjectNames
        {
            get => new gax::ResourceNameList<ProjectName>(RepeatedRef, s => string.IsNullOrEmpty(s) ? null : ProjectName.Parse(s, allowUnparsed: true));
        }

        /// <summary>
        /// <see cref="OrgName"/>-typed view over the <see cref="RepeatedRef"/> resource name property.
        /// </summary>
        public gax::ResourceNameList<OrgName> RepeatedRefAsOrgNames
        {
            get => new gax::ResourceNameList<OrgName>(RepeatedRef, s => string.IsNullOrEmpty(s) ? null : OrgName.Parse(s, allowUnparsed: true));
        }

        /// <summary>
        /// <see cref="DeptName"/>-typed view over the <see cref="RepeatedRef"/> resource name property.
        /// </summary>
        public gax::ResourceNameList<DeptName> RepeatedRefAsDeptNames
        {
            get => new gax::ResourceNameList<DeptName>(RepeatedRef, s => string.IsNullOrEmpty(s) ? null : DeptName.Parse(s, allowUnparsed: true));
        }

        /// <summary>
        /// <see cref="ProjectOverlapName"/>-typed view over the <see cref="RepeatedRef"/> resource name property.
        /// </summary>
        public gax::ResourceNameList<ProjectOverlapName> RepeatedRefAsProjectOverlapNames
        {
            get => new gax::ResourceNameList<ProjectOverlapName>(RepeatedRef, s => string.IsNullOrEmpty(s) ? null : ProjectOverlapName.Parse(s, allowUnparsed: true));
        }

        /// <summary>
        /// <see cref="OrgOverlapName"/>-typed view over the <see cref="RepeatedRef"/> resource name property.
        /// </summary>
        public gax::ResourceNameList<OrgOverlapName> RepeatedRefAsOrgOverlapNames
        {
            get => new gax::ResourceNameList<OrgOverlapName>(RepeatedRef, s => string.IsNullOrEmpty(s) ? null : OrgOverlapName.Parse(s, allowUnparsed: true));
        }

        /// <summary>
        /// <see cref="AllOverlapName"/>-typed view over the <see cref="RepeatedRef"/> resource name property.
        /// </summary>
        public gax::ResourceNameList<AllOverlapName> RepeatedRefAsAllOverlapNames
        {
            get => new gax::ResourceNameList<AllOverlapName>(RepeatedRef, s => string.IsNullOrEmpty(s) ? null : AllOverlapName.Parse(s, allowUnparsed: true));
        }

        /// <summary>
        /// <see cref="gax::IResourceName"/>-typed view over the <see cref="RepeatedRef"/> resource name property.
        /// </summary>
        public gax::ResourceNameList<gax::IResourceName> RepeatedRefAsResourceNames
        {
            get => new gax::ResourceNameList<gax::IResourceName>(RepeatedRef, s =>
            {
                if (string.IsNullOrEmpty(s))
                {
                    return null;
                }
                if (ProjectName.TryParse(s, out ProjectName project))
                {
                    return project;
                }
                if (OrgName.TryParse(s, out OrgName org))
                {
                    return org;
                }
                if (DeptName.TryParse(s, out DeptName dept))
                {
                    return dept;
                }
                if (ProjectOverlapName.TryParse(s, out ProjectOverlapName projectOverlap))
                {
                    return projectOverlap;
                }
                if (OrgOverlapName.TryParse(s, out OrgOverlapName orgOverlap))
                {
                    return orgOverlap;
                }
                if (AllOverlapName.TryParse(s, out AllOverlapName allOverlap))
                {
                    return allOverlap;
                }
                return gax::UnparsedResourceName.Parse(s);
            });
        }
    }
}
