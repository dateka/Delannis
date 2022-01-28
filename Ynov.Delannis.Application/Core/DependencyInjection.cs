using Microsoft.Extensions.DependencyInjection;
using Ynov.Delannis.Application.UserAggregate;
using Ynov.Delannis.Domain.Core;
using Ynov.Delannis.Infrastructure.Adapters;

namespace Ynov.Delannis.Application.Core
{
    public static class DependencyInjection
    {
        public static void InjectServices(this IServiceCollection services)
        {
            services.InjectDomain();
            services.InjectInfrastructure();
            services.AddScoped<UserService>();
        }
    }
}