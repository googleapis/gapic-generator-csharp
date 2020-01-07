// Copyright 2019 Google Inc. All Rights Reserved.
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

using Google.Api.Gax;
using Google.Api.Generator.ProtoUtils;
using Google.Api.Generator.RoslynUtils;
using Google.Api.Generator.Utils;
using Google.Protobuf.Reflection;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using static Google.Api.Generator.RoslynUtils.Modifier;
using static Google.Api.Generator.RoslynUtils.RoslynBuilder;

namespace Google.Api.Generator.Generation
{
    /// <summary>
    /// Generate all code in the "ResourceNames.cs" file.
    /// </summary>
    internal class ResourceNamesGenerator
    {
        public static (CompilationUnitSyntax, int) Generate(ProtoCatalog catalog, SourceFileContext ctx, FileDescriptor fileDesc) =>
            new ResourceNamesGenerator(catalog, ctx, fileDesc).Generate();

        private ResourceNamesGenerator(ProtoCatalog catalog, SourceFileContext ctx, FileDescriptor fileDesc) =>
            (_catalog, _ctx, _fileDesc) = (catalog, ctx, fileDesc);

        private readonly ProtoCatalog _catalog;
        private readonly SourceFileContext _ctx;
        private readonly FileDescriptor _fileDesc;

        private (CompilationUnitSyntax, int) Generate()
        {

            var ns = Namespace(_fileDesc.CSharpNamespace());
            using (_ctx.InNamespace(ns))
            {
                var resourceNameClasses = ResourceNameClasses().ToArray();
                var protoMessagePartials = ProtoMessagePartials().ToArray();
                ns = ns.AddMembers(resourceNameClasses);
                ns = ns.AddMembers(protoMessagePartials);
                return (_ctx.CreateCompilationUnit(ns), resourceNameClasses.Length + protoMessagePartials.Length);
            }
        }

        private class PatternDetails
        {
            public class PathElement
            {
                public PathElement(SourceFileContext ctx, ResourceDetails.Definition def, string rawPathElement)
                {
                    var nameWithoutId = rawPathElement.RemoveSuffix("_id");
                    var nameWithId = $"{nameWithoutId}_id";
                    UpperCamel = nameWithoutId.ToUpperCamelCase();
                    LowerCamel = nameWithoutId.ToLowerCamelCase();
                    Parameter = RoslynBuilder.Parameter(ctx.Type<string>(), nameWithId.ToLowerCamelCase());
                    ParameterWithDefault = RoslynBuilder.Parameter(ctx.Type<string>(), nameWithId.ToLowerCamelCase(), @default: Null);
                    ParameterXmlDoc = XmlDoc.Param(Parameter, "The ", XmlDoc.C(nameWithoutId.ToUpperCamelCase()), " ID. Must not be ", null, " or empty.");
                    var summarySuffix = def.Patterns.Count > 1 ?
                        new object[] { "May be ", null, ", depending on which resource name is contained by this instance." } :
                        new object[] { "Will not be ", null, ", unless this instance contains an unparsed resource name." };
                    Property = AutoProperty(Public, ctx.Type<string>(), nameWithId.ToUpperCamelCase())
                        .WithXmlDoc(XmlDoc.Summary(new object[] { "The ", XmlDoc.C(nameWithoutId.ToUpperCamelCase()), " ID. " }.Concat(summarySuffix).ToArray()));
                }

                public string UpperCamel { get; }
                public string LowerCamel { get; }
                public ParameterSyntax Parameter { get; }
                public ParameterSyntax ParameterWithDefault { get; }
                public DocumentationCommentTriviaSyntax ParameterXmlDoc { get; }
                public PropertyDeclarationSyntax Property { get; }
            }

            public PatternDetails(SourceFileContext ctx, ResourceDetails.Definition def, ResourceDetails.Definition.Pattern pattern)
            {
                PatternString = pattern.PatternString;
                PathElements = pattern.Template.ParameterNames.Select(name => new PathElement(ctx, def, name)).ToList();
                UpperName = string.Join("", PathElements.Select(x => x.UpperCamel));
                LowerName = string.Join("", PathElements.Take(1).Select(x => x.LowerCamel).Concat(PathElements.Skip(1).Select(x => x.UpperCamel)));
                PathTemplateField = Field(Private | Static, ctx.Type<PathTemplate>(), $"s_{LowerName}").WithInitializer(New(ctx.Type<PathTemplate>())(pattern.PatternString));
            }

