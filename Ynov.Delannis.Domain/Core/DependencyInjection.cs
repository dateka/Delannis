using Microsoft.Extensions.DependencyInjection;
using Ynov.Delannis.Domain.CartAggregate.Services;
using Ynov.Delannis.Domain.productAggregate.Ports;
using Ynov.Delannis.Domain.UserAggregate.Services;

namespace Ynov.Delannis.Domain.Core
{
    public static class DependencyInjection
    {
        public static void InjectDomain(this IServiceCollection services)
        {
            services.AddScoped<IUserRegistrationService, UserRegistrationService>();
            services.AddScoped<IUserLoginService, UserLoginService>();
            services.AddScoped<IAddProductToCartService, AddProductToCartService>();
            services.AddScoped<IEmptyCartService, EmptyCartService>();
            services.AddScoped<IUpdateCartItemService, UpdateCartItemService>();
        }
    }
}