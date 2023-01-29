namespace Supermarket.Services
{
    using AutoMapper;
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
            services.AddAutoMapper(typeof(ServiceRegistry));

            return services;
        }
    }
}

