using InventoryManagement.Domain.DTO;
using InventoryManagement.Domain.Entity;
using System.Linq.Expressions;

namespace InventoryManagement.Domain.Interfaces.IRepository
{
    public interface IProductInfoRepository
    {
        Task<ProductInfo?> CreateAsync(ProductInfo productInfo);
    }
}