            public string PatternString { get; }
            public string UpperName { get; }
            public string LowerName { get; }
            public IReadOnlyList<PathElement> PathElements { get; }
            public FieldDeclarationSyntax PathTemplateField { get; }
        }

        private class ResourceClassBuilder
        {
            private class PathElementByNameComparer : IEqualityComparer<PatternDetails.PathElement>
            {
                public static PathElementByNameComparer Instance { get; } = new PathElementByNameComparer();
                public bool Equals(PatternDetails.PathElement x, PatternDetails.PathElement y) => x.LowerCamel == y.LowerCamel;
                public int GetHashCode(PatternDetails.PathElement obj) => obj.LowerCamel.GetHashCode();
            }

            public ResourceClassBuilder(SourceFileContext ctx, ResourceDetails.Definition def)
            {
                _ctx = ctx;
                _def = def;
                ResourceNameTypeTyp = Typ.Nested(def.ResourceNameTyp, "ResourceNameType", isEnum: true);
                PatternDetails = _def.Patterns.Select(x => new PatternDetails(ctx, def, x)).ToList();
            }

            private readonly SourceFileContext _ctx;
            private readonly ResourceDetails.Definition _def;

            public ClassDeclarationSyntax Generate()
            {
                var cls = Class(Public | Sealed | Partial, _def.ResourceNameTyp, _ctx.Type<IResourceName>(), _ctx.Type(Typ.Generic(typeof(IEquatable<>), _def.ResourceNameTyp)))
                    .WithXmlDoc(XmlDoc.Summary("Resource name for the ", XmlDoc.C(_def.DocName), " resource."));
                using (_ctx.InClass(cls))
                {
                    cls = cls.AddMembers(ResourceTypeEnum());
                    cls = cls.AddMembers(TemplateFields().ToArray());
                    cls = cls.AddMembers(FromUnparsedMethod());
                    cls = cls.AddMembers(FromMethods().ToArray());
                    cls = cls.AddMembers(FormatMethods().ToArray());
                    cls = cls.AddMembers(ParseMethods().ToArray());
                    cls = cls.AddMembers(Constructors(cls).ToArray());
                    cls = cls.AddMembers(ResourceType());
                    cls = cls.AddMembers(UnparsedResourceNameProperty());
                    cls = cls.AddMembers(Properties().ToArray());
                    cls = cls.AddMembers(IsKnownPattern());
                    cls = cls.AddMembers(ToString());
                    cls = cls.AddMembers(GetHashCode());
                    cls = cls.AddMembers(Equals());
                    cls = cls.AddMembers(EqualsIEquatable());
                    cls = cls.AddMembers(EqualityOperator());
                    cls = cls.AddMembers(InequalityOperator());
                }
                return cls;
            }

            private Typ ResourceNameTypeTyp { get; }

            private IReadOnlyList<PatternDetails> PatternDetails { get; }

            private EnumDeclarationSyntax ResourceTypeEnum()
            {
                var resources = PatternDetails.Select((x, i) => EnumMember(x.UpperName, value: i + 1).WithXmlDoc(
                    XmlDoc.Summary("A resource name with pattern ", XmlDoc.C(x.PatternString), ".")))
                    .Prepend(EnumMember("Unparsed", value: 0).WithXmlDoc(XmlDoc.Summary("An unparsed resource name.")));
                return Enum(Public, ResourceNameTypeTyp)(resources.ToArray())
                    .WithXmlDoc(XmlDoc.Summary("The possible contents of ", _ctx.Type(_def.ResourceNameTyp), "."));
            }

            private IEnumerable<FieldDeclarationSyntax> TemplateFields() => PatternDetails.Select(x => x.PathTemplateField);

