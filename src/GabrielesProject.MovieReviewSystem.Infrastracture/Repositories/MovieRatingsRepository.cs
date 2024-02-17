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

    public void GetRatings()
    {
        _connection.Execute("SELECT * FROM ratings");
    }

    public void UpdateRatings(int movieId, int ratingNumber)
    {
        string sql = @"UPDATE ratings SET rating_number=@ratingNumber WHERE movie_id=@movieId";

        _connection.Execute(sql, new { movieId, ratingNumber });
    }
}
