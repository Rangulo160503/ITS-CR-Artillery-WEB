using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos.Servicios.Inventario;
using System.Net.Http.Headers;
using System.Text.Json;


namespace Servicios
{
    public class InventarioServicio : IInventarioServicio
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguracion _configuracion;

        public InventarioServicio(IHttpClientFactory httpClientFactory, IConfiguracion configuracion)
        {
            _httpClientFactory = httpClientFactory;
            _configuracion = configuracion;
        }

        public async Task<IEnumerable<Inventario>> ObtenerInventarioAsync()
        {
            var endpoint = _configuracion.ObtenerMetodo("ApiEndPointsInventario", "ListadoInventario");

            var cliente = _httpClientFactory.CreateClient("ServicioInventario");
            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var respuesta = await cliente.GetAsync(endpoint);
            respuesta.EnsureSuccessStatusCode();

            var contenido = await respuesta.Content.ReadAsStringAsync();
            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var resultado = JsonSerializer.Deserialize<List<Inventario>>(contenido, opciones);

            return resultado ?? new List<Inventario>();
        }
    }
}
