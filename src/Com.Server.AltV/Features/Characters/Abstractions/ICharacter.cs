using AltV.Net.Async;
using AltV.Net.Elements.Entities;

namespace Com.Server.AltV.Features.Characters.Abstractions;

public interface ICharacter : IPlayer, IAsyncConvertible<IPlayer>
{
    Guid AccountId { get; set; }
}
