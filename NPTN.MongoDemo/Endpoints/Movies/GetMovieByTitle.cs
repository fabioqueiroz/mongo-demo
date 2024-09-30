using MediatR;
using NPTN.MongoDemo.Application.Movies.GetByTitle;
using NPTN.MongoDemo.Application.Services;

namespace NPTN.MongoDemo.Api.Endpoints.Movies
{
    internal class GetMovieByTitle : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/movies/{title}", async (string title, IMediator mediator, CancellationToken cancellationToken) =>
            {
                return await mediator.Send(new GetMovieByTitleQuery(title), cancellationToken); // "Back to the Future" // Back%20to%20the%20Future
            })
                .WithTags(EndpointTag.Movies)
                .WithName(nameof(GetMovieByTitle))
                .WithOpenApi();
        }
    }
}
