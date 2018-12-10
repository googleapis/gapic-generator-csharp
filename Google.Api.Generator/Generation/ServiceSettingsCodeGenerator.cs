﻿// Copyright 2018 Google Inc. All Rights Reserved.
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
using Google.Api.Gax.Grpc;
using Google.Api.Generator.RoslynUtils;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using static Google.Api.Generator.RoslynUtils.Modifier;
using static Google.Api.Generator.RoslynUtils.RoslynBuilder;

namespace Google.Api.Generator.Generation
{
    /// <summary>
    /// Generate all code for the `Settings` class of a proto-defined service.
    /// </summary>
    internal class ServiceSettingsCodeGenerator
    {
        public static ClassDeclarationSyntax Generate(SourceFileContext ctx, ServiceDetails svc) =>
            new ServiceSettingsCodeGenerator(ctx, svc).Generate();

        private ServiceSettingsCodeGenerator(SourceFileContext ctx, ServiceDetails svc) =>
            (_ctx, _svc) = (ctx, svc);

        private readonly SourceFileContext _ctx;
        private readonly ServiceDetails _svc;

        private ClassDeclarationSyntax Generate()
        {
            // TODO: Re-word the xmldoc summary, or handle the "a"/"an" case properly.
            var cls = Class(Public | Sealed | Partial, _svc.SettingsTyp, baseType: _ctx.Type<ServiceSettingsBase>())
                .WithXmlDoc(XmlDoc.Summary("Settings for a ", _ctx.Type(_svc.ClientAbstractTyp), "."));
            using (_ctx.InClass(cls))
            {
                cls = cls.AddMembers(GetDefault());
                cls = cls.AddMembers(ParameterlessCtor());
                cls = cls.AddMembers(CopyCtor());
                cls = cls.AddMembers(OnCopyPartial());
                cls = cls.AddMembers(SettingsProperties().ToArray());
                cls = cls.AddMembers(Clone());
            }
            return cls;
        }

        // Generates the GetDefault() static method in the Settings class.
        private MemberDeclarationSyntax GetDefault() =>
            Method(Public | Static, _ctx.CurrentType, "GetDefault")()
                .WithBody(New(_ctx.CurrentType)())
                .WithXmlDoc(
                    XmlDoc.Summary("Get a new instance of the default ", _ctx.CurrentType, "."),
                    XmlDoc.Returns("A new instance of the default ", _ctx.CurrentType, "."));

        // Generates the parameterless constructor in the Settings class.
        private MemberDeclarationSyntax ParameterlessCtor() =>
            Ctor(Public, _ctx.CurrentTyp)()
                .WithBody()
                .WithXmlDoc(XmlDoc.Summary("Constructs a new ", _ctx.CurrentType, " object with default settings."));

        // Generates the copy ctor in the Settings class.
        private MemberDeclarationSyntax CopyCtor()
        {
            var existing = Parameter(_ctx.CurrentType, "existing");
            return Ctor(Private, _ctx.CurrentTyp)(existing)
                .WithBody(
                    // Check `existing` parameter value is not null.
                    _ctx.Type(typeof(GaxPreconditions)).Call(nameof(GaxPreconditions.CheckNotNull))(existing, Nameof(existing)),
                    // Copy all the per-method settings.
                    SettingsProperties().Select(p => p.Assign(existing.Access(p))),
                    // Call the OnCopy() partial method.
                    This.Call("OnCopy")(existing)
                );
        }

        private IEnumerable<PropertyDeclarationSyntax> SettingsProperties()
        {
            return _svc.Methods.SelectMany(PerMethod);
            IEnumerable<PropertyDeclarationSyntax> PerMethod(MethodDetails method)
            {
                var property = AutoProperty(Public, _ctx.Type<CallSettings>(), method.SettingsName, hasSetter: true);
                // TODO: XmlDoc.
                // TODO: Initialization.
                yield return property;
                // TODO: Extra properties for LRO and streaming methods.
            }
        }

        private MemberDeclarationSyntax OnCopyPartial() => PartialMethod("OnCopy")(Parameter(_ctx.CurrentType, "existing"));

        private MemberDeclarationSyntax Clone() =>
            Method(Public, _ctx.CurrentType, "Clone")()
                .WithBody(New(_ctx.CurrentType)(This))
                .WithXmlDoc(
                    XmlDoc.Summary("Creates a deep clone of this object, with all the same property values."),
                    XmlDoc.Returns("A deep clone of this ", _ctx.CurrentType, " object.")
                );
    }
}
