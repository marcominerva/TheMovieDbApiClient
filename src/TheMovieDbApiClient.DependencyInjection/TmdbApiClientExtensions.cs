using System;
using Microsoft.Extensions.DependencyInjection;

namespace TheMovieDbApiClient
{
    public static class TheMovieDbApiClient
    {
        public static IHttpClientBuilder AddTmdbApiClient(this IServiceCollection services, Action<TmdbSettings> configuration)
        {
            var settings = new TmdbSettings();
            configuration.Invoke(settings);

            var httpClientBuilder = services.AddHttpClient<ITmdbApiClient, TmdbApiClient>(httpClient =>
            {
                var tmdbApiClient = new TmdbApiClient(httpClient, settings.SubscriptionKey);
                return tmdbApiClient;
            });

            return httpClientBuilder;
        }
    }
}
