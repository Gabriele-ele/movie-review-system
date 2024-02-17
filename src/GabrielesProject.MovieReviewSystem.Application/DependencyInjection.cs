using GabrielesProject.MovieReviewSystem.Application.Interfaces;
using GabrielesProject.MovieReviewSystem.Application.Services;
using Microsoft.Extensions.DependencyInjection;
namespace GabrielesProject.MovieReviewSystem.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication (this IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();

        }
    }
}
