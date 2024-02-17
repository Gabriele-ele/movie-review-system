namespace GabrielesProject.MovieReviewSystem.Domain.Entities;

public record ExternalComments
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Body { get; set; }
}
