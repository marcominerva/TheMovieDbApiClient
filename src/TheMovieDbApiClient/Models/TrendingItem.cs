using System;
using System.Text.Json.Serialization;
using TheMovieDbApiClient.Converters;

namespace TheMovieDbApiClient.Models
{
    public class TrendingItem
    {
        [JsonPropertyName("original_name")]
        public string OriginalName { get; set; } = null!;

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        [JsonPropertyName("vote_count")]
        public int VoteCount { get; set; }

        [JsonPropertyName("vote_average")]
        public float VoteAverage { get; set; }

        [JsonPropertyName("first_air_date")]
        [JsonConverter(typeof(StringToDateConverter))]
        public DateTime? FirstAirDate { get; set; }

        [JsonPropertyName("poster_path")]
        public string? PosterPath { get; init; }

        public string? PosterUrl => PosterPath != null ? $"https://image.tmdb.org/t/p/original{PosterPath}" : null;

        [JsonPropertyName("genre_ids")]
        public int[] GenreIds { get; set; } = null!;

        [JsonPropertyName("original_language")]
        public string OriginalLanguage { get; set; } = null!;

        [JsonPropertyName("backdrop_path")]
        public string? BackdropPath { get; init; }

        public string? BackdropUrl => BackdropPath != null ? $"https://image.tmdb.org/t/p/original{BackdropPath}" : null;

        public string Overview { get; set; } = null!;

        [JsonPropertyName("origin_country")]
        public string[] OriginCountries { get; set; } = null!;

        public float Popularity { get; set; }

        [JsonPropertyName("media_type")]
        public string MediaType { get; set; } = null!;
    }
}
