using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KataRedis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestRedisController : ControllerBase
    {
        private readonly IDistributedCache _cache;

        public TestRedisController(IDistributedCache cache)
        {
            _cache = cache;
        }

        // GET: api/<TestRedisController>
        [HttpGet]
        public void Get()
        {
            string? dataFromCacheAsString = _cache.GetString("users");
            if (dataFromCacheAsString is null)
            {
                return;
            }

            var dataFromCacheAsObject = JsonSerializer.Deserialize<WeakReference>(dataFromCacheAsString);
            return;
        }

    }
}
