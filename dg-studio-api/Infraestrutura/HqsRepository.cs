using dg_studio_api.Model;
using Microsoft.EntityFrameworkCore;

namespace dg_studio_api.Infraestrutura
{
    public class HqsRepository : IHqsRepository
    {
        private readonly ConnectionContext _context;

        public HqsRepository(ConnectionContext context)
        {
            _context = context;
        }
        public async Task AddHqAsync(Hqs hq)
        {
            _context.Hqs.Add(hq);
            await _context.SaveChangesAsync();
        }
        public List<Hqs> Get()
        {
            return _context.Hqs.ToList();
        }

        public async Task<Hqs> GetHqById(int id)
        {
            return await _context.Hqs.FindAsync(id);
        }

        public async Task<Hqs> GetHqByName(string nome)
        {
            return await _context.Hqs.FirstOrDefaultAsync(x => x.nome == nome);
        }

        public async Task<List<Hqs>> GetHqFinalizada(string status)
        {
            return await _context.Hqs.Where(x => x.status == status).ToListAsync();
        }
        public async Task<List<Hqs>> GetHqAndamento(string status)
        {
            return await _context.Hqs.Where(x => x.status == status).ToListAsync();
        }
    }
}
