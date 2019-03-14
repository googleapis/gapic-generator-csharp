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

namespace Testing.UnitTests
{
    /// <summary>Resource name for the <c>AResource</c> resource</summary>
    public sealed partial class AResourceName : gax::IResourceName, sys::IEquatable<AResourceName>
    {
        private static readonly gax::PathTemplate s_template = new gax::PathTemplate("items/{item_id}/parts/{part_id}");

        /// <summary>
        /// Parses the given <c>AResource</c> resource name in string form into a new <see cref="AResourceName"/>
        /// instance.
        /// </summary>
        /// <param name="aResource">The <c>AResource</c> resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="AResourceName"/> if successful.</returns>
        public static AResourceName Parse(string aResource)
        {
            gax::GaxPreconditions.CheckNotNull(aResource, nameof(aResource));
            gax::TemplatedResourceName resourceName = s_template.ParseName(aResource);
            return new AResourceName(resourceName[0], resourceName[1]);
        }

        /// <summary>
        /// Tries to parse the given session resource name in string form into a new <see cref="AResourceName"/>
        /// instance.
        /// </summary>
        /// <remarks>
        /// This method still throws <see cref="sys::ArgumentNullException"/> if <paramref name="aResource"/> is <c>null</c>
        /// , as this would usually indicate a programming error rather than a data error.
        /// </remarks>
        /// <param name="aResource">The <c>AResource</c> resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="AResourceName"/>, or <c>null</c> if parsing fails.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string aResource, out AResourceName result)
        {
            gax::GaxPreconditions.CheckNotNull(aResource, nameof(aResource));
            if (s_template.TryParseName(aResource, out gax::TemplatedResourceName resourceName))
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
    }
}
