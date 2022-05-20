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

#pragma warning disable CS8981
using gax = Google.Api.Gax;
using gsv = Google.Showcase.V1Beta1;
using sys = System;

namespace Google.Showcase.V1Beta1
{
    /// <summary>Resource name for the <c>Sequence</c> resource.</summary>
    public sealed partial class SequenceName : gax::IResourceName, sys::IEquatable<SequenceName>
    {
        /// <summary>The possible contents of <see cref="SequenceName"/>.</summary>
        public enum ResourceNameType
        {
            /// <summary>An unparsed resource name.</summary>
            Unparsed = 0,

            /// <summary>A resource name with pattern <c>sequences/{sequence}</c>.</summary>
            Sequence = 1,
        }

        private static gax::PathTemplate s_sequence = new gax::PathTemplate("sequences/{sequence}");

        /// <summary>Creates a <see cref="SequenceName"/> containing an unparsed resource name.</summary>
        /// <param name="unparsedResourceName">The unparsed resource name. Must not be <c>null</c>.</param>
        /// <returns>
        /// A new instance of <see cref="SequenceName"/> containing the provided <paramref name="unparsedResourceName"/>
        /// .
        /// </returns>
        public static SequenceName FromUnparsed(gax::UnparsedResourceName unparsedResourceName) =>
            new SequenceName(ResourceNameType.Unparsed, gax::GaxPreconditions.CheckNotNull(unparsedResourceName, nameof(unparsedResourceName)));

