using System;
using MongoDB.Driver;

public class DbConnector : IDbConnector
{
    private readonly ILogger<MessageReceiver> _logger;

    public DbConnector(ILogger<MessageReceiver> logger)
    {
        _logger = logger;
    }

    public void UpdateDb(int num)
    {
        // Connect
        string connectionString = "mongodb://root:example@localhost:27017";
        MongoClient client = new MongoClient(connectionString);
        IMongoDatabase database = client.GetDatabase("mydatabase");
        //Console.WriteLine("Connection successful!");

        _logger.LogInformation("Connected to Mongo!", DateTime.UtcNow.ToLongTimeString());
        
        // Update
    }
}