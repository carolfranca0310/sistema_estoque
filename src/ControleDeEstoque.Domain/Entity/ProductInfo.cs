using System.Xml.Linq;

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

        public ProductInfo(int productId, DateTime purchaseDate, DateTime expirationDate, int quantity, decimal unitPrice)
        {
            ProductId = productId;
            PurchaseDate = purchaseDate;
            ExpirationDate = expirationDate;
            Quantity = quantity;
            UnitPrice = unitPrice;
            TotalPrice = unitPrice * quantity;
        }

        public void RecalculateTotal()
        {
            TotalPrice = UnitPrice * Quantity;
        }
    }
}
