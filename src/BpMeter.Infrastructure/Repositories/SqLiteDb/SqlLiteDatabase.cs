using BpMeter.Infrastructure.Repositories.Models;
using SQLite;

namespace BpMeter.Infrastructure.Repositories.SqLiteDb;

internal class SqlLiteDatabase
{
    private readonly DatabaseSettings _settings;

    private SQLiteAsyncConnection? _database;

    public SqlLiteDatabase(DatabaseSettings settings)
    {
        _settings = settings;
    }

    public async Task<SQLiteAsyncConnection> CreateOrGetConnectionAsync()
    {
        if (_database is not null)
            return _database;

        _database = new SQLiteAsyncConnection(_settings.DatabasePath, _settings.Flags);

        await ConfigureAsync();

        return _database;
    }

    private async Task ConfigureAsync()
    {
        if (_database == null)
            throw new Exception("Cannot configure database. Connection to the database does not exist.");

        await _database.CreateTableAsync<BloodPressureEntity>();
        await _database.CreateTableAsync<BodyWeightEntity>();
        await _database.CreateTableAsync<PersonalInformationEntity>();
    }
}