            private MethodDeclarationSyntax FromUnparsedMethod()
            {
                var unparsedResourceName = Parameter(_ctx.Type<UnparsedResourceName>(), "unparsedResourceName");
                return Method(Public | Static, _ctx.Type(_def.ResourceNameTyp), "FromUnparsed")(unparsedResourceName)
                    .WithBody(Return(New(_ctx.Type(_def.ResourceNameTyp))(
                        _ctx.Type(ResourceNameTypeTyp).Access("Unparsed"),
                        _ctx.Type(typeof(GaxPreconditions)).Call(nameof(GaxPreconditions.CheckNotNull))(unparsedResourceName, Nameof(unparsedResourceName)))))
                    .WithXmlDoc(
                        XmlDoc.Summary("Creates a ", _ctx.Type(_def.ResourceNameTyp), " containing an unparsed resource name."),
                        XmlDoc.Param(unparsedResourceName, "The unparsed resource name. Must not be ", null, "."),
                        XmlDoc.Returns("A new instance of ", _ctx.Type(_def.ResourceNameTyp), " containing the provided ", unparsedResourceName, "."));
            }

            private IEnumerable<MethodDeclarationSyntax> FromMethods()
            {
                foreach (var pattern in PatternDetails)
                {
                    var xmlDocSummary = XmlDoc.Summary($"Creates a ", _ctx.Type(_def.ResourceNameTyp), " with the pattern ", XmlDoc.C(pattern.PatternString), ".");
                    var xmlDocReturns = XmlDoc.Returns("A new instance of ", _ctx.Type(_def.ResourceNameTyp), " constructed from the provided ids.");
                    yield return Method(Public | Static, _ctx.Type(_def.ResourceNameTyp), $"From{pattern.UpperName}")(pattern.PathElements.Select(x => x.Parameter).ToArray())
                        .WithBody(Return(New(_ctx.Type(_def.ResourceNameTyp))(
                            pattern.PathElements.Select(x => (object)(x.Parameter.Identifier.ValueText, _ctx.Type(typeof(GaxPreconditions))
                                .Call(nameof(GaxPreconditions.CheckNotNullOrEmpty))(x.Parameter, Nameof(x.Parameter))))
                                .Prepend(_ctx.Type(ResourceNameTypeTyp).Access(pattern.UpperName)).ToArray())))
                        .WithXmlDoc(pattern.PathElements.Select(x => x.ParameterXmlDoc).Prepend(xmlDocSummary).Append(xmlDocReturns).ToArray());
                }
            }

            private IEnumerable<MethodDeclarationSyntax> FormatMethods()
            {
                bool first = true;
                foreach (var pattern in PatternDetails)
                {
                    var xmlDoc = pattern.PathElements.Select(x => x.ParameterXmlDoc)
                        .Prepend(XmlDoc.Summary("Formats the IDs into the string representation of this ", _ctx.Type(_def.ResourceNameTyp),
                            " with pattern ", XmlDoc.C(pattern.PatternString), "."))
                        .Append(XmlDoc.Returns("The string representation of this ", _ctx.Type(_def.ResourceNameTyp), " with pattern ", XmlDoc.C(pattern.PatternString), "."))
                        .ToArray();
                    var method = Method(Public | Static, _ctx.Type<string>(), $"Format{pattern.UpperName}")(pattern.PathElements.Select(x => x.Parameter).ToArray())
                        .WithBody(Return(pattern.PathTemplateField.Call(nameof(PathTemplate.Expand))(pattern.PathElements.Select(x =>
                            _ctx.Type(typeof(GaxPreconditions)).Call(nameof(GaxPreconditions.CheckNotNullOrEmpty))(x.Parameter, Nameof(x.Parameter))))))
                        .WithXmlDoc(xmlDoc);
                    if (first)
                    {
                        yield return Method(Public | Static, _ctx.Type<string>(), "Format")(pattern.PathElements.Select(x => x.Parameter).ToArray())
                            .WithBody(Return(This.Call(method)(pattern.PathElements.Select(x => x.Parameter))))
                            .WithXmlDoc(xmlDoc);
                        first = false;
                    }
                    yield return method;
                }
            }

