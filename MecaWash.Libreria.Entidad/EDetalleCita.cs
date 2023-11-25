using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaWash.Libreria.Entidad
{
    public class EDetalleCita
    {
        public int IDCita { get; set; }
        public string servicio { get; set; }
        public decimal precio { get; set; }
        public decimal descuento { get; set; }
        public decimal subtotal { get; set; }
    }
}
