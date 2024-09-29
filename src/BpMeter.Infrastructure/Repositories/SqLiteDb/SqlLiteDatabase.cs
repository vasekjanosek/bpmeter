using BpMeter.Domain;
using SQLite;

namespace BpMeter.Infrastructure.Repositories.SqLiteDb;

internal class SqlLiteDatabase
{
    private readonly DatabaseSettings _settings;

    private SQLiteAsyncConnection _database;

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
        await _database.CreateTableAsync<DbBloodPressureReading>();
    }
}
