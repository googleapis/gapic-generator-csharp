using gax = Google.Api.Gax;
using gaxgrpc = Google.Api.Gax.Grpc;

namespace Testing
{
    /// <summary>Settings for a <see cref="BasicClient"/>.</summary>
    public sealed partial class BasicSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="BasicSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="BasicSettings"/>.</returns>
        public static BasicSettings GetDefault() => new BasicSettings();

        /// <summary>Constructs a new <see cref="BasicSettings"/> object with default settings.</summary>
        public BasicSettings()
        {
        }

        private BasicSettings(BasicSettings existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            Method1Settings = existing.Method1Settings;
            OnCopy(existing);
        }

        partial void OnCopy(BasicSettings existing);

        public gaxgrpc::CallSettings Method1Settings { get; set; }

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="BasicSettings"/> object.</returns>
        public BasicSettings Clone() => new BasicSettings(this);
    }
}
