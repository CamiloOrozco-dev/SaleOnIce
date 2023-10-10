using SaleOnIce.Models.DTOs;
using SaleOnIce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOnIce.Services.Helpers.Converters
{
    public class DebitCardConverter : IConverter<DebitCard, DebitCardDto>
    {
        public DebitCard DTOToEntity(DebitCardDto dto)
        {
            throw new NotImplementedException();
        }

        public DebitCardDto EntityToDTO(DebitCard entity)
        {
            throw new NotImplementedException();
        }

        public List<DebitCard> ListDTOToListEntity(List<DebitCardDto> dtos)
        {
            throw new NotImplementedException();
        }

        public List<DebitCardDto> ListEntityToListDTO(List<DebitCard> entity)
        {
            throw new NotImplementedException();
        }
    }
}
