using InventoryManagement.Domain.DTO;
using InventoryManagement.Domain.DTO.Product;
using InventoryManagement.Domain.DTO.ProductInfo;
using InventoryManagement.Domain.Entity;
using InventoryManagement.Domain.Utils.Extensions;

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
                Brand = product.Brand,
                Weight = product.Weight
            };
            return dto;
        }

        public static Product ProductDTOFromEntity(ProductDTO dto)
        {
            var entity = new Product(dto.Name, dto.Brand, dto.Weight);

            entity.Id = dto.Id;
            return entity;
        }

        public static Product ProductCreateDTOFromEntity(ProductCreateDTO dtoCreate)
        {
            var entity = new Product(dtoCreate.Name, dtoCreate.Brand, dtoCreate.Weight);

            return entity;
        }

        public static Product ProductUpdateDTOFromEntity(ProductUpdateDTO dtoUpdate)
        {
            var entity = new Product(dtoUpdate.Name, dtoUpdate.Brand, dtoUpdate.Weight);

            return entity;
        }
        #endregion
        #region ProductInfo
        public static ProductInfoDTO? ProductInfoEntityFromInfoDTO(ProductInfo? productInfo)
        {
            if (productInfo == null)
                return null;

            var dto = new ProductInfoDTO
            {
                Id = productInfo.Id,
                ProductId = productInfo.ProductId,
                PurchaseDate = productInfo.PurchaseDate,
                ExpirationDate = productInfo.ExpirationDate,
                Quantity = productInfo.Quantity,
                UnitPrice = productInfo.UnitPrice,
                TotalPrice = productInfo.TotalPrice,
                Status = productInfo.Status.GetDescription(),
                InactivationJustification = productInfo.InactivationJustification
            };
            return dto;
        }
        public static ProductInfo ProductInfoDTOFromEntity(ProductInfoDTO dto)
        {
            var entity = new ProductInfo(dto.ProductId, dto.PurchaseDate, dto.ExpirationDate, dto.Quantity, dto.UnitPrice);

            entity.Id = dto.Id;
            return entity;
        }

        public static ProductInfo ProductInfoCreateDTOFromEntity(ProductInfoCreateDTO dtoCreate)
        {
            var entity = new ProductInfo(dtoCreate.ProductId, dtoCreate.PurchaseDate, dtoCreate.ExpirationDate, dtoCreate.Quantity, dtoCreate.UnitPrice);

            return entity;
        }

        public static ProductInfo ProductInfoUpdateDTOFromEntity(ProductInfoUpdateDTO dtoUpdate)
        {
            var entity = new ProductInfo(dtoUpdate.ProductId, dtoUpdate.ExpirationDate, dtoUpdate.PurchaseDate, dtoUpdate.Quantity, dtoUpdate.UnitPrice);

            return entity;
        } 
        #endregion
    }
}
