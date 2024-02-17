namespace GabrielesProject.MovieReviewSystem.Application.DTOs;

public record MovieDTO
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Summary { get; set; }

    public decimal Rating { get; set; }

    public List<CommentsDTO> Comments { get; set; } = new();
}
