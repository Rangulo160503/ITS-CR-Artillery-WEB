using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos.Servicios.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flujo
{
    public class InventarioFlujo : IInventarioFlujo
    {
        private readonly IInventarioServicio _inventarioServicio;

        public InventarioFlujo(IInventarioServicio inventarioServicio)
        {
            _inventarioServicio = inventarioServicio;
        }

        public async Task<IEnumerable<Inventario>> Obtener()
        {
            return await _inventarioServicio.ObtenerInventarioAsync();
        }
    }
}
