using NPTN.MongoDemo.Application.Movies.GetByTitle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPTN.MongoDemo.Application.Services
{
    public interface IMovieService
    {
        Task<MovieResponse> GetMovieByTitleAsync(string title, CancellationToken cancellationToken = default);
    }
}
