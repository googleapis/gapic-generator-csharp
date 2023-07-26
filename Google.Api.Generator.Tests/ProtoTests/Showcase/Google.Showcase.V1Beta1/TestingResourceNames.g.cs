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
    /// <summary>Resource name for the <c>Session</c> resource.</summary>
    public sealed partial class SessionName : gax::IResourceName, sys::IEquatable<SessionName>
    {
        /// <summary>The possible contents of <see cref="SessionName"/>.</summary>
        public enum ResourceNameType
        {
            /// <summary>An unparsed resource name.</summary>
            Unparsed = 0,

            /// <summary>A resource name with pattern <c>sessions/{session}</c>.</summary>
            Session = 1,
        }

        private static gax::PathTemplate s_session = new gax::PathTemplate("sessions/{session}");

        /// <summary>Creates a <see cref="SessionName"/> containing an unparsed resource name.</summary>
        /// <param name="unparsedResourceName">The unparsed resource name. Must not be <c>null</c>.</param>
        /// <returns>
        /// A new instance of <see cref="SessionName"/> containing the provided <paramref name="unparsedResourceName"/>.
        /// </returns>
        public static SessionName FromUnparsed(gax::UnparsedResourceName unparsedResourceName) =>
            new SessionName(ResourceNameType.Unparsed, gax::GaxPreconditions.CheckNotNull(unparsedResourceName, nameof(unparsedResourceName)));

        /// <summary>Creates a <see cref="SessionName"/> with the pattern <c>sessions/{session}</c>.</summary>
        /// <param name="sessionId">The <c>Session</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="SessionName"/> constructed from the provided ids.</returns>
        public static SessionName FromSession(string sessionId) =>
            new SessionName(ResourceNameType.Session, sessionId: gax::GaxPreconditions.CheckNotNullOrEmpty(sessionId, nameof(sessionId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="SessionName"/> with pattern
        /// <c>sessions/{session}</c>.
        /// </summary>
        /// <param name="sessionId">The <c>Session</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="SessionName"/> with pattern <c>sessions/{session}</c>.
        /// </returns>
        public static string Format(string sessionId) => FormatSession(sessionId);

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="SessionName"/> with pattern
        /// <c>sessions/{session}</c>.
        /// </summary>
        /// <param name="sessionId">The <c>Session</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="SessionName"/> with pattern <c>sessions/{session}</c>.
        /// </returns>
        public static string FormatSession(string sessionId) =>
            s_session.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(sessionId, nameof(sessionId)));

        /// <summary>Parses the given resource name string into a new <see cref="SessionName"/> instance.</summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>sessions/{session}</c></description></item></list>
        /// </remarks>
        /// <param name="sessionName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="SessionName"/> if successful.</returns>
        public static SessionName Parse(string sessionName) => Parse(sessionName, false);

        /// <summary>
        /// Parses the given resource name string into a new <see cref="SessionName"/> instance; optionally allowing an
        /// unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>sessions/{session}</c></description></item></list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="sessionName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <returns>The parsed <see cref="SessionName"/> if successful.</returns>
        public static SessionName Parse(string sessionName, bool allowUnparsed) =>
            TryParse(sessionName, allowUnparsed, out SessionName result) ? result : throw new sys::ArgumentException("The given resource-name matches no pattern.");

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="SessionName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>sessions/{session}</c></description></item></list>
        /// </remarks>
        /// <param name="sessionName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="SessionName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string sessionName, out SessionName result) => TryParse(sessionName, false, out result);

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="SessionName"/> instance; optionally
        /// allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>sessions/{session}</c></description></item></list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="sessionName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="SessionName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string sessionName, bool allowUnparsed, out SessionName result)
        {
            gax::GaxPreconditions.CheckNotNull(sessionName, nameof(sessionName));
            gax::TemplatedResourceName resourceName;
            if (s_session.TryParseName(sessionName, out resourceName))
            {
                result = FromSession(resourceName[0]);
                return true;
            }
            if (allowUnparsed)
            {
                if (gax::UnparsedResourceName.TryParse(sessionName, out gax::UnparsedResourceName unparsedResourceName))
                {
                    result = FromUnparsed(unparsedResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        private SessionName(ResourceNameType type, gax::UnparsedResourceName unparsedResourceName = null, string sessionId = null)
        {
            Type = type;
            UnparsedResource = unparsedResourceName;
            SessionId = sessionId;
        }

        /// <summary>
        /// Constructs a new instance of a <see cref="SessionName"/> class from the component parts of pattern
        /// <c>sessions/{session}</c>
        /// </summary>
        /// <param name="sessionId">The <c>Session</c> ID. Must not be <c>null</c> or empty.</param>
        public SessionName(string sessionId) : this(ResourceNameType.Session, sessionId: gax::GaxPreconditions.CheckNotNullOrEmpty(sessionId, nameof(sessionId)))
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
        /// The <c>Session</c> ID. Will not be <c>null</c>, unless this instance contains an unparsed resource name.
        /// </summary>
        public string SessionId { get; }

        /// <summary>Whether this instance contains a resource name with a known pattern.</summary>
        public bool IsKnownPattern => Type != ResourceNameType.Unparsed;

        /// <summary>The string representation of the resource name.</summary>
        /// <returns>The string representation of the resource name.</returns>
        public override string ToString()
        {
            switch (Type)
            {
                case ResourceNameType.Unparsed: return UnparsedResource.ToString();
                case ResourceNameType.Session: return s_session.Expand(SessionId);
                default: throw new sys::InvalidOperationException("Unrecognized resource-type.");
            }
        }

        /// <summary>Returns a hash code for this resource name.</summary>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as SessionName);

        /// <inheritdoc/>
        public bool Equals(SessionName other) => ToString() == other?.ToString();

        /// <summary>Determines whether two specified resource names have the same value.</summary>
        /// <param name="a">The first resource name to compare, or null.</param>
        /// <param name="b">The second resource name to compare, or null.</param>
        /// <returns>
        /// true if the value of <paramref name="a"/> is the same as the value of <paramref name="b"/>; otherwise,
        /// false.
        /// </returns>
        public static bool operator ==(SessionName a, SessionName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <summary>Determines whether two specified resource names have different values.</summary>
        /// <param name="a">The first resource name to compare, or null.</param>
        /// <param name="b">The second resource name to compare, or null.</param>
        /// <returns>
        /// true if the value of <paramref name="a"/> is different from the value of <paramref name="b"/>; otherwise,
        /// false.
        /// </returns>
        public static bool operator !=(SessionName a, SessionName b) => !(a == b);
    }

    /// <summary>Resource name for the <c>Blueprint</c> resource.</summary>
    public sealed partial class BlueprintName : gax::IResourceName, sys::IEquatable<BlueprintName>
    {
        /// <summary>The possible contents of <see cref="BlueprintName"/>.</summary>
        public enum ResourceNameType
        {
            /// <summary>An unparsed resource name.</summary>
            Unparsed = 0,

            /// <summary>
            /// A resource name with pattern <c>sessions/{session}/tests/{test}/blueprints/{blueprint}</c>.
            /// </summary>
            SessionTestBlueprint = 1,
        }

        private static gax::PathTemplate s_sessionTestBlueprint = new gax::PathTemplate("sessions/{session}/tests/{test}/blueprints/{blueprint}");

        /// <summary>Creates a <see cref="BlueprintName"/> containing an unparsed resource name.</summary>
        /// <param name="unparsedResourceName">The unparsed resource name. Must not be <c>null</c>.</param>
        /// <returns>
        /// A new instance of <see cref="BlueprintName"/> containing the provided
        /// <paramref name="unparsedResourceName"/>.
        /// </returns>
        public static BlueprintName FromUnparsed(gax::UnparsedResourceName unparsedResourceName) =>
            new BlueprintName(ResourceNameType.Unparsed, gax::GaxPreconditions.CheckNotNull(unparsedResourceName, nameof(unparsedResourceName)));

        /// <summary>
        /// Creates a <see cref="BlueprintName"/> with the pattern
        /// <c>sessions/{session}/tests/{test}/blueprints/{blueprint}</c>.
        /// </summary>
        /// <param name="sessionId">The <c>Session</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="testId">The <c>Test</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="blueprintId">The <c>Blueprint</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="BlueprintName"/> constructed from the provided ids.</returns>
        public static BlueprintName FromSessionTestBlueprint(string sessionId, string testId, string blueprintId) =>
            new BlueprintName(ResourceNameType.SessionTestBlueprint, sessionId: gax::GaxPreconditions.CheckNotNullOrEmpty(sessionId, nameof(sessionId)), testId: gax::GaxPreconditions.CheckNotNullOrEmpty(testId, nameof(testId)), blueprintId: gax::GaxPreconditions.CheckNotNullOrEmpty(blueprintId, nameof(blueprintId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="BlueprintName"/> with pattern
        /// <c>sessions/{session}/tests/{test}/blueprints/{blueprint}</c>.
        /// </summary>
        /// <param name="sessionId">The <c>Session</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="testId">The <c>Test</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="blueprintId">The <c>Blueprint</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="BlueprintName"/> with pattern
        /// <c>sessions/{session}/tests/{test}/blueprints/{blueprint}</c>.
        /// </returns>
        public static string Format(string sessionId, string testId, string blueprintId) =>
            FormatSessionTestBlueprint(sessionId, testId, blueprintId);

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="BlueprintName"/> with pattern
        /// <c>sessions/{session}/tests/{test}/blueprints/{blueprint}</c>.
        /// </summary>
        /// <param name="sessionId">The <c>Session</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="testId">The <c>Test</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="blueprintId">The <c>Blueprint</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="BlueprintName"/> with pattern
        /// <c>sessions/{session}/tests/{test}/blueprints/{blueprint}</c>.
        /// </returns>
        public static string FormatSessionTestBlueprint(string sessionId, string testId, string blueprintId) =>
            s_sessionTestBlueprint.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(sessionId, nameof(sessionId)), gax::GaxPreconditions.CheckNotNullOrEmpty(testId, nameof(testId)), gax::GaxPreconditions.CheckNotNullOrEmpty(blueprintId, nameof(blueprintId)));

        /// <summary>Parses the given resource name string into a new <see cref="BlueprintName"/> instance.</summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>sessions/{session}/tests/{test}/blueprints/{blueprint}</c></description></item>
        /// </list>
        /// </remarks>
        /// <param name="blueprintName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="BlueprintName"/> if successful.</returns>
        public static BlueprintName Parse(string blueprintName) => Parse(blueprintName, false);

        /// <summary>
        /// Parses the given resource name string into a new <see cref="BlueprintName"/> instance; optionally allowing
        /// an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>sessions/{session}/tests/{test}/blueprints/{blueprint}</c></description></item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="blueprintName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <returns>The parsed <see cref="BlueprintName"/> if successful.</returns>
        public static BlueprintName Parse(string blueprintName, bool allowUnparsed) =>
            TryParse(blueprintName, allowUnparsed, out BlueprintName result) ? result : throw new sys::ArgumentException("The given resource-name matches no pattern.");

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="BlueprintName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>sessions/{session}/tests/{test}/blueprints/{blueprint}</c></description></item>
        /// </list>
        /// </remarks>
        /// <param name="blueprintName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="BlueprintName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string blueprintName, out BlueprintName result) => TryParse(blueprintName, false, out result);

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="BlueprintName"/> instance; optionally
        /// allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet">
        /// <item><description><c>sessions/{session}/tests/{test}/blueprints/{blueprint}</c></description></item>
        /// </list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="blueprintName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="BlueprintName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string blueprintName, bool allowUnparsed, out BlueprintName result)
        {
            gax::GaxPreconditions.CheckNotNull(blueprintName, nameof(blueprintName));
            gax::TemplatedResourceName resourceName;
            if (s_sessionTestBlueprint.TryParseName(blueprintName, out resourceName))
            {
                result = FromSessionTestBlueprint(resourceName[0], resourceName[1], resourceName[2]);
                return true;
            }
            if (allowUnparsed)
            {
                if (gax::UnparsedResourceName.TryParse(blueprintName, out gax::UnparsedResourceName unparsedResourceName))
                {
                    result = FromUnparsed(unparsedResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        private BlueprintName(ResourceNameType type, gax::UnparsedResourceName unparsedResourceName = null, string blueprintId = null, string sessionId = null, string testId = null)
        {
            Type = type;
            UnparsedResource = unparsedResourceName;
            BlueprintId = blueprintId;
            SessionId = sessionId;
            TestId = testId;
        }

        /// <summary>
        /// Constructs a new instance of a <see cref="BlueprintName"/> class from the component parts of pattern
        /// <c>sessions/{session}/tests/{test}/blueprints/{blueprint}</c>
        /// </summary>
        /// <param name="sessionId">The <c>Session</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="testId">The <c>Test</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="blueprintId">The <c>Blueprint</c> ID. Must not be <c>null</c> or empty.</param>
        public BlueprintName(string sessionId, string testId, string blueprintId) : this(ResourceNameType.SessionTestBlueprint, sessionId: gax::GaxPreconditions.CheckNotNullOrEmpty(sessionId, nameof(sessionId)), testId: gax::GaxPreconditions.CheckNotNullOrEmpty(testId, nameof(testId)), blueprintId: gax::GaxPreconditions.CheckNotNullOrEmpty(blueprintId, nameof(blueprintId)))
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
        /// The <c>Blueprint</c> ID. Will not be <c>null</c>, unless this instance contains an unparsed resource name.
        /// </summary>
        public string BlueprintId { get; }

        /// <summary>
        /// The <c>Session</c> ID. Will not be <c>null</c>, unless this instance contains an unparsed resource name.
        /// </summary>
        public string SessionId { get; }

        /// <summary>
        /// The <c>Test</c> ID. Will not be <c>null</c>, unless this instance contains an unparsed resource name.
        /// </summary>
        public string TestId { get; }

        /// <summary>Whether this instance contains a resource name with a known pattern.</summary>
        public bool IsKnownPattern => Type != ResourceNameType.Unparsed;

        /// <summary>The string representation of the resource name.</summary>
        /// <returns>The string representation of the resource name.</returns>
        public override string ToString()
        {
            switch (Type)
            {
                case ResourceNameType.Unparsed: return UnparsedResource.ToString();
                case ResourceNameType.SessionTestBlueprint: return s_sessionTestBlueprint.Expand(SessionId, TestId, BlueprintId);
                default: throw new sys::InvalidOperationException("Unrecognized resource-type.");
            }
        }

        /// <summary>Returns a hash code for this resource name.</summary>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as BlueprintName);

        /// <inheritdoc/>
        public bool Equals(BlueprintName other) => ToString() == other?.ToString();

        /// <summary>Determines whether two specified resource names have the same value.</summary>
        /// <param name="a">The first resource name to compare, or null.</param>
        /// <param name="b">The second resource name to compare, or null.</param>
        /// <returns>
        /// true if the value of <paramref name="a"/> is the same as the value of <paramref name="b"/>; otherwise,
        /// false.
        /// </returns>
        public static bool operator ==(BlueprintName a, BlueprintName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <summary>Determines whether two specified resource names have different values.</summary>
        /// <param name="a">The first resource name to compare, or null.</param>
        /// <param name="b">The second resource name to compare, or null.</param>
        /// <returns>
        /// true if the value of <paramref name="a"/> is different from the value of <paramref name="b"/>; otherwise,
        /// false.
        /// </returns>
        public static bool operator !=(BlueprintName a, BlueprintName b) => !(a == b);
    }

    /// <summary>Resource name for the <c>Test</c> resource.</summary>
    public sealed partial class TestName : gax::IResourceName, sys::IEquatable<TestName>
    {
        /// <summary>The possible contents of <see cref="TestName"/>.</summary>
        public enum ResourceNameType
        {
            /// <summary>An unparsed resource name.</summary>
            Unparsed = 0,

            /// <summary>A resource name with pattern <c>sessions/{session}/tests/{test}</c>.</summary>
            SessionTest = 1,
        }

        private static gax::PathTemplate s_sessionTest = new gax::PathTemplate("sessions/{session}/tests/{test}");

        /// <summary>Creates a <see cref="TestName"/> containing an unparsed resource name.</summary>
        /// <param name="unparsedResourceName">The unparsed resource name. Must not be <c>null</c>.</param>
        /// <returns>
        /// A new instance of <see cref="TestName"/> containing the provided <paramref name="unparsedResourceName"/>.
        /// </returns>
        public static TestName FromUnparsed(gax::UnparsedResourceName unparsedResourceName) =>
            new TestName(ResourceNameType.Unparsed, gax::GaxPreconditions.CheckNotNull(unparsedResourceName, nameof(unparsedResourceName)));

        /// <summary>Creates a <see cref="TestName"/> with the pattern <c>sessions/{session}/tests/{test}</c>.</summary>
        /// <param name="sessionId">The <c>Session</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="testId">The <c>Test</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="TestName"/> constructed from the provided ids.</returns>
        public static TestName FromSessionTest(string sessionId, string testId) =>
            new TestName(ResourceNameType.SessionTest, sessionId: gax::GaxPreconditions.CheckNotNullOrEmpty(sessionId, nameof(sessionId)), testId: gax::GaxPreconditions.CheckNotNullOrEmpty(testId, nameof(testId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="TestName"/> with pattern
        /// <c>sessions/{session}/tests/{test}</c>.
        /// </summary>
        /// <param name="sessionId">The <c>Session</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="testId">The <c>Test</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="TestName"/> with pattern <c>sessions/{session}/tests/{test}</c>
        /// .
        /// </returns>
        public static string Format(string sessionId, string testId) => FormatSessionTest(sessionId, testId);

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="TestName"/> with pattern
        /// <c>sessions/{session}/tests/{test}</c>.
        /// </summary>
        /// <param name="sessionId">The <c>Session</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="testId">The <c>Test</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="TestName"/> with pattern <c>sessions/{session}/tests/{test}</c>
        /// .
        /// </returns>
        public static string FormatSessionTest(string sessionId, string testId) =>
            s_sessionTest.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(sessionId, nameof(sessionId)), gax::GaxPreconditions.CheckNotNullOrEmpty(testId, nameof(testId)));

        /// <summary>Parses the given resource name string into a new <see cref="TestName"/> instance.</summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>sessions/{session}/tests/{test}</c></description></item></list>
        /// </remarks>
        /// <param name="testName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="TestName"/> if successful.</returns>
        public static TestName Parse(string testName) => Parse(testName, false);

        /// <summary>
        /// Parses the given resource name string into a new <see cref="TestName"/> instance; optionally allowing an
        /// unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>sessions/{session}/tests/{test}</c></description></item></list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="testName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <returns>The parsed <see cref="TestName"/> if successful.</returns>
        public static TestName Parse(string testName, bool allowUnparsed) =>
            TryParse(testName, allowUnparsed, out TestName result) ? result : throw new sys::ArgumentException("The given resource-name matches no pattern.");

        /// <summary>Tries to parse the given resource name string into a new <see cref="TestName"/> instance.</summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>sessions/{session}/tests/{test}</c></description></item></list>
        /// </remarks>
        /// <param name="testName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="TestName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string testName, out TestName result) => TryParse(testName, false, out result);

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="TestName"/> instance; optionally
        /// allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>sessions/{session}/tests/{test}</c></description></item></list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="testName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="TestName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string testName, bool allowUnparsed, out TestName result)
        {
            gax::GaxPreconditions.CheckNotNull(testName, nameof(testName));
            gax::TemplatedResourceName resourceName;
            if (s_sessionTest.TryParseName(testName, out resourceName))
            {
                result = FromSessionTest(resourceName[0], resourceName[1]);
                return true;
            }
            if (allowUnparsed)
            {
                if (gax::UnparsedResourceName.TryParse(testName, out gax::UnparsedResourceName unparsedResourceName))
                {
                    result = FromUnparsed(unparsedResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        private TestName(ResourceNameType type, gax::UnparsedResourceName unparsedResourceName = null, string sessionId = null, string testId = null)
        {
            Type = type;
            UnparsedResource = unparsedResourceName;
            SessionId = sessionId;
            TestId = testId;
        }

        /// <summary>
        /// Constructs a new instance of a <see cref="TestName"/> class from the component parts of pattern
        /// <c>sessions/{session}/tests/{test}</c>
        /// </summary>
        /// <param name="sessionId">The <c>Session</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="testId">The <c>Test</c> ID. Must not be <c>null</c> or empty.</param>
        public TestName(string sessionId, string testId) : this(ResourceNameType.SessionTest, sessionId: gax::GaxPreconditions.CheckNotNullOrEmpty(sessionId, nameof(sessionId)), testId: gax::GaxPreconditions.CheckNotNullOrEmpty(testId, nameof(testId)))
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
        /// The <c>Session</c> ID. Will not be <c>null</c>, unless this instance contains an unparsed resource name.
        /// </summary>
        public string SessionId { get; }

        /// <summary>
        /// The <c>Test</c> ID. Will not be <c>null</c>, unless this instance contains an unparsed resource name.
        /// </summary>
        public string TestId { get; }

        /// <summary>Whether this instance contains a resource name with a known pattern.</summary>
        public bool IsKnownPattern => Type != ResourceNameType.Unparsed;

        /// <summary>The string representation of the resource name.</summary>
        /// <returns>The string representation of the resource name.</returns>
        public override string ToString()
        {
            switch (Type)
            {
                case ResourceNameType.Unparsed: return UnparsedResource.ToString();
                case ResourceNameType.SessionTest: return s_sessionTest.Expand(SessionId, TestId);
                default: throw new sys::InvalidOperationException("Unrecognized resource-type.");
            }
        }

        /// <summary>Returns a hash code for this resource name.</summary>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as TestName);

        /// <inheritdoc/>
        public bool Equals(TestName other) => ToString() == other?.ToString();

        /// <summary>Determines whether two specified resource names have the same value.</summary>
        /// <param name="a">The first resource name to compare, or null.</param>
        /// <param name="b">The second resource name to compare, or null.</param>
        /// <returns>
        /// true if the value of <paramref name="a"/> is the same as the value of <paramref name="b"/>; otherwise,
        /// false.
        /// </returns>
        public static bool operator ==(TestName a, TestName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <summary>Determines whether two specified resource names have different values.</summary>
        /// <param name="a">The first resource name to compare, or null.</param>
        /// <param name="b">The second resource name to compare, or null.</param>
        /// <returns>
        /// true if the value of <paramref name="a"/> is different from the value of <paramref name="b"/>; otherwise,
        /// false.
        /// </returns>
        public static bool operator !=(TestName a, TestName b) => !(a == b);
    }

    public partial class Session
    {
        /// <summary>
        /// <see cref="gsv::SessionName"/>-typed view over the <see cref="Name"/> resource name property.
        /// </summary>
        public gsv::SessionName SessionName
        {
            get => string.IsNullOrEmpty(Name) ? null : gsv::SessionName.Parse(Name, allowUnparsed: true);
            set => Name = value?.ToString() ?? "";
        }
    }

    public partial class GetSessionRequest
    {
        /// <summary>
        /// <see cref="gsv::SessionName"/>-typed view over the <see cref="Name"/> resource name property.
        /// </summary>
        public gsv::SessionName SessionName
        {
            get => string.IsNullOrEmpty(Name) ? null : gsv::SessionName.Parse(Name, allowUnparsed: true);
            set => Name = value?.ToString() ?? "";
        }
    }

    public partial class DeleteSessionRequest
    {
        /// <summary>
        /// <see cref="gsv::SessionName"/>-typed view over the <see cref="Name"/> resource name property.
        /// </summary>
        public gsv::SessionName SessionName
        {
            get => string.IsNullOrEmpty(Name) ? null : gsv::SessionName.Parse(Name, allowUnparsed: true);
            set => Name = value?.ToString() ?? "";
        }
    }

    public partial class ReportSessionRequest
    {
        /// <summary>
        /// <see cref="gsv::SessionName"/>-typed view over the <see cref="Name"/> resource name property.
        /// </summary>
        public gsv::SessionName SessionName
        {
            get => string.IsNullOrEmpty(Name) ? null : gsv::SessionName.Parse(Name, allowUnparsed: true);
            set => Name = value?.ToString() ?? "";
        }
    }

    public partial class Test
    {
        /// <summary>
        /// <see cref="gsv::TestName"/>-typed view over the <see cref="Name"/> resource name property.
        /// </summary>
        public gsv::TestName TestName
        {
            get => string.IsNullOrEmpty(Name) ? null : gsv::TestName.Parse(Name, allowUnparsed: true);
            set => Name = value?.ToString() ?? "";
        }
    }

    public partial class ListTestsRequest
    {
        /// <summary>
        /// <see cref="SessionName"/>-typed view over the <see cref="Parent"/> resource name property.
        /// </summary>
        public SessionName ParentAsSessionName
        {
            get => string.IsNullOrEmpty(Parent) ? null : SessionName.Parse(Parent, allowUnparsed: true);
            set => Parent = value?.ToString() ?? "";
        }
    }

    public partial class TestRun
    {
        /// <summary><see cref="TestName"/>-typed view over the <see cref="Test"/> resource name property.</summary>
        public TestName TestAsTestName
        {
            get => string.IsNullOrEmpty(Test) ? null : TestName.Parse(Test, allowUnparsed: true);
            set => Test = value?.ToString() ?? "";
        }
    }

    public partial class DeleteTestRequest
    {
        /// <summary>
        /// <see cref="gsv::TestName"/>-typed view over the <see cref="Name"/> resource name property.
        /// </summary>
        public gsv::TestName TestName
        {
            get => string.IsNullOrEmpty(Name) ? null : gsv::TestName.Parse(Name, allowUnparsed: true);
            set => Name = value?.ToString() ?? "";
        }
    }

    public partial class VerifyTestRequest
    {
        /// <summary>
        /// <see cref="gsv::TestName"/>-typed view over the <see cref="Name"/> resource name property.
        /// </summary>
        public gsv::TestName TestName
        {
            get => string.IsNullOrEmpty(Name) ? null : gsv::TestName.Parse(Name, allowUnparsed: true);
            set => Name = value?.ToString() ?? "";
        }
    }
}
