using MongoDB.Driver;
using MongoDB.Bson;
using System.Data;

public class MyDbConnection : IMyDbConn
{
    private string db;
    private string user;
    private string pass;
    private string collection_name;
    private string host_name;
    private IMongoClient client;
    private readonly IMongoCollection<BsonDocument> _collection;
    public MyDbConnection(string _host_name, string _db, string _user, string _pass, string _collection_name)
    {
        db = _db;
        user = _user;
        pass = _pass;
        collection_name = _collection_name;
        host_name = _host_name;

        var connStr = $"mongodb://{user}:{pass}@{host_name}:27017?authSource={db}";

        var p = new Printer();
        p.Print(connStr);

        client = new MongoClient(connStr);

        var database = client.GetDatabase(db);
        _collection = database.GetCollection<BsonDocument>(collection_name);
    }

    public void InsertResult(string s)
    {
        var document = new BsonDocument
        {
            { "result", s }
        };

        InsertDocumentAsync(document);
    }

    private async Task InsertDocumentAsync(BsonDocument document)
    {
        var p = new Printer();
        try
        {
            _collection.InsertOne(document);
            p.Print("Success! Document inserted");
        }
        catch (Exception e)
        {
            p.Print($"Exception caught: {e}");
        }
    }
}
