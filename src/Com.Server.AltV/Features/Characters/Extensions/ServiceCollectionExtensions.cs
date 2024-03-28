using Com.Server.AltV.Features.Characters;
using Com.Server.AltV.Features.Characters.Abstractions;

namespace Microsoft.Extensions.DependencyInjection;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddCharacterFeatures(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<ICharacterFactory, CharacterFactory>();
        return serviceCollection;
    }
}
