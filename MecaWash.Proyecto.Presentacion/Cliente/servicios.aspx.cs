using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MecaWash.Libreria.Entidad;
using MecaWash.Libreria.Negocio;

namespace MecaWash.Proyecto.Presentacion.Cliente
{
    public partial class servicios : System.Web.UI.Page
    {
        EServicios objE = new EServicios();
        NServicio objN = new NServicio();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idCliente"] == null)
            {
                Response.Redirect("../");
            }
            if (!IsPostBack)
            {
                Repeater1.DataSource = objN.ListarServicio();
                Repeater1.DataBind();
            }
            
        }


        protected void AgregarCarrito(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Agregar")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                int idCliente = int.Parse(Session["idCliente"].ToString());

            }
        }
    }
}