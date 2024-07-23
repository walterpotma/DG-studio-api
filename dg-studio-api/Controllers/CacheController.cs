using dg_studio_api.Model;
using dg_studio_api.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace dg_studio_api.Controllers
{
    [ApiController]
    [Route("Api/Cache")]
    public class CacheController : ControllerBase
    {
        private readonly ICacheRepository _cacheRepository;

        public CacheController(ICacheRepository cacheRepository)
        {
            _cacheRepository = cacheRepository;
        }
        
        
        [HttpGet]
        [Route("ListarPorId/{id}")]
        public async Task<IActionResult> GetCacheById(int id)
        {
            var cache = await _cacheRepository.GetCacheById(id);
            if (cache == null)
            {
                return NotFound();
            }
            return Ok(cache);
        }
    }
}
