using SaleOnIce.Models;

namespace SaleOnIce.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(SaleOnIceContext context) : base(context)
        {
        }

        public Task<DebitCard> AddDebitCardAsync(DebitCard debitCard, int idUser)
        {
            throw new NotImplementedException();
        }

        public Task<DebitCard> GetDebitCardAsync(DebitCard debitCard)
        {
            throw new NotImplementedException();
        }
    }
}