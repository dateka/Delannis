using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Ynov.Delannis.Domain.CartAggregate.Ports;
using Ynov.Delannis.Domain.productAggregate.Ports;
using Ynov.Delannis.Domain.UserAggregate.Ports;
using Ynov.Delannis.Infrastructure.Adapters.Domain.CartAggregate;
using Ynov.Delannis.Infrastructure.Adapters.Domain.ProductAggregate;
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
            services.AddSingleton<ICartRepository, InMemoryCartRepository>();
            services.AddSingleton<IProductRepository, InMemoryProductRepository>();

            //TypeAdapterConfig.GlobalSettings.Default.EnableNonPublicMembers(true);
            //TypeAdapterConfig.GlobalSettings.Default.MapToConstructor(true);
        }
    }
}