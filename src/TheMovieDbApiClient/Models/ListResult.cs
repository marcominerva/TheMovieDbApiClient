using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TheMovieDbApiClient.Models
{
    public class ListResult<T>
    {
        public IEnumerable<T> Results { get; init; } = Array.Empty<T>();

        public int Page { get; init; }

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; init; }

        [JsonPropertyName("total_results")]
        public int TotalResults { get; init; }
    }
}
