using FluentValidation;

namespace NPTN.MongoDemo.Application.UseCases.Users.GetByEmail
{
    internal sealed class GetUserByEmailQueryValidator : AbstractValidator<GetUserByEmailQuery>
    {
        public GetUserByEmailQueryValidator()
        {
            RuleFor(x => x.Email).NotEmpty();
        }
    }
}
