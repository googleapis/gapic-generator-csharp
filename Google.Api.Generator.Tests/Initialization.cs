using System.Globalization;
using System.Runtime.CompilerServices;

namespace Google.Api.Generator.Tests;

public static class Initialization
{
    [ModuleInitializer]
    public static void Run()
    {
        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
        CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;
    }
}
