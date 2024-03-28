using System.Reflection;
using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;
using AsyncAwaitBestPractices;
using Com.Server.AltV.Features.Characters.Abstractions;
using Com.Shared.AltV.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Com.Server.AltV;

public sealed class ServerResource : AsyncResource
{
    private readonly IHost host;
    public ServerResource()
    {
        var builder = Host.CreateApplicationBuilder(new HostApplicationBuilderSettings
        {
            ContentRootPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
        });

        builder.AddPersistence();
        builder.Services
            .AddAccountFeatures()
            .AddCharacterFeatures();

        host = builder.Build();
    }

    public override void OnStart()
    {
        ResourceHelper.RegisterAdapters();
        host.RunAsync().SafeFireAndForget((exception) =>
        {
            Alt.LogError(exception.ToString());
            Alt.StopResource(Alt.Resource.Name);
        });
    }

    public override void OnStop()
    {
        host.StopAsync().Wait();
        host.Dispose();
    }

    public override IEntityFactory<IPlayer> GetPlayerFactory()
    {
        return host.Services.GetRequiredService<ICharacterFactory>();
    }
}
