using dg_studio_api.Infraestrutura;
using dg_studio_api.Model;
using Microsoft.AspNetCore.Mvc;

namespace dg_studio_api.Controllers
{
    [ApiController]
    [Route("Api/Hqs")]
    public class HqsController : Controller
    {
        private readonly IHqsRepository _hqsRepository;

        public HqsController(IHqsRepository hqsRepository)
        {
            _hqsRepository = hqsRepository;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddHq(Hqs hq)
        {
            /*if (string.IsNullOrEmpty(nome) || capaFile == null || bannerFile == null || string.IsNullOrEmpty(autor))
            {
                return BadRequest("Invalid input.");
            }

            var capaBase64 = await ConvertToBase64(capaFile);
            var bannerBase64 = await ConvertToBase64(bannerFile);*/

            await _hqsRepository.AddHqAsync(hq);

            return Ok(new { Message = "HQ added successfully!" });
        }
        /*
        private async Task<string> ConvertToBase64(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var imageBytes = memoryStream.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }*/

        [HttpGet]
        [Route("ListarHqs")]
        public IActionResult ListarUsuarios()
        {
            var usuarioss = _hqsRepository.Get();
            return Ok(usuarioss);
        }

        [HttpGet]
        [Route("ListarPorId/{id}")]
        public async Task<IActionResult> GetHqById(int id)
        {
            var hq = await _hqsRepository.GetHqById(id);
            if (hq == null)
            {
                return NotFound();
            }
            return Ok(hq);
        }

        [HttpGet]
        [Route("ListarPorNome/{nome}")]
        public async Task<IActionResult> GetHqByName(string nome)
        {
            var hq = await _hqsRepository.GetHqByName(nome);
            if (hq == null)
            {
                return NotFound();
            }
            return Ok(hq);
        }

        [HttpGet]
        [Route("ListarFinalizadas")]
        public async Task<IActionResult> GetHqFinalizadas()
        {
            var hq = await _hqsRepository.GetHqFinalizada("Finalizada");
            if (hq == null)
            {
                return NotFound();
            }
            // Teste de Rebase de um commit do github
            // Teste de Rebase de um commit do github
            // Teste de Rebase de um commit do github
            // Teste de Rebase de um commit do github
            // Teste de Rebase de um commit do github
            // Teste de Rebase de um commit do github
            // Teste de Rebase de um commit do github
            // Teste de Rebase de um commit do github
            // Teste de Rebase de um commit do github
            // Teste de Rebase de um commit do github
            // Teste de Rebase de um commit do github
            // Teste de Rebase de um commit do github
            // Teste de Rebase de um commit do github
            // Teste de Rebase de um commit do github
            // Teste de Rebase de um commit do github
            // Teste de Rebase de um commit do github
            // Teste de Rebase de um commit do github
            // Teste de Rebase de um commit do github
            // Teste de Rebase de um commit do github
            // Teste de Rebase de um commit do github
            // Teste de Rebase de um commit do github
            // Teste de Rebase de um commit do github
            // Teste de Rebase de um commit do github
            // Teste de Rebase de um commit do github
            // Teste de Rebase de um commit do github
            // Teste de Rebase de um commit do github
            // Teste de Rebase de um commit do github
            // Teste de Rebase de um commit do github
            // Teste de Rebase de um commit do github
            return Ok(hq);
        }

        [HttpGet]
        [Route("ListarAndamentos")]
        public async Task<IActionResult> GetHqAndamento()
        {
            var hq = await _hqsRepository.GetHqAndamento("Andamento");
            if (hq == null)
            {
                return NotFound();
            }
            return Ok(hq);
        }
    }
}
