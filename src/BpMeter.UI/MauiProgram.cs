using BpMeter.Application;
using BpMeter.Infrastructure.Database.Entites;
using BpMeter.Infrastructure.Database.PostgreSQL;
using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BpMeter.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddDbContextPool<BpMeterDbContext>(opt =>
                opt.UseSqlite(
                    $"Data Source={Path.Combine(FileSystem.Current.AppDataDirectory, "BpSQLite.db3")}",
                    x => x.MigrationsAssembly("BpMeter.Infrastructure.Database.SQLiteMigrations")));

            builder.Services.RegisterApplication();
            builder.Services.RegisterDatabase(ServiceLifetime.Transient);
            builder.Services.RegisterUi();

            builder.Services.AddAutoMapper(typeof(DbMappingProfile));

#if DEBUG
            builder.Logging.AddDebug();
#endif
            var app = builder.Build();

            Task.Run(async () =>
            {
                var dbContext = app.Services.GetRequiredService<BpMeterDbContext>();

                dbContext.Database.EnsureCreated();

                /*var appMig = dbContext.Database.GetAppliedMigrations();

                var pendMig = dbContext.Database.GetPendingMigrations();

                var mig = dbContext.Database.GetMigrations();

                if ((await dbContext.Database.GetPendingMigrationsAsync()).Any())
                {
                    dbContext.Database.Migrate();
                }*/
                await app.Services.InitializeApplicationAsync();
            }).Wait();

            return app;
        }
    }
}
