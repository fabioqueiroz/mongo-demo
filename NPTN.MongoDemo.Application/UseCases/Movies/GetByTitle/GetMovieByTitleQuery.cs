using MediatR;
//using NPTN.MongoDemo.Application.Services;
using NPTN.MongoDemo.Application.UseCases.Movies;

namespace NPTN.MongoDemo.Application.UseCases.Movies.GetByTitle
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
            //private readonly IMovieService _movieService;
            //public GetMovieByTitleQueryHandler(IMovieService movieService)
            //{
            //    _movieService = movieService;
            //}
            //public async Task<MovieResponse> Handle(GetMovieByTitleQuery request, CancellationToken cancellationToken)
            //{
            //    return await _movieService.GetMovieByTitleAsync(request.Title, cancellationToken);
            //}

            private readonly IReadOnlyMovieRepository _repository;
            public GetMovieByTitleQueryHandler(IReadOnlyMovieRepository movieService)
            {
                _repository = movieService;
            }
            public async Task<MovieResponse> Handle(GetMovieByTitleQuery request, CancellationToken cancellationToken)
            {
                return await _repository.GetMovieByTitleAsync(request.Title, cancellationToken);
            }
        }
    }
}