            private IEnumerable<MethodDeclarationSyntax> ParseMethods()
            {
                var paramName = _def.ResourceNameTyp.Name.ToLowerCamelCase();
                var name = Parameter(_ctx.Type<string>(), paramName);
                var allowUnparsed = Parameter(_ctx.Type<bool>(), "allowUnparsed");
                var result = Parameter(_ctx.Type(_def.ResourceNameTyp), "result").Out();
                var resultLocal = Local(_ctx.Type(_def.ResourceNameTyp), "result");
                var resourceName = Local(_ctx.Type<TemplatedResourceName>(), paramName == "resourceName" ? "resourceName2" : "resourceName");
                var unparsedResourceName = Local(_ctx.Type<UnparsedResourceName>(), "unparsedResourceName");
                var tryParse2 = Method(Public | Static, _ctx.Type<bool>(), "TryParse")(name, allowUnparsed, result)
                    .WithBody(
                        _ctx.Type(typeof(GaxPreconditions)).Call(nameof(GaxPreconditions.CheckNotNull))(name, Nameof(name)),
                        resourceName,
                        PatternDetails.Zip(FromMethods(), (pattern, create) =>
                        {
                            var elements = Enumerable.Range(0, pattern.PathElements.Count).Select(i => resourceName.ElementAccess(i));
                            return If(pattern.PathTemplateField.Call(nameof(PathTemplate.TryParseName))(name, Out(resourceName))).Then(
                                result.Assign(This.Call(create)(elements.ToArray())),
                                Return(true));
                        }),
                        If(allowUnparsed).Then(
                            If(_ctx.Type<UnparsedResourceName>().Call(nameof(UnparsedResourceName.TryParse))(name, OutVar(unparsedResourceName))).Then(
                                result.Assign(This.Call(FromUnparsedMethod())(unparsedResourceName)),
                                Return(true))),
                        result.Assign(Null),
                        Return(false)
                    )
                    .WithXmlDoc(
                        XmlDoc.Summary("Tries to parse the given resource name string into a new ", _ctx.Type(_def.ResourceNameTyp),
                            " instance; optionally allowing an unparseable resource name."),
                        XmlDocRemarks(includeUnparsed: true),
                        XmlDoc.Param(name, "The resource name in string form. Must not be ", null, "."),
                        XmlDoc.Param(allowUnparsed, "If ", true, " will successfully store an unparseable resource name into the ", UnparsedResourceNameProperty(), " property; ",
                            "otherwise will throw an ", _ctx.Type<ArgumentException>(), " if an unparseable resource name is specified."),
                        XmlDoc.Param(result, "When this method returns, the parsed ", _ctx.Type(_def.ResourceNameTyp), ", or ", null, " if parsing failed."),
                        XmlDoc.Returns(true, " if the name was parsed successfully; ", false, " otherwise."));
                var parse2 = Method(Public | Static, _ctx.Type(_def.ResourceNameTyp), "Parse")(name, allowUnparsed)
                    .WithBody(Return(
                        This.Call(tryParse2)(name, allowUnparsed, OutVar(resultLocal))
                            .ConditionalOperator(resultLocal, Throw(New(_ctx.Type<ArgumentException>())("The given resource-name matches no pattern.")))))
                    .WithXmlDoc(
                        XmlDoc.Summary("Parses the given resource name string into a new ", _ctx.Type(_def.ResourceNameTyp),
                            " instance; optionally allowing an unparseable resource name."),
                        XmlDocRemarks(includeUnparsed: true),
                        XmlDoc.Param(name, "The resource name in string form. Must not be ", null, "."),
                        XmlDoc.Param(allowUnparsed, "If ", true, " will successfully store an unparseable resource name into the ", UnparsedResourceNameProperty(), " property; ",
                            "otherwise will throw an ", _ctx.Type<ArgumentException>(), " if an unparseable resource name is specified."),
                        XmlDoc.Returns("The parsed ", _ctx.Type(_def.ResourceNameTyp), " if successful."));
                yield return Method(Public | Static, _ctx.Type(_def.ResourceNameTyp), "Parse")(name)
                    .WithBody(This.Call(parse2)(name, false))
                    .WithXmlDoc(
                        XmlDoc.Summary("Parses the given resource name string into a new ", _ctx.Type(_def.ResourceNameTyp), " instance."),
                        XmlDocRemarks(includeUnparsed: false),
                        XmlDoc.Param(name, "The resource name in string form. Must not be ", null, "."),
                        XmlDoc.Returns("The parsed ", _ctx.Type(_def.ResourceNameTyp), " if successful."));
                yield return parse2;
                yield return Method(Public | Static, _ctx.Type<bool>(), "TryParse")(name, result)
                    .WithBody(This.Call(tryParse2)(name, false, Out(result)))
                    .WithXmlDoc(
                        XmlDoc.Summary("Tries to parse the given resource name string into a new ", _ctx.Type(_def.ResourceNameTyp), " instance."),
                        XmlDocRemarks(includeUnparsed: false),
                        XmlDoc.Param(name, "The resource name in string form. Must not be ", null, "."),
                        XmlDoc.Param(result, "When this method returns, the parsed ", _ctx.Type(_def.ResourceNameTyp), ", or ", null, " if parsing failed."),
                        XmlDoc.Returns(true, " if the name was parsed successfully; ", false, " otherwise."));
                yield return tryParse2;

                DocumentationCommentTriviaSyntax XmlDocRemarks(bool includeUnparsed)
                {
                    IEnumerable<object> patterns = new object[]
                    {
                        "To parse successfully, the resource name must be formatted as one of the following:",
                        XmlDoc.UL(PatternDetails.Select(pattern => XmlDoc.C(pattern.PatternString)))
                    };
                    if (includeUnparsed)
                    {
                        patterns = patterns.Concat(new object[] { "Or may be in any format if ", allowUnparsed, " is ", true, "." });
                    }
                    return XmlDoc.Remarks(patterns.ToArray());
                }
            }

