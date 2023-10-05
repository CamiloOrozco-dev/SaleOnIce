using SaleOnIce.Models;
using SaleOnIce.Repository;

namespace SaleOnIce.Services
{
    public class PurchaseServices : IPurchaseServices
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseServices(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }



        public async Task<Purchase> AddPurchaseAsync(Purchase purchase)
        {

            return await _purchaseRepository.SaveAsync(purchase);
        }
        public void GenerateTotal()
        {
           
        }
    }
}
