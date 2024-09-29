using BpMeter.Domain;
using BpMeter.Domain.Abstractions;

namespace BpMeter.Infrastructure.Repositories.FileRepository;

internal class CsvBpReadingRepository : IBloodPressureReadingRepository
{
    public Task Delete(BloodPressureReading reading)
    {
        throw new NotImplementedException();
    }

    public Task<BloodPressureReading> Get()
    {
        throw new NotImplementedException();
    }

    public Task<List<BloodPressureReading>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<BloodPressureReading> Insert(BloodPressureReading reading)
    {
        throw new NotImplementedException();
    }

    public Task<BloodPressureReading> Update(BloodPressureReading reading)
    {
        throw new NotImplementedException();
    }
}
