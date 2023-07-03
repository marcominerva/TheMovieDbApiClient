using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using TheMovieDbApiClient.Models;

namespace TheMovieDbApiClient;

public class TmdbApiClient : ITmdbApiClient
{
    private readonly HttpClient httpClient;
    private readonly bool useInnerHttpClient;

    private const string authorizationHeader = "Authorization";
    private const string bearer = "Bearer ";

    private const string baseUrl = "https://api.themoviedb.org/3/";

    public TmdbApiClient(string subscriptionKey) : this(null, subscriptionKey)
    {
    }

    public TmdbApiClient(HttpClient? httpClient, string subscriptionKey)
    {
        if (httpClient == null)
        {
            this.httpClient = new HttpClient();
            useInnerHttpClient = true;
        }
        else
        {
            this.httpClient = httpClient;
            useInnerHttpClient = false;
        }

        _ = this.httpClient.DefaultRequestHeaders.TryAddWithoutValidation(authorizationHeader, $"{bearer} {subscriptionKey}");
    }

    public async Task<ListResult<Movie>> GetMoviesAsync(string query, string? language = null)
    {
        var resource = new Uri(new Uri(baseUrl), $"search/movie?language={language ?? Thread.CurrentThread.CurrentCulture.Name}&query={Uri.EscapeUriString(query)}");
        var movies = await httpClient.GetFromJsonAsync<ListResult<Movie>>(resource);

        return movies!;
    }

    public async Task<ListResult<TvShow>> GetTvShowsAsync(string query, string? language = null)
    {
        var resource = new Uri(new Uri(baseUrl), $"search/tv?language={language ?? Thread.CurrentThread.CurrentCulture.Name}&query={Uri.EscapeUriString(query)}");
        var tvShows = await httpClient.GetFromJsonAsync<ListResult<TvShow>>(resource);

        return tvShows!;
    }

    public void Dispose()
    {
        if (useInnerHttpClient)
        {
            httpClient.Dispose();
        }
    }
}
