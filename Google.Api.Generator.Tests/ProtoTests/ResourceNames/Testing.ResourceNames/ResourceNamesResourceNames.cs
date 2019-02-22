using gax = Google.Api.Gax;
using sys = System;
using tr = Testing.ResourceNames;

namespace Testing.ResourceNames
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
        /// <param name="itemId">The <c>Item</c> ID. Must not be <c>null</c>.</param>
        public SimpleResourceName(string itemId) => ItemId = gax::GaxPreconditions.CheckNotNull(itemId, nameof(itemId));

        /// <summary>The <c>Item</c> ID. Never <c>null</c>.</summary>
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

    /// <summary>Resource name for the <c>CheckIdSuffixResource</c> resource</summary>
    public sealed partial class CheckIdSuffixResourceName : gax::IResourceName, sys::IEquatable<CheckIdSuffixResourceName>
    {
        private static readonly gax::PathTemplate s_template = new gax::PathTemplate("with_suffix/{with_suffix_id}/no_suffix/{no_suffix}");

        /// <summary>
        /// Parses the given <c>CheckIdSuffixResource</c> resource name in string form into a new
        /// <see cref="CheckIdSuffixResourceName"/> instance.
        /// </summary>
        /// <param name="checkIdSuffixResource">
        /// The <c>CheckIdSuffixResource</c> resource name in string form. Must not be <c>null</c>.
        /// </param>
        /// <returns>The parsed <see cref="CheckIdSuffixResourceName"/> if successful.</returns>
        public static CheckIdSuffixResourceName Parse(string checkIdSuffixResource)
        {
            gax::GaxPreconditions.CheckNotNull(checkIdSuffixResource, nameof(checkIdSuffixResource));
            gax::TemplatedResourceName resourceName = s_template.ParseName(checkIdSuffixResource);
            return new CheckIdSuffixResourceName(resourceName[0], resourceName[1]);
        }

        /// <summary>
        /// Tries to parse the given session resource name in string form into a new
        /// <see cref="CheckIdSuffixResourceName"/> instance.
        /// </summary>
        /// <remarks>
        /// This method still throws <see cref="sys::ArgumentNullException"/> if
        /// <paramref name="checkIdSuffixResource"/> is <c>null</c>, as this would usually indicate a programming error
        /// rather than a data error.
        /// </remarks>
        /// <param name="checkIdSuffixResource">
        /// The <c>CheckIdSuffixResource</c> resource name in string form. Must not be <c>null</c>.
        /// </param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="CheckIdSuffixResourceName"/>, or <c>null</c> if parsing
        /// fails.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string checkIdSuffixResource, out CheckIdSuffixResourceName result)
        {
            gax::GaxPreconditions.CheckNotNull(checkIdSuffixResource, nameof(checkIdSuffixResource));
            if (s_template.TryParseName(checkIdSuffixResource, out gax::TemplatedResourceName resourceName))
            {
                result = new CheckIdSuffixResourceName(resourceName[0], resourceName[1]);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        /// <summary>
        /// Constructs a new instance of the <see cref="CheckIdSuffixResourceName"/> resource name class from its
        /// component parts.
        /// </summary>
        /// <param name="withSuffixId">The <c>WithSuffix</c> ID. Must not be <c>null</c>.</param>
        /// <param name="noSuffixId">The <c>NoSuffix</c> ID. Must not be <c>null</c>.</param>
        public CheckIdSuffixResourceName(string withSuffixId, string noSuffixId)
        {
            WithSuffixId = gax::GaxPreconditions.CheckNotNull(withSuffixId, nameof(withSuffixId));
            NoSuffixId = gax::GaxPreconditions.CheckNotNull(noSuffixId, nameof(noSuffixId));
        }

        /// <summary>The <c>WithSuffix</c> ID. Never <c>null</c>.</summary>
        public string WithSuffixId { get; }

        /// <summary>The <c>NoSuffix</c> ID. Never <c>null</c>.</summary>
        public string NoSuffixId { get; }

        /// <inheritdoc/>
        public gax::ResourceNameKind Kind => gax::ResourceNameKind.Simple;

        /// <inheritdoc/>
        public override string ToString() => s_template.Expand(WithSuffixId, NoSuffixId);

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as CheckIdSuffixResourceName);

        /// <inheritdoc/>
        public bool Equals(CheckIdSuffixResourceName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(CheckIdSuffixResourceName a, CheckIdSuffixResourceName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(CheckIdSuffixResourceName a, CheckIdSuffixResourceName b) => !(a == b);
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
        /// <param name="item1Id">The <c>Item1</c> ID. Must not be <c>null</c>.</param>
        /// <param name="item2Id">The <c>Item2</c> ID. Must not be <c>null</c>.</param>
        public SimpleInlineResourceName(string item1Id, string item2Id)
        {
            Item1Id = gax::GaxPreconditions.CheckNotNull(item1Id, nameof(item1Id));
            Item2Id = gax::GaxPreconditions.CheckNotNull(item2Id, nameof(item2Id));
        }

        /// <summary>The <c>Item1</c> ID. Never <c>null</c>.</summary>
        public string Item1Id { get; }

        /// <summary>The <c>Item2</c> ID. Never <c>null</c>.</summary>
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

    public partial class SimpleRepeatedResource
    {
        /// <summary>
        /// <see cref="SimpleResourceName"/>-typed view over the <see cref="Names"/> resource name property.
        /// </summary>
        public gax::ResourceNameList<SimpleResourceName> SimpleResourceNames => new gax::ResourceNameList<SimpleResourceName>(Names, s => SimpleResourceName.Parse(s));
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

        /// <summary>
        /// <see cref="gax::IResourceName"/>-typed view over the <see cref="Names"/> resource name property.
        /// </summary>
        public gax::ResourceNameList<gax::IResourceName> AsResourceNames => new gax::ResourceNameList<gax::IResourceName>(Names, s => gax::UnknownResourceName.Parse(s));

        /// <summary>
        /// <see cref="gax::IResourceName"/>-typed view over the <see cref="RequiredSingle"/> resource name property.
        /// </summary>
        public gax::IResourceName RequiredSingleAsResourceName
        {
            get => string.IsNullOrEmpty(RequiredSingle) ? null : gax::UnknownResourceName.Parse(RequiredSingle);
            set => RequiredSingle = value?.ToString() ?? "";
        }

        /// <summary>
        /// <see cref="gax::IResourceName"/>-typed view over the <see cref="RequiredRepeated"/> resource name property.
        /// </summary>
        public gax::ResourceNameList<gax::IResourceName> RequiredRepeatedAsResourceNames => new gax::ResourceNameList<gax::IResourceName>(RequiredRepeated, s => gax::UnknownResourceName.Parse(s));
    }

    public partial class MultiCaseRequest
    {
        /// <summary>
        /// <see cref="SimpleResourceName"/>-typed view over the <see cref="OptionalSingle"/> resource name property.
        /// </summary>
        public SimpleResourceName OptionalSingleAsSimpleResourceName
        {
            get => string.IsNullOrEmpty(OptionalSingle) ? null : SimpleResourceName.Parse(OptionalSingle);
            set => OptionalSingle = value?.ToString() ?? "";
        }

        /// <summary>
        /// <see cref="SimpleResourceName"/>-typed view over the <see cref="OptionalRepeated"/> resource name property.
        /// </summary>
        public gax::ResourceNameList<SimpleResourceName> OptionalRepeatedAsSimpleResourceNames => new gax::ResourceNameList<SimpleResourceName>(OptionalRepeated, s => SimpleResourceName.Parse(s));

        /// <summary>
        /// <see cref="SimpleResourceName"/>-typed view over the <see cref="RequiredSingle"/> resource name property.
        /// </summary>
        public SimpleResourceName RequiredSingleAsSimpleResourceName
        {
            get => string.IsNullOrEmpty(RequiredSingle) ? null : SimpleResourceName.Parse(RequiredSingle);
            set => RequiredSingle = value?.ToString() ?? "";
        }

        /// <summary>
        /// <see cref="SimpleResourceName"/>-typed view over the <see cref="RequiredRepeated"/> resource name property.
        /// </summary>
        public gax::ResourceNameList<SimpleResourceName> RequiredRepeatedAsSimpleResourceNames => new gax::ResourceNameList<SimpleResourceName>(RequiredRepeated, s => SimpleResourceName.Parse(s));
    }
}
