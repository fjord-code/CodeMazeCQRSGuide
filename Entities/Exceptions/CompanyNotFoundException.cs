using Entities.Exceptions.Base;

namespace Entities.Exceptions;

public sealed class CompanyNotFoundException : NotFoundException
{
    public CompanyNotFoundException(int id) 
        : base(id)
    {
    }
}
