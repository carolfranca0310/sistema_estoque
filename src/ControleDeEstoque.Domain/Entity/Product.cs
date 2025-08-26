namespace InventoryManagement.Domain.Entity
{
    public class Product: Base
    {
        public string Name { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        public Product(string name, DateTime purchaseDate, DateTime expirationDate)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Product name can't be null");
            }

            Name = name;
            PurchaseDate = purchaseDate;
            ExpirationDate = expirationDate;
        }

    }
}
