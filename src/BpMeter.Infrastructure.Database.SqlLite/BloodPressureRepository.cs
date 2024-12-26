using AutoMapper;
using BpMeter.Domain;
using BpMeter.Domain.Abstractions;
using BpMeter.Domain.Exceptions;
using BpMeter.Infrastructure.Database.Enitites;

namespace BpMeter.Infrastructure.Database.SqlLite
{
    internal class BloodPressureRepository : SqlLiteRepository<BloodPressureEntity, BloodPressureReading>, IBloodPressureRepository
    {
        public BloodPressureRepository(SqlLiteDatabase database, IMapper mapper) : base (database, mapper)
        {
        }

        public async Task<BloodPressureReading> GetAsync(int id)
        {
            var connection = await Database.CreateOrGetConnectionAsync();
            BloodPressureEntity result;

            try
            {
                result = await connection.GetAsync<BloodPressureEntity>(id);
            }
            catch (Exception)
            {
                throw new EntityNotFoundException($"Entity BloodPressure with ID {id} was not found.", id);
            }

            var reading = Mapper.Map<BloodPressureReading>(result);

            return reading;
        }

        public async Task<List<BloodPressureReading>> GetAllAsync()
        {
            var connection = await Database.CreateOrGetConnectionAsync();
            var result = await connection.QueryAsync<BloodPressureEntity>($"select * from {nameof(BloodPressureEntity)}");

            return result.Select(x => Mapper.Map<BloodPressureReading>(x)).ToList();
        }
    }
}
