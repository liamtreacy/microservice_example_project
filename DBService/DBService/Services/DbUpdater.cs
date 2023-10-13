using MongoDB.Driver;
using MongoDB.Bson;

public class DbUpdater
{
    private readonly IMongoCollection<BsonDocument> _collection;

    public DbUpdater(string connectionString, string databaseName, string collectionName)
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        _collection = database.GetCollection<BsonDocument>(collectionName);
    }

    public async Task InsertDocumentAsync(BsonDocument document)
    {
        await _collection.InsertOneAsync(document);
    }
}
