using HackerNewsDomain.Domain;

namespace HackerNewsDomain.Services
{
    public interface INewsProvider
    {
        Task<List<int>> GetBestNewsAsync();

        Task<HackerNewsInfo?> GetNewsAsync(int id);
    }
}
