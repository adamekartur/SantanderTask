namespace HackerNewsDomain.Domain
{
    public sealed class HackerNewsInfo
    {
        public required string By { get; set; }

        public required int Descendants { get; set; }

        public required string Id { get; set; }

        public List<int> Kids { get; set; } = [];

        public required int Score { get; set; }

        public required long Time { get; set; }

        public required string Title { get; set; }

        public required string Type { get; set; }

        public required string Url { get; set; }
    }
}
