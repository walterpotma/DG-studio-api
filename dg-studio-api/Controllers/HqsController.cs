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
        public async Task<IActionResult> AddHq(string nome, IFormFile capaFile, IFormFile bannerFile, string autor, string descricao, string generos)
        {
            if (string.IsNullOrEmpty(nome) || capaFile == null || bannerFile == null || string.IsNullOrEmpty(autor))
            {
                return BadRequest("Invalid input.");
            }

            var capaBase64 = await ConvertToBase64(capaFile);
            var bannerBase64 = await ConvertToBase64(bannerFile);

            var hq = new Hqs
            {
                nome = nome,
                capa = capaBase64,
                banner = bannerBase64,
                autor = autor,
                descricao = descricao,
                generos = generos
            };

            await _hqsRepository.AddHqAsync(hq);

            return Ok(new { Message = "HQ added successfully!" });
        }

        private async Task<string> ConvertToBase64(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var imageBytes = memoryStream.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }

        [HttpGet]
        [Route("ListarHqs")]
        public IActionResult ListarUsuarios()
        {
            var usuarioss = _hqsRepository.Get();
            return Ok(usuarioss);
        }
    }
}
