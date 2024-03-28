using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;
using Com.Server.AltV.Features.Accounts.Abstractions;
using Com.Shared.AltV.Interfaces;
using Marten;

namespace Com.Server.AltV.Features.Players.Scripts;

public sealed class HelloWorldScript : IStartup
{
    private readonly IDocumentStore store;
    public HelloWorldScript(IDocumentStore store)
    {
        this.store = store;
        Alt.RegisterEvents(this);
    }

    [AsyncScriptEvent(ScriptEventType.PlayerConnect)]
    private async Task HandlePlayerConnect(IPlayer player)
    {
        await using var session = store.LightweightSession();
        var account = await session.Query<Account>()
            .Where(x => x.Name == player.Name)
            .FirstOrDefaultAsync()
            .ConfigureAwait(false);
        if (account is null)
        {
            account = new Account
            {
                Name = player.Name
            };
            session.Store(account);
            await session.SaveChangesAsync().ConfigureAwait(false);
        }
        Console.WriteLine($"Account - ID: ${account.Id}, Name: ${account.Name}");
    }
}