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

namespace Testing.ChildResource
{
    public partial class SingleParent : ProtoMsgFake<Response>
    {
        public string Ref { get; set; }
        public RepeatedField<string> RepeatedRef { get; }
    }

    public partial class WildcardParent
    {
        public string Ref { get; set; }
        public RepeatedField<string> RepeatedRef { get; }
        public string RefSugar { get; set; }
        public RepeatedField<string> RepeatedRefSugar { get; }
    }

    public partial class TripleParent : ProtoMsgFake<TripleParent>
    {
        public string Ref { get; set; }
        public RepeatedField<string> RepeatedRef { get; }
    }

    public partial class TripleWildcardParent : ProtoMsgFake<TripleWildcardParent>
    {
        public string Ref { get; set; }
        public RepeatedField<string> RepeatedRef { get; }
    }

    public partial class OverlapParent : ProtoMsgFake<OverlapParent>
    {
        public string Ref { get; set; }
        public RepeatedField<string> RepeatedRef { get; }
    }

    public class Response : ProtoMsgFake<Response> { }
}
