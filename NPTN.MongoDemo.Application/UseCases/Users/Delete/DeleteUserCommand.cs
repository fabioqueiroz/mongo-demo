using MediatR;

namespace NPTN.MongoDemo.Application.UseCases.Users.Delete
{
    public sealed class DeleteUserCommand(string id) : IRequest
    {
        public string Id { get; } = id;

        internal class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
        {
            private readonly IUserRepository _repository;
            public DeleteUserCommandHandler(IUserRepository repository)
            {
                _repository = repository;
            }

            public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                await _repository.DeleteUserByIdAsync(request.Id,cancellationToken);
            }
        }
    }
}
