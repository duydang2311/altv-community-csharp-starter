using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;
using Com.Server.AltV.Features.Accounts.Abstractions;
using Com.Shared.AltV.Dtos;
using Com.Shared.AltV.Interfaces;
using Marten;

namespace Com.Server.AltV.Features.Accounts.Scripts;

public sealed class ExampleScript : IStartup
{
    private readonly IDocumentStore store;
    public ExampleScript(IDocumentStore store)
    {
        this.store = store;
        Alt.RegisterEvents(this);
    }

    [AsyncScriptEvent(ScriptEventType.PlayerConnect)]
    private async Task OnPlayerConnectAsync(IPlayer player)
    {
        // Example code for query an account using player's name
        await using var session = store.LightweightSession();
        var account = await session.Query<Account>()
            .Where(x => x.Name == player.Name)
            .FirstOrDefaultAsync()
            .ConfigureAwait(false);

        // Example code for creating an account for the player
        // if no account exists
        if (account is null)
        {
            account = new Account
            {
                Name = player.Name
            };
            session.Store(account);
            await session.SaveChangesAsync().ConfigureAwait(false);
        }

        // Example code for sending a DTO to client using MValue adapter
        // Check AccountDto definition for how it was implemented
        player.Emit("account.dto", new AccountDto
        {
            Id = account.Id.ToString(),
            Name = account.Name
        });
    }
}
