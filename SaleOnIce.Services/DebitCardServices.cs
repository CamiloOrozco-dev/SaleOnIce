using SaleOnIce.Models;
using SaleOnIce.Models.DTOs;
using SaleOnIce.Repository;
using SaleOnIce.Services.Interfaces;

namespace SaleOnIce.Services
{
    public class DebitCardServices : IDebitCardServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserServices _services;

        public DebitCardServices(IUserRepository userRepository, IUserServices services)
        {
            _userRepository = userRepository;
            _services = services;
        }

        public async Task<DebitCard> AddDebitCardAsync(UserDto user, DebitCardDto debitCardDto)
        {
            var userDb = await _userRepository.GetAllAsync();
            var userExisting = userDb.FirstOrDefault(u => u.Id == user.UserId);

            if (userExisting != null)
            {
                if (userExisting.debitCard == null)
                {
                    userExisting.debitCard = new DebitCard();
                }

                userExisting.debitCard.CardHolderName = debitCardDto.CardHolderName;
                userExisting.debitCard.CardNumber = debitCardDto.CardNumber;
                userExisting.debitCard.CVC = debitCardDto.CVC;

            }

            return await _userRepository.UpdateUserDebitCardAsync()
    }
}