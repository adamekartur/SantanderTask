using HackerNewsDomain.Domain;

namespace HackerNewsDomain.Services
{
    public sealed class MockNewsService : INewsService
    {
        public Task<IList<NewsInfo>> GetBestNews(int n)
        {
            var list = new List<NewsInfo>();
            for (int i = 0;i<n; ++i)
            {
                list.Add(new NewsInfo() { CommentCount = 10, PostedBy = "aadamek", Score = 1000000, Time = DateTime.Now, Title = "Test Data", Uri = "www.mock.pl" });
            }
            return Task.FromResult<IList<NewsInfo>>(list);
        }
    }
}
