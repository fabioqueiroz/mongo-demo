using Amazon.Runtime.Internal;
using FluentValidation;
using MediatR;
using NPTN.MongoDemo.Application.Exceptions;
using NPTN.MongoDemo.Domain.Users;

namespace NPTN.MongoDemo.Application.UseCases.Users.Update
{
    public sealed class UpdateUserCommand(string id, string name, string email, string password) : MediatR.IRequest
    {
        public string Id { get; } = id;
        public string Name { get; } = name;
        public string Email { get; } = email;
        public string Password { get; } = password;

        internal class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
        {
            private readonly IUserRepository _repository;
            public UpdateUserCommandHandler(IUserRepository repository)
            {
                _repository = repository;
            }

            public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var existingUser = await _repository.GetUserByIdAsync(request.Id, cancellationToken) 
                    ?? throw new EntityNotFoundException("User not found.");

                if (existingUser!.Email != request.Email)
                {
                    throw new ArgumentException("The email is unique and cannot be changed.");
                }

                var updatedUser = new User 
                { 
                    Id = existingUser.Id, 
                    Name = request.Name, 
                    Email = request.Email, 
                    Password = request.Password
                };

                await _repository.UpdateUserAsync(updatedUser, cancellationToken);
            }
        }
    }
}
