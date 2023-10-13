using System;
using MongoDB.Driver;

namespace MongoDBConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "mongodb://root:example@localhost:27017";
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase("mydatabase");
            Console.WriteLine("Connection successful!");
        }
    }
}
