using System;
using System.Text.Json.Serialization;
using TheMovieDbApiClient.Converters;

namespace TheMovieDbApiClient.Models;

public class TrendingItem
{
    [JsonPropertyName("original_name")]
    public string OriginalName { get; set; } = string.Empty;

    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("vote_count")]
    public int VoteCount { get; set; }

    [JsonPropertyName("vote_average")]
    public float VoteAverage { get; set; }

    [JsonPropertyName("first_air_date")]
    [JsonConverter(typeof(StringToDateConverter))]
    public DateTime? FirstAirDate { get; set; }

    [JsonPropertyName("poster_path")]
    public string? PosterPath { get; init; }

    [JsonPropertyName("poster_url")]
    public string? PosterUrl => PosterPath != null ? $"https://image.tmdb.org/t/p/original{PosterPath}" : null;

    [JsonPropertyName("genre_ids")]
    public int[] GenreIds { get; set; } = Array.Empty<int>();

    [JsonPropertyName("original_language")]
    public string OriginalLanguage { get; set; } = string.Empty;

    [JsonPropertyName("backdrop_path")]
    public string? BackdropPath { get; init; }

    [JsonPropertyName("backdrop_url")]
    public string? BackdropUrl => BackdropPath != null ? $"https://image.tmdb.org/t/p/original{BackdropPath}" : null;

    public string Overview { get; set; } = string.Empty;

    [JsonPropertyName("origin_country")]
    public string[] OriginCountries { get; set; } = Array.Empty<string>();

    public float Popularity { get; set; }

    [JsonPropertyName("media_type")]
    public string MediaType { get; set; } = string.Empty;
}
