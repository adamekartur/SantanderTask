using HackerNewsDomain.Domain;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace HackerNewsDomain.Repository
{
    public sealed class RedisDecoratorRepository : INewsRepository
    {
        private readonly INewsRepository baseRepository;
        private readonly IDatabase database;

        public RedisDecoratorRepository(INewsRepository baseRepository, IDatabase database)
        {
            this.baseRepository = baseRepository;
            this.database = database;
        }

        public async Task<List<int>> GetBestNewsAsync()
        {
            return await baseRepository.GetBestNewsAsync();
        }

        public async Task<HackerNewsInfo?> GetNewsAsync(int id)
        {
            var json = await database.StringGetAsync(id.ToString());
            if (json.HasValue)
            {
                var data = JsonConvert.DeserializeObject<HackerNewsInfo>(json!);
                if (data != null)
                {
                    return data;
                }
            }
                
            var news = await baseRepository.GetNewsAsync(id);
            var toSave = JsonConvert.SerializeObject(news, Formatting.Indented);
            _ = database.StringSetAsync(id.ToString(), toSave, TimeSpan.FromMinutes(60), When.NotExists, CommandFlags.FireAndForget);
            return news;

        }
    }
}
