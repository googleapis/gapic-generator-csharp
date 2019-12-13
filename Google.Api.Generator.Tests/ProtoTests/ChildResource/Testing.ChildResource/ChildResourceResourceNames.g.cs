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
        /// The contained <see cref="gax::UnparsedResourceName"/>. Only non-<c>null</c>if this instance contains an
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

    /// <summary>Resource name for the <c>ProjectUser</c> resource.</summary>
    public sealed partial class ProjectUserName : gax::IResourceName, sys::IEquatable<ProjectUserName>
    {
        /// <summary>The possible contents of <see cref="ProjectUserName"/>.</summary>
        public enum ResourceNameType
        {
            /// <summary>An unparsed resource name.</summary>
            Unparsed = 0,

            /// <summary>A resource name with pattern <c>projects/{project}/users/{user}</c>.</summary>
            ProjectUser = 1
        }

        private static gax::PathTemplate s_projectUser = new gax::PathTemplate("projects/{project}/users/{user}");

        /// <summary>Creates a <see cref="ProjectUserName"/> containing an unparsed resource name.</summary>
        /// <param name="unparsedResourceName">The unparsed resource name. Must not be <c>null</c>.</param>
        /// <returns>
        /// A new instance of <see cref="ProjectUserName"/> containing the provided
        /// <paramref name="unparsedResourceName"/>.
        /// </returns>
        public static ProjectUserName FromUnparsed(gax::UnparsedResourceName unparsedResourceName) =>
            new ProjectUserName(ResourceNameType.Unparsed, gax::GaxPreconditions.CheckNotNull(unparsedResourceName, nameof(unparsedResourceName)));

        /// <summary>
        /// Creates a <see cref="ProjectUserName"/> with the pattern <c>projects/{project}/users/{user}</c>.
        /// </summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="userId">The <c>User</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="ProjectUserName"/> constructed from the provided ids.</returns>
        public static ProjectUserName FromProjectUser(string projectId, string userId) =>
            new ProjectUserName(ResourceNameType.ProjectUser, projectId: gax::GaxPreconditions.CheckNotNullOrEmpty(projectId, nameof(projectId)), userId: gax::GaxPreconditions.CheckNotNullOrEmpty(userId, nameof(userId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="ProjectUserName"/> with pattern
        /// <c>projects/{project}/users/{user}</c>.
        /// </summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="userId">The <c>User</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="ProjectUserName"/> with pattern
        /// <c>projects/{project}/users/{user}</c>.
        /// </returns>
        public static string Format(string projectId, string userId) => FormatProjectUser(projectId, userId);

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="ProjectUserName"/> with pattern
        /// <c>projects/{project}/users/{user}</c>.
        /// </summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="userId">The <c>User</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="ProjectUserName"/> with pattern
        /// <c>projects/{project}/users/{user}</c>.
        /// </returns>
        public static string FormatProjectUser(string projectId, string userId) =>
            s_projectUser.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(projectId, nameof(projectId)), gax::GaxPreconditions.CheckNotNullOrEmpty(userId, nameof(userId)));

        /// <summary>Parses the given resource name string into a new <see cref="ProjectUserName"/> instance.</summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>projects/{project}/users/{user}</c></description></item></list>
        /// </remarks>
        /// <param name="projectUserName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="ProjectUserName"/> if successful.</returns>
        public static ProjectUserName Parse(string projectUserName) => Parse(projectUserName, false);

        /// <summary>
        /// Parses the given resource name string into a new <see cref="ProjectUserName"/> instance; optionally allowing
        /// an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>projects/{project}/users/{user}</c></description></item></list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="projectUserName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <returns>The parsed <see cref="ProjectUserName"/> if successful.</returns>
        public static ProjectUserName Parse(string projectUserName, bool allowUnparsed) =>
            TryParse(projectUserName, allowUnparsed, out ProjectUserName result) ? result : throw new sys::ArgumentException("The given resource-name matches no pattern.");

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="ProjectUserName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>projects/{project}/users/{user}</c></description></item></list>
        /// </remarks>
        /// <param name="projectUserName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="ProjectUserName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string projectUserName, out ProjectUserName result) =>
            TryParse(projectUserName, false, out result);

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="ProjectUserName"/> instance; optionally
        /// allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>projects/{project}/users/{user}</c></description></item></list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="projectUserName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="ProjectUserName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string projectUserName, bool allowUnparsed, out ProjectUserName result)
        {
            gax::GaxPreconditions.CheckNotNull(projectUserName, nameof(projectUserName));
            gax::TemplatedResourceName resourceName;
            if (s_projectUser.TryParseName(projectUserName, out resourceName))
            {
                result = FromProjectUser(resourceName[0], resourceName[1]);
                return true;
            }
            if (allowUnparsed)
            {
                if (gax::UnparsedResourceName.TryParse(projectUserName, out gax::UnparsedResourceName unparsedResourceName))
                {
                    result = FromUnparsed(unparsedResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        private ProjectUserName(ResourceNameType type, gax::UnparsedResourceName unparsedResourceName = null, string projectId = null, string userId = null)
        {
            Type = type;
            UnparsedResource = unparsedResourceName;
            ProjectId = projectId;
            UserId = userId;
        }

        /// <summary>
        /// Constructs a new instance of a <see cref="ProjectUserName"/> class from the component parts of pattern
        /// <c>projects/{project}/users/{user}</c>
        /// </summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="userId">The <c>User</c> ID. Must not be <c>null</c> or empty.</param>
        public ProjectUserName(string projectId, string userId) : this(ResourceNameType.ProjectUser, projectId: gax::GaxPreconditions.CheckNotNullOrEmpty(projectId, nameof(projectId)), userId: gax::GaxPreconditions.CheckNotNullOrEmpty(userId, nameof(userId)))
        {
        }

        /// <summary>The <see cref="ResourceNameType"/> of the contained resource name.</summary>
        public ResourceNameType Type { get; }

        /// <summary>
        /// The contained <see cref="gax::UnparsedResourceName"/>. Only non-<c>null</c>if this instance contains an
        /// unparsed resource name.
        /// </summary>
        public gax::UnparsedResourceName UnparsedResource { get; }

        /// <summary>
        /// The <c>Project</c> ID. Will not be <c>null</c>, unless this instance contains an unparsed resource name.
        /// </summary>
        public string ProjectId { get; }

        /// <summary>
        /// The <c>User</c> ID. Will not be <c>null</c>, unless this instance contains an unparsed resource name.
        /// </summary>
        public string UserId { get; }

        /// <inheritdoc/>
        public bool IsKnownPattern => Type != ResourceNameType.Unparsed;

        /// <inheritdoc/>
        public override string ToString()
        {
            switch (Type)
            {
                case ResourceNameType.Unparsed: return UnparsedResource.ToString();
                case ResourceNameType.ProjectUser: return s_projectUser.Expand(ProjectId, UserId);
                default: throw new sys::InvalidOperationException("Unrecognized resource-type.");
            }
        }

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as ProjectUserName);

        /// <inheritdoc/>
        public bool Equals(ProjectUserName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(ProjectUserName a, ProjectUserName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(ProjectUserName a, ProjectUserName b) => !(a == b);
    }

    /// <summary>Resource name for the <c>MultiRootItem</c> resource.</summary>
    public sealed partial class MultiRootItemName : gax::IResourceName, sys::IEquatable<MultiRootItemName>
    {
        /// <summary>The possible contents of <see cref="MultiRootItemName"/>.</summary>
        public enum ResourceNameType
        {
            /// <summary>An unparsed resource name.</summary>
            Unparsed = 0,

            /// <summary>A resource name with pattern <c>root_a/{root_a}/items/{item}</c>.</summary>
            RootAItem = 1,

            /// <summary>A resource name with pattern <c>root_b/{root_b}/items/{item}</c>.</summary>
            RootBItem = 2
        }

        private static gax::PathTemplate s_rootAItem = new gax::PathTemplate("root_a/{root_a}/items/{item}");

        private static gax::PathTemplate s_rootBItem = new gax::PathTemplate("root_b/{root_b}/items/{item}");

        /// <summary>Creates a <see cref="MultiRootItemName"/> containing an unparsed resource name.</summary>
        /// <param name="unparsedResourceName">The unparsed resource name. Must not be <c>null</c>.</param>
        /// <returns>
        /// A new instance of <see cref="MultiRootItemName"/> containing the provided
        /// <paramref name="unparsedResourceName"/>.
        /// </returns>
        public static MultiRootItemName FromUnparsed(gax::UnparsedResourceName unparsedResourceName) =>
            new MultiRootItemName(ResourceNameType.Unparsed, gax::GaxPreconditions.CheckNotNull(unparsedResourceName, nameof(unparsedResourceName)));

        /// <summary>
        /// Creates a <see cref="MultiRootItemName"/> with the pattern <c>root_a/{root_a}/items/{item}</c>.
        /// </summary>
        /// <param name="rootAId">The <c>RootA</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="MultiRootItemName"/> constructed from the provided ids.</returns>
        public static MultiRootItemName FromRootAItem(string rootAId, string itemId) =>
            new MultiRootItemName(ResourceNameType.RootAItem, rootAId: gax::GaxPreconditions.CheckNotNullOrEmpty(rootAId, nameof(rootAId)), itemId: gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Creates a <see cref="MultiRootItemName"/> with the pattern <c>root_b/{root_b}/items/{item}</c>.
        /// </summary>
        /// <param name="rootBId">The <c>RootB</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="MultiRootItemName"/> constructed from the provided ids.</returns>
        public static MultiRootItemName FromRootBItem(string rootBId, string itemId) =>
            new MultiRootItemName(ResourceNameType.RootBItem, rootBId: gax::GaxPreconditions.CheckNotNullOrEmpty(rootBId, nameof(rootBId)), itemId: gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="MultiRootItemName"/> with pattern
        /// <c>root_a/{root_a}/items/{item}</c>.
        /// </summary>
        /// <param name="rootAId">The <c>RootA</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="MultiRootItemName"/> with pattern
        /// <c>root_a/{root_a}/items/{item}</c>.
        /// </returns>
        public static string Format(string rootAId, string itemId) => FormatRootAItem(rootAId, itemId);

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="MultiRootItemName"/> with pattern
        /// <c>root_a/{root_a}/items/{item}</c>.
        /// </summary>
        /// <param name="rootAId">The <c>RootA</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="MultiRootItemName"/> with pattern
        /// <c>root_a/{root_a}/items/{item}</c>.
        /// </returns>
        public static string FormatRootAItem(string rootAId, string itemId) =>
            s_rootAItem.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(rootAId, nameof(rootAId)), gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="MultiRootItemName"/> with pattern
        /// <c>root_b/{root_b}/items/{item}</c>.
        /// </summary>
        /// <param name="rootBId">The <c>RootB</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="MultiRootItemName"/> with pattern
        /// <c>root_b/{root_b}/items/{item}</c>.
        /// </returns>
        public static string FormatRootBItem(string rootBId, string itemId) =>
            s_rootBItem.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(rootBId, nameof(rootBId)), gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Parses the given resource name string into a new <see cref="MultiRootItemName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>root_a/{root_a}/items/{item}</c></description></item>
        /// <item><description><c>root_b/{root_b}/items/{item}</c></description></item>
        /// </list>
        /// </remarks>
        /// <param name="multiRootItemName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="MultiRootItemName"/> if successful.</returns>
        public static MultiRootItemName Parse(string multiRootItemName) => Parse(multiRootItemName, false);

        /// <summary>
        /// Parses the given resource name string into a new <see cref="MultiRootItemName"/> instance; optionally
        /// allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>root_a/{root_a}/items/{item}</c></description></item>
        /// <item><description><c>root_b/{root_b}/items/{item}</c></description></item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="multiRootItemName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <returns>The parsed <see cref="MultiRootItemName"/> if successful.</returns>
        public static MultiRootItemName Parse(string multiRootItemName, bool allowUnparsed) =>
            TryParse(multiRootItemName, allowUnparsed, out MultiRootItemName result) ? result : throw new sys::ArgumentException("The given resource-name matches no pattern.");

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="MultiRootItemName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>root_a/{root_a}/items/{item}</c></description></item>
        /// <item><description><c>root_b/{root_b}/items/{item}</c></description></item>
        /// </list>
        /// </remarks>
        /// <param name="multiRootItemName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="MultiRootItemName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string multiRootItemName, out MultiRootItemName result) =>
            TryParse(multiRootItemName, false, out result);

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="MultiRootItemName"/> instance;
        /// optionally allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>root_a/{root_a}/items/{item}</c></description></item>
        /// <item><description><c>root_b/{root_b}/items/{item}</c></description></item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="multiRootItemName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="MultiRootItemName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string multiRootItemName, bool allowUnparsed, out MultiRootItemName result)
        {
            gax::GaxPreconditions.CheckNotNull(multiRootItemName, nameof(multiRootItemName));
            gax::TemplatedResourceName resourceName;
            if (s_rootAItem.TryParseName(multiRootItemName, out resourceName))
            {
                result = FromRootAItem(resourceName[0], resourceName[1]);
                return true;
            }
            if (s_rootBItem.TryParseName(multiRootItemName, out resourceName))
            {
                result = FromRootBItem(resourceName[0], resourceName[1]);
                return true;
            }
            if (allowUnparsed)
            {
                if (gax::UnparsedResourceName.TryParse(multiRootItemName, out gax::UnparsedResourceName unparsedResourceName))
                {
                    result = FromUnparsed(unparsedResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        private MultiRootItemName(ResourceNameType type, gax::UnparsedResourceName unparsedResourceName = null, string itemId = null, string rootAId = null, string rootBId = null)
        {
            Type = type;
            UnparsedResource = unparsedResourceName;
            ItemId = itemId;
            RootAId = rootAId;
            RootBId = rootBId;
        }

        /// Constructs a new instance of a <see cref="MultiRootItemName"/> class from the component parts of pattern
        /// <c>root_a/{root_a}/items/{item}</c>
        /// </summary>
        /// <param name="rootAId">The <c>RootA</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        public MultiRootItemName(string rootAId, string itemId) : this(ResourceNameType.RootAItem, rootAId: gax::GaxPreconditions.CheckNotNullOrEmpty(rootAId, nameof(rootAId)), itemId: gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)))
        {
        }

        /// <summary>The <see cref="ResourceNameType"/> of the contained resource name.</summary>
        public ResourceNameType Type { get; }

        /// <summary>
        /// The contained <see cref="gax::UnparsedResourceName"/>. Only non-<c>null</c>if this instance contains an
        /// unparsed resource name.
        /// </summary>
        public gax::UnparsedResourceName UnparsedResource { get; }

        /// <summary>
        /// The <c>Item</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string ItemId { get; }

        /// <summary>
        /// The <c>RootA</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string RootAId { get; }

        /// <summary>
        /// The <c>RootB</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string RootBId { get; }

        /// <inheritdoc/>
        public bool IsKnownPattern => Type != ResourceNameType.Unparsed;

        /// <inheritdoc/>
        public override string ToString()
        {
            switch (Type)
            {
                case ResourceNameType.Unparsed: return UnparsedResource.ToString();
                case ResourceNameType.RootAItem: return s_rootAItem.Expand(RootAId, ItemId);
                case ResourceNameType.RootBItem: return s_rootBItem.Expand(RootBId, ItemId);
                default: throw new sys::InvalidOperationException("Unrecognized resource-type.");
            }
        }

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as MultiRootItemName);

        /// <inheritdoc/>
        public bool Equals(MultiRootItemName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(MultiRootItemName a, MultiRootItemName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(MultiRootItemName a, MultiRootItemName b) => !(a == b);
    }

    /// <summary>Resource name for the <c>Roots</c> resource.</summary>
    public sealed partial class RootsName : gax::IResourceName, sys::IEquatable<RootsName>
    {
        /// <summary>The possible contents of <see cref="RootsName"/>.</summary>
        public enum ResourceNameType
        {
            /// <summary>An unparsed resource name.</summary>
            Unparsed = 0,

            /// <summary>A resource name with pattern <c>root_a/{root_a}</c>.</summary>
            RootA = 1,

            /// <summary>A resource name with pattern <c>root_b/{root_b}</c>.</summary>
            RootB = 2
        }

        private static gax::PathTemplate s_rootA = new gax::PathTemplate("root_a/{root_a}");

        private static gax::PathTemplate s_rootB = new gax::PathTemplate("root_b/{root_b}");

        /// <summary>Creates a <see cref="RootsName"/> containing an unparsed resource name.</summary>
        /// <param name="unparsedResourceName">The unparsed resource name. Must not be <c>null</c>.</param>
        /// <returns>
        /// A new instance of <see cref="RootsName"/> containing the provided <paramref name="unparsedResourceName"/>.
        /// </returns>
        public static RootsName FromUnparsed(gax::UnparsedResourceName unparsedResourceName) =>
            new RootsName(ResourceNameType.Unparsed, gax::GaxPreconditions.CheckNotNull(unparsedResourceName, nameof(unparsedResourceName)));

        /// <summary>Creates a <see cref="RootsName"/> with the pattern <c>root_a/{root_a}</c>.</summary>
        /// <param name="rootAId">The <c>RootA</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="RootsName"/> constructed from the provided ids.</returns>
        public static RootsName FromRootA(string rootAId) =>
            new RootsName(ResourceNameType.RootA, rootAId: gax::GaxPreconditions.CheckNotNullOrEmpty(rootAId, nameof(rootAId)));

        /// <summary>Creates a <see cref="RootsName"/> with the pattern <c>root_b/{root_b}</c>.</summary>
        /// <param name="rootBId">The <c>RootB</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="RootsName"/> constructed from the provided ids.</returns>
        public static RootsName FromRootB(string rootBId) =>
            new RootsName(ResourceNameType.RootB, rootBId: gax::GaxPreconditions.CheckNotNullOrEmpty(rootBId, nameof(rootBId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="RootsName"/> with pattern
        /// <c>root_a/{root_a}</c>.
        /// </summary>
        /// <param name="rootAId">The <c>RootA</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="RootsName"/> with pattern <c>root_a/{root_a}</c>.
        /// </returns>
        public static string Format(string rootAId) => FormatRootA(rootAId);

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="RootsName"/> with pattern
        /// <c>root_a/{root_a}</c>.
        /// </summary>
        /// <param name="rootAId">The <c>RootA</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="RootsName"/> with pattern <c>root_a/{root_a}</c>.
        /// </returns>
        public static string FormatRootA(string rootAId) =>
            s_rootA.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(rootAId, nameof(rootAId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="RootsName"/> with pattern
        /// <c>root_b/{root_b}</c>.
        /// </summary>
        /// <param name="rootBId">The <c>RootB</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="RootsName"/> with pattern <c>root_b/{root_b}</c>.
        /// </returns>
        public static string FormatRootB(string rootBId) =>
            s_rootB.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(rootBId, nameof(rootBId)));

        /// <summary>Parses the given resource name string into a new <see cref="RootsName"/> instance.</summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>root_a/{root_a}</c></description></item>
        /// <item><description><c>root_b/{root_b}</c></description></item>
        /// </list>
        /// </remarks>
        /// <param name="rootsName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="RootsName"/> if successful.</returns>
        public static RootsName Parse(string rootsName) => Parse(rootsName, false);

        /// <summary>
        /// Parses the given resource name string into a new <see cref="RootsName"/> instance; optionally allowing an
        /// unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>root_a/{root_a}</c></description></item>
        /// <item><description><c>root_b/{root_b}</c></description></item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="rootsName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <returns>The parsed <see cref="RootsName"/> if successful.</returns>
        public static RootsName Parse(string rootsName, bool allowUnparsed) =>
            TryParse(rootsName, allowUnparsed, out RootsName result) ? result : throw new sys::ArgumentException("The given resource-name matches no pattern.");

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="RootsName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>root_a/{root_a}</c></description></item>
        /// <item><description><c>root_b/{root_b}</c></description></item>
        /// </list>
        /// </remarks>
        /// <param name="rootsName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="RootsName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string rootsName, out RootsName result) => TryParse(rootsName, false, out result);

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="RootsName"/> instance; optionally
        /// allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>root_a/{root_a}</c></description></item>
        /// <item><description><c>root_b/{root_b}</c></description></item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="rootsName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="RootsName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string rootsName, bool allowUnparsed, out RootsName result)
        {
            gax::GaxPreconditions.CheckNotNull(rootsName, nameof(rootsName));
            gax::TemplatedResourceName resourceName;
            if (s_rootA.TryParseName(rootsName, out resourceName))
            {
                result = FromRootA(resourceName[0]);
                return true;
            }
            if (s_rootB.TryParseName(rootsName, out resourceName))
            {
                result = FromRootB(resourceName[0]);
                return true;
            }
            if (allowUnparsed)
            {
                if (gax::UnparsedResourceName.TryParse(rootsName, out gax::UnparsedResourceName unparsedResourceName))
                {
                    result = FromUnparsed(unparsedResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        private RootsName(ResourceNameType type, gax::UnparsedResourceName unparsedResourceName = null, string rootAId = null, string rootBId = null)
        {
            Type = type;
            UnparsedResource = unparsedResourceName;
            RootAId = rootAId;
            RootBId = rootBId;
        }

        /// <summary>
        /// Constructs a new instance of a <see cref="RootsName"/> class from the component parts of pattern
        /// <c>root_a/{root_a}</c>
        /// </summary>
        /// <param name="rootAId">The <c>RootA</c> ID. Must not be <c>null</c> or empty.</param>
        public RootsName(string rootAId) : this(ResourceNameType.RootA, rootAId: gax::GaxPreconditions.CheckNotNullOrEmpty(rootAId, nameof(rootAId)))
        {
        }

        /// <summary>The <see cref="ResourceNameType"/> of the contained resource name.</summary>
        public ResourceNameType Type { get; }

        /// <summary>
        /// The contained <see cref="gax::UnparsedResourceName"/>. Only non-<c>null</c>if this instance contains an
        /// unparsed resource name.
        /// </summary>
        public gax::UnparsedResourceName UnparsedResource { get; }

        /// <summary>
        /// The <c>RootA</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string RootAId { get; }

        /// <summary>
        /// The <c>RootB</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string RootBId { get; }

        /// <inheritdoc/>
        public bool IsKnownPattern => Type != ResourceNameType.Unparsed;

        /// <inheritdoc/>
        public override string ToString()
        {
            switch (Type)
            {
                case ResourceNameType.Unparsed: return UnparsedResource.ToString();
                case ResourceNameType.RootA: return s_rootA.Expand(RootAId);
                case ResourceNameType.RootB: return s_rootB.Expand(RootBId);
                default: throw new sys::InvalidOperationException("Unrecognized resource-type.");
            }
        }

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as RootsName);

        /// <inheritdoc/>
        public bool Equals(RootsName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(RootsName a, RootsName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(RootsName a, RootsName b) => !(a == b);
    }

    public partial class ProjectRef
    {
        /// <summary>
        /// <see cref="ProjectUserName"/>-typed view over the <see cref="ProjectUserParent"/> resource name property.
        /// </summary>
        public ProjectUserName ProjectUserParentAsProjectUserName
        {
            get => string.IsNullOrEmpty(ProjectUserParent) ? null : ProjectUserName.Parse(ProjectUserParent);
            set => ProjectUserParent = value?.ToString() ?? "";
        }
    }

    public partial class MultiRootRef
    {
        /// <summary>
        /// <see cref="MultiRootItemName"/>-typed view over the <see cref="MultiRootParent"/> resource name property.
        /// </summary>
        public MultiRootItemName MultiRootParentAsMultiRootItemName
        {
            get => string.IsNullOrEmpty(MultiRootParent) ? null : MultiRootItemName.Parse(MultiRootParent);
            set => MultiRootParent = value?.ToString() ?? "";
        }
    }
}

