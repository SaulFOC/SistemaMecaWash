using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MecaWash.Libreria.Entidad;
using MecaWash.Libreria.Negocio;
using System.Data;

namespace MecaWash.Proyecto.Presentacion
{
    public partial class _default : System.Web.UI.Page
    {
        ECliente objE = new ECliente();
        NCliente objN = new NCliente();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoguearCliente2(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Loguear")
            {
                DataTable dt2 = new DataTable();
                string correo, clave;
                correo = txtCorreo.Text;
                clave = txtClave.Text;
                objE.CorreoElectronico = correo;
                objE.clave = clave;
                dt2 = objN.LoguearCliente(objE);

                if (dt2.Rows.Count > 0)
                {
                    Session["idCliente"] = dt2.Rows[0]["IDCliente"];
                    Session["dni"] = dt2.Rows[0]["DNI"];
                    Session["nombre"] = dt2.Rows[0]["Nombre"];
                    Session["direccion"] = dt2.Rows[0]["Direccion"];
                    Session["correo"] = correo;
                    Session["clave"] = clave;

                    Response.Redirect("/Cliente");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Error", "notiError('Correo o clave incorrecta!');", true);
                }
            }
        }
    }
}