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
        private static readonly gax::PathTemplate s_template = new gax::PathTemplate("projects/{project}");

        /// <summary>
        /// Parses the given <c>Project</c> resource name in string form into a new <see cref="ProjectName"/> instance.
        /// </summary>
        /// <param name="projectName">The <c>Project</c> resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="ProjectName"/> if successful.</returns>
        public static ProjectName Parse(string projectName)
        {
            gax::GaxPreconditions.CheckNotNull(projectName, nameof(projectName));
            gax::TemplatedResourceName resourceName = s_template.ParseName(projectName);
            return new ProjectName(resourceName[0]);
        }

        /// <summary>
        /// Tries to parse the given session resource name in string form into a new <see cref="ProjectName"/> instance.
        /// </summary>
        /// <remarks>
        /// This method still throws <see cref="sys::ArgumentNullException"/> if <paramref name="projectName"/> is
        /// <c>null</c>, as this would usually indicate a programming error rather than a data error.
        /// </remarks>
        /// <param name="projectName">The <c>Project</c> resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="ProjectName"/>, or <c>null</c> if parsing fails.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string projectName, out ProjectName result)
        {
            gax::GaxPreconditions.CheckNotNull(projectName, nameof(projectName));
            if (s_template.TryParseName(projectName, out gax::TemplatedResourceName resourceName))
            {
                result = new ProjectName(resourceName[0]);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        /// <summary>Formats the IDs into the string representation of the <see cref="ProjectName"/>.</summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c>.</param>
        /// <returns>The string representation of the <see cref="ProjectName"/>.</returns>
        public static string Format(string projectId) =>
            s_template.Expand(gax::GaxPreconditions.CheckNotNull(projectId, nameof(projectId)));

        /// <summary>
        /// Constructs a new instance of the <see cref="ProjectName"/> resource name class from its component parts.
        /// </summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c>.</param>
        public ProjectName(string projectId) => ProjectId = gax::GaxPreconditions.CheckNotNull(projectId, nameof(projectId));

        /// <summary>The <c>Project</c> ID. Never <c>null</c>.</summary>
        public string ProjectId { get; }

        /// <inheritdoc/>
        public gax::ResourceNameKind Kind => gax::ResourceNameKind.Simple;

        /// <inheritdoc/>
        public override string ToString() => s_template.Expand(ProjectId);

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
        private static readonly gax::PathTemplate s_template = new gax::PathTemplate("projects/{project}/users/{user}");

        /// <summary>
        /// Parses the given <c>ProjectUser</c> resource name in string form into a new <see cref="ProjectUserName"/>
        /// instance.
        /// </summary>
        /// <param name="projectUserName">
        /// The <c>ProjectUser</c> resource name in string form. Must not be <c>null</c>.
        /// </param>
        /// <returns>The parsed <see cref="ProjectUserName"/> if successful.</returns>
        public static ProjectUserName Parse(string projectUserName)
        {
            gax::GaxPreconditions.CheckNotNull(projectUserName, nameof(projectUserName));
            gax::TemplatedResourceName resourceName = s_template.ParseName(projectUserName);
            return new ProjectUserName(resourceName[0], resourceName[1]);
        }

        /// <summary>
        /// Tries to parse the given session resource name in string form into a new <see cref="ProjectUserName"/>
        /// instance.
        /// </summary>
        /// <remarks>
        /// This method still throws <see cref="sys::ArgumentNullException"/> if <paramref name="projectUserName"/> is
        /// <c>null</c>, as this would usually indicate a programming error rather than a data error.
        /// </remarks>
        /// <param name="projectUserName">
        /// The <c>ProjectUser</c> resource name in string form. Must not be <c>null</c>.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="ProjectUserName"/>, or <c>null</c> if parsing fails.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string projectUserName, out ProjectUserName result)
        {
            gax::GaxPreconditions.CheckNotNull(projectUserName, nameof(projectUserName));
            if (s_template.TryParseName(projectUserName, out gax::TemplatedResourceName resourceName))
            {
                result = new ProjectUserName(resourceName[0], resourceName[1]);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        /// <summary>Formats the IDs into the string representation of the <see cref="ProjectUserName"/>.</summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c>.</param>
        /// <param name="userId">The <c>User</c> ID. Must not be <c>null</c>.</param>
        /// <returns>The string representation of the <see cref="ProjectUserName"/>.</returns>
        public static string Format(string projectId, string userId) =>
            s_template.Expand(gax::GaxPreconditions.CheckNotNull(projectId, nameof(projectId)), gax::GaxPreconditions.CheckNotNull(userId, nameof(userId)));

        /// <summary>
        /// Constructs a new instance of the <see cref="ProjectUserName"/> resource name class from its component parts.
        /// </summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c>.</param>
        /// <param name="userId">The <c>User</c> ID. Must not be <c>null</c>.</param>
        public ProjectUserName(string projectId, string userId)
        {
            ProjectId = gax::GaxPreconditions.CheckNotNull(projectId, nameof(projectId));
            UserId = gax::GaxPreconditions.CheckNotNull(userId, nameof(userId));
        }

        /// <summary>The <c>Project</c> ID. Never <c>null</c>.</summary>
        public string ProjectId { get; }

        /// <summary>The <c>User</c> ID. Never <c>null</c>.</summary>
        public string UserId { get; }

        /// <inheritdoc/>
        public gax::ResourceNameKind Kind => gax::ResourceNameKind.Simple;

        /// <inheritdoc/>
        public override string ToString() => s_template.Expand(ProjectId, UserId);

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

    /// <summary>Resource name for the <c>RootAItem</c> resource.</summary>
    public sealed partial class RootAItemName : gax::IResourceName, sys::IEquatable<RootAItemName>
    {
        private static readonly gax::PathTemplate s_template = new gax::PathTemplate("root_a/{root_a}/items/{item}");

        /// <summary>
        /// Parses the given <c>RootAItem</c> resource name in string form into a new <see cref="RootAItemName"/>
        /// instance.
        /// </summary>
        /// <param name="rootAItemName">
        /// The <c>RootAItem</c> resource name in string form. Must not be <c>null</c>.
        /// </param>
        /// <returns>The parsed <see cref="RootAItemName"/> if successful.</returns>
        public static RootAItemName Parse(string rootAItemName)
        {
            gax::GaxPreconditions.CheckNotNull(rootAItemName, nameof(rootAItemName));
            gax::TemplatedResourceName resourceName = s_template.ParseName(rootAItemName);
            return new RootAItemName(resourceName[0], resourceName[1]);
        }

        /// <summary>
        /// Tries to parse the given session resource name in string form into a new <see cref="RootAItemName"/>
        /// instance.
        /// </summary>
        /// <remarks>
        /// This method still throws <see cref="sys::ArgumentNullException"/> if <paramref name="rootAItemName"/> is
        /// <c>null</c>, as this would usually indicate a programming error rather than a data error.
        /// </remarks>
        /// <param name="rootAItemName">
        /// The <c>RootAItem</c> resource name in string form. Must not be <c>null</c>.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="RootAItemName"/>, or <c>null</c> if parsing fails.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string rootAItemName, out RootAItemName result)
        {
            gax::GaxPreconditions.CheckNotNull(rootAItemName, nameof(rootAItemName));
            if (s_template.TryParseName(rootAItemName, out gax::TemplatedResourceName resourceName))
            {
                result = new RootAItemName(resourceName[0], resourceName[1]);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        /// <summary>Formats the IDs into the string representation of the <see cref="RootAItemName"/>.</summary>
        /// <param name="rootAId">The <c>RootA</c> ID. Must not be <c>null</c>.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c>.</param>
        /// <returns>The string representation of the <see cref="RootAItemName"/>.</returns>
        public static string Format(string rootAId, string itemId) =>
            s_template.Expand(gax::GaxPreconditions.CheckNotNull(rootAId, nameof(rootAId)), gax::GaxPreconditions.CheckNotNull(itemId, nameof(itemId)));

        /// <summary>
        /// Constructs a new instance of the <see cref="RootAItemName"/> resource name class from its component parts.
        /// </summary>
        /// <param name="rootAId">The <c>RootA</c> ID. Must not be <c>null</c>.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c>.</param>
        public RootAItemName(string rootAId, string itemId)
        {
            RootAId = gax::GaxPreconditions.CheckNotNull(rootAId, nameof(rootAId));
            ItemId = gax::GaxPreconditions.CheckNotNull(itemId, nameof(itemId));
        }

        /// <summary>The <c>RootA</c> ID. Never <c>null</c>.</summary>
        public string RootAId { get; }

        /// <summary>The <c>Item</c> ID. Never <c>null</c>.</summary>
        public string ItemId { get; }

        /// <inheritdoc/>
        public gax::ResourceNameKind Kind => gax::ResourceNameKind.Simple;

        /// <inheritdoc/>
        public override string ToString() => s_template.Expand(RootAId, ItemId);

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as RootAItemName);

        /// <inheritdoc/>
        public bool Equals(RootAItemName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(RootAItemName a, RootAItemName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(RootAItemName a, RootAItemName b) => !(a == b);
    }

    /// <summary>Resource name for the <c>RootBItem</c> resource.</summary>
    public sealed partial class RootBItemName : gax::IResourceName, sys::IEquatable<RootBItemName>
    {
        private static readonly gax::PathTemplate s_template = new gax::PathTemplate("root_b/{root_b}/items/{item}");

        /// <summary>
        /// Parses the given <c>RootBItem</c> resource name in string form into a new <see cref="RootBItemName"/>
        /// instance.
        /// </summary>
        /// <param name="rootBItemName">
        /// The <c>RootBItem</c> resource name in string form. Must not be <c>null</c>.
        /// </param>
        /// <returns>The parsed <see cref="RootBItemName"/> if successful.</returns>
        public static RootBItemName Parse(string rootBItemName)
        {
            gax::GaxPreconditions.CheckNotNull(rootBItemName, nameof(rootBItemName));
            gax::TemplatedResourceName resourceName = s_template.ParseName(rootBItemName);
            return new RootBItemName(resourceName[0], resourceName[1]);
        }

        /// <summary>
        /// Tries to parse the given session resource name in string form into a new <see cref="RootBItemName"/>
        /// instance.
        /// </summary>
        /// <remarks>
        /// This method still throws <see cref="sys::ArgumentNullException"/> if <paramref name="rootBItemName"/> is
        /// <c>null</c>, as this would usually indicate a programming error rather than a data error.
        /// </remarks>
        /// <param name="rootBItemName">
        /// The <c>RootBItem</c> resource name in string form. Must not be <c>null</c>.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="RootBItemName"/>, or <c>null</c> if parsing fails.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string rootBItemName, out RootBItemName result)
        {
            gax::GaxPreconditions.CheckNotNull(rootBItemName, nameof(rootBItemName));
            if (s_template.TryParseName(rootBItemName, out gax::TemplatedResourceName resourceName))
            {
                result = new RootBItemName(resourceName[0], resourceName[1]);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        /// <summary>Formats the IDs into the string representation of the <see cref="RootBItemName"/>.</summary>
        /// <param name="rootBId">The <c>RootB</c> ID. Must not be <c>null</c>.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c>.</param>
        /// <returns>The string representation of the <see cref="RootBItemName"/>.</returns>
        public static string Format(string rootBId, string itemId) =>
            s_template.Expand(gax::GaxPreconditions.CheckNotNull(rootBId, nameof(rootBId)), gax::GaxPreconditions.CheckNotNull(itemId, nameof(itemId)));

        /// <summary>
        /// Constructs a new instance of the <see cref="RootBItemName"/> resource name class from its component parts.
        /// </summary>
        /// <param name="rootBId">The <c>RootB</c> ID. Must not be <c>null</c>.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c>.</param>
        public RootBItemName(string rootBId, string itemId)
        {
            RootBId = gax::GaxPreconditions.CheckNotNull(rootBId, nameof(rootBId));
            ItemId = gax::GaxPreconditions.CheckNotNull(itemId, nameof(itemId));
        }

        /// <summary>The <c>RootB</c> ID. Never <c>null</c>.</summary>
        public string RootBId { get; }

        /// <summary>The <c>Item</c> ID. Never <c>null</c>.</summary>
        public string ItemId { get; }

        /// <inheritdoc/>
        public gax::ResourceNameKind Kind => gax::ResourceNameKind.Simple;

        /// <inheritdoc/>
        public override string ToString() => s_template.Expand(RootBId, ItemId);

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as RootBItemName);

        /// <inheritdoc/>
        public bool Equals(RootBItemName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(RootBItemName a, RootBItemName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(RootBItemName a, RootBItemName b) => !(a == b);
    }

    /// <summary>Resource name which will contain one of a choice of resource names.</summary>
    /// <remarks>
    /// This resource name will contain one of the following:
    /// <list type="bullet">
    /// <item><description>RootAItemName: A resource of type 'root_a'.</description></item>
    /// <item><description>RootBItemName: A resource of type 'root_b'.</description></item>
    /// </list>
    /// </remarks>
    public sealed partial class MultiRootItemNameOneOf : gax::IResourceName, sys::IEquatable<MultiRootItemNameOneOf>
    {
        /// <summary>The possible contents of <see cref="MultiRootItemNameOneOf"/>.</summary>
        public enum OneofType
        {
            /// <summary>A resource of an unknown type.</summary>
            Unknown = 0,

            /// <summary>A resource of type 'root_a'</summary>
            RootAItemName = 1,

            /// <summary>A resource of type 'root_b'</summary>
            RootBItemName = 2
        }

        /// <summary>
        /// Parses the given <c>MultiRootItem</c> resource name in string form into a new
        /// <see cref="MultiRootItemNameOneOf"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully the resource name must be one of the following:
        /// <list type="bullet">
        /// <item><description>RootAItemName: A resource of type 'root_a'.</description></item>
        /// <item><description>RootBItemName: A resource of type 'root_b'.</description></item>
        /// </list>
        /// Or an <see cref="gax::UnknownResourceName"/> if <paramref name="allowUnknown"/> is <c>true</c>
        /// </remarks>
        /// <param name="name">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnknown">
        /// If <c>true</c>, will successfully parse an unknown resource name into an
        /// <see cref="gax::UnknownResourceName"/>; otherwise will throw an<see cref="sys::ArgumentException"/> if an
        /// unknown resource name is given.
        /// </param>
        /// <returns>The parsed <see cref="MultiRootItemNameOneOf"/> if successful.</returns>
        public static MultiRootItemNameOneOf Parse(string name, bool allowUnknown)
        {
            if (TryParse(name, allowUnknown, out MultiRootItemNameOneOf result))
            {
                return result;
            }
            throw new sys::ArgumentException("Invalid name", nameof(name));
        }

        /// <summary>
        /// Tries to parse a resource name in string form into a new <see cref="MultiRootItemNameOneOf"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully the resource name must be one of the following:
        /// <list type="bullet">
        /// <item><description>RootAItemName: A resource of type 'root_a'.</description></item>
        /// <item><description>RootBItemName: A resource of type 'root_b'.</description></item>
        /// </list>
        /// Or an <see cref="gax::UnknownResourceName"/> if <paramref name="allowUnknown"/> is <c>true</c>
        /// </remarks>
        /// <param name="name">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnknown">
        /// If <c>true</c>, will successfully parse an unknown resource name into an
        /// <see cref="gax::UnknownResourceName"/>.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="MultiRootItemNameOneOf"/>, or <c>null</c> if parsing fails.
        /// </param>
        /// <returns><c>true</c> if the name was parsed succssfully; othrewise <c>false</c></returns>
        public static bool TryParse(string name, bool allowUnknown, out MultiRootItemNameOneOf result)
        {
            gax::GaxPreconditions.CheckNotNull(name, nameof(name));
            if (RootAItemName.TryParse(name, out RootAItemName rootAItemName))
            {
                result = new MultiRootItemNameOneOf(OneofType.RootAItemName, rootAItemName);
                return true;
            }
            if (RootBItemName.TryParse(name, out RootBItemName rootBItemName))
            {
                result = new MultiRootItemNameOneOf(OneofType.RootBItemName, rootBItemName);
                return true;
            }
            if (allowUnknown)
            {
                if (gax::UnknownResourceName.TryParse(name, out gax::UnknownResourceName unknownResourceName))
                {
                    result = new MultiRootItemNameOneOf(OneofType.Unknown, unknownResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        /// <summary>
        /// Constructs a new instance of <see cref="MultiRootItemNameOneOf"/> from the provided
        /// <see cref="RootAItemName"/>.
        /// </summary>
        /// <param name="rootAItemName">
        /// The <see cref="RootAItemName"/> to be contained within the returned <see cref="MultiRootItemNameOneOf"/>.
        /// Must not be <c>null</c>
        /// </param>
        /// <returns>A new <see cref="MultiRootItemNameOneOf"/>, containing <paramref name="rootAItemName"/>.</returns>
        public static MultiRootItemNameOneOf From(RootAItemName rootAItemName) =>
            new MultiRootItemNameOneOf(OneofType.RootAItemName, rootAItemName);

        /// <summary>
        /// Constructs a new instance of <see cref="MultiRootItemNameOneOf"/> from the provided
        /// <see cref="RootBItemName"/>.
        /// </summary>
        /// <param name="rootBItemName">
        /// The <see cref="RootBItemName"/> to be contained within the returned <see cref="MultiRootItemNameOneOf"/>.
        /// Must not be <c>null</c>
        /// </param>
        /// <returns>A new <see cref="MultiRootItemNameOneOf"/>, containing <paramref name="rootBItemName"/>.</returns>
        public static MultiRootItemNameOneOf From(RootBItemName rootBItemName) =>
            new MultiRootItemNameOneOf(OneofType.RootBItemName, rootBItemName);

        private static bool IsValid(OneofType type, gax::IResourceName name)
        {
            switch (type)
            {
                case OneofType.Unknown: return true;
                case OneofType.RootAItemName: return name is RootAItemName;
                case OneofType.RootBItemName: return name is RootBItemName;
                default: return false;
            }
        }

        /// <summary>
        /// Constructs a new instance of <see cref="MultiRootItemNameOneOf"/> with an expected type and a resource name.
        /// </summary>
        /// <param name="type">The expected type of this oneof.</param>
        /// <param name="name">The resource name represented by this oneof. Must not be <c>null</c>.</param>
        public MultiRootItemNameOneOf(OneofType type, gax::IResourceName name)
        {
            Type = gax::GaxPreconditions.CheckEnumValue<OneofType>(type, nameof(type));
            Name = gax::GaxPreconditions.CheckNotNull(name, nameof(name));
            if (!IsValid(type, name))
            {
                throw new sys::ArgumentException($"Mismatched OneofType '{type}' and resource name '{name}'");
            }
        }

        /// <summary>The <see cref="OneofType"/> of the Name contained in this instance.</summary>
        public OneofType Type { get; }

        /// <summary>The <see cref="gax::IResourceName"/> contained in this instance.</summary>
        public gax::IResourceName Name { get; }

        private T CheckAndReturn<T>(OneofType type)
        {
            if (Type != type)
            {
                throw new sys::InvalidOperationException($"Requested type {type}, but this one-of contains type {Type}");
            }
            return (T)Name;
        }

        /// <summary>Get the contained <see cref="gax::IResourceName"/> as <see cref="RootAItemName"/>.</summary>
        /// <remarks>
        /// An <see cref="sys::InvalidOperationException"/> will be thrown is this does not contain an instance of
        /// <see cref="RootAItemName"/>.
        /// </remarks>
        public RootAItemName RootAItemName => CheckAndReturn<RootAItemName>(OneofType.RootAItemName);

        /// <summary>Get the contained <see cref="gax::IResourceName"/> as <see cref="RootBItemName"/>.</summary>
        /// <remarks>
        /// An <see cref="sys::InvalidOperationException"/> will be thrown is this does not contain an instance of
        /// <see cref="RootBItemName"/>.
        /// </remarks>
        public RootBItemName RootBItemName => CheckAndReturn<RootBItemName>(OneofType.RootBItemName);

        /// <inheritdoc/>
        public gax::ResourceNameKind Kind => gax::ResourceNameKind.Oneof;

        /// <inheritdoc/>
        public override string ToString() => this.Name.ToString();

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as MultiRootItemNameOneOf);

        /// <inheritdoc/>
        public bool Equals(MultiRootItemNameOneOf other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(MultiRootItemNameOneOf a, MultiRootItemNameOneOf b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(MultiRootItemNameOneOf a, MultiRootItemNameOneOf b) => !(a == b);
    }

    /// <summary>Resource name for the <c>RootA</c> resource.</summary>
    public sealed partial class RootAName : gax::IResourceName, sys::IEquatable<RootAName>
    {
        private static readonly gax::PathTemplate s_template = new gax::PathTemplate("root_a/{root_a}");

        /// <summary>
        /// Parses the given <c>RootA</c> resource name in string form into a new <see cref="RootAName"/> instance.
        /// </summary>
        /// <param name="rootAName">The <c>RootA</c> resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="RootAName"/> if successful.</returns>
        public static RootAName Parse(string rootAName)
        {
            gax::GaxPreconditions.CheckNotNull(rootAName, nameof(rootAName));
            gax::TemplatedResourceName resourceName = s_template.ParseName(rootAName);
            return new RootAName(resourceName[0]);
        }

        /// <summary>
        /// Tries to parse the given session resource name in string form into a new <see cref="RootAName"/> instance.
        /// </summary>
        /// <remarks>
        /// This method still throws <see cref="sys::ArgumentNullException"/> if <paramref name="rootAName"/> is <c>null</c>
        /// , as this would usually indicate a programming error rather than a data error.
        /// </remarks>
        /// <param name="rootAName">The <c>RootA</c> resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="RootAName"/>, or <c>null</c> if parsing fails.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string rootAName, out RootAName result)
        {
            gax::GaxPreconditions.CheckNotNull(rootAName, nameof(rootAName));
            if (s_template.TryParseName(rootAName, out gax::TemplatedResourceName resourceName))
            {
                result = new RootAName(resourceName[0]);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        /// <summary>Formats the IDs into the string representation of the <see cref="RootAName"/>.</summary>
        /// <param name="rootAId">The <c>RootA</c> ID. Must not be <c>null</c>.</param>
        /// <returns>The string representation of the <see cref="RootAName"/>.</returns>
        public static string Format(string rootAId) =>
            s_template.Expand(gax::GaxPreconditions.CheckNotNull(rootAId, nameof(rootAId)));

        /// <summary>
        /// Constructs a new instance of the <see cref="RootAName"/> resource name class from its component parts.
        /// </summary>
        /// <param name="rootAId">The <c>RootA</c> ID. Must not be <c>null</c>.</param>
        public RootAName(string rootAId) => RootAId = gax::GaxPreconditions.CheckNotNull(rootAId, nameof(rootAId));

        /// <summary>The <c>RootA</c> ID. Never <c>null</c>.</summary>
        public string RootAId { get; }

        /// <inheritdoc/>
        public gax::ResourceNameKind Kind => gax::ResourceNameKind.Simple;

        /// <inheritdoc/>
        public override string ToString() => s_template.Expand(RootAId);

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as RootAName);

        /// <inheritdoc/>
        public bool Equals(RootAName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(RootAName a, RootAName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(RootAName a, RootAName b) => !(a == b);
    }

    /// <summary>Resource name for the <c>RootB</c> resource.</summary>
    public sealed partial class RootBName : gax::IResourceName, sys::IEquatable<RootBName>
    {
        private static readonly gax::PathTemplate s_template = new gax::PathTemplate("root_b/{root_b}");

        /// <summary>
        /// Parses the given <c>RootB</c> resource name in string form into a new <see cref="RootBName"/> instance.
        /// </summary>
        /// <param name="rootBName">The <c>RootB</c> resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="RootBName"/> if successful.</returns>
        public static RootBName Parse(string rootBName)
        {
            gax::GaxPreconditions.CheckNotNull(rootBName, nameof(rootBName));
            gax::TemplatedResourceName resourceName = s_template.ParseName(rootBName);
            return new RootBName(resourceName[0]);
        }

        /// <summary>
        /// Tries to parse the given session resource name in string form into a new <see cref="RootBName"/> instance.
        /// </summary>
        /// <remarks>
        /// This method still throws <see cref="sys::ArgumentNullException"/> if <paramref name="rootBName"/> is <c>null</c>
        /// , as this would usually indicate a programming error rather than a data error.
        /// </remarks>
        /// <param name="rootBName">The <c>RootB</c> resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="RootBName"/>, or <c>null</c> if parsing fails.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string rootBName, out RootBName result)
        {
            gax::GaxPreconditions.CheckNotNull(rootBName, nameof(rootBName));
            if (s_template.TryParseName(rootBName, out gax::TemplatedResourceName resourceName))
            {
                result = new RootBName(resourceName[0]);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        /// <summary>Formats the IDs into the string representation of the <see cref="RootBName"/>.</summary>
        /// <param name="rootBId">The <c>RootB</c> ID. Must not be <c>null</c>.</param>
        /// <returns>The string representation of the <see cref="RootBName"/>.</returns>
        public static string Format(string rootBId) =>
            s_template.Expand(gax::GaxPreconditions.CheckNotNull(rootBId, nameof(rootBId)));

        /// <summary>
        /// Constructs a new instance of the <see cref="RootBName"/> resource name class from its component parts.
        /// </summary>
        /// <param name="rootBId">The <c>RootB</c> ID. Must not be <c>null</c>.</param>
        public RootBName(string rootBId) => RootBId = gax::GaxPreconditions.CheckNotNull(rootBId, nameof(rootBId));

        /// <summary>The <c>RootB</c> ID. Never <c>null</c>.</summary>
        public string RootBId { get; }

        /// <inheritdoc/>
        public gax::ResourceNameKind Kind => gax::ResourceNameKind.Simple;

        /// <inheritdoc/>
        public override string ToString() => s_template.Expand(RootBId);

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as RootBName);

        /// <inheritdoc/>
        public bool Equals(RootBName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(RootBName a, RootBName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(RootBName a, RootBName b) => !(a == b);
    }

    /// <summary>Resource name which will contain one of a choice of resource names.</summary>
    /// <remarks>
    /// This resource name will contain one of the following:
    /// <list type="bullet">
    /// <item><description>RootAName: A resource of type 'root_a'.</description></item>
    /// <item><description>RootBName: A resource of type 'root_b'.</description></item>
    /// </list>
    /// </remarks>
    public sealed partial class RootsNameOneOf : gax::IResourceName, sys::IEquatable<RootsNameOneOf>
    {
        /// <summary>The possible contents of <see cref="RootsNameOneOf"/>.</summary>
        public enum OneofType
        {
            /// <summary>A resource of an unknown type.</summary>
            Unknown = 0,

            /// <summary>A resource of type 'root_a'</summary>
            RootAName = 1,

            /// <summary>A resource of type 'root_b'</summary>
            RootBName = 2
        }

        /// <summary>
        /// Parses the given <c>Roots</c> resource name in string form into a new <see cref="RootsNameOneOf"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully the resource name must be one of the following:
        /// <list type="bullet">
        /// <item><description>RootAName: A resource of type 'root_a'.</description></item>
        /// <item><description>RootBName: A resource of type 'root_b'.</description></item>
        /// </list>
        /// Or an <see cref="gax::UnknownResourceName"/> if <paramref name="allowUnknown"/> is <c>true</c>
        /// </remarks>
        /// <param name="name">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnknown">
        /// If <c>true</c>, will successfully parse an unknown resource name into an
        /// <see cref="gax::UnknownResourceName"/>; otherwise will throw an<see cref="sys::ArgumentException"/> if an
        /// unknown resource name is given.
        /// </param>
        /// <returns>The parsed <see cref="RootsNameOneOf"/> if successful.</returns>
        public static RootsNameOneOf Parse(string name, bool allowUnknown)
        {
            if (TryParse(name, allowUnknown, out RootsNameOneOf result))
            {
                return result;
            }
            throw new sys::ArgumentException("Invalid name", nameof(name));
        }

        /// <summary>
        /// Tries to parse a resource name in string form into a new <see cref="RootsNameOneOf"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully the resource name must be one of the following:
        /// <list type="bullet">
        /// <item><description>RootAName: A resource of type 'root_a'.</description></item>
        /// <item><description>RootBName: A resource of type 'root_b'.</description></item>
        /// </list>
        /// Or an <see cref="gax::UnknownResourceName"/> if <paramref name="allowUnknown"/> is <c>true</c>
        /// </remarks>
        /// <param name="name">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnknown">
        /// If <c>true</c>, will successfully parse an unknown resource name into an
        /// <see cref="gax::UnknownResourceName"/>.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="RootsNameOneOf"/>, or <c>null</c> if parsing fails.
        /// </param>
        /// <returns><c>true</c> if the name was parsed succssfully; othrewise <c>false</c></returns>
        public static bool TryParse(string name, bool allowUnknown, out RootsNameOneOf result)
        {
            gax::GaxPreconditions.CheckNotNull(name, nameof(name));
            if (RootAName.TryParse(name, out RootAName rootAName))
            {
                result = new RootsNameOneOf(OneofType.RootAName, rootAName);
                return true;
            }
            if (RootBName.TryParse(name, out RootBName rootBName))
            {
                result = new RootsNameOneOf(OneofType.RootBName, rootBName);
                return true;
            }
            if (allowUnknown)
            {
                if (gax::UnknownResourceName.TryParse(name, out gax::UnknownResourceName unknownResourceName))
                {
                    result = new RootsNameOneOf(OneofType.Unknown, unknownResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        /// <summary>
        /// Constructs a new instance of <see cref="RootsNameOneOf"/> from the provided <see cref="RootAName"/>.
        /// </summary>
        /// <param name="rootAName">
        /// The <see cref="RootAName"/> to be contained within the returned <see cref="RootsNameOneOf"/>. Must not be
        /// <c>null</c>
        /// </param>
        /// <returns>A new <see cref="RootsNameOneOf"/>, containing <paramref name="rootAName"/>.</returns>
        public static RootsNameOneOf From(RootAName rootAName) => new RootsNameOneOf(OneofType.RootAName, rootAName);

        /// <summary>
        /// Constructs a new instance of <see cref="RootsNameOneOf"/> from the provided <see cref="RootBName"/>.
        /// </summary>
        /// <param name="rootBName">
        /// The <see cref="RootBName"/> to be contained within the returned <see cref="RootsNameOneOf"/>. Must not be
        /// <c>null</c>
        /// </param>
        /// <returns>A new <see cref="RootsNameOneOf"/>, containing <paramref name="rootBName"/>.</returns>
        public static RootsNameOneOf From(RootBName rootBName) => new RootsNameOneOf(OneofType.RootBName, rootBName);

        private static bool IsValid(OneofType type, gax::IResourceName name)
        {
            switch (type)
            {
                case OneofType.Unknown: return true;
                case OneofType.RootAName: return name is RootAName;
                case OneofType.RootBName: return name is RootBName;
                default: return false;
            }
        }

        /// <summary>
        /// Constructs a new instance of <see cref="RootsNameOneOf"/> with an expected type and a resource name.
        /// </summary>
        /// <param name="type">The expected type of this oneof.</param>
        /// <param name="name">The resource name represented by this oneof. Must not be <c>null</c>.</param>
        public RootsNameOneOf(OneofType type, gax::IResourceName name)
        {
            Type = gax::GaxPreconditions.CheckEnumValue<OneofType>(type, nameof(type));
            Name = gax::GaxPreconditions.CheckNotNull(name, nameof(name));
            if (!IsValid(type, name))
            {
                throw new sys::ArgumentException($"Mismatched OneofType '{type}' and resource name '{name}'");
            }
        }

        /// <summary>The <see cref="OneofType"/> of the Name contained in this instance.</summary>
        public OneofType Type { get; }

        /// <summary>The <see cref="gax::IResourceName"/> contained in this instance.</summary>
        public gax::IResourceName Name { get; }

        private T CheckAndReturn<T>(OneofType type)
        {
            if (Type != type)
            {
                throw new sys::InvalidOperationException($"Requested type {type}, but this one-of contains type {Type}");
            }
            return (T)Name;
        }

        /// <summary>Get the contained <see cref="gax::IResourceName"/> as <see cref="RootAName"/>.</summary>
        /// <remarks>
        /// An <see cref="sys::InvalidOperationException"/> will be thrown is this does not contain an instance of
        /// <see cref="RootAName"/>.
        /// </remarks>
        public RootAName RootAName => CheckAndReturn<RootAName>(OneofType.RootAName);

        /// <summary>Get the contained <see cref="gax::IResourceName"/> as <see cref="RootBName"/>.</summary>
        /// <remarks>
        /// An <see cref="sys::InvalidOperationException"/> will be thrown is this does not contain an instance of
        /// <see cref="RootBName"/>.
        /// </remarks>
        public RootBName RootBName => CheckAndReturn<RootBName>(OneofType.RootBName);

        /// <inheritdoc/>
        public gax::ResourceNameKind Kind => gax::ResourceNameKind.Oneof;

        /// <inheritdoc/>
        public override string ToString() => this.Name.ToString();

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as RootsNameOneOf);

        /// <inheritdoc/>
        public bool Equals(RootsNameOneOf other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(RootsNameOneOf a, RootsNameOneOf b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(RootsNameOneOf a, RootsNameOneOf b) => !(a == b);
    }

    public partial class ProjectRef
    {
        /// <summary>
        /// <see cref="ProjectName"/>-typed view over the <see cref="ProjectUserParent"/> resource name property.
        /// </summary>
        public ProjectName ProjectUserParentAsProjectName
        {
            get => string.IsNullOrEmpty(ProjectUserParent) ? null : ProjectName.Parse(ProjectUserParent);
            set => ProjectUserParent = value?.ToString() ?? "";
        }
    }

    public partial class MultiRootRef
    {
        /// <summary>
        /// <see cref="RootsNameOneOf"/>-typed view over the <see cref="MultiRootParent"/> resource name property.
        /// </summary>
        public RootsNameOneOf MultiRootParentAsRootsNameOneOf
        {
            get => string.IsNullOrEmpty(MultiRootParent) ? null : RootsNameOneOf.Parse(MultiRootParent, true);
            set => MultiRootParent = value?.ToString() ?? "";
        }
    }
}
