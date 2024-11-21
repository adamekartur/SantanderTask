using HackerNewsDomain.Domain;
using HackerNewsDomain.Services;
using Microsoft.AspNetCore.Mvc;

namespace HackerNewsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HackerNewsController : ControllerBase
    {
        private readonly INewsService service;

        public HackerNewsController(INewsService service)
        {
            this.service = service;
        }

        [HttpGet("GetBestNews")]
        public async Task<IEnumerable<NewsInfo>> GetBestNews([FromQuery] int n)
        {
            return await service.GetBestNews(n);
        }
    }
}
