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
        [Route("ListarUltimoCapHq/{hq}")]
        public async Task<IActionResult> GetHqUltimoCap(string hq)
        {
            var cap = await _capituloRepository.ListarCapitulosHq(hq);
            if (cap == null)
            {
                return NotFound();
            }
            return Ok(cap);
        }

        [HttpGet]
        [Route("ListarUltimosCapHq")]
        public async Task<IActionResult> GetLastnewCaps()
        {
            var cap = await _capituloRepository.GetUltimosCaps();
            if (cap == null)
            {
                return NotFound();
            }
            return Ok(cap);
        }


        [HttpGet]
        [Route("ListarTodosCapHq/{hq}")]
        public async Task<IActionResult> GetAllCapsHq(string hq)
        {
            var cap = await _capituloRepository.ListarTodosCapitulosHq(hq);

            if (cap == null || !cap.Any())
            {
                return NotFound("Nenhum capítulo encontrado para essa HQ.");
            }

            return Ok(cap);
        }
    }

}
