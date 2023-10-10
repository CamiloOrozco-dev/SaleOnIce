using SaleOnIce.Models.DTOs;

namespace SaleOnIce.Services.Helpers
{
    public class Utilities
    {
        public static bool ProductIsInStock(int stock)
        {
            return stock > 0;
        }

        public static double CalculateTotalPurchase(List<ProductDto> products)
        {
            return products.Sum(product => product.Price * product.CountProduct);
        }
    }
}