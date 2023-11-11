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
            int error = 0;
            if (string.IsNullOrEmpty(obj.NumeroPlaca) || string.IsNullOrWhiteSpace(obj.NumeroPlaca))
            {
                error = 1;
            }else if(obj.NumeroPlaca.Length != 6)
            {
                error = 1;
            }
            else if (string.IsNullOrEmpty(obj.Marca) || string.IsNullOrWhiteSpace(obj.Marca))
            {
                error = 1;
            }
            else if (string.IsNullOrEmpty(obj.Modelo) || string.IsNullOrWhiteSpace(obj.Modelo))
            {
                error = 1;
            }
            else if (string.IsNullOrEmpty(obj.Color) || string.IsNullOrWhiteSpace(obj.Color))
            {
                error = 1;
            }
            else if (obj.Anio == 0)
            {
                error = 1;
            }
            else if (obj.IDCliente == 0)
            {
                error = 1;
            }

            if (error == 0)
            {
                return datos.RegistrarVehiculo(obj);
            }
            else
            {
                return error;
            }
        }

        public bool EditarVehiculo(EVehiculos obj)
        {
            bool error = false;
            if (string.IsNullOrEmpty(obj.NumeroPlaca) || string.IsNullOrWhiteSpace(obj.NumeroPlaca))
            {
                error = true;
            }
            else if (obj.NumeroPlaca.Length != 6)
            {
                error = true;
            }
            else if (string.IsNullOrEmpty(obj.Marca) || string.IsNullOrWhiteSpace(obj.Marca))
            {
                error = true;
            }
            else if (string.IsNullOrEmpty(obj.Modelo) || string.IsNullOrWhiteSpace(obj.Modelo))
            {
                error = true;
            }
            else if (string.IsNullOrEmpty(obj.Color) || string.IsNullOrWhiteSpace(obj.Color))
            {
                error = true;
            }
            else if (obj.Anio == 0)
            {
                error = true;
            }
            else if (obj.IDCliente == 0)
            {
                error = true;
            }

            if (error == false)
            {
                return datos.EditarVehiculo(obj);
            }
            else
            {
                return error;
            }
        }

        public bool EliminarVehiculo(int id)
        {
            return datos.ElimnarVehiculo(id);
        }

        public DataTable BuscarVehiculo(EVehiculos obj)
        {
            return datos.BuscarVehiculo(obj);
        }
    }
}
