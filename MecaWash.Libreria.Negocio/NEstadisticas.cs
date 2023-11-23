using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MecaWash.Libreria.Datos;

namespace MecaWash.Libreria.Negocio
{
    public class NEstadisticas
    {
        public DataTable ObtenerDatosGraficoEmpleados()
        {
            return DEstadisticas.ObtenerDatosGraficoEmpleados();
        }
        public DataTable ObtenerDatosGraficoServicio()
        {
            return DEstadisticas.ObtenerDatosGraficoServicio();
        }
        public DataTable ObtenerDatosGraficoDias()
        {
            return DEstadisticas.ObtenerDatosGraficoDias();
        }

        public DataTable ObtenerDatosGraficoMeses()
        {
            return DEstadisticas.ObtenerDatosGraficoMeses();
        }
    }
}
