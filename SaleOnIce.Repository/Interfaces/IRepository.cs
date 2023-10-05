namespace SaleOnIce.Repository
{
    public interface IRepository<TEntity>
    {
        Task<List<TEntity>> GetAllAsync();

        Task<TEntity?> GetByIdAsync(int id);

        Task<TEntity> SaveAsync(TEntity entity);

        Task<TEntity?> UpdateAsync(int id, TEntity entity);

        Task DeleteAsync(int id);

        Task<bool> ExistsAsync(int id);
    }
}