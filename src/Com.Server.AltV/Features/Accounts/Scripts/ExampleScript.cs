using AltV.Net;
using AltV.Net.Async;
using Com.Server.AltV.Features.Accounts.Abstractions;
using Com.Server.AltV.Features.Characters.Abstractions;
using Com.Shared.AltV.Dtos;
using Marten;
using Microsoft.Extensions.Hosting;

namespace Com.Server.AltV.Features.Accounts.Scripts;

public sealed class ExampleScript(IDocumentStore store) : IHostedService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        Alt.RegisterEvents(this);
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    [AsyncScriptEvent(ScriptEventType.PlayerConnect)]
    private async Task OnPlayerConnectAsync(ICharacter character)
    {   //                                  ^^^^^^^^^^
        // Feature slices are not supposed to reference each other directly in vertical slice architecture.
        // There are many ways to solve this, my way is to put common shared code in Abstractions namespace of each slice
        // It can be a folder in a slice for now, but you can easily move it to a separate project without any further changes.
        // Pay attention to how ICharacter is put in Characters.Abstractions namespace

        // Example code for query an account using player's name
        await using var session = store.LightweightSession();
        var account = await session.Query<Account>()
            .Where(x => x.Name == character.Name)
            .FirstOrDefaultAsync()
            .ConfigureAwait(false);

        // Example code for creating an account for the player
        // if no account exists
        if (account is null)
        {
            account = new Account
            {
                Name = character.Name
            };
            session.Store(account);
            await session.SaveChangesAsync().ConfigureAwait(false);
        }

        // Example code for sending a DTO to client using MValue adapter
        // Check AccountDto definition for how it was implemented
        character.Emit("account.dto", new AccountDto
        {
            Id = account.Id.ToString(),
            Name = account.Name
        });
    }
}
