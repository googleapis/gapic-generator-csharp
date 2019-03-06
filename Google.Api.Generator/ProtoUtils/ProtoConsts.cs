// Copyright 2018 Google Inc. All Rights Reserved.
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

namespace Google.Api.Generator.ProtoUtils
{
    internal static class ProtoConsts
    {
        public static class FileOption
        {
            public const int ResourceDefinition = 1053;
            public const int ResourceSetDefinition = 1054;
        }

        public static class ServiceOption
        {
            public const int DefaultHost = 1049;
            public const int OAuthScopes = 1050;
        }

        public static class MethodOption
        {
            public const int OperationInfo = 1049;
            public const int MethodSignature = 1051;
            public const int HttpRule = 72295728;
        }

        public static class FieldOption
        {
            public const int FieldBehavior = 1052;
            public const int Resource = 1053;
            public const int ResourceSet = 1054;
            public const int ResourceReference = 1055;
        }
    }
}
