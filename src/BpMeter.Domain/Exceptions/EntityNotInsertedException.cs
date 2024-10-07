namespace BpMeter.Domain.Exceptions;

public class EntityNotInsertedException : Exception
{
    public EntityNotInsertedException(string message) : base(message)
    {
    }
}
