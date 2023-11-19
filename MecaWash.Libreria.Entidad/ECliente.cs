using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaWash.Libreria.Entidad
{
 //   [IDCliente] [int]  NOT NULL,
 //   [Nombre] [varchar] (50) NULL,
	//[Apellido][varchar] (50) NULL,
 //   [Dni][varchar] (8) NULL
 //   [Direccion][varchar] (100) NULL,
	//[Telefono][varchar] (15) NULL,
	//[CorreoElectronico][varchar] (100) NULL,
	//[Estado][int] (1) NULL,
    public class ECliente
    {
		public int IDCliente { get; set; }
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public int Estado { get; set; }
        public string clave { get; set; }
    }
}
