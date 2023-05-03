using ApiGateway.Models;
using MongoDB.Driver;

namespace ApiGateway.Dal;

public class Database : IDatabase
{
    private const string ConnectionString = "mongodb://localhost:27017/builds";
    private const string DatabaseName = "builds";
    private const string CollectionName = "pc_builds";
    private readonly IMongoCollection<BuildEntity> _collection;
    
    public Database()
    {
        var mongoClient = new MongoClient(ConnectionString);
        var database = mongoClient.GetDatabase(DatabaseName);
        var collectionExists = database.ListCollectionNames().ToList().Contains(CollectionName);
        
        if (!collectionExists)
        {
            database.CreateCollection(CollectionName);
        }
        
        _collection = database.GetCollection<BuildEntity>(CollectionName);
        
    }

    public Guid SaveBuild(PcBuild pcBuild)
    {
        var id = Guid.NewGuid();
        _collection.InsertOne(new BuildEntity(pcBuild, id));
        return id;
    }
    
    public PcBuild? GetBuild(Guid id)
    {
        var filter = Builders<BuildEntity>.Filter.Eq(x => x.Id, id);

        var foundBuild = _collection.Find(filter).FirstOrDefault();

        var pcBuild = foundBuild?.PcBuild;
        
        return pcBuild;
    }
}