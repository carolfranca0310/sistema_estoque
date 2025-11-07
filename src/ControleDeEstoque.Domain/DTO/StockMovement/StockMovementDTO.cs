using InventoryManagement.Domain.Enums;

namespace InventoryManagement.Domain.DTO.StockMovement
{
    public class StockMovementDTO
    {
        public int Id { get; set; }
        public int ProductInfoId { get; set; }
        public string? MovementType { get; set; }
        public DateTime MovementDate { get; set; }
        public int Quantity { get; set; }
    }
}
