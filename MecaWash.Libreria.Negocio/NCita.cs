using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MecaWash.Libreria.Datos;
using MecaWash.Libreria.Entidad;

namespace MecaWash.Libreria.Negocio
{
    public class NCita
    {
        DCita datos = new DCita();
        public void agregarCita(ECita obj)
        {
            datos.agregarCita(obj);
        }

        public DataTable ListarCita()
        {
            return datos.ListarCita();
        }

        public DataTable ListarCitaAceptada()
        {
            return datos.ListarCitaAceptada();
        }

        public DataTable ListarDetalleCita(ECita obj)
        {
            return datos.ListarDetalleCita(obj);
        }
        public void AceptarCita(ECita obj)
        {
            datos.AceptarCita(obj);
        }
        public DataTable ComprobarDisponibilidad(ECita obj)
        {
            return datos.ComprobarDisponibilidad(obj);
        }
        public void agregarCarritoColor(ECita obj)
        {
            datos.agregarCarritoColor(obj);
        }

        public void insertarCitaColor(ECita obj)
        {
            datos.insertarCitaColor(obj);
        }

        public DataTable ListarCitaAsignada(ECita obj)
        {
            return datos.ListarCitaAsignada(obj);
        }

        public DataTable ReporteFechas(string fechI, string fechaF)
        {
            return datos.ReporteFechas(fechI, fechaF);
        }
    }
}
