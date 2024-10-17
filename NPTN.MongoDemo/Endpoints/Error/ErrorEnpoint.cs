using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using NPTN.MongoDemo.Application.Exceptions;
using NPTN.MongoDemo.Application.UseCases.Users.Update;

namespace NPTN.MongoDemo.Api.Endpoints.Error
{
    public class ErrorEnpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.Map("/error", (IHttpContextAccessor httpContextAccessor) =>
            {
                var context = httpContextAccessor.HttpContext?.Features.Get<IExceptionHandlerFeature>();
                if (context != null) 
                {
                    return GetMappedResultForException(context.Error);
                }
                return Results.Empty;
            })
            .WithTags(EndpointTag.Error)
            .WithName(nameof(ErrorEnpoint))
            .WithOpenApi();
        }

        private IResult GetMappedResultForException(Exception exception)
        {
            switch (exception)
            {
                case ValidationException validationException:
                    //_logger.LogInformation(validationException, $"{nameof(ValidationException)} occurred.");
                    return Results.Problem(detail: validationException.Message, statusCode: 400, title: "Validation Error.");
                case EntityNotFoundException entityNotFoundException:
                    //_logger.LogInformation(entityNotFoundException, $"{nameof(EntityNotFoundException)} occurred.");
                    return Results.Problem(detail: entityNotFoundException.Message, statusCode: 404, title: "Not Found.");
                default:
                    return Results.Problem(detail: exception.Message, statusCode: 500, title: $"{typeof(Exception)} Found.");
            }
        }
    }
}
