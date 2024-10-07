using BpMeter.Domain;

namespace BpMeter.Application.Abstractions;

public interface IBwReadingService
{
    Task<BodyWeightReading> AddNewReadingAsync(BodyWeightReading reading);

    Task<List<BodyWeightReading>> GetAllReadingsAsync();
}
