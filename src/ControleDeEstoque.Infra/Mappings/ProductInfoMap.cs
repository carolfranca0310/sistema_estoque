using InventoryManagement.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infra.Mappings
{
    public class ProductInfoMap : IEntityTypeConfiguration<ProductInfo>
    {
        public void Configure(EntityTypeBuilder<ProductInfo> builder)
        {
            builder.ToTable("product_info");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("id");

            builder.Property(x => x.ProductId)
                   .IsRequired()
                   .HasColumnName("product_id");

            builder.Property(x => x.PurchaseDate)
                    .IsRequired()
                    .HasColumnName("purchase_date");

            builder.Property(x => x.ExpirationDate)
                   .IsRequired()
                   .HasColumnName("expiration_date");

            builder.Property(x => x.Quantity)
                   .IsRequired()
                   .HasColumnName("quantity");

            builder.Property(x => x.UnitPrice)
                   .IsRequired()
                   .HasColumnName("unit_price");

            builder.Property(x => x.TotalPrice)
                   .IsRequired()
                   .HasColumnName("total_price");

            builder.HasOne(x => x.Product)
                   .WithMany()
                   .HasForeignKey(x => x.ProductId);
        }
    }

}
