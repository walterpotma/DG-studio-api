using dg_studio_api.Model;

namespace dg_studio_api.Infraestrutura
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public void Add(Usuarios usuarios)
        {
            _context.Usuarios.Add(usuarios);
            _context.SaveChanges();
        }

        public List<Usuarios> Get()
        {
            return _context.Usuarios.ToList();
        }
    }
}
