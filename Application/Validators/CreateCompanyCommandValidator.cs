using Application.Commands;
using FluentValidation;
using FluentValidation.Results;
using Shared.DataTransferObjects;

namespace Application.Validators;

public sealed class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
{
    public CreateCompanyCommandValidator()
    {
        RuleFor(c => c.Company.Name)
            .NotEmpty()
            .MaximumLength(60);

        RuleFor(c => c.Company.Address)
            .NotEmpty()
            .MaximumLength(60);
    }

    /// <summary>
    /// A method demonstrating FluentValidation ability to handle some kind of errors.
    /// </summary>
    public override ValidationResult Validate(ValidationContext<CreateCompanyCommand> context)
    {
        return context.InstanceToValidate.Company is null ?
            new ValidationResult(new[] { new ValidationFailure(nameof(CompanyForCreationDto), $"{nameof(CompanyForCreationDto)} is null.") }) :
            base.Validate(context);
    }
}
