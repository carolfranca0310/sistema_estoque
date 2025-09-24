using InventoryManagement.Domain.Interfaces.IRepository;
using InventoryManagement.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagement.Infra.Setup
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IProductInfoRepository, ProductInfoRepository>();

            return services;
        }
    }
}
