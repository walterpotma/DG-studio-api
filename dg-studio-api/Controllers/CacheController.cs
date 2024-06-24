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

        [HttpPost]
        public IActionResult AddCache([FromBody] Cache cache)
        {
            _cacheRepository.Add(cache);
            return Ok();
        }

        [HttpGet]
        public ActionResult<List<Cache>> GetCache()
        {
            var caches = _cacheRepository.Get();
            return Ok(caches);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCache(int id, [FromBody] Cache updatedCache)
        {
            var existingCache = _cacheRepository.Get().FirstOrDefault(c => c.cachekey == id);
            if (existingCache == null)
            {
                return NotFound();
            }

            existingCache = new Cache(id, updatedCache.userid, updatedCache.reqtype, updatedCache.cachevalue, updatedCache.expirationtime);
            _cacheRepository.Update(existingCache);
            return Ok();
        }
    }
}
