using Dapper;
using GabrielesProject.MovieReviewSystem.Application.Interfaces;
using System.Data;

namespace GabrielesProject.MovieReviewSystem.Infrastracture.Repositories;

public class MovieRatingsRepository : IMovieRatingsRepository
{
    private readonly IDbConnection _connection;

    public MovieRatingsRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<int>> GetRatingsAsync(int movieId)
    {
        return await _connection.QueryAsync<int>("SELECT rating_number FROM ratings WHERE movie_id=@movieId", new { movieId });
    }

    public Task AddRatingAsync(int movieId, int ratingNumber)
    {
        string sql = @"INSERT INTO ratings (movie_id, rating_number) VALUES (@movieId, @ratingNumber)";

        return _connection.ExecuteAsync(sql, new { movieId, ratingNumber });
    }
}
