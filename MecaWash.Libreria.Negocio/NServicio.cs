using MecaWash.Libreria.Datos;
using MecaWash.Libreria.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaWash.Libreria.Negocio
{
    public class NServicio
    {
        private DServicio datos = new DServicio();

        public DataTable ListarServicio()
        {
            return datos.ListarServicio();
        }

        public int RegistrarServicio(EServicios obj)
        {
            int error = 1;
            if (string.IsNullOrEmpty(obj.TipoServicio) || string.IsNullOrWhiteSpace(obj.TipoServicio))
            {
                error = 0;
            }
            else if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                error = 0;
            }
            else if (obj.PrecioServicio == 0)
            {
                error = 0;
            }
            if (error == 1)
            {
                return datos.RegistrarServicio(obj);
            }
            else
            {
                error = 0;
            }
            return error;
        }

        public bool EditarServicio(EServicios obj)
        {
            bool error = false;
            if (string.IsNullOrEmpty(obj.TipoServicio) || string.IsNullOrWhiteSpace(obj.TipoServicio))
            {
                error = true;
            }
            else if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                error = true;
            }
            else if (obj.PrecioServicio == 0)
            {
                error = true;
            }
            if (error == false)
            {
                return datos.EditarServicio(obj);
            }
            else
            {
                return false;
            }
        }

        public bool EliminarServicio(int id)
        {
            return datos.EliminarServicio(id);
        }

        public DataTable BuscarServicio(EServicios obj)
        {
            return datos.BuscarServicio(obj);
        }
    }
}
