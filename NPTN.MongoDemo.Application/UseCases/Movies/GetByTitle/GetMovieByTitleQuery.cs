﻿using MediatR;

namespace NPTN.MongoDemo.Application.UseCases.Movies.GetByTitle
{
    public sealed class GetMovieByTitleQuery(string title) : IRequest<MovieResponse>
    {
        public string Title { get; } = title;

        internal class GetMovieByTitleQueryHandler : IRequestHandler<GetMovieByTitleQuery, MovieResponse>
        {
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
