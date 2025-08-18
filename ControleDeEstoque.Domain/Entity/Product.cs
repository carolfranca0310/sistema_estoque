namespace InventoryManagement.Domain.Entity
{
    public class Product: Base
    {
        public string Name { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime ExpirationDate { get; set; }

    }
}
