namespace Entities.Exceptions.Base;

public abstract class NotFoundException : Exception
{
    public NotFoundException(int id)
        : base($"Could not found the entity with the id: {id}.")
    { }
}
