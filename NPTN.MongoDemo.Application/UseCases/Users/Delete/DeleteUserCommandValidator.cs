using FluentValidation;

namespace NPTN.MongoDemo.Application.UseCases.Users.Delete
{
    public sealed class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
