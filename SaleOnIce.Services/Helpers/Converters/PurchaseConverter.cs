using SaleOnIce.Models;
using SaleOnIce.Models.DTOs;

namespace SaleOnIce.Services.Helpers
{
    public class PurchaseConverter : IConverter<Purchase, PurchaseDto>
    {
        public Purchase DTOToEntity(PurchaseDto dto)
        {
            return new Purchase
            {
                Id = dto.Id,
                Products = dto.Products,
                Date = dto.Date,
                Total = dto.Total,
            };
        }

        public PurchaseDto EntityToDTO(Purchase entity)
        {
            return new PurchaseDto
            {
                Id = entity.Id,
                Products = entity.Products,
                Date = entity.Date,
                Total = entity.Total,
            };
        }

        public List<Purchase> ListDTOToListEntity(List<PurchaseDto> purchasesDto)
        {
            List<Purchase> listEntity = new();

            foreach (var purchaseDto in purchasesDto)
            {
                var purchase = DTOToEntity(purchaseDto);

                listEntity.Add(purchase);
            }

            return listEntity;
        }

        public List<PurchaseDto> ListEntityToListDTO(List<Purchase> purchases)
        {
            List<PurchaseDto> listDto = new();

            foreach (var purchase in purchases)
            {
                var purchaseDto = EntityToDTO(purchase);

                listDto.Add(purchaseDto);
            }

            return listDto;
        }
    }
}