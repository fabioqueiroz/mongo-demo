using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NPTN.MongoDbDemo.Api.Endpoints.Movies;
using NPTN.MongoDemo.Domain.Users;
using NPTN.MongoDemo.Infrastructure.Options;

namespace NPTN.MongoDemo.Infrastructure.Repositories
{
    internal abstract class BaseRepository
    {
        protected IMongoDatabase MongoDatabase { get; private set; }
        protected string MoviesCollectionName { get; private set; }
        protected string UsersCollectionName { get; private set; }
        protected IMongoCollection<Movie?> MoviesCollection { get => GetMoviesCollection(); }
        protected IMongoCollection<User?> UsersCollection {  get => GetUsersCollection(); }

        public BaseRepository(IOptions<MongoDbSettings> mongoDatabaseSettings)
        {
            var mongoClient = new MongoClient(mongoDatabaseSettings.Value.ConnectionString);
            MongoDatabase = mongoClient.GetDatabase(mongoDatabaseSettings.Value.MoviesDatabaseName);
            MoviesCollectionName = mongoDatabaseSettings.Value.MoviesCollectionName;
            UsersCollectionName = mongoDatabaseSettings.Value.UsersCollectionName;
        }

        private IMongoCollection<Movie?> GetMoviesCollection()
            => MongoDatabase.GetCollection<Movie?>(MoviesCollectionName);

        private IMongoCollection<User?> GetUsersCollection()
            => MongoDatabase.GetCollection<User?>(UsersCollectionName);
    }
}
