using SaleOnIce.Models;
using SaleOnIce.Models.DTOs;
using SaleOnIce.Repository;

namespace SaleOnIce.Services
{
    public class PurchaseServices : IPurchaseServices
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IConverter<Purchase, PurchaseDto> _converter;

        public PurchaseServices(IPurchaseRepository purchaseRepository, IConverter<Purchase, PurchaseDto> converter)
        {
            _purchaseRepository = purchaseRepository;
            _converter = converter;
        }

        public async Task<List<PurchaseDto>> GetPurchases()
        {
            var purchase = await _purchaseRepository.GetAllAsync();
            var purchaseDto = _converter.ListEntityToListDTO(purchase);
            return purchaseDto;
        }

        public async Task<PurchaseDto> GetPurchaseByIdAsync(int id)
        {
            var purchase = await _purchaseRepository.GetByIdAsync(id);
            if (purchase == null)
                throw new KeyNotFoundException($"Product with id {id} not found");
            var purchaseDto = _converter.EntityToDTO(purchase);
            return purchaseDto;
        }
    }
}