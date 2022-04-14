// Copyright 2019 Google LLC
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

// Generated code. DO NOT EDIT!

using gax = Google.Api.Gax;
using gaxgrpc = Google.Api.Gax.Grpc;
using gaxgrpccore = Google.Api.Gax.Grpc.GrpcCore;
using proto = Google.Protobuf;
using grpccore = Grpc.Core;
using grpcinter = Grpc.Core.Interceptors;
using sys = System;
using scg = System.Collections.Generic;
using sco = System.Collections.ObjectModel;
using linq = System.Linq;
using st = System.Threading;
using stt = System.Threading.Tasks;

namespace Testing.ResourceNames
{
    /// <summary>Settings for <see cref="ResourceNamesClient"/> instances.</summary>
    public sealed partial class ResourceNamesSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="ResourceNamesSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="ResourceNamesSettings"/>.</returns>
        public static ResourceNamesSettings GetDefault() => new ResourceNamesSettings();

        /// <summary>Constructs a new <see cref="ResourceNamesSettings"/> object with default settings.</summary>
        public ResourceNamesSettings()
        {
        }

        private ResourceNamesSettings(ResourceNamesSettings existing) : base(existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            SinglePatternMethodSettings = existing.SinglePatternMethodSettings;
            DeprecatedPatternMethodSettings = existing.DeprecatedPatternMethodSettings;
            WildcardOnlyPatternMethodSettings = existing.WildcardOnlyPatternMethodSettings;
            WildcardMultiPatternMethodSettings = existing.WildcardMultiPatternMethodSettings;
            WildcardMultiPatternMultipleMethodSettings = existing.WildcardMultiPatternMultipleMethodSettings;
            LooseValidationPatternMethodSettings = existing.LooseValidationPatternMethodSettings;
            OnCopy(existing);
        }

