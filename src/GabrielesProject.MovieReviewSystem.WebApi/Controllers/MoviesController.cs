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

    [HttpGet]
    public async Task<IEnumerable<MovieDTO>> Get([FromQuery] int? minRating, [FromQuery] int? maxRating)
    {
        if (minRating is null && maxRating is null)
        {
            return await _movieService.GetMoviesAsync();
        }
        return await _movieService.GetMoviesAsync(minRating, maxRating);
    }

    [HttpPost]
    public async Task<MovieDTO> Post([FromBody] CreateMovieArgs movie)
    {
       return await _movieService.AddMovieAsync(movie);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _movieService.GetMovieAsync(id));
    }

    [HttpDelete]
    public async Task Delete(int id)
    {
       await _movieService.DeleteMovieAsync(id);
    }

    [HttpPost]
    [Route("/Rating")]
    public async Task Rate(int id, [FromBody] int rating)
    {
        await _movieService.RateMovieAsync(id, rating);
    }
}
