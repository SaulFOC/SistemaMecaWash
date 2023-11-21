﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MecaWash.Proyecto.Presentacion.Colaborador.Administrador
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["EmpleadoCookie"] != null)
            {
                string valoresSerializados = Request.Cookies["EmpleadoCookie"].Value;

                // Deserializar los valores desde la cookie
                var valoresDeserializados = JsonConvert.DeserializeObject<dynamic>(valoresSerializados);
                string nombre = valoresDeserializados.nombre;
                llbNombre.Text = nombre;
            }
            else
            {
                // La cookie no existe, redirige al usuario a la página de inicio de sesión
                Response.Redirect("./");
            }
        }
    }
}