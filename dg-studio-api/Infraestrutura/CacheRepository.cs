using dg_studio_api.Infraestrutura;
using dg_studio_api.Model;

namespace dg_studio_api.Infraestrutura
{
    public class CacheRepository : ICacheRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
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
            _context.Cache.Update(cache);
            _context.SaveChanges();
        }
    }
}