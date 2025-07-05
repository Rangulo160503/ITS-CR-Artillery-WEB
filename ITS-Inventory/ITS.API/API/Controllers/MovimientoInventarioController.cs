using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class MovimientoInventarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
