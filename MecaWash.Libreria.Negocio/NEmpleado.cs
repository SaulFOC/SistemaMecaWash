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
    public class NEmpleado
    {
        private DEmpleado datos = new DEmpleado();
        public DataTable ListarEmpleados()
        {  
            return datos.ListarEmpleado();
        }
        public DataTable ListarEmpleadosCompleto()
        {
            return datos.ListarEmpleadosCompleto();
        }
        public int RegistrarEmpleado(EEmpleado obj)
        {
            int error = 0;
            if(obj.Dni.Length != 8)
            {
               error = 1;
            }else if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                error = 1; 
            }
            else if (string.IsNullOrEmpty(obj.Telefono) || string.IsNullOrWhiteSpace(obj.Telefono))
            {
                error = 1;
            }
            else if (string.IsNullOrEmpty(obj.CorreoElectronico) || string.IsNullOrWhiteSpace(obj.CorreoElectronico))
            {
                error = 1;
            }
            else if (string.IsNullOrEmpty(obj.Puesto) || string.IsNullOrWhiteSpace(obj.Puesto))
            {
                error = 1;
            }
            else if (string.IsNullOrEmpty(obj.Contrasena) || string.IsNullOrWhiteSpace(obj.Contrasena))
            {
                error = 1;
            }
            
            if(error== 0)
            {
                //obj.Contrasena = NEncriptacion.Encriptar(obj.Contrasena);
                return datos.RegistrarEmpleado(obj);
            }
            else
            {
                error=1;
            }
            return error;
        }

        public bool EditarEmpleado(EEmpleado obj)
        {
            bool error = false;
            if (obj.Dni.Length != 8)
            {
                error = true;
            }
            else if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                error = true;
            }
            else if (string.IsNullOrEmpty(obj.Telefono) || string.IsNullOrWhiteSpace(obj.Telefono))
            {
                error = true;
            }
            else if (string.IsNullOrEmpty(obj.CorreoElectronico) || string.IsNullOrWhiteSpace(obj.CorreoElectronico))
            {
                error = true;
            }
            else if (string.IsNullOrEmpty(obj.Puesto) || string.IsNullOrWhiteSpace(obj.Puesto))
            {
                error = true;
            }
            else if (string.IsNullOrEmpty(obj.Contrasena) || string.IsNullOrWhiteSpace(obj.Contrasena))
            {
                error = true;
            }

            if (error ==false)
            {
                //obj.Contrasena = NEncriptacion.Encriptar(obj.Contrasena);
                return datos.EditarEmpleado(obj);
            }
            else
            {
                return error;
            }
        }

        public bool EliminarEmpleado(int id)
        {
            return datos.EliminarEmpleado(id);
        }

        public DataTable BuscarEmpleado(EEmpleado obj)
        {
            return datos.BuscarEmpleado(obj);
        }

        public DataTable VerificarUsuario(EEmpleado obj)
        {
            return datos.VerificarUsuario(obj);
        }
    }
}
