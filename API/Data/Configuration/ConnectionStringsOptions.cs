namespace API.Data.Configuration;

public sealed class ConnectionStringsOptions
{
    public const string Position = "ConnectionStrings";

    public int CosmosConnection { get; set; }
}
