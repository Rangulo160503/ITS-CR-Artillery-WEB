using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reglas
{
    public class Configuracion : IConfiguracion
    {
        private readonly IConfiguration _configuracion;

        public Configuracion(IConfiguration configuracion)
        {
            _configuracion = configuracion;
        }

        public string ObtenerMetodo(string seccion, string nombre)
        {
            var urlBase = ObtenerUrlBase(seccion);
            var metodo = _configuracion
                .GetSection(seccion)
                .Get<APIEndPoint>()
                .Metodos
                .FirstOrDefault(m => m.Nombre == nombre)?.Valor;

            if (string.IsNullOrEmpty(urlBase) || string.IsNullOrEmpty(metodo))
                throw new Exception($"No se encontró configuración para {seccion}:{nombre}");

            return $"{urlBase}/{metodo}";
        }

        private string ObtenerUrlBase(string seccion)
        {
            return _configuracion.GetSection(seccion).Get<APIEndPoint>()?.UrlBase ?? throw new Exception($"No se encontró UrlBase para {seccion}");
        }
    }
}
