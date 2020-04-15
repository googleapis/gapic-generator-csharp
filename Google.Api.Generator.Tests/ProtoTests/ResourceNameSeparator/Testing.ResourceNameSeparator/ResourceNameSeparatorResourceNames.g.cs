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
using tr = Testing.ResourceNameSeparator;

namespace Testing.ResourceNameSeparator
{
    /// <summary>Resource name for the <c>Request</c> resource.</summary>
    public sealed partial class RequestName : gax::IResourceName, sys::IEquatable<RequestName>
    {
        /// <summary>The possible contents of <see cref="RequestName"/>.</summary>
        public enum ResourceNameType
        {
            /// <summary>An unparsed resource name.</summary>
            Unparsed = 0,

            /// <summary>
            /// A resource name with pattern
            /// <c>items/{item_a_id}~{item_b_id}/details/{details_a_id}_{details_b_id}:{details_c_id}/extra/{extra_id}</c>
            /// .
            /// </summary>
            ItemAItemBDetailsADetailsBDetailsCExtra = 1,

            /// <summary>A resource name with pattern <c>as/aaa{a_id}aaa/bs/~{b1_id}~{b2_id}~{b3_id}~</c>.</summary>
            AB1B2B3 = 2
        }

        private static gax::PathTemplate s_itemAItemBDetailsADetailsBDetailsCExtra = new gax::PathTemplate("items/{item_a_id_item_b_id}/details/{details_a_id_details_b_id_details_c_id}/extra/{extra_id}");

        private static gax::PathTemplate s_aB1B2B3 = new gax::PathTemplate("as/{a_id}/bs/{b1_id_b2_id_b3_id}");

        /// <summary>Creates a <see cref="RequestName"/> containing an unparsed resource name.</summary>
        /// <param name="unparsedResourceName">The unparsed resource name. Must not be <c>null</c>.</param>
        /// <returns>
        /// A new instance of <see cref="RequestName"/> containing the provided <paramref name="unparsedResourceName"/>.
        /// </returns>
        public static RequestName FromUnparsed(gax::UnparsedResourceName unparsedResourceName) =>
            new RequestName(ResourceNameType.Unparsed, gax::GaxPreconditions.CheckNotNull(unparsedResourceName, nameof(unparsedResourceName)));

        /// <summary>
        /// Creates a <see cref="RequestName"/> with the pattern
        /// <c>items/{item_a_id}~{item_b_id}/details/{details_a_id}_{details_b_id}:{details_c_id}/extra/{extra_id}</c>.
        /// </summary>
        /// <param name="itemAId">The <c>ItemA</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemBId">The <c>ItemB</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="detailsAId">The <c>DetailsA</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="detailsBId">The <c>DetailsB</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="detailsCId">The <c>DetailsC</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="extraId">The <c>Extra</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="RequestName"/> constructed from the provided ids.</returns>
        public static RequestName FromItemAItemBDetailsADetailsBDetailsCExtra(string itemAId, string itemBId, string detailsAId, string detailsBId, string detailsCId, string extraId) =>
            new RequestName(ResourceNameType.ItemAItemBDetailsADetailsBDetailsCExtra, itemAId: gax::GaxPreconditions.CheckNotNullOrEmpty(itemAId, nameof(itemAId)), itemBId: gax::GaxPreconditions.CheckNotNullOrEmpty(itemBId, nameof(itemBId)), detailsAId: gax::GaxPreconditions.CheckNotNullOrEmpty(detailsAId, nameof(detailsAId)), detailsBId: gax::GaxPreconditions.CheckNotNullOrEmpty(detailsBId, nameof(detailsBId)), detailsCId: gax::GaxPreconditions.CheckNotNullOrEmpty(detailsCId, nameof(detailsCId)), extraId: gax::GaxPreconditions.CheckNotNullOrEmpty(extraId, nameof(extraId)));

