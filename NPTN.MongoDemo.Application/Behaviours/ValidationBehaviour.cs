using Amazon.Runtime;
using FluentValidation.Results;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace NPTN.MongoDemo.Application.Behaviours
{
    internal sealed class ValidationBehaviour<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            ValidationFailure[] validationFailures = await ValidateAsync(request);

            if (validationFailures.Length > 0)
            {
                var failures = validationFailures
                .Select(f => f.ErrorMessage)
                .ToList();

                if (failures.Any())
                {
                    foreach (var failure in failures)
                    {
                        throw new ValidationException(failure);
                    }
                }
            }

            return await next();
        }

        private async Task<ValidationFailure[]> ValidateAsync(TRequest request)
        {
            if (!validators.Any())
            {
                return [];
            }

            var context = new ValidationContext<TRequest>(request);

            ValidationResult[] validationResults = await Task.WhenAll(
                validators.Select(validator => validator.ValidateAsync(context)));

            ValidationFailure[] validationFailures = validationResults
                .Where(validationResult => !validationResult.IsValid)
                .SelectMany(validationResult => validationResult.Errors)
                .ToArray();

            return validationFailures;
        }
    }
}
