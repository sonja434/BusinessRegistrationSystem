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

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IActivityGroupRepository, ActivityGroupRepository>();
            services.AddScoped<IActivityCodeRepository, ActivityCodeRepository>();
            services.AddScoped<ICompanyRequestRepository, CompanyRequestRepository>();
            services.AddScoped<IActivitySectorRepository, ActivitySectorRepository>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<ICompanyRequestService, CompanyRequestService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IPdfService, PdfService>();
            services.AddScoped<IUserService, UserService>();

            // DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
