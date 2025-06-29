using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CategoriaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
