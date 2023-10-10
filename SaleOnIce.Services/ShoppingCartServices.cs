using SaleOnIce.Models;
using SaleOnIce.Models.DTOs;
using SaleOnIce.Repository;
using SaleOnIce.Services.Helpers;

namespace SaleOnIce.Services
{
    public class ShoppingCartServices : IShoppingCartServices
    {
        private readonly IConverter<Product, ProductDto> _converter;

        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IProductServices _services;

        public ShoppingCartServices(IConverter<Product, ProductDto> converter, IPurchaseRepository purchaseRepository, IProductServices services)
        {
            this._converter = converter;
            this._purchaseRepository = purchaseRepository;
            _services = services;
        }

        public async Task<Purchase> GeneratePurchase(List<ProductDto> products)
        {
            double total = Utilities.CalculateTotalPurchase(products);
            var productsToUpdate = await _services.UpdateProductStockAsync(products);
            // Update range quantity
            Purchase purchase = new Purchase()
            {
                Products = productsToUpdate,
                Total = total,
                Date = DateTime.Now,
            };
            return await _purchaseRepository.SaveAsync(purchase);
        }
    }
}