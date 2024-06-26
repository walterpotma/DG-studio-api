using dg_studio_api.Model;
using dg_studio_api.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace dg_studio_api.Controllers
{
    [ApiController]
    [Route("Api/Usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosRepository _usuariosRepository;

        public UsuariosController(IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
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
    }
}
