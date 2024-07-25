using Microsoft.AspNetCore.Mvc;

namespace dg_studio_api.Controllers
{
    public class CapitulosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
