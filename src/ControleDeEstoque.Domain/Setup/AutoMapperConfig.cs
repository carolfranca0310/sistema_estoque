using InventoryManagement.Domain.DTO;
using InventoryManagement.Domain.Entity;

namespace InventoryManagement.Domain.Setup
{
    public static class AutoMapperConfig
    {
        #region Product
        public static ProductDTO ProductFromDTO(Product product)
        {
            var dto = new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                ExpirationDate = product.ExpirationDate,
                PurchaseDate = product.PurchaseDate,
            };
            return dto;
        }

        public static Product ProductDTOFromEntity(ProductDTO dto)
        {
            var entity = new Product(dto.Name, dto.PurchaseDate, dto.ExpirationDate);

            entity.Id = dto.Id;
            return entity;
        }

        public static Product ProductCreateDTOFromEntity(ProductCreateDTO dtoCreate)
        {
            var entity = new Product(dtoCreate.Name, dtoCreate.PurchaseDate, dtoCreate.ExpirationDate);

            return entity;
        }

        public static Product ProductUpdateDTOFromEntity(ProductUpdateDTO dtoUpdate)
        {
            var entity = new Product(dtoUpdate.Name, dtoUpdate.PurchaseDate, dtoUpdate.ExpirationDate);

            return entity;
        }
        #endregion
    }
}
