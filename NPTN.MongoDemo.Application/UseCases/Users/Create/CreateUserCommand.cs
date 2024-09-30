using MediatR;
using NPTN.MongoDemo.Domain.Users;

namespace NPTN.MongoDemo.Application.UseCases.Users.Create
{
    public sealed class CreateUserCommand(string name,string email, string password) : IRequest<string>
    {
        public string Name { get; } = name;
        public string Email { get; } = email;
        public string Password { get; } = password;

        internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
        {
            private readonly IUserRepository _repository;
            public CreateUserCommandHandler(IUserRepository repository)
            {
                _repository = repository;
            }

            public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var user = new User { Name = request.Name, Email = request.Email, Password = request.Password };
                return await _repository.CreateUserAsync(user, cancellationToken);
            }
        }
    }
}
