using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MecaWash.Proyecto.Presentacion.Cliente
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["idCliente"] != null &&
            Session["dni"] != null &&
            Session["nombre"] != null &&
            Session["direccion"] != null &&
            Session["correo"] != null &&
            Session["clave"] != null)
            {
                int idCliente;
                string dni, nombre, direccion, correo, clave;
                idCliente = int.Parse(Session["idCliente"].ToString());
                dni = Session["dni"].ToString();
                nombre = Session["nombre"].ToString();
                direccion = Session["direccion"].ToString();
                correo = Session["correo"].ToString();
                clave = Session["clave"].ToString();

                llbNombre.Text = nombre;
            }
            else
            {
                Response.Redirect("../");
            }
        }
    }
}