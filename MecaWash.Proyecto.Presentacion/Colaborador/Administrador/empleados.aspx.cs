using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MecaWash.Libreria.Entidad;
using MecaWash.Libreria.Negocio;

namespace MecaWash.Proyecto.Presentacion.Colaborador.Administrador
{
    public partial class empleados : System.Web.UI.Page
    {
        EEmpleado objEmpleadoE = new EEmpleado();
        NEmpleado objEmpleadoN = new NEmpleado();
        protected void Page_Load(object sender, EventArgs e)
        {
            ListarEmpleados();
        }
        protected void ListarEmpleados()
        {
            GridView1.DataSource = objEmpleadoN.ListarEmpleados();
            GridView1.DataBind();
        }
    }
}