            private IEnumerable<ConstructorDeclarationSyntax> Constructors(ClassDeclarationSyntax cls)
            {
                // Ctor for any pattern
                var type = Parameter(_ctx.Type(ResourceNameTypeTyp), "type");
                var unparsedResourceName = Parameter(_ctx.Type<UnparsedResourceName>(), "unparsedResourceName", @default: Null);
                var parameters = PatternDetails.SelectMany(pattern => pattern.PathElements).ToImmutableHashSet(PathElementByNameComparer.Instance).OrderBy(x => x.LowerCamel);
                var ctor = Ctor(Private, cls)(parameters.Select(x => x.ParameterWithDefault).Prepend(unparsedResourceName).Prepend(type).ToArray())
                    .WithBody(
                        ResourceType().Assign(type),
                        UnparsedResourceNameProperty().Assign(unparsedResourceName),
                        parameters.Select(x => x.Property.Assign(x.Parameter)));
                yield return ctor;
                // Ctor for pattern[0]
                var initParams = PatternDetails[0].PathElements.Select(x => (object)(x.Parameter.Identifier.ValueText,
                    _ctx.Type(typeof(GaxPreconditions)).Call(nameof(GaxPreconditions.CheckNotNullOrEmpty))(x.Parameter, Nameof(x.Parameter))))
                    .Prepend(_ctx.Type(ResourceNameTypeTyp).Access(ResourceTypeEnum().Members[1]));
                var xmlDocSummary = XmlDoc.Summary("Constructs a new instance of a ", _ctx.Type(_def.ResourceNameTyp),
                    " class from the component parts of pattern ", XmlDoc.C(PatternDetails[0].PatternString));
                yield return Ctor(Public, cls, initializer: ThisInitializer(initParams.ToArray()))
                    (PatternDetails[0].PathElements.Select(x => x.Parameter).ToArray())
                    .WithBody() // Deliberately empty body.
                    .WithXmlDoc(PatternDetails[0].PathElements.Select(pattern => pattern.ParameterXmlDoc).Prepend(xmlDocSummary).ToArray());
            }

