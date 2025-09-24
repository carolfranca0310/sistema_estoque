namespace InventoryManagement.Domain.DTO
{
    public class ProductInfoCreateDTO
    {
        public int ProductId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
