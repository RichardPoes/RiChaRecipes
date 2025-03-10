using Microsoft.Extensions.DependencyInjection;
using RCR.JavaScript.Wrappers;

namespace RCR.JavaScript;

public static class ScriptExtensions
{
    public static void AddJavaScript(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ThemeSelector>();
    }
}