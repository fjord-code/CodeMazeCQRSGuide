namespace Contracts;

public interface IRepositoryManager
{
    ICompaniesRepository Companies { get; }
    Task SaveAsync();
}
