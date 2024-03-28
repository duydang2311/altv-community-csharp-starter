using System.Reflection;
using AltV.Net;
using AltV.Net.Async;
using AsyncAwaitBestPractices;
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
            .AddPlayerFeatures();
        host = builder.Build();
    }

    public override void OnStart()
    {
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
}