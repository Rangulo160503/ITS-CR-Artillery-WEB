using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PedidoInventarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
