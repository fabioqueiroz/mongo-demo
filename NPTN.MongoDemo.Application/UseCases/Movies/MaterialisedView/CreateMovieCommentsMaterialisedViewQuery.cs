using MediatR;
using NPTN.MongoDemo.Application.UseCases.Movies.GetByTitle;
using NPTN.MongoDemo.Domain.MaterialisedViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPTN.MongoDemo.Application.UseCases.Movies.MaterialisedView
{
    public sealed class CreateMovieCommentsMaterialisedViewQuery : IRequest<IReadOnlyCollection<MovieCommentsMaterialisedView>>
    {
        internal class CreateMovieCommentsMaterialisedViewQueryHandler : IRequestHandler<CreateMovieCommentsMaterialisedViewQuery, IReadOnlyCollection<MovieCommentsMaterialisedView>>
        {
            private readonly IMovieCommentsMaterialisedViewRepository _materialisedViewRepository;
            public CreateMovieCommentsMaterialisedViewQueryHandler(IMovieCommentsMaterialisedViewRepository materialisedViewRepository)
            {
                _materialisedViewRepository = materialisedViewRepository;
            }

            public async Task<IReadOnlyCollection<MovieCommentsMaterialisedView>> Handle(CreateMovieCommentsMaterialisedViewQuery request, CancellationToken cancellationToken)
            {
                return await _materialisedViewRepository.CreateMovieCommentsMaterialisedView(cancellationToken);
            }
        }
    }
}
