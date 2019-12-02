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

using Google.Api.Gax;
using Google.Api.Gax.Grpc;
using Google.Api.Generator.RoslynUtils;
using Google.LongRunning;
using Grpc.Core;
using Microsoft.CodeAnalysis;
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
        private static readonly PollSettings s_lroDefaultPollSettings = new PollSettings(
            expiration: Expiration.FromTimeout(TimeSpan.FromHours(24)),
            delay: TimeSpan.FromSeconds(20),
            delayMultiplier: 1.5,
            maxDelay: TimeSpan.FromSeconds(45));

        private static readonly SyntaxAnnotation s_cloneSetting = new SyntaxAnnotation("cloneSetting");

        public static ClassDeclarationSyntax Generate(SourceFileContext ctx, ServiceDetails svc) =>
            new ServiceSettingsCodeGenerator(ctx, svc).Generate();

        private ServiceSettingsCodeGenerator(SourceFileContext ctx, ServiceDetails svc) =>
            (_ctx, _svc) = (ctx, svc);

        private readonly SourceFileContext _ctx;
        private readonly ServiceDetails _svc;

        private ClassDeclarationSyntax Generate()
        {
            var cls = Class(Public | Sealed | Partial, _svc.SettingsTyp, baseTypes: _ctx.Type<ServiceSettingsBase>())
                .WithXmlDoc(XmlDoc.Summary("Settings for ", _ctx.Type(_svc.ClientAbstractTyp), " instances."));
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
            return Ctor(Private, _ctx.CurrentTyp, initializer: BaseInitializer(existing))(existing)
                .WithBody(
                    // Check `existing` parameter value is not null.
                    _ctx.Type(typeof(GaxPreconditions)).Call(nameof(GaxPreconditions.CheckNotNull))(existing, Nameof(existing)),
                    // Copy all the per-method settings.
                    SettingsProperties().Select(CopySetting),
                    // Call the OnCopy() partial method.
                    This.Call("OnCopy")(existing)
                );

            object CopySetting(PropertyDeclarationSyntax property)
            {
                var assign = property.Assign(existing.Access(property));
                return property.HasAnnotation(s_cloneSetting) ? assign.Call("Clone")() : (object)assign;
            }
        }

        private IEnumerable<PropertyDeclarationSyntax> SettingsProperties()
        {
            return _svc.Methods.SelectMany(PerMethod);
            IEnumerable<PropertyDeclarationSyntax> PerMethod(MethodDetails method)
            {
                var cSync = XmlDoc.C($"{_svc.ClientAbstractTyp.Name}.{method.SyncMethodName}");
                var cAsync = XmlDoc.C($"{_svc.ClientAbstractTyp.Name}.{method.AsyncMethodName}");
                // Add the general per-method settings property.
                // We always specify an expiration, and the retry is optional.
                var expiration = method.Expiration ?? Expiration.None;
                var property = AutoProperty(Public, _ctx.Type<CallSettings>(), method.SettingsName, hasSetter: true)
                    .WithInitializer(_ctx.Type<CallSettings>().Call(nameof(CallSettings.FromExpiration))(
                        expiration.Type == ExpirationType.None
                        ? _ctx.Type(typeof(Expiration)).Access(nameof(Expiration.None))
                        : _ctx.Type(typeof(Expiration)).Call(nameof(Expiration.FromTimeout))(_ctx.Type<TimeSpan>().Call(nameof(TimeSpan.FromMilliseconds))((int) expiration.Timeout.Value.TotalMilliseconds))));
                var xmlSummary = XmlDoc.Summary(_ctx.Type<CallSettings>(), " for synchronous and asynchronous calls to ", cSync, " and ", cAsync, ".");
                string timeoutRemark = expiration.Type == ExpirationType.None ? "No timeout is applied." : $"Timeout: {(int) expiration.Timeout.Value.TotalSeconds} seconds.";

                if (method.MethodRetry != null)
                {
                    var retry = method.MethodRetry;
                    var retryExpression = _ctx.Type<RetrySettings>().Call(nameof(RetrySettings.FromExponentialBackoff))(
                        ("maxAttempts", retry.MaxAttempts),
                        ("initialBackoff", _ctx.Type<TimeSpan>().Call(nameof(TimeSpan.FromMilliseconds))((int) retry.InitialBackoff.TotalMilliseconds)),
                        ("maxBackoff", _ctx.Type<TimeSpan>().Call(nameof(TimeSpan.FromMilliseconds))((int) retry.MaxBackoff.TotalMilliseconds)),
                        ("backoffMultiplier", retry.BackoffMultiplier),
                        ("retryFilter", _ctx.Type<RetrySettings>().Call(nameof(RetrySettings.FilterForStatusCodes))(
                                        method.MethodRetryStatusCodes.Select(x => _ctx.Type<StatusCode>().Access(x))))
                    );
                    // WithRetry is an extension method, but all our imports are aliased, so the extension methods aren't imported.
                    // While this is a little ugly, it avoids collisions.
                    property = property.WithInitializer(
                        _ctx.Type(typeof(CallSettingsExtensions)).Call(nameof(CallSettingsExtensions.WithRetry))(property.Initializer.Value, retryExpression))
                        .WithXmlDoc(xmlSummary,
                            XmlDoc.Remarks(
                                XmlDoc.UL(
                                    $"Initial retry delay: {(int)retry.InitialBackoff.TotalMilliseconds} milliseconds.",
                                    $"Retry delay multiplier: {retry.BackoffMultiplier}",
                                    $"Retry maximum delay: {(int)retry.MaxBackoff.TotalMilliseconds} milliseconds.",
                                    $"Maximum attempts: {(int)retry.MaxAttempts}",
                                    timeoutRemark)));
                }
                else
                {
                    property = property.WithXmlDoc(xmlSummary,
                        XmlDoc.Remarks(XmlDoc.UL(
                            "This call will not be retried.",
                            timeoutRemark)));
                }
                yield return property;
                // Add extra properties as required for special call types.
                switch (method)
                {
                    case MethodDetails.Lro lro:
                        yield return LroSettingsProperty(lro);
                        break;
                    case MethodDetails.BidiStreaming bidi:
                        yield return BidiSettingsProperty(bidi);
                        break;
                }
            }
        }

        private PropertyDeclarationSyntax LroSettingsProperty(MethodDetails.Lro method) =>
            AutoProperty(Public, _ctx.Type<OperationsSettings>(), method.LroSettingsName, hasSetter: true)
                .WithInitializer(New(_ctx.Type<OperationsSettings>())().WithInitializer(
                    new ObjectInitExpr(nameof(OperationsSettings.DefaultPollSettings), New(_ctx.Type<PollSettings>())(
                        _ctx.Type<Expiration>().Call(nameof(Expiration.FromTimeout))(_ctx.Type<TimeSpan>().Call(nameof(TimeSpan.FromHours))((int)s_lroDefaultPollSettings.Expiration.Timeout.Value.TotalHours)),
                        _ctx.Type<TimeSpan>().Call(nameof(TimeSpan.FromSeconds))((int)s_lroDefaultPollSettings.Delay.TotalSeconds),
                        s_lroDefaultPollSettings.DelayMultiplier,
                        _ctx.Type<TimeSpan>().Call(nameof(TimeSpan.FromSeconds))((int)s_lroDefaultPollSettings.MaxDelay.TotalSeconds)))))
                .WithXmlDoc(
                    XmlDoc.Summary("Long Running Operation settings for calls to ",
                        XmlDoc.C($"{_svc.ClientAbstractTyp.Name}.{method.SyncMethodName}"), " and ",
                        XmlDoc.C($"{_svc.ClientAbstractTyp.Name}.{method.AsyncMethodName}"), "."),
                    XmlDoc.Remarks("Uses default ", _ctx.Type<PollSettings>(), " of:", XmlDoc.UL(
                        $"Initial delay: {(int)s_lroDefaultPollSettings.Delay.TotalSeconds} seconds.",
                        $"Delay multiplier: {s_lroDefaultPollSettings.DelayMultiplier}",
                        $"Maximum delay: {(int)s_lroDefaultPollSettings.MaxDelay.TotalSeconds} seconds.",
                        $"Total timeout: {(int)s_lroDefaultPollSettings.Expiration.Timeout.Value.TotalHours} hours.")))
                .WithAdditionalAnnotations(s_cloneSetting);

        private PropertyDeclarationSyntax BidiSettingsProperty(MethodDetails.BidiStreaming method) =>
            AutoProperty(Public, _ctx.Type<BidirectionalStreamingSettings>(), method.StreamingSettingsName, hasSetter: true)
                .WithInitializer(New(_ctx.Type<BidirectionalStreamingSettings>())(100))
                .WithXmlDoc(
                    XmlDoc.Summary(_ctx.Type<BidirectionalStreamingSettings>(), " for calls to ",
                        XmlDoc.C($"{_svc.ClientAbstractTyp.Name}.{method.SyncMethodName}"), " and ",
                        XmlDoc.C($"{_svc.ClientAbstractTyp.Name}.{method.AsyncMethodName}"), "."),
                    XmlDoc.Remarks("The default local send queue size is 100."));

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
