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
using gsv = Google.Showcase.V1Beta1;
using sys = System;

namespace Google.Showcase.V1Beta1
{
    /// <summary>Resource name for the <c>Room</c> resource.</summary>
    public sealed partial class RoomName : gax::IResourceName, sys::IEquatable<RoomName>
    {
        /// <summary>The possible contents of <see cref="RoomName"/>.</summary>
        public enum ResourceNameType
        {
            /// <summary>An unparsed resource name.</summary>
            Unparsed = 0,

            /// <summary>A resource name with pattern <c>rooms/{room}</c>.</summary>
            Room = 1,
        }

        private static gax::PathTemplate s_room = new gax::PathTemplate("rooms/{room}");

        /// <summary>Creates a <see cref="RoomName"/> containing an unparsed resource name.</summary>
        /// <param name="unparsedResourceName">The unparsed resource name. Must not be <c>null</c>.</param>
        /// <returns>
        /// A new instance of <see cref="RoomName"/> containing the provided <paramref name="unparsedResourceName"/>.
        /// </returns>
        public static RoomName FromUnparsed(gax::UnparsedResourceName unparsedResourceName) =>
            new RoomName(ResourceNameType.Unparsed, gax::GaxPreconditions.CheckNotNull(unparsedResourceName, nameof(unparsedResourceName)));

