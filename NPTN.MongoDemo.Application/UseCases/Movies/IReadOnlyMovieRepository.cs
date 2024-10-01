using NPTN.MongoDemo.Application.UseCases.Movies.GetByTitle;

namespace NPTN.MongoDemo.Application.UseCases.Movies
{
    public interface IReadOnlyMovieRepository
    {
        Task<MovieResponse> GetMovieByTitleAsync(string title, CancellationToken cancellationToken = default);
    }
}
