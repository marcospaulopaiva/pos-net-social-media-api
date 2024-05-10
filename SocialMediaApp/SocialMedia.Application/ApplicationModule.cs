using Microsoft.Extensions.DependencyInjection;
using SocialMedia.Application.Services;

namespace SocialMedia.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddServices();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IContaService, ContaService>();
            services.AddScoped<IPerfilService, PerfilService>();

            return services;
        }
    }
}
