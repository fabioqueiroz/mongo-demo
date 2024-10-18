using NPTN.MongoDemo.Domain.MaterialisedViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPTN.MongoDemo.Application.UseCases.Movies
{
    public interface IMovieCommentsMaterialisedViewRepository
    {
        Task<IReadOnlyCollection<MovieCommentsMaterialisedView>> CreateMovieCommentsMaterialisedView(CancellationToken cancellationToken = default);
    }
}
