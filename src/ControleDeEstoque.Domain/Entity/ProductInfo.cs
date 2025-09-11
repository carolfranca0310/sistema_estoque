namespace InventoryManagement.Domain.Entity
{
    public class ProductInfo:Base
    {
        public int ProductId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; private set; }


        //Table relationships
        public Product? Product { get; set; }
    }
}
