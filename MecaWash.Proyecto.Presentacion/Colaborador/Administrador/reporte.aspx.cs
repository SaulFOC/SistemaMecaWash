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
using System.Data.SqlClient;

namespace MecaWash.Proyecto.Presentacion.Colaborador.Administrador
{
    public partial class reporte : System.Web.UI.Page
    {
        NCliente objncliente = new NCliente();
        NEmpleado objempleado = new NEmpleado();
        NVehiculo objvehiculo = new NVehiculo();
        NCita objcita = new NCita();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["EmpleadoCookie"] == null)
            {
                Response.Redirect("../");
            }
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

        protected void btnVentas_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objvehiculo.ListarVehiculo();
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rdc = new ReportDataSource("DataSet1", dt);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("../../reportes/RVentas.rdlc");
            ReportViewer1.LocalReport.DataSources.Add(rdc);
            ReportViewer1.LocalReport.Refresh();
        }

        protected void btnCita_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objvehiculo.ListarVehiculo();
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rdc = new ReportDataSource("DataSet1", dt);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("../../reportes/RCita.rdlc");
            ReportViewer1.LocalReport.DataSources.Add(rdc);
            ReportViewer1.LocalReport.Refresh();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection("Data Source=SQL5101.site4now.net;Initial Catalog=db_aa12b2_mecwash;User Id=db_aa12b2_mecwash_admin;Password=mireyra123");
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("execute reporteCitasFechas " + TextBox1.Text + " " + TextBox2.Text, cn);
            da.Fill(dt);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rdc = new ReportDataSource("DataSet1", dt);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("/reportes/RCita.rdlc");
            ReportViewer1.LocalReport.DataSources.Add(rdc);
            ReportViewer1.LocalReport.Refresh();
        }
    }
    }
