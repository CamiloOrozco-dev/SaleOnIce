using SaleOnIce.Models;
using SaleOnIce.Models.DTOs;

namespace SaleOnIce.Services.Interfaces
{
    public interface IDebitCardServices 
    {
        Task<DebitCard> AddDebitCardAsync(UserDto user, DebitCardDto debitCard);
    }
}
