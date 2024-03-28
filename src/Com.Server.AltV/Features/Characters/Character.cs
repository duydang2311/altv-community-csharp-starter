using AltV.Net;
using AltV.Net.Async.Elements.Entities;
using Com.Server.AltV.Features.Characters.Abstractions;

namespace Com.Server.AltV.Features.Characters;

public sealed class Character(ICore core, nint nativePointer, uint id) : AsyncPlayer(core, nativePointer, id), ICharacter
{
    public Guid AccountId { get; set; }
}
