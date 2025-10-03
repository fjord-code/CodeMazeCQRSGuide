using Contracts;
using Microsoft.EntityFrameworkCore;

namespace Repository.Base;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<T> _dbSet;

    protected RepositoryBase(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync(bool trackChanges)
    {
        if (trackChanges)
        {
            return await _dbSet.ToListAsync();
        }

        return await _dbSet.AsNoTracking().ToListAsync();
    }


    public async Task<T?> GetByIdAsync(int id, bool trackChanges)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
    }

    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity); 
    }
}

