namespace InventoryManagement.Domain.Entity
{
    public class Product: Base
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Weight { get; set; }

        public Product(string name, string brand, decimal weight)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Product name can't be null");
            }

            Name = name;
            Brand = brand;
            Weight = weight;
        }

    }
}
