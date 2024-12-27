using BpMeter.Domain;

namespace BpMeter.Application.Abstractions;

public interface IBpReadingService
{
    Task InitializeAsync();

    Task<BloodPressureReading> AddNewReadingAsync(BloodPressureReading reading);

    Task<List<BloodPressureReading>> GetAllReadingsAsync();
}
