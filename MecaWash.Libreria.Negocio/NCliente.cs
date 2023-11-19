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
    public class NCliente
    {
        public DClientes datos = new DClientes();
        public DataTable LoguearCliente(ECliente obj)
        {
            return datos.LoguearCliente(obj);
        }

        public DataTable ListarClientes()
        {
            return datos.ListarClientes();
        }

        public int RegistrarCliente69(ECliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Dni.Length != 8)
            {
                Mensaje = "El DNI debe tener 8 digitos";
            }
            else if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El campo nombre es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Telefono) || string.IsNullOrWhiteSpace(obj.Telefono))
            {
               Mensaje = "El campo telefono es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.CorreoElectronico) || string.IsNullOrWhiteSpace(obj.CorreoElectronico))
            {
                Mensaje = "El campo correo electronico es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Direccion) || string.IsNullOrWhiteSpace(obj.Direccion))
            {
                Mensaje = "El campo direccion es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.clave) || string.IsNullOrWhiteSpace(obj.clave))
            {
                Mensaje = "El campo clave es obligatorio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
               
                return datos.RegistrarCliente69(obj, out Mensaje);
            }
            else
            {
                return 0;
            }
        }

        public int RegistrarCliente(ECliente obj)
        {
            int error = 0;
            if (obj.Dni.Length != 8)
            {
                error = 1;
            }
            else if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
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
            else if (string.IsNullOrEmpty(obj.Direccion) || string.IsNullOrWhiteSpace(obj.Direccion))
            {
                error = 1;
            }
            else if (string.IsNullOrEmpty(obj.clave) || string.IsNullOrWhiteSpace(obj.clave))
            {
                error = 1;
            }

            if (error == 0)
            {
                //obj.Contrasena = NEncriptacion.Encriptar(obj.Contrasena);
                return datos.RegistrarCliente(obj);
            }
            else
            {
                error = 1;
            }
            return error;
        }

        public bool EditarCliente(ECliente obj)
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
            else if (string.IsNullOrEmpty(obj.Direccion) || string.IsNullOrWhiteSpace(obj.Direccion))
            {
                error = true;
            }
            else if (string.IsNullOrEmpty(obj.clave) || string.IsNullOrWhiteSpace(obj.clave))
            {
                error = true;
            }

            if (error == false)
            {
          
                return datos.EditarCliente(obj);
            }
            else
            {
                return error;
            }
        }

        public bool EliminarCliente(int id)
        {
            return datos.EliminarCliente(id);
        }

        public DataTable BuscarCliente(ECliente obj)
        {
            return datos.BuscarCliente(obj);
        }

        public bool ExisteCuenta(ECliente obj)
        {
            bool rpt= false;
            DataTable dt2 = datos.ExisteCuenta(obj);
            if(dt2.Rows.Count == 0)
            {
                rpt = true;
            }
            return rpt;
        }
    }
}
