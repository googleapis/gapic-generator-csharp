// Copyright 2025 Google LLC
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

using Google.Api.Generator.ProtoUtils;
using Google.Api.Generator.Utils;
using Google.Api.Generator.Utils.Roslyn;
using Google.Protobuf.Reflection;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using static Google.Api.Generator.Utils.Roslyn.Modifier;
using static Google.Api.Generator.Utils.Roslyn.RoslynBuilder;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Google.Api.Generator.Generation;

/// <summary>
/// Generates a static class (with nested static classes) to provide
/// string constants for the wire representations of enum values. This is only used
/// for DIREGAPIC APIs (currently just Compute).
/// </summary>
internal class EnumStringGenerator
{
    // TODO: Determine a policy or config for the class, file and API description.
    internal const string RootClassName = "ComputeEnumConstants";
    private const string ApiDescription = "Compute API";

    public static CompilationUnitSyntax MaybeGenerate(SourceFileContext ctx, string ns, IEnumerable<FileDescriptor> packageFileDescriptors)
    {
        // TODO: Add an option in the service config for this... although this will be fine for now,
        // as only Compute needs this.
        if (!ns.StartsWith("Google.Cloud.Compute.", StringComparison.Ordinal))
        {
            return null;
        }

        var container = new EnumContainer(null, packageFileDescriptors.SelectMany(d => d.EnumTypes), packageFileDescriptors.SelectMany(d => d.MessageTypes));
        if (!container.ShouldGenerate)
        {
            return null;
        }
                
        var nsDeclaration = Namespace(ns);
        using (ctx.InNamespace(nsDeclaration))
        {
            nsDeclaration = nsDeclaration.AddMembers(new[] { container.Generate(ctx) });
        }
        return ctx.CreateCompilationUnit(nsDeclaration);
    }

    /// <summary>
    /// A container for either enums or other nested enum containers (or both).
    /// </summary>
    public class EnumContainer
    {
        public MessageDescriptor Descriptor { get; }

        public List<EnumContainer> NestedContainers { get; }

        public List<EnumDescriptor> Enums { get; }

        public bool ShouldGenerate => Enums.Count > 0 || NestedContainers.Any(nc => nc.ShouldGenerate);

        public EnumContainer(MessageDescriptor descriptor, IEnumerable<EnumDescriptor> enums, IEnumerable<MessageDescriptor> messages)
        {
            Descriptor = descriptor;
            Enums = enums.ToList();
            NestedContainers = messages.Select(message => new EnumContainer(message, message.EnumTypes, message.NestedTypes)).ToList();
        }

        public MemberDeclarationSyntax Generate(SourceFileContext ctx)
        {
            var cls = Descriptor is object
                ? Class(Public | Static, Typ.Nested(ctx.CurrentTyp, Descriptor.Name))
                    .WithXmlDoc(XmlDoc.Summary("Container class for enums within the ", GlobalTypeSyntax(ProtoTyp.Of(Descriptor)), " message."))
                : Class(Public | Static, Typ.Manual(ctx.Namespace, RootClassName))
                    .WithXmlDoc(XmlDoc.Summary($"Helper constants with the wire representation for enums within the {ApiDescription}."))
                ;

            using (ctx.InClass(cls))
            {
                var enumClasses = Enums.OrderBy(d => d.Name, StringComparer.Ordinal).Select(GenerateEnumClass);
                var nestedClasses = NestedContainers.Where(nc => nc.ShouldGenerate).OrderBy(nc => nc.Descriptor.Name, StringComparer.Ordinal).Select(nested => nested.Generate(ctx));
                cls = cls.AddMembers(enumClasses.ToArray());
                cls = cls.AddMembers(nestedClasses.ToArray());
            }
            return cls;

            MemberDeclarationSyntax GenerateEnumClass(EnumDescriptor descriptor)
            {
                var enumCls = Class(Public | Static, Typ.Nested(ctx.CurrentTyp, descriptor.Name))
                    .WithXmlDoc(XmlDoc.Summary("Constants for wire representations of the ", GlobalTypeSyntax(ProtoTyp.Of(descriptor)), " enum."));

                using (ctx.InClass(enumCls))
                {
                    enumCls = enumCls.AddMembers(descriptor.Values.Select(GenerateEnumConstant).ToArray());
                }
                return enumCls;

                MemberDeclarationSyntax GenerateEnumConstant(EnumValueDescriptor value)
                {
                    string wireValue = value.Name;
                    string enumValueName = value.CSharpName();
                    string constantName = enumValueName;
                    if (NeedsUnderscore(constantName))
                    {
                        constantName += "_";
                    }
                    var enumValueAccess = GlobalTypeSyntax(ProtoTyp.Of(value.EnumDescriptor)).Access(enumValueName);
                    return Field(Public | Const, ctx.Type<string>(), constantName)
                        .WithXmlDoc(XmlDoc.Summary("Wire representation of ", enumValueAccess, "."))
                        .WithInitializer(wireValue);
                }

                // Initially only Equals needs "escaping". It's unlikely that we'll get ToString or GetHashCode as field names,
                // but there may be other cases. Just add them here as needed.
                bool NeedsUnderscore(string name) => name == "Equals";
            }

            // Due to the nesting, it's simplest to use names of the form global::X.Y.Z to refer to the real
            // message and enum types. That's tricky with our existing SourceFileContext code, so this method just builds it.
            TypeSyntax GlobalTypeSyntax(Typ typ)
            {
                var segments = typ.FullName.Replace('+', '.').Split('.');

                var name = (NameSyntax) AliasQualifiedName(IdentifierName("global"), IdentifierName(segments.First()));
                foreach (var segment in segments.Skip(1))
                {
                    name = QualifiedName(name, IdentifierName(segment));
                }
                return name;
            }
            
        }
    }
}
