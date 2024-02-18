using GabrielesProject.MovieReviewSystem.Application.Interfaces;
using GabrielesProject.MovieReviewSystem.Domain.Entities;

namespace GabrielesProject.MovieReviewSystem.Application.Services;

public class ExternalCommentsService : IExternalCommentsService
{
    private readonly HttpClient _httpClient;

    public ExternalCommentsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<ExternalComments>> GetCommentsAsync(int movieId)
    {
        var response = await _httpClient.GetAsync($"https://jsonplaceholder.typicode.com/comments?postId={movieId}");
        var comments = await response.Content.ReadAsAsync<IEnumerable<ExternalComments>>();

        if( response.Content is null )
        {
            throw new Exception("Comments not found");
        }
        return comments;
    }
}
