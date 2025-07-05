using Abstracciones.Interfaces.Flujo;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class InventarioController : ControllerBase
        {
            private readonly IInventarioFlujo _inventarioFlujo;

            public InventarioController(IInventarioFlujo inventarioFlujo)
            {
                _inventarioFlujo = inventarioFlujo;
            }

            [HttpGet]
            public async Task<IActionResult> Obtener()
            {
                var inventario = await _inventarioFlujo.Obtener();
                if (inventario == null || !inventario.Any())
                    return NoContent();
                return Ok(inventario);
            }
        }
    
}
