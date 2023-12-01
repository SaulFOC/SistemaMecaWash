using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MecaWash.Proyecto.Presentacion.Colaborador.Tecnico
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["TecnicoCookie"] != null)
            {
                string valoresSerializados = Request.Cookies["TecnicoCookie"].Value;

                // Deserializar los valores desde la cookie
                var valoresDeserializados = JsonConvert.DeserializeObject<dynamic>(valoresSerializados);
                string id = valoresDeserializados.id;
                string dni = valoresDeserializados.dni;
                string nombre = valoresDeserializados.nombre;
                string direccion = valoresDeserializados.puesto;
                string email = valoresDeserializados.email;

                txtIdm.Text = id;
                txtDniM.Text = dni;
                txtNombreM.Text = nombre;
                txtDireccionM.Text = direccion;
                txtCorreoM.Text = email;
            }
            else
            {
                // La cookie no existe, redirige al usuario a la página de inicio de sesión
                Response.Redirect("../");
            }
        }
    }
}