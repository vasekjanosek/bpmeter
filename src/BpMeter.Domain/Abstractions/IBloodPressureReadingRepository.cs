namespace BpMeter.Domain.Abstractions;

public interface IBloodPressureReadingRepository
{
    Task<List<BloodPressureReading>> GetAll();

    Task<BloodPressureReading> Get();

    Task<BloodPressureReading> Insert(BloodPressureReading reading);

    Task<BloodPressureReading> Update(BloodPressureReading reading);

    Task Delete(BloodPressureReading reading);
}
