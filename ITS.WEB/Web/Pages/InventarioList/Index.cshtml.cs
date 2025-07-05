using Abstracciones.Interfaces.Reglas;
using InventarioModel = Abstracciones.Modelos.Inventarios.Inventario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Inventario
{
    public class IndexModel : PageModel
    {
        private readonly IInventarioApi _inventarioApi;

        public IndexModel(IInventarioApi inventarioApi)
        {
            _inventarioApi = inventarioApi;
        }

        public List<InventarioModel> Inventarios { get; set; } = new List<InventarioModel>();

        public async Task OnGetAsync()
        {
            Inventarios = (await _inventarioApi.ObtenerInventarioAsync()).ToList();
        }
    }
}
