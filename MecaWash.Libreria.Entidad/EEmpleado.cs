using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaWash.Libreria.Entidad
{
    public class EEmpleado
    {
        public int IDEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public string Puesto { get; set; }
        public string Contrasena { get; set; }
        public int Estado { get; set; }
    }
}
