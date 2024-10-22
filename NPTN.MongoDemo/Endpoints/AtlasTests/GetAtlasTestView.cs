using MediatR;
using NPTN.MongoDemo.Api.Endpoints.Movies;
using NPTN.MongoDemo.Application.UseCases.AtlasTests.MaterialisedView;

namespace NPTN.MongoDemo.Api.Endpoints.AtlasTests
{
    public class GetAtlasTestView : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/atlas/testMaterialisedView", async (IMediator mediator, CancellationToken cancellationToken) =>
            {
                return Results.Ok(await mediator.Send(new GetAtlasTestMaterialisedViewQuery(), cancellationToken));
            })
                .WithTags(EndpointTag.Atlas)
                .WithName(nameof(GetAtlasTestView))
                .WithOpenApi();
        }
    }
}
