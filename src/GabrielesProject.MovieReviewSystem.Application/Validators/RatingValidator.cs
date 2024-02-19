using GabrielesProject.MovieReviewSystem.Domain.Exceptions;

namespace GabrielesProject.MovieReviewSystem.Application.Validators;

internal class RatingValidator 
{
    public void ValidateAndThrow(int rating)
    {
        var validator = new ValidatorRules();
        var result = validator.Validate(rating);
        if(result.IsValid)
        {
            return;
        }

        var errorMessage = string.Join(" - ", result.Errors.Select(x => x.ErrorMessage));
        throw new InvalidInputException(errorMessage);
    }
}
