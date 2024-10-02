using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NPTN.MongoDemo.Infrastructure.Options;

namespace NPTN.MongoDemo.Infrastructure.DatabaseConnection
{
    internal class MongoConnection : IMongoConnection
    {
        public MongoClient ConnectionClient { get; private set; }
        public IMongoDatabase DatabaseInstance { get; private set; }

        public MongoConnection(IOptions<MongoDbSettings> mongoDatabaseSettings)
        {
            ConnectionClient = new MongoClient(mongoDatabaseSettings.Value.ConnectionString);
            DatabaseInstance = ConnectionClient.GetDatabase(mongoDatabaseSettings.Value.MoviesDatabaseName)
                ?? throw new ArgumentNullException("Unable to retrieve the database with the give connection string.");
        }
    }
}
