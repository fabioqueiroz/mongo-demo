using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
