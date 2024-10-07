namespace BpMeter.Domain.Abstractions;

public interface IRepository<S> where S : Reading
{
    Task DeleteAsync(S reading);

    Task<S> InsertAsync(S reading);

    Task<S> UpdateAsync(S reading);
}
