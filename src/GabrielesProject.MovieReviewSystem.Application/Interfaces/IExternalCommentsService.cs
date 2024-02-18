using GabrielesProject.MovieReviewSystem.Domain.Entities;

namespace GabrielesProject.MovieReviewSystem.Application.Interfaces;

public interface IExternalCommentsService
{
    public Task<IEnumerable<ExternalComments>> GetCommentsAsync(int movieId);
}
