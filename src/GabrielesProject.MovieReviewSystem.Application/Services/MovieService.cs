using GabrielesProject.MovieReviewSystem.Application.DTOs;
using GabrielesProject.MovieReviewSystem.Application.Interfaces;
using GabrielesProject.MovieReviewSystem.Domain.Entities;
using System.Reflection;
using System.Xml.Linq;

namespace GabrielesProject.MovieReviewSystem.Application.Services;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;
    private readonly IExternalCommentsService _commentsService;
    private readonly IMovieRatingsRepository _ratingsRepository;

    public MovieService(IMovieRepository movieRepository, IExternalCommentsService commentsService, IMovieRatingsRepository ratingsRepository)
    {
        _movieRepository = movieRepository;
        _commentsService = commentsService;
        _ratingsRepository = ratingsRepository;
    }

    public async Task<MovieDTO?> AddMovieAsync(CreateMovieArgs movie)
    {
        var movieId = await _movieRepository.AddMovieAsync(new Movie { Title = movie.Title, Summary = movie.Summary });
        return await GetMovieAsync(movieId);
    }

    public Task DeleteMovieAsync(int id)
    {
        return _movieRepository.DeleteMovieAsync(id);
    }

    public async Task<MovieDTO?> GetMovieAsync(int id)
    {
        var movieFromDb = await _movieRepository.GetMovieAsync(id);
        if (movieFromDb is null)
        {
            throw new KeyNotFoundException();
        }

        MovieDTO movie = await ConvertToDto(movieFromDb);

        return movie;
    }

    public async Task<IEnumerable<MovieDTO>> GetMoviesAsync(int? minRating, int? maxRating)
    {
        var moviesFromDb = await _movieRepository.GetMoviesAsync(minRating ?? 0, maxRating ?? 5);
        var movies = await ConvertToDto(moviesFromDb);
        return movies.Where(m => m.Rating >= minRating && m.Rating <= maxRating);
    }

    public Task RateMovieAsync(int id, int rating)
    {
        return _ratingsRepository.AddRatingAsync(id, rating);
    }

    private async Task<decimal?> GetAverageRatings(int movieId)
    {
        var ratings = await _ratingsRepository.GetRatingsAsync(movieId);
        if (ratings.Any())
        {
            return (decimal)ratings.Average();
        }
        return null;
    }

    private async Task<List<CommentsDTO>> GetFiveComments(int movieId)
    {
        var externalComments = await _commentsService.GetCommentsAsync(movieId);
        return externalComments
        .Take(5)
            .Select(c => new CommentsDTO { Id = c.Id, Name = c.Name, Text = c.Body })
            .ToList();
    }

    private async Task<IEnumerable<MovieDTO>> ConvertToDto(IEnumerable<Movie> moviesFromDb)
    {
        var result = new List<MovieDTO>();
        foreach (var movieFromDb in moviesFromDb)
        {
            var movie = await ConvertToDto(movieFromDb);
            result.Add(movie);
        }

        return result;
    }

    private async Task<MovieDTO> ConvertToDto(Movie movieFromDb)
    {
        var movie = new MovieDTO { Id = movieFromDb.Id, Title = movieFromDb.Title, Summary = movieFromDb.Summary };
        movie.Rating = (decimal)await GetAverageRatings(movie.Id);
        movie.Comments = await GetFiveComments(movie.Id);
        return movie;
    }

    public Task<IEnumerable<MovieDTO>> GetMoviesAsync()
    {
        throw new NotImplementedException();
    }
}
