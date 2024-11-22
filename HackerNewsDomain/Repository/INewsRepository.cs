using HackerNewsDomain.Domain;

namespace HackerNewsDomain.Repository
{
    public interface INewsRepository
    {
        Task<List<int>> GetBestNewsAsync();

        Task<HackerNewsInfo?> GetNewsAsync(int id);
    }
}
