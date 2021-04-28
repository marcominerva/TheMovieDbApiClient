using System;
using System.Text.Json.Serialization;
using TheMovieDbApiClient.Converters;

namespace TheMovieDbApiClient.Models
{
    public class TvShow
    {
        [JsonPropertyName("original_name")]
        public string OriginalName { get; init; } = null!;

        public int Id { get; init; }

        public string Name { get; init; } = null!;

        [JsonPropertyName("vote_count")]
        public int VoteCount { get; init; }

        [JsonPropertyName("vote_average")]
        public float VoteAverage { get; init; }

        [JsonPropertyName("first_air_date")]
        [JsonConverter(typeof(StringToDateConverter))]
        public DateTime? FirstAirDate { get; init; }

        [JsonPropertyName("poster_path")]
        public string? PosterPath { get; init; }

        public string? PosterUrl => PosterPath != null ? $"https://image.tmdb.org/t/p/original{PosterPath}" : null;

        [JsonPropertyName("genre_ids")]
        public int[] GenreIds { get; init; } = null!;

        [JsonPropertyName("original_language")]
        public string OriginalLanguage { get; init; } = null!;

        [JsonPropertyName("backdrop_path")]
        public string? BackdropPath { get; init; }

        public string? BackdropUrl => BackdropPath != null ? $"https://image.tmdb.org/t/p/original{BackdropPath}" : null;

        public string Overview { get; init; } = null!;

        [JsonPropertyName("origin_country")]
        public string[] OriginCountries { get; init; } = null!;

        public float Popularity { get; init; }
    }
}
