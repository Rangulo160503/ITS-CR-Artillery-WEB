using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class PoliticaReabastecimientoBase
    {
        [Required(ErrorMessage = "El producto es obligatorio")]
        public Guid ProductoId { get; set; }

        [Required(ErrorMessage = "El mínimo es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "El mínimo debe ser mayor o igual a 0")]
        public int Minimo { get; set; }

        [Required(ErrorMessage = "El punto de pedido es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "El pedir antes de debe ser mayor o igual a 0")]
        public int PedirAntesDe { get; set; }
    }

    public class PoliticaReabastecimientoRequest : PoliticaReabastecimientoBase
    {
        // Aquí no agregamos nada más por ahora,
        // pero podrías expandir si necesitas
    }

    public class PoliticaReabastecimientoResponse : PoliticaReabastecimientoBase
    {
        public Guid Id { get; set; }

        // Información del producto para mostrar en consulta
        public string ProductoDescripcion { get; set; }
        public string ProductoMarca { get; set; }
        public string CategoriaNombre { get; set; }
    }
}
