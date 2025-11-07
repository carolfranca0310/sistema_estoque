using InventoryManagement.Domain.DTO;
using InventoryManagement.Domain.DTO.ProductInfo;
using InventoryManagement.Domain.DTO.StockMovement;
using InventoryManagement.Domain.Entity;
using InventoryManagement.Domain.Enums;
using InventoryManagement.Domain.Exceptions;
using InventoryManagement.Domain.Setup;
using InventoryManagement.Domain.Interfaces.IRepository;
using InventoryManagement.Domain.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Service.Services
{
    public class StockMovementService : IStockMovementService
    {
        private readonly IStockMovementRepository _repository;
        private readonly IProductInfoRepository _productInfoRepository;

        public StockMovementService(IStockMovementRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<StockMovementDTO>> GetProductMovementsByProductInfoIdAsync(int productInfoId, MovementType? movementType)
        {
            var stockMovementEntities = await _repository.GetProductMovementsByProductInfoIdAsync(productInfoId, movementType);

            if (stockMovementEntities == null || !stockMovementEntities.Any())
                return [];

            var stockMovementDTOs = stockMovementEntities
                .Select(p => AutoMapperConfig.StockMovementEntityFromInfoDTO(p))
                .ToList();

            return stockMovementDTOs;
        }
    }
}
