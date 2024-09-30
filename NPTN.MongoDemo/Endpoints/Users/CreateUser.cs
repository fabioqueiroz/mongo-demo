using MediatR;
using NPTN.MongoDemo.Application.UseCases.Users.Create;

namespace NPTN.MongoDemo.Api.Endpoints.Users
{
    public class CreateUser : IEndpoint
    {
        public sealed record CreateUserRequest(string Email, string Name, string Password);

        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("users", async (CreateUserRequest request, IMediator mediator, CancellationToken cancellationToken) =>
            {
                var command = new CreateUserCommand(request.Name, request.Email, request.Password);
                return Results.Ok(await mediator.Send(command, cancellationToken));
            })
            .WithTags(EndpointTag.Users)
            .WithName(nameof(CreateUser))
            .WithOpenApi();
        }
    }
}
