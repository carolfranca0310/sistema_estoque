using InventoryManagement.Domain.Enums;

namespace InventoryManagement.Domain.DTO.ProductInfo
{
    public class ProductInfoDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public string? InactivationJustification { get; set; }
    }
}
