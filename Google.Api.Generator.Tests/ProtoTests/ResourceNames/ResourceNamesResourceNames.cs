using gax = Google.Api.Gax;
using sys = System;
using tr = Testing.Resourcenames;

namespace Testing.Resourcenames
{
    /// <summary>Resource name for the <c>SimpleResource</c> resource</summary>
    public sealed partial class SimpleResourceName : gax::IResourceName, sys::IEquatable<SimpleResourceName>
    {
        private static readonly gax::PathTemplate s_template = new gax::PathTemplate("items/{item_id}");

        /// <summary>
        /// Parses the given <c>SimpleResource</c> resource name in string form into a new
        /// <see cref="SimpleResourceName"/> instance.
        /// </summary>
        /// <param name="simpleResource">
        /// The <c>SimpleResource</c> resource name in string form. Must not be <c>null</c>.
        /// </param>
        /// <returns>The parsed <see cref="SimpleResourceName"/> if successful.</returns>
        public static SimpleResourceName Parse(string simpleResource)
        {
            gax::GaxPreconditions.CheckNotNull(simpleResource, nameof(simpleResource));
            gax::TemplatedResourceName resourceName = s_template.ParseName(simpleResource);
            return new SimpleResourceName(resourceName[0]);
        }

        /// <summary>
        /// Tries to parse the given session resource name in string form into a new <see cref="SimpleResourceName"/>
        /// instance.
        /// </summary>
        /// <remarks>
        /// This method still throws <see cref="sys::ArgumentNullException"/> if <paramref name="simpleResource"/> is
        /// <c>null</c>, as this would usually indicate a programming error rather than a data error.
        /// </remarks>
        /// <param name="simpleResource">
        /// The <c>SimpleResource</c> resource name in string form. Must not be <c>null</c>.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="SimpleResourceName"/>, or <c>null</c> if parsing fails.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string simpleResource, out SimpleResourceName result)
        {
            gax::GaxPreconditions.CheckNotNull(simpleResource, nameof(simpleResource));
            if (s_template.TryParseName(simpleResource, out gax::TemplatedResourceName resourceName))
            {
                result = new SimpleResourceName(resourceName[0]);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        /// <summary>
        /// Constructs a new instance of the <see cref="SimpleResourceName"/> resource name class from its component
        /// parts.
        /// </summary>
        /// <param name="itemId">The itemId ID. Must not be <c>null</c>.</param>
        public SimpleResourceName(string itemId) => ItemId = gax::GaxPreconditions.CheckNotNull(itemId, nameof(itemId));

        /// <summary>The ItemId ID. Never <c>null</c>.</summary>
        public string ItemId { get; }

        /// <inheritdoc/>
        public gax::ResourceNameKind Kind => gax::ResourceNameKind.Simple;

        /// <inheritdoc/>
        public override string ToString() => s_template.Expand(ItemId);

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as SimpleResourceName);

        /// <inheritdoc/>
        public bool Equals(SimpleResourceName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(SimpleResourceName a, SimpleResourceName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(SimpleResourceName a, SimpleResourceName b) => !(a == b);
    }

    /// <summary>Resource name for the <c>SimpleInlineResource</c> resource</summary>
    public sealed partial class SimpleInlineResourceName : gax::IResourceName, sys::IEquatable<SimpleInlineResourceName>
    {
        private static readonly gax::PathTemplate s_template = new gax::PathTemplate("items1/{item1_id}/items2/{item2_id}");

        /// <summary>
        /// Parses the given <c>SimpleInlineResource</c> resource name in string form into a new
        /// <see cref="SimpleInlineResourceName"/> instance.
        /// </summary>
        /// <param name="simpleInlineResource">
        /// The <c>SimpleInlineResource</c> resource name in string form. Must not be <c>null</c>.
        /// </param>
        /// <returns>The parsed <see cref="SimpleInlineResourceName"/> if successful.</returns>
        public static SimpleInlineResourceName Parse(string simpleInlineResource)
        {
            gax::GaxPreconditions.CheckNotNull(simpleInlineResource, nameof(simpleInlineResource));
            gax::TemplatedResourceName resourceName = s_template.ParseName(simpleInlineResource);
            return new SimpleInlineResourceName(resourceName[0], resourceName[1]);
        }

        /// <summary>
        /// Tries to parse the given session resource name in string form into a new
        /// <see cref="SimpleInlineResourceName"/> instance.
        /// </summary>
        /// <remarks>
        /// This method still throws <see cref="sys::ArgumentNullException"/> if <paramref name="simpleInlineResource"/>
        /// is <c>null</c>, as this would usually indicate a programming error rather than a data error.
        /// </remarks>
        /// <param name="simpleInlineResource">
        /// The <c>SimpleInlineResource</c> resource name in string form. Must not be <c>null</c>.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="SimpleInlineResourceName"/>, or <c>null</c> if parsing
        /// fails.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string simpleInlineResource, out SimpleInlineResourceName result)
        {
            gax::GaxPreconditions.CheckNotNull(simpleInlineResource, nameof(simpleInlineResource));
            if (s_template.TryParseName(simpleInlineResource, out gax::TemplatedResourceName resourceName))
            {
                result = new SimpleInlineResourceName(resourceName[0], resourceName[1]);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        /// <summary>
        /// Constructs a new instance of the <see cref="SimpleInlineResourceName"/> resource name class from its
        /// component parts.
        /// </summary>
        /// <param name="item1Id">The item1Id ID. Must not be <c>null</c>.</param>
        /// <param name="item2Id">The item2Id ID. Must not be <c>null</c>.</param>
        public SimpleInlineResourceName(string item1Id, string item2Id)
        {
            Item1Id = gax::GaxPreconditions.CheckNotNull(item1Id, nameof(item1Id));
            Item2Id = gax::GaxPreconditions.CheckNotNull(item2Id, nameof(item2Id));
        }

        /// <summary>The Item1Id ID. Never <c>null</c>.</summary>
        public string Item1Id { get; }

        /// <summary>The Item2Id ID. Never <c>null</c>.</summary>
        public string Item2Id { get; }

        /// <inheritdoc/>
        public gax::ResourceNameKind Kind => gax::ResourceNameKind.Simple;

        /// <inheritdoc/>
        public override string ToString() => s_template.Expand(Item1Id, Item2Id);

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as SimpleInlineResourceName);

        /// <inheritdoc/>
        public bool Equals(SimpleInlineResourceName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(SimpleInlineResourceName a, SimpleInlineResourceName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(SimpleInlineResourceName a, SimpleInlineResourceName b) => !(a == b);
    }

    public partial class SimpleResource
    {
        /// <summary>
        /// <see cref="tr::SimpleResourceName"/>-typed view over the <see cref="Name"/> resource name property.
        /// </summary>
        public SimpleResourceName SimpleResourceName
        {
            get => string.IsNullOrEmpty(Name) ? null : SimpleResourceName.Parse(Name);
            set => Name = value?.ToString() ?? "";
        }
    }

    public partial class SimpleInlineResource
    {
        /// <summary>
        /// <see cref="tr::SimpleInlineResourceName"/>-typed view over the <see cref="Name"/> resource name property.
        /// </summary>
        public SimpleInlineResourceName SimpleInlineResourceName
        {
            get => string.IsNullOrEmpty(Name) ? null : SimpleInlineResourceName.Parse(Name);
            set => Name = value?.ToString() ?? "";
        }
    }
}
