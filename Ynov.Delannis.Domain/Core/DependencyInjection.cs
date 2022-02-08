using Microsoft.Extensions.DependencyInjection;
using Ynov.Delannis.Domain.UserAggregate.Services;

namespace Ynov.Delannis.Domain.Core
{
    public static class DependencyInjection
    {
        public static void InjectDomain(this IServiceCollection services)
        {
            services.AddScoped<IUserRegistrationService, UserRegistrationService>();
            services.AddScoped<IUserLoginService, UserLoginService>();
        }
    }
}