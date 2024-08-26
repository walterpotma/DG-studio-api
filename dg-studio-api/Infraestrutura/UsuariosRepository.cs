using dg_studio_api.Model;
using dg_studio_api.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace dg_studio_api.Infraestrutura
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly ConnectionContext _context;

        public UsuariosRepository(ConnectionContext context)
        {
            _context = context;
        }

        public async Task AddTokenAsync(Cache cache)
        {
            _context.Cache.Add(cache);
            await _context.SaveChangesAsync();
        }


        public void Add(Usuarios usuarios)
        {
            _context.Usuarios.Add(usuarios);
            _context.SaveChanges();
        }

        public List<Usuarios> Get()
        {
            return _context.Usuarios.ToList();
        }
        public async Task<Usuarios> Login(int id, string email, string senha)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.email == email && x.senha == senha);
        }

        public async Task<Usuarios> BuscarPorTokenJWT(string token)
        {
            var email = TokenService.ReadJWT(token);
            var busca = await _context.Usuarios.FirstOrDefaultAsync(x => x.email == email);
            return busca;
        }
    }
}
