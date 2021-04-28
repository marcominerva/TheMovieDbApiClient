using System;
using Net50ConsoleApp;
using TheMovieDbApiClient;

using var apiClient = new TmdbApiClient(ServiceKeys.SubscriptionKey);
var movies = await apiClient.GetMoviesAsync("austin powers");

Console.ReadLine();
