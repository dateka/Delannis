using System;
using Microsoft.Extensions.DependencyInjection;
using Ynov.Delannis.Domain.UserAggregate.Ports;
using Ynov.Delannis.Domain.UserAggregate.Services;
using Ynov.Delannis.Infrastructure.Adapters.Domain.UserAggregate;

namespace Ynov.Delannis.UnitTest.Commons
{
    public class UnitTestConfiguration
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public void Configure()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddScoped<IUserRepository, InMemoryUserRepository>();
            services.AddScoped<IAuthenticationGateway, InMemoryAuthenticationGateway>();
            services.AddScoped<IUserLoginService, UserLoginService>();
            services.AddScoped<IUserRegistrationService, UserRegistrationService>();
            services.AddScoped<IShoppingCartService, ShoppingCartService>();
            
            ServiceProvider = services.BuildServiceProvider();
        }
    }
}