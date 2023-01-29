namespace Supermarket.Infrastructure
{
    using Supermarket.Services;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

	public static class SupermarketDIRegistration
    {
        public static IServiceCollection AddSupermarketServices(this IServiceCollection services)
        {
            services.AddServices();
            return services;
        }
    }
}

