using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Ynov.Delannis.Domain.CartAggregate.Ports;
using Ynov.Delannis.Domain.CartAggregate.Services;
using Ynov.Delannis.Domain.Core;
using Ynov.Delannis.Domain.productAggregate.Ports;
using Ynov.Delannis.Domain.UserAggregate.Ports;
using Ynov.Delannis.Domain.UserAggregate.Services;
using Ynov.Delannis.Infrastructure.Adapters.Domain.CartAggregate;
using Ynov.Delannis.Infrastructure.Adapters.Domain.ProductAggregate;
using Ynov.Delannis.Infrastructure.Adapters.Domain.UserAggregate;

namespace Ynov.Delannis.UnitTest.Commons
{
    public class UnitTestConfiguration
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public void Configure()
        {
            ServiceCollection services = new ServiceCollection();

            services.InjectDomain();
            services.AddScoped<IUserRepository, InMemoryUserRepository>();
            services.AddScoped<IAuthenticationGateway, InMemoryAuthenticationGateway>();
            services.AddScoped<IAddProductToCartService, AddProductToCartService>();
            services.AddScoped<IEmptyCartService, EmptyCartService>();
            services.AddScoped<IUpdateCartItemService, UpdateCartItemService>();
            services.AddScoped<IProductRepository, InMemoryProductRepository>();
            services.AddScoped<ICartRepository, InMemoryCartRepository>();
            ServiceProvider = services.BuildServiceProvider();
        }
    }
}