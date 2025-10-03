using Entities;

namespace Contracts;

public interface ICompaniesRepository : IRepositoryBase<Company>
{
    Task<Company?> GetByNameAsync(string name);
}
