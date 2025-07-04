using Abstracciones.Modelos.Servicios.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.Servicios
{
    public interface IInventarioServicio
    {
        Task<IEnumerable<Inventario>> ObtenerInventarioAsync();
    }
}
