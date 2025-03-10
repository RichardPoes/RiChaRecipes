using RCR.JavaScript;

namespace RCR.SiteServer;

public static class Startup
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        // Add services to the container.
        services.AddRazorComponents()
            .AddInteractiveServerComponents()
            .AddInteractiveWebAssemblyComponents();

        services.AddJavaScript();
    }    
}