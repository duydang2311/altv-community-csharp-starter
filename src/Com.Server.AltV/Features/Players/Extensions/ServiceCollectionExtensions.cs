using Com.Server.AltV.Features.Players.Scripts;

namespace Microsoft.Extensions.DependencyInjection;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddPlayerFeatures(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddStartup<HelloWorldScript>();
        return serviceCollection;
    }
}