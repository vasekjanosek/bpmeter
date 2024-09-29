using BpMeter.Application.Abstractions;
using BpMeter.Domain;
using BpMeter.Domain.Abstractions;

namespace BpMeter.Application
{
    internal class BpReadingService : IBpReadingService
    {
        private readonly IBloodPressureReadingRepository _bpRepository;

        public BpReadingService(IBloodPressureReadingRepository bpRepository)
        {
            _bpRepository = bpRepository;
        }

        public async Task<BloodPressureReading> AddNewReadingAsync(BloodPressureReading reading)
        {
            if (reading == null) throw new ArgumentNullException(nameof(reading));

            return await _bpRepository.InsertAsync(reading);
        }

        public async Task<List<BloodPressureReading>> GetAllReadingAsync()
        {
            return await _bpRepository.GetAllAsync();
        }
    }
}
