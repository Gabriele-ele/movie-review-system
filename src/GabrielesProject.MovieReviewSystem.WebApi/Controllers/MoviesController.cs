using GabrielesProject.MovieReviewSystem.Application.DTOs;
using GabrielesProject.MovieReviewSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GabrielesProject.MovieReviewSystem.WebApi.Controllers;

[ApiController]
[Produces("application/json")]
[Route("v1/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly IMovieService _movieService;

    public MoviesController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpPost]
    public async Task<MovieDTO> AddMovie([FromBody] CreateMovieArgs movie)
    {
       return await _movieService.AddMovieAsync(movie);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMovieById(int id)
    {
        return Ok(await _movieService.GetMovieAsync(id));
    }
}
