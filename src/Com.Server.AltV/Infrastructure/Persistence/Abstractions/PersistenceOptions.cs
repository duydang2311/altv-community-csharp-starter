using System.ComponentModel.DataAnnotations;

namespace Com.Server.AltV.Infrastructure.Persistence.Abstractions;

public sealed class PersistenceOptions
{
    public const string Section = "Persistence";
    [Required] public required string ConnectionString { get; set; }
}