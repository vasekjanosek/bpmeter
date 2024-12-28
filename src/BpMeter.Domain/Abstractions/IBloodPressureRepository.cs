namespace BpMeter.Domain.Abstractions;

public interface IBloodPressureRepository : IRepository<BloodPressureReading>
{
    Task<List<BloodPressureReading>> GetAllAsync();

    Task<BloodPressureReading> GetAsync(Guid id);
}
