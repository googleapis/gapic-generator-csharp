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
            public ParamProperty(ParameterSyntax parameter, PropertyDeclarationSyntax property) => (Parameter, Property) = (parameter, property);
            public ParameterSyntax Parameter { get; }
            public PropertyDeclarationSyntax Property { get; }
        }

        private IEnumerable<ClassDeclarationSyntax> ResourceNameClasses()
        {
            // TODO: Resource sets.
            var defs = _catalog.GetResourceDefsByFile(_fileDesc);
            foreach (var def in defs)
            {
                if (def.One != null)
                {
                    var cls = Class(Public | Sealed | Partial, def.One.ResourceNameTyp, _ctx.Type<IResourceName>(), _ctx.Type(Typ.Generic(typeof(IEquatable<>), def.One.ResourceNameTyp)))
                        .WithXmlDoc(XmlDoc.Summary("Resource name for the ", XmlDoc.C(def.DocName), " resource"));
                    using (_ctx.InClass(cls))
                    {
                        // TODO: Deal with the "ID" suffix on resource part names.
                        var paramProperties = def.One.Template.ParameterNames.Select(name => new ParamProperty(
                            Parameter(_ctx.Type<string>(), name.ToLowerCamelCase()), AutoProperty(Public, _ctx.Type<string>(), name.ToUpperCamelCase())))
                                .ToList();
                        var templateField = TemplateField();
                        cls = cls.AddMembers(
                            templateField,
                            Parse(templateField),
                            TryParse(templateField),
                            Constructor(cls, paramProperties));
                        cls = cls.AddMembers(PartProperties(paramProperties).ToArray());
                        var toString = ToString(templateField, paramProperties);
                        var equalsIEquality = EqualsIEquatable();
                        cls = cls.AddMembers(
                            Kind(),
                            toString,
                            GetHashCode(toString),
                            Equals(equalsIEquality), equalsIEquality,
                            EqualityOperator(equalsIEquality), InequalityOperator());
                    }
                    yield return cls;
                }

                FieldDeclarationSyntax TemplateField() =>
                    Field(Private | Static | Readonly, _ctx.Type<PathTemplate>(), "s_template").WithInitializer(New(_ctx.Type<PathTemplate>())(def.One.Pattern));

                MethodDeclarationSyntax Parse(FieldDeclarationSyntax templateField)
                {
                    var name = Parameter(_ctx.Type<string>(), def.FieldName);
                    var resourceName = Local(_ctx.Type<TemplatedResourceName>(), "resourceName");
                    return Method(Public | Static, _ctx.Type(def.One.ResourceNameTyp), "Parse")(name)
                        .WithBody(
                            _ctx.Type(typeof(GaxPreconditions)).Call(nameof(GaxPreconditions.CheckNotNull))(name, Nameof(name)),
                            resourceName.WithInitializer(templateField.Call("ParseName")(name)),
                            Return(New(_ctx.Type(def.One.ResourceNameTyp))(def.One.Template.ParameterNames.Select((_, i) => resourceName.ElementAccess(i)))))
                        .WithXmlDoc(
                            XmlDoc.Summary("Parses the given ", XmlDoc.C(def.DocName), " resource name in string form into a new ", _ctx.Type(def.One.ResourceNameTyp), " instance."),
                            XmlDoc.Param(name, "The ", XmlDoc.C(def.DocName), " resource name in string form. Must not be ", null, "."),
                            XmlDoc.Returns("The parsed ", _ctx.Type(def.One.ResourceNameTyp), " if successful.")
                        );
                }

                MethodDeclarationSyntax TryParse(FieldDeclarationSyntax templateField)
                {
                    var name = Parameter(_ctx.Type<string>(), def.FieldName);
                    var result = Parameter(_ctx.Type(def.One.ResourceNameTyp), "result").Out();
                    var resourceName = ParameterOutVar(_ctx.Type<TemplatedResourceName>(), "resourceName");
                    return Method(Public | Static, _ctx.Type<bool>(), "TryParse")(name, result)
                        .WithBody(
                            _ctx.Type(typeof(GaxPreconditions)).Call(nameof(GaxPreconditions.CheckNotNull))(name, Nameof(name)),
                            If(templateField.Call(nameof(PathTemplate.TryParseName))(name, resourceName))
                                .Then(
                                    result.Assign(New(_ctx.Type(def.One.ResourceNameTyp))(def.One.Template.ParameterNames.Select((_, i) => resourceName.ElementAccess(i)))),
                                    Return(true))
                                .Else(
                                    result.Assign(Null),
                                    Return(false)))
                        .WithXmlDoc(
                            XmlDoc.Summary("Tries to parse the given session resource name in string form into a new ", _ctx.Type(def.One.ResourceNameTyp), " instance."),
                            XmlDoc.Remarks("This method still throws ", _ctx.Type<ArgumentNullException>(), " if ", name, " is ", null,
                                ", as this would usually indicate a programming error rather than a data error."),
                            XmlDoc.Param(name, "The ", XmlDoc.C(def.DocName), " resource name in string form. Must not be ", null, "."),
                            XmlDoc.Param(result, "When this method returns, the parsed ", _ctx.Type(def.One.ResourceNameTyp), ", or ", null, " if parsing fails."),
                            XmlDoc.Returns(true, " if the name was parsed successfully; ", false, " otherwise.")
                        );
                }

                ConstructorDeclarationSyntax Constructor(ClassDeclarationSyntax cls, IEnumerable<ParamProperty> paramProperties)
                {
                    // TODO: Sort out "ID" suffix on part names, in parameter/property names, and in XmlDoc.
                    return Ctor(Public, cls)(paramProperties.Select(x => x.Parameter).ToArray())
                        .WithBody(paramProperties.Select(x =>
                            x.Property.Assign(_ctx.Type(typeof(GaxPreconditions)).Call(nameof(GaxPreconditions.CheckNotNull))(x.Parameter, Nameof(x.Parameter)))))
                        .WithXmlDoc(paramProperties.Select(x => XmlDoc.Param(x.Parameter, "The ", x.Parameter.Identifier.Text, " ID. Must not be ", null, "."))
                            .Prepend(XmlDoc.Summary("Constructs a new instance of the ", _ctx.Type(def.One.ResourceNameTyp), " resource name class from its component parts.")).ToArray());
                }

                IEnumerable<PropertyDeclarationSyntax> PartProperties(IEnumerable<ParamProperty> paramProperties)
                {
                    // TODO: Get rid of this, put XmlDoc elsewhere?
                    return paramProperties.Select(x => x.Property.WithXmlDoc(
                        XmlDoc.Summary("The ", x.Property.Identifier.Text, " ID. Never ", null, ".")));
                }

                PropertyDeclarationSyntax Kind() => Property(Public, _ctx.Type<ResourceNameKind>(), nameof(IResourceName.Kind))
                    .WithGetBody(_ctx.Type<ResourceNameKind>().Access(ResourceNameKind.Simple))
                    .WithXmlDoc(XmlDoc.InheritDoc);

                MethodDeclarationSyntax ToString(FieldDeclarationSyntax templateField, IEnumerable<ParamProperty> paramProperties) =>
                    Method(Public | Override, _ctx.Type<string>(), nameof(object.ToString))()
                        .WithBody(templateField.Call(nameof(PathTemplate.Expand))(paramProperties.Select(x => x.Property).ToArray()))
                        .WithXmlDoc(XmlDoc.InheritDoc);

                MethodDeclarationSyntax GetHashCode(MethodDeclarationSyntax toString) =>
                    Method(Public | Override, _ctx.Type<int>(), nameof(object.GetHashCode))()
                        .WithBody(This.Call(toString)().Call(nameof(string.GetHashCode))())
                        .WithXmlDoc(XmlDoc.InheritDoc);

                MethodDeclarationSyntax EqualsIEquatable()
                {
                    var other = Parameter(_ctx.Type(def.One.ResourceNameTyp), "other");
                    return Method(Public, _ctx.Type<bool>(), nameof(IEquatable<int>.Equals))(other)
                        .WithBody(This.Call(nameof(object.ToString))().Equality(other.Call(nameof(object.ToString), conditional: true)()))
                        .WithXmlDoc(XmlDoc.InheritDoc);
                }

                MethodDeclarationSyntax Equals(MethodDeclarationSyntax equalsIEquatable)
                {
                    var obj = Parameter(_ctx.Type<object>(), "obj");
                    return Method(Public | Override, _ctx.Type<bool>(), nameof(object.Equals))(obj)
                        .WithBody(This.Call(equalsIEquatable)(obj.As(_ctx.Type(def.One.ResourceNameTyp))))
                        .WithXmlDoc(XmlDoc.InheritDoc);
                }

                OperatorDeclarationSyntax EqualityOperator(MethodDeclarationSyntax equalsIEquatable)
                {
                    var a = Parameter(_ctx.Type(def.One.ResourceNameTyp), "a");
                    var b = Parameter(_ctx.Type(def.One.ResourceNameTyp), "b");
                    return OperatorMethod(_ctx.Type<bool>(), "==")(a, b)
                        .WithBody(This.Call(nameof(object.ReferenceEquals))(a, b).Or(Parens(a.Call(equalsIEquatable, conditional: true)(b).NullCoalesce(false))))
                        .WithXmlDoc(XmlDoc.InheritDoc);
                }

                OperatorDeclarationSyntax InequalityOperator()
                {
                    var a = Parameter(_ctx.Type(def.One.ResourceNameTyp), "a");
                    var b = Parameter(_ctx.Type(def.One.ResourceNameTyp), "b");
                    return OperatorMethod(_ctx.Type<bool>(), "!=")(a, b)
                        .WithBody(Not(Parens(a.Equality(b))))
                        .WithXmlDoc(XmlDoc.InheritDoc);
                }
            }

        }

        private IEnumerable<ClassDeclarationSyntax> ProtoMessagePartials()
        {
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
                        foreach(var res in resources)
                        {
                            var underlyingProperty = Property(DontCare, _ctx.TypeDontCare, res.resDetails.UnderlyingPropertyName);
                            if (res.field.IsRepeated)
                            {
                                throw new NotImplementedException();
                            }
                            else
                            {
                                var one = res.resDetails.ResourceDefinition.One;
                                if (one != null)
                                {
                                    object getter;
                                    if (one.IsWildcard)
                                    {
                                        // TODO: Wildcard pattern support.
                                        throw new NotImplementedException();
                                    }
                                    else
                                    {
                                        getter = Return(_ctx.Type<string>().Call(nameof(string.IsNullOrEmpty))(underlyingProperty).ConditionalOperator(
                                            Null, _ctx.Type(one.ResourceNameTyp).Call("Parse")(underlyingProperty)));
                                    }
                                    var resourceProperty = Property(Public, _ctx.Type(one.ResourceNameTyp), res.resDetails.ResourcePropertyName)
                                        .WithGetBody(getter)
                                        .WithSetBody(underlyingProperty.Assign(Value.Call(nameof(object.ToString), conditional: true)().NullCoalesce("")))
                                        .WithXmlDoc(XmlDoc.Summary(_ctx.Type(one.ResourceNameTyp), "-typed view over the ", underlyingProperty, " resource name property."));
                                    // TODO: Sets and One/Set combination.
                                    cls = cls.AddMembers(resourceProperty);
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
