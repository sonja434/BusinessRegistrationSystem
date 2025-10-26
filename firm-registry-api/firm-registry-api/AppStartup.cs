using firm_registry_api.Data;
using firm_registry_api.Mappers;
using firm_registry_api.Repositories;
using firm_registry_api.Repositories.Interfaces;
using firm_registry_api.Services;
using firm_registry_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace firm_registry_api
{
    public static class AppStartup
    {
        public static IServiceCollection ConfigureModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(MapperProfile).Assembly);

            // Repozitorijumi
            services.AddScoped<IUserRepository, UserRepository>();

            // Servisi
            services.AddScoped<IAuthService, AuthService>();


            // DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
