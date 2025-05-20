using Hive.Application.JwtSettingsConfigurations;
using Hive.Application.MappingProfiles;
using Hive.Application.Services;
using Hive.Application.Services.Items;
using Hive.Core.Entities;
using Hive.Core.Interfaces;
using Hive.Core.Interfaces.AuthService;
using Hive.Core.Interfaces.Services;
using Hive.Infrastructure.Data;
using Hive.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
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

            // Identity service registeration 
            services.AddIdentity<AppUser, IdentityRole>(options =>
            {

            }).AddEntityFrameworkStores<HiveContext>();

            // Getting JwtSettings configurations from appsetting
            services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

            // AuthService Registeration
            services.AddScoped(typeof(IAuthService), typeof(AuthService));

            services.AddScoped(typeof(IItemService), typeof(ItemService));

            // GenericRepository service registeration
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // UnitOfWork service registeration
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            // Mapper service registeration
            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);


            return services;
        }
    }
}
