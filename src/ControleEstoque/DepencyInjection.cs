using InventoryManagement.Domain.Interfaces.IService;
using InventoryManagement.Service.Services;

namespace InventoryManagement.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {

            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IProductInfoService, ProductInfoService>();

            return services;
        }
    }
}
