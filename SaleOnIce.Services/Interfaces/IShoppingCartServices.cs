using SaleOnIce.Models;
using SaleOnIce.Models.DTOs;

namespace SaleOnIce.Services
{
    public interface IShoppingCartServices
    {
        Task<Purchase> GeneratePurchase(List<ProductDto> products);
    }
}