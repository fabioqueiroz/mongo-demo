using MediatR;
using NPTN.MongoDemo.Application.UseCases.Users.GetByEmail;

namespace NPTN.MongoDemo.Api.Endpoints.Users
{
    internal class GetUserByEmail : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/users/{email}", async (string email, IMediator mediator, CancellationToken cancellationToken) =>
            {
                return Results.Ok(await mediator.Send(new GetUserByEmailQuery(email), cancellationToken)); // joe_dempsie@gameofthron.es // joe_dempsie%40gameofthron.es
            })
                .WithTags(EndpointTag.Users)
                .WithName(nameof(GetUserByEmail))
                .WithOpenApi();
        }
    }
}
