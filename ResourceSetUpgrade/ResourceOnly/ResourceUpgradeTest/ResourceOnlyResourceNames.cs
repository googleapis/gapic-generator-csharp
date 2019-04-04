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
using r = ResourceUpgradeTest;
using sys = System;

namespace ResourceUpgradeTest
{
    /// <summary>Resource name for the <c>Request</c> resource</summary>
    public sealed partial class RequestName : gax::IResourceName, sys::IEquatable<RequestName>
    {
        private static readonly gax::PathTemplate s_template = new gax::PathTemplate("items/{item_id}");

        /// <summary>
        /// Parses the given <c>Request</c> resource name in string form into a new <see cref="RequestName"/> instance.
        /// </summary>
        /// <param name="request">The <c>Request</c> resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="RequestName"/> if successful.</returns>
        public static RequestName Parse(string request)
        {
            gax::GaxPreconditions.CheckNotNull(request, nameof(request));
            gax::TemplatedResourceName resourceName = s_template.ParseName(request);
            return new RequestName(resourceName[0]);
        }

        /// <summary>
        /// Tries to parse the given session resource name in string form into a new <see cref="RequestName"/> instance.
        /// </summary>
        /// <remarks>
        /// This method still throws <see cref="sys::ArgumentNullException"/> if <paramref name="request"/> is <c>null</c>
        /// , as this would usually indicate a programming error rather than a data error.
        /// </remarks>
        /// <param name="request">The <c>Request</c> resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="RequestName"/>, or <c>null</c> if parsing fails.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string request, out RequestName result)
        {
            gax::GaxPreconditions.CheckNotNull(request, nameof(request));
            if (s_template.TryParseName(request, out gax::TemplatedResourceName resourceName))
            {
                result = new RequestName(resourceName[0]);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        /// <summary>
        /// Constructs a new instance of the <see cref="RequestName"/> resource name class from its component parts.
        /// </summary>
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c>.</param>
        public RequestName(string itemId) => ItemId = gax::GaxPreconditions.CheckNotNull(itemId, nameof(itemId));

        /// <summary>The <c>Item</c> ID. Never <c>null</c>.</summary>
        public string ItemId { get; }

        /// <inheritdoc/>
        public gax::ResourceNameKind Kind => gax::ResourceNameKind.Simple;

        /// <inheritdoc/>
        public override string ToString() => s_template.Expand(ItemId);

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
        /// <see cref="r::RequestName"/>-typed view over the <see cref="Name"/> resource name property.
        /// </summary>
        public RequestName RequestName
        {
            get => string.IsNullOrEmpty(Name) ? null : RequestName.Parse(Name);
            set => Name = value?.ToString() ?? "";
        }

        /// <summary>
        /// <see cref="RequestName"/>-typed view over the <see cref="AnotherName"/> resource name property.
        /// </summary>
        public RequestName AnotherNameAsRequestName
        {
            get => string.IsNullOrEmpty(AnotherName) ? null : RequestName.Parse(AnotherName);
            set => AnotherName = value?.ToString() ?? "";
        }
    }
}
