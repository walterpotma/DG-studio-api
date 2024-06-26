using dg_studio_api.Model;
using Microsoft.EntityFrameworkCore;

namespace dg_studio_api.Infraestrutura
{
    public class CacheRepository : ICacheRepository
    {
        private readonly ConnectionContext _context;

        public CacheRepository(ConnectionContext context)
        {
            _context = context;
        }

        public void Add(Cache cache)
        {
            _context.Cache.Add(cache);
            _context.SaveChanges();
        }

        public List<Cache> Get()
        {
            return _context.Cache.ToList();
        }

        public void Update(Cache cache)
        {
            var existingCache = _context.Cache.Find(cache.id);
            if (existingCache != null)
            {
                _context.Entry(existingCache).CurrentValues.SetValues(cache);
                _context.SaveChanges();
            }
        }
    }
}
