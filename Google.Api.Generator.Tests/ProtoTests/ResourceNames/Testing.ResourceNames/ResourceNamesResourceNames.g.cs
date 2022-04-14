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
    /// <summary>Resource name for the <c>SinglePattern</c> resource.</summary>
    public sealed partial class SinglePatternName : gax::IResourceName, sys::IEquatable<SinglePatternName>
    {
        /// <summary>The possible contents of <see cref="SinglePatternName"/>.</summary>
        public enum ResourceNameType
        {
            /// <summary>An unparsed resource name.</summary>
            Unparsed = 0,

            /// <summary>A resource name with pattern <c>items/{item_id}</c>.</summary>
            Item = 1,
        }

        private static gax::PathTemplate s_item = new gax::PathTemplate("items/{item_id}");

        /// <summary>Creates a <see cref="SinglePatternName"/> containing an unparsed resource name.</summary>
        /// <param name="unparsedResourceName">The unparsed resource name. Must not be <c>null</c>.</param>
        /// <returns>
        /// A new instance of <see cref="SinglePatternName"/> containing the provided
        /// <paramref name="unparsedResourceName"/>.
        /// </returns>
        public static SinglePatternName FromUnparsed(gax::UnparsedResourceName unparsedResourceName) =>
            new SinglePatternName(ResourceNameType.Unparsed, gax::GaxPreconditions.CheckNotNull(unparsedResourceName, nameof(unparsedResourceName)));

        /// <summary>Creates a <see cref="SinglePatternName"/> with the pattern <c>items/{item_id}</c>.</summary>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="SinglePatternName"/> constructed from the provided ids.</returns>
        public static SinglePatternName FromItem(string itemId) =>
            new SinglePatternName(ResourceNameType.Item, itemId: gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="SinglePatternName"/> with pattern
        /// <c>items/{item_id}</c>.
        /// </summary>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="SinglePatternName"/> with pattern <c>items/{item_id}</c>.
        /// </returns>
        public static string Format(string itemId) => FormatItem(itemId);

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="SinglePatternName"/> with pattern
        /// <c>items/{item_id}</c>.
        /// </summary>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="SinglePatternName"/> with pattern <c>items/{item_id}</c>.
        /// </returns>
        public static string FormatItem(string itemId) =>
            s_item.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Parses the given resource name string into a new <see cref="SinglePatternName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>items/{item_id}</c></description></item></list>
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
        /// <list type="bullet"><item><description><c>items/{item_id}</c></description></item></list>
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
        /// <list type="bullet"><item><description><c>items/{item_id}</c></description></item></list>
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
        /// <list type="bullet"><item><description><c>items/{item_id}</c></description></item></list>
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
            if (s_item.TryParseName(singlePatternName, out resourceName))
            {
                result = FromItem(resourceName[0]);
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

        private SinglePatternName(ResourceNameType type, gax::UnparsedResourceName unparsedResourceName = null, string itemId = null)
        {
            Type = type;
            UnparsedResource = unparsedResourceName;
            ItemId = itemId;
        }

        /// <summary>
        /// Constructs a new instance of a <see cref="SinglePatternName"/> class from the component parts of pattern
        /// <c>items/{item_id}</c>
        /// </summary>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        public SinglePatternName(string itemId) : this(ResourceNameType.Item, itemId: gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)))
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

        /// <summary>Whether this instance contains a resource name with a known pattern.</summary>
        public bool IsKnownPattern => Type != ResourceNameType.Unparsed;

        /// <summary>The string representation of the resource name.</summary>
        /// <returns>The string representation of the resource name.</returns>
        public override string ToString()
        {
            switch (Type)
            {
                case ResourceNameType.Unparsed: return UnparsedResource.ToString();
                case ResourceNameType.Item: return s_item.Expand(ItemId);
                default: throw new sys::InvalidOperationException("Unrecognized resource-type.");
            }
        }

        /// <summary>Returns a hash code for this resource name.</summary>
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

    /// <summary>Resource name for the <c>DeprecatedPattern</c> resource.</summary>
    public sealed partial class DeprecatedPatternName : gax::IResourceName, sys::IEquatable<DeprecatedPatternName>
    {
        /// <summary>The possible contents of <see cref="DeprecatedPatternName"/>.</summary>
        public enum ResourceNameType
        {
            /// <summary>An unparsed resource name.</summary>
            Unparsed = 0,

            /// <summary>A resource name with pattern <c>items/{item_id}</c>.</summary>
            Item = 1,
        }

        private static gax::PathTemplate s_item = new gax::PathTemplate("items/{item_id}");

        /// <summary>Creates a <see cref="DeprecatedPatternName"/> containing an unparsed resource name.</summary>
        /// <param name="unparsedResourceName">The unparsed resource name. Must not be <c>null</c>.</param>
        /// <returns>
        /// A new instance of <see cref="DeprecatedPatternName"/> containing the provided
        /// <paramref name="unparsedResourceName"/>.
        /// </returns>
        public static DeprecatedPatternName FromUnparsed(gax::UnparsedResourceName unparsedResourceName) =>
            new DeprecatedPatternName(ResourceNameType.Unparsed, gax::GaxPreconditions.CheckNotNull(unparsedResourceName, nameof(unparsedResourceName)));

        /// <summary>Creates a <see cref="DeprecatedPatternName"/> with the pattern <c>items/{item_id}</c>.</summary>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="DeprecatedPatternName"/> constructed from the provided ids.</returns>
        public static DeprecatedPatternName FromItem(string itemId) =>
            new DeprecatedPatternName(ResourceNameType.Item, itemId: gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="DeprecatedPatternName"/> with pattern
        /// <c>items/{item_id}</c>.
        /// </summary>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="DeprecatedPatternName"/> with pattern <c>items/{item_id}</c>.
        /// </returns>
        public static string Format(string itemId) => FormatItem(itemId);

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="DeprecatedPatternName"/> with pattern
        /// <c>items/{item_id}</c>.
        /// </summary>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="DeprecatedPatternName"/> with pattern <c>items/{item_id}</c>.
        /// </returns>
        public static string FormatItem(string itemId) =>
            s_item.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Parses the given resource name string into a new <see cref="DeprecatedPatternName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>items/{item_id}</c></description></item></list>
        /// </remarks>
        /// <param name="deprecatedPatternName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="DeprecatedPatternName"/> if successful.</returns>
        public static DeprecatedPatternName Parse(string deprecatedPatternName) => Parse(deprecatedPatternName, false);

        /// <summary>
        /// Parses the given resource name string into a new <see cref="DeprecatedPatternName"/> instance; optionally
        /// allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>items/{item_id}</c></description></item></list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="deprecatedPatternName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <returns>The parsed <see cref="DeprecatedPatternName"/> if successful.</returns>
        public static DeprecatedPatternName Parse(string deprecatedPatternName, bool allowUnparsed) =>
            TryParse(deprecatedPatternName, allowUnparsed, out DeprecatedPatternName result) ? result : throw new sys::ArgumentException("The given resource-name matches no pattern.");

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="DeprecatedPatternName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>items/{item_id}</c></description></item></list>
        /// </remarks>
        /// <param name="deprecatedPatternName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="DeprecatedPatternName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string deprecatedPatternName, out DeprecatedPatternName result) =>
            TryParse(deprecatedPatternName, false, out result);

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="DeprecatedPatternName"/> instance;
        /// optionally allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>items/{item_id}</c></description></item></list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="deprecatedPatternName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="DeprecatedPatternName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string deprecatedPatternName, bool allowUnparsed, out DeprecatedPatternName result)
        {
            gax::GaxPreconditions.CheckNotNull(deprecatedPatternName, nameof(deprecatedPatternName));
            gax::TemplatedResourceName resourceName;
            if (s_item.TryParseName(deprecatedPatternName, out resourceName))
            {
                result = FromItem(resourceName[0]);
                return true;
            }
            if (allowUnparsed)
            {
                if (gax::UnparsedResourceName.TryParse(deprecatedPatternName, out gax::UnparsedResourceName unparsedResourceName))
                {
                    result = FromUnparsed(unparsedResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        private DeprecatedPatternName(ResourceNameType type, gax::UnparsedResourceName unparsedResourceName = null, string itemId = null)
        {
            Type = type;
            UnparsedResource = unparsedResourceName;
            ItemId = itemId;
        }

        /// <summary>
        /// Constructs a new instance of a <see cref="DeprecatedPatternName"/> class from the component parts of pattern
        /// <c>items/{item_id}</c>
        /// </summary>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        public DeprecatedPatternName(string itemId) : this(ResourceNameType.Item, itemId: gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)))
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

        /// <summary>Whether this instance contains a resource name with a known pattern.</summary>
        public bool IsKnownPattern => Type != ResourceNameType.Unparsed;

        /// <summary>The string representation of the resource name.</summary>
        /// <returns>The string representation of the resource name.</returns>
        public override string ToString()
        {
            switch (Type)
            {
                case ResourceNameType.Unparsed: return UnparsedResource.ToString();
                case ResourceNameType.Item: return s_item.Expand(ItemId);
                default: throw new sys::InvalidOperationException("Unrecognized resource-type.");
            }
        }

        /// <summary>Returns a hash code for this resource name.</summary>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as DeprecatedPatternName);

        /// <inheritdoc/>
        public bool Equals(DeprecatedPatternName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(DeprecatedPatternName a, DeprecatedPatternName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(DeprecatedPatternName a, DeprecatedPatternName b) => !(a == b);
    }

    /// <summary>Resource name for the <c>WildcardMultiPattern</c> resource.</summary>
    public sealed partial class WildcardMultiPatternName : gax::IResourceName, sys::IEquatable<WildcardMultiPatternName>
    {
        /// <summary>The possible contents of <see cref="WildcardMultiPatternName"/>.</summary>
        public enum ResourceNameType
        {
            /// <summary>An unparsed resource name.</summary>
            Unparsed = 0,

            /// <summary>A resource name with pattern <c>singular_item</c>.</summary>
            SingularItem = 1,
        }

        private static gax::PathTemplate s_singularItem = new gax::PathTemplate("singular_item");

        /// <summary>Creates a <see cref="WildcardMultiPatternName"/> containing an unparsed resource name.</summary>
        /// <param name="unparsedResourceName">The unparsed resource name. Must not be <c>null</c>.</param>
        /// <returns>
        /// A new instance of <see cref="WildcardMultiPatternName"/> containing the provided
        /// <paramref name="unparsedResourceName"/>.
        /// </returns>
        public static WildcardMultiPatternName FromUnparsed(gax::UnparsedResourceName unparsedResourceName) =>
            new WildcardMultiPatternName(ResourceNameType.Unparsed, gax::GaxPreconditions.CheckNotNull(unparsedResourceName, nameof(unparsedResourceName)));

        /// <summary>Creates a <see cref="WildcardMultiPatternName"/> with the pattern <c>singular_item</c>.</summary>
        /// <returns>
        /// A new instance of <see cref="WildcardMultiPatternName"/> constructed from the provided ids.
        /// </returns>
        public static WildcardMultiPatternName FromSingularItem() =>
            new WildcardMultiPatternName(ResourceNameType.SingularItem);

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="WildcardMultiPatternName"/> with pattern
        /// <c>singular_item</c>.
        /// </summary>
        /// <returns>
        /// The string representation of this <see cref="WildcardMultiPatternName"/> with pattern <c>singular_item</c>.
        /// </returns>
        public static string Format() => FormatSingularItem();

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="WildcardMultiPatternName"/> with pattern
        /// <c>singular_item</c>.
        /// </summary>
        /// <returns>
        /// The string representation of this <see cref="WildcardMultiPatternName"/> with pattern <c>singular_item</c>.
        /// </returns>
        public static string FormatSingularItem() => s_singularItem.Expand();

        /// <summary>
        /// Parses the given resource name string into a new <see cref="WildcardMultiPatternName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>singular_item</c></description></item></list>
        /// </remarks>
        /// <param name="wildcardMultiPatternName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="WildcardMultiPatternName"/> if successful.</returns>
        public static WildcardMultiPatternName Parse(string wildcardMultiPatternName) =>
            Parse(wildcardMultiPatternName, false);

        /// <summary>
        /// Parses the given resource name string into a new <see cref="WildcardMultiPatternName"/> instance; optionally
        /// allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>singular_item</c></description></item></list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="wildcardMultiPatternName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <returns>The parsed <see cref="WildcardMultiPatternName"/> if successful.</returns>
        public static WildcardMultiPatternName Parse(string wildcardMultiPatternName, bool allowUnparsed) =>
            TryParse(wildcardMultiPatternName, allowUnparsed, out WildcardMultiPatternName result) ? result : throw new sys::ArgumentException("The given resource-name matches no pattern.");

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="WildcardMultiPatternName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>singular_item</c></description></item></list>
        /// </remarks>
        /// <param name="wildcardMultiPatternName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="WildcardMultiPatternName"/>, or <c>null</c> if parsing
        /// failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string wildcardMultiPatternName, out WildcardMultiPatternName result) =>
            TryParse(wildcardMultiPatternName, false, out result);

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="WildcardMultiPatternName"/> instance;
        /// optionally allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>singular_item</c></description></item></list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="wildcardMultiPatternName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="WildcardMultiPatternName"/>, or <c>null</c> if parsing
        /// failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string wildcardMultiPatternName, bool allowUnparsed, out WildcardMultiPatternName result)
        {
            gax::GaxPreconditions.CheckNotNull(wildcardMultiPatternName, nameof(wildcardMultiPatternName));
            gax::TemplatedResourceName resourceName;
            if (s_singularItem.TryParseName(wildcardMultiPatternName, out resourceName))
            {
                result = FromSingularItem();
                return true;
            }
            if (allowUnparsed)
            {
                if (gax::UnparsedResourceName.TryParse(wildcardMultiPatternName, out gax::UnparsedResourceName unparsedResourceName))
                {
                    result = FromUnparsed(unparsedResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        private WildcardMultiPatternName(ResourceNameType type, gax::UnparsedResourceName unparsedResourceName = null)
        {
            Type = type;
            UnparsedResource = unparsedResourceName;
        }

        /// <summary>
        /// Constructs a new instance of a <see cref="WildcardMultiPatternName"/> class from the component parts of
        /// pattern <c>singular_item</c>
        /// </summary>
        public WildcardMultiPatternName() : this(ResourceNameType.SingularItem)
        {
        }

        /// <summary>The <see cref="ResourceNameType"/> of the contained resource name.</summary>
        public ResourceNameType Type { get; }

        /// <summary>
        /// The contained <see cref="gax::UnparsedResourceName"/>. Only non-<c>null</c> if this instance contains an
        /// unparsed resource name.
        /// </summary>
        public gax::UnparsedResourceName UnparsedResource { get; }

        /// <summary>Whether this instance contains a resource name with a known pattern.</summary>
        public bool IsKnownPattern => Type != ResourceNameType.Unparsed;

        /// <summary>The string representation of the resource name.</summary>
        /// <returns>The string representation of the resource name.</returns>
        public override string ToString()
        {
            switch (Type)
            {
                case ResourceNameType.Unparsed: return UnparsedResource.ToString();
                case ResourceNameType.SingularItem: return s_singularItem.Expand();
                default: throw new sys::InvalidOperationException("Unrecognized resource-type.");
            }
        }

        /// <summary>Returns a hash code for this resource name.</summary>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as WildcardMultiPatternName);

        /// <inheritdoc/>
        public bool Equals(WildcardMultiPatternName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(WildcardMultiPatternName a, WildcardMultiPatternName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(WildcardMultiPatternName a, WildcardMultiPatternName b) => !(a == b);
    }

    /// <summary>Resource name for the <c>WildcardMultiPatternMultiple</c> resource.</summary>
    public sealed partial class WildcardMultiPatternMultipleName : gax::IResourceName, sys::IEquatable<WildcardMultiPatternMultipleName>
    {
        /// <summary>The possible contents of <see cref="WildcardMultiPatternMultipleName"/>.</summary>
        public enum ResourceNameType
        {
            /// <summary>An unparsed resource name.</summary>
            Unparsed = 0,

            /// <summary>A resource name with pattern <c>constPattern</c>.</summary>
            ConstPattern = 1,

            /// <summary>A resource name with pattern <c>_invalid-character-pattern_</c>.</summary>
            InvalidCharacterPattern = 2,

            /// <summary>A resource name with pattern <c>itemsA/{item_a_id}</c>.</summary>
            ItemA = 3,

            /// <summary>A resource name with pattern <c>itemsB/{item_b_id=*}</c>.</summary>
            ItemB = 4,

            /// <summary>A resource name with pattern <c>itemsC/{item_c_id=**}</c>.</summary>
            ItemC = 5,
        }

        private static gax::PathTemplate s_constPattern = new gax::PathTemplate("constPattern");

        private static gax::PathTemplate s_invalidCharacterPattern = new gax::PathTemplate("_invalid-character-pattern_");

        private static gax::PathTemplate s_itemA = new gax::PathTemplate("itemsA/{item_a_id}");

        private static gax::PathTemplate s_itemB = new gax::PathTemplate("itemsB/{item_b_id=*}");

        private static gax::PathTemplate s_itemC = new gax::PathTemplate("itemsC/{item_c_id=**}");

        /// <summary>
        /// Creates a <see cref="WildcardMultiPatternMultipleName"/> containing an unparsed resource name.
        /// </summary>
        /// <param name="unparsedResourceName">The unparsed resource name. Must not be <c>null</c>.</param>
        /// <returns>
        /// A new instance of <see cref="WildcardMultiPatternMultipleName"/> containing the provided
        /// <paramref name="unparsedResourceName"/>.
        /// </returns>
        public static WildcardMultiPatternMultipleName FromUnparsed(gax::UnparsedResourceName unparsedResourceName) =>
            new WildcardMultiPatternMultipleName(ResourceNameType.Unparsed, gax::GaxPreconditions.CheckNotNull(unparsedResourceName, nameof(unparsedResourceName)));

        /// <summary>
        /// Creates a <see cref="WildcardMultiPatternMultipleName"/> with the pattern <c>constPattern</c>.
        /// </summary>
        /// <returns>
        /// A new instance of <see cref="WildcardMultiPatternMultipleName"/> constructed from the provided ids.
        /// </returns>
        public static WildcardMultiPatternMultipleName FromConstPattern() =>
            new WildcardMultiPatternMultipleName(ResourceNameType.ConstPattern);

        /// <summary>
        /// Creates a <see cref="WildcardMultiPatternMultipleName"/> with the pattern <c>_invalid-character-pattern_</c>
        /// .
        /// </summary>
        /// <returns>
        /// A new instance of <see cref="WildcardMultiPatternMultipleName"/> constructed from the provided ids.
        /// </returns>
        public static WildcardMultiPatternMultipleName FromInvalidCharacterPattern() =>
            new WildcardMultiPatternMultipleName(ResourceNameType.InvalidCharacterPattern);

        /// <summary>
        /// Creates a <see cref="WildcardMultiPatternMultipleName"/> with the pattern <c>itemsA/{item_a_id}</c>.
        /// </summary>
        /// <param name="itemAId">The <c>ItemA</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// A new instance of <see cref="WildcardMultiPatternMultipleName"/> constructed from the provided ids.
        /// </returns>
        public static WildcardMultiPatternMultipleName FromItemA(string itemAId) =>
            new WildcardMultiPatternMultipleName(ResourceNameType.ItemA, itemAId: gax::GaxPreconditions.CheckNotNullOrEmpty(itemAId, nameof(itemAId)));

        /// <summary>
        /// Creates a <see cref="WildcardMultiPatternMultipleName"/> with the pattern <c>itemsB/{item_b_id=*}</c>.
        /// </summary>
        /// <param name="itemBId">The <c>ItemB</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// A new instance of <see cref="WildcardMultiPatternMultipleName"/> constructed from the provided ids.
        /// </returns>
        public static WildcardMultiPatternMultipleName FromItemB(string itemBId) =>
            new WildcardMultiPatternMultipleName(ResourceNameType.ItemB, itemBId: gax::GaxPreconditions.CheckNotNullOrEmpty(itemBId, nameof(itemBId)));

        /// <summary>
        /// Creates a <see cref="WildcardMultiPatternMultipleName"/> with the pattern <c>itemsC/{item_c_id=**}</c>.
        /// </summary>
        /// <param name="itemCId">The <c>ItemC</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// A new instance of <see cref="WildcardMultiPatternMultipleName"/> constructed from the provided ids.
        /// </returns>
        public static WildcardMultiPatternMultipleName FromItemC(string itemCId) =>
            new WildcardMultiPatternMultipleName(ResourceNameType.ItemC, itemCId: gax::GaxPreconditions.CheckNotNullOrEmpty(itemCId, nameof(itemCId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="WildcardMultiPatternMultipleName"/> with
        /// pattern <c>constPattern</c>.
        /// </summary>
        /// <returns>
        /// The string representation of this <see cref="WildcardMultiPatternMultipleName"/> with pattern
        /// <c>constPattern</c>.
        /// </returns>
        public static string Format() => FormatConstPattern();

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="WildcardMultiPatternMultipleName"/> with
        /// pattern <c>constPattern</c>.
        /// </summary>
        /// <returns>
        /// The string representation of this <see cref="WildcardMultiPatternMultipleName"/> with pattern
        /// <c>constPattern</c>.
        /// </returns>
        public static string FormatConstPattern() => s_constPattern.Expand();

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="WildcardMultiPatternMultipleName"/> with
        /// pattern <c>_invalid-character-pattern_</c>.
        /// </summary>
        /// <returns>
        /// The string representation of this <see cref="WildcardMultiPatternMultipleName"/> with pattern
        /// <c>_invalid-character-pattern_</c>.
        /// </returns>
        public static string FormatInvalidCharacterPattern() => s_invalidCharacterPattern.Expand();

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="WildcardMultiPatternMultipleName"/> with
        /// pattern <c>itemsA/{item_a_id}</c>.
        /// </summary>
        /// <param name="itemAId">The <c>ItemA</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="WildcardMultiPatternMultipleName"/> with pattern
        /// <c>itemsA/{item_a_id}</c>.
        /// </returns>
        public static string FormatItemA(string itemAId) =>
            s_itemA.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(itemAId, nameof(itemAId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="WildcardMultiPatternMultipleName"/> with
        /// pattern <c>itemsB/{item_b_id=*}</c>.
        /// </summary>
        /// <param name="itemBId">The <c>ItemB</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="WildcardMultiPatternMultipleName"/> with pattern
        /// <c>itemsB/{item_b_id=*}</c>.
        /// </returns>
        public static string FormatItemB(string itemBId) =>
            s_itemB.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(itemBId, nameof(itemBId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="WildcardMultiPatternMultipleName"/> with
        /// pattern <c>itemsC/{item_c_id=**}</c>.
        /// </summary>
        /// <param name="itemCId">The <c>ItemC</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="WildcardMultiPatternMultipleName"/> with pattern
        /// <c>itemsC/{item_c_id=**}</c>.
        /// </returns>
        public static string FormatItemC(string itemCId) =>
            s_itemC.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(itemCId, nameof(itemCId)));

        /// <summary>
        /// Parses the given resource name string into a new <see cref="WildcardMultiPatternMultipleName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>constPattern</c></description></item>
        /// <item><description><c>_invalid-character-pattern_</c></description></item>
        /// <item><description><c>itemsA/{item_a_id}</c></description></item>
        /// <item><description><c>itemsB/{item_b_id=*}</c></description></item>
        /// <item><description><c>itemsC/{item_c_id=**}</c></description></item>
        /// </list>
        /// </remarks>
        /// <param name="wildcardMultiPatternMultipleName">
        /// The resource name in string form. Must not be <c>null</c>.
        /// </param>
        /// <returns>The parsed <see cref="WildcardMultiPatternMultipleName"/> if successful.</returns>
        public static WildcardMultiPatternMultipleName Parse(string wildcardMultiPatternMultipleName) =>
            Parse(wildcardMultiPatternMultipleName, false);

        /// <summary>
        /// Parses the given resource name string into a new <see cref="WildcardMultiPatternMultipleName"/> instance;
        /// optionally allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>constPattern</c></description></item>
        /// <item><description><c>_invalid-character-pattern_</c></description></item>
        /// <item><description><c>itemsA/{item_a_id}</c></description></item>
        /// <item><description><c>itemsB/{item_b_id=*}</c></description></item>
        /// <item><description><c>itemsC/{item_c_id=**}</c></description></item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="wildcardMultiPatternMultipleName">
        /// The resource name in string form. Must not be <c>null</c>.
        /// </param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <returns>The parsed <see cref="WildcardMultiPatternMultipleName"/> if successful.</returns>
        public static WildcardMultiPatternMultipleName Parse(string wildcardMultiPatternMultipleName, bool allowUnparsed) =>
            TryParse(wildcardMultiPatternMultipleName, allowUnparsed, out WildcardMultiPatternMultipleName result) ? result : throw new sys::ArgumentException("The given resource-name matches no pattern.");

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="WildcardMultiPatternMultipleName"/>
        /// instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>constPattern</c></description></item>
        /// <item><description><c>_invalid-character-pattern_</c></description></item>
        /// <item><description><c>itemsA/{item_a_id}</c></description></item>
        /// <item><description><c>itemsB/{item_b_id=*}</c></description></item>
        /// <item><description><c>itemsC/{item_c_id=**}</c></description></item>
        /// </list>
        /// </remarks>
        /// <param name="wildcardMultiPatternMultipleName">
        /// The resource name in string form. Must not be <c>null</c>.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="WildcardMultiPatternMultipleName"/>, or <c>null</c> if
        /// parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string wildcardMultiPatternMultipleName, out WildcardMultiPatternMultipleName result) =>
            TryParse(wildcardMultiPatternMultipleName, false, out result);

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="WildcardMultiPatternMultipleName"/>
        /// instance; optionally allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>constPattern</c></description></item>
        /// <item><description><c>_invalid-character-pattern_</c></description></item>
        /// <item><description><c>itemsA/{item_a_id}</c></description></item>
        /// <item><description><c>itemsB/{item_b_id=*}</c></description></item>
        /// <item><description><c>itemsC/{item_c_id=**}</c></description></item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="wildcardMultiPatternMultipleName">
        /// The resource name in string form. Must not be <c>null</c>.
        /// </param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="WildcardMultiPatternMultipleName"/>, or <c>null</c> if
        /// parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string wildcardMultiPatternMultipleName, bool allowUnparsed, out WildcardMultiPatternMultipleName result)
        {
            gax::GaxPreconditions.CheckNotNull(wildcardMultiPatternMultipleName, nameof(wildcardMultiPatternMultipleName));
            gax::TemplatedResourceName resourceName;
            if (s_constPattern.TryParseName(wildcardMultiPatternMultipleName, out resourceName))
            {
                result = FromConstPattern();
                return true;
            }
            if (s_invalidCharacterPattern.TryParseName(wildcardMultiPatternMultipleName, out resourceName))
            {
                result = FromInvalidCharacterPattern();
                return true;
            }
            if (s_itemA.TryParseName(wildcardMultiPatternMultipleName, out resourceName))
            {
                result = FromItemA(resourceName[0]);
                return true;
            }
            if (s_itemB.TryParseName(wildcardMultiPatternMultipleName, out resourceName))
            {
                result = FromItemB(resourceName[0]);
                return true;
            }
            if (s_itemC.TryParseName(wildcardMultiPatternMultipleName, out resourceName))
            {
                result = FromItemC(resourceName[0]);
                return true;
            }
            if (allowUnparsed)
            {
                if (gax::UnparsedResourceName.TryParse(wildcardMultiPatternMultipleName, out gax::UnparsedResourceName unparsedResourceName))
                {
                    result = FromUnparsed(unparsedResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        private WildcardMultiPatternMultipleName(ResourceNameType type, gax::UnparsedResourceName unparsedResourceName = null, string itemAId = null, string itemBId = null, string itemCId = null)
        {
            Type = type;
            UnparsedResource = unparsedResourceName;
            ItemAId = itemAId;
            ItemBId = itemBId;
            ItemCId = itemCId;
        }

        /// <summary>The <see cref="ResourceNameType"/> of the contained resource name.</summary>
        public ResourceNameType Type { get; }

        /// <summary>
        /// The contained <see cref="gax::UnparsedResourceName"/>. Only non-<c>null</c> if this instance contains an
        /// unparsed resource name.
        /// </summary>
        public gax::UnparsedResourceName UnparsedResource { get; }

        /// <summary>
        /// The <c>ItemA</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string ItemAId { get; }

        /// <summary>
        /// The <c>ItemB</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string ItemBId { get; }

        /// <summary>
        /// The <c>ItemC</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string ItemCId { get; }

        /// <summary>Whether this instance contains a resource name with a known pattern.</summary>
        public bool IsKnownPattern => Type != ResourceNameType.Unparsed;

        /// <summary>The string representation of the resource name.</summary>
        /// <returns>The string representation of the resource name.</returns>
        public override string ToString()
        {
            switch (Type)
            {
                case ResourceNameType.Unparsed: return UnparsedResource.ToString();
                case ResourceNameType.ConstPattern: return s_constPattern.Expand();
                case ResourceNameType.InvalidCharacterPattern: return s_invalidCharacterPattern.Expand();
                case ResourceNameType.ItemA: return s_itemA.Expand(ItemAId);
                case ResourceNameType.ItemB: return s_itemB.Expand(ItemBId);
                case ResourceNameType.ItemC: return s_itemC.Expand(ItemCId);
                default: throw new sys::InvalidOperationException("Unrecognized resource-type.");
            }
        }

        /// <summary>Returns a hash code for this resource name.</summary>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as WildcardMultiPatternMultipleName);

        /// <inheritdoc/>
        public bool Equals(WildcardMultiPatternMultipleName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(WildcardMultiPatternMultipleName a, WildcardMultiPatternMultipleName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(WildcardMultiPatternMultipleName a, WildcardMultiPatternMultipleName b) => !(a == b);
    }

    /// <summary>Resource name for the <c>LooseValidationPattern</c> resource.</summary>
    public sealed partial class LooseValidationPatternName : gax::IResourceName, sys::IEquatable<LooseValidationPatternName>
    {
        /// <summary>The possible contents of <see cref="LooseValidationPatternName"/>.</summary>
        public enum ResourceNameType
        {
            /// <summary>An unparsed resource name.</summary>
            Unparsed = 0,

            /// <summary>A resource name with pattern <c>parents/{parent_id}/invalid_name/items/{item_id}</c>.</summary>
            ParentItem = 1,
        }

        private static gax::PathTemplate s_parentItem = new gax::PathTemplate("parents/{parent_id}/invalid_name/items/{item_id}");

        /// <summary>Creates a <see cref="LooseValidationPatternName"/> containing an unparsed resource name.</summary>
        /// <param name="unparsedResourceName">The unparsed resource name. Must not be <c>null</c>.</param>
        /// <returns>
        /// A new instance of <see cref="LooseValidationPatternName"/> containing the provided
        /// <paramref name="unparsedResourceName"/>.
        /// </returns>
        public static LooseValidationPatternName FromUnparsed(gax::UnparsedResourceName unparsedResourceName) =>
            new LooseValidationPatternName(ResourceNameType.Unparsed, gax::GaxPreconditions.CheckNotNull(unparsedResourceName, nameof(unparsedResourceName)));

        /// <summary>
        /// Creates a <see cref="LooseValidationPatternName"/> with the pattern
        /// <c>parents/{parent_id}/invalid_name/items/{item_id}</c>.
        /// </summary>
        /// <param name="parentId">The <c>Parent</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// A new instance of <see cref="LooseValidationPatternName"/> constructed from the provided ids.
        /// </returns>
        public static LooseValidationPatternName FromParentItem(string parentId, string itemId) =>
            new LooseValidationPatternName(ResourceNameType.ParentItem, parentId: gax::GaxPreconditions.CheckNotNullOrEmpty(parentId, nameof(parentId)), itemId: gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="LooseValidationPatternName"/> with pattern
        /// <c>parents/{parent_id}/invalid_name/items/{item_id}</c>.
        /// </summary>
        /// <param name="parentId">The <c>Parent</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="LooseValidationPatternName"/> with pattern
        /// <c>parents/{parent_id}/invalid_name/items/{item_id}</c>.
        /// </returns>
        public static string Format(string parentId, string itemId) => FormatParentItem(parentId, itemId);

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="LooseValidationPatternName"/> with pattern
        /// <c>parents/{parent_id}/invalid_name/items/{item_id}</c>.
        /// </summary>
        /// <param name="parentId">The <c>Parent</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="LooseValidationPatternName"/> with pattern
        /// <c>parents/{parent_id}/invalid_name/items/{item_id}</c>.
        /// </returns>
        public static string FormatParentItem(string parentId, string itemId) =>
            s_parentItem.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(parentId, nameof(parentId)), gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)));

        /// <summary>
        /// Parses the given resource name string into a new <see cref="LooseValidationPatternName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>parents/{parent_id}/invalid_name/items/{item_id}</c></description></item>
        /// </list>
        /// </remarks>
        /// <param name="looseValidationPatternName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="LooseValidationPatternName"/> if successful.</returns>
        public static LooseValidationPatternName Parse(string looseValidationPatternName) =>
            Parse(looseValidationPatternName, false);

        /// <summary>
        /// Parses the given resource name string into a new <see cref="LooseValidationPatternName"/> instance;
        /// optionally allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>parents/{parent_id}/invalid_name/items/{item_id}</c></description></item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="looseValidationPatternName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <returns>The parsed <see cref="LooseValidationPatternName"/> if successful.</returns>
        public static LooseValidationPatternName Parse(string looseValidationPatternName, bool allowUnparsed) =>
            TryParse(looseValidationPatternName, allowUnparsed, out LooseValidationPatternName result) ? result : throw new sys::ArgumentException("The given resource-name matches no pattern.");

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="LooseValidationPatternName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>parents/{parent_id}/invalid_name/items/{item_id}</c></description></item>
        /// </list>
        /// </remarks>
        /// <param name="looseValidationPatternName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="LooseValidationPatternName"/>, or <c>null</c> if parsing
        /// failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string looseValidationPatternName, out LooseValidationPatternName result) =>
            TryParse(looseValidationPatternName, false, out result);

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="LooseValidationPatternName"/> instance;
        /// optionally allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>parents/{parent_id}/invalid_name/items/{item_id}</c></description></item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="looseValidationPatternName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="LooseValidationPatternName"/>, or <c>null</c> if parsing
        /// failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string looseValidationPatternName, bool allowUnparsed, out LooseValidationPatternName result)
        {
            gax::GaxPreconditions.CheckNotNull(looseValidationPatternName, nameof(looseValidationPatternName));
            gax::TemplatedResourceName resourceName;
            if (s_parentItem.TryParseName(looseValidationPatternName, out resourceName))
            {
                result = FromParentItem(resourceName[0], resourceName[1]);
                return true;
            }
            if (allowUnparsed)
            {
                if (gax::UnparsedResourceName.TryParse(looseValidationPatternName, out gax::UnparsedResourceName unparsedResourceName))
                {
                    result = FromUnparsed(unparsedResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        private LooseValidationPatternName(ResourceNameType type, gax::UnparsedResourceName unparsedResourceName = null, string itemId = null, string parentId = null)
        {
            Type = type;
            UnparsedResource = unparsedResourceName;
            ItemId = itemId;
            ParentId = parentId;
        }

        /// <summary>
        /// Constructs a new instance of a <see cref="LooseValidationPatternName"/> class from the component parts of
        /// pattern <c>parents/{parent_id}/invalid_name/items/{item_id}</c>
        /// </summary>
        /// <param name="parentId">The <c>Parent</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c> or empty.</param>
        public LooseValidationPatternName(string parentId, string itemId) : this(ResourceNameType.ParentItem, parentId: gax::GaxPreconditions.CheckNotNullOrEmpty(parentId, nameof(parentId)), itemId: gax::GaxPreconditions.CheckNotNullOrEmpty(itemId, nameof(itemId)))
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
        /// The <c>Parent</c> ID. Will not be <c>null</c>, unless this instance contains an unparsed resource name.
        /// </summary>
        public string ParentId { get; }

        /// <summary>Whether this instance contains a resource name with a known pattern.</summary>
        public bool IsKnownPattern => Type != ResourceNameType.Unparsed;

        /// <summary>The string representation of the resource name.</summary>
        /// <returns>The string representation of the resource name.</returns>
        public override string ToString()
        {
            switch (Type)
            {
                case ResourceNameType.Unparsed: return UnparsedResource.ToString();
                case ResourceNameType.ParentItem: return s_parentItem.Expand(ParentId, ItemId);
                default: throw new sys::InvalidOperationException("Unrecognized resource-type.");
            }
        }

        /// <summary>Returns a hash code for this resource name.</summary>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as LooseValidationPatternName);

        /// <inheritdoc/>
        public bool Equals(LooseValidationPatternName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(LooseValidationPatternName a, LooseValidationPatternName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(LooseValidationPatternName a, LooseValidationPatternName b) => !(a == b);
    }

    public partial class SinglePattern
    {
        /// <summary>
        /// <see cref="SinglePatternName"/>-typed view over the <see cref="RealName"/> resource name property.
        /// </summary>
        public SinglePatternName RealNameAsSinglePatternName
        {
            get => string.IsNullOrEmpty(RealName) ? null : SinglePatternName.Parse(RealName, allowUnparsed: true);
            set => RealName = value?.ToString() ?? "";
        }

        /// <summary>
        /// <see cref="SinglePatternName"/>-typed view over the <see cref="Ref"/> resource name property.
        /// </summary>
        public SinglePatternName RefAsSinglePatternName
        {
            get => string.IsNullOrEmpty(Ref) ? null : SinglePatternName.Parse(Ref, allowUnparsed: true);
            set => Ref = value?.ToString() ?? "";
        }

        /// <summary>
        /// <see cref="SinglePatternName"/>-typed view over the <see cref="RepeatedRef"/> resource name property.
        /// </summary>
        public gax::ResourceNameList<SinglePatternName> RepeatedRefAsSinglePatternNames
        {
            get => new gax::ResourceNameList<SinglePatternName>(RepeatedRef, s => string.IsNullOrEmpty(s) ? null : SinglePatternName.Parse(s, allowUnparsed: true));
        }

        /// <summary>
        /// <see cref="SinglePatternName"/>-typed view over the <see cref="ValueRef"/> resource name property.
        /// </summary>
        public SinglePatternName ValueRefAsSinglePatternName
        {
            get => string.IsNullOrEmpty(ValueRef) ? null : SinglePatternName.Parse(ValueRef, allowUnparsed: true);
            set => ValueRef = value?.ToString() ?? "";
        }

        /// <summary>
        /// <see cref="SinglePatternName"/>-typed view over the <see cref="RepeatedValueRef"/> resource name property.
        /// </summary>
        public gax::ResourceNameList<SinglePatternName> RepeatedValueRefAsSinglePatternNames
        {
            get => new gax::ResourceNameList<SinglePatternName>(RepeatedValueRef, s => string.IsNullOrEmpty(s) ? null : SinglePatternName.Parse(s, allowUnparsed: true));
        }
    }

    public partial class DeprecatedPattern
    {
        /// <summary>
        /// <see cref="tr::DeprecatedPatternName"/>-typed view over the <see cref="Name"/> resource name property.
        /// </summary>
        [sys::ObsoleteAttribute]
        public tr::DeprecatedPatternName DeprecatedPatternName
        {
            get => string.IsNullOrEmpty(Name) ? null : tr::DeprecatedPatternName.Parse(Name, allowUnparsed: true);
            set => Name = value?.ToString() ?? "";
        }
    }

    public partial class WildcardOnlyPattern
    {
        /// <summary>
        /// <see cref="gax::IResourceName"/>-typed view over the <see cref="Name"/> resource name property.
        /// </summary>
        public gax::IResourceName ResourceName
        {
            get => string.IsNullOrEmpty(Name) ? null : gax::UnparsedResourceName.Parse(Name);
            set => Name = value?.ToString() ?? "";
        }

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

    public partial class WildcardMultiPattern
    {
        /// <summary>
        /// <see cref="tr::WildcardMultiPatternName"/>-typed view over the <see cref="Name"/> resource name property.
        /// </summary>
        public tr::WildcardMultiPatternName WildcardMultiPatternName
        {
            get => string.IsNullOrEmpty(Name) ? null : tr::WildcardMultiPatternName.Parse(Name, allowUnparsed: true);
            set => Name = value?.ToString() ?? "";
        }

        /// <summary>
        /// <see cref="gax::IResourceName"/>-typed view over the <see cref="Name"/> resource name property.
        /// </summary>
        public gax::IResourceName ResourceName
        {
            get
            {
                if (string.IsNullOrEmpty(Name))
                {
                    return null;
                }
                if (tr::WildcardMultiPatternName.TryParse(Name, out tr::WildcardMultiPatternName wildcardMultiPattern))
                {
                    return wildcardMultiPattern;
                }
                return gax::UnparsedResourceName.Parse(Name);
            }
            set => Name = value?.ToString() ?? "";
        }

        /// <summary>
        /// <see cref="tr::WildcardMultiPatternName"/>-typed view over the <see cref="Ref"/> resource name property.
        /// </summary>
        public tr::WildcardMultiPatternName RefAsWildcardMultiPatternName
        {
            get => string.IsNullOrEmpty(Ref) ? null : tr::WildcardMultiPatternName.Parse(Ref, allowUnparsed: true);
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
                if (tr::WildcardMultiPatternName.TryParse(Ref, out tr::WildcardMultiPatternName wildcardMultiPattern))
                {
                    return wildcardMultiPattern;
                }
                return gax::UnparsedResourceName.Parse(Ref);
            }
            set => Ref = value?.ToString() ?? "";
        }

        /// <summary>
        /// <see cref="tr::WildcardMultiPatternName"/>-typed view over the <see cref="RepeatedRef"/> resource name
        /// property.
        /// </summary>
        public gax::ResourceNameList<tr::WildcardMultiPatternName> RepeatedRefAsWildcardMultiPatternNames
        {
            get => new gax::ResourceNameList<tr::WildcardMultiPatternName>(RepeatedRef, s => string.IsNullOrEmpty(s) ? null : tr::WildcardMultiPatternName.Parse(s, allowUnparsed: true));
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
                if (tr::WildcardMultiPatternName.TryParse(s, out tr::WildcardMultiPatternName wildcardMultiPattern))
                {
                    return wildcardMultiPattern;
                }
                return gax::UnparsedResourceName.Parse(s);
            });
        }
    }

    public partial class WildcardMultiPatternMultiple
    {
        /// <summary>
        /// <see cref="tr::WildcardMultiPatternMultipleName"/>-typed view over the <see cref="Name"/> resource name
        /// property.
        /// </summary>
        public tr::WildcardMultiPatternMultipleName WildcardMultiPatternMultipleName
        {
            get => string.IsNullOrEmpty(Name) ? null : tr::WildcardMultiPatternMultipleName.Parse(Name, allowUnparsed: true);
            set => Name = value?.ToString() ?? "";
        }

        /// <summary>
        /// <see cref="gax::IResourceName"/>-typed view over the <see cref="Name"/> resource name property.
        /// </summary>
        public gax::IResourceName ResourceName
        {
            get
            {
                if (string.IsNullOrEmpty(Name))
                {
                    return null;
                }
                if (tr::WildcardMultiPatternMultipleName.TryParse(Name, out tr::WildcardMultiPatternMultipleName wildcardMultiPatternMultiple))
                {
                    return wildcardMultiPatternMultiple;
                }
                return gax::UnparsedResourceName.Parse(Name);
            }
            set => Name = value?.ToString() ?? "";
        }

        /// <summary>
        /// <see cref="tr::WildcardMultiPatternMultipleName"/>-typed view over the <see cref="Ref"/> resource name
        /// property.
        /// </summary>
        public tr::WildcardMultiPatternMultipleName RefAsWildcardMultiPatternMultipleName
        {
            get => string.IsNullOrEmpty(Ref) ? null : tr::WildcardMultiPatternMultipleName.Parse(Ref, allowUnparsed: true);
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
                if (tr::WildcardMultiPatternMultipleName.TryParse(Ref, out tr::WildcardMultiPatternMultipleName wildcardMultiPatternMultiple))
                {
                    return wildcardMultiPatternMultiple;
                }
                return gax::UnparsedResourceName.Parse(Ref);
            }
            set => Ref = value?.ToString() ?? "";
        }

        /// <summary>
        /// <see cref="tr::WildcardMultiPatternMultipleName"/>-typed view over the <see cref="RepeatedRef"/> resource
        /// name property.
        /// </summary>
        public gax::ResourceNameList<tr::WildcardMultiPatternMultipleName> RepeatedRefAsWildcardMultiPatternMultipleNames
        {
            get => new gax::ResourceNameList<tr::WildcardMultiPatternMultipleName>(RepeatedRef, s => string.IsNullOrEmpty(s) ? null : tr::WildcardMultiPatternMultipleName.Parse(s, allowUnparsed: true));
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
                if (tr::WildcardMultiPatternMultipleName.TryParse(s, out tr::WildcardMultiPatternMultipleName wildcardMultiPatternMultiple))
                {
                    return wildcardMultiPatternMultiple;
                }
                return gax::UnparsedResourceName.Parse(s);
            });
        }
    }

    public partial class LooseValidationPattern
    {
        /// <summary>
        /// <see cref="tr::LooseValidationPatternName"/>-typed view over the <see cref="Name"/> resource name property.
        /// </summary>
        public tr::LooseValidationPatternName LooseValidationPatternName
        {
            get => string.IsNullOrEmpty(Name) ? null : tr::LooseValidationPatternName.Parse(Name, allowUnparsed: true);
            set => Name = value?.ToString() ?? "";
        }
    }
}
