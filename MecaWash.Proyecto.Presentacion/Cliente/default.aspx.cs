using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Globalization;

namespace MecaWash.Proyecto.Presentacion.Cliente
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["ClienteCookie"] != null)
            {
                string valoresSerializados = Request.Cookies["ClienteCookie"].Value;

                // Deserializar los valores desde la cookie
                var valoresDeserializados = JsonConvert.DeserializeObject<dynamic>(valoresSerializados);
                string nombre = valoresDeserializados.nombre;
                string nom = FormatearNombre(nombre);
                llbNombre.Text = nom;
            }
            else
            {
                // La cookie no existe, redirige al usuario a la página de inicio de sesión
                Response.Redirect("../");
            }
        }

        static string FormatearNombre(string nombreCompleto)
        {
            string[] partesNombre = nombreCompleto.Split(' ');

            if (partesNombre.Length >= 2)
            {
                string primerNombre = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(partesNombre[0].ToLower());
                string primerApellido = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(partesNombre[partesNombre.Count() - 2].ToLower());

                return $"{primerNombre} {primerApellido}";
            }

            return nombreCompleto; // Devuelve el nombre original si no hay al menos dos partes.
        }
    }
}