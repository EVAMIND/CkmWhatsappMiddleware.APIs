using CkmWhatsAppMiddleware.APIs.AutoMapper;
using CkmWhatsAppMiddleware.APIs.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CkmWhatsAppMiddleware.APIs.DependencyInjections;

public static class WhatsAppMiddlewareApiInjections
{
    public static void AddCkmWhatsAppMiddlewareInjections(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = assembly.GetManifestResourceNames().FirstOrDefault(str => str.EndsWith("appsettings.WhatsAppMiddlewareApi.json"));

        if (resourceName == null)
        {
            throw new Exception("appsettings.WhatsAppMiddlewareApi.json não encontrado como recurso embutido.");
        }

        using (var stream = assembly.GetManifestResourceStream(resourceName))
        {
            if (stream == null)
            {
                return;
            }

            var embeddedConfig = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();

            configuration = new ConfigurationBuilder()
                .AddConfiguration(configuration)
                .AddConfiguration(embeddedConfig)
                .Build();
        }

        services.Configure<WhatsAppMiddlewareApi>(configuration.GetSection("WhatsAppMiddlewareApi"));

        AddRepositoriesServices(services);
        AddApplicationsServices(services);
    }

    private static void AddRepositoriesServices(this IServiceCollection services)
    {
    }

    private static void AddApplicationsServices(this IServiceCollection services)
    {

        services.AddAutoMapper(typeof(ApplicationMappingProfile));
    }
}
