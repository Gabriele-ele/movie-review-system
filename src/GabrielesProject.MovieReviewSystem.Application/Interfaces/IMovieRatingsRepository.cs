namespace GabrielesProject.MovieReviewSystem.Application.Interfaces;

public interface IMovieRatingsRepository
{
    public Task<IEnumerable<int>> GetRatingsAsync(int movieId);

    public Task AddRatingAsync(int movieId, int ratingNumber);
}
