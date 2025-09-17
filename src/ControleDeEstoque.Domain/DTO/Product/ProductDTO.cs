namespace InventoryManagement.Domain.DTO.Product
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Brand { get; set; }
        public decimal Weight { get; set; }
    }
}
