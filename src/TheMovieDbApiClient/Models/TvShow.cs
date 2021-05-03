using System;
using System.Text.Json.Serialization;
using TheMovieDbApiClient.Converters;

namespace TheMovieDbApiClient.Models
{
    public class TvShow
    {
        [JsonPropertyName("original_name")]
        public string OriginalName { get; init; } = string.Empty;

        public int Id { get; init; }

        public string Name { get; init; } = string.Empty;

        [JsonPropertyName("vote_count")]
        public int VoteCount { get; init; }

        [JsonPropertyName("vote_average")]
        public float VoteAverage { get; init; }

        [JsonPropertyName("first_air_date")]
        [JsonConverter(typeof(StringToDateConverter))]
        public DateTime? FirstAirDate { get; init; }

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

        [JsonPropertyName("origin_country")]
        public string[] OriginCountries { get; init; } = Array.Empty<string>();

        public float Popularity { get; init; }
    }
}
