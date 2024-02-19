namespace GabrielesProject.MovieReviewSystem.Application.Interfaces;

public interface IRatingValidator
{
    public void ValidateAndThrow(int rating);
}
