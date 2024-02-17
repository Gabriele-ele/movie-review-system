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

    public IEnumerable<Movie> GetMovies()
    {
        return _connection.Query<Movie>("SELECT * FROM movies");
    }

    public void AddMovie(Movie movie)
    {
        //string sql = @"INSERT INTO movies (title, summary) VALUES (@title, @summary) RETURNING *";
        //return _connection.QuerySingleOrDefault<Movie>(sql, movie);
        _connection.Execute("INSERT INTO movies (title, summary) VALUES (@title, @summary) RETURNING *", movie);
    }

    public void DeleteMovie(int id)
    {
        _connection.Execute("DELETE FROM movies WHERE id=@id");
    }

    public void UpdateMovie(string title, string summary)
    {
        _connection.Execute("UPDATE movies SET title=@title, summary=@summary RETURNING *");
    }
}
