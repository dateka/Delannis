using Microsoft.Extensions.DependencyInjection;
using Ynov.Delannis.Domain.UserAggregate.Ports;
using Ynov.Delannis.Infrastructure.Adapters.Domain.UserAggregate;

namespace Ynov.Delannis.Infrastructure.Adapters
{
    public static class DependencyInjection
    {
        public static void InjectInfrastructure(this IServiceCollection services)
        {
            // services.AddDbContext<ApplicationContext>(opt =>
            // {
            //     opt.UseSqlServer("Server=localhost;Database=YnovPizza;User Id=sa;password=86*v8%hqNbf6a57;Trusted_Connection=False;MultipleActiveResultSets=true;");
            // });
            
            services.AddScoped<IAuthenticationGateway, InMemoryAuthenticationGateway>();
            services.AddSingleton<IUserRepository, InMemoryUserRepository>();
        }
    }
}