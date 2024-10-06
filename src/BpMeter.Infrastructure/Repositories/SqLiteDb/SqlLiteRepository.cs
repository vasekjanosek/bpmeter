using AutoMapper;
using BpMeter.Domain;
using BpMeter.Domain.Abstractions;
using BpMeter.Domain.Exceptions;
using BpMeter.Infrastructure.Repositories.Models;

namespace BpMeter.Infrastructure.Repositories.SqLiteDb;

internal abstract class SqlLiteRepository<T, S> : IRepository<S>
    where T : AuditableEntity 
    where S : Reading
{
    protected readonly SqlLiteDatabase Database;
    protected readonly IMapper Mapper;

    public SqlLiteRepository(SqlLiteDatabase database, IMapper mapper)
    {
        Database = database;
        Mapper = mapper;
    }

    public async Task DeleteAsync(S reading)
    {
        var connection = await Database.CreateOrGetConnectionAsync();

        var entity = Mapper.Map<T>(reading);

        if (entity.Id == null)
        {
            throw new EntityNotDeletedException($"Entity {nameof(S)} could not be deleted. It does not have filled Id.", entity.Id);
        }

        var rows = await connection.DeleteAsync(entity);
        if (rows < 1)
        {
            throw new EntityNotDeletedException($"Entity {nameof(S)} with ID '{entity.Id}' could not be deleted.", entity.Id);
        }
    }

    public async Task<S> InsertAsync(S reading)
    {
        var connection = await Database.CreateOrGetConnectionAsync();

        var entity = Mapper.Map<T>(reading);

        var rows = await connection.InsertAsync(entity);

        if (rows < 1)
        {
            throw new EntityNotInsertedException($"Entity {nameof(S)} was not inserted.");
        }

        reading = Mapper.Map<S>(entity);

        return reading;
    }

    public async Task<S> UpdateAsync(S reading)
    {
        var connection = await Database.CreateOrGetConnectionAsync();

        var entity = Mapper.Map<T>(reading);

        if (entity.Id == null)
        {
            throw new EntityNotUpdatedException($"Entity {nameof(S)} could not be update. It does not have filled Id.", entity.Id);
        }

        var rows = await connection.UpdateAsync(entity);

        if (rows < 1)
        {
            throw new EntityNotUpdatedException($"Entity {nameof(S)} with ID {entity.Id} was not updated.", entity.Id);
        }

        reading = Mapper.Map<S>(entity);

        return reading;
    }
}
