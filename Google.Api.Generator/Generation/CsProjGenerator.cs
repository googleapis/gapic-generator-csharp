﻿// Copyright 2019 Google Inc. All Rights Reserved.
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

using System;
using System.Collections.Generic;
using System.Linq;

namespace Google.Api.Generator.Generation
{
    internal static class CsProjGenerator
    {
        private const string GaxGrpcCoreVersion = "[3.5.0, 4.0.0)";
        private const string GrpcCoreVersion = "[2.38.1, 3.0.0)";
        private const string LroVersion = "[2.3.0, 3.0.0)";
        private const string ReferenceAssembliesVersion = "1.0.2";
        private const string SystemLinqAsyncVersion = "5.1.0";
        private const string TestSdkVersion = "17.0.0";
        private const string XUnitRunnerVersion = "2.4.3";
        private const string XUnitVersion = "2.4.1";
        private const string MoqVersion = "4.16.1";

        public static string GenerateClient(bool hasLro)
        {
            var packageRefs = string.Join("", ExtraRefs().Select(x => $"{Environment.NewLine}    {x}"));
            // TODO: Use information from package metadata; when it's finalised.
            string content = $@"
<?xml version=""1.0"" encoding=""utf-8""?>
<Project Sdk=""Microsoft.NET.Sdk"">
  <PropertyGroup>

    <!-- TODO: Version defaults to 1.0.0-alpha01, edit as required -->
    <Version>1.0.0-alpha01</Version>

    <!-- TODO: NuGet packaging options -->
    <!--
      <Description>
        TODO: Description of this library.
      </Description>
      <PackageTags>TODO;Library;Tags</PackageTags>
      <Copyright>TODO: Copyright Statement</Copyright>
      <Authors>TODO:Authors</Authors>
      *** TODO: These Icon, License, Project, and repo settings *MUST* be checked and edited ***
      *** The values given are just examples ***
      <PackageIconUrl>TODO: https://cloud.google.com/images/gcp-icon-64x64.png</PackageIconUrl>
      <PackageLicenseUrl>TODO: https://www.apache.org/licenses/LICENSE-2.0</PackageLicenseUrl>
      <PackageProjectUrl>TODO: https://github.com/googleapis/google-cloud-dotnet</PackageProjectUrl>
      <RepositoryType>TODO: git</RepositoryType>
      <RepositoryUrl>TODO: https://github.com/googleapis/google-cloud-dotnet</RepositoryUrl>
    -->

    <!-- TODO: Configure package signing -->
    <!--
      <AssemblyOriginatorKeyFile>...</AssemblyOriginatorKeyFile>
      <SignAssembly>true</SignAssembly>
      <PublicSign Condition=""'$(OS)' != 'Windows_NT'"">true</PublicSign>
    -->

    <!-- These items should not require editing -->
    <TargetFrameworks>netstandard2.0;net461</TargetFrameworks>
    <LangVersion>latest</LangVersion>
    <GenerateDocumentationFile>true</GenerateDocumentationFile>
    <Deterministic>true</Deterministic>
    <TreatWarningsAsErrors>true</TreatWarningsAsErrors>

  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include=""Google.Api.Gax.Grpc.GrpcCore"" Version=""{GaxGrpcCoreVersion}"" />
    <PackageReference Include=""Grpc.Core"" Version=""{GrpcCoreVersion}"" />
    <PackageReference Include=""Microsoft.NETFramework.ReferenceAssemblies"" Version=""{ReferenceAssembliesVersion}"" PrivateAssets=""All"" />{packageRefs}
  </ItemGroup>

</Project>
";
            return content.Trim();

            IEnumerable<string> ExtraRefs()
            {
                if (hasLro)
                {
                    yield return $@"<PackageReference Include=""Google.LongRunning"" Version=""{LroVersion}"" />";
                }
            }
        }

        public static string GenerateSnippets(string clientNamespace)
        {
            string content = $@"
<?xml version=""1.0"" encoding=""utf-8""?>
<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <TargetFrameworks>netcoreapp3.1;net461</TargetFrameworks>
    <LangVersion>latest</LangVersion>
  </PropertyGroup>

  <ItemGroup>
    <ProjectReference Include=""../{clientNamespace}/{clientNamespace}.csproj"" />
    <PackageReference Include=""System.Linq.Async"" Version=""{SystemLinqAsyncVersion}"" />
    <PackageReference Include=""Microsoft.NETFramework.ReferenceAssemblies"" Version=""{ReferenceAssembliesVersion}"" PrivateAssets=""All"" />
  </ItemGroup>

</Project>
";
            return content.Trim();
        }

        public static string GenerateUnitTests(string clientNamespace)
        {
            string content = $@"
<?xml version=""1.0"" encoding=""utf-8""?>
<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <TargetFramework>netcoreapp3.1</TargetFramework>
    <LangVersion>latest</LangVersion>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include=""Microsoft.NET.Test.Sdk"" Version=""{TestSdkVersion}"" />
    <PackageReference Include=""xunit.runner.visualstudio"" Version=""{XUnitRunnerVersion}"" />
    <PackageReference Include=""Moq"" Version=""{MoqVersion}"" />
    <PackageReference Include=""xunit"" Version=""{XUnitVersion}"" />
    <PackageReference Include=""Microsoft.NETFramework.ReferenceAssemblies"" Version=""{ReferenceAssembliesVersion}"" PrivateAssets=""All"" />
    <ProjectReference Include=""../{clientNamespace}/{clientNamespace}.csproj"" />
  </ItemGroup>

</Project>
";
            return content.Trim();
        }
    }
}
