﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MecaWash.Proyecto.Presentacion.Cliente
{
    public partial class cerrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            // Limpiar las cookies de autenticación si las estás utilizando
            if (Request.Cookies["UsuarioAutenticado"] != null)
            {
                Response.Cookies["UsuarioAutenticado"].Value = "";
                Response.Cookies["UsuarioAutenticado"].Expires = DateTime.Now.AddDays(-1);
            }

            // Redirigir a la página de inicio de sesión o a la página principal
            Response.Redirect("../"); // Cambia la URL según tu estructura de proyecto
        }
    }
}