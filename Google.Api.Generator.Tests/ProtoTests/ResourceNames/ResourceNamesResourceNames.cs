using gax = Google.Api.Gax;
using sys = System;

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
        /// <param name="simpleresource">
        /// The <c>SimpleResource</c> resource name in string form. Must not be <c>null</c>.
        /// </param>
        /// <returns>The parsed <see cref="SimpleResourceName"/> if successful.</returns>
        public static SimpleResourceName Parse(string simpleresource)
        {
            gax::GaxPreconditions.CheckNotNull(simpleresource, nameof(simpleresource));
            gax::TemplatedResourceName resourceName = s_template.ParseName(simpleresource);
            return new SimpleResourceName(resourceName[0]);
        }

        /// <summary>
        /// Tries to parse the given session resource name in string form into a new <see cref="SimpleResourceName"/>
        /// instance.
        /// </summary>
        /// <remarks>
        /// This method still throws <see cref="sys::ArgumentNullException"/> if <paramref name="simpleresource"/> is
        /// <c>null</c>, as this would usually indicate a programming error rather than a data error.
        /// </remarks>
        /// <param name="simpleresource">
        /// The <c>SimpleResource</c> resource name in string form. Must not be <c>null</c>.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="SimpleResourceName"/>, or <c>null</c> if parsing fails.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string simpleresource, out SimpleResourceName result)
        {
            gax::GaxPreconditions.CheckNotNull(simpleresource, nameof(simpleresource));
            if (s_template.TryParseName(simpleresource, out gax::TemplatedResourceName resourceName))
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

    public partial class SimpleResource
    {
        /// <summary>
        /// <see cref="SimpleResourceName"/>-typed view over the <see cref="Name"/> resource name property.
        /// </summary>
        public SimpleResourceName NameAsSimpleResourceName
        {
            get => string.IsNullOrEmpty(Name) ? null : SimpleResourceName.Parse(Name);
            set => Name = value?.ToString() ?? "";
        }
    }
}
