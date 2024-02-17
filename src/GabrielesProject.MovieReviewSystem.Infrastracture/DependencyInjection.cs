using GabrielesProject.MovieReviewSystem.Application.Interfaces;
using GabrielesProject.MovieReviewSystem.Infrastracture.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Data;

namespace GabrielesProject.MovieReviewSystem.Infrastracture;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, string? dbConnectionString)
    {
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        services.AddScoped<IDbConnection>(sp => new NpgsqlConnection(dbConnectionString));
        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<IMovieRatingsRepository, MovieRatingsRepository>();
    }
}
