using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IPT.TestProject.Api.Configurations.Extensions;

namespace IPT.TestProject.Api.Configurations
{
    public static class ServiceExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterDefaults(configuration);
            services.RegisterDb(configuration);
            services.RegisterAuthorization();
            services.RegisterAuthentication(configuration);
            services.RegisterSwagger(configuration);
            return services;
        }

        public static IMvcBuilder UseServices(this IMvcBuilder builder)
        {

            return builder;
        }

        public static IApplicationBuilder AddServices(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.AddDefaults(env);
            app.AddHelper();
            app.AddSwagger();
            return app;
        } 
    }
}
