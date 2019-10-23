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
        public static CompilationUnitSyntax Generate(ProtoCatalog catalog, SourceFileContext ctx, FileDescriptor fileDesc) =>
            new ResourceNamesGenerator(catalog, ctx, fileDesc).Generate();

        private ResourceNamesGenerator(ProtoCatalog catalog, SourceFileContext ctx, FileDescriptor fileDesc) =>
            (_catalog, _ctx, _fileDesc) = (catalog, ctx, fileDesc);

        private ProtoCatalog _catalog;
        private SourceFileContext _ctx;
        private FileDescriptor _fileDesc;

        private CompilationUnitSyntax Generate()
        {

            var ns = Namespace(_fileDesc.CSharpNamespace());
            using (_ctx.InNamespace(ns))
            {
                ns = ns.AddMembers(ResourceNameClasses().ToArray());
                ns = ns.AddMembers(ProtoMessagePartials().ToArray());
            }
            return _ctx.CreateCompilationUnit(ns);
        }

        private class ParamProperty
        {
            public ParamProperty(SourceFileContext ctx, string name)
            {
                var (nameWithId, nameWithoutId) = name.ToLowerInvariant().EndsWith("_id") ? (name, name.Substring(0, name.Length - "_id".Length)) : (name + "_id", name);
                Parameter = RoslynBuilder.Parameter(ctx.Type<string>(), nameWithId.ToLowerCamelCase());
                ParameterXmlDoc = XmlDoc.Param(Parameter, "The ", XmlDoc.C(nameWithoutId.ToUpperCamelCase()), " ID. Must not be ", null, ".");
                Property = AutoProperty(Public, ctx.Type<string>(), nameWithId.ToUpperCamelCase());
                PropertyXmlDoc = XmlDoc.Summary("The ", XmlDoc.C(nameWithoutId.ToUpperCamelCase()), " ID. Never ", null, ".");
            }

            public ParameterSyntax Parameter { get; }
            public DocumentationCommentTriviaSyntax ParameterXmlDoc { get; }
            public PropertyDeclarationSyntax Property { get; }
            public DocumentationCommentTriviaSyntax PropertyXmlDoc { get; }
        }

        private class ResourceClassBuilder
        {
            public ResourceClassBuilder(SourceFileContext ctx, string fieldName, ResourceDetails.Definition.SingleDef def, string docName) =>
                (_ctx, _fieldName, _def, _docName) = (ctx, $"{fieldName}Name", def, docName);

            private SourceFileContext _ctx;
            private string _fieldName;
            private ResourceDetails.Definition.SingleDef _def;
            private string _docName;

            public ClassDeclarationSyntax Generate()
            {
                var cls = Class(Public | Sealed | Partial, _def.ResourceNameTyp, _ctx.Type<IResourceName>(), _ctx.Type(Typ.Generic(typeof(IEquatable<>), _def.ResourceNameTyp)))
                    .WithXmlDoc(XmlDoc.Summary("Resource name for the ", XmlDoc.C(_docName), " resource."));
                using (_ctx.InClass(cls))
                {
                    var paramProperties = _def.Template.ParameterNames.Select(name => new ParamProperty(_ctx, name)).ToList();
                    var templateField = TemplateField();
                    cls = cls.AddMembers(
                        templateField,
                        Parse(templateField),
                        TryParse(templateField),
                        Format(templateField, paramProperties),
                        Constructor(cls, paramProperties));
                    cls = cls.AddMembers(PartProperties(paramProperties).ToArray());
                    var toString = ToString(templateField, paramProperties);
                    var equalsIEquatable = EqualsIEquatable();
                    cls = cls.AddMembers(
                        Kind(),
                        toString,
                        GetHashCode(toString),
                        Equals(equalsIEquatable), equalsIEquatable,
                        EqualityOperator(equalsIEquatable), InequalityOperator());
                }
                return cls;
            }

            private FieldDeclarationSyntax TemplateField() =>
                Field(Private | Static | Readonly, _ctx.Type<PathTemplate>(), "s_template").WithInitializer(New(_ctx.Type<PathTemplate>())(_def.Pattern));

            private MethodDeclarationSyntax Parse(FieldDeclarationSyntax templateField)
            {
                var name = Parameter(_ctx.Type<string>(), _fieldName);
                var resourceName = Local(_ctx.Type<TemplatedResourceName>(), _fieldName != "resourceName" ? "resourceName" : "resourceName2");
                return Method(Public | Static, _ctx.Type(_def.ResourceNameTyp), "Parse")(name)
                    .WithBody(
                        _ctx.Type(typeof(GaxPreconditions)).Call(nameof(GaxPreconditions.CheckNotNull))(name, Nameof(name)),
                        resourceName.WithInitializer(templateField.Call("ParseName")(name)),
                        Return(New(_ctx.Type(_def.ResourceNameTyp))(_def.Template.ParameterNames.Select((_, i) => resourceName.ElementAccess(i)))))
                    .WithXmlDoc(
                        XmlDoc.Summary("Parses the given ", XmlDoc.C(_docName), " resource name in string form into a new ", _ctx.Type(_def.ResourceNameTyp), " instance."),
                        XmlDoc.Param(name, "The ", XmlDoc.C(_docName), " resource name in string form. Must not be ", null, "."),
                        XmlDoc.Returns("The parsed ", _ctx.Type(_def.ResourceNameTyp), " if successful.")
                    );
            }

            private MethodDeclarationSyntax TryParse(FieldDeclarationSyntax templateField)
            {
                var name = Parameter(_ctx.Type<string>(), _fieldName);
                var result = Parameter(_ctx.Type(_def.ResourceNameTyp), "result").Out();
                var resourceName = ParameterOutVar(_ctx.Type<TemplatedResourceName>(), _fieldName != "resourceName" ? "resourceName" : "resourceName2");
                return Method(Public | Static, _ctx.Type<bool>(), "TryParse")(name, result)
                    .WithBody(
                        _ctx.Type(typeof(GaxPreconditions)).Call(nameof(GaxPreconditions.CheckNotNull))(name, Nameof(name)),
                        If(templateField.Call(nameof(PathTemplate.TryParseName))(name, resourceName))
                            .Then(
                                result.Assign(New(_ctx.Type(_def.ResourceNameTyp))(_def.Template.ParameterNames.Select((_, i) => resourceName.ElementAccess(i)))),
                                Return(true))
                            .Else(
                                result.Assign(Null),
                                Return(false)))
                    .WithXmlDoc(
                        XmlDoc.Summary("Tries to parse the given session resource name in string form into a new ", _ctx.Type(_def.ResourceNameTyp), " instance."),
                        XmlDoc.Remarks("This method still throws ", _ctx.Type<ArgumentNullException>(), " if ", name, " is ", null,
                            ", as this would usually indicate a programming error rather than a data error."),
                        XmlDoc.Param(name, "The ", XmlDoc.C(_docName), " resource name in string form. Must not be ", null, "."),
                        XmlDoc.Param(result, "When this method returns, the parsed ", _ctx.Type(_def.ResourceNameTyp), ", or ", null, " if parsing fails."),
                        XmlDoc.Returns(true, " if the name was parsed successfully; ", false, " otherwise."));
            }

            private MethodDeclarationSyntax Format(FieldDeclarationSyntax templateField, IEnumerable<ParamProperty> paramProperties)
            {
                return Method(Public | Static, _ctx.Type<string>(), "Format")(paramProperties.Select(x => x.Parameter).ToArray())
                    .WithBody(templateField.Call(nameof(PathTemplate.Expand))(paramProperties.Select(x =>
                        _ctx.Type(typeof(GaxPreconditions)).Call(nameof(GaxPreconditions.CheckNotNull))(x.Parameter, Nameof(x.Parameter)))))
                    .WithXmlDoc(
                        paramProperties.Select(x => x.ParameterXmlDoc)
                        .Prepend(XmlDoc.Summary("Formats the IDs into the string representation of the ", _ctx.Type(_def.ResourceNameTyp), "."))
                        .Append(XmlDoc.Returns("The string representation of the ", _ctx.Type(_def.ResourceNameTyp), "."))
                        .ToArray());
            }

            private ConstructorDeclarationSyntax Constructor(ClassDeclarationSyntax cls, IEnumerable<ParamProperty> paramProperties) =>
                Ctor(Public, cls)(paramProperties.Select(x => x.Parameter).ToArray())
                    .WithBody(paramProperties.Select(x =>
                        x.Property.Assign(_ctx.Type(typeof(GaxPreconditions)).Call(nameof(GaxPreconditions.CheckNotNull))(x.Parameter, Nameof(x.Parameter)))))
                    .WithXmlDoc(paramProperties.Select(x => x.ParameterXmlDoc)
                        .Prepend(XmlDoc.Summary("Constructs a new instance of the ", _ctx.Type(_def.ResourceNameTyp), " resource name class from its component parts.")).ToArray());

            private IEnumerable<PropertyDeclarationSyntax> PartProperties(IEnumerable<ParamProperty> paramProperties) =>
                paramProperties.Select(x => x.Property.WithXmlDoc(x.PropertyXmlDoc));

            private PropertyDeclarationSyntax Kind() => Property(Public, _ctx.Type<ResourceNameKind>(), nameof(IResourceName.Kind))
                .WithGetBody(_ctx.Type<ResourceNameKind>().Access(ResourceNameKind.Simple))
                .WithXmlDoc(XmlDoc.InheritDoc);

            private MethodDeclarationSyntax ToString(FieldDeclarationSyntax templateField, IEnumerable<ParamProperty> paramProperties) =>
                Method(Public | Override, _ctx.Type<string>(), nameof(object.ToString))()
                    .WithBody(templateField.Call(nameof(PathTemplate.Expand))(paramProperties.Select(x => x.Property).ToArray()))
                    .WithXmlDoc(XmlDoc.InheritDoc);

            private MethodDeclarationSyntax GetHashCode(MethodDeclarationSyntax toString) =>
                Method(Public | Override, _ctx.Type<int>(), nameof(object.GetHashCode))()
                    .WithBody(This.Call(toString)().Call(nameof(string.GetHashCode))())
                    .WithXmlDoc(XmlDoc.InheritDoc);

            private MethodDeclarationSyntax Equals(MethodDeclarationSyntax equalsIEquatable)
            {
                var obj = Parameter(_ctx.Type<object>(), "obj");
                return Method(Public | Override, _ctx.Type<bool>(), nameof(object.Equals))(obj)
                    .WithBody(This.Call(equalsIEquatable)(obj.As(_ctx.Type(_def.ResourceNameTyp))))
                    .WithXmlDoc(XmlDoc.InheritDoc);
            }

            private MethodDeclarationSyntax EqualsIEquatable()
            {
                var other = Parameter(_ctx.Type(_def.ResourceNameTyp), "other");
                return Method(Public, _ctx.Type<bool>(), nameof(IEquatable<int>.Equals))(other)
                    .WithBody(This.Call(nameof(object.ToString))().Equality(other.Call(nameof(object.ToString), conditional: true)()))
                    .WithXmlDoc(XmlDoc.InheritDoc);
            }

            private OperatorDeclarationSyntax EqualityOperator(MethodDeclarationSyntax equalsIEquatable)
            {
                var a = Parameter(_ctx.Type(_def.ResourceNameTyp), "a");
                var b = Parameter(_ctx.Type(_def.ResourceNameTyp), "b");
                return OperatorMethod(_ctx.Type<bool>(), "==")(a, b)
                    .WithBody(This.Call(nameof(object.ReferenceEquals))(a, b).Or(Parens(a.Call(equalsIEquatable, conditional: true)(b).NullCoalesce(false))))
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

        private class OneOfClassBuilder
        {
            public OneOfClassBuilder(SourceFileContext ctx, ResourceDetails.Definition.MultiDef def, string docName) =>
                (_ctx, _def, _docName) = (ctx, def, docName);

            private SourceFileContext _ctx;
            private ResourceDetails.Definition.MultiDef _def;
            private string _docName;

            private Typ OneOfTypeEnumTyp => Typ.Nested(_def.ContainerTyp, "OneofType", isEnum: true);
            
            public ClassDeclarationSyntax Generate()
            {
                var xmlDocUl = XmlDoc.UL(_def.Defs.Select(x =>
                    $"{x.ResourceNameTyp.Name}: A resource of type '{x.Template.ParameterNames.TakeLast(2).First().RemoveSuffix("_id")}'."));
                var cls = Class(Public | Sealed | Partial, _def.ContainerTyp, _ctx.Type<IResourceName>(), _ctx.Type(Typ.Generic(typeof(IEquatable<>), _def.ContainerTyp)))
                    .WithXmlDoc(
                        XmlDoc.Summary("Resource name which will contain one of a choice of resource names."),
                        XmlDoc.Remarks("This resource name will contain one of the following:", xmlDocUl));
                using (_ctx.InClass(cls))
                {
                    var tryParse = TryParse(xmlDocUl);
                    cls = cls.AddMembers(
                        OneOfTypeEnum(),
                        Parse(xmlDocUl, tryParse),
                        tryParse);
                    cls = cls.AddMembers(Froms().ToArray());
                    var isValid = IsValid();
                    var typeProp = TypeProperty();
                    var nameProp = NameProperty();
                    var checkAndReturn = CheckAndReturn(typeProp, nameProp);
                    cls = cls.AddMembers(
                        isValid,
                        Ctor0(cls, typeProp, nameProp, isValid),
                        typeProp,
                        nameProp,
                        checkAndReturn);
                    cls = cls.AddMembers(Getters(checkAndReturn).ToArray());
                    var toString = ToString(nameProp);
                    var equalsIEquatable = EqualsIEquatable();
                    cls = cls.AddMembers(
                        Kind(),
                        toString,
                        GetHashCode(toString),
                        Equals(equalsIEquatable), equalsIEquatable,
                        EqualityOperator(equalsIEquatable), InequalityOperator());
                }
                return cls;
            }

            private EnumDeclarationSyntax OneOfTypeEnum()
            {
                var resources = _def.Defs.Select((x, i) => EnumMember(x.ResourceNameTyp.Name, value: i + 1).WithXmlDoc(
                    XmlDoc.Summary($"A resource of type '{x.Template.ParameterNames.TakeLast(2).First().RemoveSuffix("_id")}'")))
                    .Prepend(EnumMember("Unknown", value: 0).WithXmlDoc(XmlDoc.Summary("A resource of an unknown type.")));
                return Enum(Public, OneOfTypeEnumTyp)(resources.ToArray())
                    .WithXmlDoc(XmlDoc.Summary("The possible contents of ", _ctx.Type(_def.ContainerTyp), "."));
            }

            private MethodDeclarationSyntax Parse(XmlNodeSyntax xmlDocUl, MethodDeclarationSyntax tryParse)
            {
                var name = Parameter(_ctx.Type<string>(), "name");
                var allowUnknown = Parameter(_ctx.Type<bool>(), "allowUnknown");
                var result = Local(_ctx.Type(_def.ContainerTyp), "result");
                return Method(Public | Static, _ctx.Type(_def.ContainerTyp), "Parse")(name, allowUnknown)
                    .WithBody(
                        If(This.Call(tryParse)(name, allowUnknown, ParameterOutVar(result))).Then(Return(result)),
                        Throw(New(_ctx.Type<ArgumentException>())("Invalid name", Nameof(name))))
                    .WithXmlDoc(
                        XmlDoc.Summary("Parses the given ", XmlDoc.C(_docName), " resource name in string form into a new ", _ctx.Type(_def.ContainerTyp), " instance."),
                        XmlDoc.Remarks("To parse successfully the resource name must be one of the following:", xmlDocUl, "Or an ", _ctx.Type<UnknownResourceName>(), " if ", allowUnknown, " is ", true),
                        XmlDoc.Param(name, "The resource name in string form. Must not be ", null, "."),
                        XmlDoc.Param(allowUnknown, "If ", true, ", will successfully parse an unknown resource name into an ", _ctx.Type<UnknownResourceName>(),
                            "; otherwise will throw an", _ctx.Type<ArgumentException>(), " if an unknown resource name is given."),
                        XmlDoc.Returns("The parsed ", _ctx.Type(_def.ContainerTyp), " if successful."));
            }

            private MethodDeclarationSyntax TryParse(XmlNodeSyntax xmlDocUl)
            {
                var name = Parameter(_ctx.Type<string>(), "name");
                var allowUnknown = Parameter(_ctx.Type<bool>(), "allowUnknown");
                var result = Parameter(_ctx.Type(_def.ContainerTyp), "result");
                var unknownResourceName = Local(_ctx.Type<UnknownResourceName>(), "unknownResourceName");
                return Method(Public | Static, _ctx.Type<bool>(), "TryParse")(name, allowUnknown, result.Out())
                    .WithBody(
                        _ctx.Type(typeof(GaxPreconditions)).Call(nameof(GaxPreconditions.CheckNotNull))(name, Nameof(name)),
                        _def.Defs.Select(single =>
                        {
                            var singleName = Local(_ctx.Type(single.ResourceNameTyp), single.ResourceNameTyp.Name.ToLowerCamelCase());
                            return new object[]
                            {
                                If(_ctx.Type(single.ResourceNameTyp).Call("TryParse")(name, ParameterOutVar(singleName))).Then(
                                    result.Assign(New(_ctx.Type(_def.ContainerTyp))(_ctx.Type(OneOfTypeEnumTyp).Access(single.ResourceNameTyp.Name), singleName)),
                                    Return(true))
                            };
                        }),
                        If(allowUnknown).Then(
                            If(_ctx.Type<UnknownResourceName>().Call("TryParse")(name, ParameterOutVar(unknownResourceName))).Then(
                                result.Assign(New(_ctx.Type(_def.ContainerTyp))(_ctx.Type(OneOfTypeEnumTyp).Access("Unknown"), unknownResourceName)),
                                Return(true))),
                        result.Assign(Null),
                        Return(false)
                    )
                    .WithXmlDoc(
                        XmlDoc.Summary("Tries to parse a resource name in string form into a new ", _ctx.Type(_def.ContainerTyp), " instance."),
                        XmlDoc.Remarks("To parse successfully the resource name must be one of the following:", xmlDocUl, "Or an ", _ctx.Type<UnknownResourceName>(), " if ", allowUnknown, " is ", true),
                        XmlDoc.Param(name, "The resource name in string form. Must not be ", null, "."),
                        XmlDoc.Param(allowUnknown, "If ", true, ", will successfully parse an unknown resource name into an ", _ctx.Type<UnknownResourceName>(), "."),
                        XmlDoc.Param(result, "When this method returns, the parsed ", _ctx.Type(_def.ContainerTyp), ", or ", null, " if parsing fails."),
                        XmlDoc.Returns(true, " if the name was parsed succssfully; othrewise ", false));
            }

            private IEnumerable<MethodDeclarationSyntax> Froms()
            {
                foreach (var single in _def.Defs)
                {
                    var name = Parameter(_ctx.Type(single.ResourceNameTyp), single.ResourceNameTyp.Name.ToLowerCamelCase());
                    yield return Method(Public | Static, _ctx.Type(_def.ContainerTyp), "From")(name)
                        .WithBody(New(_ctx.Type(_def.ContainerTyp))(_ctx.Type(OneOfTypeEnumTyp).Access(single.ResourceNameTyp.Name), name))
                        .WithXmlDoc(
                            XmlDoc.Summary("Constructs a new instance of ", _ctx.Type(_def.ContainerTyp), " from the provided ", _ctx.Type(single.ResourceNameTyp), "."),
                            XmlDoc.Param(name, "The ", _ctx.Type(single.ResourceNameTyp), " to be contained within the returned ", _ctx.Type(_def.ContainerTyp), ".",
                                " Must not be ", null),
                            XmlDoc.Returns("A new ", _ctx.Type(_def.ContainerTyp), ", containing ", name, "."));
                }
            }

            private MethodDeclarationSyntax IsValid()
            {
                var type = Parameter(_ctx.Type(OneOfTypeEnumTyp), "type");
                var name = Parameter(_ctx.Type<IResourceName>(), "name");
                var cases = _def.Defs.Select(single =>
                    ((object)_ctx.Type(OneOfTypeEnumTyp).Access(single.ResourceNameTyp.Name), (object)Return(name.Is(_ctx.Type(single.ResourceNameTyp)))));
                return Method(Private | Static, _ctx.Type<bool>(), "IsValid")(type, name)
                    .WithBody(
                        Switch(type)(cases.Prepend((_ctx.Type(OneOfTypeEnumTyp).Access("Unknown"), Return(true))).ToArray()).WithDefault(Return(false)));
            }

            private ConstructorDeclarationSyntax Ctor0(ClassDeclarationSyntax cls,
                PropertyDeclarationSyntax typeProp, PropertyDeclarationSyntax nameProp, MethodDeclarationSyntax isValid)
            {
                var type = Parameter(_ctx.Type(OneOfTypeEnumTyp), "type");
                var name = Parameter(_ctx.Type<IResourceName>(), "name");
                return Ctor(Public, cls)(type, name)
                    .WithBody(
                        typeProp.Assign(_ctx.Type(typeof(GaxPreconditions)).Call(nameof(GaxPreconditions.CheckEnumValue), _ctx.Type(OneOfTypeEnumTyp))(type, Nameof(type))),
                        nameProp.Assign(_ctx.Type(typeof(GaxPreconditions)).Call(nameof(GaxPreconditions.CheckNotNull))(name, Nameof(name))),
                        If(Not(This.Call(isValid)(type, name))).Then(
                            Throw(New(_ctx.Type<ArgumentException>())(Dollar($"Mismatched OneofType '{type}' and resource name '{name}'")))))
                    .WithXmlDoc();
            }

            private PropertyDeclarationSyntax TypeProperty() => AutoProperty(Public, _ctx.Type(OneOfTypeEnumTyp), "Type")
                .WithXmlDoc(XmlDoc.Summary("The ", _ctx.Type(OneOfTypeEnumTyp), " of the Name contained in this instance."));

            private PropertyDeclarationSyntax NameProperty() => AutoProperty(Public, _ctx.Type<IResourceName>(), "Name")
                .WithXmlDoc(XmlDoc.Summary("The ", _ctx.Type<IResourceName>(), " contained in this instance."));

            private MethodDeclarationSyntax CheckAndReturn(PropertyDeclarationSyntax typeProp, PropertyDeclarationSyntax nameProp)
            {
                var t = Typ.GenericParam("T");
                var type = Parameter(_ctx.Type(OneOfTypeEnumTyp), "type");
                return Method(Private, _ctx.Type(t), "CheckAndReturn", t)(type)
                    .WithBody(
                        If(typeProp.NotEqualTo(type)).Then(
                            Throw(New(_ctx.Type<InvalidOperationException>())(Dollar($"Requested type {type}, but this one-of contains type {typeProp}")))),
                        Return(Cast(_ctx.Type(t), nameProp)));
            }

            private IEnumerable<PropertyDeclarationSyntax> Getters(MethodDeclarationSyntax checkAndReturn)
            {
                foreach (var single in _def.Defs)
                {
                    yield return Property(Public, _ctx.Type(single.ResourceNameTyp), single.ResourceNameTyp.Name)
                        .WithGetBody(
                            This.Call(checkAndReturn, _ctx.Type(single.ResourceNameTyp))(_ctx.Type(OneOfTypeEnumTyp).Access(single.ResourceNameTyp.Name)))
                        .WithXmlDoc(
                            XmlDoc.Summary("Get the contained ", _ctx.Type<IResourceName>(), " as ", _ctx.Type(single.ResourceNameTyp), "."),
                            XmlDoc.Remarks("An ", _ctx.Type<InvalidOperationException>(), " will be thrown is this does not contain an instance of ", _ctx.Type(single.ResourceNameTyp), ".")
                        );
                }
            }

            private PropertyDeclarationSyntax Kind() => Property(Public, _ctx.Type<ResourceNameKind>(), nameof(IResourceName.Kind))
                .WithGetBody(_ctx.Type<ResourceNameKind>().Access(ResourceNameKind.Oneof))
                .WithXmlDoc(XmlDoc.InheritDoc);

            private MethodDeclarationSyntax ToString(PropertyDeclarationSyntax nameProp) =>
                Method(Public | Override, _ctx.Type<string>(), nameof(object.ToString))()
                    .WithBody(This.Access(nameProp).Call(nameof(object.ToString))())
                    .WithXmlDoc(XmlDoc.InheritDoc);

            private MethodDeclarationSyntax GetHashCode(MethodDeclarationSyntax toString) =>
                Method(Public | Override, _ctx.Type<int>(), nameof(object.GetHashCode))()
                    .WithBody(This.Call(toString)().Call(nameof(string.GetHashCode))())
                    .WithXmlDoc(XmlDoc.InheritDoc);

            private MethodDeclarationSyntax Equals(MethodDeclarationSyntax equalsIEquatable)
            {
                var obj = Parameter(_ctx.Type<object>(), "obj");
                return Method(Public | Override, _ctx.Type<bool>(), nameof(object.Equals))(obj)
                    .WithBody(This.Call(equalsIEquatable)(obj.As(_ctx.Type(_def.ContainerTyp))))
                    .WithXmlDoc(XmlDoc.InheritDoc);
            }

            private MethodDeclarationSyntax EqualsIEquatable()
            {
                var other = Parameter(_ctx.Type(_def.ContainerTyp), "other");
                return Method(Public, _ctx.Type<bool>(), nameof(IEquatable<int>.Equals))(other)
                    .WithBody(This.Call(nameof(object.ToString))().Equality(other.Call(nameof(object.ToString), conditional: true)()))
                    .WithXmlDoc(XmlDoc.InheritDoc);
            }

            private OperatorDeclarationSyntax EqualityOperator(MethodDeclarationSyntax equalsIEquatable)
            {
                var a = Parameter(_ctx.Type(_def.ContainerTyp), "a");
                var b = Parameter(_ctx.Type(_def.ContainerTyp), "b");
                return OperatorMethod(_ctx.Type<bool>(), "==")(a, b)
                    .WithBody(This.Call(nameof(object.ReferenceEquals))(a, b).Or(Parens(a.Call(equalsIEquatable, conditional: true)(b).NullCoalesce(false))))
                    .WithXmlDoc(XmlDoc.InheritDoc);
            }

            private OperatorDeclarationSyntax InequalityOperator()
            {
                var a = Parameter(_ctx.Type(_def.ContainerTyp), "a");
                var b = Parameter(_ctx.Type(_def.ContainerTyp), "b");
                return OperatorMethod(_ctx.Type<bool>(), "!=")(a, b)
                    .WithBody(Not(Parens(a.Equality(b))))
                    .WithXmlDoc(XmlDoc.InheritDoc);
            }
        }

        private IEnumerable<ClassDeclarationSyntax> ResourceNameClasses()
        {
            var defs = _catalog.GetResourceDefsByFile(_fileDesc);
            var seenTyps = new HashSet<Typ>();
            foreach (var def in defs)
            {
                if (def.Single != null && !def.Single.IsWildcard && !def.Single.IsCommon && seenTyps.Add(def.Single.ResourceNameTyp))
                {
                    // Generate single (ie not a set) resource-name class.
                    // Not for wildcard resources. They don't have a generated class, but use the `UnknownResourceName` class in gax.
                    // Not for common resources. These already exist somewhere else.
                    yield return new ResourceClassBuilder(_ctx, def.FieldName, def.Single, def.DocName).Generate();
                }

                if (def.Multi != null)
                {
                    // Generate the individual resources.
                    foreach (var def0 in def.Multi.Defs.Where(x => seenTyps.Add(x.ResourceNameTyp)))
                    {
                        var docName = def0.ResourceNameTyp.Name.RemoveSuffix("Name").RemoveSuffix("Id");
                        var parameterName = docName.ToLowerCamelCase();
                        yield return new ResourceClassBuilder(_ctx, parameterName, def0, docName).Generate();
                    }
                    yield return new OneOfClassBuilder(_ctx, def.Multi, def.DocName).Generate();
                }
            }
        }

        private IEnumerable<ClassDeclarationSyntax> ProtoMessagePartials()
        {
            // Note: Whether a field is required or optional is purposefully ignored in this partial class.
            // The optionalness of a field is only relevant within a method signature (flattening).
            foreach (var msg in _fileDesc.MessageTypes)
            {
                if (msg.CustomOptions.TryGetMessage<ResourceDescriptor>(ProtoConsts.MessageOption.Resource, out var resDesc))
                {
                    if (_catalog.IsCommonResourceType(resDesc.Type))
                    {
                        continue;
                    }
                }
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
                            .SelectMany(res => new[] { res.resDetails.SingleResourcePropertyName, res.resDetails.MultiResourcePropertyName })
                            .Concat(msg.Fields.InDeclarationOrder().Select(f => f.CSharpPropertyName()))
                            .Append(msg.NestedTypes.Any() ? "Types" : null)
                            .Where(x => x != null));
                        foreach (var res in resources)
                        {
                            var underlyingProperty = Property(DontCare, _ctx.TypeDontCare, res.resDetails.UnderlyingPropertyName);
                            var single = res.resDetails.ResourceDefinition.Single;
                            var multi = res.resDetails.ResourceDefinition.Multi;
                            if (single != null)
                            {
                                cls = cls.AddMembers(ResourceProperty(single.ResourceNameTyp, res.resDetails.SingleResourcePropertyName, single.IsWildcard, false));
                            }
                            if (multi != null)
                            {
                                cls = cls.AddMembers(ResourceProperty(multi.ContainerTyp, res.resDetails.MultiResourcePropertyName, false, true));
                            }
                            
                            PropertyDeclarationSyntax ResourceProperty(Typ resourceNameTyp, string propertyName, bool isWildcard, bool isMulti)
                            {
                                var xmlDocSummary = XmlDoc.Summary(_ctx.Type(resourceNameTyp), "-typed view over the ", underlyingProperty, " resource name property.");
                                if (res.field.IsRepeated)
                                {
                                    var repeatedTyp = Typ.Generic(typeof(ResourceNameList<>), resourceNameTyp);
                                    var s = Parameter(null, "s");
                                    object getter;
                                    if (isWildcard)
                                    {
                                        getter = New(_ctx.Type(repeatedTyp))(underlyingProperty, Lambda(s)(_ctx.Type<UnknownResourceName>().Call(nameof(UnknownResourceName.Parse))(s)));
                                    }
                                    else
                                    {
                                        var parameters = isMulti ? new object[] { s, true } : new[] { s };
                                        getter = New(_ctx.Type(repeatedTyp))(underlyingProperty, Lambda(s)(_ctx.Type(resourceNameTyp).Call("Parse")(parameters)));
                                    }
                                    return Property(Public, _ctx.Type(repeatedTyp), propertyName)
                                        .WithGetBody(getter)
                                        .WithXmlDoc(xmlDocSummary);
                                }
                                else
                                {
                                    object getter;
                                    if (isWildcard)
                                    {
                                        getter = Return(_ctx.Type<string>().Call(nameof(string.IsNullOrEmpty))(underlyingProperty).ConditionalOperator(
                                            Null, _ctx.Type<UnknownResourceName>().Call(nameof(UnknownResourceName.Parse))(underlyingProperty)));
                                    }
                                    else
                                    {
                                        var parameters = isMulti ? new object[] { underlyingProperty, true } : new[] { underlyingProperty };
                                        getter = Return(_ctx.Type<string>().Call(nameof(string.IsNullOrEmpty))(underlyingProperty).ConditionalOperator(
                                            Null, _ctx.Type(resourceNameTyp).Call("Parse")(parameters)));
                                    }
                                    return Property(Public, _ctx.Type(resourceNameTyp), propertyName)
                                        .WithGetBody(getter)
                                        .WithSetBody(underlyingProperty.Assign(Value.Call(nameof(object.ToString), conditional: true)().NullCoalesce("")))
                                        .WithXmlDoc(xmlDocSummary);
                                }
                            }
                        }
                    }
                    yield return cls;
                }
            }
        }
    }
}
