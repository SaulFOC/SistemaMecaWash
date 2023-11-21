using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using MecaWash.Libreria.Entidad;
using MecaWash.Libreria.Negocio;

namespace MecaWash.Proyecto.Presentacion.Cliente
{
    public partial class carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarCarrito();
            }

        }
        protected void MostrarCarrito()
        {
            HttpCookie carritoCookie2 = Request.Cookies["Carrito"];

            // Verifica si la cookie existe y tiene datos.
            if (carritoCookie2 != null && !string.IsNullOrEmpty(carritoCookie2.Value))
            {
                // Deserializa la cookie en una lista de productos.
                List<CarritoServicio> carrito2 = JsonConvert.DeserializeObject<List<CarritoServicio>>(carritoCookie2.Value);

                // Asigna la lista al Repeater.
                Repeater1.DataSource = carrito2;
                Repeater1.DataBind();
            }
            else
            {
                // Si la cookie está vacía, puedes mostrar un mensaje o dejar el Repeater vacío.
                Repeater1.Visible = false;
                Response.Write("El carrito está vacío.");
            }
        }
    }
}