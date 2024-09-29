using BpMeter.Domain;

namespace BpMeter.Application.Abstractions;

public interface IBpReadingService
{
    Task<BloodPressureReading> AddNewReadingAsync(BloodPressureReading reading);

    Task<List<BloodPressureReading>> GetAllReadingAsync();
}
