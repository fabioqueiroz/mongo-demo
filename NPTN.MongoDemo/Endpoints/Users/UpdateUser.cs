using MediatR;
using NPTN.MongoDemo.Application.UseCases.Users.Update;

namespace NPTN.MongoDemo.Api.Endpoints.Users
{
    public class UpdateUser : IEndpoint
    {
        public sealed record UpdateUserRequest(string Email, string Name, string Password);

        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPut("users/{id}", async (string id, UpdateUserRequest request, IMediator mediator, CancellationToken cancellationToken) =>
            {
                var command = new UpdateUserCommand(id, request.Name, request.Email, request.Password);
                await mediator.Send(command, cancellationToken);
            })
            .WithTags(EndpointTag.Users)
            .WithName(nameof(UpdateUser))
            .WithOpenApi();
        }
    }
}
