using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MecaWash.Libreria.Entidad;
using MecaWash.Libreria.Datos;
using System.Data;

namespace MecaWash.Libreria.Negocio
{
    public class NVehiculo
    {
        private DVehiculo datos = new DVehiculo();

        public DataTable ListarVehiculo()
        {
            return datos.listarVehiculo();
        }

        public int RegistarVehiculo(EVehiculos obj)
        {
           return datos.RegistrarVehiculo(obj);
        }

        public bool EditarVehiculo(EVehiculos obj)
        {
            
            return datos.EditarVehiculo(obj);
            
        }

        public bool EliminarVehiculo(int id)
        {
            return datos.ElimnarVehiculo(id);
        }

        public DataTable BuscarVehiculo(EVehiculos obj)
        {
            return datos.BuscarVehiculo(obj);
        }

        public DataTable BuscarVehiculoCliente(EVehiculos obj)
        {
            return datos.BuscarVehiculoCliente(obj);
        }
    }
}
