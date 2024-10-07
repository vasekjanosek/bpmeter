namespace BpMeter.Domain.Exceptions;

public class EntityNotUpdatedException : Exception
{
    public int? EntityId { get; }

    public EntityNotUpdatedException(string message, int? entityId) : base(message)
    {
        EntityId = entityId;
    }
}
