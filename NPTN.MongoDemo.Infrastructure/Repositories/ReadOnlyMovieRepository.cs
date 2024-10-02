using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using NPTN.MongoDemo.Application.UseCases.Movies;
using NPTN.MongoDemo.Application.UseCases.Movies.GetByTitle;
using NPTN.MongoDemo.Infrastructure.DatabaseConnection;
using NPTN.MongoDemo.Infrastructure.Options;

namespace NPTN.MongoDemo.Infrastructure.Repositories
{
    internal class ReadOnlyMovieRepository(IOptions<MongoDbSettings> mongoDatabaseSettings, IMongoConnection mongoConnection) 
        : BaseRepository(mongoDatabaseSettings, mongoConnection), IReadOnlyMovieRepository
    {
        public async Task<MovieResponse> GetMovieByTitleAsync(string title, CancellationToken cancellationToken = default)
        {
            return await MoviesCollection
                .AsQueryable()
                .Where(x => x.Title.Equals(title))
                .Select(movie => new MovieResponse
                {
                    Id = movie.Id,
                    Year = movie.Year,
                    Title = movie.Title,
                    Plot = movie.Plot
                })
                .SingleOrDefaultAsync(cancellationToken);
        }
    }
}
