namespace BpMeter.Domain.Exceptions;

public class EntityAlreadyExistsException : Exception
{
    public Guid EntityId { get; }

    public EntityAlreadyExistsException(string message, Guid entityId) : base(message)
    {
        EntityId = entityId;
    }
}
