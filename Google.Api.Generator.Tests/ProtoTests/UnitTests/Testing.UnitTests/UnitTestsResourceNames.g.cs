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
using tu = Testing.UnitTests;

namespace Testing.UnitTests
{
    /// <summary>Resource name for the <c>AResource</c> resource.</summary>
    public sealed partial class AResourceName : gax::IResourceName, sys::IEquatable<AResourceName>
    {
        /// <summary>The possible contents of <see cref="AResourceName"/>.</summary>
        public enum ResourceNameType
        {
            /// <summary>An unparsed resource name.</summary>
            Unparsed = 0,

            /// <summary>A resource name with pattern <c>items/{item_id}/parts/{part_id}</c>.</summary>
            ItemPart = 1
        }

        private static gax::PathTemplate s_itemPart = new gax::PathTemplate("items/{item_id}/parts/{part_id}");

        /// <summary>Creates a <see cref="AResourceName"/> containing an unparsed resource name.</summary>
        /// <param name="unparsedResourceName">The unparsed resource name. Must not be <c>null</c>.</param>
        /// <returns>
        /// A new instance of <see cref="AResourceName"/> containing the provided
        /// <paramref name="unparsedResourceName"/>.
        /// </returns>
        public static AResourceName FromUnparsed(gax::UnparsedResourceName unparsedResourceName) =>
            new AResourceName(ResourceNameType.Unparsed, gax::GaxPreconditions.CheckNotNull(unparsedResourceName, nameof(unparsedResourceName)));

