using InventoryManagement.Domain.DTO.StockMovement;
using InventoryManagement.Domain.Entity;
using InventoryManagement.Domain.Enums;
using InventoryManagement.Domain.Exceptions;
using InventoryManagement.Domain.Interfaces.IRepository;
using InventoryManagement.Domain.Interfaces.IService;
using InventoryManagement.Domain.Setup;
using InventoryManagement.Domain.Utils.Extensions;

namespace InventoryManagement.Service.Services
{
    public class StockMovementService : IStockMovementService
    {
        private readonly IStockMovementRepository _repository;
        private readonly IProductInfoRepository _productInfoRepository;

        public StockMovementService(IStockMovementRepository repository, IProductInfoRepository productInfoRepository)
        {
            _repository = repository;
            _productInfoRepository = productInfoRepository;
        }

        public async Task<List<StockMovementDTO>> GetProductMovementsByProductInfoIdAsync(int productInfoId, MovementType? movementType)
        {
            var stockMovementEntities = await _repository.GetProductMovementsByProductInfoIdAsync(productInfoId, movementType);

            if (stockMovementEntities.IsNullOrEmpty())
                return [];

            var stockMovementDTOs = stockMovementEntities
                                    .Select(p => AutoMapperConfig.StockMovementEntityFromInfoDTO(p))
                                    .ToList();

            return stockMovementDTOs!;
        }

        public async Task<StockMovementDTO> UpdateRegisterMovementAsync(int productInfoId, StockMovementUpdateDTO updateDto)
        {
            var productInfo = await _productInfoRepository.GetByIdAsync(productInfoId) ?? throw new NotFoundException($"Produto com ID {productInfoId} não encontrado.");

            ValidateStockMovement(productInfo, updateDto);

            StockMovement? stockMovement = null;

            int diff = updateDto.Quantity - productInfo.Quantity;

            if (diff > 0)
            {
                stockMovement = new StockMovement
                {
                    ProductInfoId = productInfoId,
                    MovementType = MovementType.Inbound,
                    Quantity = diff,
                    MovementDate = DateTime.UtcNow
                };
            }
            else if (diff < 0)
            {
                stockMovement = new StockMovement
                {
                    ProductInfoId = productInfoId,
                    MovementType = MovementType.Outbound,
                    Quantity = Math.Abs(diff),
                    MovementDate = DateTime.UtcNow
                };
            }

            await UpdateProductInfoStatusAndQuantityAsync(productInfo, updateDto.Quantity);

            if (stockMovement != null)
            {
                await _repository.AddAsync(stockMovement);
            }

            return AutoMapperConfig.StockMovementEntityFromInfoDTO(stockMovement)!;
        }
        private static void ValidateStockMovement(ProductInfo productInfo, StockMovementUpdateDTO updateDto)
        {
            if (updateDto.Quantity < 0)
            {
                throw new BadRequestException("Quantidade não pode ser menor do que 0.");
            }

            if (productInfo.Status != Status.Active)
            {
                throw new BadRequestException("Apenas lotes ativos podem ser alterados.");
            }
        }

        private async Task UpdateProductInfoStatusAndQuantityAsync(ProductInfo productInfo, int quantity)
        {
            if (quantity == 0)
            {
                productInfo.Status = Status.Cleared;
            }

            productInfo.Quantity = quantity;
            await _productInfoRepository.UpdateAsync(productInfo.Id, productInfo);
        }
    }
}
