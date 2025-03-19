using System.Text;
using FluentValidation;
using MediatR.Pipeline;

namespace eShopOnWinUI.Application.CQRS.RequestProcessors.Validation;

public sealed class ValidationRequestPreProcessor<TRequest>(IList<IValidator<TRequest>> validators) : IRequestPreProcessor<TRequest>
    where TRequest : notnull
{
    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var errors = validators
            .Select(validator => validator.Validate(request))
            .SelectMany(validationResult => validationResult.Errors)
            .Where(error => error is not null)
            .ToList();

        if (errors.Count != 0)
        {
            StringBuilder errorBuilder = new();

            _ = errorBuilder.AppendLine("Invalid command, reason: ");

            errors.ForEach(error => errorBuilder.AppendLine(error.ErrorMessage));

            throw new ValidationException(errorBuilder.ToString());
        }

        return Task.CompletedTask;
    }
}