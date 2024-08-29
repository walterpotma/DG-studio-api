using dg_studio_api.Model;
using Microsoft.EntityFrameworkCore;

namespace dg_studio_api.Infraestrutura
{
    public class CapitulosRepository : ICapitulosRepository
    {
        private readonly ConnectionContext _context;

        public CapitulosRepository(ConnectionContext context)
        {
            _context = context;
        }
        public async Task AddCapituloAsync(Capitulos capitulo)
        {
            _context.Capitulos.Add(capitulo);
            await _context.SaveChangesAsync();
        }

        public async Task<Capitulos> GetCapituloByIdAsync(int id)
        {
            return await _context.Capitulos.FindAsync(id);
        }

        public List<Capitulos> Get()
        {
            return _context.Capitulos.ToList();
        }

        public async Task<Capitulos> ListarCapitulosHq(string hq)
        {
            return await _context.Capitulos
                .Where(x => x.hq == hq)
                .OrderByDescending(x => x.id) // Ajuste 'Id' para o campo que faz sentido para determinar o último
                .FirstOrDefaultAsync();
        }
    }
}
