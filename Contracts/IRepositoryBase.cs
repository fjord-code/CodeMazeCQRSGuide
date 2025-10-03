namespace Contracts;

public interface IRepositoryBase<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(bool trackChanges);
    Task<T?> GetByIdAsync(int id, bool trackChanges);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
