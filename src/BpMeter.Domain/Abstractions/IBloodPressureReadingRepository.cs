namespace BpMeter.Domain.Abstractions;

public interface IBloodPressureReadingRepository
{
    Task<List<BloodPressureReading>> GetAllAsync();

    Task<BloodPressureReading> GetAsync(int id);

    Task<BloodPressureReading> InsertAsync(BloodPressureReading reading);

    Task<BloodPressureReading> UpdateAsync(BloodPressureReading reading);

    Task DeleteAsync(BloodPressureReading reading);
}
