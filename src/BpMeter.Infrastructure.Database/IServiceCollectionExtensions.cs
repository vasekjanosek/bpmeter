using BpMeter.Domain.Abstractions;
using BpMeter.Infrastructure.Database.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BpMeter.Infrastructure.Database.PostgreSQL;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection RegisterDatabase(this IServiceCollection services, ServiceLifetime serviceLifetime)
    {
        services.AddDynamic<IBloodPressureRepository, BloodPressureRepository>(serviceLifetime);
        services.AddDynamic<IPersonalInformationRepository, PersonalInformationRepository>(serviceLifetime);
        services.AddDynamic<IBodyWeightRepository, BodyWeightRepository>(serviceLifetime);

        return services;
    }

    public static void AddDynamic<TInterface, TClass>(this IServiceCollection services, ServiceLifetime lifetime)
        where TClass : class, TInterface
        where TInterface : class
    {
        services.Add(new ServiceDescriptor(typeof(TInterface), typeof(TClass), lifetime));
    }
}
