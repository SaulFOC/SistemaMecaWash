using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using MecaWash.Libreria.Negocio;

namespace MecaWash.Proyecto.Presentacion.Colaborador.Administrador
{
    public partial class grafico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string ObtenerDatosGraficoEmpleados()
        {
            // Llamar a la capa de negocios para obtener los datos
            NEstadisticas servicioGrafico = new NEstadisticas();
            var datos = servicioGrafico.ObtenerDatosGraficoEmpleados();

            // Serializar los datos a formato JSON y devolverlos
            return JsonConvert.SerializeObject(datos);
        }

        [WebMethod]
        public static string ObtenerDatosGraficoServicio()
        {
            // Llamar a la capa de negocios para obtener los datos
            NEstadisticas servicioGrafico = new NEstadisticas();
            var datos = servicioGrafico.ObtenerDatosGraficoServicio();

            // Serializar los datos a formato JSON y devolverlos
            return JsonConvert.SerializeObject(datos);
        }
        [WebMethod]
        public static string ObtenerDatosGraficoDias()
        {
            // Llamar a la capa de negocios para obtener los datos
            NEstadisticas servicioGrafico = new NEstadisticas();
            var datos = servicioGrafico.ObtenerDatosGraficoDias();

            // Serializar los datos a formato JSON y devolverlos
            return JsonConvert.SerializeObject(datos);
        }

        [WebMethod]
        public static string ObtenerDatosGraficoMeses()
        {
            // Llamar a la capa de negocios para obtener los datos
            NEstadisticas servicioGrafico = new NEstadisticas();
            var datos = servicioGrafico.ObtenerDatosGraficoMeses();

            // Serializar los datos a formato JSON y devolverlos
            return JsonConvert.SerializeObject(datos);
        }
    }
}