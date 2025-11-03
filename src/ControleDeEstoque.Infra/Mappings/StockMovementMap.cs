using InventoryManagement.Domain.Entity;
using InventoryManagement.Domain.Enums;
using InventoryManagement.Domain.Utils.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Infra.Mappings
{
    public class StockMovementMap : IEntityTypeConfiguration<StockMovement>
    {
        public void Configure(EntityTypeBuilder<StockMovement> builder)
        {
            builder.ToTable("stock_movement");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("id");

            builder.Property(x => x.ProductInfoId)
                   .IsRequired()
                   .HasColumnName("product_id");

            builder.Property(x => x.MovementType)
                    .IsRequired()
                    .HasColumnName("movement_type")
                    .HasConversion(
                        l => l.GetDescription(),
                        l => EnumExtension.GetEnumFromDescription<MovementType>(l)
                    );

            builder.Property(x => x.Quantity)
                   .IsRequired()
                   .HasColumnName("quantity");

            builder.Property(x => x.MovementDate)
                   .IsRequired()
                   .HasColumnName("movement_date");
        }
    }
}
