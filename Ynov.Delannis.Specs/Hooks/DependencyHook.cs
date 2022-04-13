using Microsoft.Extensions.DependencyInjection;
using SolidToken.SpecFlow.DependencyInjection;
using Ynov.Delannis.Domain.CartAggregate.Ports;
using Ynov.Delannis.Domain.Core;
using Ynov.Delannis.Domain.productAggregate.Ports;
using Ynov.Delannis.Domain.UserAggregate.Ports;
using Ynov.Delannis.Domain.UserAggregate.Services;
using Ynov.Delannis.Infrastructure.Adapters.Domain.CartAggregate;
using Ynov.Delannis.Infrastructure.Adapters.Domain.ProductAggregate;
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
            services.InjectDomain();
            
            services.AddScoped<IUserRepository, InMemoryUserRepository>();
            services.AddScoped<IAuthenticationGateway, InMemoryAuthenticationGateway>();
            services.AddScoped<IProductRepository, InMemoryProductRepository>();
            services.AddScoped<ICartRepository, InMemoryCartRepository>();
            services.AddScoped<ErrorDriver>();
            return services;
        }
    }
}