        /// <summary>
        /// Creates a <see cref="AResourceName"/> with the pattern <c>items/{item_id}/parts/{part_id}</c>.
        /// </summary>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="partId">The <c>Part</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="AResourceName"/> constructed from the provided ids.</returns>
        public static AResourceName FromItemPart(string itemId, string partId) =>
            new AResourceName(ResourceNameType.ItemPart, itemId: gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)), partId: gax::GaxPreconditions.CheckNotNullOrEmpty(partId, nameof(partId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="AResourceName"/> with pattern
        /// <c>items/{item_id}/parts/{part_id}</c>.
        /// </summary>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="partId">The <c>Part</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="AResourceName"/> with pattern
        /// <c>items/{item_id}/parts/{part_id}</c>.
        /// </returns>
        public static string Format(string itemId, string partId) => FormatItemPart(itemId, partId);

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="AResourceName"/> with pattern
        /// <c>items/{item_id}/parts/{part_id}</c>.
        /// </summary>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="partId">The <c>Part</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="AResourceName"/> with pattern
        /// <c>items/{item_id}/parts/{part_id}</c>.
        /// </returns>
        public static string FormatItemPart(string itemId, string partId) =>
            s_itemPart.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)), gax::GaxPreconditions.CheckNotNullOrEmpty(partId, nameof(partId)));

        /// <summary>Parses the given resource name string into a new <see cref="AResourceName"/> instance.</summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>items/{item_id}/parts/{part_id}</c></description></item></list>
        /// </remarks>
        /// <param name="aResourceName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="AResourceName"/> if successful.</returns>
        public static AResourceName Parse(string aResourceName) => Parse(aResourceName, false);

        /// <summary>
        /// Parses the given resource name string into a new <see cref="AResourceName"/> instance; optionally allowing
        /// an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>items/{item_id}/parts/{part_id}</c></description></item></list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="aResourceName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <returns>The parsed <see cref="AResourceName"/> if successful.</returns>
        public static AResourceName Parse(string aResourceName, bool allowUnparsed) =>
            TryParse(aResourceName, allowUnparsed, out AResourceName result) ? result : throw new sys::ArgumentException("The given resource-name matches no pattern.");

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="AResourceName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>items/{item_id}/parts/{part_id}</c></description></item></list>
        /// </remarks>
        /// <param name="aResourceName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="AResourceName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string aResourceName, out AResourceName result) => TryParse(aResourceName, false, out result);

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="AResourceName"/> instance; optionally
        /// allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>items/{item_id}/parts/{part_id}</c></description></item></list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="aResourceName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="AResourceName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string aResourceName, bool allowUnparsed, out AResourceName result)
        {
            gax::GaxPreconditions.CheckNotNull(aResourceName, nameof(aResourceName));
            gax::TemplatedResourceName resourceName;
            if (s_itemPart.TryParseName(aResourceName, out resourceName))
            {
                result = FromItemPart(resourceName[0], resourceName[1]);
                return true;
            }
            if (allowUnparsed)
            {
                if (gax::UnparsedResourceName.TryParse(aResourceName, out gax::UnparsedResourceName unparsedResourceName))
                {
                    result = FromUnparsed(unparsedResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        private AResourceName(ResourceNameType type, gax::UnparsedResourceName unparsedResourceName = null, string itemId = null, string partId = null)
        {
            Type = type;
            UnparsedResource = unparsedResourceName;
            ItemId = itemId;
            PartId = partId;
        }

        /// <summary>
        /// Constructs a new instance of a <see cref="AResourceName"/> class from the component parts of pattern
        /// <c>items/{item_id}/parts/{part_id}</c>
        /// </summary>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="partId">The <c>Part</c> ID. Must not be <c>null</c> or empty.</param>
        public AResourceName(string itemId, string partId) : this(ResourceNameType.ItemPart, itemId: gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)), partId: gax::GaxPreconditions.CheckNotNullOrEmpty(partId, nameof(partId)))
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

        /// <summary>
        /// The <c>Part</c> ID. Will not be <c>null</c>, unless this instance contains an unparsed resource name.
        /// </summary>
        public string PartId { get; }

        /// <inheritdoc/>
        public bool IsKnownPattern => Type != ResourceNameType.Unparsed;

        /// <inheritdoc/>
        public override string ToString()
        {
            switch (Type)
            {
                case ResourceNameType.Unparsed: return UnparsedResource.ToString();
                case ResourceNameType.ItemPart: return s_itemPart.Expand(ItemId, PartId);
                default: throw new sys::InvalidOperationException("Unrecognized resource-type.");
            }
        }

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as AResourceName);

        /// <inheritdoc/>
        public bool Equals(AResourceName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(AResourceName a, AResourceName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(AResourceName a, AResourceName b) => !(a == b);
    }

    /// <summary>Resource name for the <c>MultiPatternResource</c> resource.</summary>
    public sealed partial class MultiPatternResourceName : gax::IResourceName, sys::IEquatable<MultiPatternResourceName>
    {
        /// <summary>The possible contents of <see cref="MultiPatternResourceName"/>.</summary>
        public enum ResourceNameType
        {
            /// <summary>An unparsed resource name.</summary>
            Unparsed = 0,

            /// <summary>A resource name with pattern <c>root/{root_a_id}/items/{item_id}</c>.</summary>
            RootAItem = 1,

            /// <summary>A resource name with pattern <c>root/{root_b_id}/items/{item_id}</c>.</summary>
            RootBItem = 2
        }

        private static gax::PathTemplate s_rootAItem = new gax::PathTemplate("root/{root_a_id}/items/{item_id}");

        private static gax::PathTemplate s_rootBItem = new gax::PathTemplate("root/{root_b_id}/items/{item_id}");

        /// <summary>Creates a <see cref="MultiPatternResourceName"/> containing an unparsed resource name.</summary>
        /// <param name="unparsedResourceName">The unparsed resource name. Must not be <c>null</c>.</param>
        /// <returns>
        /// A new instance of <see cref="MultiPatternResourceName"/> containing the provided
        /// <paramref name="unparsedResourceName"/>.
        /// </returns>
        public static MultiPatternResourceName FromUnparsed(gax::UnparsedResourceName unparsedResourceName) =>
            new MultiPatternResourceName(ResourceNameType.Unparsed, gax::GaxPreconditions.CheckNotNull(unparsedResourceName, nameof(unparsedResourceName)));

        /// <summary>
        /// Creates a <see cref="MultiPatternResourceName"/> with the pattern <c>root/{root_a_id}/items/{item_id}</c>.
        /// </summary>
        /// <param name="rootAId">The <c>RootA</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// A new instance of <see cref="MultiPatternResourceName"/> constructed from the provided ids.
        /// </returns>
        public static MultiPatternResourceName FromRootAItem(string rootAId, string itemId) =>
            new MultiPatternResourceName(ResourceNameType.RootAItem, rootAId: gax::GaxPreconditions.CheckNotNullOrEmpty(rootAId, nameof(rootAId)), itemId: gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Creates a <see cref="MultiPatternResourceName"/> with the pattern <c>root/{root_b_id}/items/{item_id}</c>.
        /// </summary>
        /// <param name="rootBId">The <c>RootB</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// A new instance of <see cref="MultiPatternResourceName"/> constructed from the provided ids.
        /// </returns>
        public static MultiPatternResourceName FromRootBItem(string rootBId, string itemId) =>
            new MultiPatternResourceName(ResourceNameType.RootBItem, rootBId: gax::GaxPreconditions.CheckNotNullOrEmpty(rootBId, nameof(rootBId)), itemId: gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="MultiPatternResourceName"/> with pattern
        /// <c>root/{root_a_id}/items/{item_id}</c>.
        /// </summary>
        /// <param name="rootAId">The <c>RootA</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="MultiPatternResourceName"/> with pattern
        /// <c>root/{root_a_id}/items/{item_id}</c>.
        /// </returns>
        public static string Format(string rootAId, string itemId) => FormatRootAItem(rootAId, itemId);

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="MultiPatternResourceName"/> with pattern
        /// <c>root/{root_a_id}/items/{item_id}</c>.
        /// </summary>
        /// <param name="rootAId">The <c>RootA</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="MultiPatternResourceName"/> with pattern
        /// <c>root/{root_a_id}/items/{item_id}</c>.
        /// </returns>
        public static string FormatRootAItem(string rootAId, string itemId) =>
            s_rootAItem.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(rootAId, nameof(rootAId)), gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="MultiPatternResourceName"/> with pattern
        /// <c>root/{root_b_id}/items/{item_id}</c>.
        /// </summary>
        /// <param name="rootBId">The <c>RootB</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="MultiPatternResourceName"/> with pattern
        /// <c>root/{root_b_id}/items/{item_id}</c>.
        /// </returns>
        public static string FormatRootBItem(string rootBId, string itemId) =>
            s_rootBItem.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(rootBId, nameof(rootBId)), gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Parses the given resource name string into a new <see cref="MultiPatternResourceName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>root/{root_a_id}/items/{item_id}</c></description></item>
        /// <item><description><c>root/{root_b_id}/items/{item_id}</c></description></item>
        /// </list>
        /// </remarks>
        /// <param name="multiPatternResourceName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="MultiPatternResourceName"/> if successful.</returns>
        public static MultiPatternResourceName Parse(string multiPatternResourceName) =>
            Parse(multiPatternResourceName, false);

        /// <summary>
        /// Parses the given resource name string into a new <see cref="MultiPatternResourceName"/> instance; optionally
        /// allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>root/{root_a_id}/items/{item_id}</c></description></item>
        /// <item><description><c>root/{root_b_id}/items/{item_id}</c></description></item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="multiPatternResourceName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <returns>The parsed <see cref="MultiPatternResourceName"/> if successful.</returns>
        public static MultiPatternResourceName Parse(string multiPatternResourceName, bool allowUnparsed) =>
            TryParse(multiPatternResourceName, allowUnparsed, out MultiPatternResourceName result) ? result : throw new sys::ArgumentException("The given resource-name matches no pattern.");

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="MultiPatternResourceName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>root/{root_a_id}/items/{item_id}</c></description></item>
        /// <item><description><c>root/{root_b_id}/items/{item_id}</c></description></item>
        /// </list>
        /// </remarks>
        /// <param name="multiPatternResourceName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="MultiPatternResourceName"/>, or <c>null</c> if parsing
        /// failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string multiPatternResourceName, out MultiPatternResourceName result) =>
            TryParse(multiPatternResourceName, false, out result);

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="MultiPatternResourceName"/> instance;
        /// optionally allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>root/{root_a_id}/items/{item_id}</c></description></item>
        /// <item><description><c>root/{root_b_id}/items/{item_id}</c></description></item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="multiPatternResourceName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="MultiPatternResourceName"/>, or <c>null</c> if parsing
        /// failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string multiPatternResourceName, bool allowUnparsed, out MultiPatternResourceName result)
        {
            gax::GaxPreconditions.CheckNotNull(multiPatternResourceName, nameof(multiPatternResourceName));
            gax::TemplatedResourceName resourceName;
            if (s_rootAItem.TryParseName(multiPatternResourceName, out resourceName))
            {
                result = FromRootAItem(resourceName[0], resourceName[1]);
                return true;
            }
            if (s_rootBItem.TryParseName(multiPatternResourceName, out resourceName))
            {
                result = FromRootBItem(resourceName[0], resourceName[1]);
                return true;
            }
            if (allowUnparsed)
            {
                if (gax::UnparsedResourceName.TryParse(multiPatternResourceName, out gax::UnparsedResourceName unparsedResourceName))
                {
                    result = FromUnparsed(unparsedResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        private MultiPatternResourceName(ResourceNameType type, gax::UnparsedResourceName unparsedResourceName = null, string itemId = null, string rootAId = null, string rootBId = null)
        {
            Type = type;
            UnparsedResource = unparsedResourceName;
            ItemId = itemId;
            RootAId = rootAId;
            RootBId = rootBId;
        }

        /// <summary>
        /// Constructs a new instance of a <see cref="MultiPatternResourceName"/> class from the component parts of
        /// pattern <c>root/{root_a_id}/items/{item_id}</c>
        /// </summary>
        /// <param name="rootAId">The <c>RootA</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        public MultiPatternResourceName(string rootAId, string itemId) : this(ResourceNameType.RootAItem, rootAId: gax::GaxPreconditions.CheckNotNullOrEmpty(rootAId, nameof(rootAId)), itemId: gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)))
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
        public override bool Equals(object obj) => Equals(obj as MultiPatternResourceName);

        /// <inheritdoc/>
        public bool Equals(MultiPatternResourceName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(MultiPatternResourceName a, MultiPatternResourceName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(MultiPatternResourceName a, MultiPatternResourceName b) => !(a == b);
    }

    public partial class AResource
    {
        /// <summary>
        /// <see cref="tu::AResourceName"/>-typed view over the <see cref="Name"/> resource name property.
        /// </summary>
        public tu::AResourceName AResourceName
        {
            get => string.IsNullOrEmpty(Name) ? null : tu::AResourceName.Parse(Name);
            set => Name = value?.ToString() ?? "";
        }
    }

    public partial class WildcardResource
    {
        /// <summary>
        /// <see cref="gax::IResourceName"/>-typed view over the <see cref="Name"/> resource name property.
        /// </summary>
        public gax::IResourceName AsResourceName
        {
            get => string.IsNullOrEmpty(Name) ? null : gax::UnparsedResourceName.Parse(Name);
            set => Name = value?.ToString() ?? "";
        }
    }

    public partial class MultiPatternResource
    {
        /// <summary>
        /// <see cref="tu::MultiPatternResourceName"/>-typed view over the <see cref="Name"/> resource name property.
        /// </summary>
        public tu::MultiPatternResourceName MultiPatternResourceName
        {
            get => string.IsNullOrEmpty(Name) ? null : tu::MultiPatternResourceName.Parse(Name);
            set => Name = value?.ToString() ?? "";
        }
    }

    public partial class ValuesRequest
    {
        /// <summary>
        /// <see cref="AResourceName"/>-typed view over the <see cref="SingleResourceName"/> resource name property.
        /// </summary>
        public AResourceName SingleResourceNameAsAResourceName
        {
            get => string.IsNullOrEmpty(SingleResourceName) ? null : AResourceName.Parse(SingleResourceName);
            set => SingleResourceName = value?.ToString() ?? "";
        }

        /// <summary>
        /// <see cref="AResourceName"/>-typed view over the <see cref="RepeatedResourceName"/> resource name property.
        /// </summary>
        public gax::ResourceNameList<AResourceName> RepeatedResourceNameAsAResourceNames
        {
            get => new gax::ResourceNameList<AResourceName>(RepeatedResourceName, s => AResourceName.Parse(s));
        }

        /// <summary>
        /// <see cref="gax::IResourceName"/>-typed view over the <see cref="SingleWildcardResource"/> resource name
        /// property.
        /// </summary>
        public gax::IResourceName SingleWildcardResourceAsResourceName
        {
            get => string.IsNullOrEmpty(SingleWildcardResource) ? null : gax::UnparsedResourceName.Parse(SingleWildcardResource);
            set => SingleWildcardResource = value?.ToString() ?? "";
        }

        /// <summary>
        /// <see cref="gax::IResourceName"/>-typed view over the <see cref="RepeatedWildcardResource"/> resource name
        /// property.
        /// </summary>
        public gax::ResourceNameList<gax::IResourceName> RepeatedWildcardResourceAsResourceNames
        {
            get => new gax::ResourceNameList<gax::IResourceName>(RepeatedWildcardResource, s => gax::UnparsedResourceName.Parse(s));
        }

        /// <summary>
        /// <see cref="tu::MultiPatternResourceName"/>-typed view over the <see cref="MultiPatternResourceName"/>
        /// resource name property.
        /// </summary>
        public tu::MultiPatternResourceName MultiPatternResourceNameAsMultiPatternResourceName
        {
            get => string.IsNullOrEmpty(MultiPatternResourceName) ? null : tu::MultiPatternResourceName.Parse(MultiPatternResourceName);
            set => MultiPatternResourceName = value?.ToString() ?? "";
        }

        /// <summary>
        /// <see cref="tu::MultiPatternResourceName"/>-typed view over the
        /// <see cref="RepeatedMultiPatternResourceName"/> resource name property.
        /// </summary>
        public gax::ResourceNameList<tu::MultiPatternResourceName> RepeatedMultiPatternResourceNameAsMultiPatternResourceNames
        {
            get => new gax::ResourceNameList<tu::MultiPatternResourceName>(RepeatedMultiPatternResourceName, s => tu::MultiPatternResourceName.Parse(s));
        }
    }
}
