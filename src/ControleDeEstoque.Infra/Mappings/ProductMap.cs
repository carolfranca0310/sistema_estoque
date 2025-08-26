using InventoryManagement.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Xml.Schema;

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

            builder.Property(x => x.PurchaseDate)
                    .IsRequired()
                    .HasColumnName("purchase_date");

            builder.Property(x => x.ExpirationDate)
                   .IsRequired()
                   .HasColumnName("expiration_date");
        }
    }
}
