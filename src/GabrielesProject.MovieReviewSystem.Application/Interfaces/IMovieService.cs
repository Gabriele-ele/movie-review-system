using GabrielesProject.MovieReviewSystem.Application.DTOs;

namespace GabrielesProject.MovieReviewSystem.Application.Interfaces;

public interface IMovieService
{
    public Task<IEnumerable<MovieDTO>> GetMoviesAsync();

    public Task<MovieDTO?> GetMovieAsync(int id);

    public Task<MovieDTO?> AddMovieAsync(CreateMovieArgs movie);

    public Task<IEnumerable<MovieDTO>> GetMoviesAsync(int? minRating, int? maxRating);

    public Task DeleteMovieAsync(int id);

    public Task RateMovieAsync(int id,  int rating);
}