            private PropertyDeclarationSyntax ResourceType() =>
                AutoProperty(Public, _ctx.Type(ResourceNameTypeTyp), "Type")
                    .WithXmlDoc(XmlDoc.Summary("The ", _ctx.Type(ResourceNameTypeTyp), " of the contained resource name."));

            private PropertyDeclarationSyntax UnparsedResourceNameProperty() =>
                AutoProperty(Public, _ctx.Type<UnparsedResourceName>(), "UnparsedResource")
                    .WithXmlDoc(XmlDoc.Summary("The contained ", _ctx.Type<UnparsedResourceName>(), ". Only non-", null, " if this instance contains an unparsed resource name."));

            private IEnumerable<PropertyDeclarationSyntax> Properties() =>
                PatternDetails.SelectMany(pattern => pattern.PathElements).ToImmutableHashSet(PathElementByNameComparer.Instance)
                    .OrderBy(x => x.LowerCamel) // To make deterministic.
                    .Select(x => x.Property);

            private PropertyDeclarationSyntax IsKnownPattern() => Property(Public, _ctx.Type<bool>(), nameof(IResourceName.IsKnownPattern))
                .WithGetBody(ResourceType().NotEqualTo(_ctx.Type(ResourceNameTypeTyp).Access("Unparsed")))
                .WithXmlDoc(XmlDoc.InheritDoc);

            private new MethodDeclarationSyntax ToString()
            {
                var switchCases = PatternDetails.Select(pattern =>
                    ((object)_ctx.Type(ResourceNameTypeTyp).Access(pattern.UpperName),
                        (object)Return(pattern.PathTemplateField.Call(nameof(PathTemplate.Expand))(pattern.PathElements.Select(x => x.Property).ToArray()))))
                    .Prepend((_ctx.Type(ResourceNameTypeTyp).Access("Unparsed"), Return(UnparsedResourceNameProperty().Call(nameof(object.ToString))())));
                return Method(Public | Override, _ctx.Type<string>(), nameof(object.ToString))()
                    .WithBody(
                        Switch(ResourceType())(switchCases.ToArray()).WithDefault(
                            Throw(New(_ctx.Type<InvalidOperationException>())("Unrecognized resource-type."))))
                    .WithXmlDoc(XmlDoc.InheritDoc);
            }

            private new MethodDeclarationSyntax GetHashCode()
            {
                return Method(Public | Override, _ctx.Type<int>(), nameof(object.GetHashCode))()
                    .WithBody(Return(This.Call(ToString())().Call(nameof(object.GetHashCode))()))
                    .WithXmlDoc(XmlDoc.InheritDoc);
            }

            private MethodDeclarationSyntax Equals()
            {
                var obj = Parameter(_ctx.Type<object>(), "obj");
                return Method(Public | Override, _ctx.Type<bool>(), nameof(object.Equals))(obj)
                    .WithBody(Return(This.Call(EqualsIEquatable())(obj.As(_ctx.Type(_def.ResourceNameTyp)))))
                    .WithXmlDoc(XmlDoc.InheritDoc);
            }

            private MethodDeclarationSyntax EqualsIEquatable()
            {
                var other = Parameter(_ctx.Type(_def.ResourceNameTyp), "other");
                return Method(Public, _ctx.Type<bool>(), nameof(IEquatable<int>.Equals))(other)
                    .WithBody(Return(This.Call(ToString())().Equality(other.Call(ToString(), conditional: true)())))
                    .WithXmlDoc(XmlDoc.InheritDoc);
            }

            private OperatorDeclarationSyntax EqualityOperator()
            {
                var a = Parameter(_ctx.Type(_def.ResourceNameTyp), "a");
                var b = Parameter(_ctx.Type(_def.ResourceNameTyp), "b");
                return OperatorMethod(_ctx.Type<bool>(), "==")(a, b)
                    .WithBody(This.Call(nameof(object.ReferenceEquals))(a, b).Or(Parens(a.Call(EqualsIEquatable(), conditional: true)(b).NullCoalesce(false))))
                    .WithXmlDoc(XmlDoc.InheritDoc);
            }

