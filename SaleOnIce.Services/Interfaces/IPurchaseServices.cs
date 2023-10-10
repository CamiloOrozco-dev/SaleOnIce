using SaleOnIce.Models.DTOs;

namespace SaleOnIce.Services
{
    public interface IPurchaseServices
    {
        Task<List<PurchaseDto>> GetPurchases();

        Task<PurchaseDto> GetPurchaseByIdAsync(int id);
    }
}