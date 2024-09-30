//using Microsoft.Extensions.Options;
//using MongoDB.Driver;
//using NPTN.MongoDbDemo.Api.Endpoints.Movies;
//using NPTN.MongoDemo.Application.Options;
//using NPTN.MongoDemo.Application.UseCases.Movies.GetByTitle;

//namespace NPTN.MongoDemo.Application.Services
//{
//    public class MovieService : IMovieService
//    {
//        private readonly IMongoDatabase _mongoDatabase;
//        private readonly string _moviesCollection;
//        public MovieService(IOptions<MongoDbSettings> mongoDatabaseSettings)
//        {
//            var mongoClient = new MongoClient(mongoDatabaseSettings.Value.ConnectionString);
//            _mongoDatabase = mongoClient.GetDatabase(mongoDatabaseSettings.Value.MoviesDatabaseName);
//            _moviesCollection = mongoDatabaseSettings.Value.MoviesCollectionName;
//        }

//        public async Task<MovieResponse> GetMovieByTitleAsync(string title, CancellationToken cancellationToken = default)
//        {
//            var collection = _mongoDatabase.GetCollection<Movie>(_moviesCollection);
//            var filter = Builders<Movie>.Filter.Eq("title", title);
//            var document = await collection.Find(filter).FirstAsync(cancellationToken);

//            var projection = new FindExpressionProjectionDefinition<Movie, MovieResponse>(movie => new MovieResponse
//            {
//                Id = movie.Id,
//                Year = movie.Year,
//                Title = movie.Title,
//                Plot = movie.Plot
//            });

//            return await collection
//                .Find(filter)
//                .Project(projection)
//                .FirstOrDefaultAsync(cancellationToken);
//        }
//    }
//}
