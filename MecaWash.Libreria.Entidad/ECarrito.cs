using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaWash.Libreria.Entidad
{
    public class ECarrito
    {
        public int IDCliente { get; set; }
        public int IDServicio { get; set; }
        public decimal precio { get; set; }
    }
}
