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
using Google.Api.Generator.Utils;
using Google.Api.Generator.Utils.Roslyn;
using Google.LongRunning;
using Grpc.Core;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using static Google.Api.Generator.Utils.Roslyn.Modifier;
using static Google.Api.Generator.Utils.Roslyn.RoslynBuilder;

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
                .MaybeWithAttribute(_svc.IsDeprecated, () => _ctx.Type<ObsoleteAttribute>())()
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
            return _svc.Methods.SelectMany(PerMethod)
                .Concat(_svc.Mixins.Select(PerMixin));
            IEnumerable<PropertyDeclarationSyntax> PerMethod(MethodDetails method)
            {
                var cSync = XmlDoc.C($"{_svc.ClientAbstractTyp.Name}.{method.SyncMethodName}");
                var cAsync = XmlDoc.C($"{_svc.ClientAbstractTyp.Name}.{method.AsyncMethodName}");
                // Add the general per-method settings property.
                // We always specify an expiration, and the retry is optional.
                // The property always has an initializer, XML summary, and XML remarks.
                // We build each of these separately based on the settings, then assemble the property.
                var expiration = method.Expiration ?? Expiration.None;
                var xmlSummary = XmlDoc.Summary(_ctx.Type<CallSettings>(), " for synchronous and asynchronous calls to ", cSync, " and ", cAsync, ".");
                string timeoutRemark = expiration.Type == ExpirationType.None ? "No timeout is applied." : $"Timeout: {(int) expiration.Timeout.Value.TotalSeconds} seconds.";

                var initializer = _ctx.Type<CallSettings>().Call(nameof(CallSettings.FromExpiration))(
                    expiration.Type == ExpirationType.None
                        ? _ctx.Type(typeof(Expiration)).Access(nameof(Expiration.None))
                        : _ctx.Type(typeof(Expiration)).Call(nameof(Expiration.FromTimeout))(_ctx.Type<TimeSpan>().Call(nameof(TimeSpan.FromMilliseconds))((int) expiration.Timeout.Value.TotalMilliseconds)));
                DocumentationCommentTriviaSyntax xmlRemarks;
                if (method.MethodRetry != null)
                {
                    if (method is MethodDetails.IStreaming)
                    {
                        // Eventually it may  be illegal to configure retry on streaming methods, but for now just remove it.
                        // It is not possible to apply retry to streaming methods in the general case.
                        //property = property.WithXmlDoc(xmlSummary, XmlDoc.Remarks(timeoutRemark));
                        xmlRemarks = XmlDoc.Remarks(timeoutRemark);
                    }
                    else
                    {
                        var retry = method.MethodRetry;
                        var retryExpression = _ctx.Type<RetrySettings>().Call(nameof(RetrySettings.FromExponentialBackoff))(
                            ("maxAttempts", retry.MaxAttempts),
                            ("initialBackoff", _ctx.Type<TimeSpan>().Call(nameof(TimeSpan.FromMilliseconds))((int)retry.InitialBackoff.TotalMilliseconds)),
                            ("maxBackoff", _ctx.Type<TimeSpan>().Call(nameof(TimeSpan.FromMilliseconds))((int)retry.MaxBackoff.TotalMilliseconds)),
                            ("backoffMultiplier", retry.BackoffMultiplier),
                            ("retryFilter", _ctx.Type<RetrySettings>().Call(nameof(RetrySettings.FilterForStatusCodes))(
                                            method.MethodRetryStatusCodes.Select(x => _ctx.Type<StatusCode>().Access(x))))
                        );
                        // WithRetry is an extension method, but all our imports are aliased, so the extension methods aren't imported.
                        // While this is a little ugly, it avoids collisions.
                        initializer =
                            _ctx.Type(typeof(CallSettingsExtensions)).Call(nameof(CallSettingsExtensions.WithRetry))(initializer, retryExpression);
                        xmlRemarks = XmlDoc.Remarks(
                            XmlDoc.UL(
                                $"Initial retry delay: {(int)retry.InitialBackoff.TotalMilliseconds} milliseconds.",
                                $"Retry delay multiplier: {retry.BackoffMultiplier}",
                                $"Retry maximum delay: {(int)retry.MaxBackoff.TotalMilliseconds} milliseconds.",
                                $"Maximum attempts: {(retry.MaxAttempts == int.MaxValue ? "Unlimited" : retry.MaxAttempts.ToString())}",
                                GetRetriableErrorCodeDocs().ToArray(),
                                timeoutRemark));

                        IEnumerable<object> GetRetriableErrorCodeDocs()
                        {
                            var codes = method.MethodRetryStatusCodes.ToList();
                            if (!codes.Any())
                            {
                                // This is a little unusual, in terms of "Here are the retry timing parameters, that will never be used..." but
                                // I guess the settings could then be augmented with status codes. (And this does happen.)
                                yield return "No status codes are retried.";
                                yield break;
                            }

                            yield return "Retriable status codes: ";
                            for (int i = 0; i < codes.Count; i++)
                            {
                                if (i != 0)
                                {
                                    yield return ", ";
                                }
                                yield return _ctx.Type<StatusCode>().Access(codes[i]);
                            }
                            yield return ".";
                        }
                    }
                }
                else
                {
                    xmlRemarks = XmlDoc.Remarks(XmlDoc.UL(
                        "This call will not be retried.",
                        timeoutRemark));
                }
                var property = AutoProperty(Public, _ctx.Type<CallSettings>(), method.SettingsName, hasSetter: true)
                    .WithInitializer(initializer)
                    .WithXmlDoc(xmlSummary, xmlRemarks);
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
                    case MethodDetails.ClientStreaming client:
                        yield return ClientSettingsProperty(client);
                        break;
                }
            }

            PropertyDeclarationSyntax PerMixin(ServiceDetails.MixinDetails mixin)
            {
                var settingsType = _ctx.Type(mixin.GapicSettingsType);
                var propertyName = mixin.GapicSettingsType.Name;
                return AutoProperty(Public, settingsType, propertyName, hasSetter: true)
                    .WithInitializer(settingsType.Call("GetDefault")())
                    .WithXmlDoc(XmlDoc.Summary("The settings to use for the ", _ctx.Type(mixin.GapicClientType), " associated with the client."));
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

        private PropertyDeclarationSyntax ClientSettingsProperty(MethodDetails.ClientStreaming method) =>
            AutoProperty(Public, _ctx.Type<ClientStreamingSettings>(), method.StreamingSettingsName, hasSetter: true)
                .WithInitializer(New(_ctx.Type<ClientStreamingSettings>())(100))
                .WithXmlDoc(
                    XmlDoc.Summary(_ctx.Type<ClientStreamingSettings>(), " for calls to ",
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
