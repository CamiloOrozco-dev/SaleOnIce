using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOnIce.Models.Helpers
{
    public interface IConverter<TEntity, TDTOS>
    {
        abstract TEntity DTOToEntity(TDTOS dto);
        abstract TDTOS EntityToDTO(TEntity entity);

    }
}