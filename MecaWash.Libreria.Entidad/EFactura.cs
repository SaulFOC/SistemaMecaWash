﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaWash.Libreria.Entidad
{
 //   IDDetalleCliente INT PRIMARY KEY,
 //FechaServicio DATETIME,
 //   IDCliente INT,
 //   IDVehiculo INT,
 //   IDServicio INT,
 //   IDFactura INT,
 //   FOREIGN KEY(IDCliente) REFERENCES Clientes(IDCliente),
 //   FOREIGN KEY(IDVehiculo) REFERENCES Vehiculos(IDVehiculo),
 //   FOREIGN KEY(IDServicio) REFERENCES Servicios(IDServicio),
 //   FOREIGN KEY(IDFactura) REFERENCES Facturas(IDFactura)
    public class EFactura
    {
        public int IDFactura { get; set; }
        public DateTime FechaFactura { get; set; }
        public int IDCliente { get; set; }
        public int IDVehiculo { get; set; }
        public int IDServicio { get; set; }
        public int IDEmpleado { get; set; }
        public double Total { get; set; }
    }
}
