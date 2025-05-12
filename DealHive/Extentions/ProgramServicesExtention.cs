using Hive.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DealHive.Extentions
{
    internal static class ProgramServicesExtention
    {
        public static IServiceCollection UseProgramServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            // Db Connection
            services.AddDbContext<HiveContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            return services;
        }
    }
}
