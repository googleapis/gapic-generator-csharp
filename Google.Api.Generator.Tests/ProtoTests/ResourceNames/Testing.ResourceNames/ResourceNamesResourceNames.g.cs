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
        /// <summary>The possible contents of <see cref="SingleResourceName"/>.</summary>
        public enum ResourceNameType
        {
            /// <summary>An unparsed resource name.</summary>
            Unparsed = 0,

            /// <summary>A resource name with pattern <c>items/{item_id}</c>.</summary>
            Item = 1
        }

        private static gax::PathTemplate s_item = new gax::PathTemplate("items/{item_id}");

        /// <summary>Creates a <see cref="SingleResourceName"/> containing an unparsed resource name.</summary>
        /// <param name="unparsedResourceName">The unparsed resource name. Must not be <c>null</c>.</param>
        /// <returns>
        /// A new instance of <see cref="SingleResourceName"/> containing the provided
        /// <paramref name="unparsedResourceName"/>.
        /// </returns>
        public static SingleResourceName FromUnparsed(gax::UnparsedResourceName unparsedResourceName) =>
            new SingleResourceName(ResourceNameType.Unparsed, gax::GaxPreconditions.CheckNotNull(unparsedResourceName, nameof(unparsedResourceName)));

        /// <summary>Creates a <see cref="SingleResourceName"/> with the pattern <c>items/{item_id}</c>.</summary>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="SingleResourceName"/> constructed from the provided ids.</returns>
        public static SingleResourceName FromItem(string itemId) =>
            new SingleResourceName(ResourceNameType.Item, itemId: gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="SingleResourceName"/> with pattern
        /// <c>items/{item_id}</c>.
        /// </summary>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="SingleResourceName"/> with pattern <c>items/{item_id}</c>.
        /// </returns>
        public static string Format(string itemId) => FormatItem(itemId);

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="SingleResourceName"/> with pattern
        /// <c>items/{item_id}</c>.
        /// </summary>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="SingleResourceName"/> with pattern <c>items/{item_id}</c>.
        /// </returns>
        public static string FormatItem(string itemId) =>
            s_item.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Parses the given resource name string into a new <see cref="SingleResourceName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>items/{item_id}</c></description></item></list>
        /// </remarks>
        /// <param name="singleResourceName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="SingleResourceName"/> if successful.</returns>
        public static SingleResourceName Parse(string singleResourceName) => Parse(singleResourceName, false);

        /// <summary>
        /// Parses the given resource name string into a new <see cref="SingleResourceName"/> instance; optionally
        /// allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>items/{item_id}</c></description></item></list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="singleResourceName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <returns>The parsed <see cref="SingleResourceName"/> if successful.</returns>
        public static SingleResourceName Parse(string singleResourceName, bool allowUnparsed) =>
            TryParse(singleResourceName, allowUnparsed, out SingleResourceName result) ? result : throw new sys::ArgumentException("The given resource-name matches no pattern.");

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="SingleResourceName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>items/{item_id}</c></description></item></list>
        /// </remarks>
        /// <param name="singleResourceName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="SingleResourceName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string singleResourceName, out SingleResourceName result) =>
            TryParse(singleResourceName, false, out result);

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="SingleResourceName"/> instance;
        /// optionally allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>items/{item_id}</c></description></item></list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="singleResourceName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="SingleResourceName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string singleResourceName, bool allowUnparsed, out SingleResourceName result)
        {
            gax::GaxPreconditions.CheckNotNull(singleResourceName, nameof(singleResourceName));
            gax::TemplatedResourceName resourceName;
            if (s_item.TryParseName(singleResourceName, out resourceName))
            {
                result = FromItem(resourceName[0]);
                return true;
            }
            if (allowUnparsed)
            {
                if (gax::UnparsedResourceName.TryParse(singleResourceName, out gax::UnparsedResourceName unparsedResourceName))
                {
                    result = FromUnparsed(unparsedResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        private SingleResourceName(ResourceNameType type, gax::UnparsedResourceName unparsedResourceName = null, string itemId = null)
        {
            Type = type;
            UnparsedResource = unparsedResourceName;
            ItemId = itemId;
        }

        /// <summary>
        /// Constructs a new instance of a <see cref="SingleResourceName"/> class from the component parts of pattern
        /// <c>items/{item_id}</c>
        /// </summary>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        public SingleResourceName(string itemId) : this(ResourceNameType.Item, itemId: gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)))
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
        /// The <c>Item</c> ID. Will not be <c>null</c>, unless this instance contains an unparsed resource name.
        /// </summary>
        public string ItemId { get; }

        /// <inheritdoc/>
        public bool IsKnownPattern => Type != ResourceNameType.Unparsed;

        /// <inheritdoc/>
        public override string ToString()
        {
            switch (Type)
            {
                case ResourceNameType.Unparsed: return UnparsedResource.ToString();
                case ResourceNameType.Item: return s_item.Expand(ItemId);
                default: throw new sys::InvalidOperationException("Unrecognized resource-type.");
            }
        }

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

    /// <summary>Resource name for the <c>MultiResource</c> resource.</summary>
    public sealed partial class MultiResourceName : gax::IResourceName, sys::IEquatable<MultiResourceName>
    {
        /// <summary>The possible contents of <see cref="MultiResourceName"/>.</summary>
        public enum ResourceNameType
        {
            /// <summary>An unparsed resource name.</summary>
            Unparsed = 0,

            /// <summary>A resource name with pattern <c>roota/{root_a_id}/multi/{multi_id}</c>.</summary>
            RootAMulti = 1,

            /// <summary>A resource name with pattern <c>rootb/{root_b_id}/multi/{multi_id}</c>.</summary>
            RootBMulti = 2
        }

        private static gax::PathTemplate s_rootAMulti = new gax::PathTemplate("roota/{root_a_id}/multi/{multi_id}");

        private static gax::PathTemplate s_rootBMulti = new gax::PathTemplate("rootb/{root_b_id}/multi/{multi_id}");

        /// <summary>Creates a <see cref="MultiResourceName"/> containing an unparsed resource name.</summary>
        /// <param name="unparsedResourceName">The unparsed resource name. Must not be <c>null</c>.</param>
        /// <returns>
        /// A new instance of <see cref="MultiResourceName"/> containing the provided
        /// <paramref name="unparsedResourceName"/>.
        /// </returns>
        public static MultiResourceName FromUnparsed(gax::UnparsedResourceName unparsedResourceName) =>
            new MultiResourceName(ResourceNameType.Unparsed, gax::GaxPreconditions.CheckNotNull(unparsedResourceName, nameof(unparsedResourceName)));

        /// <summary>
        /// Creates a <see cref="MultiResourceName"/> with the pattern <c>roota/{root_a_id}/multi/{multi_id}</c>.
        /// </summary>
        /// <param name="rootAId">The <c>RootA</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="multiId">The <c>Multi</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="MultiResourceName"/> constructed from the provided ids.</returns>
        public static MultiResourceName FromRootAMulti(string rootAId, string multiId) =>
            new MultiResourceName(ResourceNameType.RootAMulti, rootAId: gax::GaxPreconditions.CheckNotNullOrEmpty(rootAId, nameof(rootAId)), multiId: gax::GaxPreconditions.CheckNotNullOrEmpty(multiId, nameof(multiId)));

        /// <summary>
        /// Creates a <see cref="MultiResourceName"/> with the pattern <c>rootb/{root_b_id}/multi/{multi_id}</c>.
        /// </summary>
        /// <param name="rootBId">The <c>RootB</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="multiId">The <c>Multi</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="MultiResourceName"/> constructed from the provided ids.</returns>
        public static MultiResourceName FromRootBMulti(string rootBId, string multiId) =>
            new MultiResourceName(ResourceNameType.RootBMulti, rootBId: gax::GaxPreconditions.CheckNotNullOrEmpty(rootBId, nameof(rootBId)), multiId: gax::GaxPreconditions.CheckNotNullOrEmpty(multiId, nameof(multiId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="MultiResourceName"/> with pattern
        /// <c>roota/{root_a_id}/multi/{multi_id}</c>.
        /// </summary>
        /// <param name="rootAId">The <c>RootA</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="multiId">The <c>Multi</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="MultiResourceName"/> with pattern
        /// <c>roota/{root_a_id}/multi/{multi_id}</c>.
        /// </returns>
        public static string Format(string rootAId, string multiId) => FormatRootAMulti(rootAId, multiId);

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="MultiResourceName"/> with pattern
        /// <c>roota/{root_a_id}/multi/{multi_id}</c>.
        /// </summary>
        /// <param name="rootAId">The <c>RootA</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="multiId">The <c>Multi</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="MultiResourceName"/> with pattern
        /// <c>roota/{root_a_id}/multi/{multi_id}</c>.
        /// </returns>
        public static string FormatRootAMulti(string rootAId, string multiId) =>
            s_rootAMulti.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(rootAId, nameof(rootAId)), gax::GaxPreconditions.CheckNotNullOrEmpty(multiId, nameof(multiId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="MultiResourceName"/> with pattern
        /// <c>rootb/{root_b_id}/multi/{multi_id}</c>.
        /// </summary>
        /// <param name="rootBId">The <c>RootB</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="multiId">The <c>Multi</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="MultiResourceName"/> with pattern
        /// <c>rootb/{root_b_id}/multi/{multi_id}</c>.
        /// </returns>
        public static string FormatRootBMulti(string rootBId, string multiId) =>
            s_rootBMulti.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(rootBId, nameof(rootBId)), gax::GaxPreconditions.CheckNotNullOrEmpty(multiId, nameof(multiId)));

        /// <summary>
        /// Parses the given resource name string into a new <see cref="MultiResourceName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>roota/{root_a_id}/multi/{multi_id}</c></description></item>
        /// <item><description><c>rootb/{root_b_id}/multi/{multi_id}</c></description></item>
        /// </list>
        /// </remarks>
        /// <param name="multiResourceName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="MultiResourceName"/> if successful.</returns>
        public static MultiResourceName Parse(string multiResourceName) => Parse(multiResourceName, false);

        /// <summary>
        /// Parses the given resource name string into a new <see cref="MultiResourceName"/> instance; optionally
        /// allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>roota/{root_a_id}/multi/{multi_id}</c></description></item>
        /// <item><description><c>rootb/{root_b_id}/multi/{multi_id}</c></description></item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="multiResourceName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <returns>The parsed <see cref="MultiResourceName"/> if successful.</returns>
        public static MultiResourceName Parse(string multiResourceName, bool allowUnparsed) =>
            TryParse(multiResourceName, allowUnparsed, out MultiResourceName result) ? result : throw new sys::ArgumentException("The given resource-name matches no pattern.");

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="MultiResourceName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>roota/{root_a_id}/multi/{multi_id}</c></description></item>
        /// <item><description><c>rootb/{root_b_id}/multi/{multi_id}</c></description></item>
        /// </list>
        /// </remarks>
        /// <param name="multiResourceName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="MultiResourceName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string multiResourceName, out MultiResourceName result) =>
            TryParse(multiResourceName, false, out result);

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="MultiResourceName"/> instance;
        /// optionally allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>roota/{root_a_id}/multi/{multi_id}</c></description></item>
        /// <item><description><c>rootb/{root_b_id}/multi/{multi_id}</c></description></item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="multiResourceName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="MultiResourceName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string multiResourceName, bool allowUnparsed, out MultiResourceName result)
        {
            gax::GaxPreconditions.CheckNotNull(multiResourceName, nameof(multiResourceName));
            gax::TemplatedResourceName resourceName;
            if (s_rootAMulti.TryParseName(multiResourceName, out resourceName))
            {
                result = FromRootAMulti(resourceName[0], resourceName[1]);
                return true;
            }
            if (s_rootBMulti.TryParseName(multiResourceName, out resourceName))
            {
                result = FromRootBMulti(resourceName[0], resourceName[1]);
                return true;
            }
            if (allowUnparsed)
            {
                if (gax::UnparsedResourceName.TryParse(multiResourceName, out gax::UnparsedResourceName unparsedResourceName))
                {
                    result = FromUnparsed(unparsedResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        private MultiResourceName(ResourceNameType type, gax::UnparsedResourceName unparsedResourceName = null, string multiId = null, string rootAId = null, string rootBId = null)
        {
            Type = type;
            UnparsedResource = unparsedResourceName;
            MultiId = multiId;
            RootAId = rootAId;
            RootBId = rootBId;
        }

        /// <summary>
        /// Constructs a new instance of a <see cref="MultiResourceName"/> class from the component parts of pattern
        /// <c>roota/{root_a_id}/multi/{multi_id}</c>
        /// </summary>
        /// <param name="rootAId">The <c>RootA</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="multiId">The <c>Multi</c> ID. Must not be <c>null</c> or empty.</param>
        public MultiResourceName(string rootAId, string multiId) : this(ResourceNameType.RootAMulti, rootAId: gax::GaxPreconditions.CheckNotNullOrEmpty(rootAId, nameof(rootAId)), multiId: gax::GaxPreconditions.CheckNotNullOrEmpty(multiId, nameof(multiId)))
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
        /// The <c>Multi</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string MultiId { get; }

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
                case ResourceNameType.RootAMulti: return s_rootAMulti.Expand(RootAId, MultiId);
                case ResourceNameType.RootBMulti: return s_rootBMulti.Expand(RootBId, MultiId);
                default: throw new sys::InvalidOperationException("Unrecognized resource-type.");
            }
        }

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as MultiResourceName);

        /// <inheritdoc/>
        public bool Equals(MultiResourceName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(MultiResourceName a, MultiResourceName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(MultiResourceName a, MultiResourceName b) => !(a == b);
    }

    /// <summary>Resource name for the <c>FutureMultiResource</c> resource.</summary>
    public sealed partial class FutureMultiResourceName : gax::IResourceName, sys::IEquatable<FutureMultiResourceName>
    {
        /// <summary>The possible contents of <see cref="FutureMultiResourceName"/>.</summary>
        public enum ResourceNameType
        {
            /// <summary>An unparsed resource name.</summary>
            Unparsed = 0,

            /// <summary>A resource name with pattern <c>root/{root_a_id}/futuremulti/{future_multi_id}</c>.</summary>
            RootAFutureMulti = 1
        }

        private static gax::PathTemplate s_rootAFutureMulti = new gax::PathTemplate("root/{root_a_id}/futuremulti/{future_multi_id}");

        /// <summary>Creates a <see cref="FutureMultiResourceName"/> containing an unparsed resource name.</summary>
        /// <param name="unparsedResourceName">The unparsed resource name. Must not be <c>null</c>.</param>
        /// <returns>
        /// A new instance of <see cref="FutureMultiResourceName"/> containing the provided
        /// <paramref name="unparsedResourceName"/>.
        /// </returns>
        public static FutureMultiResourceName FromUnparsed(gax::UnparsedResourceName unparsedResourceName) =>
            new FutureMultiResourceName(ResourceNameType.Unparsed, gax::GaxPreconditions.CheckNotNull(unparsedResourceName, nameof(unparsedResourceName)));

        /// <summary>
        /// Creates a <see cref="FutureMultiResourceName"/> with the pattern
        /// <c>root/{root_a_id}/futuremulti/{future_multi_id}</c>.
        /// </summary>
        /// <param name="rootAId">The <c>RootA</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="futureMultiId">The <c>FutureMulti</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// A new instance of <see cref="FutureMultiResourceName"/> constructed from the provided ids.
        /// </returns>
        public static FutureMultiResourceName FromRootAFutureMulti(string rootAId, string futureMultiId) =>
            new FutureMultiResourceName(ResourceNameType.RootAFutureMulti, rootAId: gax::GaxPreconditions.CheckNotNullOrEmpty(rootAId, nameof(rootAId)), futureMultiId: gax::GaxPreconditions.CheckNotNullOrEmpty(futureMultiId, nameof(futureMultiId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="FutureMultiResourceName"/> with pattern
        /// <c>root/{root_a_id}/futuremulti/{future_multi_id}</c>.
        /// </summary>
        /// <param name="rootAId">The <c>RootA</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="futureMultiId">The <c>FutureMulti</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="FutureMultiResourceName"/> with pattern
        /// <c>root/{root_a_id}/futuremulti/{future_multi_id}</c>.
        /// </returns>
        public static string Format(string rootAId, string futureMultiId) => FormatRootAFutureMulti(rootAId, futureMultiId);

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="FutureMultiResourceName"/> with pattern
        /// <c>root/{root_a_id}/futuremulti/{future_multi_id}</c>.
        /// </summary>
        /// <param name="rootAId">The <c>RootA</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="futureMultiId">The <c>FutureMulti</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="FutureMultiResourceName"/> with pattern
        /// <c>root/{root_a_id}/futuremulti/{future_multi_id}</c>.
        /// </returns>
        public static string FormatRootAFutureMulti(string rootAId, string futureMultiId) =>
            s_rootAFutureMulti.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(rootAId, nameof(rootAId)), gax::GaxPreconditions.CheckNotNullOrEmpty(futureMultiId, nameof(futureMultiId)));

        /// <summary>
        /// Parses the given resource name string into a new <see cref="FutureMultiResourceName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>root/{root_a_id}/futuremulti/{future_multi_id}</c></description></item>
        /// </list>
        /// </remarks>
        /// <param name="futureMultiResourceName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="FutureMultiResourceName"/> if successful.</returns>
        public static FutureMultiResourceName Parse(string futureMultiResourceName) => Parse(futureMultiResourceName, false);

        /// <summary>
        /// Parses the given resource name string into a new <see cref="FutureMultiResourceName"/> instance; optionally
        /// allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>root/{root_a_id}/futuremulti/{future_multi_id}</c></description></item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="futureMultiResourceName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <returns>The parsed <see cref="FutureMultiResourceName"/> if successful.</returns>
        public static FutureMultiResourceName Parse(string futureMultiResourceName, bool allowUnparsed) =>
            TryParse(futureMultiResourceName, allowUnparsed, out FutureMultiResourceName result) ? result : throw new sys::ArgumentException("The given resource-name matches no pattern.");

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="FutureMultiResourceName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>root/{root_a_id}/futuremulti/{future_multi_id}</c></description></item>
        /// </list>
        /// </remarks>
        /// <param name="futureMultiResourceName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="FutureMultiResourceName"/>, or <c>null</c> if parsing
        /// failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string futureMultiResourceName, out FutureMultiResourceName result) =>
            TryParse(futureMultiResourceName, false, out result);

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="FutureMultiResourceName"/> instance;
        /// optionally allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>root/{root_a_id}/futuremulti/{future_multi_id}</c></description></item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="futureMultiResourceName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="FutureMultiResourceName"/>, or <c>null</c> if parsing
        /// failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string futureMultiResourceName, bool allowUnparsed, out FutureMultiResourceName result)
        {
            gax::GaxPreconditions.CheckNotNull(futureMultiResourceName, nameof(futureMultiResourceName));
            gax::TemplatedResourceName resourceName;
            if (s_rootAFutureMulti.TryParseName(futureMultiResourceName, out resourceName))
            {
                result = FromRootAFutureMulti(resourceName[0], resourceName[1]);
                return true;
            }
            if (allowUnparsed)
            {
                if (gax::UnparsedResourceName.TryParse(futureMultiResourceName, out gax::UnparsedResourceName unparsedResourceName))
                {
                    result = FromUnparsed(unparsedResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        private FutureMultiResourceName(ResourceNameType type, gax::UnparsedResourceName unparsedResourceName = null, string futureMultiId = null, string rootAId = null)
        {
            Type = type;
            UnparsedResource = unparsedResourceName;
            FutureMultiId = futureMultiId;
            RootAId = rootAId;
        }

        /// <summary>
        /// Constructs a new instance of a <see cref="FutureMultiResourceName"/> class from the component parts of
        /// pattern <c>root/{root_a_id}/futuremulti/{future_multi_id}</c>
        /// </summary>
        /// <param name="rootAId">The <c>RootA</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="futureMultiId">The <c>FutureMulti</c> ID. Must not be <c>null</c> or empty.</param>
        public FutureMultiResourceName(string rootAId, string futureMultiId) : this(ResourceNameType.RootAFutureMulti, rootAId: gax::GaxPreconditions.CheckNotNullOrEmpty(rootAId, nameof(rootAId)), futureMultiId: gax::GaxPreconditions.CheckNotNullOrEmpty(futureMultiId, nameof(futureMultiId)))
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
        /// The <c>FutureMulti</c> ID. Will not be <c>null</c>, unless this instance contains an unparsed resource name.
        /// </summary>
        public string FutureMultiId { get; }

        /// <summary>
        /// The <c>RootA</c> ID. Will not be <c>null</c>, unless this instance contains an unparsed resource name.
        /// </summary>
        public string RootAId { get; }

        /// <inheritdoc/>
        public bool IsKnownPattern => Type != ResourceNameType.Unparsed;

        /// <inheritdoc/>
        public override string ToString()
        {
            switch (Type)
            {
                case ResourceNameType.Unparsed: return UnparsedResource.ToString();
                case ResourceNameType.RootAFutureMulti: return s_rootAFutureMulti.Expand(RootAId, FutureMultiId);
                default: throw new sys::InvalidOperationException("Unrecognized resource-type.");
            }
        }

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as FutureMultiResourceName);

        /// <inheritdoc/>
        public bool Equals(FutureMultiResourceName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(FutureMultiResourceName a, FutureMultiResourceName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(FutureMultiResourceName a, FutureMultiResourceName b) => !(a == b);
    }

    /// <summary>Resource name for the <c>OriginallySingleResource</c> resource.</summary>
    public sealed partial class OriginallySingleResourceName : gax::IResourceName, sys::IEquatable<OriginallySingleResourceName>
    {
        /// <summary>The possible contents of <see cref="OriginallySingleResourceName"/>.</summary>
        public enum ResourceNameType
        {
            /// <summary>An unparsed resource name.</summary>
            Unparsed = 0,

            /// <summary>
            /// A resource name with pattern <c>roota/{root_a_id}/originallysingle/{originally_single_multi_id}</c>.
            /// </summary>
            RootAOriginallySingleMulti = 1,

            /// <summary>
            /// A resource name with pattern <c>rootb/{root_b_id}/originallysingle/{originally_single_multi_id}</c>.
            /// </summary>
            RootBOriginallySingleMulti = 2
        }

        private static gax::PathTemplate s_rootAOriginallySingleMulti = new gax::PathTemplate("roota/{root_a_id}/originallysingle/{originally_single_multi_id}");

        private static gax::PathTemplate s_rootBOriginallySingleMulti = new gax::PathTemplate("rootb/{root_b_id}/originallysingle/{originally_single_multi_id}");

        /// <summary>
        /// Creates a <see cref="OriginallySingleResourceName"/> containing an unparsed resource name.
        /// </summary>
        /// <param name="unparsedResourceName">The unparsed resource name. Must not be <c>null</c>.</param>
        /// <returns>
        /// A new instance of <see cref="OriginallySingleResourceName"/> containing the provided
        /// <paramref name="unparsedResourceName"/>.
        /// </returns>
        public static OriginallySingleResourceName FromUnparsed(gax::UnparsedResourceName unparsedResourceName) =>
            new OriginallySingleResourceName(ResourceNameType.Unparsed, gax::GaxPreconditions.CheckNotNull(unparsedResourceName, nameof(unparsedResourceName)));

        /// <summary>
        /// Creates a <see cref="OriginallySingleResourceName"/> with the pattern
        /// <c>roota/{root_a_id}/originallysingle/{originally_single_multi_id}</c>.
        /// </summary>
        /// <param name="rootAId">The <c>RootA</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="originallySingleMultiId">
        /// The <c>OriginallySingleMulti</c> ID. Must not be <c>null</c> or empty.
        /// </param>
        /// <returns>
        /// A new instance of <see cref="OriginallySingleResourceName"/> constructed from the provided ids.
        /// </returns>
        public static OriginallySingleResourceName FromRootAOriginallySingleMulti(string rootAId, string originallySingleMultiId) =>
            new OriginallySingleResourceName(ResourceNameType.RootAOriginallySingleMulti, rootAId: gax::GaxPreconditions.CheckNotNullOrEmpty(rootAId, nameof(rootAId)), originallySingleMultiId: gax::GaxPreconditions.CheckNotNullOrEmpty(originallySingleMultiId, nameof(originallySingleMultiId)));

        /// <summary>
        /// Creates a <see cref="OriginallySingleResourceName"/> with the pattern
        /// <c>rootb/{root_b_id}/originallysingle/{originally_single_multi_id}</c>.
        /// </summary>
        /// <param name="rootBId">The <c>RootB</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="originallySingleMultiId">
        /// The <c>OriginallySingleMulti</c> ID. Must not be <c>null</c> or empty.
        /// </param>
        /// <returns>
        /// A new instance of <see cref="OriginallySingleResourceName"/> constructed from the provided ids.
        /// </returns>
        public static OriginallySingleResourceName FromRootBOriginallySingleMulti(string rootBId, string originallySingleMultiId) =>
            new OriginallySingleResourceName(ResourceNameType.RootBOriginallySingleMulti, rootBId: gax::GaxPreconditions.CheckNotNullOrEmpty(rootBId, nameof(rootBId)), originallySingleMultiId: gax::GaxPreconditions.CheckNotNullOrEmpty(originallySingleMultiId, nameof(originallySingleMultiId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="OriginallySingleResourceName"/> with
        /// pattern <c>roota/{root_a_id}/originallysingle/{originally_single_multi_id}</c>.
        /// </summary>
        /// <param name="rootAId">The <c>RootA</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="originallySingleMultiId">
        /// The <c>OriginallySingleMulti</c> ID. Must not be <c>null</c> or empty.
        /// </param>
        /// <returns>
        /// The string representation of this <see cref="OriginallySingleResourceName"/> with pattern
        /// <c>roota/{root_a_id}/originallysingle/{originally_single_multi_id}</c>.
        /// </returns>
        public static string Format(string rootAId, string originallySingleMultiId) =>
            FormatRootAOriginallySingleMulti(rootAId, originallySingleMultiId);

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="OriginallySingleResourceName"/> with
        /// pattern <c>roota/{root_a_id}/originallysingle/{originally_single_multi_id}</c>.
        /// </summary>
        /// <param name="rootAId">The <c>RootA</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="originallySingleMultiId">
        /// The <c>OriginallySingleMulti</c> ID. Must not be <c>null</c> or empty.
        /// </param>
        /// <returns>
        /// The string representation of this <see cref="OriginallySingleResourceName"/> with pattern
        /// <c>roota/{root_a_id}/originallysingle/{originally_single_multi_id}</c>.
        /// </returns>
        public static string FormatRootAOriginallySingleMulti(string rootAId, string originallySingleMultiId) =>
            s_rootAOriginallySingleMulti.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(rootAId, nameof(rootAId)), gax::GaxPreconditions.CheckNotNullOrEmpty(originallySingleMultiId, nameof(originallySingleMultiId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="OriginallySingleResourceName"/> with
        /// pattern <c>rootb/{root_b_id}/originallysingle/{originally_single_multi_id}</c>.
        /// </summary>
        /// <param name="rootBId">The <c>RootB</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="originallySingleMultiId">
        /// The <c>OriginallySingleMulti</c> ID. Must not be <c>null</c> or empty.
        /// </param>
        /// <returns>
        /// The string representation of this <see cref="OriginallySingleResourceName"/> with pattern
        /// <c>rootb/{root_b_id}/originallysingle/{originally_single_multi_id}</c>.
        /// </returns>
        public static string FormatRootBOriginallySingleMulti(string rootBId, string originallySingleMultiId) =>
            s_rootBOriginallySingleMulti.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(rootBId, nameof(rootBId)), gax::GaxPreconditions.CheckNotNullOrEmpty(originallySingleMultiId, nameof(originallySingleMultiId)));

        /// <summary>
        /// Parses the given resource name string into a new <see cref="OriginallySingleResourceName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item>
        /// <description><c>roota/{root_a_id}/originallysingle/{originally_single_multi_id}</c></description>
        /// </item>
        /// <item>
        /// <description><c>rootb/{root_b_id}/originallysingle/{originally_single_multi_id}</c></description>
        /// </item>
        /// </list>
        /// </remarks>
        /// <param name="originallySingleResourceName">
        /// The resource name in string form. Must not be <c>null</c>.
        /// </param>
        /// <returns>The parsed <see cref="OriginallySingleResourceName"/> if successful.</returns>
        public static OriginallySingleResourceName Parse(string originallySingleResourceName) =>
            Parse(originallySingleResourceName, false);

        /// <summary>
        /// Parses the given resource name string into a new <see cref="OriginallySingleResourceName"/> instance;
        /// optionally allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item>
        /// <description><c>roota/{root_a_id}/originallysingle/{originally_single_multi_id}</c></description>
        /// </item>
        /// <item>
        /// <description><c>rootb/{root_b_id}/originallysingle/{originally_single_multi_id}</c></description>
        /// </item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="originallySingleResourceName">
        /// The resource name in string form. Must not be <c>null</c>.
        /// </param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <returns>The parsed <see cref="OriginallySingleResourceName"/> if successful.</returns>
        public static OriginallySingleResourceName Parse(string originallySingleResourceName, bool allowUnparsed) =>
            TryParse(originallySingleResourceName, allowUnparsed, out OriginallySingleResourceName result) ? result : throw new sys::ArgumentException("The given resource-name matches no pattern.");

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="OriginallySingleResourceName"/>
        /// instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item>
        /// <description><c>roota/{root_a_id}/originallysingle/{originally_single_multi_id}</c></description>
        /// </item>
        /// <item>
        /// <description><c>rootb/{root_b_id}/originallysingle/{originally_single_multi_id}</c></description>
        /// </item>
        /// </list>
        /// </remarks>
        /// <param name="originallySingleResourceName">
        /// The resource name in string form. Must not be <c>null</c>.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="OriginallySingleResourceName"/>, or <c>null</c> if parsing
        /// failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string originallySingleResourceName, out OriginallySingleResourceName result) =>
            TryParse(originallySingleResourceName, false, out result);

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="OriginallySingleResourceName"/>
        /// instance; optionally allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item>
        /// <description><c>roota/{root_a_id}/originallysingle/{originally_single_multi_id}</c></description>
        /// </item>
        /// <item>
        /// <description><c>rootb/{root_b_id}/originallysingle/{originally_single_multi_id}</c></description>
        /// </item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="originallySingleResourceName">
        /// The resource name in string form. Must not be <c>null</c>.
        /// </param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="OriginallySingleResourceName"/>, or <c>null</c> if parsing
        /// failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string originallySingleResourceName, bool allowUnparsed, out OriginallySingleResourceName result)
        {
            gax::GaxPreconditions.CheckNotNull(originallySingleResourceName, nameof(originallySingleResourceName));
            gax::TemplatedResourceName resourceName;
            if (s_rootAOriginallySingleMulti.TryParseName(originallySingleResourceName, out resourceName))
            {
                result = FromRootAOriginallySingleMulti(resourceName[0], resourceName[1]);
                return true;
            }
            if (s_rootBOriginallySingleMulti.TryParseName(originallySingleResourceName, out resourceName))
            {
                result = FromRootBOriginallySingleMulti(resourceName[0], resourceName[1]);
                return true;
            }
            if (allowUnparsed)
            {
                if (gax::UnparsedResourceName.TryParse(originallySingleResourceName, out gax::UnparsedResourceName unparsedResourceName))
                {
                    result = FromUnparsed(unparsedResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        private OriginallySingleResourceName(ResourceNameType type, gax::UnparsedResourceName unparsedResourceName = null, string originallySingleMultiId = null, string rootAId = null, string rootBId = null)
        {
            Type = type;
            UnparsedResource = unparsedResourceName;
            OriginallySingleMultiId = originallySingleMultiId;
            RootAId = rootAId;
            RootBId = rootBId;
        }

        /// <summary>
        /// Constructs a new instance of a <see cref="OriginallySingleResourceName"/> class from the component parts of
        /// pattern <c>roota/{root_a_id}/originallysingle/{originally_single_multi_id}</c>
        /// </summary>
        /// <param name="rootAId">The <c>RootA</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="originallySingleMultiId">
        /// The <c>OriginallySingleMulti</c> ID. Must not be <c>null</c> or empty.
        /// </param>
        public OriginallySingleResourceName(string rootAId, string originallySingleMultiId) : this(ResourceNameType.RootAOriginallySingleMulti, rootAId: gax::GaxPreconditions.CheckNotNullOrEmpty(rootAId, nameof(rootAId)), originallySingleMultiId: gax::GaxPreconditions.CheckNotNullOrEmpty(originallySingleMultiId, nameof(originallySingleMultiId)))
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
        /// The <c>OriginallySingleMulti</c> ID. May be <c>null</c>, depending on which resource name is contained by
        /// this instance.
        /// </summary>
        public string OriginallySingleMultiId { get; }

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
                case ResourceNameType.RootAOriginallySingleMulti: return s_rootAOriginallySingleMulti.Expand(RootAId, OriginallySingleMultiId);
                case ResourceNameType.RootBOriginallySingleMulti: return s_rootBOriginallySingleMulti.Expand(RootBId, OriginallySingleMultiId);
                default: throw new sys::InvalidOperationException("Unrecognized resource-type.");
            }
        }

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
        /// <see cref="tr::MultiResourceName"/>-typed view over the <see cref="Name"/> resource name property.
        /// </summary>
        public tr::MultiResourceName MultiResourceName
        {
            get => string.IsNullOrEmpty(Name) ? null : tr::MultiResourceName.Parse(Name);
            set => Name = value?.ToString() ?? "";
        }
    }

    public partial class MultiResourceRef
    {
        /// <summary>
        /// <see cref="MultiResourceName"/>-typed view over the <see cref="MultiResource"/> resource name property.
        /// </summary>
        public MultiResourceName MultiResourceAsMultiResourceName
        {
            get => string.IsNullOrEmpty(MultiResource) ? null : MultiResourceName.Parse(MultiResource);
            set => MultiResource = value?.ToString() ?? "";
        }
    }

    public partial class FutureMultiResource
    {
        /// <summary>
        /// <see cref="tr::FutureMultiResourceName"/>-typed view over the <see cref="Name"/> resource name property.
        /// </summary>
        public tr::FutureMultiResourceName FutureMultiResourceName
        {
            get => string.IsNullOrEmpty(Name) ? null : tr::FutureMultiResourceName.Parse(Name);
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
        /// <see cref="OriginallySingleResourceName"/>-typed view over the <see cref="Resource2"/> resource name
        /// property.
        /// </summary>
        public OriginallySingleResourceName Resource2AsOriginallySingleResourceName
        {
            get => string.IsNullOrEmpty(Resource2) ? null : OriginallySingleResourceName.Parse(Resource2);
            set => Resource2 = value?.ToString() ?? "";
        }
    }
}
