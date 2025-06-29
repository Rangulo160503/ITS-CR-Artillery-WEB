using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Producto
    {
        public int Id { get; set; }                       // PRODUCT CODE
        public string Descripcion { get; set; }           // EQUIPMENT DESCRIPTION
        public string Marca { get; set; }                 // BRAND
        public int TotalEntradas { get; set; }            // IN
        public int TotalSalidas { get; set; }             // OUT
        public int Disponible { get; set; }               // AVAILABLE
    }
}
