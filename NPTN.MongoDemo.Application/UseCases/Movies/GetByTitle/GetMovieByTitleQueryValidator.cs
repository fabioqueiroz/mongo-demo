using FluentValidation;

namespace NPTN.MongoDemo.Application.UseCases.Movies.GetByTitle
{
    public sealed class GetMovieByTitleQueryValidator : AbstractValidator<GetMovieByTitleQuery>
    {
        public GetMovieByTitleQueryValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}
