using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Base;

namespace Repository
{
    public class CompaniesRepository : RepositoryBase<Company>, ICompaniesRepository
    {
        public CompaniesRepository(AppDbContext context) : base(context) { }

        public async Task<Company?> GetByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return null;

            var lower = name.ToLower();
            return await _dbSet.FirstOrDefaultAsync(c => c.Name.ToLower() == lower);
        }
    }
}
