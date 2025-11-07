using InventoryManagement.Domain.Enums;

namespace InventoryManagement.Domain.Entity
{
    public class StockMovement : Base
    {
        public int ProductInfoId { get; set; }
        public MovementType MovementType { get; set; }
        public int Quantity { get; set; }
        public DateTime MovementDate { get; set; }

        //Table relationships
        public ProductInfo? ProductInfo { get; set; }

        public StockMovement()
        {
            
        }
        public StockMovement(int productInfoId, MovementType movementType, int quantity, DateTime movementDate)
        {
            ProductInfoId = productInfoId;
            MovementType = movementType;
            Quantity = quantity;
            MovementDate = movementDate;
        }
    }
}
