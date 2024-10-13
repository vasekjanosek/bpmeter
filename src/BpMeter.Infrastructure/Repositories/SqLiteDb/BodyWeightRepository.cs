using BpMeter.Domain.Abstractions;
using BpMeter.Domain;
using BpMeter.Infrastructure.Repositories.Models;
using AutoMapper;
using BpMeter.Domain.Exceptions;

namespace BpMeter.Infrastructure.Repositories.SqLiteDb;

internal class BodyWeightRepository : SqlLiteRepository<BodyWeightEntity, BodyWeightReading>, IBodyWeightRepository
{
    public BodyWeightRepository(SqlLiteDatabase database, IMapper mapper) : base(database, mapper)
    {
    }

    public async Task<List<BodyWeightReading>> GetAllAsync()
    {
        var connection = await Database.CreateOrGetConnectionAsync();
        var result = await connection.QueryAsync<BodyWeightEntity>($"select * from {nameof(BodyWeightEntity)}");

        return result.Select(x => Mapper.Map<BodyWeightReading>(x)).ToList();
    }

    public async Task<BodyWeightReading> GetNewestAsync()
    {
        var connection = await Database.CreateOrGetConnectionAsync();
        var result = await connection.QueryAsync<BodyWeightEntity>($"select * from {nameof(BodyWeightEntity)}");

        return result.Select(x => Mapper.Map<BodyWeightReading>(x)).OrderBy(x => x.DateTime).First();
    }

    public async Task<BodyWeightReading> GetAsync(int id)
    {
        var connection = await Database.CreateOrGetConnectionAsync();
        BodyWeightEntity result;

        try
        {
            result = await connection.GetAsync<BodyWeightEntity>(id);
        }
        catch (Exception)
        {
            throw new EntityNotFoundException($"Entity BodyWeight with ID {id} was not found.", id);
        }

        var reading = Mapper.Map<BodyWeightReading>(result);

        return reading;
    }
}