        /// <summary>Creates a <see cref="SequenceName"/> with the pattern <c>sequences/{sequence}</c>.</summary>
        /// <param name="sequenceId">The <c>Sequence</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="SequenceName"/> constructed from the provided ids.</returns>
        public static SequenceName FromSequence(string sequenceId) =>
            new SequenceName(ResourceNameType.Sequence, sequenceId: gax::GaxPreconditions.CheckNotNullOrEmpty(sequenceId, nameof(sequenceId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="SequenceName"/> with pattern
        /// <c>sequences/{sequence}</c>.
        /// </summary>
        /// <param name="sequenceId">The <c>Sequence</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="SequenceName"/> with pattern <c>sequences/{sequence}</c>.
        /// </returns>
        public static string Format(string sequenceId) => FormatSequence(sequenceId);

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="SequenceName"/> with pattern
        /// <c>sequences/{sequence}</c>.
        /// </summary>
        /// <param name="sequenceId">The <c>Sequence</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="SequenceName"/> with pattern <c>sequences/{sequence}</c>.
        /// </returns>
        public static string FormatSequence(string sequenceId) =>
            s_sequence.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(sequenceId, nameof(sequenceId)));

        /// <summary>Parses the given resource name string into a new <see cref="SequenceName"/> instance.</summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>sequences/{sequence}</c></description></item></list>
        /// </remarks>
        /// <param name="sequenceName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="SequenceName"/> if successful.</returns>
        public static SequenceName Parse(string sequenceName) => Parse(sequenceName, false);

        /// <summary>
        /// Parses the given resource name string into a new <see cref="SequenceName"/> instance; optionally allowing an
        /// unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>sequences/{sequence}</c></description></item></list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="sequenceName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <returns>The parsed <see cref="SequenceName"/> if successful.</returns>
        public static SequenceName Parse(string sequenceName, bool allowUnparsed) =>
            TryParse(sequenceName, allowUnparsed, out SequenceName result) ? result : throw new sys::ArgumentException("The given resource-name matches no pattern.");

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="SequenceName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>sequences/{sequence}</c></description></item></list>
        /// </remarks>
        /// <param name="sequenceName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="SequenceName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string sequenceName, out SequenceName result) => TryParse(sequenceName, false, out result);

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="SequenceName"/> instance; optionally
        /// allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>sequences/{sequence}</c></description></item></list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="sequenceName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="SequenceName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string sequenceName, bool allowUnparsed, out SequenceName result)
        {
            gax::GaxPreconditions.CheckNotNull(sequenceName, nameof(sequenceName));
            gax::TemplatedResourceName resourceName;
            if (s_sequence.TryParseName(sequenceName, out resourceName))
            {
                result = FromSequence(resourceName[0]);
                return true;
            }
            if (allowUnparsed)
            {
                if (gax::UnparsedResourceName.TryParse(sequenceName, out gax::UnparsedResourceName unparsedResourceName))
                {
                    result = FromUnparsed(unparsedResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        private SequenceName(ResourceNameType type, gax::UnparsedResourceName unparsedResourceName = null, string sequenceId = null)
        {
            Type = type;
            UnparsedResource = unparsedResourceName;
            SequenceId = sequenceId;
        }

        /// <summary>
        /// Constructs a new instance of a <see cref="SequenceName"/> class from the component parts of pattern
        /// <c>sequences/{sequence}</c>
        /// </summary>
        /// <param name="sequenceId">The <c>Sequence</c> ID. Must not be <c>null</c> or empty.</param>
        public SequenceName(string sequenceId) : this(ResourceNameType.Sequence, sequenceId: gax::GaxPreconditions.CheckNotNullOrEmpty(sequenceId, nameof(sequenceId)))
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
        /// The <c>Sequence</c> ID. Will not be <c>null</c>, unless this instance contains an unparsed resource name.
        /// </summary>
        public string SequenceId { get; }

        /// <summary>Whether this instance contains a resource name with a known pattern.</summary>
        public bool IsKnownPattern => Type != ResourceNameType.Unparsed;

        /// <summary>The string representation of the resource name.</summary>
        /// <returns>The string representation of the resource name.</returns>
        public override string ToString()
        {
            switch (Type)
            {
                case ResourceNameType.Unparsed: return UnparsedResource.ToString();
                case ResourceNameType.Sequence: return s_sequence.Expand(SequenceId);
                default: throw new sys::InvalidOperationException("Unrecognized resource-type.");
            }
        }

        /// <summary>Returns a hash code for this resource name.</summary>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as SequenceName);

        /// <inheritdoc/>
        public bool Equals(SequenceName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(SequenceName a, SequenceName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(SequenceName a, SequenceName b) => !(a == b);
    }

    /// <summary>Resource name for the <c>SequenceReport</c> resource.</summary>
    public sealed partial class SequenceReportName : gax::IResourceName, sys::IEquatable<SequenceReportName>
    {
        /// <summary>The possible contents of <see cref="SequenceReportName"/>.</summary>
        public enum ResourceNameType
        {
            /// <summary>An unparsed resource name.</summary>
            Unparsed = 0,

            /// <summary>A resource name with pattern <c>sequences/{sequence}/sequenceReport</c>.</summary>
            Sequence = 1,
        }

        private static gax::PathTemplate s_sequence = new gax::PathTemplate("sequences/{sequence}/sequenceReport");

        /// <summary>Creates a <see cref="SequenceReportName"/> containing an unparsed resource name.</summary>
        /// <param name="unparsedResourceName">The unparsed resource name. Must not be <c>null</c>.</param>
        /// <returns>
        /// A new instance of <see cref="SequenceReportName"/> containing the provided
        /// <paramref name="unparsedResourceName"/>.
        /// </returns>
        public static SequenceReportName FromUnparsed(gax::UnparsedResourceName unparsedResourceName) =>
            new SequenceReportName(ResourceNameType.Unparsed, gax::GaxPreconditions.CheckNotNull(unparsedResourceName, nameof(unparsedResourceName)));

        /// <summary>
        /// Creates a <see cref="SequenceReportName"/> with the pattern <c>sequences/{sequence}/sequenceReport</c>.
        /// </summary>
        /// <param name="sequenceId">The <c>Sequence</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="SequenceReportName"/> constructed from the provided ids.</returns>
        public static SequenceReportName FromSequence(string sequenceId) =>
            new SequenceReportName(ResourceNameType.Sequence, sequenceId: gax::GaxPreconditions.CheckNotNullOrEmpty(sequenceId, nameof(sequenceId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="SequenceReportName"/> with pattern
        /// <c>sequences/{sequence}/sequenceReport</c>.
        /// </summary>
        /// <param name="sequenceId">The <c>Sequence</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="SequenceReportName"/> with pattern
        /// <c>sequences/{sequence}/sequenceReport</c>.
        /// </returns>
        public static string Format(string sequenceId) => FormatSequence(sequenceId);

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="SequenceReportName"/> with pattern
        /// <c>sequences/{sequence}/sequenceReport</c>.
        /// </summary>
        /// <param name="sequenceId">The <c>Sequence</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="SequenceReportName"/> with pattern
        /// <c>sequences/{sequence}/sequenceReport</c>.
        /// </returns>
        public static string FormatSequence(string sequenceId) =>
            s_sequence.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(sequenceId, nameof(sequenceId)));

        /// <summary>
        /// Parses the given resource name string into a new <see cref="SequenceReportName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>sequences/{sequence}/sequenceReport</c></description></item>
        /// </list>
        /// </remarks>
        /// <param name="sequenceReportName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="SequenceReportName"/> if successful.</returns>
        public static SequenceReportName Parse(string sequenceReportName) => Parse(sequenceReportName, false);

        /// <summary>
        /// Parses the given resource name string into a new <see cref="SequenceReportName"/> instance; optionally
        /// allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>sequences/{sequence}/sequenceReport</c></description></item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="sequenceReportName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <returns>The parsed <see cref="SequenceReportName"/> if successful.</returns>
        public static SequenceReportName Parse(string sequenceReportName, bool allowUnparsed) =>
            TryParse(sequenceReportName, allowUnparsed, out SequenceReportName result) ? result : throw new sys::ArgumentException("The given resource-name matches no pattern.");

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="SequenceReportName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>sequences/{sequence}/sequenceReport</c></description></item>
        /// </list>
        /// </remarks>
        /// <param name="sequenceReportName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="SequenceReportName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string sequenceReportName, out SequenceReportName result) =>
            TryParse(sequenceReportName, false, out result);

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="SequenceReportName"/> instance;
        /// optionally allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>sequences/{sequence}/sequenceReport</c></description></item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="sequenceReportName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="SequenceReportName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string sequenceReportName, bool allowUnparsed, out SequenceReportName result)
        {
            gax::GaxPreconditions.CheckNotNull(sequenceReportName, nameof(sequenceReportName));
            gax::TemplatedResourceName resourceName;
            if (s_sequence.TryParseName(sequenceReportName, out resourceName))
            {
                result = FromSequence(resourceName[0]);
                return true;
            }
            if (allowUnparsed)
            {
                if (gax::UnparsedResourceName.TryParse(sequenceReportName, out gax::UnparsedResourceName unparsedResourceName))
                {
                    result = FromUnparsed(unparsedResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        private SequenceReportName(ResourceNameType type, gax::UnparsedResourceName unparsedResourceName = null, string sequenceId = null)
        {
            Type = type;
            UnparsedResource = unparsedResourceName;
            SequenceId = sequenceId;
        }

        /// <summary>
        /// Constructs a new instance of a <see cref="SequenceReportName"/> class from the component parts of pattern
        /// <c>sequences/{sequence}/sequenceReport</c>
        /// </summary>
        /// <param name="sequenceId">The <c>Sequence</c> ID. Must not be <c>null</c> or empty.</param>
        public SequenceReportName(string sequenceId) : this(ResourceNameType.Sequence, sequenceId: gax::GaxPreconditions.CheckNotNullOrEmpty(sequenceId, nameof(sequenceId)))
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
        /// The <c>Sequence</c> ID. Will not be <c>null</c>, unless this instance contains an unparsed resource name.
        /// </summary>
        public string SequenceId { get; }

        /// <summary>Whether this instance contains a resource name with a known pattern.</summary>
        public bool IsKnownPattern => Type != ResourceNameType.Unparsed;

        /// <summary>The string representation of the resource name.</summary>
        /// <returns>The string representation of the resource name.</returns>
        public override string ToString()
        {
            switch (Type)
            {
                case ResourceNameType.Unparsed: return UnparsedResource.ToString();
                case ResourceNameType.Sequence: return s_sequence.Expand(SequenceId);
                default: throw new sys::InvalidOperationException("Unrecognized resource-type.");
            }
        }

        /// <summary>Returns a hash code for this resource name.</summary>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as SequenceReportName);

        /// <inheritdoc/>
        public bool Equals(SequenceReportName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(SequenceReportName a, SequenceReportName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(SequenceReportName a, SequenceReportName b) => !(a == b);
    }

    public partial class Sequence
    {
        /// <summary>
        /// <see cref="gsv::SequenceName"/>-typed view over the <see cref="Name"/> resource name property.
        /// </summary>
        public gsv::SequenceName SequenceName
        {
            get => string.IsNullOrEmpty(Name) ? null : gsv::SequenceName.Parse(Name, allowUnparsed: true);
            set => Name = value?.ToString() ?? "";
        }
    }

    public partial class SequenceReport
    {
        /// <summary>
        /// <see cref="gsv::SequenceReportName"/>-typed view over the <see cref="Name"/> resource name property.
        /// </summary>
        public gsv::SequenceReportName SequenceReportName
        {
            get => string.IsNullOrEmpty(Name) ? null : gsv::SequenceReportName.Parse(Name, allowUnparsed: true);
            set => Name = value?.ToString() ?? "";
        }
    }

    public partial class AttemptSequenceRequest
    {
        /// <summary>
        /// <see cref="gsv::SequenceName"/>-typed view over the <see cref="Name"/> resource name property.
        /// </summary>
        public gsv::SequenceName SequenceName
        {
            get => string.IsNullOrEmpty(Name) ? null : gsv::SequenceName.Parse(Name, allowUnparsed: true);
            set => Name = value?.ToString() ?? "";
        }
    }

    public partial class GetSequenceReportRequest
    {
        /// <summary>
        /// <see cref="gsv::SequenceReportName"/>-typed view over the <see cref="Name"/> resource name property.
        /// </summary>
        public gsv::SequenceReportName SequenceReportName
        {
            get => string.IsNullOrEmpty(Name) ? null : gsv::SequenceReportName.Parse(Name, allowUnparsed: true);
            set => Name = value?.ToString() ?? "";
        }
    }
}
