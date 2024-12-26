using BpMeter.Domain.Abstractions;
using BpMeter.Infrastructure.Database.Enitites;
using Microsoft.Extensions.DependencyInjection;

namespace BpMeter.Infrastructure.Database.SqlLite;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection RegisterSqlLiteDatabase(this IServiceCollection services)
    {
        services.RegisterDatabaseEntities();

        services.AddTransient<IBloodPressureRepository, BloodPressureRepository>();
        services.AddTransient<IPersonalInformationRepository, PersonalInformationRepository>();
        services.AddTransient<IBodyWeightRepository, BodyWeightRepository>();
        services.AddSingleton<SqlLiteDatabase>();

        return services;
    }

    public static IServiceCollection ConfigureSqlLiteDatabase(this IServiceCollection services, string appDataDirectory)
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
