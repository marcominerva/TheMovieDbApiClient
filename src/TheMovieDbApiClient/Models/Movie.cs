using System;
using System.Text.Json.Serialization;
using TheMovieDbApiClient.Converters;

namespace TheMovieDbApiClient.Models;

public class Movie
{
    [JsonPropertyName("original_title")]
    public string OriginalTitle { get; init; } = string.Empty;

    public int Id { get; init; }

    public string Title { get; init; } = string.Empty;

    [JsonPropertyName("vote_count")]
    public int VoteCount { get; init; }

    [JsonPropertyName("vote_average")]
    public float VoteAverage { get; init; }

    [JsonPropertyName("release_date")]
    [JsonConverter(typeof(StringToDateConverter))]
    public DateTime? ReleaseDate { get; init; }

    [JsonPropertyName("poster_path")]
    public string? PosterPath { get; init; }

    [JsonPropertyName("poster_url")]
    public string? PosterUrl => PosterPath != null ? $"https://image.tmdb.org/t/p/original{PosterPath}" : null;

    [JsonPropertyName("genre_ids")]
    public int[] GenreIds { get; init; } = Array.Empty<int>();

    [JsonPropertyName("original_language")]
    public string OriginalLanguage { get; init; } = string.Empty;

    [JsonPropertyName("backdrop_path")]
    public string? BackdropPath { get; init; }

    [JsonPropertyName("backdrop_url")]
    public string? BackdropUrl => BackdropPath != null ? $"https://image.tmdb.org/t/p/original{BackdropPath}" : null;

    public string Overview { get; init; } = string.Empty;

    public float Popularity { get; init; }

    public bool Video { get; init; }

    public bool Adult { get; init; }
}
