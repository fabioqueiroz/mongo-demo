using MediatR;
using NPTN.MongoDemo.Application.Services;

namespace NPTN.MongoDemo.Application.Movies.GetByTitle
{
    public sealed class GetMovieByTitleQuery : IRequest<MovieResponse>
    {
        public string Title { get; init; } = string.Empty;

        public GetMovieByTitleQuery(string title)
        {
            Title = title;
        }

        internal class GetMovieByTitleQueryHandler : IRequestHandler<GetMovieByTitleQuery, MovieResponse>
        {
            private readonly IMovieService _movieService;
            public GetMovieByTitleQueryHandler(IMovieService movieService)
            {
                _movieService = movieService;
            }
            public async Task<MovieResponse> Handle(GetMovieByTitleQuery request, CancellationToken cancellationToken)
            {
                return await _movieService.GetMovieByTitleAsync(request.Title, cancellationToken);
            }
        }
    }
}
