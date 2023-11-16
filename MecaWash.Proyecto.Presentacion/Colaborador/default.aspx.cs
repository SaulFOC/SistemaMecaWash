using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MecaWash.Libreria.Entidad;
using MecaWash.Libreria.Negocio;
using System.Data.SqlClient;

namespace MecaWash.Proyecto.Presentacion.Colaborador
{
    public partial class _default : System.Web.UI.Page
    {
        EEmpleado objEmpleadoE = new EEmpleado();
        NEmpleado objEmpleadoN = new NEmpleado();
        
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt =new DataTable();
           string correo = txtCorreo.Text;
           objEmpleadoE.CorreoElectronico = correo;
           dt= objEmpleadoN.VerificarUsuario(objEmpleadoE);


            //verificar si el usuario existe
            if (dt.Rows.Count > 0)
            {
               Response.Redirect("Administrador/default.aspx");
            }
            else
            {
               Response.Write("<script>alert('Usuario no existe')</script>");
            }
            

        }
    }
}