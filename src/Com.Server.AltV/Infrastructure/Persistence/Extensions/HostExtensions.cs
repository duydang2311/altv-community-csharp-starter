using Com.Server.AltV.Infrastructure.Persistence.Abstractions;
using Marten;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Weasel.Core;

namespace Microsoft.Extensions.Hosting;

public static partial class HostExtensions
{
    public static IHostApplicationBuilder AddPersistence(this IHostApplicationBuilder builder)
    {
        var persistenceOptions = builder.Configuration.GetRequiredSection(PersistenceOptions.Section).Get<PersistenceOptions>();
        builder.Services
            .AddOptions<PersistenceOptions>()
            .Bind(builder.Configuration.GetSection(PersistenceOptions.Section))
            .ValidateDataAnnotations()
            .ValidateOnStart();
        builder.Services.AddMarten(options =>
        {
            if (persistenceOptions is not null)
            {
                options.Connection(persistenceOptions.ConnectionString);
            }
            if (builder.Environment.IsDevelopment())
            {
                options.AutoCreateSchemaObjects = AutoCreate.All;
            }
        });
        return builder;
    }
}