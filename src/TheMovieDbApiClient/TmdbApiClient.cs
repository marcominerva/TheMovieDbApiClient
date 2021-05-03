using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using TheMovieDbApiClient.Models;

namespace TheMovieDbApiClient
{
    public class TmdbApiClient : ITmdbApiClient
    {
        private readonly HttpClient httpClient;
        private readonly bool useInnerHttpClient;

        private const string AuthorizationHeader = "Authorization";
        private const string Bearer = "Bearer ";

        private const string BaseUrl = "https://api.themoviedb.org/4/";

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

            this.httpClient.DefaultRequestHeaders.TryAddWithoutValidation(AuthorizationHeader, $"{Bearer} {subscriptionKey}");
        }

        public async Task<ListResult<Movie>> GetMoviesAsync(string query, string? language = null)
        {
            var resource = new Uri(new Uri(BaseUrl), $"search/movie?language={language ?? Thread.CurrentThread.CurrentCulture.Name}&query={Uri.EscapeUriString(query)}");
            var movies = await httpClient.GetFromJsonAsync<ListResult<Movie>>(resource);

            return movies!;
        }

        public async Task<ListResult<TvShow>> GetTvShowsAsync(string query, string? language = null)
        {
            var resource = new Uri(new Uri(BaseUrl), $"search/tv?language={language ?? Thread.CurrentThread.CurrentCulture.Name}&query={Uri.EscapeUriString(query)}");
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
}
