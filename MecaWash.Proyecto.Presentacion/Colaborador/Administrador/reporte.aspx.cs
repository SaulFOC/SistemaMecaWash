using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MecaWash.Libreria.Entidad;
using MecaWash.Libreria.Negocio;
using Microsoft.Reporting.WebForms;
using System.IO;

namespace MecaWash.Proyecto.Presentacion.Colaborador.Administrador
{
    public partial class reporte : System.Web.UI.Page
    {
        NCliente objncliente = new NCliente();
        NEmpleado objempleado = new NEmpleado();
        NVehiculo objvehiculo = new NVehiculo();

        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void BtnCargar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objncliente.ListarClientes();
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rdc = new ReportDataSource("DataSet1", dt);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("../../reportes/Rclientes.rdlc");
            ReportViewer1.LocalReport.DataSources.Add(rdc);
            ReportViewer1.LocalReport.Refresh();
        }

        protected void Btnempleados_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objempleado.ListarEmpleados();
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rdc = new ReportDataSource("DataSet1", dt);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("../../reportes/Rempleados.rdlc");
            ReportViewer1.LocalReport.DataSources.Add(rdc);
            ReportViewer1.LocalReport.Refresh();
        }

        protected void Btnvehiculo_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objvehiculo.ListarVehiculo();
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rdc = new ReportDataSource("DataSet1", dt);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("../../reportes/Rvehiculo.rdlc");
            ReportViewer1.LocalReport.DataSources.Add(rdc);
            ReportViewer1.LocalReport.Refresh();
        }
    }
    }
