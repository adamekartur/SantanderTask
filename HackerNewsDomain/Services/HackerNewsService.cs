using HackerNewsDomain.Domain;
using Microsoft.Extensions.Logging;

namespace HackerNewsDomain.Services
{
    public sealed class HackerNewsService : INewsService
    {
        private readonly INewsProvider newsProvider;
        private readonly ILogger<HackerNewsService> logger;

        public HackerNewsService(INewsProvider newsProvider, ILogger<HackerNewsService> logger)
        {
            this.newsProvider = newsProvider;
            this.logger = logger;
        }

        public async Task<IList<NewsInfo>> GetBestNews(int n)
        {
            var result = new List<NewsInfo>();
            var best = (await newsProvider.GetBestNewsAsync()).Take(n);

            foreach (var item in best)
            {
                var details = await newsProvider.GetNewsAsync(item);
                if (details == null) 
                {
                    logger.LogError($"News {item} not found in service.");
                    continue;
                }
                result.Add(new NewsInfo()
                {
                    CommentCount = details.Kids.Count,
                    Title = details.Title,
                    Score = details.Score,
                    PostedBy = details.By,
                    Time = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(details.Time).ToLocalTime(),
                    Uri = details.Url,
                });
            }

            return result;
        }
    }
}
