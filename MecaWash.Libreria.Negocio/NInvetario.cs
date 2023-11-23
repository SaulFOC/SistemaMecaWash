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
   
    public class NInvetario
    {
        private DInventario objInventario = new DInventario();

        public DataTable listarInventario()
        {
            return objInventario.ListarInventario();
        }
        public DataTable BuscarInventario(EInventario obj)
        {
            return objInventario.BuscarInventario(obj);
        }

        public int AgregarInventario(EInventario obj)
        {
            return objInventario.AgregarInventario(obj);
        }

        public int addInventario(EInventario obj)
        {
            return objInventario.AgregarInventario(obj);
        }

        public int RegistrarInventario(EInventario obj)
        {
            int error = 1;

            if (string.IsNullOrEmpty(obj.NombreProducto) || string.IsNullOrWhiteSpace(obj.NombreProducto))
            {
                error = 0;
            }else if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                error = 0;
            }else if(obj.Cantidad==0)
            {
                error = 0;
            }else if(obj.PrecioProducto==0)
            {
                error = 0;
            }

            if (error==1)
            {
                return objInventario.RegistrarInventario(obj);
            }
            else
            {
                error = 0;
            }
            return error;
        }

        public bool EditarInventario(EInventario obj)
        {
            bool error = true;
            if (string.IsNullOrEmpty(obj.NombreProducto) || string.IsNullOrWhiteSpace(obj.NombreProducto))
            {
                error = false;
            }
            else if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                error = false;
            }
            else if (obj.Cantidad == 0)
            {
                error = false;
            }
            else if (obj.PrecioProducto == 0)
            {
                error = false;
            }

            if (error == true)
            {
                return objInventario.ActualizarInventario(obj);
            }
            else
            {
                error = false;
            }
            return error;
        }

        public bool EliminarInventario(int id)
        {
            return objInventario.EliminarInventario(id);
        }

       
    }
}
