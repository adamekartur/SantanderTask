using System.Text.Json.Serialization;

namespace HackerNewsDomain.Domain
{
    public sealed class NewsInfo
    {
        [JsonPropertyName("title")]
        public required string Title { get; init; }

        [JsonPropertyName("uri")]
        public required string Uri { get; init; }

        [JsonPropertyName("postedBy")]
        public required string PostedBy { get; init; }

        [JsonIgnore]
        public required DateTime Time { get; init; }

        [JsonPropertyName("time")]
        public string TimeString => Time.ToString("yyyy-MM-ddTHH:mm:sszzz");

        [JsonPropertyName("scope")]
        public required int Score { get; init; }

        [JsonPropertyName("commentCount")]
        public required int CommentCount { get; init; }
    }
}
