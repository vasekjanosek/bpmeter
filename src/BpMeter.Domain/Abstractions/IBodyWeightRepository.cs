namespace BpMeter.Domain.Abstractions;

public interface IBodyWeightRepository : IRepository<BodyWeightReading>
{
    Task<List<BodyWeightReading>> GetAllAsync();

    Task<BodyWeightReading> GetAsync(Guid id);

    Task<BodyWeightReading> GetNewestAsync();
}
