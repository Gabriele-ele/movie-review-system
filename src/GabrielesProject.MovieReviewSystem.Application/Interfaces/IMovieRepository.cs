using GabrielesProject.MovieReviewSystem.Domain.Entities;

namespace GabrielesProject.MovieReviewSystem.Application.Interfaces;

public interface IMovieRepository
{
    public Task<IEnumerable<Movie>> GetMoviesAsync();

    public Task<Movie?> GetMovieAsync(int id);

    public Task<int> AddMovieAsync(Movie movie);

    public Task<IEnumerable<Movie>> GetMoviesAsync(int minRating, int maxRating);

    public Task<int> DeleteMovieAsync(int id);
}