            private OperatorDeclarationSyntax InequalityOperator()
            {
                var a = Parameter(_ctx.Type(_def.ResourceNameTyp), "a");
                var b = Parameter(_ctx.Type(_def.ResourceNameTyp), "b");
                return OperatorMethod(_ctx.Type<bool>(), "!=")(a, b)
                    .WithBody(Not(Parens(a.Equality(b))))
                    .WithXmlDoc(XmlDoc.InheritDoc);
            }
        }

        private IEnumerable<ClassDeclarationSyntax> ResourceNameClasses()
        {
            foreach (var def in _catalog.GetResourceDefsByFile(_fileDesc))
            {
                if (!def.IsWildcard && !def.IsCommon)
                {
                    yield return new ResourceClassBuilder(_ctx, def).Generate();
                }
            }
        }

        private IEnumerable<ClassDeclarationSyntax> ProtoMessagePartials()
        {
            // Note: Whether a field is required or optional is purposefully ignored in this partial class.
            // The optionalness of a field is only relevant within a method signature (flattening).
            foreach (var msg in _fileDesc.MessageTypes)
            {
                var resources = msg.Fields.InFieldNumberOrder()
                    .Select(field => (field, resDetails: _catalog.GetResourceDetailsByField(field)))
                    .Where(x => x.resDetails != null)
                    .ToList();
                if (resources.Any())
                {
                    var cls = Class(Public | Partial, Typ.Of(msg));
                    using (_ctx.InClass(cls))
                    {
                        _ctx.RegisterClassMemberNames(resources
                            .Select(res => res.resDetails.ResourcePropertyName)
                            .Concat(msg.Fields.InDeclarationOrder().Select(f => f.CSharpPropertyName()))
                            .Append(msg.NestedTypes.Any() ? "Types" : null)
                            .Where(x => x != null));
                        var properties = resources.Select(res =>
                        {
                            var underlyingProperty = Property(DontCare, _ctx.TypeDontCare, res.resDetails.UnderlyingPropertyName);
                            var def = res.resDetails.ResourceDefinition;
                            var xmlDocSummary = XmlDoc.Summary(_ctx.Type(def.ResourceNameTyp), "-typed view over the ", underlyingProperty, " resource name property.");
                            if (res.field.IsRepeated)
                            {
                                var repeatedTyp = Typ.Generic(typeof(ResourceNameList<>), def.ResourceNameTyp);
                                var s = Parameter(null, "s");
                                return Property(Public, _ctx.Type(repeatedTyp), res.resDetails.ResourcePropertyName)
                                    .WithGetBody(Return(def.IsWildcard ?
                                        New(_ctx.Type(repeatedTyp))(underlyingProperty, Lambda(s)(_ctx.Type<UnparsedResourceName>().Call(nameof(UnparsedResourceName.Parse))(s))) :
                                        New(_ctx.Type(repeatedTyp))(underlyingProperty, Lambda(s)(_ctx.Type(def.ResourceNameTyp).Call("Parse")(s)))))
                                    .WithXmlDoc(xmlDocSummary);
                            }
                            else
                            {
                                return Property(Public, _ctx.Type(def.ResourceNameTyp), res.resDetails.ResourcePropertyName)
                                    .WithGetBody(Return(def.IsWildcard ?
                                        _ctx.Type<string>().Call(nameof(string.IsNullOrEmpty))(underlyingProperty).ConditionalOperator(
                                            Null, _ctx.Type<UnparsedResourceName>().Call(nameof(UnparsedResourceName.Parse))(underlyingProperty)) :
                                        _ctx.Type<string>().Call(nameof(string.IsNullOrEmpty))(underlyingProperty).ConditionalOperator(
                                            Null, _ctx.Type(def.ResourceNameTyp).Call("Parse")(underlyingProperty))))
                                    .WithSetBody(underlyingProperty.Assign(Value.Call(nameof(object.ToString), conditional: true)().NullCoalesce("")))
                                    .WithXmlDoc(xmlDocSummary);
                            }

                        });
                        cls = cls.AddMembers(properties.ToArray());
                    }
                    yield return cls;
                }
            }
        }
    }
}
