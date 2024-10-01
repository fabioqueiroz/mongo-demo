using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NPTN.MongoDbDemo.Api.Endpoints.Movies;
using NPTN.MongoDemo.Application.UseCases.Movies;
using NPTN.MongoDemo.Application.UseCases.Movies.GetByTitle;
using NPTN.MongoDemo.Infrastructure.Options;

namespace NPTN.MongoDemo.Infrastructure.Repositories
{
    internal class ReadOnlyMovieRepository(IOptions<MongoDbSettings> mongoDatabaseSettings) : BaseRepository(mongoDatabaseSettings), IReadOnlyMovieRepository
    {
        public async Task<MovieResponse> GetMovieByTitleAsync(string title, CancellationToken cancellationToken = default)
        {
            var projection = new FindExpressionProjectionDefinition<Movie, MovieResponse>(movie => new MovieResponse
            {
                Id = movie.Id,
                Year = movie.Year,
                Title = movie.Title,
                Plot = movie.Plot
            });

            return await MoviesCollection
                .Find(x => x.Title.Contains(title))
                .Project(projection)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