        /// <summary>
        /// Creates a <see cref="RequestName"/> with the pattern <c>as/aaa{a_id}aaa/bs/~{b1_id}~{b2_id}~{b3_id}~</c>.
        /// </summary>
        /// <param name="aId">The <c>A</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="b1Id">The <c>B1</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="b2Id">The <c>B2</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="b3Id">The <c>B3</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="RequestName"/> constructed from the provided ids.</returns>
        public static RequestName FromAB1B2B3(string aId, string b1Id, string b2Id, string b3Id) =>
            new RequestName(ResourceNameType.AB1B2B3, aId: gax::GaxPreconditions.CheckNotNullOrEmpty(aId, nameof(aId)), b1Id: gax::GaxPreconditions.CheckNotNullOrEmpty(b1Id, nameof(b1Id)), b2Id: gax::GaxPreconditions.CheckNotNullOrEmpty(b2Id, nameof(b2Id)), b3Id: gax::GaxPreconditions.CheckNotNullOrEmpty(b3Id, nameof(b3Id)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="RequestName"/> with pattern
        /// <c>items/{item_a_id}~{item_b_id}/details/{details_a_id}_{details_b_id}:{details_c_id}/extra/{extra_id}</c>.
        /// </summary>
        /// <param name="itemAId">The <c>ItemA</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemBId">The <c>ItemB</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="detailsAId">The <c>DetailsA</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="detailsBId">The <c>DetailsB</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="detailsCId">The <c>DetailsC</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="extraId">The <c>Extra</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="RequestName"/> with pattern
        /// <c>items/{item_a_id}~{item_b_id}/details/{details_a_id}_{details_b_id}:{details_c_id}/extra/{extra_id}</c>.
        /// </returns>
        public static string Format(string itemAId, string itemBId, string detailsAId, string detailsBId, string detailsCId, string extraId) =>
            FormatItemAItemBDetailsADetailsBDetailsCExtra(itemAId, itemBId, detailsAId, detailsBId, detailsCId, extraId);

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="RequestName"/> with pattern
        /// <c>items/{item_a_id}~{item_b_id}/details/{details_a_id}_{details_b_id}:{details_c_id}/extra/{extra_id}</c>.
        /// </summary>
        /// <param name="itemAId">The <c>ItemA</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemBId">The <c>ItemB</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="detailsAId">The <c>DetailsA</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="detailsBId">The <c>DetailsB</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="detailsCId">The <c>DetailsC</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="extraId">The <c>Extra</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="RequestName"/> with pattern
        /// <c>items/{item_a_id}~{item_b_id}/details/{details_a_id}_{details_b_id}:{details_c_id}/extra/{extra_id}</c>.
        /// </returns>
        public static string FormatItemAItemBDetailsADetailsBDetailsCExtra(string itemAId, string itemBId, string detailsAId, string detailsBId, string detailsCId, string extraId) =>
            s_itemAItemBDetailsADetailsBDetailsCExtra.Expand($"{(gax::GaxPreconditions.CheckNotNullOrEmpty(itemAId, nameof(itemAId)))}~{(gax::GaxPreconditions.CheckNotNullOrEmpty(itemBId, nameof(itemBId)))}", $"{(gax::GaxPreconditions.CheckNotNullOrEmpty(detailsAId, nameof(detailsAId)))}_{(gax::GaxPreconditions.CheckNotNullOrEmpty(detailsBId, nameof(detailsBId)))}:{(gax::GaxPreconditions.CheckNotNullOrEmpty(detailsCId, nameof(detailsCId)))}", gax::GaxPreconditions.CheckNotNullOrEmpty(extraId, nameof(extraId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="RequestName"/> with pattern
        /// <c>as/aaa{a_id}aaa/bs/~{b1_id}~{b2_id}~{b3_id}~</c>.
        /// </summary>
        /// <param name="aId">The <c>A</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="b1Id">The <c>B1</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="b2Id">The <c>B2</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="b3Id">The <c>B3</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="RequestName"/> with pattern
        /// <c>as/aaa{a_id}aaa/bs/~{b1_id}~{b2_id}~{b3_id}~</c>.
        /// </returns>
        public static string FormatAB1B2B3(string aId, string b1Id, string b2Id, string b3Id) =>
            s_aB1B2B3.Expand($"aaa{(gax::GaxPreconditions.CheckNotNullOrEmpty(aId, nameof(aId)))}aaa", $"~{(gax::GaxPreconditions.CheckNotNullOrEmpty(b1Id, nameof(b1Id)))}~{(gax::GaxPreconditions.CheckNotNullOrEmpty(b2Id, nameof(b2Id)))}~{(gax::GaxPreconditions.CheckNotNullOrEmpty(b3Id, nameof(b3Id)))}~");

        /// <summary>Parses the given resource name string into a new <see cref="RequestName"/> instance.</summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <c>items/{item_a_id}~{item_b_id}/details/{details_a_id}_{details_b_id}:{details_c_id}/extra/{extra_id}</c>
        /// </description>
        /// </item>
        /// <item><description><c>as/aaa{a_id}aaa/bs/~{b1_id}~{b2_id}~{b3_id}~</c></description></item>
        /// </list>
        /// </remarks>
        /// <param name="requestName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="RequestName"/> if successful.</returns>
        public static RequestName Parse(string requestName) => Parse(requestName, false);

        /// <summary>
        /// Parses the given resource name string into a new <see cref="RequestName"/> instance; optionally allowing an
        /// unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <c>items/{item_a_id}~{item_b_id}/details/{details_a_id}_{details_b_id}:{details_c_id}/extra/{extra_id}</c>
        /// </description>
        /// </item>
        /// <item><description><c>as/aaa{a_id}aaa/bs/~{b1_id}~{b2_id}~{b3_id}~</c></description></item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="requestName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <returns>The parsed <see cref="RequestName"/> if successful.</returns>
        public static RequestName Parse(string requestName, bool allowUnparsed) =>
            TryParse(requestName, allowUnparsed, out RequestName result) ? result : throw new sys::ArgumentException("The given resource-name matches no pattern.");

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="RequestName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <c>items/{item_a_id}~{item_b_id}/details/{details_a_id}_{details_b_id}:{details_c_id}/extra/{extra_id}</c>
        /// </description>
        /// </item>
        /// <item><description><c>as/aaa{a_id}aaa/bs/~{b1_id}~{b2_id}~{b3_id}~</c></description></item>
        /// </list>
        /// </remarks>
        /// <param name="requestName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="RequestName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string requestName, out RequestName result) => TryParse(requestName, false, out result);

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="RequestName"/> instance; optionally
        /// allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <c>items/{item_a_id}~{item_b_id}/details/{details_a_id}_{details_b_id}:{details_c_id}/extra/{extra_id}</c>
        /// </description>
        /// </item>
        /// <item><description><c>as/aaa{a_id}aaa/bs/~{b1_id}~{b2_id}~{b3_id}~</c></description></item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="requestName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="RequestName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string requestName, bool allowUnparsed, out RequestName result)
        {
            gax::GaxPreconditions.CheckNotNull(requestName, nameof(requestName));
            gax::TemplatedResourceName resourceName;
            if (s_itemAItemBDetailsADetailsBDetailsCExtra.TryParseName(requestName, out resourceName))
            {
                string[] split0 = ParseSplitHelper(resourceName[0], new string[] { "", "~", "", });
                if (split0 == null)
                {
                    result = null;
                    return false;
                }
                string[] split1 = ParseSplitHelper(resourceName[1], new string[] { "", "_", ":", "", });
                if (split1 == null)
                {
                    result = null;
                    return false;
                }
                result = FromItemAItemBDetailsADetailsBDetailsCExtra(split0[0], split0[1], split1[0], split1[1], split1[2], resourceName[2]);
                return true;
            }
            if (s_aB1B2B3.TryParseName(requestName, out resourceName))
            {
                string[] split0 = ParseSplitHelper(resourceName[0], new string[] { "aaa", "aaa", });
                if (split0 == null)
                {
                    result = null;
                    return false;
                }
                string[] split1 = ParseSplitHelper(resourceName[1], new string[] { "~", "~", "~", "~", });
                if (split1 == null)
                {
                    result = null;
                    return false;
                }
                result = FromAB1B2B3(split0[0], split1[0], split1[1], split1[2]);
                return true;
            }
            if (allowUnparsed)
            {
                if (gax::UnparsedResourceName.TryParse(requestName, out gax::UnparsedResourceName unparsedResourceName))
                {
                    result = FromUnparsed(unparsedResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        private static string[] ParseSplitHelper(string s, string[] separators)
        {
            if (!s.StartsWith(separators[0]))
            {
                return null;
            }
            int i0 = separators[0].Length;
            string[] result = new string[separators.Length - 1];
            for (int i = 1; i < separators.Length; i++)
            {
                int i1 = separators[i] == "" ? s.Length : s.IndexOf(separators[i], i0);
                if (i1 < 0)
                {
                    return null;
                }
                result[i - 1] = s.Substring(i0, i1 - i0);
                i0 = i1 + separators[i].Length;
            }
            return result;
        }

        private RequestName(ResourceNameType type, gax::UnparsedResourceName unparsedResourceName = null, string aId = null, string b1Id = null, string b2Id = null, string b3Id = null, string detailsAId = null, string detailsBId = null, string detailsCId = null, string extraId = null, string itemAId = null, string itemBId = null)
        {
            Type = type;
            UnparsedResource = unparsedResourceName;
            AId = aId;
            B1Id = b1Id;
            B2Id = b2Id;
            B3Id = b3Id;
            DetailsAId = detailsAId;
            DetailsBId = detailsBId;
            DetailsCId = detailsCId;
            ExtraId = extraId;
            ItemAId = itemAId;
            ItemBId = itemBId;
        }

        /// <summary>
        /// Constructs a new instance of a <see cref="RequestName"/> class from the component parts of pattern
        /// <c>items/{item_a_id}~{item_b_id}/details/{details_a_id}_{details_b_id}:{details_c_id}/extra/{extra_id}</c>
        /// </summary>
        /// <param name="itemAId">The <c>ItemA</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="itemBId">The <c>ItemB</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="detailsAId">The <c>DetailsA</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="detailsBId">The <c>DetailsB</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="detailsCId">The <c>DetailsC</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="extraId">The <c>Extra</c> ID. Must not be <c>null</c> or empty.</param>
        public RequestName(string itemAId, string itemBId, string detailsAId, string detailsBId, string detailsCId, string extraId) : this(ResourceNameType.ItemAItemBDetailsADetailsBDetailsCExtra, itemAId: gax::GaxPreconditions.CheckNotNullOrEmpty(itemAId, nameof(itemAId)), itemBId: gax::GaxPreconditions.CheckNotNullOrEmpty(itemBId, nameof(itemBId)), detailsAId: gax::GaxPreconditions.CheckNotNullOrEmpty(detailsAId, nameof(detailsAId)), detailsBId: gax::GaxPreconditions.CheckNotNullOrEmpty(detailsBId, nameof(detailsBId)), detailsCId: gax::GaxPreconditions.CheckNotNullOrEmpty(detailsCId, nameof(detailsCId)), extraId: gax::GaxPreconditions.CheckNotNullOrEmpty(extraId, nameof(extraId)))
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
        /// The <c>A</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string AId { get; }

        /// <summary>
        /// The <c>B1</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string B1Id { get; }

        /// <summary>
        /// The <c>B2</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string B2Id { get; }

        /// <summary>
        /// The <c>B3</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string B3Id { get; }

        /// <summary>
        /// The <c>DetailsA</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string DetailsAId { get; }

        /// <summary>
        /// The <c>DetailsB</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string DetailsBId { get; }

        /// <summary>
        /// The <c>DetailsC</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string DetailsCId { get; }

        /// <summary>
        /// The <c>Extra</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string ExtraId { get; }

        /// <summary>
        /// The <c>ItemA</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string ItemAId { get; }

        /// <summary>
        /// The <c>ItemB</c> ID. May be <c>null</c>, depending on which resource name is contained by this instance.
        /// </summary>
        public string ItemBId { get; }

        /// <inheritdoc/>
        public bool IsKnownPattern => Type != ResourceNameType.Unparsed;

        /// <inheritdoc/>
        public override string ToString()
        {
            switch (Type)
            {
                case ResourceNameType.Unparsed: return UnparsedResource.ToString();
                case ResourceNameType.ItemAItemBDetailsADetailsBDetailsCExtra: return s_itemAItemBDetailsADetailsBDetailsCExtra.Expand($"{ItemAId}~{ItemBId}", $"{DetailsAId}_{DetailsBId}:{DetailsCId}", ExtraId);
                case ResourceNameType.AB1B2B3: return s_aB1B2B3.Expand($"aaa{AId}aaa", $"~{B1Id}~{B2Id}~{B3Id}~");
                default: throw new sys::InvalidOperationException("Unrecognized resource-type.");
            }
        }

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as RequestName);

        /// <inheritdoc/>
        public bool Equals(RequestName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(RequestName a, RequestName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(RequestName a, RequestName b) => !(a == b);
    }

    public partial class Request
    {
        /// <summary>
        /// <see cref="tr::RequestName"/>-typed view over the <see cref="Name"/> resource name property.
        /// </summary>
        public tr::RequestName RequestName
        {
            get => string.IsNullOrEmpty(Name) ? null : tr::RequestName.Parse(Name, allowUnparsed: true);
            set => Name = value?.ToString() ?? "";
        }

        /// <summary>
        /// <see cref="tr::RequestName"/>-typed view over the <see cref="Ref"/> resource name property.
        /// </summary>
        public tr::RequestName RefAsRequestName
        {
            get => string.IsNullOrEmpty(Ref) ? null : tr::RequestName.Parse(Ref, allowUnparsed: true);
            set => Ref = value?.ToString() ?? "";
        }
    }
}
