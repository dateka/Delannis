using Microsoft.Extensions.DependencyInjection;
using SolidToken.SpecFlow.DependencyInjection;
using Ynov.Delannis.Domain.UserAggregate.Ports;
using Ynov.Delannis.Domain.UserAggregate.Services;
using Ynov.Delannis.Infrastructure.Adapters.Domain.UserAggregate;
using Ynov.Delannis.Specs.Drivers;

namespace Ynov.Delannis.Specs.Hooks
{
    public class DependencyHook
    {
        [ScenarioDependencies]
        public static IServiceCollection ConfigureDependencies()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<IUserRepository, InMemoryUserRepository>();
            services.AddScoped<IAuthenticationGateway, InMemoryAuthenticationGateway>();
            services.AddScoped<IUserRegistrationService, UserRegistrationService>();
            services.AddScoped<IUserLoginService, UserLoginService>();
            services.AddScoped<IShoppingCartService, ShoppingCartService>();
            services.AddScoped<ErrorDriver>();
            return services;
        }
    }
}