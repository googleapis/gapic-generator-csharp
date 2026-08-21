// Copyright 2026 Google LLC
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

using Google.Api.Gax.Grpc;
using Google.Api.Gax.Grpc.Rest;
using Google.Showcase.V1Beta1;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Google.Api.Generator.IntegrationTests
{
    public abstract class ResumableUploadTestBase : ShowcaseTestBase<ResumableUploadServiceClient, ResumableUploadServiceClientBuilder>
    {
        [SkippableFact]
        public async Task UploadMedia_Simple()
        {
            var client = CreateClient();
            var session = client.UploadMedia();
            Assert.NotNull(session);

            var request = new UploadMediaRequest { Name = "test-file.txt" };
            byte[] contentBytes = Encoding.UTF8.GetBytes("Hello Resumable Upload World!");
            using var stream = new MemoryStream(contentBytes);

            var response = await session.BeginUploadAsync(request, stream);
            Assert.NotNull(response);
            Assert.NotNull(session.UploadUri);
            Assert.Equal(contentBytes.Length, response.Size);
        }

        [SkippableFact]
        public async Task UploadMedia_LargePayload()
        {
            var client = CreateClient();
            var session = client.UploadMedia();
            Assert.NotNull(session);

            var request = new UploadMediaRequest { Name = "large-file.bin" };
            byte[] contentBytes = new byte[512 * 1024]; // 512 KiB
            for (int i = 0; i < contentBytes.Length; i++)
            {
                contentBytes[i] = (byte)(i % 256);
            }
            using var stream = new MemoryStream(contentBytes);

            var response = await session.BeginUploadAsync(request, stream);
            Assert.NotNull(response);
            Assert.NotNull(session.UploadUri);
            Assert.Equal(contentBytes.Length, response.Size);
        }

        [SkippableFact]
        public async Task UploadMedia_ResumeUploadAfterInterruption()
        {
            var client = CreateClient();

            byte[] contentBytes = new byte[512 * 1024]; // 512 KiB
            for (int i = 0; i < contentBytes.Length; i++)
            {
                contentBytes[i] = (byte)(i % 256);
            }

            var session1 = client.UploadMedia();
            var request = new UploadMediaRequest { Name = "interrupted-file.bin" };

            using var interruptingStream = new InterruptibleMemoryStream(contentBytes, interruptAfterBytes: 256 * 1024);
            var chunkSettings = ResumableUploadSettings.Default.WithChunkSize(256 * 1024);

            await Assert.ThrowsAsync<IOException>(() => session1.BeginUploadAsync(request, interruptingStream, uploadSettings: chunkSettings));

            Uri uploadUri = session1.UploadUri;
            Assert.NotNull(uploadUri);

            // Resume session using session2 and full stream
            var session2 = client.UploadMedia();
            using var fullStream = new MemoryStream(contentBytes);
            var response = await session2.ResumeUploadAsync(uploadUri, fullStream, uploadSettings: chunkSettings);

            Assert.NotNull(response);
            Assert.Equal(contentBytes.Length, response.Size);
        }

        [SkippableFact]
        public async Task UploadMedia_CustomChunkSize()
        {
            var client = CreateClient();
            var session = client.UploadMedia();
            Assert.NotNull(session);

            var request = new UploadMediaRequest { Name = "custom-chunk.bin" };
            byte[] contentBytes = new byte[768 * 1024]; // 768 KiB
            using var stream = new MemoryStream(contentBytes);

            var customSettings = ResumableUploadSettings.Default.WithChunkSize(256 * 1024);
            var response = await session.BeginUploadAsync(request, stream, uploadSettings: customSettings);
            Assert.NotNull(response);
            Assert.NotNull(session.UploadUri);
            Assert.Equal(contentBytes.Length, response.Size);
        }

        [SkippableFact]
        public async Task UploadMedia_NonFatalErrorOnStart_RetriesAndSucceeds()
        {
            var client = CreateClient();
            var session = client.UploadMedia();
            var request = new UploadMediaRequest { Name = "test-start-retry.txt" };
            byte[] contentBytes = Encoding.UTF8.GetBytes("Testing non-fatal start retry");
            using var stream = new MemoryStream(contentBytes);

            string clientUuid = Guid.NewGuid().ToString();
            var callSettings = CallSettings.FromHeader("X-Goog-Test-Scenario", "non_fatal_error_on_start")
                .WithHeader("X-Goog-Test-Scenario-Config", $"{{\"client_uuid\":\"{clientUuid}\",\"error_code\":503,\"failure_count\":1}}");

            var response = await session.BeginUploadAsync(request, stream, callSettings: callSettings);
            Assert.NotNull(response);
            Assert.Equal(contentBytes.Length, response.Size);
        }

        [SkippableFact]
        public async Task UploadMedia_FatalErrorOnStart_ThrowsRpcException()
        {
            var client = CreateClient();
            var session = client.UploadMedia();
            var request = new UploadMediaRequest { Name = "test-start-fatal.txt" };
            byte[] contentBytes = Encoding.UTF8.GetBytes("Testing fatal start error");
            using var stream = new MemoryStream(contentBytes);

            string clientUuid = Guid.NewGuid().ToString();
            var callSettings = CallSettings.FromHeader("X-Goog-Test-Scenario", "fatal_error_on_start")
                .WithHeader("X-Goog-Test-Scenario-Config", $"{{\"client_uuid\":\"{clientUuid}\",\"error_code\":400,\"failure_count\":1}}");

            await Assert.ThrowsAsync<Grpc.Core.RpcException>(() => session.BeginUploadAsync(request, stream, callSettings: callSettings));
        }

        [SkippableFact]
        public async Task UploadMedia_NonFatalErrorOnChunkUpload_RetriesAndSucceeds()
        {
            var client = CreateClient();
            var session = client.UploadMedia();
            var request = new UploadMediaRequest { Name = "test-chunk-retry.txt" };
            byte[] contentBytes = new byte[512 * 1024]; // 512 KiB
            for (int i = 0; i < contentBytes.Length; i++)
            {
                contentBytes[i] = (byte)(i % 256);
            }
            using var stream = new MemoryStream(contentBytes);

            string clientUuid = Guid.NewGuid().ToString();
            var callSettings = CallSettings.FromHeader("X-Goog-Test-Scenario", "non_fatal_error_on_chunk_upload")
                .WithHeader("X-Goog-Test-Scenario-Config", $"{{\"client_uuid\":\"{clientUuid}\",\"error_code\":503,\"failure_count\":1,\"after_offset\":0}}");

            var response = await session.BeginUploadAsync(request, stream, callSettings: callSettings);
            Assert.NotNull(response);
            Assert.Equal(contentBytes.Length, response.Size);
        }

        [SkippableFact]
        public async Task UploadMedia_NonFatalErrorOnQuery_RetriesAndSucceeds()
        {
            var client = CreateClient();
            var session = client.UploadMedia();
            var request = new UploadMediaRequest { Name = "test-query-retry.txt" };
            byte[] contentBytes = new byte[512 * 1024]; // 512 KiB
            using var stream = new MemoryStream(contentBytes);

            string clientUuid = Guid.NewGuid().ToString();
            var callSettings = CallSettings.FromHeader("X-Goog-Test-Scenario", "non_fatal_error_on_query")
                .WithHeader("X-Goog-Test-Scenario-Config", $"{{\"client_uuid\":\"{clientUuid}\",\"error_code\":503,\"failure_count\":1}}");

            var response = await session.BeginUploadAsync(request, stream, callSettings: callSettings);
            Assert.NotNull(response);
            Assert.Equal(contentBytes.Length, response.Size);
        }

        private class InterruptibleMemoryStream : MemoryStream
        {
            private readonly long _interruptAfterBytes;
            private long _bytesRead;

            public InterruptibleMemoryStream(byte[] buffer, long interruptAfterBytes) : base(buffer)
            {
                _interruptAfterBytes = interruptAfterBytes;
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                if (_bytesRead >= _interruptAfterBytes)
                {
                    throw new IOException("Simulated network interruption");
                }
                int toRead = (int)Math.Min(count, _interruptAfterBytes - _bytesRead);
                int read = base.Read(buffer, offset, toRead);
                _bytesRead += read;
                return read;
            }

            public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
            {
                if (_bytesRead >= _interruptAfterBytes)
                {
                    throw new IOException("Simulated network interruption");
                }
                int toRead = (int)Math.Min(count, _interruptAfterBytes - _bytesRead);
                int read = await base.ReadAsync(buffer, offset, toRead, cancellationToken);
                _bytesRead += read;
                return read;
            }

            public override async ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default)
            {
                if (_bytesRead >= _interruptAfterBytes)
                {
                    throw new IOException("Simulated network interruption");
                }
                int toRead = (int)Math.Min(buffer.Length, _interruptAfterBytes - _bytesRead);
                int read = await base.ReadAsync(buffer.Slice(0, toRead), cancellationToken);
                _bytesRead += read;
                return read;
            }
        }

        public class ResumableUploadRestTest : ResumableUploadTestBase { }
    }
}
