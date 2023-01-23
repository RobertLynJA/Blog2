using DataFacade.DataSource;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataFacade.DB;

public class CosmosDB : IDisposable
{
    private readonly CosmosClient _client;
    private readonly string _connectionString;
    private readonly ILogger<CosmosDB> _logger;

    public CosmosDB(ILogger<CosmosDB> logger, string connectionString)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        if (connectionString == null || connectionString.Length == 0)
        {
            throw new ArgumentNullException(nameof(connectionString));
        }

        _connectionString = connectionString;
        _client = CreateDBInstance();

        _logger.LogInformation($"{nameof(StoriesDataSource)}()");
    }

    private CosmosClient CreateDBInstance()
    {
        return new(_connectionString, new CosmosClientOptions()
        {
            SerializerOptions = new CosmosSerializationOptions()
            {
                PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase,
            }
        });
    }

    private Database GetDatabase() => _client.GetDatabase("Blog");

    public Container StoriesContainer
    {
        get
        {
            return GetDatabase().GetContainer("stories");
        }
    }

    public void Dispose() => _client?.Dispose();
}
