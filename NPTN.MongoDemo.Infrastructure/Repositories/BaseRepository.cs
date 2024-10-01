﻿using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NPTN.MongoDbDemo.Api.Endpoints.Movies;
using NPTN.MongoDemo.Domain.Users;
using NPTN.MongoDemo.Infrastructure.Options;

namespace NPTN.MongoDemo.Infrastructure.Repositories
{
    internal abstract class BaseRepository
    {
        protected IMongoCollection<Movie> MoviesCollection { get; private set; }
        protected IMongoCollection<User> UsersCollection { get; private set; }

        public BaseRepository(IOptions<MongoDbSettings> mongoDatabaseSettings)
        {
            var mongoClient = new MongoClient(mongoDatabaseSettings.Value.ConnectionString);
            var db = mongoClient.GetDatabase(mongoDatabaseSettings.Value.MoviesDatabaseName);
            MoviesCollection = db.GetCollection<Movie>(mongoDatabaseSettings.Value.MoviesCollectionName);
            UsersCollection = db.GetCollection<User>(mongoDatabaseSettings.Value.UsersCollectionName);
        }
    }
}
