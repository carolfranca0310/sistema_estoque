using InventoryManagement.Domain.Entity;
using InventoryManagement.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infra.Context
{
    public class InventoryContext: DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductInfo> ProductInfo { get; set; }
        public DbSet<StockMovement> StockMovement { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new ProductInfoMap());
            modelBuilder.ApplyConfiguration(new StockMovementMap());
        }
    }
}
