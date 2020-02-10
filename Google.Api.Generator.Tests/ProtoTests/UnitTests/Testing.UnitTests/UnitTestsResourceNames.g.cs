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
        private static readonly gax::PathTemplate s_template = new gax::PathTemplate("items/{item_id}/parts/{part_id}");

        /// <summary>
        /// Parses the given <c>AResource</c> resource name in string form into a new <see cref="AResourceName"/>
        /// instance.
        /// </summary>
        /// <param name="aResourceName">
        /// The <c>AResource</c> resource name in string form. Must not be <c>null</c>.
        /// </param>
        /// <returns>The parsed <see cref="AResourceName"/> if successful.</returns>
        public static AResourceName Parse(string aResourceName)
        {
            gax::GaxPreconditions.CheckNotNull(aResourceName, nameof(aResourceName));
            gax::TemplatedResourceName resourceName = s_template.ParseName(aResourceName);
            return new AResourceName(resourceName[0], resourceName[1]);
        }

        /// <summary>
        /// Tries to parse the given session resource name in string form into a new <see cref="AResourceName"/>
        /// instance.
        /// </summary>
        /// <remarks>
        /// This method still throws <see cref="sys::ArgumentNullException"/> if <paramref name="aResourceName"/> is
        /// <c>null</c>, as this would usually indicate a programming error rather than a data error.
        /// </remarks>
        /// <param name="aResourceName">
        /// The <c>AResource</c> resource name in string form. Must not be <c>null</c>.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="AResourceName"/>, or <c>null</c> if parsing fails.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string aResourceName, out AResourceName result)
        {
            gax::GaxPreconditions.CheckNotNull(aResourceName, nameof(aResourceName));
            if (s_template.TryParseName(aResourceName, out gax::TemplatedResourceName resourceName))
            {
                result = new AResourceName(resourceName[0], resourceName[1]);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        /// <summary>Formats the IDs into the string representation of the <see cref="AResourceName"/>.</summary>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c>.</param>
        /// <param name="partId">The <c>Part</c> ID. Must not be <c>null</c>.</param>
        /// <returns>The string representation of the <see cref="AResourceName"/>.</returns>
        public static string Format(string itemId, string partId) =>
            s_template.Expand(gax::GaxPreconditions.CheckNotNull(itemId, nameof(itemId)), gax::GaxPreconditions.CheckNotNull(partId, nameof(partId)));

        /// <summary>
        /// Constructs a new instance of the <see cref="AResourceName"/> resource name class from its component parts.
        /// </summary>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c>.</param>
        /// <param name="partId">The <c>Part</c> ID. Must not be <c>null</c>.</param>
        public AResourceName(string itemId, string partId)
        {
            ItemId = gax::GaxPreconditions.CheckNotNull(itemId, nameof(itemId));
            PartId = gax::GaxPreconditions.CheckNotNull(partId, nameof(partId));
        }

        /// <summary>The <c>Item</c> ID. Never <c>null</c>.</summary>
        public string ItemId { get; }

        /// <summary>The <c>Part</c> ID. Never <c>null</c>.</summary>
        public string PartId { get; }

        /// <inheritdoc/>
        public gax::ResourceNameKind Kind => gax::ResourceNameKind.Simple;

        /// <inheritdoc/>
        public override string ToString() => s_template.Expand(ItemId, PartId);

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

    /// <summary>Resource name for the <c>RootAItem</c> resource.</summary>
    public sealed partial class RootAItemName : gax::IResourceName, sys::IEquatable<RootAItemName>
    {
        private static readonly gax::PathTemplate s_template = new gax::PathTemplate("root/{root_a_id}/items/{item_id}");

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
        private static readonly gax::PathTemplate s_template = new gax::PathTemplate("root/{root_b_id}/items/{item_id}");

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
    public sealed partial class MultiPatternResourceNameOneOf : gax::IResourceName, sys::IEquatable<MultiPatternResourceNameOneOf>
    {
        /// <summary>The possible contents of <see cref="MultiPatternResourceNameOneOf"/>.</summary>
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
        /// Parses the given <c>MultiPatternResource</c> resource name in string form into a new
        /// <see cref="MultiPatternResourceNameOneOf"/> instance.
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
        /// <returns>The parsed <see cref="MultiPatternResourceNameOneOf"/> if successful.</returns>
        public static MultiPatternResourceNameOneOf Parse(string name, bool allowUnknown)
        {
            if (TryParse(name, allowUnknown, out MultiPatternResourceNameOneOf result))
            {
                return result;
            }
            throw new sys::ArgumentException("Invalid name", nameof(name));
        }

        /// <summary>
        /// Tries to parse a resource name in string form into a new <see cref="MultiPatternResourceNameOneOf"/>
        /// instance.
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
        /// When this method returns, the parsed <see cref="MultiPatternResourceNameOneOf"/>, or <c>null</c> if parsing
        /// fails.
        /// </param>
        /// <returns><c>true</c> if the name was parsed succssfully; othrewise <c>false</c></returns>
        public static bool TryParse(string name, bool allowUnknown, out MultiPatternResourceNameOneOf result)
        {
            gax::GaxPreconditions.CheckNotNull(name, nameof(name));
            if (RootAItemName.TryParse(name, out RootAItemName rootAItemName))
            {
                result = new MultiPatternResourceNameOneOf(OneofType.RootAItemName, rootAItemName);
                return true;
            }
            if (RootBItemName.TryParse(name, out RootBItemName rootBItemName))
            {
                result = new MultiPatternResourceNameOneOf(OneofType.RootBItemName, rootBItemName);
                return true;
            }
            if (allowUnknown)
            {
                if (gax::UnknownResourceName.TryParse(name, out gax::UnknownResourceName unknownResourceName))
                {
                    result = new MultiPatternResourceNameOneOf(OneofType.Unknown, unknownResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        /// <summary>
        /// Constructs a new instance of <see cref="MultiPatternResourceNameOneOf"/> from the provided
        /// <see cref="RootAItemName"/>.
        /// </summary>
        /// <param name="rootAItemName">
        /// The <see cref="RootAItemName"/> to be contained within the returned
        /// <see cref="MultiPatternResourceNameOneOf"/>. Must not be <c>null</c>
        /// </param>
        /// <returns>
        /// A new <see cref="MultiPatternResourceNameOneOf"/>, containing <paramref name="rootAItemName"/>.
        /// </returns>
        public static MultiPatternResourceNameOneOf From(RootAItemName rootAItemName) =>
            new MultiPatternResourceNameOneOf(OneofType.RootAItemName, rootAItemName);

        /// <summary>
        /// Constructs a new instance of <see cref="MultiPatternResourceNameOneOf"/> from the provided
        /// <see cref="RootBItemName"/>.
        /// </summary>
        /// <param name="rootBItemName">
        /// The <see cref="RootBItemName"/> to be contained within the returned
        /// <see cref="MultiPatternResourceNameOneOf"/>. Must not be <c>null</c>
        /// </param>
        /// <returns>
        /// A new <see cref="MultiPatternResourceNameOneOf"/>, containing <paramref name="rootBItemName"/>.
        /// </returns>
        public static MultiPatternResourceNameOneOf From(RootBItemName rootBItemName) =>
            new MultiPatternResourceNameOneOf(OneofType.RootBItemName, rootBItemName);

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
        /// Constructs a new instance of <see cref="MultiPatternResourceNameOneOf"/> with an expected type and a
        /// resource name.
        /// </summary>
        /// <param name="type">The expected type of this oneof.</param>
        /// <param name="name">The resource name represented by this oneof. Must not be <c>null</c>.</param>
        public MultiPatternResourceNameOneOf(OneofType type, gax::IResourceName name)
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
        public override bool Equals(object obj) => Equals(obj as MultiPatternResourceNameOneOf);

        /// <inheritdoc/>
        public bool Equals(MultiPatternResourceNameOneOf other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(MultiPatternResourceNameOneOf a, MultiPatternResourceNameOneOf b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(MultiPatternResourceNameOneOf a, MultiPatternResourceNameOneOf b) => !(a == b);
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
            get => string.IsNullOrEmpty(Name) ? null : gax::UnknownResourceName.Parse(Name);
            set => Name = value?.ToString() ?? "";
        }
    }

    public partial class MultiPatternResource
    {
        /// <summary>
        /// <see cref="tu::MultiPatternResourceNameOneOf"/>-typed view over the <see cref="Name"/> resource name
        /// property.
        /// </summary>
        public tu::MultiPatternResourceNameOneOf MultiPatternResourceNameOneOf
        {
            get => string.IsNullOrEmpty(Name) ? null : tu::MultiPatternResourceNameOneOf.Parse(Name, true);
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
        public gax::ResourceNameList<AResourceName> RepeatedResourceNameAsAResourceNames => new gax::ResourceNameList<AResourceName>(RepeatedResourceName, s => AResourceName.Parse(s));

        /// <summary>
        /// <see cref="gax::IResourceName"/>-typed view over the <see cref="SingleWildcardResource"/> resource name
        /// property.
        /// </summary>
        public gax::IResourceName SingleWildcardResourceAsResourceName
        {
            get => string.IsNullOrEmpty(SingleWildcardResource) ? null : gax::UnknownResourceName.Parse(SingleWildcardResource);
            set => SingleWildcardResource = value?.ToString() ?? "";
        }

        /// <summary>
        /// <see cref="gax::IResourceName"/>-typed view over the <see cref="RepeatedWildcardResource"/> resource name
        /// property.
        /// </summary>
        public gax::ResourceNameList<gax::IResourceName> RepeatedWildcardResourceAsResourceNames => new gax::ResourceNameList<gax::IResourceName>(RepeatedWildcardResource, s => gax::UnknownResourceName.Parse(s));

        /// <summary>
        /// <see cref="MultiPatternResourceNameOneOf"/>-typed view over the <see cref="MultiPatternResourceName"/>
        /// resource name property.
        /// </summary>
        public MultiPatternResourceNameOneOf MultiPatternResourceNameAsMultiPatternResourceNameOneOf
        {
            get => string.IsNullOrEmpty(MultiPatternResourceName) ? null : MultiPatternResourceNameOneOf.Parse(MultiPatternResourceName, true);
            set => MultiPatternResourceName = value?.ToString() ?? "";
        }

        /// <summary>
        /// <see cref="MultiPatternResourceNameOneOf"/>-typed view over the
        /// <see cref="RepeatedMultiPatternResourceName"/> resource name property.
        /// </summary>
        public gax::ResourceNameList<MultiPatternResourceNameOneOf> RepeatedMultiPatternResourceNameAsMultiPatternResourceNameOneOfs => new gax::ResourceNameList<MultiPatternResourceNameOneOf>(RepeatedMultiPatternResourceName, s => MultiPatternResourceNameOneOf.Parse(s, true));
    }
}