        /// <summary>Creates a <see cref="RoomName"/> with the pattern <c>rooms/{room}</c>.</summary>
        /// <param name="roomId">The <c>Room</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="RoomName"/> constructed from the provided ids.</returns>
        public static RoomName FromRoom(string roomId) =>
            new RoomName(ResourceNameType.Room, roomId: gax::GaxPreconditions.CheckNotNullOrEmpty(roomId, nameof(roomId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="RoomName"/> with pattern <c>rooms/{room}</c>
        /// .
        /// </summary>
        /// <param name="roomId">The <c>Room</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="RoomName"/> with pattern <c>rooms/{room}</c>.
        /// </returns>
        public static string Format(string roomId) => FormatRoom(roomId);

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="RoomName"/> with pattern <c>rooms/{room}</c>
        /// .
        /// </summary>
        /// <param name="roomId">The <c>Room</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="RoomName"/> with pattern <c>rooms/{room}</c>.
        /// </returns>
        public static string FormatRoom(string roomId) =>
            s_room.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(roomId, nameof(roomId)));

        /// <summary>Parses the given resource name string into a new <see cref="RoomName"/> instance.</summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>rooms/{room}</c></description></item></list>
        /// </remarks>
        /// <param name="roomName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="RoomName"/> if successful.</returns>
        public static RoomName Parse(string roomName) => Parse(roomName, false);

        /// <summary>
        /// Parses the given resource name string into a new <see cref="RoomName"/> instance; optionally allowing an
        /// unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>rooms/{room}</c></description></item></list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="roomName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <returns>The parsed <see cref="RoomName"/> if successful.</returns>
        public static RoomName Parse(string roomName, bool allowUnparsed) =>
            TryParse(roomName, allowUnparsed, out RoomName result) ? result : throw new sys::ArgumentException("The given resource-name matches no pattern.");

        /// <summary>Tries to parse the given resource name string into a new <see cref="RoomName"/> instance.</summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>rooms/{room}</c></description></item></list>
        /// </remarks>
        /// <param name="roomName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="RoomName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string roomName, out RoomName result) => TryParse(roomName, false, out result);

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="RoomName"/> instance; optionally
        /// allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>rooms/{room}</c></description></item></list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="roomName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="RoomName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string roomName, bool allowUnparsed, out RoomName result)
        {
            gax::GaxPreconditions.CheckNotNull(roomName, nameof(roomName));
            gax::TemplatedResourceName resourceName;
            if (s_room.TryParseName(roomName, out resourceName))
            {
                result = FromRoom(resourceName[0]);
                return true;
            }
            if (allowUnparsed)
            {
                if (gax::UnparsedResourceName.TryParse(roomName, out gax::UnparsedResourceName unparsedResourceName))
                {
                    result = FromUnparsed(unparsedResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        private RoomName(ResourceNameType type, gax::UnparsedResourceName unparsedResourceName = null, string roomId = null)
        {
            Type = type;
            UnparsedResource = unparsedResourceName;
            RoomId = roomId;
        }

        /// <summary>
        /// Constructs a new instance of a <see cref="RoomName"/> class from the component parts of pattern
        /// <c>rooms/{room}</c>
        /// </summary>
        /// <param name="roomId">The <c>Room</c> ID. Must not be <c>null</c> or empty.</param>
        public RoomName(string roomId) : this(ResourceNameType.Room, roomId: gax::GaxPreconditions.CheckNotNullOrEmpty(roomId, nameof(roomId)))
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
        /// The <c>Room</c> ID. Will not be <c>null</c>, unless this instance contains an unparsed resource name.
        /// </summary>
        public string RoomId { get; }

        /// <summary>Whether this instance contains a resource name with a known pattern.</summary>
        public bool IsKnownPattern => Type != ResourceNameType.Unparsed;

        /// <summary>The string representation of the resource name.</summary>
        /// <returns>The string representation of the resource name.</returns>
        public override string ToString()
        {
            switch (Type)
            {
                case ResourceNameType.Unparsed: return UnparsedResource.ToString();
                case ResourceNameType.Room: return s_room.Expand(RoomId);
                default: throw new sys::InvalidOperationException("Unrecognized resource-type.");
            }
        }

        /// <summary>Returns a hash code for this resource name.</summary>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as RoomName);

        /// <inheritdoc/>
        public bool Equals(RoomName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(RoomName a, RoomName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(RoomName a, RoomName b) => !(a == b);
    }

    /// <summary>Resource name for the <c>Blurb</c> resource.</summary>
    public sealed partial class BlurbName : gax::IResourceName, sys::IEquatable<BlurbName>
    {
        /// <summary>The possible contents of <see cref="BlurbName"/>.</summary>
        public enum ResourceNameType
        {
            /// <summary>An unparsed resource name.</summary>
            Unparsed = 0,

            /// <summary>A resource name with pattern <c>rooms/{room}/blurbs/{blurb}</c>.</summary>
            RoomBlurb = 1,
        }

        private static gax::PathTemplate s_roomBlurb = new gax::PathTemplate("rooms/{room}/blurbs/{blurb}");

        /// <summary>Creates a <see cref="BlurbName"/> containing an unparsed resource name.</summary>
        /// <param name="unparsedResourceName">The unparsed resource name. Must not be <c>null</c>.</param>
        /// <returns>
        /// A new instance of <see cref="BlurbName"/> containing the provided <paramref name="unparsedResourceName"/>.
        /// </returns>
        public static BlurbName FromUnparsed(gax::UnparsedResourceName unparsedResourceName) =>
            new BlurbName(ResourceNameType.Unparsed, gax::GaxPreconditions.CheckNotNull(unparsedResourceName, nameof(unparsedResourceName)));

        /// <summary>Creates a <see cref="BlurbName"/> with the pattern <c>rooms/{room}/blurbs/{blurb}</c>.</summary>
        /// <param name="roomId">The <c>Room</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="blurbId">The <c>Blurb</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>A new instance of <see cref="BlurbName"/> constructed from the provided ids.</returns>
        public static BlurbName FromRoomBlurb(string roomId, string blurbId) =>
            new BlurbName(ResourceNameType.RoomBlurb, roomId: gax::GaxPreconditions.CheckNotNullOrEmpty(roomId, nameof(roomId)), blurbId: gax::GaxPreconditions.CheckNotNullOrEmpty(blurbId, nameof(blurbId)));

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="BlurbName"/> with pattern
        /// <c>rooms/{room}/blurbs/{blurb}</c>.
        /// </summary>
        /// <param name="roomId">The <c>Room</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="blurbId">The <c>Blurb</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="BlurbName"/> with pattern <c>rooms/{room}/blurbs/{blurb}</c>.
        /// </returns>
        public static string Format(string roomId, string blurbId) => FormatRoomBlurb(roomId, blurbId);

        /// <summary>
        /// Formats the IDs into the string representation of this <see cref="BlurbName"/> with pattern
        /// <c>rooms/{room}/blurbs/{blurb}</c>.
        /// </summary>
        /// <param name="roomId">The <c>Room</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="blurbId">The <c>Blurb</c> ID. Must not be <c>null</c> or empty.</param>
        /// <returns>
        /// The string representation of this <see cref="BlurbName"/> with pattern <c>rooms/{room}/blurbs/{blurb}</c>.
        /// </returns>
        public static string FormatRoomBlurb(string roomId, string blurbId) =>
            s_roomBlurb.Expand(gax::GaxPreconditions.CheckNotNullOrEmpty(roomId, nameof(roomId)), gax::GaxPreconditions.CheckNotNullOrEmpty(blurbId, nameof(blurbId)));

        /// <summary>Parses the given resource name string into a new <see cref="BlurbName"/> instance.</summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>rooms/{room}/blurbs/{blurb}</c></description></item></list>
        /// </remarks>
        /// <param name="blurbName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="BlurbName"/> if successful.</returns>
        public static BlurbName Parse(string blurbName) => Parse(blurbName, false);

        /// <summary>
        /// Parses the given resource name string into a new <see cref="BlurbName"/> instance; optionally allowing an
        /// unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>rooms/{room}/blurbs/{blurb}</c></description></item></list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="blurbName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <returns>The parsed <see cref="BlurbName"/> if successful.</returns>
        public static BlurbName Parse(string blurbName, bool allowUnparsed) =>
            TryParse(blurbName, allowUnparsed, out BlurbName result) ? result : throw new sys::ArgumentException("The given resource-name matches no pattern.");

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="BlurbName"/> instance.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>rooms/{room}/blurbs/{blurb}</c></description></item></list>
        /// </remarks>
        /// <param name="blurbName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="BlurbName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string blurbName, out BlurbName result) => TryParse(blurbName, false, out result);

        /// <summary>
        /// Tries to parse the given resource name string into a new <see cref="BlurbName"/> instance; optionally
        /// allowing an unparseable resource name.
        /// </summary>
        /// <remarks>
        /// To parse successfully, the resource name must be formatted as one of the following:
        /// <list type="bullet"><item><description><c>rooms/{room}/blurbs/{blurb}</c></description></item></list>
        /// Or may be in any format if <paramref name="allowUnparsed"/> is <c>true</c>.
        /// </remarks>
        /// <param name="blurbName">The resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="allowUnparsed">
        /// If <c>true</c> will successfully store an unparseable resource name into the <see cref="UnparsedResource"/>
        /// property; otherwise will throw an <see cref="sys::ArgumentException"/> if an unparseable resource name is
        /// specified.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="BlurbName"/>, or <c>null</c> if parsing failed.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string blurbName, bool allowUnparsed, out BlurbName result)
        {
            gax::GaxPreconditions.CheckNotNull(blurbName, nameof(blurbName));
            gax::TemplatedResourceName resourceName;
            if (s_roomBlurb.TryParseName(blurbName, out resourceName))
            {
                result = FromRoomBlurb(resourceName[0], resourceName[1]);
                return true;
            }
            if (allowUnparsed)
            {
                if (gax::UnparsedResourceName.TryParse(blurbName, out gax::UnparsedResourceName unparsedResourceName))
                {
                    result = FromUnparsed(unparsedResourceName);
                    return true;
                }
            }
            result = null;
            return false;
        }

        private BlurbName(ResourceNameType type, gax::UnparsedResourceName unparsedResourceName = null, string blurbId = null, string roomId = null)
        {
            Type = type;
            UnparsedResource = unparsedResourceName;
            BlurbId = blurbId;
            RoomId = roomId;
        }

        /// <summary>
        /// Constructs a new instance of a <see cref="BlurbName"/> class from the component parts of pattern
        /// <c>rooms/{room}/blurbs/{blurb}</c>
        /// </summary>
        /// <param name="roomId">The <c>Room</c> ID. Must not be <c>null</c> or empty.</param>
        /// <param name="blurbId">The <c>Blurb</c> ID. Must not be <c>null</c> or empty.</param>
        public BlurbName(string roomId, string blurbId) : this(ResourceNameType.RoomBlurb, roomId: gax::GaxPreconditions.CheckNotNullOrEmpty(roomId, nameof(roomId)), blurbId: gax::GaxPreconditions.CheckNotNullOrEmpty(blurbId, nameof(blurbId)))
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
        /// The <c>Blurb</c> ID. Will not be <c>null</c>, unless this instance contains an unparsed resource name.
        /// </summary>
        public string BlurbId { get; }

        /// <summary>
        /// The <c>Room</c> ID. Will not be <c>null</c>, unless this instance contains an unparsed resource name.
        /// </summary>
        public string RoomId { get; }

        /// <summary>Whether this instance contains a resource name with a known pattern.</summary>
        public bool IsKnownPattern => Type != ResourceNameType.Unparsed;

        /// <summary>The string representation of the resource name.</summary>
        /// <returns>The string representation of the resource name.</returns>
        public override string ToString()
        {
            switch (Type)
            {
                case ResourceNameType.Unparsed: return UnparsedResource.ToString();
                case ResourceNameType.RoomBlurb: return s_roomBlurb.Expand(RoomId, BlurbId);
                default: throw new sys::InvalidOperationException("Unrecognized resource-type.");
            }
        }

        /// <summary>Returns a hash code for this resource name.</summary>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as BlurbName);

        /// <inheritdoc/>
        public bool Equals(BlurbName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(BlurbName a, BlurbName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(BlurbName a, BlurbName b) => !(a == b);
    }

    public partial class Room
    {
        /// <summary>
        /// <see cref="gsv::RoomName"/>-typed view over the <see cref="Name"/> resource name property.
        /// </summary>
        public gsv::RoomName RoomName
        {
            get => string.IsNullOrEmpty(Name) ? null : gsv::RoomName.Parse(Name, allowUnparsed: true);
            set => Name = value?.ToString() ?? "";
        }
    }

    public partial class GetRoomRequest
    {
        /// <summary>
        /// <see cref="gsv::RoomName"/>-typed view over the <see cref="Name"/> resource name property.
        /// </summary>
        public gsv::RoomName RoomName
        {
            get => string.IsNullOrEmpty(Name) ? null : gsv::RoomName.Parse(Name, allowUnparsed: true);
            set => Name = value?.ToString() ?? "";
        }
    }

    public partial class DeleteRoomRequest
    {
        /// <summary>
        /// <see cref="gsv::RoomName"/>-typed view over the <see cref="Name"/> resource name property.
        /// </summary>
        public gsv::RoomName RoomName
        {
            get => string.IsNullOrEmpty(Name) ? null : gsv::RoomName.Parse(Name, allowUnparsed: true);
            set => Name = value?.ToString() ?? "";
        }
    }

    public partial class Blurb
    {
        /// <summary>
        /// <see cref="gsv::BlurbName"/>-typed view over the <see cref="Name"/> resource name property.
        /// </summary>
        public gsv::BlurbName BlurbName
        {
            get => string.IsNullOrEmpty(Name) ? null : gsv::BlurbName.Parse(Name, allowUnparsed: true);
            set => Name = value?.ToString() ?? "";
        }

        /// <summary><see cref="UserName"/>-typed view over the <see cref="User"/> resource name property.</summary>
        public UserName UserAsUserName
        {
            get => string.IsNullOrEmpty(User) ? null : UserName.Parse(User, allowUnparsed: true);
            set => User = value?.ToString() ?? "";
        }
    }

    public partial class CreateBlurbRequest
    {
        /// <summary><see cref="RoomName"/>-typed view over the <see cref="Parent"/> resource name property.</summary>
        public RoomName ParentAsRoomName
        {
            get => string.IsNullOrEmpty(Parent) ? null : RoomName.Parse(Parent, allowUnparsed: true);
            set => Parent = value?.ToString() ?? "";
        }
    }

    public partial class GetBlurbRequest
    {
        /// <summary>
        /// <see cref="gsv::BlurbName"/>-typed view over the <see cref="Name"/> resource name property.
        /// </summary>
        public gsv::BlurbName BlurbName
        {
            get => string.IsNullOrEmpty(Name) ? null : gsv::BlurbName.Parse(Name, allowUnparsed: true);
            set => Name = value?.ToString() ?? "";
        }
    }

    public partial class DeleteBlurbRequest
    {
        /// <summary>
        /// <see cref="gsv::BlurbName"/>-typed view over the <see cref="Name"/> resource name property.
        /// </summary>
        public gsv::BlurbName BlurbName
        {
            get => string.IsNullOrEmpty(Name) ? null : gsv::BlurbName.Parse(Name, allowUnparsed: true);
            set => Name = value?.ToString() ?? "";
        }
    }

    public partial class ListBlurbsRequest
    {
        /// <summary><see cref="RoomName"/>-typed view over the <see cref="Parent"/> resource name property.</summary>
        public RoomName ParentAsRoomName
        {
            get => string.IsNullOrEmpty(Parent) ? null : RoomName.Parse(Parent, allowUnparsed: true);
            set => Parent = value?.ToString() ?? "";
        }
    }

    public partial class SearchBlurbsRequest
    {
        /// <summary><see cref="RoomName"/>-typed view over the <see cref="Parent"/> resource name property.</summary>
        public RoomName ParentAsRoomName
        {
            get => string.IsNullOrEmpty(Parent) ? null : RoomName.Parse(Parent, allowUnparsed: true);
            set => Parent = value?.ToString() ?? "";
        }
    }

    public partial class StreamBlurbsRequest
    {
        /// <summary>
        /// <see cref="gsv::RoomName"/>-typed view over the <see cref="Name"/> resource name property.
        /// </summary>
        public gsv::RoomName RoomName
        {
            get => string.IsNullOrEmpty(Name) ? null : gsv::RoomName.Parse(Name, allowUnparsed: true);
            set => Name = value?.ToString() ?? "";
        }
    }
}
