using System;
using System.Threading.Tasks;
using TheMovieDbApiClient.Models;

namespace TheMovieDbApiClient
{
    public interface ITmdbApiClient : IDisposable
    {
        Task<ListResult<Movie>> GetMoviesAsync(string query, string? language = null);
    }
}
