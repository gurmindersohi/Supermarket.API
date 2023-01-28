namespace Supermarket.Services
{
    using Supermarket.Abstractions.Services;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Supermarket.Abstractions.Repositories;
    using Supermarket.Data.Repositories;

    public static class ServiceRegistry
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(ICategoryRepository), typeof(CategoryRepository));
            services.AddTransient(typeof(ICategoryService), typeof(CategoryService));
            services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));

            return services;
        }
    }
}

