using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NPTN.MongoDemo.Infrastructure.Options;

namespace NPTN.MongoDemo.Infrastructure.Repositories
{
    internal abstract class BaseRepository
    {
        protected IMongoDatabase MongoDatabase { get; private set; }
        protected string MoviesCollection { get; private set; }
        protected string UserssCollection { get; private set; }

        public BaseRepository(IOptions<MongoDbSettings> mongoDatabaseSettings)
        {
            var mongoClient = new MongoClient(mongoDatabaseSettings.Value.ConnectionString);
            MongoDatabase = mongoClient.GetDatabase(mongoDatabaseSettings.Value.MoviesDatabaseName);
            MoviesCollection = mongoDatabaseSettings.Value.MoviesCollectionName;
            UserssCollection = mongoDatabaseSettings.Value.UsersCollectionName;
        }
    }
}
