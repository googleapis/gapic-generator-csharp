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
using tr = Testing.ResourceNames;

namespace Testing.ResourceNames
{
    /// <summary>Resource name for the <c>SingleResource</c> resource.</summary>
    public sealed partial class SingleResourceName : gax::IResourceName, sys::IEquatable<SingleResourceName>
    {
        private static readonly gax::PathTemplate s_template = new gax::PathTemplate("items/{item_id}");

        /// <summary>
        /// Parses the given <c>SingleResource</c> resource name in string form into a new
        /// <see cref="SingleResourceName"/> instance.
        /// </summary>
        /// <param name="singleResourceName">
        /// The <c>SingleResource</c> resource name in string form. Must not be <c>null</c>.
        /// </param>
        /// <returns>The parsed <see cref="SingleResourceName"/> if successful.</returns>
        public static SingleResourceName Parse(string singleResourceName)
        {
            gax::GaxPreconditions.CheckNotNull(singleResourceName, nameof(singleResourceName));
            gax::TemplatedResourceName resourceName = s_template.ParseName(singleResourceName);
            return new SingleResourceName(resourceName[0]);
        }

        /// <summary>
        /// Tries to parse the given session resource name in string form into a new <see cref="SingleResourceName"/>
        /// instance.
        /// </summary>
        /// <remarks>
        /// This method still throws <see cref="sys::ArgumentNullException"/> if <paramref name="singleResourceName"/>
        /// is <c>null</c>, as this would usually indicate a programming error rather than a data error.
        /// </remarks>
        /// <param name="singleResourceName">
        /// The <c>SingleResource</c> resource name in string form. Must not be <c>null</c>.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="SingleResourceName"/>, or <c>null</c> if parsing fails.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string singleResourceName, out SingleResourceName result)
        {
            gax::GaxPreconditions.CheckNotNull(singleResourceName, nameof(singleResourceName));
            if (s_template.TryParseName(singleResourceName, out gax::TemplatedResourceName resourceName))
            {
                result = new SingleResourceName(resourceName[0]);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        /// <summary>Formats the IDs into the string representation of the <see cref="SingleResourceName"/>.</summary>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c>.</param>
        /// <returns>The string representation of the <see cref="SingleResourceName"/>.</returns>
        public static string Format(string itemId) =>
            s_template.Expand(gax::GaxPreconditions.CheckNotNull(itemId, nameof(itemId)));

        /// <summary>
        /// Constructs a new instance of the <see cref="SingleResourceName"/> resource name class from its component
        /// parts.
        /// </summary>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c>.</param>
        public SingleResourceName(string itemId) => ItemId = gax::GaxPreconditions.CheckNotNull(itemId, nameof(itemId));

        /// <summary>The <c>Item</c> ID. Never <c>null</c>.</summary>
        public string ItemId { get; }

        /// <inheritdoc/>
        public gax::ResourceNameKind Kind => gax::ResourceNameKind.Simple;

        /// <inheritdoc/>
        public override string ToString() => s_template.Expand(ItemId);

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as SingleResourceName);

        /// <inheritdoc/>
        public bool Equals(SingleResourceName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(SingleResourceName a, SingleResourceName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(SingleResourceName a, SingleResourceName b) => !(a == b);
    }

    /// <summary>Resource name for the <c>RootAMulti</c> resource.</summary>
    public sealed partial class RootAMultiName : gax::IResourceName, sys::IEquatable<RootAMultiName>
    {
        private static readonly gax::PathTemplate s_template = new gax::PathTemplate("roota/{root_a_id}/multi/{multi_id}");

        /// <summary>
        /// Parses the given <c>RootAMulti</c> resource name in string form into a new <see cref="RootAMultiName"/>
        /// instance.
        /// </summary>
        /// <param name="rootAMultiName">
        /// The <c>RootAMulti</c> resource name in string form. Must not be <c>null</c>.
        /// </param>
        /// <returns>The parsed <see cref="RootAMultiName"/> if successful.</returns>
        public static RootAMultiName Parse(string rootAMultiName)
        {
            gax::GaxPreconditions.CheckNotNull(rootAMultiName, nameof(rootAMultiName));
            gax::TemplatedResourceName resourceName = s_template.ParseName(rootAMultiName);
            return new RootAMultiName(resourceName[0], resourceName[1]);
        }

        /// <summary>
        /// Tries to parse the given session resource name in string form into a new <see cref="RootAMultiName"/>
        /// instance.
        /// </summary>
        /// <remarks>
        /// This method still throws <see cref="sys::ArgumentNullException"/> if <paramref name="rootAMultiName"/> is
        /// <c>null</c>, as this would usually indicate a programming error rather than a data error.
        /// </remarks>
        /// <param name="rootAMultiName">
        /// The <c>RootAMulti</c> resource name in string form. Must not be <c>null</c>.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="RootAMultiName"/>, or <c>null</c> if parsing fails.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string rootAMultiName, out RootAMultiName result)
        {
            gax::GaxPreconditions.CheckNotNull(rootAMultiName, nameof(rootAMultiName));
            if (s_template.TryParseName(rootAMultiName, out gax::TemplatedResourceName resourceName))
            {
                result = new RootAMultiName(resourceName[0], resourceName[1]);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        /// <summary>Formats the IDs into the string representation of the <see cref="RootAMultiName"/>.</summary>
        /// <param name="rootAId">The <c>RootA</c> ID. Must not be <c>null</c>.</param>
        /// <param name="multiId">The <c>Multi</c> ID. Must not be <c>null</c>.</param>
        /// <returns>The string representation of the <see cref="RootAMultiName"/>.</returns>
        public static string Format(string rootAId, string multiId) =>
            s_template.Expand(gax::GaxPreconditions.CheckNotNull(rootAId, nameof(rootAId)), gax::GaxPreconditions.CheckNotNull(multiId, nameof(multiId)));

        /// <summary>
        /// Constructs a new instance of the <see cref="RootAMultiName"/> resource name class from its component parts.
        /// </summary>
        /// <param name="rootAId">The <c>RootA</c> ID. Must not be <c>null</c>.</param>
        /// <param name="multiId">The <c>Multi</c> ID. Must not be <c>null</c>.</param>
        public RootAMultiName(string rootAId, string multiId)
        {
            RootAId = gax::GaxPreconditions.CheckNotNull(rootAId, nameof(rootAId));
            MultiId = gax::GaxPreconditions.CheckNotNull(multiId, nameof(multiId));
        }

        /// <summary>The <c>RootA</c> ID. Never <c>null</c>.</summary>
        public string RootAId { get; }

        /// <summary>The <c>Multi</c> ID. Never <c>null</c>.</summary>
        public string MultiId { get; }

        /// <inheritdoc/>
        public gax::ResourceNameKind Kind => gax::ResourceNameKind.Simple;

        /// <inheritdoc/>
        public override string ToString() => s_template.Expand(RootAId, MultiId);

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as RootAMultiName);

        /// <inheritdoc/>
        public bool Equals(RootAMultiName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(RootAMultiName a, RootAMultiName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(RootAMultiName a, RootAMultiName b) => !(a == b);
    }

    /// <summary>Resource name for the <c>RootBMulti</c> resource.</summary>
    public sealed partial class RootBMultiName : gax::IResourceName, sys::IEquatable<RootBMultiName>
    {
        private static readonly gax::PathTemplate s_template = new gax::PathTemplate("rootb/{root_b_id}/multi/{multi_id}");

        /// <summary>
        /// Parses the given <c>RootBMulti</c> resource name in string form into a new <see cref="RootBMultiName"/>
        /// instance.
        /// </summary>
        /// <param name="rootBMultiName">
        /// The <c>RootBMulti</c> resource name in string form. Must not be <c>null</c>.
        /// </param>
        /// <returns>The parsed <see cref="RootBMultiName"/> if successful.</returns>
        public static RootBMultiName Parse(string rootBMultiName)
        {
            gax::GaxPreconditions.CheckNotNull(rootBMultiName, nameof(rootBMultiName));
            gax::TemplatedResourceName resourceName = s_template.ParseName(rootBMultiName);
            return new RootBMultiName(resourceName[0], resourceName[1]);
        }

        /// <summary>
        /// Tries to parse the given session resource name in string form into a new <see cref="RootBMultiName"/>
        /// instance.
        /// </summary>
        /// <remarks>
        /// This method still throws <see cref="sys::ArgumentNullException"/> if <paramref name="rootBMultiName"/> is
        /// <c>null</c>, as this would usually indicate a programming error rather than a data error.
        /// </remarks>
        /// <param name="rootBMultiName">
        /// The <c>RootBMulti</c> resource name in string form. Must not be <c>null</c>.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="RootBMultiName"/>, or <c>null</c> if parsing fails.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string rootBMultiName, out RootBMultiName result)
        {
            gax::GaxPreconditions.CheckNotNull(rootBMultiName, nameof(rootBMultiName));
            if (s_template.TryParseName(rootBMultiName, out gax::TemplatedResourceName resourceName))
            {
                result = new RootBMultiName(resourceName[0], resourceName[1]);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        /// <summary>Formats the IDs into the string representation of the <see cref="RootBMultiName"/>.</summary>
        /// <param name="rootBId">The <c>RootB</c> ID. Must not be <c>null</c>.</param>
        /// <param name="multiId">The <c>Multi</c> ID. Must not be <c>null</c>.</param>
        /// <returns>The string representation of the <see cref="RootBMultiName"/>.</returns>
        public static string Format(string rootBId, string multiId) =>
            s_template.Expand(gax::GaxPreconditions.CheckNotNull(rootBId, nameof(rootBId)), gax::GaxPreconditions.CheckNotNull(multiId, nameof(multiId)));

        /// <summary>
        /// Constructs a new instance of the <see cref="RootBMultiName"/> resource name class from its component parts.
        /// </summary>
        /// <param name="rootBId">The <c>RootB</c> ID. Must not be <c>null</c>.</param>
        /// <param name="multiId">The <c>Multi</c> ID. Must not be <c>null</c>.</param>
        public RootBMultiName(string rootBId, string multiId)
        {
            RootBId = gax::GaxPreconditions.CheckNotNull(rootBId, nameof(rootBId));
            MultiId = gax::GaxPreconditions.CheckNotNull(multiId, nameof(multiId));
        }

        /// <summary>The <c>RootB</c> ID. Never <c>null</c>.</summary>
        public string RootBId { get; }

        /// <summary>The <c>Multi</c> ID. Never <c>null</c>.</summary>
        public string MultiId { get; }

        /// <inheritdoc/>
        public gax::ResourceNameKind Kind => gax::ResourceNameKind.Simple;

        /// <inheritdoc/>
        public override string ToString() => s_template.Expand(RootBId, MultiId);

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as RootBMultiName);

        /// <inheritdoc/>
        public bool Equals(RootBMultiName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(RootBMultiName a, RootBMultiName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(RootBMultiName a, RootBMultiName b) => !(a == b);
    }

    /// <summary>Resource name which will contain one of a choice of resource names.</summary>
    /// <remarks>
    /// This resource name will contain one of the following:
    /// <list type="bullet">
    /// <item><description>RootAMultiName: A resource of type 'root_a'.</description></item>
    /// <item><description>RootBMultiName: A resource of type 'root_b'.</description></item>
    /// </list>
    /// </remarks>
    public sealed partial class MultiResourceNameOneOf : gax::IResourceName, sys::IEquatable<MultiResourceNameOneOf>
    {
        /// <summary>The possible contents of <see cref="MultiResourceNameOneOf"/>.</summary>
        public enum OneofType
        {
            /// <summary>A resource of an unknown type.</summary>
            Unknown = 0,

            /// <summary>A resource of type 'root_a'</summary>
            RootAMultiName = 1,

            /// <summary>A resource of type 'root_b'</summary>
            RootBMultiName = 2
        }

        /// <summary>
        /// Parses the given <c>MultiResource</c> resource name in string form into a new
        /// <see cref="MultiResourceNameOneOf"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully the resource name must be one of the following:
        /// <list type="bullet">
        /// <item><description>RootAMultiName: A resource of type 'root_a'.</description></item>
        /// <item><description>RootBMultiName: A resource of type 'root_b'.</description></item>
        /// </list>
        /// Or an <see cref="gax::UnknownResourceName"/> if <paramref name="allowUnknown"/> is <c>true</c>
        /// </remarks>
        /// <param name="name">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnknown">
        /// If <c>true</c>, will successfully parse an unknown resource name into an
        /// <see cref="gax::UnknownResourceName"/>; otherwise will throw an<see cref="sys::ArgumentException"/> if an
        /// unknown resource name is given.
        /// </param>
        /// <returns>The parsed <see cref="MultiResourceNameOneOf"/> if successful.</returns>
        public static MultiResourceNameOneOf Parse(string name, bool allowUnknown)
        {
            if (TryParse(name, allowUnknown, out MultiResourceNameOneOf result))
            {
                return result;
            }
            throw new sys::ArgumentException("Invalid name", nameof(name));
        }

        /// <summary>
        /// Tries to parse a resource name in string form into a new <see cref="MultiResourceNameOneOf"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully the resource name must be one of the following:
        /// <list type="bullet">
        /// <item><description>RootAMultiName: A resource of type 'root_a'.</description></item>
        /// <item><description>RootBMultiName: A resource of type 'root_b'.</description></item>
        /// </list>
        /// Or an <see cref="gax::UnknownResourceName"/> if <paramref name="allowUnknown"/> is <c>true</c>
        /// </remarks>
        /// <param name="name">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnknown">
        /// If <c>true</c>, will successfully parse an unknown resource name into an
        /// <see cref="gax::UnknownResourceName"/>.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="MultiResourceNameOneOf"/>, or <c>null</c> if parsing fails.
        /// </param>
        /// <returns><c>true</c> if the name was parsed succssfully; othrewise <c>false</c></returns>
        public static bool TryParse(string name, bool allowUnknown, out MultiResourceNameOneOf result)
        {
            gax::GaxPreconditions.CheckNotNull(name, nameof(name));
            if (RootAMultiName.TryParse(name, out RootAMultiName rootAMultiName))
            {
                result = new MultiResourceNameOneOf(OneofType.RootAMultiName, rootAMultiName);
                return true;
            }
            if (RootBMultiName.TryParse(name, out RootBMultiName rootBMultiName))
            {
                result = new MultiResourceNameOneOf(OneofType.RootBMultiName, rootBMultiName);
                return true;
            }
            if (allowUnknown)
            {
                if (gax::UnknownResourceName.TryParse(name, out gax::UnknownResourceName unknownResourceName))
                {
                    result = new MultiResourceNameOneOf(OneofType.Unknown, unknownResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        /// <summary>
        /// Constructs a new instance of <see cref="MultiResourceNameOneOf"/> from the provided
        /// <see cref="RootAMultiName"/>.
        /// </summary>
        /// <param name="rootAMultiName">
        /// The <see cref="RootAMultiName"/> to be contained within the returned <see cref="MultiResourceNameOneOf"/>.
        /// Must not be <c>null</c>
        /// </param>
        /// <returns>A new <see cref="MultiResourceNameOneOf"/>, containing <paramref name="rootAMultiName"/>.</returns>
        public static MultiResourceNameOneOf From(RootAMultiName rootAMultiName) =>
            new MultiResourceNameOneOf(OneofType.RootAMultiName, rootAMultiName);

        /// <summary>
        /// Constructs a new instance of <see cref="MultiResourceNameOneOf"/> from the provided
        /// <see cref="RootBMultiName"/>.
        /// </summary>
        /// <param name="rootBMultiName">
        /// The <see cref="RootBMultiName"/> to be contained within the returned <see cref="MultiResourceNameOneOf"/>.
        /// Must not be <c>null</c>
        /// </param>
        /// <returns>A new <see cref="MultiResourceNameOneOf"/>, containing <paramref name="rootBMultiName"/>.</returns>
        public static MultiResourceNameOneOf From(RootBMultiName rootBMultiName) =>
            new MultiResourceNameOneOf(OneofType.RootBMultiName, rootBMultiName);

        private static bool IsValid(OneofType type, gax::IResourceName name)
        {
            switch (type)
            {
                case OneofType.Unknown: return true;
                case OneofType.RootAMultiName: return name is RootAMultiName;
                case OneofType.RootBMultiName: return name is RootBMultiName;
                default: return false;
            }
        }

        public MultiResourceNameOneOf(OneofType type, gax::IResourceName name)
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

        /// <summary>Get the contained <see cref="gax::IResourceName"/> as <see cref="RootAMultiName"/>.</summary>
        /// <remarks>
        /// An <see cref="sys::InvalidOperationException"/> will be thrown is this does not contain an instance of
        /// <see cref="RootAMultiName"/>.
        /// </remarks>
        public RootAMultiName RootAMultiName => CheckAndReturn<RootAMultiName>(OneofType.RootAMultiName);

        /// <summary>Get the contained <see cref="gax::IResourceName"/> as <see cref="RootBMultiName"/>.</summary>
        /// <remarks>
        /// An <see cref="sys::InvalidOperationException"/> will be thrown is this does not contain an instance of
        /// <see cref="RootBMultiName"/>.
        /// </remarks>
        public RootBMultiName RootBMultiName => CheckAndReturn<RootBMultiName>(OneofType.RootBMultiName);

        /// <inheritdoc/>
        public gax::ResourceNameKind Kind => gax::ResourceNameKind.Oneof;

        /// <inheritdoc/>
        public override string ToString() => this.Name.ToString();

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as MultiResourceNameOneOf);

        /// <inheritdoc/>
        public bool Equals(MultiResourceNameOneOf other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(MultiResourceNameOneOf a, MultiResourceNameOneOf b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(MultiResourceNameOneOf a, MultiResourceNameOneOf b) => !(a == b);
    }

    /// <summary>Resource name for the <c>RootAFutureMulti</c> resource.</summary>
    public sealed partial class RootAFutureMultiName : gax::IResourceName, sys::IEquatable<RootAFutureMultiName>
    {
        private static readonly gax::PathTemplate s_template = new gax::PathTemplate("root/{root_a_id}/futuremulti/{future_multi_id}");

        /// <summary>
        /// Parses the given <c>RootAFutureMulti</c> resource name in string form into a new
        /// <see cref="RootAFutureMultiName"/> instance.
        /// </summary>
        /// <param name="rootAFutureMultiName">
        /// The <c>RootAFutureMulti</c> resource name in string form. Must not be <c>null</c>.
        /// </param>
        /// <returns>The parsed <see cref="RootAFutureMultiName"/> if successful.</returns>
        public static RootAFutureMultiName Parse(string rootAFutureMultiName)
        {
            gax::GaxPreconditions.CheckNotNull(rootAFutureMultiName, nameof(rootAFutureMultiName));
            gax::TemplatedResourceName resourceName = s_template.ParseName(rootAFutureMultiName);
            return new RootAFutureMultiName(resourceName[0], resourceName[1]);
        }

        /// <summary>
        /// Tries to parse the given session resource name in string form into a new <see cref="RootAFutureMultiName"/>
        /// instance.
        /// </summary>
        /// <remarks>
        /// This method still throws <see cref="sys::ArgumentNullException"/> if <paramref name="rootAFutureMultiName"/>
        /// is <c>null</c>, as this would usually indicate a programming error rather than a data error.
        /// </remarks>
        /// <param name="rootAFutureMultiName">
        /// The <c>RootAFutureMulti</c> resource name in string form. Must not be <c>null</c>.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="RootAFutureMultiName"/>, or <c>null</c> if parsing fails.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string rootAFutureMultiName, out RootAFutureMultiName result)
        {
            gax::GaxPreconditions.CheckNotNull(rootAFutureMultiName, nameof(rootAFutureMultiName));
            if (s_template.TryParseName(rootAFutureMultiName, out gax::TemplatedResourceName resourceName))
            {
                result = new RootAFutureMultiName(resourceName[0], resourceName[1]);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        /// <summary>Formats the IDs into the string representation of the <see cref="RootAFutureMultiName"/>.</summary>
        /// <param name="rootAId">The <c>RootA</c> ID. Must not be <c>null</c>.</param>
        /// <param name="futureMultiId">The <c>FutureMulti</c> ID. Must not be <c>null</c>.</param>
        /// <returns>The string representation of the <see cref="RootAFutureMultiName"/>.</returns>
        public static string Format(string rootAId, string futureMultiId) =>
            s_template.Expand(gax::GaxPreconditions.CheckNotNull(rootAId, nameof(rootAId)), gax::GaxPreconditions.CheckNotNull(futureMultiId, nameof(futureMultiId)));

        /// <summary>
        /// Constructs a new instance of the <see cref="RootAFutureMultiName"/> resource name class from its component
        /// parts.
        /// </summary>
        /// <param name="rootAId">The <c>RootA</c> ID. Must not be <c>null</c>.</param>
        /// <param name="futureMultiId">The <c>FutureMulti</c> ID. Must not be <c>null</c>.</param>
        public RootAFutureMultiName(string rootAId, string futureMultiId)
        {
            RootAId = gax::GaxPreconditions.CheckNotNull(rootAId, nameof(rootAId));
            FutureMultiId = gax::GaxPreconditions.CheckNotNull(futureMultiId, nameof(futureMultiId));
        }

        /// <summary>The <c>RootA</c> ID. Never <c>null</c>.</summary>
        public string RootAId { get; }

        /// <summary>The <c>FutureMulti</c> ID. Never <c>null</c>.</summary>
        public string FutureMultiId { get; }

        /// <inheritdoc/>
        public gax::ResourceNameKind Kind => gax::ResourceNameKind.Simple;

        /// <inheritdoc/>
        public override string ToString() => s_template.Expand(RootAId, FutureMultiId);

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as RootAFutureMultiName);

        /// <inheritdoc/>
        public bool Equals(RootAFutureMultiName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(RootAFutureMultiName a, RootAFutureMultiName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(RootAFutureMultiName a, RootAFutureMultiName b) => !(a == b);
    }

    /// <summary>Resource name which will contain one of a choice of resource names.</summary>
    /// <remarks>
    /// This resource name will contain one of the following:
    /// <list type="bullet">
    /// <item><description>RootAFutureMultiName: A resource of type 'root_a'.</description></item>
    /// </list>
    /// </remarks>
    public sealed partial class FutureMultiResourceNameOneOf : gax::IResourceName, sys::IEquatable<FutureMultiResourceNameOneOf>
    {
        /// <summary>The possible contents of <see cref="FutureMultiResourceNameOneOf"/>.</summary>
        public enum OneofType
        {
            /// <summary>A resource of an unknown type.</summary>
            Unknown = 0,

            /// <summary>A resource of type 'root_a'</summary>
            RootAFutureMultiName = 1
        }

        /// <summary>
        /// Parses the given <c>FutureMultiResource</c> resource name in string form into a new
        /// <see cref="FutureMultiResourceNameOneOf"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully the resource name must be one of the following:
        /// <list type="bullet">
        /// <item><description>RootAFutureMultiName: A resource of type 'root_a'.</description></item>
        /// </list>
        /// Or an <see cref="gax::UnknownResourceName"/> if <paramref name="allowUnknown"/> is <c>true</c>
        /// </remarks>
        /// <param name="name">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnknown">
        /// If <c>true</c>, will successfully parse an unknown resource name into an
        /// <see cref="gax::UnknownResourceName"/>; otherwise will throw an<see cref="sys::ArgumentException"/> if an
        /// unknown resource name is given.
        /// </param>
        /// <returns>The parsed <see cref="FutureMultiResourceNameOneOf"/> if successful.</returns>
        public static FutureMultiResourceNameOneOf Parse(string name, bool allowUnknown)
        {
            if (TryParse(name, allowUnknown, out FutureMultiResourceNameOneOf result))
            {
                return result;
            }
            throw new sys::ArgumentException("Invalid name", nameof(name));
        }

        /// <summary>
        /// Tries to parse a resource name in string form into a new <see cref="FutureMultiResourceNameOneOf"/>
        /// instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully the resource name must be one of the following:
        /// <list type="bullet">
        /// <item><description>RootAFutureMultiName: A resource of type 'root_a'.</description></item>
        /// </list>
        /// Or an <see cref="gax::UnknownResourceName"/> if <paramref name="allowUnknown"/> is <c>true</c>
        /// </remarks>
        /// <param name="name">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnknown">
        /// If <c>true</c>, will successfully parse an unknown resource name into an
        /// <see cref="gax::UnknownResourceName"/>.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="FutureMultiResourceNameOneOf"/>, or <c>null</c> if parsing
        /// fails.
        /// </param>
        /// <returns><c>true</c> if the name was parsed succssfully; othrewise <c>false</c></returns>
        public static bool TryParse(string name, bool allowUnknown, out FutureMultiResourceNameOneOf result)
        {
            gax::GaxPreconditions.CheckNotNull(name, nameof(name));
            if (RootAFutureMultiName.TryParse(name, out RootAFutureMultiName rootAFutureMultiName))
            {
                result = new FutureMultiResourceNameOneOf(OneofType.RootAFutureMultiName, rootAFutureMultiName);
                return true;
            }
            if (allowUnknown)
            {
                if (gax::UnknownResourceName.TryParse(name, out gax::UnknownResourceName unknownResourceName))
                {
                    result = new FutureMultiResourceNameOneOf(OneofType.Unknown, unknownResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        /// <summary>
        /// Constructs a new instance of <see cref="FutureMultiResourceNameOneOf"/> from the provided
        /// <see cref="RootAFutureMultiName"/>.
        /// </summary>
        /// <param name="rootAFutureMultiName">
        /// The <see cref="RootAFutureMultiName"/> to be contained within the returned
        /// <see cref="FutureMultiResourceNameOneOf"/>. Must not be <c>null</c>
        /// </param>
        /// <returns>
        /// A new <see cref="FutureMultiResourceNameOneOf"/>, containing <paramref name="rootAFutureMultiName"/>.
        /// </returns>
        public static FutureMultiResourceNameOneOf From(RootAFutureMultiName rootAFutureMultiName) =>
            new FutureMultiResourceNameOneOf(OneofType.RootAFutureMultiName, rootAFutureMultiName);

        private static bool IsValid(OneofType type, gax::IResourceName name)
        {
            switch (type)
            {
                case OneofType.Unknown: return true;
                case OneofType.RootAFutureMultiName: return name is RootAFutureMultiName;
                default: return false;
            }
        }

        public FutureMultiResourceNameOneOf(OneofType type, gax::IResourceName name)
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

        /// <summary>Get the contained <see cref="gax::IResourceName"/> as <see cref="RootAFutureMultiName"/>.</summary>
        /// <remarks>
        /// An <see cref="sys::InvalidOperationException"/> will be thrown is this does not contain an instance of
        /// <see cref="RootAFutureMultiName"/>.
        /// </remarks>
        public RootAFutureMultiName RootAFutureMultiName => CheckAndReturn<RootAFutureMultiName>(OneofType.RootAFutureMultiName);

        /// <inheritdoc/>
        public gax::ResourceNameKind Kind => gax::ResourceNameKind.Oneof;

        /// <inheritdoc/>
        public override string ToString() => this.Name.ToString();

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as FutureMultiResourceNameOneOf);

        /// <inheritdoc/>
        public bool Equals(FutureMultiResourceNameOneOf other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(FutureMultiResourceNameOneOf a, FutureMultiResourceNameOneOf b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(FutureMultiResourceNameOneOf a, FutureMultiResourceNameOneOf b) => !(a == b);
    }

    /// <summary>Resource name for the <c>OriginallySingleResource</c> resource.</summary>
    public sealed partial class OriginallySingleResourceName : gax::IResourceName, sys::IEquatable<OriginallySingleResourceName>
    {
        private static readonly gax::PathTemplate s_template = new gax::PathTemplate("roota/{root_a_id}/originallysingle/{originally_single_multi_id}");

        /// <summary>
        /// Parses the given <c>OriginallySingleResource</c> resource name in string form into a new
        /// <see cref="OriginallySingleResourceName"/> instance.
        /// </summary>
        /// <param name="originallySingleResourceName">
        /// The <c>OriginallySingleResource</c> resource name in string form. Must not be <c>null</c>.
        /// </param>
        /// <returns>The parsed <see cref="OriginallySingleResourceName"/> if successful.</returns>
        public static OriginallySingleResourceName Parse(string originallySingleResourceName)
        {
            gax::GaxPreconditions.CheckNotNull(originallySingleResourceName, nameof(originallySingleResourceName));
            gax::TemplatedResourceName resourceName = s_template.ParseName(originallySingleResourceName);
            return new OriginallySingleResourceName(resourceName[0], resourceName[1]);
        }

        /// <summary>
        /// Tries to parse the given session resource name in string form into a new
        /// <see cref="OriginallySingleResourceName"/> instance.
        /// </summary>
        /// <remarks>
        /// This method still throws <see cref="sys::ArgumentNullException"/> if
        /// <paramref name="originallySingleResourceName"/> is <c>null</c>, as this would usually indicate a programming
        /// error rather than a data error.
        /// </remarks>
        /// <param name="originallySingleResourceName">
        /// The <c>OriginallySingleResource</c> resource name in string form. Must not be <c>null</c>.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="OriginallySingleResourceName"/>, or <c>null</c> if parsing
        /// fails.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string originallySingleResourceName, out OriginallySingleResourceName result)
        {
            gax::GaxPreconditions.CheckNotNull(originallySingleResourceName, nameof(originallySingleResourceName));
            if (s_template.TryParseName(originallySingleResourceName, out gax::TemplatedResourceName resourceName))
            {
                result = new OriginallySingleResourceName(resourceName[0], resourceName[1]);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        /// <summary>
        /// Formats the IDs into the string representation of the <see cref="OriginallySingleResourceName"/>.
        /// </summary>
        /// <param name="rootAId">The <c>RootA</c> ID. Must not be <c>null</c>.</param>
        /// <param name="originallySingleMultiId">The <c>OriginallySingleMulti</c> ID. Must not be <c>null</c>.</param>
        /// <returns>The string representation of the <see cref="OriginallySingleResourceName"/>.</returns>
        public static string Format(string rootAId, string originallySingleMultiId) =>
            s_template.Expand(gax::GaxPreconditions.CheckNotNull(rootAId, nameof(rootAId)), gax::GaxPreconditions.CheckNotNull(originallySingleMultiId, nameof(originallySingleMultiId)));

        /// <summary>
        /// Constructs a new instance of the <see cref="OriginallySingleResourceName"/> resource name class from its
        /// component parts.
        /// </summary>
        /// <param name="rootAId">The <c>RootA</c> ID. Must not be <c>null</c>.</param>
        /// <param name="originallySingleMultiId">The <c>OriginallySingleMulti</c> ID. Must not be <c>null</c>.</param>
        public OriginallySingleResourceName(string rootAId, string originallySingleMultiId)
        {
            RootAId = gax::GaxPreconditions.CheckNotNull(rootAId, nameof(rootAId));
            OriginallySingleMultiId = gax::GaxPreconditions.CheckNotNull(originallySingleMultiId, nameof(originallySingleMultiId));
        }

        /// <summary>The <c>RootA</c> ID. Never <c>null</c>.</summary>
        public string RootAId { get; }

        /// <summary>The <c>OriginallySingleMulti</c> ID. Never <c>null</c>.</summary>
        public string OriginallySingleMultiId { get; }

        /// <inheritdoc/>
        public gax::ResourceNameKind Kind => gax::ResourceNameKind.Simple;

        /// <inheritdoc/>
        public override string ToString() => s_template.Expand(RootAId, OriginallySingleMultiId);

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as OriginallySingleResourceName);

        /// <inheritdoc/>
        public bool Equals(OriginallySingleResourceName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(OriginallySingleResourceName a, OriginallySingleResourceName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(OriginallySingleResourceName a, OriginallySingleResourceName b) => !(a == b);
    }

    /// <summary>Resource name for the <c>RootBOriginallySingleMulti</c> resource.</summary>
    public sealed partial class RootBOriginallySingleMultiName : gax::IResourceName, sys::IEquatable<RootBOriginallySingleMultiName>
    {
        private static readonly gax::PathTemplate s_template = new gax::PathTemplate("rootb/{root_b_id}/originallysingle/{originally_single_multi_id}");

        /// <summary>
        /// Parses the given <c>RootBOriginallySingleMulti</c> resource name in string form into a new
        /// <see cref="RootBOriginallySingleMultiName"/> instance.
        /// </summary>
        /// <param name="rootBOriginallySingleMultiName">
        /// The <c>RootBOriginallySingleMulti</c> resource name in string form. Must not be <c>null</c>.
        /// </param>
        /// <returns>The parsed <see cref="RootBOriginallySingleMultiName"/> if successful.</returns>
        public static RootBOriginallySingleMultiName Parse(string rootBOriginallySingleMultiName)
        {
            gax::GaxPreconditions.CheckNotNull(rootBOriginallySingleMultiName, nameof(rootBOriginallySingleMultiName));
            gax::TemplatedResourceName resourceName = s_template.ParseName(rootBOriginallySingleMultiName);
            return new RootBOriginallySingleMultiName(resourceName[0], resourceName[1]);
        }

        /// <summary>
        /// Tries to parse the given session resource name in string form into a new
        /// <see cref="RootBOriginallySingleMultiName"/> instance.
        /// </summary>
        /// <remarks>
        /// This method still throws <see cref="sys::ArgumentNullException"/> if
        /// <paramref name="rootBOriginallySingleMultiName"/> is <c>null</c>, as this would usually indicate a
        /// programming error rather than a data error.
        /// </remarks>
        /// <param name="rootBOriginallySingleMultiName">
        /// The <c>RootBOriginallySingleMulti</c> resource name in string form. Must not be <c>null</c>.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="RootBOriginallySingleMultiName"/>, or <c>null</c> if parsing
        /// fails.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string rootBOriginallySingleMultiName, out RootBOriginallySingleMultiName result)
        {
            gax::GaxPreconditions.CheckNotNull(rootBOriginallySingleMultiName, nameof(rootBOriginallySingleMultiName));
            if (s_template.TryParseName(rootBOriginallySingleMultiName, out gax::TemplatedResourceName resourceName))
            {
                result = new RootBOriginallySingleMultiName(resourceName[0], resourceName[1]);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        /// <summary>
        /// Formats the IDs into the string representation of the <see cref="RootBOriginallySingleMultiName"/>.
        /// </summary>
        /// <param name="rootBId">The <c>RootB</c> ID. Must not be <c>null</c>.</param>
        /// <param name="originallySingleMultiId">The <c>OriginallySingleMulti</c> ID. Must not be <c>null</c>.</param>
        /// <returns>The string representation of the <see cref="RootBOriginallySingleMultiName"/>.</returns>
        public static string Format(string rootBId, string originallySingleMultiId) =>
            s_template.Expand(gax::GaxPreconditions.CheckNotNull(rootBId, nameof(rootBId)), gax::GaxPreconditions.CheckNotNull(originallySingleMultiId, nameof(originallySingleMultiId)));

        /// <summary>
        /// Constructs a new instance of the <see cref="RootBOriginallySingleMultiName"/> resource name class from its
        /// component parts.
        /// </summary>
        /// <param name="rootBId">The <c>RootB</c> ID. Must not be <c>null</c>.</param>
        /// <param name="originallySingleMultiId">The <c>OriginallySingleMulti</c> ID. Must not be <c>null</c>.</param>
        public RootBOriginallySingleMultiName(string rootBId, string originallySingleMultiId)
        {
            RootBId = gax::GaxPreconditions.CheckNotNull(rootBId, nameof(rootBId));
            OriginallySingleMultiId = gax::GaxPreconditions.CheckNotNull(originallySingleMultiId, nameof(originallySingleMultiId));
        }

        /// <summary>The <c>RootB</c> ID. Never <c>null</c>.</summary>
        public string RootBId { get; }

        /// <summary>The <c>OriginallySingleMulti</c> ID. Never <c>null</c>.</summary>
        public string OriginallySingleMultiId { get; }

        /// <inheritdoc/>
        public gax::ResourceNameKind Kind => gax::ResourceNameKind.Simple;

        /// <inheritdoc/>
        public override string ToString() => s_template.Expand(RootBId, OriginallySingleMultiId);

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as RootBOriginallySingleMultiName);

        /// <inheritdoc/>
        public bool Equals(RootBOriginallySingleMultiName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(RootBOriginallySingleMultiName a, RootBOriginallySingleMultiName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(RootBOriginallySingleMultiName a, RootBOriginallySingleMultiName b) => !(a == b);
    }

    /// <summary>Resource name which will contain one of a choice of resource names.</summary>
    /// <remarks>
    /// This resource name will contain one of the following:
    /// <list type="bullet">
    /// <item><description>OriginallySingleResourceName: A resource of type 'root_a'.</description></item>
    /// <item><description>RootBOriginallySingleMultiName: A resource of type 'root_b'.</description></item>
    /// </list>
    /// </remarks>
    public sealed partial class OriginallySingleResourceNameOneOf : gax::IResourceName, sys::IEquatable<OriginallySingleResourceNameOneOf>
    {
        /// <summary>The possible contents of <see cref="OriginallySingleResourceNameOneOf"/>.</summary>
        public enum OneofType
        {
            /// <summary>A resource of an unknown type.</summary>
            Unknown = 0,

            /// <summary>A resource of type 'root_a'</summary>
            OriginallySingleResourceName = 1,

            /// <summary>A resource of type 'root_b'</summary>
            RootBOriginallySingleMultiName = 2
        }

        /// <summary>
        /// Parses the given <c>OriginallySingleResource</c> resource name in string form into a new
        /// <see cref="OriginallySingleResourceNameOneOf"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully the resource name must be one of the following:
        /// <list type="bullet">
        /// <item><description>OriginallySingleResourceName: A resource of type 'root_a'.</description></item>
        /// <item><description>RootBOriginallySingleMultiName: A resource of type 'root_b'.</description></item>
        /// </list>
        /// Or an <see cref="gax::UnknownResourceName"/> if <paramref name="allowUnknown"/> is <c>true</c>
        /// </remarks>
        /// <param name="name">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnknown">
        /// If <c>true</c>, will successfully parse an unknown resource name into an
        /// <see cref="gax::UnknownResourceName"/>; otherwise will throw an<see cref="sys::ArgumentException"/> if an
        /// unknown resource name is given.
        /// </param>
        /// <returns>The parsed <see cref="OriginallySingleResourceNameOneOf"/> if successful.</returns>
        public static OriginallySingleResourceNameOneOf Parse(string name, bool allowUnknown)
        {
            if (TryParse(name, allowUnknown, out OriginallySingleResourceNameOneOf result))
            {
                return result;
            }
            throw new sys::ArgumentException("Invalid name", nameof(name));
        }

        /// <summary>
        /// Tries to parse a resource name in string form into a new <see cref="OriginallySingleResourceNameOneOf"/>
        /// instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully the resource name must be one of the following:
        /// <list type="bullet">
        /// <item><description>OriginallySingleResourceName: A resource of type 'root_a'.</description></item>
        /// <item><description>RootBOriginallySingleMultiName: A resource of type 'root_b'.</description></item>
        /// </list>
        /// Or an <see cref="gax::UnknownResourceName"/> if <paramref name="allowUnknown"/> is <c>true</c>
        /// </remarks>
        /// <param name="name">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnknown">
        /// If <c>true</c>, will successfully parse an unknown resource name into an
        /// <see cref="gax::UnknownResourceName"/>.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="OriginallySingleResourceNameOneOf"/>, or <c>null</c> if
        /// parsing fails.
        /// </param>
        /// <returns><c>true</c> if the name was parsed succssfully; othrewise <c>false</c></returns>
        public static bool TryParse(string name, bool allowUnknown, out OriginallySingleResourceNameOneOf result)
        {
            gax::GaxPreconditions.CheckNotNull(name, nameof(name));
            if (OriginallySingleResourceName.TryParse(name, out OriginallySingleResourceName originallySingleResourceName))
            {
                result = new OriginallySingleResourceNameOneOf(OneofType.OriginallySingleResourceName, originallySingleResourceName);
                return true;
            }
            if (RootBOriginallySingleMultiName.TryParse(name, out RootBOriginallySingleMultiName rootBOriginallySingleMultiName))
            {
                result = new OriginallySingleResourceNameOneOf(OneofType.RootBOriginallySingleMultiName, rootBOriginallySingleMultiName);
                return true;
            }
            if (allowUnknown)
            {
                if (gax::UnknownResourceName.TryParse(name, out gax::UnknownResourceName unknownResourceName))
                {
                    result = new OriginallySingleResourceNameOneOf(OneofType.Unknown, unknownResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        /// <summary>
        /// Constructs a new instance of <see cref="OriginallySingleResourceNameOneOf"/> from the provided
        /// <see cref="OriginallySingleResourceName"/>.
        /// </summary>
        /// <param name="originallySingleResourceName">
        /// The <see cref="OriginallySingleResourceName"/> to be contained within the returned
        /// <see cref="OriginallySingleResourceNameOneOf"/>. Must not be <c>null</c>
        /// </param>
        /// <returns>
        /// A new <see cref="OriginallySingleResourceNameOneOf"/>, containing
        /// <paramref name="originallySingleResourceName"/>.
        /// </returns>
        public static OriginallySingleResourceNameOneOf From(OriginallySingleResourceName originallySingleResourceName) =>
            new OriginallySingleResourceNameOneOf(OneofType.OriginallySingleResourceName, originallySingleResourceName);

        /// <summary>
        /// Constructs a new instance of <see cref="OriginallySingleResourceNameOneOf"/> from the provided
        /// <see cref="RootBOriginallySingleMultiName"/>.
        /// </summary>
        /// <param name="rootBOriginallySingleMultiName">
        /// The <see cref="RootBOriginallySingleMultiName"/> to be contained within the returned
        /// <see cref="OriginallySingleResourceNameOneOf"/>. Must not be <c>null</c>
        /// </param>
        /// <returns>
        /// A new <see cref="OriginallySingleResourceNameOneOf"/>, containing
        /// <paramref name="rootBOriginallySingleMultiName"/>.
        /// </returns>
        public static OriginallySingleResourceNameOneOf From(RootBOriginallySingleMultiName rootBOriginallySingleMultiName) =>
            new OriginallySingleResourceNameOneOf(OneofType.RootBOriginallySingleMultiName, rootBOriginallySingleMultiName);

        private static bool IsValid(OneofType type, gax::IResourceName name)
        {
            switch (type)
            {
                case OneofType.Unknown: return true;
                case OneofType.OriginallySingleResourceName: return name is OriginallySingleResourceName;
                case OneofType.RootBOriginallySingleMultiName: return name is RootBOriginallySingleMultiName;
                default: return false;
            }
        }

        public OriginallySingleResourceNameOneOf(OneofType type, gax::IResourceName name)
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

        /// <summary>
        /// Get the contained <see cref="gax::IResourceName"/> as <see cref="OriginallySingleResourceName"/>.
        /// </summary>
        /// <remarks>
        /// An <see cref="sys::InvalidOperationException"/> will be thrown is this does not contain an instance of
        /// <see cref="OriginallySingleResourceName"/>.
        /// </remarks>
        public OriginallySingleResourceName OriginallySingleResourceName => CheckAndReturn<OriginallySingleResourceName>(OneofType.OriginallySingleResourceName);

        /// <summary>
        /// Get the contained <see cref="gax::IResourceName"/> as <see cref="RootBOriginallySingleMultiName"/>.
        /// </summary>
        /// <remarks>
        /// An <see cref="sys::InvalidOperationException"/> will be thrown is this does not contain an instance of
        /// <see cref="RootBOriginallySingleMultiName"/>.
        /// </remarks>
        public RootBOriginallySingleMultiName RootBOriginallySingleMultiName => CheckAndReturn<RootBOriginallySingleMultiName>(OneofType.RootBOriginallySingleMultiName);

        /// <inheritdoc/>
        public gax::ResourceNameKind Kind => gax::ResourceNameKind.Oneof;

        /// <inheritdoc/>
        public override string ToString() => this.Name.ToString();

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as OriginallySingleResourceNameOneOf);

        /// <inheritdoc/>
        public bool Equals(OriginallySingleResourceNameOneOf other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(OriginallySingleResourceNameOneOf a, OriginallySingleResourceNameOneOf b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(OriginallySingleResourceNameOneOf a, OriginallySingleResourceNameOneOf b) => !(a == b);
    }

    public partial class SingleResource
    {
        /// <summary>
        /// <see cref="tr::SingleResourceName"/>-typed view over the <see cref="Name"/> resource name property.
        /// </summary>
        public tr::SingleResourceName SingleResourceName
        {
            get => string.IsNullOrEmpty(Name) ? null : tr::SingleResourceName.Parse(Name);
            set => Name = value?.ToString() ?? "";
        }
    }

    public partial class SingleResourceRef
    {
        /// <summary>
        /// <see cref="tr::SingleResourceName"/>-typed view over the <see cref="SingleResource"/> resource name
        /// property.
        /// </summary>
        public tr::SingleResourceName SingleResourceAsSingleResourceName
        {
            get => string.IsNullOrEmpty(SingleResource) ? null : tr::SingleResourceName.Parse(SingleResource);
            set => SingleResource = value?.ToString() ?? "";
        }
    }

    public partial class MultiResource
    {
        /// <summary>
        /// <see cref="tr::MultiResourceNameOneOf"/>-typed view over the <see cref="Name"/> resource name property.
        /// </summary>
        public tr::MultiResourceNameOneOf MultiResourceNameOneOf
        {
            get => string.IsNullOrEmpty(Name) ? null : tr::MultiResourceNameOneOf.Parse(Name, true);
            set => Name = value?.ToString() ?? "";
        }
    }

    public partial class MultiResourceRef
    {
        /// <summary>
        /// <see cref="MultiResourceNameOneOf"/>-typed view over the <see cref="MultiResource"/> resource name property.
        /// </summary>
        public MultiResourceNameOneOf MultiResourceAsMultiResourceNameOneOf
        {
            get => string.IsNullOrEmpty(MultiResource) ? null : MultiResourceNameOneOf.Parse(MultiResource, true);
            set => MultiResource = value?.ToString() ?? "";
        }
    }

    public partial class FutureMultiResource
    {
        /// <summary>
        /// <see cref="tr::FutureMultiResourceNameOneOf"/>-typed view over the <see cref="Name"/> resource name
        /// property.
        /// </summary>
        public tr::FutureMultiResourceNameOneOf FutureMultiResourceNameOneOf
        {
            get => string.IsNullOrEmpty(Name) ? null : tr::FutureMultiResourceNameOneOf.Parse(Name, true);
            set => Name = value?.ToString() ?? "";
        }
    }

    public partial class OriginallySingleResource
    {
        /// <summary>
        /// <see cref="tr::OriginallySingleResourceName"/>-typed view over the <see cref="Name"/> resource name
        /// property.
        /// </summary>
        public tr::OriginallySingleResourceName OriginallySingleResourceName
        {
            get => string.IsNullOrEmpty(Name) ? null : tr::OriginallySingleResourceName.Parse(Name);
            set => Name = value?.ToString() ?? "";
        }

        /// <summary>
        /// <see cref="tr::OriginallySingleResourceNameOneOf"/>-typed view over the <see cref="Name"/> resource name
        /// property.
        /// </summary>
        public tr::OriginallySingleResourceNameOneOf OriginallySingleResourceNameOneOf
        {
            get => string.IsNullOrEmpty(Name) ? null : tr::OriginallySingleResourceNameOneOf.Parse(Name, true);
            set => Name = value?.ToString() ?? "";
        }
    }

    public partial class OriginallySingleResourceRef
    {
        /// <summary>
        /// <see cref="OriginallySingleResourceName"/>-typed view over the <see cref="Resource1"/> resource name
        /// property.
        /// </summary>
        public OriginallySingleResourceName Resource1AsOriginallySingleResourceName
        {
            get => string.IsNullOrEmpty(Resource1) ? null : OriginallySingleResourceName.Parse(Resource1);
            set => Resource1 = value?.ToString() ?? "";
        }

        /// <summary>
        /// <see cref="OriginallySingleResourceNameOneOf"/>-typed view over the <see cref="Resource1"/> resource name
        /// property.
        /// </summary>
        public OriginallySingleResourceNameOneOf Resource1AsOriginallySingleResourceNameOneOf
        {
            get => string.IsNullOrEmpty(Resource1) ? null : OriginallySingleResourceNameOneOf.Parse(Resource1, true);
            set => Resource1 = value?.ToString() ?? "";
        }

        /// <summary>
        /// <see cref="OriginallySingleResourceName"/>-typed view over the <see cref="Resource2"/> resource name
        /// property.
        /// </summary>
        public OriginallySingleResourceName Resource2AsOriginallySingleResourceName
        {
            get => string.IsNullOrEmpty(Resource2) ? null : OriginallySingleResourceName.Parse(Resource2);
            set => Resource2 = value?.ToString() ?? "";
        }

        /// <summary>
        /// <see cref="OriginallySingleResourceNameOneOf"/>-typed view over the <see cref="Resource2"/> resource name
        /// property.
        /// </summary>
        public OriginallySingleResourceNameOneOf Resource2AsOriginallySingleResourceNameOneOf
        {
            get => string.IsNullOrEmpty(Resource2) ? null : OriginallySingleResourceNameOneOf.Parse(Resource2, true);
            set => Resource2 = value?.ToString() ?? "";
        }
    }
}
