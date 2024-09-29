using BpMeter.Application;
using BpMeter.Infrastructure;
using BpMeter.Infrastructure.Repositories;
using CommunityToolkit.Maui;
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

            builder.Services.ConfigureDatabase(FileSystem.Current.AppDataDirectory);
            builder.Services.RegisterApplication();
            builder.Services.RegisterInfrastructure();
            builder.Services.RegisterUi();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
