using SaleOnIce.Models;

namespace SaleOnIce.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<DebitCard> GetDebitCardAsync(DebitCard debitCard);
        Task <DebitCard> AddDebitCardAsync (DebitCard debitCard, int idUser);   


    }
}