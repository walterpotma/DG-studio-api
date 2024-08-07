using dg_studio_api.Model;

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
    }
}
