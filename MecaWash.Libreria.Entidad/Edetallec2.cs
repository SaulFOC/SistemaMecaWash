using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaWash.Libreria.Entidad
{
    public class Edetallec2
    {
        public int IDCita { get; set; }
        public int servicio { get; set; }
        public decimal precio { get; set; }
        public decimal descuento { get; set; }
        public decimal subtotal { get; set; }
        public string Nombre { get; set; }
        public string color { get; set; }
    }
}
