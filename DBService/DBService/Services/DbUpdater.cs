using MongoDB.Driver;
using MongoDB.Bson;

public class DbUpdater
{
    private readonly IMongoCollection<BsonDocument> _collection;
    private readonly ILogger<MessageReceiver> _logger;

    public DbUpdater(ILogger<MessageReceiver> logger)
    {
        _logger = logger;
        var client = new MongoClient("mongodb://myuser:mypass@localhost:27017");
        var database = client.GetDatabase("test");
        _collection = database.GetCollection<BsonDocument>("numbers");
        _logger.LogInformation($"End CONS", DateTime.UtcNow.ToLongTimeString());
    }

    public void insertNumber(int n)
    {
        var document = new BsonDocument
        {
            { "latest", n }
        };
        _logger.LogInformation($"1", DateTime.UtcNow.ToLongTimeString());
        InsertDocumentAsync(document);
    }

    public async Task InsertDocumentAsync(BsonDocument document)
    {
        _logger.LogInformation($"2", DateTime.UtcNow.ToLongTimeString());
        _collection.InsertOne(document);
        _logger.LogInformation($"3", DateTime.UtcNow.ToLongTimeString());
    }
}
