using gax = Google.Api.Gax;
using gaxgrpc = Google.Api.Gax.Grpc;
using lro = Google.LongRunning;
using sys = System;

namespace Testing
{
    /// <summary>Settings for a <see cref="BasicLroClient"/>.</summary>
    public sealed partial class BasicLroSettings : gaxgrpc::ServiceSettingsBase
    {
        /// <summary>Get a new instance of the default <see cref="BasicLroSettings"/>.</summary>
        /// <returns>A new instance of the default <see cref="BasicLroSettings"/>.</returns>
        public static BasicLroSettings GetDefault() => new BasicLroSettings();

        /// <summary>Constructs a new <see cref="BasicLroSettings"/> object with default settings.</summary>
        public BasicLroSettings()
        {
        }

        private BasicLroSettings(BasicLroSettings existing)
        {
            gax::GaxPreconditions.CheckNotNull(existing, nameof(existing));
            Method1Settings = existing.Method1Settings;
            Method1OperationsSettings = existing.Method1OperationsSettings;
            OnCopy(existing);
        }

        partial void OnCopy(BasicLroSettings existing);

        public gaxgrpc::CallSettings Method1Settings { get; set; }

        /// <summary>Long Running Operation settings for calls to <c>BasicLroClient.Method1</c> and <c>BasicLroClient.Method1Async</c>.</summary>
        /// <remarks>Uses default <see cref="gax::PollSettings"/> of:<list type="bullet"><item><description>Initial delay: 20 seconds.</description></item><item><description>Delay multiplier: 1.5</description></item><item><description>Maximum delay: 45 seconds.</description></item><item><description>Total timeout: 24 hours.</description></item></list></remarks>
        public lro::OperationsSettings Method1OperationsSettings { get; set; } = new lro::OperationsSettings
        {
            DefaultPollSettings = new gax::PollSettings(gax::Expiration.FromTimeout(sys::TimeSpan.FromHours(24)), sys::TimeSpan.FromSeconds(20), 1.5, sys::TimeSpan.FromSeconds(45)),
        };

        /// <summary>Creates a deep clone of this object, with all the same property values.</summary>
        /// <returns>A deep clone of this <see cref="BasicLroSettings"/> object.</returns>
        public BasicLroSettings Clone() => new BasicLroSettings(this);
    }
}
