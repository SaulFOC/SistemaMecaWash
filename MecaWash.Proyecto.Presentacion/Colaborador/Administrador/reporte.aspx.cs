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
    }
}