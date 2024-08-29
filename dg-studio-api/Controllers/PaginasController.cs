using dg_studio_api.Infraestrutura;
using dg_studio_api.Model;
using Microsoft.AspNetCore.Mvc;

namespace dg_studio_api.Controllers
{
    [ApiController]
    [Route("api/Paginas")]
    public class PaginasController : Controller
    {
        private readonly IPaginasRepository _paginaRepository;

        public PaginasController(IPaginasRepository paginaRepository)
        {
            _paginaRepository = paginaRepository;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddPagina( Paginas page)
        {
            /*
            if (imagens == null || imagens.Length == 0)
            {
                return BadRequest("Nenhuma imagem fornecida.");
            }

           
            var base64 = await ConvertToBase64(imagens);

            var pagina = new Paginas
            {
                capitulo_id = capituloId,
                numero = numero,
                imagem = base64
            };*/

            await _paginaRepository.AddPaginaAsync(page);

            return Ok(new { Message = "Pagina added successfully!" });
        }

        /*private async Task<string> ConvertToBase64(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var imageBytes = memoryStream.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }*/

        [HttpGet]
        [Route("ListarPorId/{capitulo_id}")]
        public async Task<IActionResult> GetPaginaById(int capitulo_id)
        {
            var pagina = await _paginaRepository.GetPaginaByIdAsync(capitulo_id);
            if (pagina == null)
            {
                return NotFound();
            }
            return Ok(pagina);
        }

        [HttpGet]
        [Route("ListarPaginas")]
        public IActionResult ListarPaginas()
        {
            var paginass = _paginaRepository.Get();
            return Ok(paginass);
        }
    }
}
