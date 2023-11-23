using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MecaWash.Libreria.Negocio;
using MecaWash.Libreria.Entidad;
using System.Data;

namespace MecaWash.Proyecto.Presentacion.Colaborador.Administrador
{
    public partial class citas : System.Web.UI.Page
    {
        NCita nC = new NCita();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarCitasNuevas();
            }
        }

        protected void LlenarCitasNuevas()
        {
            DataTable dt = nC.ListarCita();
            if (dt.Rows.Count > 0)
            {
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
            else
            {
                Repeater1.Visible = false;
                lblNoti.Text = "Aun no se agendan citas...";
            }
            
        }
    }
}