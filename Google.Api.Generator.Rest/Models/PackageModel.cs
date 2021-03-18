// Copyright 2020 Google LLC
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

using Google.Api.Gax;
using Google.Api.Generator.Utils;
using Google.Api.Generator.Utils.Roslyn;
using Google.Apis.Discovery;
using Google.Apis.Discovery.v1.Data;
using Google.Apis.Requests;
using Google.Apis.Services;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using static Google.Api.Generator.Utils.Roslyn.RoslynBuilder;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Google.Api.Generator.Rest.Models
{
    /// <summary>
    /// Model for a package, i.e. everything associated with an API.
    /// </summary>
    public class PackageModel
    {
        private readonly Features _features;
        private readonly RestDescription _discoveryDoc;
        private readonly Dictionary<string, DataModel> _dataModelsById = new Dictionary<string, DataModel>();

        /// <summary>
        /// The name of the package, suitable for both namespace declarations and the NuGet
        /// package itself.
        /// </summary>
        public string PackageName { get; }

        /// <summary>
        /// The API name, as specified by the "name" property in the Discovery Doc.
        /// </summary>
        internal string ApiName { get; }

        /// <summary>
        /// The name of the top-level class that's generated, taken from the Discovery Doc canonical
        /// name or ApiName, with spaces removed, and then converted to a member name.
        /// </summary>
        internal string ClassName { get; }

        /// <summary>
        /// The API version, as specified by the "version" property in the Discovery Doc, e.g. "v1".
        /// </summary>
        private string ApiVersion { get; }

        /// <summary>
        /// The top-level resources. (Other resources may be nested.)
        /// </summary>
        private IReadOnlyList<ResourceModel> Resources { get; }

        /// <summary>
        /// The auth scopes specified within the Discovery Doc in auth/oauth2/scopes.
        /// </summary>
        private IReadOnlyList<AuthScope> AuthScopes { get; }

        /// <summary>
        /// The top-level methods for the API. (Most methods belong to resources, but some may be top-level.)
        /// </summary>
        private IReadOnlyList<MethodModel> Methods { get; }

        /// <summary>
        /// The top-level data models within the API. (Other data models may be nested within these.)
        /// </summary>
        private IReadOnlyList<DataModel> DataModels { get; }

        /// <summary>
        /// The base request type for all requests in this package. This does not have any type arguments, but
        /// is ready to be parameterized via a call to <see cref="Typ.Generic(Typ, Typ[])"/> to specify the response type.
        /// </summary>
        internal Typ GenericBaseRequestTypDef { get; }

        /// <summary>
        /// The type generated for the service.
        /// </summary>
        internal Typ ServiceTyp { get; }

        public PackageModel(RestDescription discoveryDoc, Features features)
        {
            _features = features;
            _discoveryDoc = discoveryDoc;
            ApiName = discoveryDoc.Name;

            // Note that spaces are removed first, because the Python code doesn't Pascal-case them. For example,
            // the "Cloud Memorystore for Memcached" API has a package name of "CloudMemorystoreforMemcached".
            // It's awful, but that's the way it works...
            ClassName = (discoveryDoc.CanonicalName ?? discoveryDoc.Name).Replace(" ", "").ToMemberName();
            ApiVersion = discoveryDoc.Version;
            string versionNoDots = discoveryDoc.Version.Replace('.', '_');
            var camelizedPackagePath = discoveryDoc.PackagePath is null
                ? ""
                : string.Join('.', discoveryDoc.PackagePath.Split('/').Select(part => part.ToUpperCamelCase())) + ".";
            PackageName = $"Google.Apis.{camelizedPackagePath}{ClassName}.{versionNoDots}";
            DataModels = discoveryDoc.Schemas.ToReadOnlyList(pair => new DataModel(this, parent: null, name: pair.Key, schema: pair.Value));

            // Populate the data model dictionary early, as methods and resources refer to the data model types.
            foreach (var dm in DataModels)
            {
                _dataModelsById[dm.Id] = dm;
            }
            Resources = discoveryDoc.Resources.ToReadOnlyList(pair => new ResourceModel(this, parent: null, pair.Key, pair.Value));
            // TODO: Ordering?
            AuthScopes = (discoveryDoc.Auth?.Oauth2?.Scopes).ToReadOnlyList(pair => new AuthScope(pair.Key, pair.Value.Description));
            ServiceTyp = Typ.Manual(PackageName, $"{ClassName}Service");
            GenericBaseRequestTypDef = Typ.Manual(PackageName, $"{ClassName}BaseServiceRequest");
            Methods = discoveryDoc.Methods.ToReadOnlyList(pair => new MethodModel(this, null, pair.Key, pair.Value));
        }

        internal CompilationUnitSyntax GenerateCompilationUnit()
        {
            var ctx = SourceFileContext.CreateFullyQualified(SystemClock.Instance);
            var ns = Namespace(PackageName);
            using (ctx.InNamespace(ns))
            {
                var serviceClass = GenerateServiceClass(ctx);
                var baseRequestClass = GenerateBaseRequestClass(ctx);
                ns = ns.AddMembers(serviceClass, baseRequestClass);

                foreach (var resource in Resources)
                {
                    var resourceClass = resource.GenerateClass(ctx);
                    ns = ns.AddMembers(resourceClass);
                }
            }
            var dataNs = Namespace(PackageName + ".Data");
            using (ctx.InNamespace(dataNs))
            {
                var dataModels = DataModels
                    .Where(dm => !dm.IsPlaceholder)
                    .OrderBy(dm => dm.Typ.Name, StringComparer.Ordinal);
                foreach (var dataModel in dataModels)
                {
                    dataNs = dataNs.AddMembers(dataModel.GenerateClass(ctx));
                }
            }
            return ctx.CreateCompilationUnit(ns).AddMembers(dataNs);
        }

        public IReadOnlyList<ParameterModel> CreateParameterList(Typ baseTyp) =>
            _discoveryDoc.Parameters.Select(p => new ParameterModel(this, p.Key, p.Value, baseTyp))
                .OrderBy(p => p.Name, StringComparer.Ordinal)
                .ToList();

        private ClassDeclarationSyntax GenerateServiceClass(SourceFileContext ctx)
        {
            var cls = Class(Modifier.Public, ServiceTyp, ctx.Type<BaseClientService>()).WithXmlDoc(XmlDoc.Summary($"The {ClassName} Service."));
            using (ctx.InClass(cls))
            {
                var discoveryVersionTyp = Typ.Manual("Google.Apis.Discovery", "DiscoveryVersion");
                var version = Field(Modifier.Public | Modifier.Const, ctx.Type<string>(), "Version")
                    .WithInitializer(ApiVersion)
                    .WithXmlDoc(XmlDoc.Summary("The API version."));
                var discoveryVersion = Field(Modifier.Public | Modifier.Static, ctx.Type(discoveryVersionTyp), "DiscoveryVersionUsed")
                    .WithInitializer(ctx.Type(discoveryVersionTyp).Access(nameof(DiscoveryVersion.Version_1_0)))
                    .WithXmlDoc(XmlDoc.Summary("The discovery version used to generate this service."));

                var parameterlessCtor = Ctor(Modifier.Public, cls, ThisInitializer(New(ctx.Type<BaseClientService.Initializer>())()))()
                    .WithBody()
                    .WithXmlDoc(XmlDoc.Summary("Constructs a new service."));

                var initializerParam = Parameter(ctx.Type<BaseClientService.Initializer>(), "initializer");

                var featuresArrayInitializer = _discoveryDoc.Features?.Any() ?? false
                    ? NewArray(ctx.ArrayType(Typ.Of<string[]>()))(_discoveryDoc.Features.ToArray())
                    : NewArray(ctx.ArrayType(Typ.Of<string[]>()), LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(0)));
                var features = Property(Modifier.Public | Modifier.Override, ctx.Type<IList<string>>(), "Features")
                    .WithGetBody(featuresArrayInitializer)
                    .WithXmlDoc(XmlDoc.Summary("Gets the service supported features."));

                var nameProperty = Property(Modifier.Public | Modifier.Override, ctx.Type<string>(), "Name")
                    .WithGetBody(ApiName)
                    .WithXmlDoc(XmlDoc.Summary("Gets the service name."));

                // Note: the following 4 properties have special handling post-generation, in terms
                // of adding the #if directives in.
                var baseUriValue = _discoveryDoc.RootUrl + _discoveryDoc.ServicePath;
                var basePathValue = _discoveryDoc.ServicePath;
                var batchUriValue = _discoveryDoc.RootUrl + _discoveryDoc.BatchPath;
                var batchPathValue = _discoveryDoc.BatchPath;

                var baseUriProperty = Property(Modifier.Public | Modifier.Override, ctx.Type<string>(), "BaseUri")
                    .WithGetBody(IdentifierName("BaseUriOverride").NullCoalesce(baseUriValue))
                    .WithXmlDoc(XmlDoc.Summary("Gets the service base URI."));

                var basePathProperty = Property(Modifier.Public | Modifier.Override, ctx.Type<string>(), "BasePath")
                    .WithGetBody(basePathValue)
                    .WithXmlDoc(XmlDoc.Summary("Gets the service base path."));

                var batchUriProperty = Property(Modifier.Public | Modifier.Override, ctx.Type<string>(), "BatchUri")
                    .WithGetBody(batchUriValue)
                    .WithXmlDoc(XmlDoc.Summary("Gets the batch base URI; ", XmlDoc.C("null"), " if unspecified."));
                var batchPathProperty = Property(Modifier.Public | Modifier.Override, ctx.Type<string>(), "BatchPath")
                    .WithGetBody(batchPathValue)
                    .WithXmlDoc(XmlDoc.Summary("Gets the batch base path; ", XmlDoc.C("null"), " if unspecified."));

                var resourceProperties = Resources.Select(resource => resource.GenerateProperty(ctx)).ToArray();

                var parameterizedCtor = Ctor(Modifier.Public, cls, BaseInitializer(initializerParam))(initializerParam)
                    .WithBlockBody(resourceProperties.Zip(Resources).Select(pair => pair.First.Assign(New(ctx.Type(pair.Second.Typ))(This))).ToArray())
                    .WithXmlDoc(
                        XmlDoc.Summary("Constructs a new service."),
                        XmlDoc.Param(initializerParam, "The service initializer."));

                cls = cls.AddMembers(version, discoveryVersion, parameterlessCtor, parameterizedCtor, features, nameProperty, baseUriProperty, basePathProperty, batchUriProperty, batchPathProperty);

                if (AuthScopes.Any())
                {
                    var scopeClass = Class(Modifier.Public, Typ.Manual(PackageName, "Scope"))
                        .WithXmlDoc(XmlDoc.Summary($"Available OAuth 2.0 scopes for use with the {_discoveryDoc.Title}."));
                    using (ctx.InClass(scopeClass))
                    {
                        foreach (var scope in AuthScopes)
                        {
                            var field = Field(Modifier.Public | Modifier.Static, ctx.Type<string>(), scope.FieldName)
                                .WithInitializer(scope.Value)
                                .WithXmlDoc(XmlDoc.Summary(scope.Description));
                            scopeClass = scopeClass.AddMembers(field);
                        }
                    }

                    var scopeConstantsClass = Class(Modifier.Public | Modifier.Static, Typ.Manual(PackageName, "ScopeConstants"))
                        .WithXmlDoc(XmlDoc.Summary($"Available OAuth 2.0 scope constants for use with the {_discoveryDoc.Title}."));
                    using (ctx.InClass(scopeConstantsClass))
                    {
                        foreach (var scope in AuthScopes)
                        {
                            var field = Field(Modifier.Public | Modifier.Const, ctx.Type<string>(), scope.FieldName)
                                .WithInitializer(scope.Value)
                                .WithXmlDoc(XmlDoc.Summary(scope.Description));
                            scopeConstantsClass = scopeConstantsClass.AddMembers(field);
                        }
                    }

                    cls = cls.AddMembers(scopeClass, scopeConstantsClass);
                }

                // Top-level methods (as opposed to resource-based methods) are relatively rare, but they do exist.
                // Example: oauth2 has a "tokeninfo" top-level method.
                foreach (var method in Methods)
                {
                    cls = cls.AddMembers(method.GenerateDeclarations(ctx).ToArray());
                }

                cls = cls.AddMembers(resourceProperties);
            }
            return cls;
        }

        private ClassDeclarationSyntax GenerateBaseRequestClass(SourceFileContext ctx)
        {
            var baseRequestTyp = Typ.Generic(GenericBaseRequestTypDef, Typ.GenericParam("TResponse"));

            var cls = Class(
                Modifier.Public | Modifier.Abstract,
                baseRequestTyp,
                ctx.Type(Typ.Generic(typeof(ClientServiceRequest<>), Typ.GenericParam("TResponse"))))
                .WithXmlDoc(XmlDoc.Summary($"A base abstract class for {ClassName} requests."));

            using (ctx.InClass(baseRequestTyp))
            {
                var serviceParam = Parameter(ctx.Type<IClientService>(), "service");
                var ctor = Ctor(Modifier.Protected, cls, BaseInitializer(serviceParam))(serviceParam)
                    .WithBody()
                    .WithXmlDoc(XmlDoc.Summary($"Constructs a new {ClassName}BaseServiceRequest instance."));

                var parameters = CreateParameterList(baseRequestTyp);

                cls = cls.AddMembers(ctor);
                cls = cls.AddMembers(parameters.SelectMany(p => p.GenerateDeclarations(ctx)).ToArray());

                var initParameters = Method(Modifier.Protected | Modifier.Override, VoidType, "InitParameters")()
                    .WithBlockBody(
                        BaseExpression().Call("InitParameters")(),
                        parameters.Select(p => p.GenerateInitializer(ctx)).ToArray())
                    .WithXmlDoc(XmlDoc.Summary($"Initializes {ClassName} parameter list."));

                cls = cls.AddMembers(initParameters);
            }
            return cls;
        }

        public XDocument GenerateProjectFile()
        {
            string releaseVersion = _features.ReleaseVersion;

            // Allow the major version to be overridden
            if (_features.MajorVersionOverrideMap.TryGetValue(PackageName, out var major))
            {
                string[] bits = releaseVersion.Split('.');
                bits[0] = major.ToString(CultureInfo.InvariantCulture);
                releaseVersion = string.Join('.', bits);
            }

            // This comment is turned into a line break later (in CodeGenerator).
            // While this is ugly, it's the simplest way of getting line breaks exactly where we want them.
            var lineBreak = new XComment("linebreak");
            var packageProperties = new XElement("PropertyGroup",
                    new XElement("Title", $"{PackageName} Client Library"),
                    new XElement("Version", $"{releaseVersion}.{GetRevision()}"),
                    new XElement("Authors", "Google Inc."),
                    new XElement("Copyright", $"Copyright {DateTime.UtcNow.Year} {(_discoveryDoc.OwnerName == "Google" ? "Google Inc." : _discoveryDoc.OwnerName)}"),
                    new XElement("PackageTags", "Google"),
                    new XElement("PackageProjectUrl", "https://github.com/google/google-api-dotnet-client"),
                    new XElement("PackageLicenseFile", "LICENSE"),
                    new XElement("RepositoryType", "git"),
                    new XElement("RepositoryUrl", "https://github.com/google/google-api-dotnet-client"),
                    new XElement("PackageIconUrl", "https://www.gstatic.com/images/branding/product/1x/google_developers_64dp.png"),
                    new XElement("Description", GetApiDescription())
                );

            var licenseItemGroup = new XElement("ItemGroup",
                new XElement("None", new XAttribute("Include", "../../../LICENSE"), new XAttribute("Pack", "true"), new XAttribute("PackagePath", ""))
            );

            var buildProperties = new XElement("PropertyGroup",
                new XElement("TargetFrameworks", "netstandard2.0;netstandard1.3;netstandard1.0;net45;net40"),
                new XElement("SignAssembly", "true"),
                new XElement("AssemblyOriginatorKeyFile", @"..\..\..\google.apis.snk"),
                new XElement("DebugType", "portable"),
                new XElement("GenerateDocumentationFile", "true"),
                new XElement("NoWarn", "1570,1587,1591")
            );

            var commonDependencies = new XElement("ItemGroup",
                PackageReference("ConfigureAwaitChecker.Analyzer", "1.0.1", new XAttribute("PrivateAssets", "All")),
                PackageReference("SourceLink.Create.CommandLine", "2.8.0", new XAttribute("PrivateAssets", "All"))
            );

            var netstandard20 = new XElement("ItemGroup", FrameworkCondition("netstandard2.0"),
                PackageReference("Google.Apis", _features.CurrentSupportVersion),
                AuthScopes.Any() ? PackageReference("Google.Apis.Auth", _features.CurrentSupportVersion) : null
            );

            var netstandard13 = new XElement("ItemGroup", FrameworkCondition("netstandard1.3"),
                PackageReference("Google.Apis", _features.CurrentSupportVersion),
                AuthScopes.Any() ? PackageReference("Google.Apis.Auth", _features.CurrentSupportVersion) : null
            );

            var netstandard10Properties = new XElement("PropertyGroup", FrameworkCondition("netstandard1.0"),
                new XElement("PackageTargetFallback", "portable-net45+win8+wpa81+wp8"),
                new XElement("AppConfig", "app.netstandard10.config")
            );
            var netstandard10Items = new XElement("ItemGroup", FrameworkCondition("netstandard1.0"),
                PackageReference("Google.Apis", $"[{_features.PclSupportVersion}]", new XAttribute("ExcludeAssets", "build")),
                AuthScopes.Any() ? PackageReference("Google.Apis.Auth", $"[{_features.PclSupportVersion}]", new XAttribute("ExcludeAssets", "build")) : null,
                PackageReference("Microsoft.NETCore.Portable.Compatibility", "1.0.1")
            );

            var net45 = new XElement("ItemGroup", FrameworkCondition("net45"),
                PackageReference("Google.Apis", _features.CurrentSupportVersion),
                AuthScopes.Any() ? PackageReference("Google.Apis.Auth", _features.CurrentSupportVersion) : null
            );

            var net40Properties = new XElement("PropertyGroup", FrameworkCondition("net40"),
                new XElement("AutoUnifyAssemblyReferences", "false"),
                new XElement("AppConfig", "app.net40.config")
            );
            var net40Items = new XElement("ItemGroup", FrameworkCondition("net40"),
                PackageReference("Google.Apis", $"[{_features.Net40SupportVersion}]", new XAttribute("ExcludeAssets", "build")),
                AuthScopes.Any() ? PackageReference("Google.Apis.Auth", $"[{_features.Net40SupportVersion}]", new XAttribute("ExcludeAssets", "build")) : null
            );

            var project = new XElement("Project", new XAttribute("Sdk", "Microsoft.NET.Sdk"), new XAttribute("ToolsVersion", "15.0"),
                lineBreak, new XComment(" nupkg information "), packageProperties,
                lineBreak, licenseItemGroup,
                lineBreak, new XComment(" build properties "), buildProperties,
                lineBreak, new XComment(" common dependencies "), commonDependencies,
                lineBreak, new XComment(" per-target dependencies "),
                netstandard20,
                lineBreak, netstandard13,
                lineBreak, netstandard10Properties, netstandard10Items,
                lineBreak, net45,
                lineBreak, net40Properties, net40Items,
                lineBreak
            );

            return new XDocument(project);

            int GetRevision()
            {
                // For some reason we don't rev the Discovery API...
                if (ApiName == "discovery")
                {
                    return 0;
                }
                string discoveryRevision = _discoveryDoc.Revision;
                // If the revision is a date string, the revision is the number of days since 2015-01-01,
                // unless the revision is before 2015, in which case it's 0.
                if (DateTime.TryParseExact(discoveryRevision, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out var date))
                {
                    return date.Year < 2015 ? 0 : (int) (date - new DateTime(2015, 1, 1)).TotalDays;
                }
                return int.Parse(discoveryRevision);
            }

            string GetApiDescription()
            {
                string upperCamelApiName = ApiName.ToUpperCamelCase(upperAfterDigit: false);
                var prefix = _features.CloudPackageMap.TryGetValue(PackageName, out var cloudPackage)
                    ? $@"
      This is not the recommended package for working with {upperCamelApiName}, please use the {cloudPackage} package.
      This Google APIs Client Library for working with {upperCamelApiName} {ApiVersion} uses older code generation, and is harder to use."
                    : $"\n      Google APIs Client Library for working with {upperCamelApiName} {ApiVersion}.";
                // The part of the package description that's the same for all packages - but can't be a constant due to the ApiName/ApiVersion part of the link.
                string suffix = @$"

      Supported Platforms:
      - .NET Framework 4.5+
      - .NET Standard 1.3 and .NET Standard 2.0; providing .NET Core support.

      Legacy platforms:
      - .NET Framework 4.0
      - Windows 8 Apps
      - Windows Phone 8.1
      - Windows Phone Silverlight 8.0

      Incompatible platforms:
      - .NET Framework < 4.0
      - Silverlight
      - UWP (will build, but is known not to work at runtime)
      - Xamarin

      More documentation on the API is available at:
      https://developers.google.com/api-client-library/dotnet/apis/{ApiName}/{ApiVersion}

      The package source code is available at:
      https://github.com/google/google-api-dotnet-client/tree/master/Src/Generated
    ";

                return prefix + suffix;
        }

        XElement PackageReference(string name, string version, params XAttribute[] extraAttributes) =>
                new XElement("PackageReference", new[] { new XAttribute("Include", name), new XAttribute("Version", version) }.Concat(extraAttributes));

            XAttribute FrameworkCondition(string framework) => new XAttribute("Condition", $"'$(TargetFramework)'=='{framework}'");
        }

        internal DataModel GetDataModelByReference(string @ref) => _dataModelsById[@ref];
    }
}
