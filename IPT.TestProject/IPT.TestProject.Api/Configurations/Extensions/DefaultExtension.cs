using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IPT.TestProject.Application.Services.Users.Commands.Add;

namespace IPT.TestProject.Api.Configurations.Extensions
{
    public static class DefaultExtension
    {
        public static void RegisterDefaults(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            services.AddMediatR(typeof(AddUserCommand).Assembly);
        }

        public static void AddDefaults(this IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapControllers();
            });

        }
    }
}
