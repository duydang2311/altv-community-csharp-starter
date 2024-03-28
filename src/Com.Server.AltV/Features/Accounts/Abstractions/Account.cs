namespace Com.Server.AltV.Features.Accounts.Abstractions;

public sealed class Account
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}