using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos.Servicios.Inventario
{
    public class RespuestaInventarioAPI
    {
        public List<ItemInventarioAPI> Items { get; set; } = new();
    }

    public class ItemInventarioAPI
    {
        public int ProductCode { get; set; }
        public string EquipmentDescription { get; set; }
        public string Brand { get; set; }
        public int InStock { get; set; }
        public int OutStock { get; set; }
        public int Available { get; set; }

        public string OutTicket { get; set; }
        public string OutTech { get; set; }
        public string OutDate { get; set; }
        public int OutQuantity { get; set; }

        public string InTicket { get; set; }
        public string InTech { get; set; }
        public string InDate { get; set; }
        public int InQuantity { get; set; }

        public string OrderEquipo { get; set; }
        public int OrderMinimo { get; set; }
        public int OrderPedirAntesDe { get; set; }
        public string OrderArticulo { get; set; }
        public int OrderCantidad { get; set; }
        public string OrderFechaDePedido { get; set; }
        public string OrderCondicion { get; set; }
    }
}
