using Newtonsoft.Json;
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
    public partial class perfil : System.Web.UI.Page
    {
        EVehiculos eV = new EVehiculos();
        NVehiculo nV = new NVehiculo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["ClienteCookie"] != null)
            {
                string valoresSerializados = Request.Cookies["ClienteCookie"].Value;

                // Deserializar los valores desde la cookie
                var valoresDeserializados = JsonConvert.DeserializeObject<dynamic>(valoresSerializados);
                string id = valoresDeserializados.id;
                string dni = valoresDeserializados.dni;
                string nombre = valoresDeserializados.nombre;
                string direccion = valoresDeserializados.direccion;
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

        protected void AgregarVehiculo(object source, CommandEventArgs e)
        {
            if (e.CommandName == "aggVehiculo")
            {
                try
                {
                    int anio;

                    string valoresSerializados = Request.Cookies["ClienteCookie"].Value;

                    // Deserializar los valores desde la cookie
                    var valoresDeserializados = JsonConvert.DeserializeObject<dynamic>(valoresSerializados);
                    string id = valoresDeserializados.id;
                    int idCliente = int.Parse(id);

                    anio = int.Parse(txtYear.Text);

                    eV.IDCliente = idCliente;
                    eV.Anio = anio;
                    eV.Marca = txtMarcaN.Text;
                    eV.Modelo = txtModeloN.Text;
                    eV.Color = txtColorN.Text;
                    eV.NumeroPlaca = txtPlacaN.Text;
                    eV.Estado = 1;

                    nV.RegistarVehiculo(eV);
                    ScriptManager.RegisterStartupScript(this, GetType(), "exito", "notiExito('Vehiculo registrado!','Se ha registrado tu vehiculo!');", true);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "notiError('llenar todos los datos!');", true);
                }
            }
        }
    }
}