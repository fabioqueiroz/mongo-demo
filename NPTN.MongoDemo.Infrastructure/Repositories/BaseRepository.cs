using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NPTN.MongoDbDemo.Api.Endpoints.Movies;
using NPTN.MongoDemo.Domain.Users;
using NPTN.MongoDemo.Infrastructure.DatabaseConnection;
using NPTN.MongoDemo.Infrastructure.Options;

namespace NPTN.MongoDemo.Infrastructure.Repositories
{
    internal abstract class BaseRepository
    {
        private readonly IMongoConnection _mongoConnection;
        protected IMongoCollection<Movie> MoviesCollection { get; private set; }
        protected IMongoCollection<User> UsersCollection { get; private set; }

        public BaseRepository(IOptions<MongoDbSettings> mongoDatabaseSettings, IMongoConnection mongoConnection)
        {
            _mongoConnection = mongoConnection;
            MoviesCollection = _mongoConnection.DatabaseInstance.GetCollection<Movie>(mongoDatabaseSettings.Value.MoviesCollectionName);
            UsersCollection = _mongoConnection.DatabaseInstance.GetCollection<User>(mongoDatabaseSettings.Value.UsersCollectionName);
        }
    }
}
