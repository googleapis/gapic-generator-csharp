// Copyright 2018 Google Inc. All Rights Reserved.
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

using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Google.Api.Generator.RoslynUtils.RoslynBuilder;

namespace Google.Api.Generator.Generation
{
    /// <summary>
    /// Generate all code related to a proto-defined service.
    /// </summary>
    internal static class ServiceCodeGenerator
    {
        public static CompilationUnitSyntax Generate(SourceFileContext ctx, ServiceDetails svc)
        {
            var ns = Namespace(svc.Namespace);
            using (ctx.InNamespace(ns))
            {
                var settingsClass = ServiceSettingsCodeGenerator.Generate(ctx, svc);
                var abstractClientClass = ServiceAbstractClientClassCodeGenerator.Generate(ctx, svc);
                var implClientClass = ServiceImplClientClassGenerator.Generate(ctx, svc);
                ns = ns.AddMembers(settingsClass, abstractClientClass, implClientClass);
            }
            return ctx.CreateCompilationUnit(ns);
        }
    }
}
