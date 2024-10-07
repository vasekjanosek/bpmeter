namespace BpMeter.Domain.Exceptions;

public class EntityNotFoundException : Exception
{
    public int EntityId { get; }

    public EntityNotFoundException(string message, int entityId) : base(message)
    {
        EntityId = entityId;
    }
}
