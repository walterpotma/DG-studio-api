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
            // Valida o token e obtém o ID do usuário
            var userId = TokenService.ReadJWT(token);

            if (userId == null)
            {
                // Se o ID estiver nulo, o token pode ser inválido ou não conter um ID válido
                throw new ArgumentException("Token inválido ou não contém um ID válido.");
            }

            // Busca o usuário no banco de dados pelo ID
            var busca = await _context.Usuarios.FirstOrDefaultAsync(x => x.id == userId.Value);

            // Retorna o usuário encontrado ou null se não encontrado
            return busca;
        }

    }
}
