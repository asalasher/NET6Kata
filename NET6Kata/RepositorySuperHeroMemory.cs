using Microsoft.Extensions.Caching.Memory;

namespace NET6Kata
{
    public class RepositorySuperHeroMemory
    {
        private readonly IMemoryCache _memoryCache;
        private readonly string _keyName = "users";
        private readonly MemoryCacheEntryOptions _cacheOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(1))
            .SetSlidingExpiration(TimeSpan.FromMinutes(1));

        public RepositorySuperHeroMemory(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        private List<SuperHero>? DeserializeUsers()
        {
            return _memoryCache.Get<List<SuperHero>>(_keyName);
        }

        public SuperHero? GetById(int id)
        {
            List<SuperHero>? users = DeserializeUsers();
            if (users is null) return null;

            return users.FirstOrDefault(x => x.Id == id);
        }

        public SuperHero Insert(SuperHero superHero)
        {
            List<SuperHero>? users = DeserializeUsers();

            if (users is null)
            {
                _memoryCache.Set(_keyName, new List<SuperHero> { superHero }, _cacheOptions);
                return superHero;
            }
            else
            {
                users.Add(superHero);
                _memoryCache.Set(_keyName, users, _cacheOptions);
                return superHero;
            }
        }

    }
}
