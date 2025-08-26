using InventoryManagement.Domain.Entity;
using InventoryManagement.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infra.Context
{
    public class InventoryContext: DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
        }
    }
}
