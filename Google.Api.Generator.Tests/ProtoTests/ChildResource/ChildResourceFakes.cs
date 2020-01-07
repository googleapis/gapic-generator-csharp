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

namespace Testing.ChildResource
{
    public partial class ProjectRef : ProtoMsgFake<ProjectRef>
    {
        public string ProjectUserParent { get; set; }
    }

    public partial class MultiRootRef : ProtoMsgFake<MultiRootRef>
    {
        public string MultiRootParent { get; set; }
    }

    public partial class WildcardRef : ProtoMsgFake<WildcardRef>
    {
        public string WildcardParent { get; set; }
    }

    public class Response : ProtoMsgFake<Response> { }
}
