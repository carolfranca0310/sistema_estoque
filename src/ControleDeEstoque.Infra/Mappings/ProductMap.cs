using InventoryManagement.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Infra.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("id");

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasColumnName("name");

            builder.Property(x => x.Brand)
                    .IsRequired()
                    .HasColumnName("brand");

            builder.Property(x => x.Weight)
                   .IsRequired()
                   .HasColumnName("weight");

            builder.HasIndex(p => new { p.Name, p.Brand, p.Weight })
                   .IsUnique();
        }
    }
}
