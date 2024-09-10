using dg_studio_api.Model;
using Microsoft.EntityFrameworkCore;

namespace dg_studio_api.Infraestrutura
{
    public class PaginasRepository : IPaginasRepository
    {
        private readonly ConnectionContext _context;

        public PaginasRepository(ConnectionContext context)
        {
            _context = context;
        }

        public async Task AddPaginaAsync(Paginas pagina)
        {
            _context.Paginas.Add(pagina);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Paginas>> GetPaginaByIdAsync(int capitulo_id)
        {
            return await _context.Paginas.Where(x => x.capitulo_id == capitulo_id).ToListAsync();
        }

        public List<Paginas> Get()
        {
            return _context.Paginas.ToList();
        }
    }

}
