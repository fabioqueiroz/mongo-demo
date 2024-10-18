using MediatR;
using NPTN.MongoDemo.Application.UseCases.Movies.MaterialisedView;

namespace NPTN.MongoDemo.Api.Endpoints.Movies
{
    public class CreateMovieCommentsView : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/movies/createMaterialView", async (IMediator mediator, CancellationToken cancellationToken) =>
            {
                return Results.Ok(await mediator.Send(new CreateMovieCommentsMaterialisedViewQuery(), cancellationToken));
            })
                .WithTags(EndpointTag.Movies)
                .WithName(nameof(CreateMovieCommentsView))
                .WithOpenApi();
        }
    }
}
