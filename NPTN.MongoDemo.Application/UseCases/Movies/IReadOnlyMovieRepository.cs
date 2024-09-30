using NPTN.MongoDemo.Application.UseCases.Movies.GetByTitle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPTN.MongoDemo.Application.UseCases.Movies
{
    public interface IReadOnlyMovieRepository
    {
        Task<MovieResponse> GetMovieByTitleAsync(string title, CancellationToken cancellationToken = default);
    }
}
