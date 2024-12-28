using BpMeter.Application;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using BpMeter.Infrastructure.Database.SqlLite;

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

            builder.Services.ConfigureSqlLiteDatabase(FileSystem.Current.AppDataDirectory);
            builder.Services.RegisterApplication();
            builder.Services.RegisterSqlLiteDatabase();
            builder.Services.RegisterUi();

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            var app = builder.Build();

            Task.Run(async () => await app.Services.InitializeApplicationAsync()).Wait();

            return app;
        }
    }
}
