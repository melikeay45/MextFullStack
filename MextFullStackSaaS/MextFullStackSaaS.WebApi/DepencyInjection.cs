using MextFullStackSaaS.WebApi.Services;
using MextFullStactSaaS.Application.Common.Interfaces;
using System.Runtime.CompilerServices;

namespace MextFullStackSaaS.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();

            services.AddScoped<ICurrentUserService, CurrentUserManager>();

            return services;
        }
    }
}
