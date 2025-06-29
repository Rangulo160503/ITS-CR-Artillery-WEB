using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class PedidoInventario
    {
        public int Id { get; set; }
        public string Articulo { get; set; } = null!;
        public int Cantidad { get; set; }
        public DateTime FechaPedido { get; set; }
        public string Condicion { get; set; } = null!;
    }
}
