using AltV.Net;
using AltV.Net.Elements.Entities;
using Com.Server.AltV.Features.Characters.Abstractions;

namespace Com.Server.AltV.Features.Characters;

public sealed class CharacterFactory : ICharacterFactory
{
    public IPlayer Create(ICore core, nint entityPointer, uint id)
    {
        return new Character(core, entityPointer, id);
    }
}
