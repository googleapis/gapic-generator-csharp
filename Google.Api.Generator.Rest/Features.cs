// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     https,//www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Collections.Generic;

namespace Google.Api.Generator.Rest
{
    /// <summary>
    /// Configuration aspects previously in features.json. For now, it's simpler to hard-code these as it is
    /// to load a JSON file and deserialize it.
    /// </summary>
    internal static class Features
    {
        /// <summary>
        /// Major/minor/patch of the generated packages.
        /// (Build part is provided by the Discovery doc.)
        /// </summary>
        internal const string ReleaseVersion = "1.49.0";

        /// <summary>
        /// Version of support library upon which to depend.
        /// </summary>
        internal const string CurrentSupportVersion = "1.49.0";

        /// <summary>
        /// Version of PCL support library.
        /// </summary>
        internal const string PclSupportVersion = "1.25.0";

        /// <summary>
        /// Version of net40 support library.
        /// </summary>
        internal const string Net40SupportVersion = "1.10.0";

        internal static IReadOnlyDictionary<string, string> CloudPackageMap { get; } = new Dictionary<string, string>
        {
            { "Google.Apis.CloudAsset.v1", "Google.Cloud.Asset.V1" },
            { "Google.Apis.BIGQUERYDATATRANSFER.v1", "Google.Cloud.BigQuery.DataTransfer.V1" },
            { "Google.Apis.Bigquery.v2", "Google.Cloud.BigQuery.V2" },
            { "Google.Apis.Container.v1", "Google.Cloud.Container.V1" },
            { "Google.Apis.Dataproc.v1", "Google.Cloud.Dataproc.V1" },
            { "Google.Apis.Datastore.v1", "Google.Cloud.Datastore.V1" },
            { "Google.Apis.CloudDebugger.v2", "Google.Cloud.Debugger.V2" },
            { "Google.Apis.DLP.v2", "Google.Cloud.Dlp.V2" },
            { "Google.Apis.Firestore.v1", "Google.Cloud.Firestore" },
            { "Google.Apis.Iam.v1", "Google.Cloud.Iam.V1" },
            { "Google.Apis.CloudKMS.v1", "Google.Cloud.Kms.V1" },
            { "Google.Apis.CloudNaturalLanguage.v1", "Google.Cloud.Language.V1" },
            { "Google.Apis.Logging.v2", "Google.Cloud.Logging.V2" },
            { "Google.Apis.Monitoring.v3", "Google.Cloud.Monitoring.V3" },
            { "Google.Apis.CloudOSLogin.v1", "Google.Cloud.OsLogin.V1" },
            { "Google.Apis.Pubsub.v1", "Google.Cloud.PubSub.V1" },
            { "Google.Apis.CloudRedis.v1", "Google.Cloud.Redis.V1" },
            { "Google.Apis.CloudScheduler.v1", "Google.Cloud.Scheduler.V1" },
            { "Google.Apis.SecurityCommandCenter.v1", "Google.Cloud.SecurityCenter.V1" },
            { "Google.Apis.Spanner.v1", "Google.Cloud.Spanner.Data" },
            { "Google.Apis.Speech.v1", "Google.Cloud.Speech.V1" },
            { "Google.Apis.Storage.v1", "Google.Cloud.Storage.V1" },
            { "Google.Apis.CloudTasks.v2", "Google.Cloud.Tasks.V2" },
            { "Google.Apis.Texttospeech.v1", "Google.Cloud.TextToSpeech.V1" },
            { "Google.Apis.CloudTrace.v1", "Google.Cloud.Trace.V1" },
            { "Google.Apis.CloudTrace.v2", "Google.Cloud.Trace.V2" },
            { "Google.Apis.Translate.v3", "Google.Cloud.Translate.V3" },
            { "Google.Apis.Translate.v2", "Google.Cloud.Translation.V2" },
            { "Google.Apis.CloudVideoIntelligence.v1", "Google.Cloud.VideoIntelligence.V1" },
            { "Google.Apis.Vision.v1", "Google.Cloud.Vision.V1" }
        };
    }
}
