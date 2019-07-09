// Copyright 2019 Google Inc. All Rights Reserved.
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

using Google.Protobuf.Collections;

namespace Testing.ResourceNames
{
    public partial class SimpleResource : ProtoMsgFake<SimpleResource>
    {
        public string Name { get; set; }
    }

    public partial class SimpleResourceRef : ProtoMsgFake<SimpleResourceRef>
    {
        public string SimpleResource { get; set; }
    }

    public partial class MultiResource : ProtoMsgFake<MultiResource>
    {
        public string Name { get; set; }
    }

    public partial class MultiResourceRef : ProtoMsgFake<MultiResourceRef>
    {
        public string MultiResource { get; set; }
    }

    public partial class FutureMultiResource : ProtoMsgFake<FutureMultiResource>
    {
        public string Name { get; set; }
    }

    public partial class OriginallySingleResource : ProtoMsgFake<OriginallySingleResource>
    {
        public string Name { get; set; }
    }

    public partial class OriginallySingleResourceRef : ProtoMsgFake<OriginallySingleResourceRef>
    {
        public string Resource1 { get; set; }
        public string Resource2 { get; set; }
    }

    public class Response : ProtoMsgFake<Response> { }
}
