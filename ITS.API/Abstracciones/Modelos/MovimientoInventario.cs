using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class MovimientoInventario
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public string Ticket { get; set; }
        public string Tecnico { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
        public string TipoMovimiento { get; set; } // IN or OUT
    }
}
