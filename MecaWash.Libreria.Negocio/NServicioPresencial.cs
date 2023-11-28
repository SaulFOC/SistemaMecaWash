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
    public class NServicioPresencial
    {
        DServicioPresencial datos = new DServicioPresencial();

        public DataTable listarCitaPresencial(ECita obj)
        {
            return datos.listarCitaPresencial(obj);
        }

        public int InsertarServicioPresencial(ECita obj)
        {
            return datos.InsertarServicioPresencial(obj);
        }

        public DataTable listarCita(int id)
        {
            return datos.listarCita(id);
        }

        public bool EliminarServicioPresencial(int id)
        {
            return datos.eliminarServicioPresencial(id);
        }

        public int insertarDetalleCitaPresencial(EDetalleCita obj)
        {
            return datos.insertarCitaDetallePresencial(obj);
        }

        public bool eliminarDetalleCitaPresencial(EDetalleCita obj)
        {
            return datos.eliminarServicioDeCita(obj);
        }
    }
}
