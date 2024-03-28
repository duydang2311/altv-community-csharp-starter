using Com.Shared.AltV.Interfaces;

namespace Microsoft.Extensions.DependencyInjection;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddStartup<T>(this IServiceCollection serviceCollection) where T : class, IStartup
    {
        serviceCollection.AddSingleton<IStartup, T>();
        return serviceCollection;
    }
}