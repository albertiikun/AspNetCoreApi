using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IPT.TestProject.Application.Interfaces;
using IPT.TestProject.Persistence;

namespace IPT.TestProject.Api.Configurations.Extensions
{
    public static  class DbExtension
    {
        public static void RegisterDb(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("TestProjectDb");
            services.AddDbContext<TestProjectDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<ITestProjectDbContext, TestProjectDbContext>();
        }
    }
}
