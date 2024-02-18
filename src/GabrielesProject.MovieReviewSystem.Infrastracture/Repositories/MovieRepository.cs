using Dapper;
using GabrielesProject.MovieReviewSystem.Application.Interfaces;
using GabrielesProject.MovieReviewSystem.Domain.Entities;
using System.Data;

namespace GabrielesProject.MovieReviewSystem.Infrastracture.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly IDbConnection _connection;

    public MovieRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public Task<Movie?> GetMovieAsync(int id)
    {
        return _connection.QueryFirstOrDefaultAsync<Movie>("SELECT * FROM movies WHERE id=@id", new { id });
    }

    public Task<IEnumerable<Movie>> GetMoviesAsync()
    {
        return _connection.QueryAsync<Movie>("SELECT * FROM movies");
    }

    public Task<int> AddMovieAsync(Movie movie)
    {
       return _connection.QueryFirstOrDefaultAsync<int>("INSERT INTO movies (title, summary) VALUES (@title, @summary) RETURNING id",  movie);
    }

    public Task<int> DeleteMovieAsync(int id)
    {
       return _connection.ExecuteAsync("DELETE FROM movies WHERE id=@id", new { id });
    }

    public Task<IEnumerable<Movie>> GetMoviesAsync (int minRating, int maxRating)
    {
        return _connection.QueryAsync<Movie>("SELECT m.* FROM movies m JOIN ratings r ON m.id = r.movie_id WHERE r.rating >= @minRating AND r.rating <= @maxRating", new { minRating, maxRating} );
    }
}
