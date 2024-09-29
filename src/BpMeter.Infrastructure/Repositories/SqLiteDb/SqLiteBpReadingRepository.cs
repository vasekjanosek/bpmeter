using AutoMapper;
using BpMeter.Domain;
using BpMeter.Domain.Abstractions;
using BpMeter.Domain.Exceptions;

namespace BpMeter.Infrastructure.Repositories.SqLiteDb
{
    internal class SqLiteBpReadingRepository : IBloodPressureReadingRepository
    {
        private readonly SqlLiteDatabase _database;
        private readonly IMapper _mapper;

        public SqLiteBpReadingRepository(SqlLiteDatabase database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public async Task DeleteAsync(BloodPressureReading reading)
        {
            var connection = await _database.CreateOrGetConnectionAsync();

            var entity = _mapper.Map<DbBloodPressureReading>(reading);

            var rows = await connection.DeleteAsync(entity);
            if (rows < 1)
            {
                throw new EntityNotDeletedException($"Entity BloodPressure with ID {entity.Id.Value} could not be deleted.", entity.Id.Value);
            }
        }

        public async Task<BloodPressureReading?> GetAsync(int id)
        {
            var connection = await _database.CreateOrGetConnectionAsync();
            DbBloodPressureReading result = null;

            try
            {
                result = await connection.GetAsync<DbBloodPressureReading>(id);
            }
            catch (Exception ex)
            {
                throw new EntityNotFoundException($"Entity BloodPressure with ID {id} was not found.", id);
            }

            var reading = _mapper.Map<BloodPressureReading>(result);

            return reading;
        }

        public async Task<List<BloodPressureReading>> GetAllAsync()
        {
            var connection = await _database.CreateOrGetConnectionAsync();
            var result = await connection.QueryAsync<DbBloodPressureReading>("select * from DbBloodPressureReading");

            return result.Select(x => _mapper.Map<BloodPressureReading>(x)).ToList();
        }

        public async Task<BloodPressureReading?> InsertAsync(BloodPressureReading reading)
        {
            var connection = await _database.CreateOrGetConnectionAsync();

            var entity = _mapper.Map<DbBloodPressureReading>(reading);

            var rows = await connection.InsertAsync(entity);

            if (rows < 1)
            {
                return null;
            }

            reading = _mapper.Map<BloodPressureReading>(entity);

            return reading;
        }

        public async Task<BloodPressureReading> UpdateAsync(BloodPressureReading reading)
        {
            var connection = await _database.CreateOrGetConnectionAsync();

            var entity = _mapper.Map<DbBloodPressureReading>(reading);

            var rows = await connection.UpdateAsync(entity);

            if (rows < 1)
            {
                return null;
            }

            reading = _mapper.Map<BloodPressureReading>(entity);

            return reading;
        }
    }
}
