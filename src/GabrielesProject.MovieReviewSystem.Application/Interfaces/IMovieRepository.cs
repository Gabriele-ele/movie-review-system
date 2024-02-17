using GabrielesProject.MovieReviewSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GabrielesProject.MovieReviewSystem.Application.Interfaces;

public interface IMovieRepository
{
    public IEnumerable<Movie> GetMovies();

    public void AddMovie(Movie movie);

    public void UpdateMovie(string title, string summary);//?

    public void DeleteMovie(int id);
}
