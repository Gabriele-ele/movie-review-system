using GabrielesProject.MovieReviewSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GabrielesProject.MovieReviewSystem.Application.Interfaces;

public interface IMovieService
{
    public Task<IEnumerable<Movie>> GetMoviesAsync();

    
}
