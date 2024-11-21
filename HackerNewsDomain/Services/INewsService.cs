using HackerNewsDomain.Domain;

namespace HackerNewsDomain.Services
{
    public interface INewsService
    {
        Task<IList<NewsInfo>> GetBestNews(int n);
    }
}
