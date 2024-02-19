using FluentValidation;

namespace GabrielesProject.MovieReviewSystem.Application.Validators;

public class ValidatorRules : AbstractValidator<int>
{
    public ValidatorRules() => RuleFor(x => x).InclusiveBetween(1, 5).WithMessage("Invalid rating value, must be between 1 and 5");
}
