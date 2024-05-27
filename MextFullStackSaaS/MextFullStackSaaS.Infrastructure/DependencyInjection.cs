using MextFullStackSaaS.Domain.Identity;
using MextFullStackSaaS.Domain.Settings;
using MextFullStackSaaS.Infrastructure.Persistence.Contexts;
using MextFullStackSaaS.Infrastructure.Services;
using MextFullStactSaaS.Application.Common.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace MextFullStackSaaS.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IApplicationDbContext,ApplicationDbContext>(
                container =>container.GetRequiredService<ApplicationDbContext>());

            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.Configure<JwtSettings>(jwtSettings=>configuration.GetSection("JwtSettings").Bind(jwtSettings));

            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;

                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IJwtService,JwtManager>();
            services.AddScoped<IIdentityService, IdentityManager>();

            return services;
        }
    }
}
