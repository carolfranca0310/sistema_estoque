namespace InventoryManagement.Domain.DTO
{
    public class ProductCreateDTO
    {
        public string Name { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
