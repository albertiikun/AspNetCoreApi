using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using IPT.TestProject.Domain.Entities;
using IPT.TestProject.Persistence;

namespace IPT.TestProject.Api.Configurations.Extensions
{
    public static class AuthExtension
    {
        public static void RegisterAuthorization(this IServiceCollection services)
        {
            services.AddIdentity<User, Role>()
                  .AddEntityFrameworkStores<TestProjectDbContext>()
                  .AddDefaultTokenProviders();

            services.AddAuthorization();
        }

        public static void RegisterAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var key = Encoding.UTF8.GetBytes(configuration["Authentication:Secret"]);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

            services.AddAuthentication();
        }
    }
}
