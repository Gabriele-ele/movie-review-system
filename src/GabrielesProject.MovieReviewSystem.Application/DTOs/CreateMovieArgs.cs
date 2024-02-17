namespace GabrielesProject.MovieReviewSystem.Application.DTOs;

public record CreateMovieArgs
{
    public string? Title { get; set; }

    public string? Summary { get; set; }
}
