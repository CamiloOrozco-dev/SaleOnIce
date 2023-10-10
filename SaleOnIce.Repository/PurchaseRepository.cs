using SaleOnIce.Models;

namespace SaleOnIce.Repository
{
    public class PurchaseRepository : Repository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(SaleOnIceContext context) : base(context)
        {
        }
    }
}