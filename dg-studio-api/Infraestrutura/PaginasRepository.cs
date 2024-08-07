using dg_studio_api.Model;

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

        public async Task<Paginas> GetPaginaByIdAsync(int id)
        {
            return await _context.Paginas.FindAsync(id);
        }
    }

}
