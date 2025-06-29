using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class PoliticaReabastecimiento
    {
        public int Id { get; set; }

        public int ProductoId { get; set; }

        public int Minimo { get; set; }

        public int PedirAntesDe { get; set; }
    }
}
