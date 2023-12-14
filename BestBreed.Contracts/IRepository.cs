namespace BestBreed.Contracts
{
    public interface IRepository<T> where T : class
    {
        T GetById<TEntity>(Guid id);
        Task<IEnumerable<T>> GetAllAsync<TEntity>();
        Task<T> AddAsync<TEntity>(T entity);
        Task<T> UpdateAsync<TEntity>(T entity);
        Task DeleteAsync<TEntity>(T entity);
    }
}