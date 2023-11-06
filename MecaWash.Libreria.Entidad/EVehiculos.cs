using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaWash.Libreria.Entidad
{
 //   [IDVehiculo]
 //   [int]
 //   NOT NULL,

 //   [NumeroPlaca] [varchar] (10) NULL,
	//[Marca][varchar] (50) NULL,
	//[Modelo][varchar] (50) NULL,
	//[Anio][int] NULL,
	//[Color][varchar] (20) NULL,
	//[IDCliente][int] NULL,
    public class EVehiculos
    {
		public int IDVehiculo { get; set; }
        public string NumeroPlaca { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public string Color { get; set; }
        public int IDCliente { get; set; }
    }
}
