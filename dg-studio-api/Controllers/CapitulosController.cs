using dg_studio_api.Infraestrutura;
using dg_studio_api.Model;
using Microsoft.AspNetCore.Mvc;

namespace dg_studio_api.Controllers
{
    [ApiController]
    [Route("api/Capitulos")]
    public class CapitulosController : Controller
    {
        private readonly ICapitulosRepository _capituloRepository;

        public CapitulosController(ICapitulosRepository capituloRepository)
        {
            _capituloRepository = capituloRepository;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddCapitulo([FromBody] Capitulos cap)
        {
            if (cap == null)
            {
                return BadRequest("Capítulo não pode ser nulo.");
            }

            await _capituloRepository.AddCapituloAsync(cap);
            return CreatedAtAction(nameof(GetCapituloById), new { id = cap.id }, cap);
        }

        [HttpGet]
        [Route("ListarPorId/{id}")]
        public async Task<IActionResult> GetCapituloById(int id)
        {
            var capitulo = await _capituloRepository.GetCapituloByIdAsync(id);
            if (capitulo == null)
            {
                return NotFound();
            }
            return Ok(capitulo);
        }

        [HttpGet]
        [Route("ListarCapitulos")]
        public IActionResult ListarUsuarios()
        {
            var usuarioss = _capituloRepository.Get();
            return Ok(usuarioss);
        }
    }

}
