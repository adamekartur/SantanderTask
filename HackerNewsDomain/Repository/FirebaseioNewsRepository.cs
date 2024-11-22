using HackerNewsDomain.Domain;
using Newtonsoft.Json;

namespace HackerNewsDomain.Repository
{
    public sealed class FirebaseioNewsRepository : INewsRepository
    {
        private readonly HttpClient httpClient;
        private readonly string beststoriesUrl = "https://hacker-news.firebaseio.com/v0/beststories.json";
        private readonly string storyDetailsUrl = "https://hacker-news.firebaseio.com/v0/item/{0}.json";

        public FirebaseioNewsRepository(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<int>> GetBestNewsAsync()
        {
            var content = await httpClient.GetStringAsync(beststoriesUrl);
            var json = JsonConvert.DeserializeObject<List<int>>(content);
            if (json == null)
            {
                return new List<int>();
            }
            return json;
        }

        public async Task<HackerNewsInfo?> GetNewsAsync(int id)
        {
            var content = await httpClient.GetStringAsync(string.Format(storyDetailsUrl, id));
            return JsonConvert.DeserializeObject<HackerNewsInfo?>(content);
        }
    }
}
