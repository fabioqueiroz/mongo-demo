using MediatR;
using NPTN.MongoDemo.Application.UseCases.Users.Delete;

namespace NPTN.MongoDemo.Api.Endpoints.Users
{
    public class DeleteUser : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapDelete("users/{id}", async (string id, IMediator mediator, CancellationToken cancellationToken) =>
            {
                await mediator.Send(new DeleteUserCommand(id), cancellationToken);
            })
            .WithTags(EndpointTag.Users)
            .WithName(nameof(DeleteUser))
            .WithOpenApi();
        }
    }
}
