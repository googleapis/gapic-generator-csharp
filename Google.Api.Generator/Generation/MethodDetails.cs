using Google.Api.Gax.Grpc;
using Google.Api.Generator.Utils;
using Google.Protobuf.Reflection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Google.Api.Generator.Generation
{
    /// <summary>
    /// Details of an RPC method within a proto-defined service.
    /// </summary>
    internal abstract class MethodDetails
    {
        /// <summary>
        /// Details about a "normal" method. I.e not paginated, streaming, LRO, ...
        /// </summary>
        public sealed class Normal : MethodDetails
        {
            public Normal(ServiceDetails svc, MethodDescriptor desc) : base(svc, desc) { }
            public override Typ SyncReturnTyp => ResponseType;
            public override Typ AsyncReturnTyp => Typ.Generic(typeof(Task<>), ResponseType);
            public override Typ ApiCallTyp => Typ.Generic(typeof(ApiCall<,>), RequestType, ResponseType);
        }

        // TODO: Nested classes for other method types: paged, streaming, LRO, ...

        public static MethodDetails Create(ServiceDetails svc, MethodDescriptor desc) =>
            // TODO: Create correct class for the method type (paged, streaming, LRO, ...)
            new Normal(svc, desc);

        private MethodDetails(ServiceDetails svc, MethodDescriptor desc)
        {
            Svc = svc;
            SyncMethodName = desc.Name;
            AsyncMethodName = $"{desc.Name}Async";
            SettingsName = $"{desc.Name}Settings";
            RequestType = Typ.Of(desc.InputType);
            ResponseType = Typ.Of(desc.OutputType);
            ApiCallFieldName = $"_call{desc.Name}";
        }

        /// <summary>
        /// The service in which this method is defined.
        /// </summary>
        public ServiceDetails Svc { get; }

        /// <summary>
        /// The sync name for this method.
        /// </summary>
        public string SyncMethodName { get; }

        /// <summary>
        /// The async name for this method.
        /// </summary>
        public string AsyncMethodName { get; }

        /// <summary>
        /// The per-method settings property name.
        /// </summary>
        public string SettingsName { get; }

        /// <summary>
        /// The typ of the method request.
        /// </summary>
        public Typ RequestType { get; }

        /// <summary>
        /// The typ of the method response.
        /// </summary>
        public Typ ResponseType { get; }

        /// <summary>
        /// The sync return typ for this method.
        /// </summary>
        public abstract Typ SyncReturnTyp { get; }

        /// <summary>
        /// The async return typ for this method.
        /// </summary>
        public abstract Typ AsyncReturnTyp { get; }

        /// <summary>
        /// The Gax ApiCall<> typ for this method.
        /// </summary>
        public abstract Typ ApiCallTyp { get; }

        /// <summary>
        /// The name of the ApiCall<> field.
        /// </summary>
        public string ApiCallFieldName { get; }
    }
}
