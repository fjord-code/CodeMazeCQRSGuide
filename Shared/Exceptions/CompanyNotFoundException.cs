using Shared.Exceptions.Base;

namespace Shared.Exceptions;

public sealed class CompanyNotFoundException : NotFoundException
{
    public CompanyNotFoundException(int id) 
        : base(id)
    {
    }
}
