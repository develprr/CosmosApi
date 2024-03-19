using System;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Cosmos API Connector PoC");
Connector.Run();

// New instance of CosmosClient class

public record Product(
    string Id,
    string UserId,
    string Category,
    string Name,
    int Quantity,
    bool Sale
);

public class Connector
{
    public static void Run()
    {
        var client = new MongoClient(Environment.GetEnvironmentVariable("COSMOS_CONNECTION_STRING"));
        var db = client.GetDatabase("store");

        var _products = db.GetCollection<Product>("products");

        _products.InsertOne(new Product(
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString(),
            "gear-surf-surfboards",
            "Yamba Surfboard", 
            12, 
            false
        ));
        var createdProducts = _products.FindSync(p => true);
        Console.WriteLine(JsonConvert.SerializeObject(createdProducts.ToList(), Formatting.Indented));
    }
}

