using BpMeter.UI.Pages;

namespace BpMeter;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection RegisterUi(this IServiceCollection services)
    {
        services.AddSingleton<MainPageViewModel>();
        services.AddSingleton<MainPage>();

        return services;
    }
}
