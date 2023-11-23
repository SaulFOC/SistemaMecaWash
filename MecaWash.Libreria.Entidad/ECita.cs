using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaWash.Libreria.Entidad
{
 //   [IDCita]
 //   [int]
 //   NOT NULL,

 //   [FechaHoraCita] [datetime] NULL,
	//[IDCliente][int] NULL,
	//[IDVehiculo][int] NULL,
	//[IDServicio][int] NULL,
	//[IDEmpleado][int] NULL,
    public class ECita
    {
		public int IDCita { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public int IDCliente { get; set; }
        public int IDVehiculo { get; set; }
        public int IDEmpleado { get; set; }
    }
}
