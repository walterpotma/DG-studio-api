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
        public void Add(Hqs hqs)
        {
            _context.Hqs.Add(hqs);
            _context.SaveChanges();
        }
    }
}
