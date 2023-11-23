using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MecaWash.Libreria.Entidad;
using MecaWash.Libreria.Negocio;
using Newtonsoft.Json;


namespace MecaWash.Proyecto.Presentacion.Colaborador
{
    public partial class _default : System.Web.UI.Page
    {
        EEmpleado objEmpleadoE = new EEmpleado();
        NEmpleado objEmpleadoN = new NEmpleado();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["EmpleadoCookie"] != null)
            {
                Response.Redirect("Administrador");
            }
            InitializeCulture();
        }

        protected void LoguearEmpleado(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Loguear")
            {
                DataTable dt2 = new DataTable();
                string correo, clave;
                correo = txtCorreo.Text;
                clave = txtPassword.Text;
                objEmpleadoE.CorreoElectronico = correo;
                objEmpleadoE.Contrasena = clave;
                dt2 = objEmpleadoN.loguearEmpleado(objEmpleadoE);

                if (dt2.Rows.Count > 0)
                {
                    if (dt2.Rows[0]["Estado"].ToString() == "1")
                    {
                        string valoresSerializados = JsonConvert.SerializeObject(new { id = dt2.Rows[0]["IDEmpleado"], dni = dt2.Rows[0]["DNI"], nombre = dt2.Rows[0]["Nombre"], puesto = dt2.Rows[0]["Puesto"], email = correo });
                        HttpCookie cookie = new HttpCookie("EmpleadoCookie");
                        cookie.Value = valoresSerializados;
                        cookie.Expires = DateTime.Now.AddDays(7); // Puedes ajustar la expiración según tus necesidades
                        Response.Cookies.Add(cookie);
                        Response.Redirect("Administrador");
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Error", "notiError('Correo o clave incorrecta!');", true);
                }
            }            
        }


    }
}