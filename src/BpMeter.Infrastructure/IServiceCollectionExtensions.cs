using BpMeter.Domain.Abstractions;
using BpMeter.Infrastructure.Repositories.Models;
using BpMeter.Infrastructure.Repositories.SqLiteDb;
using Microsoft.Extensions.DependencyInjection;

namespace BpMeter.Infrastructure;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DbMappingProfile));
        services.AddTransient<IBloodPressureReadingRepository, SqLiteBpReadingRepository>();
        services.AddSingleton<SqlLiteDatabase>();

        return services;
    }

    public static IServiceCollection ConfigureDatabase(this IServiceCollection services, string appDataDirectory)
    {
        var databaseFilename = "BpSQLite.db3";

        var flags =
        // open the database in read/write mode
        SQLite.SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
        SQLite.SQLiteOpenFlags.Create |
        // enable multi-threaded database access
        SQLite.SQLiteOpenFlags.SharedCache;

        services.AddSingleton(new DatabaseSettings(databaseFilename, flags, Path.Combine(appDataDirectory, databaseFilename)));

        return services;
    }
}
