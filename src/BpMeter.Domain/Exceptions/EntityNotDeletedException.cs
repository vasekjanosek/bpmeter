namespace BpMeter.Domain.Exceptions;

public class EntityNotDeletedException : Exception
{
    public int EntityId { get; }

    public EntityNotDeletedException(string message, int entityId) : base(message)
    {
        EntityId = entityId;
    }
}
