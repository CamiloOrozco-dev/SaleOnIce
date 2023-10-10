namespace SaleOnIce.Services
{
    public interface IConverter<TEntity, TDTOS>
    {
        abstract TEntity DTOToEntity(TDTOS dto);

        abstract TDTOS EntityToDTO(TEntity entity);

        abstract List<TDTOS> ListEntityToListDTO(List<TEntity> entity);

        abstract List<TEntity> ListDTOToListEntity(List<TDTOS> dtos);
    }
}