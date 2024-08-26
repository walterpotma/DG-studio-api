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

        public async Task AddTokenAsync(int userId, string type, string valor)
        {      
            var existe = await _context.Cache.FirstOrDefaultAsync(x => x.userid == userId && x.type == type);
            if (existe != null)
            {
                existe.valor = valor;
                _context.Cache.Update(existe);
            }
            else
            {
                var cache = new Cache
                {
                    userid = userId,
                    type = type,
                    valor = valor
                };
                _context.Cache.Add(cache);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Cache> GetCacheById(int id)
        {
            return await _context.Cache.FindAsync(id);
        }

        public async Task<Cache> GetCacheToken(int userId,string type)
        {
            return await _context.Cache.FirstOrDefaultAsync(x => x.type == type && x.userid == userId);
        }
    }
}
