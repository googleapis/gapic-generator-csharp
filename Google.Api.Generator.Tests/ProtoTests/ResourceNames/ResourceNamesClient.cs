using gax = Google.Api.Gax;
using gaxgrpc = Google.Api.Gax.Grpc;
using linq = System.Linq;
using proto = Google.Protobuf;
using scg = System.Collections.Generic;
using st = System.Threading;
using stt = System.Threading.Tasks;
using sys = System;

namespace Testing.Resourcenames
{
    public abstract class ResourceNamesClient
    {
        public Response SimpleMethod(SimpleResource request, gaxgrpc::CallSettings callSettings) => throw new sys::NotImplementedException();
        public stt::Task<Response> SimpleMethodAsync(SimpleResource request, gaxgrpc::CallSettings callSettings) => throw new sys::NotImplementedException();

        // TEST_START
        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response SimpleMethod(string name, gaxgrpc::CallSettings callSettings = null) =>
            SimpleMethod(new SimpleResource
            {
                Name = name ?? "",
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SimpleMethodAsync(string name, gaxgrpc::CallSettings callSettings = null) =>
            SimpleMethodAsync(new SimpleResource
            {
                Name = name ?? "",
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SimpleMethodAsync(string name, st::CancellationToken cancellationToken) =>
            SimpleMethodAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response SimpleMethod(SimpleResourceName name, gaxgrpc::CallSettings callSettings = null) =>
            SimpleMethod(new SimpleResource
            {
                NameAsSimpleResourceName = name,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SimpleMethodAsync(SimpleResourceName name, gaxgrpc::CallSettings callSettings = null) =>
            SimpleMethodAsync(new SimpleResource
            {
                NameAsSimpleResourceName = name,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SimpleMethodAsync(SimpleResourceName name, st::CancellationToken cancellationToken) =>
            SimpleMethodAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
        // TEST_END

        public Response SimpleInlineMethod(SimpleInlineResource request, gaxgrpc::CallSettings callSettings) => throw new sys::NotImplementedException();
        public stt::Task<Response> SimpleInlineMethodAsync(SimpleInlineResource request, gaxgrpc::CallSettings callSettings) => throw new sys::NotImplementedException();

        // TEST_START
        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response SimpleInlineMethod(string name, gaxgrpc::CallSettings callSettings = null) =>
            SimpleInlineMethod(new SimpleInlineResource
            {
                Name = name ?? "",
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SimpleInlineMethodAsync(string name, gaxgrpc::CallSettings callSettings = null) =>
            SimpleInlineMethodAsync(new SimpleInlineResource
            {
                Name = name ?? "",
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SimpleInlineMethodAsync(string name, st::CancellationToken cancellationToken) =>
            SimpleInlineMethodAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>The RPC response.</returns>
        public virtual Response SimpleInlineMethod(SimpleInlineResourceName name, gaxgrpc::CallSettings callSettings = null) =>
            SimpleInlineMethod(new SimpleInlineResource
            {
                NameAsSimpleInlineResourceName = name,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="callSettings">If not null, applies overrides to this RPC call.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SimpleInlineMethodAsync(SimpleInlineResourceName name, gaxgrpc::CallSettings callSettings = null) =>
            SimpleInlineMethodAsync(new SimpleInlineResource
            {
                NameAsSimpleInlineResourceName = name,
            }, callSettings);

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="cancellationToken">A <see cref="st::CancellationToken"/> to use for this RPC.</param>
        /// <returns>A Task containing the RPC response.</returns>
        public virtual stt::Task<Response> SimpleInlineMethodAsync(SimpleInlineResourceName name, st::CancellationToken cancellationToken) =>
            SimpleInlineMethodAsync(name, gaxgrpc::CallSettings.FromCancellationToken(cancellationToken));
        // TEST_END
    }
}