        partial void OnCopy(ResourceNamesSettings existing);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>ResourceNamesClient.SinglePatternMethod</c> and <c>ResourceNamesClient.SinglePatternMethodAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings SinglePatternMethodSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>ResourceNamesClient.DeprecatedPatternMethod</c> and <c>ResourceNamesClient.DeprecatedPatternMethodAsync</c>
        /// .
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings DeprecatedPatternMethodSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>ResourceNamesClient.WildcardOnlyPatternMethod</c> and
        /// <c>ResourceNamesClient.WildcardOnlyPatternMethodAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings WildcardOnlyPatternMethodSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>ResourceNamesClient.WildcardMultiPatternMethod</c> and
        /// <c>ResourceNamesClient.WildcardMultiPatternMethodAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings WildcardMultiPatternMethodSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>ResourceNamesClient.WildcardMultiPatternMultipleMethod</c> and
        /// <c>ResourceNamesClient.WildcardMultiPatternMultipleMethodAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings WildcardMultiPatternMultipleMethodSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>
        /// <see cref="gaxgrpc::CallSettings"/> for synchronous and asynchronous calls to
        /// <c>ResourceNamesClient.LooseValidationPatternMethod</c> and
        /// <c>ResourceNamesClient.LooseValidationPatternMethodAsync</c>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>This call will not be retried.</description></item>
        /// <item><description>No timeout is applied.</description></item>
        /// </list>
        /// </remarks>
        public gaxgrpc::CallSettings LooseValidationPatternMethodSettings { get; set; } = gaxgrpc::CallSettings.FromExpiration(gax::Expiration.None);

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="ResourceNamesSettings"/> object.</returns>
        public ResourceNamesSettings Clone() => new ResourceNamesSettings(this);
    }

    /// <summary>
    /// Builder class for <see cref="ResourceNamesClient"/> to provide simple configuration of credentials, endpoint
    /// etc.
    /// </summary>
    public sealed partial class ResourceNamesClientBuilder : gaxgrpc::ClientBuilderBase<ResourceNamesClient>
    {
        /// <summary>The settings to use for RPCs, or <c>null</c> for the default settings.</summary>
        public ResourceNamesSettings Settings { get; set; }

        /// <summary>Creates a new builder with default settings.</summary>
        public ResourceNamesClientBuilder()
        {
            UseJwtAccessWithScopes = ResourceNamesClient.UseJwtAccessWithScopes;
        }

        partial void InterceptBuild(ref ResourceNamesClient client);

        partial void InterceptBuildAsync(st::CancellationToken cancellationToken, ref stt::Task<ResourceNamesClient> task);

        /// <summary>Builds the resulting client.</summary>
        public override ResourceNamesClient Build()
        {
            ResourceNamesClient client = null;
            InterceptBuild(ref client);
            return client ?? BuildImpl();
        }

        /// <summary>Builds the resulting client asynchronously.</summary>
        public override stt::Task<ResourceNamesClient> BuildAsync(st::CancellationToken cancellationToken = default)
        {
            stt::Task<ResourceNamesClient> task = null;
            InterceptBuildAsync(cancellationToken, ref task);
            return task ?? BuildAsyncImpl(cancellationToken);
        }

        private ResourceNamesClient BuildImpl()
        {
            Validate();
            grpccore::CallInvoker callInvoker = CreateCallInvoker();
            return ResourceNamesClient.Create(callInvoker, Settings);
        }

        private async stt::Task<ResourceNamesClient> BuildAsyncImpl(st::CancellationToken cancellationToken)
        {
            Validate();
            grpccore::CallInvoker callInvoker = await CreateCallInvokerAsync(cancellationToken).ConfigureAwait(false);
            return ResourceNamesClient.Create(callInvoker, Settings);
        }

        /// <summary>Returns the endpoint for this builder type, used if no endpoint is otherwise specified.</summary>
        protected override string GetDefaultEndpoint() => ResourceNamesClient.DefaultEndpoint;

        /// <summary>
        /// Returns the default scopes for this builder type, used if no scopes are otherwise specified.
        /// </summary>
        protected override scg::IReadOnlyList<string> GetDefaultScopes() => ResourceNamesClient.DefaultScopes;

        /// <summary>Returns the channel pool to use when no other options are specified.</summary>
        protected override gaxgrpc::ChannelPool GetChannelPool() => ResourceNamesClient.ChannelPool;

        /// <summary>Returns the default <see cref="gaxgrpc::GrpcAdapter"/>to use if not otherwise specified.</summary>
        protected override gaxgrpc::GrpcAdapter DefaultGrpcAdapter => gaxgrpccore::GrpcCoreAdapter.Instance;
    }

    /// <summary>ResourceNames client wrapper, for convenient use.</summary>
    /// <remarks>
    /// </remarks>
    public abstract partial class ResourceNamesClient
    {
        /// <summary>
        /// The default endpoint for the ResourceNames service, which is a host of "" and a port of 443.
        /// </summary>
        public static string DefaultEndpoint { get; } = ":443";

        /// <summary>The default ResourceNames scopes.</summary>
        /// <remarks>The default ResourceNames scopes are:<list type="bullet"></list></remarks>
        public static scg::IReadOnlyList<string> DefaultScopes { get; } = new sco::ReadOnlyCollection<string>(new string[] { });

        internal static gaxgrpc::ChannelPool ChannelPool { get; } = new gaxgrpc::ChannelPool(DefaultScopes, UseJwtAccessWithScopes);

        internal static bool UseJwtAccessWithScopes
        {
            get
            {
                bool useJwtAccessWithScopes = true;
                MaybeUseJwtAccessWithScopes(ref useJwtAccessWithScopes);
                return useJwtAccessWithScopes;
            }
        }

        static partial void MaybeUseJwtAccessWithScopes(ref bool useJwtAccessWithScopes);

        /// <summary>
        /// Asynchronously creates a <see cref="ResourceNamesClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="ResourceNamesClientBuilder"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="st::CancellationToken"/> to use while creating the client.
        /// </param>
        /// <returns>The task representing the created <see cref="ResourceNamesClient"/>.</returns>
        public static stt::Task<ResourceNamesClient> CreateAsync(st::CancellationToken cancellationToken = default) =>
            new ResourceNamesClientBuilder().BuildAsync(cancellationToken);

        /// <summary>
        /// Synchronously creates a <see cref="ResourceNamesClient"/> using the default credentials, endpoint and
        /// settings. To specify custom credentials or other settings, use <see cref="ResourceNamesClientBuilder"/>.
        /// </summary>
        /// <returns>The created <see cref="ResourceNamesClient"/>.</returns>
        public static ResourceNamesClient Create() => new ResourceNamesClientBuilder().Build();

        /// <summary>
        /// Creates a <see cref="ResourceNamesClient"/> which uses the specified call invoker for remote operations.
        /// </summary>
        /// <param name="callInvoker">
        /// The <see cref="grpccore::CallInvoker"/> for remote operations. Must not be null.
        /// </param>
        /// <param name="settings">Optional <see cref="ResourceNamesSettings"/>.</param>
        /// <returns>The created <see cref="ResourceNamesClient"/>.</returns>
        internal static ResourceNamesClient Create(grpccore::CallInvoker callInvoker, ResourceNamesSettings settings = null)
        {
            gax::GaxPreconditions.CheckNotNull(callInvoker, nameof(callInvoker));
            grpcinter::Interceptor interceptor = settings?.Interceptor;
            if (interceptor != null)
            {
                callInvoker = grpcinter::CallInvokerExtensions.Intercept(callInvoker, interceptor);
            }
            ResourceNames.ResourceNamesClient grpcClient = new ResourceNames.ResourceNamesClient(callInvoker);
            return new ResourceNamesClientImpl(grpcClient, settings);
        }

        /// <summary>
        /// Shuts down any channels automatically created by <see cref="Create()"/> and
        /// <see cref="CreateAsync(st::CancellationToken)"/>. Channels which weren't automatically created are not
        /// affected.
        /// </summary>
        /// <remarks>
        /// After calling this method, further calls to <see cref="Create()"/> and
        /// <see cref="CreateAsync(st::CancellationToken)"/> will create new channels, which could in turn be shut down
        /// by another call to this method.
        /// </remarks>
        /// <returns>A task representing the asynchronous shutdown operation.</returns>
        public static stt::Task ShutdownDefaultChannelsAsync() => ChannelPool.ShutdownChannelsAsync();

        /// <summary>The underlying gRPC ResourceNames client</summary>
        public virtual ResourceNames.ResourceNamesClient GrpcClient => throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response SinglePatternMethod(SinglePattern request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SinglePatternMethodAsync(SinglePattern request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SinglePatternMethodAsync(SinglePattern request, st::CancellationToken cancellationToken) =>
            SinglePatternMethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="realName">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="valueRef">
        /// </param>
        /// <param name="repeatedValueRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response SinglePatternMethod(string realName, string @ref, scg::IEnumerable<string> repeatedRef, string valueRef, scg::IEnumerable<string> repeatedValueRef, gaxgrpc::CallSettings callSettings = null) =>
            SinglePatternMethod(new SinglePattern
            {
                RealName = realName ?? "",
                Ref = @ref ?? "",
                RepeatedRef =
                {
                    repeatedRef ?? linq::Enumerable.Empty<string>(),
                },
                ValueRef = valueRef,
                RepeatedValueRef =
                {
                    repeatedValueRef ?? linq::Enumerable.Empty<string>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="realName">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="valueRef">
        /// </param>
        /// <param name="repeatedValueRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SinglePatternMethodAsync(string realName, string @ref, scg::IEnumerable<string> repeatedRef, string valueRef, scg::IEnumerable<string> repeatedValueRef, gaxgrpc::CallSettings callSettings = null) =>
            SinglePatternMethodAsync(new SinglePattern
            {
                RealName = realName ?? "",
                Ref = @ref ?? "",
                RepeatedRef =
                {
                    repeatedRef ?? linq::Enumerable.Empty<string>(),
                },
                ValueRef = valueRef,
                RepeatedValueRef =
                {
                    repeatedValueRef ?? linq::Enumerable.Empty<string>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="realName">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="valueRef">
        /// </param>
        /// <param name="repeatedValueRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SinglePatternMethodAsync(string realName, string @ref, scg::IEnumerable<string> repeatedRef, string valueRef, scg::IEnumerable<string> repeatedValueRef, st::CancellationToken cancellationToken) =>
            SinglePatternMethodAsync(realName, @ref, repeatedRef, valueRef, repeatedValueRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="realName">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="valueRef">
        /// </param>
        /// <param name="repeatedValueRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response SinglePatternMethod(SinglePatternName realName, SinglePatternName @ref, scg::IEnumerable<SinglePatternName> repeatedRef, SinglePatternName valueRef, scg::IEnumerable<SinglePatternName> repeatedValueRef, gaxgrpc::CallSettings callSettings = null) =>
            SinglePatternMethod(new SinglePattern
            {
                RealNameAsSinglePatternName = realName,
                RefAsSinglePatternName = @ref,
                RepeatedRefAsSinglePatternNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<SinglePatternName>(),
                },
                ValueRefAsSinglePatternName = valueRef,
                RepeatedValueRefAsSinglePatternNames =
                {
                    repeatedValueRef ?? linq::Enumerable.Empty<SinglePatternName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="realName">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="valueRef">
        /// </param>
        /// <param name="repeatedValueRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SinglePatternMethodAsync(SinglePatternName realName, SinglePatternName @ref, scg::IEnumerable<SinglePatternName> repeatedRef, SinglePatternName valueRef, scg::IEnumerable<SinglePatternName> repeatedValueRef, gaxgrpc::CallSettings callSettings = null) =>
            SinglePatternMethodAsync(new SinglePattern
            {
                RealNameAsSinglePatternName = realName,
                RefAsSinglePatternName = @ref,
                RepeatedRefAsSinglePatternNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<SinglePatternName>(),
                },
                ValueRefAsSinglePatternName = valueRef,
                RepeatedValueRefAsSinglePatternNames =
                {
                    repeatedValueRef ?? linq::Enumerable.Empty<SinglePatternName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="realName">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="valueRef">
        /// </param>
        /// <param name="repeatedValueRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SinglePatternMethodAsync(SinglePatternName realName, SinglePatternName @ref, scg::IEnumerable<SinglePatternName> repeatedRef, SinglePatternName valueRef, scg::IEnumerable<SinglePatternName> repeatedValueRef, st::CancellationToken cancellationToken) =>
            SinglePatternMethodAsync(realName, @ref, repeatedRef, valueRef, repeatedValueRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response DeprecatedPatternMethod(DeprecatedPattern request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> DeprecatedPatternMethodAsync(DeprecatedPattern request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> DeprecatedPatternMethodAsync(DeprecatedPattern request, st::CancellationToken cancellationToken) =>
            DeprecatedPatternMethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        [sys::ObsoleteAttribute]
        public virtual Response DeprecatedPatternMethod(string name, gaxgrpc::CallSettings callSettings = null) =>
            DeprecatedPatternMethod(new DeprecatedPattern { Name = name ?? "", }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        [sys::ObsoleteAttribute]
        public virtual stt::Task<Response> DeprecatedPatternMethodAsync(string name, gaxgrpc::CallSettings callSettings = null) =>
            DeprecatedPatternMethodAsync(new DeprecatedPattern { Name = name ?? "", }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        [sys::ObsoleteAttribute]
        public virtual stt::Task<Response> DeprecatedPatternMethodAsync(string name, st::CancellationToken cancellationToken) =>
            DeprecatedPatternMethodAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        [sys::ObsoleteAttribute]
        public virtual Response DeprecatedPatternMethod(DeprecatedPatternName name, gaxgrpc::CallSettings callSettings = null) =>
            DeprecatedPatternMethod(new DeprecatedPattern
            {
                DeprecatedPatternName = name,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        [sys::ObsoleteAttribute]
        public virtual stt::Task<Response> DeprecatedPatternMethodAsync(DeprecatedPatternName name, gaxgrpc::CallSettings callSettings = null) =>
            DeprecatedPatternMethodAsync(new DeprecatedPattern
            {
                DeprecatedPatternName = name,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        [sys::ObsoleteAttribute]
        public virtual stt::Task<Response> DeprecatedPatternMethodAsync(DeprecatedPatternName name, st::CancellationToken cancellationToken) =>
            DeprecatedPatternMethodAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardOnlyPatternMethod(WildcardOnlyPattern request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardOnlyPatternMethodAsync(WildcardOnlyPattern request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardOnlyPatternMethodAsync(WildcardOnlyPattern request, st::CancellationToken cancellationToken) =>
            WildcardOnlyPatternMethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="refSugar">
        /// </param>
        /// <param name="repeatedRefSugar">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardOnlyPatternMethod(string name, string @ref, scg::IEnumerable<string> repeatedRef, string refSugar, scg::IEnumerable<string> repeatedRefSugar, gaxgrpc::CallSettings callSettings = null) =>
            WildcardOnlyPatternMethod(new WildcardOnlyPattern
            {
                Name = name ?? "",
                Ref = @ref ?? "",
                RepeatedRef =
                {
                    repeatedRef ?? linq::Enumerable.Empty<string>(),
                },
                RefSugar = refSugar ?? "",
                RepeatedRefSugar =
                {
                    repeatedRefSugar ?? linq::Enumerable.Empty<string>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="refSugar">
        /// </param>
        /// <param name="repeatedRefSugar">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardOnlyPatternMethodAsync(string name, string @ref, scg::IEnumerable<string> repeatedRef, string refSugar, scg::IEnumerable<string> repeatedRefSugar, gaxgrpc::CallSettings callSettings = null) =>
            WildcardOnlyPatternMethodAsync(new WildcardOnlyPattern
            {
                Name = name ?? "",
                Ref = @ref ?? "",
                RepeatedRef =
                {
                    repeatedRef ?? linq::Enumerable.Empty<string>(),
                },
                RefSugar = refSugar ?? "",
                RepeatedRefSugar =
                {
                    repeatedRefSugar ?? linq::Enumerable.Empty<string>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="refSugar">
        /// </param>
        /// <param name="repeatedRefSugar">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardOnlyPatternMethodAsync(string name, string @ref, scg::IEnumerable<string> repeatedRef, string refSugar, scg::IEnumerable<string> repeatedRefSugar, st::CancellationToken cancellationToken) =>
            WildcardOnlyPatternMethodAsync(name, @ref, repeatedRef, refSugar, repeatedRefSugar, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="refSugar">
        /// </param>
        /// <param name="repeatedRefSugar">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardOnlyPatternMethod(gax::IResourceName name, gax::IResourceName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gax::IResourceName refSugar, scg::IEnumerable<gax::IResourceName> repeatedRefSugar, gaxgrpc::CallSettings callSettings = null) =>
            WildcardOnlyPatternMethod(new WildcardOnlyPattern
            {
                ResourceName = name,
                RefAsResourceName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
                RefSugarAsResourceName = refSugar,
                RepeatedRefSugarAsResourceNames =
                {
                    repeatedRefSugar ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="refSugar">
        /// </param>
        /// <param name="repeatedRefSugar">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardOnlyPatternMethodAsync(gax::IResourceName name, gax::IResourceName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gax::IResourceName refSugar, scg::IEnumerable<gax::IResourceName> repeatedRefSugar, gaxgrpc::CallSettings callSettings = null) =>
            WildcardOnlyPatternMethodAsync(new WildcardOnlyPattern
            {
                ResourceName = name,
                RefAsResourceName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
                RefSugarAsResourceName = refSugar,
                RepeatedRefSugarAsResourceNames =
                {
                    repeatedRefSugar ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="refSugar">
        /// </param>
        /// <param name="repeatedRefSugar">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardOnlyPatternMethodAsync(gax::IResourceName name, gax::IResourceName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gax::IResourceName refSugar, scg::IEnumerable<gax::IResourceName> repeatedRefSugar, st::CancellationToken cancellationToken) =>
            WildcardOnlyPatternMethodAsync(name, @ref, repeatedRef, refSugar, repeatedRefSugar, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardMultiPatternMethod(WildcardMultiPattern request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(WildcardMultiPattern request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(WildcardMultiPattern request, st::CancellationToken cancellationToken) =>
            WildcardMultiPatternMethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardMultiPatternMethod(string name, string @ref, scg::IEnumerable<string> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMethod(new WildcardMultiPattern
            {
                Name = name ?? "",
                Ref = @ref ?? "",
                RepeatedRef =
                {
                    repeatedRef ?? linq::Enumerable.Empty<string>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(string name, string @ref, scg::IEnumerable<string> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMethodAsync(new WildcardMultiPattern
            {
                Name = name ?? "",
                Ref = @ref ?? "",
                RepeatedRef =
                {
                    repeatedRef ?? linq::Enumerable.Empty<string>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(string name, string @ref, scg::IEnumerable<string> repeatedRef, st::CancellationToken cancellationToken) =>
            WildcardMultiPatternMethodAsync(name, @ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardMultiPatternMethod(WildcardMultiPatternName name, WildcardMultiPatternName @ref, scg::IEnumerable<WildcardMultiPatternName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMethod(new WildcardMultiPattern
            {
                WildcardMultiPatternName = name,
                RefAsWildcardMultiPatternName = @ref,
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<WildcardMultiPatternName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(WildcardMultiPatternName name, WildcardMultiPatternName @ref, scg::IEnumerable<WildcardMultiPatternName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMethodAsync(new WildcardMultiPattern
            {
                WildcardMultiPatternName = name,
                RefAsWildcardMultiPatternName = @ref,
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<WildcardMultiPatternName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(WildcardMultiPatternName name, WildcardMultiPatternName @ref, scg::IEnumerable<WildcardMultiPatternName> repeatedRef, st::CancellationToken cancellationToken) =>
            WildcardMultiPatternMethodAsync(name, @ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardMultiPatternMethod(WildcardMultiPatternName name, WildcardMultiPatternName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMethod(new WildcardMultiPattern
            {
                WildcardMultiPatternName = name,
                RefAsWildcardMultiPatternName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(WildcardMultiPatternName name, WildcardMultiPatternName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMethodAsync(new WildcardMultiPattern
            {
                WildcardMultiPatternName = name,
                RefAsWildcardMultiPatternName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(WildcardMultiPatternName name, WildcardMultiPatternName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, st::CancellationToken cancellationToken) =>
            WildcardMultiPatternMethodAsync(name, @ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardMultiPatternMethod(WildcardMultiPatternName name, gax::IResourceName @ref, scg::IEnumerable<WildcardMultiPatternName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMethod(new WildcardMultiPattern
            {
                WildcardMultiPatternName = name,
                RefAsResourceName = @ref,
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<WildcardMultiPatternName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(WildcardMultiPatternName name, gax::IResourceName @ref, scg::IEnumerable<WildcardMultiPatternName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMethodAsync(new WildcardMultiPattern
            {
                WildcardMultiPatternName = name,
                RefAsResourceName = @ref,
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<WildcardMultiPatternName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(WildcardMultiPatternName name, gax::IResourceName @ref, scg::IEnumerable<WildcardMultiPatternName> repeatedRef, st::CancellationToken cancellationToken) =>
            WildcardMultiPatternMethodAsync(name, @ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardMultiPatternMethod(WildcardMultiPatternName name, gax::IResourceName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMethod(new WildcardMultiPattern
            {
                WildcardMultiPatternName = name,
                RefAsResourceName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(WildcardMultiPatternName name, gax::IResourceName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMethodAsync(new WildcardMultiPattern
            {
                WildcardMultiPatternName = name,
                RefAsResourceName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(WildcardMultiPatternName name, gax::IResourceName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, st::CancellationToken cancellationToken) =>
            WildcardMultiPatternMethodAsync(name, @ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardMultiPatternMethod(gax::IResourceName name, WildcardMultiPatternName @ref, scg::IEnumerable<WildcardMultiPatternName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMethod(new WildcardMultiPattern
            {
                ResourceName = name,
                RefAsWildcardMultiPatternName = @ref,
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<WildcardMultiPatternName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(gax::IResourceName name, WildcardMultiPatternName @ref, scg::IEnumerable<WildcardMultiPatternName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMethodAsync(new WildcardMultiPattern
            {
                ResourceName = name,
                RefAsWildcardMultiPatternName = @ref,
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<WildcardMultiPatternName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(gax::IResourceName name, WildcardMultiPatternName @ref, scg::IEnumerable<WildcardMultiPatternName> repeatedRef, st::CancellationToken cancellationToken) =>
            WildcardMultiPatternMethodAsync(name, @ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardMultiPatternMethod(gax::IResourceName name, WildcardMultiPatternName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMethod(new WildcardMultiPattern
            {
                ResourceName = name,
                RefAsWildcardMultiPatternName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(gax::IResourceName name, WildcardMultiPatternName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMethodAsync(new WildcardMultiPattern
            {
                ResourceName = name,
                RefAsWildcardMultiPatternName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(gax::IResourceName name, WildcardMultiPatternName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, st::CancellationToken cancellationToken) =>
            WildcardMultiPatternMethodAsync(name, @ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardMultiPatternMethod(gax::IResourceName name, gax::IResourceName @ref, scg::IEnumerable<WildcardMultiPatternName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMethod(new WildcardMultiPattern
            {
                ResourceName = name,
                RefAsResourceName = @ref,
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<WildcardMultiPatternName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(gax::IResourceName name, gax::IResourceName @ref, scg::IEnumerable<WildcardMultiPatternName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMethodAsync(new WildcardMultiPattern
            {
                ResourceName = name,
                RefAsResourceName = @ref,
                RepeatedRefAsWildcardMultiPatternNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<WildcardMultiPatternName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(gax::IResourceName name, gax::IResourceName @ref, scg::IEnumerable<WildcardMultiPatternName> repeatedRef, st::CancellationToken cancellationToken) =>
            WildcardMultiPatternMethodAsync(name, @ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardMultiPatternMethod(gax::IResourceName name, gax::IResourceName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMethod(new WildcardMultiPattern
            {
                ResourceName = name,
                RefAsResourceName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(gax::IResourceName name, gax::IResourceName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMethodAsync(new WildcardMultiPattern
            {
                ResourceName = name,
                RefAsResourceName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMethodAsync(gax::IResourceName name, gax::IResourceName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, st::CancellationToken cancellationToken) =>
            WildcardMultiPatternMethodAsync(name, @ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardMultiPatternMultipleMethod(WildcardMultiPatternMultiple request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMultipleMethodAsync(WildcardMultiPatternMultiple request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMultipleMethodAsync(WildcardMultiPatternMultiple request, st::CancellationToken cancellationToken) =>
            WildcardMultiPatternMultipleMethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardMultiPatternMultipleMethod(string @ref, scg::IEnumerable<string> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMultipleMethod(new WildcardMultiPatternMultiple
            {
                Ref = @ref ?? "",
                RepeatedRef =
                {
                    repeatedRef ?? linq::Enumerable.Empty<string>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMultipleMethodAsync(string @ref, scg::IEnumerable<string> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMultipleMethodAsync(new WildcardMultiPatternMultiple
            {
                Ref = @ref ?? "",
                RepeatedRef =
                {
                    repeatedRef ?? linq::Enumerable.Empty<string>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMultipleMethodAsync(string @ref, scg::IEnumerable<string> repeatedRef, st::CancellationToken cancellationToken) =>
            WildcardMultiPatternMultipleMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardMultiPatternMultipleMethod(WildcardMultiPatternMultipleName @ref, scg::IEnumerable<WildcardMultiPatternMultipleName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMultipleMethod(new WildcardMultiPatternMultiple
            {
                RefAsWildcardMultiPatternMultipleName = @ref,
                RepeatedRefAsWildcardMultiPatternMultipleNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<WildcardMultiPatternMultipleName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMultipleMethodAsync(WildcardMultiPatternMultipleName @ref, scg::IEnumerable<WildcardMultiPatternMultipleName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMultipleMethodAsync(new WildcardMultiPatternMultiple
            {
                RefAsWildcardMultiPatternMultipleName = @ref,
                RepeatedRefAsWildcardMultiPatternMultipleNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<WildcardMultiPatternMultipleName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMultipleMethodAsync(WildcardMultiPatternMultipleName @ref, scg::IEnumerable<WildcardMultiPatternMultipleName> repeatedRef, st::CancellationToken cancellationToken) =>
            WildcardMultiPatternMultipleMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardMultiPatternMultipleMethod(WildcardMultiPatternMultipleName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMultipleMethod(new WildcardMultiPatternMultiple
            {
                RefAsWildcardMultiPatternMultipleName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMultipleMethodAsync(WildcardMultiPatternMultipleName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMultipleMethodAsync(new WildcardMultiPatternMultiple
            {
                RefAsWildcardMultiPatternMultipleName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMultipleMethodAsync(WildcardMultiPatternMultipleName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, st::CancellationToken cancellationToken) =>
            WildcardMultiPatternMultipleMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardMultiPatternMultipleMethod(gax::IResourceName @ref, scg::IEnumerable<WildcardMultiPatternMultipleName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMultipleMethod(new WildcardMultiPatternMultiple
            {
                RefAsResourceName = @ref,
                RepeatedRefAsWildcardMultiPatternMultipleNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<WildcardMultiPatternMultipleName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMultipleMethodAsync(gax::IResourceName @ref, scg::IEnumerable<WildcardMultiPatternMultipleName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMultipleMethodAsync(new WildcardMultiPatternMultiple
            {
                RefAsResourceName = @ref,
                RepeatedRefAsWildcardMultiPatternMultipleNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<WildcardMultiPatternMultipleName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMultipleMethodAsync(gax::IResourceName @ref, scg::IEnumerable<WildcardMultiPatternMultipleName> repeatedRef, st::CancellationToken cancellationToken) =>
            WildcardMultiPatternMultipleMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response WildcardMultiPatternMultipleMethod(gax::IResourceName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMultipleMethod(new WildcardMultiPatternMultiple
            {
                RefAsResourceName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMultipleMethodAsync(gax::IResourceName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, gaxgrpc::CallSettings callSettings = null) =>
            WildcardMultiPatternMultipleMethodAsync(new WildcardMultiPatternMultiple
            {
                RefAsResourceName = @ref,
                RepeatedRefAsResourceNames =
                {
                    repeatedRef ?? linq::Enumerable.Empty<gax::IResourceName>(),
                },
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="ref">
        /// </param>
        /// <param name="repeatedRef">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> WildcardMultiPatternMultipleMethodAsync(gax::IResourceName @ref, scg::IEnumerable<gax::IResourceName> repeatedRef, st::CancellationToken cancellationToken) =>
            WildcardMultiPatternMultipleMethodAsync(@ref, repeatedRef, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response LooseValidationPatternMethod(LooseValidationPattern request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> LooseValidationPatternMethodAsync(LooseValidationPattern request, gaxgrpc::CallSettings callSettings = null) =>
            throw new sys::NotImplementedException();

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> LooseValidationPatternMethodAsync(LooseValidationPattern request, st::CancellationToken cancellationToken) =>
            LooseValidationPatternMethodAsync(request, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response LooseValidationPatternMethod(string name, gaxgrpc::CallSettings callSettings = null) =>
            LooseValidationPatternMethod(new LooseValidationPattern { Name = name ?? "", }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> LooseValidationPatternMethodAsync(string name, gaxgrpc::CallSettings callSettings = null) =>
            LooseValidationPatternMethodAsync(new LooseValidationPattern { Name = name ?? "", }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> LooseValidationPatternMethodAsync(string name, st::CancellationToken cancellationToken) =>
            LooseValidationPatternMethodAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response LooseValidationPatternMethod(LooseValidationPatternName name, gaxgrpc::CallSettings callSettings = null) =>
            LooseValidationPatternMethod(new LooseValidationPattern
            {
                LooseValidationPatternName = name,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> LooseValidationPatternMethodAsync(LooseValidationPatternName name, gaxgrpc::CallSettings callSettings = null) =>
            LooseValidationPatternMethodAsync(new LooseValidationPattern
            {
                LooseValidationPatternName = name,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> LooseValidationPatternMethodAsync(LooseValidationPatternName name, st::CancellationToken cancellationToken) =>
            LooseValidationPatternMethodAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
    }

    /// <summary>ResourceNames client wrapper implementation, for convenient use.</summary>
    /// <remarks>
    /// </remarks>
    public sealed partial class ResourceNamesClientImpl : ResourceNamesClient
    {
        private readonly gaxgrpc::ApiCall<SinglePattern, Response> _callSinglePatternMethod;

        private readonly gaxgrpc::ApiCall<DeprecatedPattern, Response> _callDeprecatedPatternMethod;

        private readonly gaxgrpc::ApiCall<WildcardOnlyPattern, Response> _callWildcardOnlyPatternMethod;

        private readonly gaxgrpc::ApiCall<WildcardMultiPattern, Response> _callWildcardMultiPatternMethod;

        private readonly gaxgrpc::ApiCall<WildcardMultiPatternMultiple, Response> _callWildcardMultiPatternMultipleMethod;

        private readonly gaxgrpc::ApiCall<LooseValidationPattern, Response> _callLooseValidationPatternMethod;

        /// <summary>
        /// Constructs a client wrapper for the ResourceNames service, with the specified gRPC client and settings.
        /// </summary>
        /// <param name="grpcClient">The underlying gRPC client.</param>
        /// <param name="settings">The base <see cref="ResourceNamesSettings"/> used within this client.</param>
        public ResourceNamesClientImpl(ResourceNames.ResourceNamesClient grpcClient, ResourceNamesSettings settings)
        {
            GrpcClient = grpcClient;
            ResourceNamesSettings effectiveSettings = settings ?? ResourceNamesSettings.GetDefault();
            gaxgrpc::ClientHelper clientHelper = new gaxgrpc::ClientHelper(effectiveSettings);
            _callSinglePatternMethod = clientHelper.BuildApiCall<SinglePattern, Response>(grpcClient.SinglePatternMethodAsync, grpcClient.SinglePatternMethod, effectiveSettings.SinglePatternMethodSettings);
            Modify_ApiCall(ref _callSinglePatternMethod);
            Modify_SinglePatternMethodApiCall(ref _callSinglePatternMethod);
            _callDeprecatedPatternMethod = clientHelper.BuildApiCall<DeprecatedPattern, Response>(grpcClient.DeprecatedPatternMethodAsync, grpcClient.DeprecatedPatternMethod, effectiveSettings.DeprecatedPatternMethodSettings);
            Modify_ApiCall(ref _callDeprecatedPatternMethod);
            Modify_DeprecatedPatternMethodApiCall(ref _callDeprecatedPatternMethod);
            _callWildcardOnlyPatternMethod = clientHelper.BuildApiCall<WildcardOnlyPattern, Response>(grpcClient.WildcardOnlyPatternMethodAsync, grpcClient.WildcardOnlyPatternMethod, effectiveSettings.WildcardOnlyPatternMethodSettings);
            Modify_ApiCall(ref _callWildcardOnlyPatternMethod);
            Modify_WildcardOnlyPatternMethodApiCall(ref _callWildcardOnlyPatternMethod);
            _callWildcardMultiPatternMethod = clientHelper.BuildApiCall<WildcardMultiPattern, Response>(grpcClient.WildcardMultiPatternMethodAsync, grpcClient.WildcardMultiPatternMethod, effectiveSettings.WildcardMultiPatternMethodSettings);
            Modify_ApiCall(ref _callWildcardMultiPatternMethod);
            Modify_WildcardMultiPatternMethodApiCall(ref _callWildcardMultiPatternMethod);
            _callWildcardMultiPatternMultipleMethod = clientHelper.BuildApiCall<WildcardMultiPatternMultiple, Response>(grpcClient.WildcardMultiPatternMultipleMethodAsync, grpcClient.WildcardMultiPatternMultipleMethod, effectiveSettings.WildcardMultiPatternMultipleMethodSettings);
            Modify_ApiCall(ref _callWildcardMultiPatternMultipleMethod);
            Modify_WildcardMultiPatternMultipleMethodApiCall(ref _callWildcardMultiPatternMultipleMethod);
            _callLooseValidationPatternMethod = clientHelper.BuildApiCall<LooseValidationPattern, Response>(grpcClient.LooseValidationPatternMethodAsync, grpcClient.LooseValidationPatternMethod, effectiveSettings.LooseValidationPatternMethodSettings);
            Modify_ApiCall(ref _callLooseValidationPatternMethod);
            Modify_LooseValidationPatternMethodApiCall(ref _callLooseValidationPatternMethod);
            OnConstruction(grpcClient, effectiveSettings, clientHelper);
        }

        partial void Modify_ApiCall<TRequest, TResponse>(ref gaxgrpc::ApiCall<TRequest, TResponse> call) where TRequest : class, proto::IMessage<TRequest> where TResponse : class, proto::IMessage<TResponse>;

        partial void Modify_SinglePatternMethodApiCall(ref gaxgrpc::ApiCall<SinglePattern, Response> call);

        partial void Modify_DeprecatedPatternMethodApiCall(ref gaxgrpc::ApiCall<DeprecatedPattern, Response> call);

        partial void Modify_WildcardOnlyPatternMethodApiCall(ref gaxgrpc::ApiCall<WildcardOnlyPattern, Response> call);

        partial void Modify_WildcardMultiPatternMethodApiCall(ref gaxgrpc::ApiCall<WildcardMultiPattern, Response> call);

        partial void Modify_WildcardMultiPatternMultipleMethodApiCall(ref gaxgrpc::ApiCall<WildcardMultiPatternMultiple, Response> call);

        partial void Modify_LooseValidationPatternMethodApiCall(ref gaxgrpc::ApiCall<LooseValidationPattern, Response> call);

        partial void OnConstruction(ResourceNames.ResourceNamesClient grpcClient, ResourceNamesSettings effectiveSettings, gaxgrpc::ClientHelper clientHelper);

        /// <summary>The underlying gRPC ResourceNames client</summary>
        public override ResourceNames.ResourceNamesClient GrpcClient { get; }

        partial void Modify_SinglePattern(ref SinglePattern request, ref gaxgrpc::CallSettings settings);

        partial void Modify_DeprecatedPattern(ref DeprecatedPattern request, ref gaxgrpc::CallSettings settings);

        partial void Modify_WildcardOnlyPattern(ref WildcardOnlyPattern request, ref gaxgrpc::CallSettings settings);

        partial void Modify_WildcardMultiPattern(ref WildcardMultiPattern request, ref gaxgrpc::CallSettings settings);

        partial void Modify_WildcardMultiPatternMultiple(ref WildcardMultiPatternMultiple request, ref gaxgrpc::CallSettings settings);

        partial void Modify_LooseValidationPattern(ref LooseValidationPattern request, ref gaxgrpc::CallSettings settings);

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Response SinglePatternMethod(SinglePattern request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_SinglePattern(ref request, ref callSettings);
            return _callSinglePatternMethod.Sync(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Response> SinglePatternMethodAsync(SinglePattern request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_SinglePattern(ref request, ref callSettings);
            return _callSinglePatternMethod.Async(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Response DeprecatedPatternMethod(DeprecatedPattern request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeprecatedPattern(ref request, ref callSettings);
            return _callDeprecatedPatternMethod.Sync(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Response> DeprecatedPatternMethodAsync(DeprecatedPattern request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_DeprecatedPattern(ref request, ref callSettings);
            return _callDeprecatedPatternMethod.Async(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Response WildcardOnlyPatternMethod(WildcardOnlyPattern request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_WildcardOnlyPattern(ref request, ref callSettings);
            return _callWildcardOnlyPatternMethod.Sync(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Response> WildcardOnlyPatternMethodAsync(WildcardOnlyPattern request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_WildcardOnlyPattern(ref request, ref callSettings);
            return _callWildcardOnlyPatternMethod.Async(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Response WildcardMultiPatternMethod(WildcardMultiPattern request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_WildcardMultiPattern(ref request, ref callSettings);
            return _callWildcardMultiPatternMethod.Sync(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Response> WildcardMultiPatternMethodAsync(WildcardMultiPattern request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_WildcardMultiPattern(ref request, ref callSettings);
            return _callWildcardMultiPatternMethod.Async(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Response WildcardMultiPatternMultipleMethod(WildcardMultiPatternMultiple request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_WildcardMultiPatternMultiple(ref request, ref callSettings);
            return _callWildcardMultiPatternMultipleMethod.Sync(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Response> WildcardMultiPatternMultipleMethodAsync(WildcardMultiPatternMultiple request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_WildcardMultiPatternMultiple(ref request, ref callSettings);
            return _callWildcardMultiPatternMultipleMethod.Async(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public override Response LooseValidationPatternMethod(LooseValidationPattern request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_LooseValidationPattern(ref request, ref callSettings);
            return _callLooseValidationPatternMethod.Sync(request, callSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">The request object containing all of the parameters for the API call.</param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public override stt::Task<Response> LooseValidationPatternMethodAsync(LooseValidationPattern request, gaxgrpc::CallSettings callSettings = null)
        {
            Modify_LooseValidationPattern(ref request, ref callSettings);
            return _callLooseValidationPatternMethod.Async(request, callSettings);
        }
    }
}
