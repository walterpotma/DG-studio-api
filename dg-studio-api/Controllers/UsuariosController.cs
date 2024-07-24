using dg_studio_api.Infraestrutura;
using dg_studio_api.Model;
using dg_studio_api.Services;
using dg_studio_api.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dg_studio_api.Controllers
{
    [ApiController]
    [Route("Api/Usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosRepository _usuariosRepository;
        private readonly ICacheRepository _cacheRepository;

        public UsuariosController(IUsuariosRepository usuariosRepository, ICacheRepository cacheRepository)
        {
            _usuariosRepository = usuariosRepository;
            _cacheRepository = cacheRepository;
        }

        [HttpPost]
        [Route("AddUsuarios")]
        public IActionResult AddNewUsuario(UsuariosViewModel usuariosView)
        {
            var usuarios = new Usuarios(usuariosView.nome, usuariosView.email, usuariosView.senha, usuariosView.categoria);
            _usuariosRepository.Add(usuarios);
            return Ok();
        }
        [HttpGet]
        [Route("ListarUsuarios")]
        public IActionResult ListarUsuarios()
        {
            var usuarioss = _usuariosRepository.Get();
            return Ok(usuarioss);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] Usuarios login)
        {
            var user = await _usuariosRepository.Login(login.id, login.email, login.senha);
            if (user != null)
            {
                var token = TokenService.GenerateToken(user);
                var tokenType = "token"; // Defina o tipo de token conforme necessário
                // Armazenar o token no banco de dados
                await _cacheRepository.AddTokenAsync(user.id, tokenType, token.ToString());


                return Ok(new { token, userId = user.id });
            }

            return Unauthorized("Email e/ou senha incorretos");
        }

        [HttpGet]
        [Route("BuscarPorTokenJWT/{token}")]
        public async Task<IActionResult> BuscarPorTokenJWT(string token)
        {
            var Perfil = await _usuariosRepository.BuscarPorTokenJWT(token);

            if (Perfil == null)
            {
                return NotFound($"Perfil não encontrado");
            }

            return Ok(Perfil);
        }
    }
}
