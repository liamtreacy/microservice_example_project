using System;
using MongoDB.Driver;
using MongoDB.Bson;

public class DbConnector : IDbConnector
{
    private readonly ILogger<MessageReceiver> _logger;

    public DbConnector(ILogger<MessageReceiver> logger)
    {
        _logger = logger;
    }

    public async Task UpdateDb(int num)
    {
        // Connect
        string connectionString = "mongodb://admin:pass@localhost:27017";
        MongoClient client = new MongoClient(connectionString);
        IMongoDatabase database = client.GetDatabase("rng_stats");
        //Console.WriteLine("Connection successful!");

        _logger.LogInformation("Connected to Mongo!", DateTime.UtcNow.ToLongTimeString());

        var collection = database.GetCollection<BsonDocument> ("numbers");
_logger.LogInformation("..1");
        var document = new BsonDocument { { "latest", num } };
_logger.LogInformation("..2");
            try
            {
                await collection.InsertOneAsync(document);
            }
            catch (MongoWriteException e)
            {
                _logger.LogInformation(e.Message);
            }
        _logger.LogInformation("Updated Mongo!", DateTime.UtcNow.ToLongTimeString());
        // Update
    }
}