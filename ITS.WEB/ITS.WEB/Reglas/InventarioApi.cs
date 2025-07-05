using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos.Inventarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Reglas
{
    public class InventarioApi : IInventarioApi
    {
        private readonly HttpClient _httpClient;

        public InventarioApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Inventario>> ObtenerInventarioAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Inventario>>("api/inventario");
        }
    }
}
