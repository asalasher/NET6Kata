using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NET6Kata.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;

        public CacheController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public List<SuperHero> GetUsersCacheAsync()
        {
            var output = _memoryCache.Get<List<SuperHero>>("superhero");

            if (output is not null)
            {
                return output;
            }

            output = new()
            {
                new SuperHero {Name = "Pierre", LastName="NodoyUna"},
                new SuperHero {Name = "Maria", LastName="Garcia"},
            };

            var cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(5))
                .SetSlidingExpiration(TimeSpan.FromSeconds(5));

            _memoryCache.Set("superhero", output, cacheOptions);
            //_memoryCache.Set("superhero", output, TimeSpan.FromMinutes(1));
            return output;
        }

        // GET: api/<CacheController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CacheController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

    }
}
