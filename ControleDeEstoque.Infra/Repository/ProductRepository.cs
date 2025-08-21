using InventoryManagement.Domain.Entity;
using InventoryManagement.Domain.Interfaces.IRepository;
using InventoryManagement.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infra.Repository
{
    internal class ProductRepository : IProductRepository
    {
        private readonly InventoryContext _context;

        public ProductRepository(InventoryContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> GetAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p =>  p.Id == id);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> UpdateAsync(int id, Product updatedProduct)
        {
            var product = await GetAsync(id);

            product.Name = updatedProduct.Name;
            product.PurchaseDate = updatedProduct.PurchaseDate;
            product.ExpirationDate = updatedProduct.ExpirationDate;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> DeleteAsync(int id)
        {
            var product = await GetAsync(id);

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }
    }
}
