using Microsoft.Extensions.DependencyInjection;
using Ynov.Delannis.Domain.UserAggregate.Ports;
using Ynov.Delannis.Infrastructure.Adapters.Domain.UserAggregate;

namespace Ynov.Delannis.Infrastructure.Adapters
{
    public static class DependencyInjection
    {
        public static void InjectInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationGateway, InMemoryAuthenticationGateway>();
            services.AddScoped<IUserRepository, InMemoryUserRepository>();
        }
    }
}