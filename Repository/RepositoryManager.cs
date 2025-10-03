using Contracts;

namespace Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly AppDbContext _context;
    private Lazy<ICompaniesRepository> _companies;

    public ICompaniesRepository Companies => _companies.Value;

    public RepositoryManager(AppDbContext context)
    {
        _context = context;
        _companies = new Lazy<ICompaniesRepository>(() => new CompaniesRepository(_context));
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}

