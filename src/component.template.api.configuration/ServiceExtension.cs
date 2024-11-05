using Microsoft.Extensions.DependencyInjection;

namespace component.template.api.configuration
{
    public static class ServiceExtension
    {
        public static void AddConfiguration(this IServiceCollection services, IGeneralApiConfig config) =>
            config.Initialize(services);

    }
}