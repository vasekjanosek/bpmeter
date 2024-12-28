using BpMeter.Application.Abstractions;
using BpMeter.Domain;
using BpMeter.Domain.Abstractions;

namespace BpMeter.Application;

public class BwReadingService : IBwReadingService
{
    private readonly IBodyWeightRepository _bodyWeightRepository;

    public BwReadingService(IBodyWeightRepository bodyWeightRepository)
    {
        _bodyWeightRepository = bodyWeightRepository;
    }

    public async Task<BodyWeightReading> AddNewReadingAsync(BodyWeightReading reading)
    {
        if (reading == null) throw new ArgumentNullException(nameof(reading));

        return await _bodyWeightRepository.InsertAsync(reading);
    }

    public async Task<List<BodyWeightReading>> GetAllReadingsAsync()
    {
        return await _bodyWeightRepository.GetAllAsync();
    }

    public async Task<BodyWeightReading> GetLastReadingAsync()
    {
        return await _bodyWeightRepository.GetNewestAsync();
    }

    public Task InitializeAsync()
    {
        return Task.CompletedTask;
    }
}
