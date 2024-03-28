using AltV.Community.MValueAdapters.Generators;
using AltV.Community.MValueAdapters.Generators.Abstractions;

namespace Com.Shared.AltV.Dtos;

[MValueAdapter(NamingConvention = NamingConvention.LowerCase)]
public sealed class AccountDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}
