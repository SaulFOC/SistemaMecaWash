using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using MecaWash.Libreria.Entidad;
using MecaWash.Libreria.Negocio;
using System.Threading.Tasks;

namespace MecaWash.Proyecto.Presentacion.Cliente
{
    public partial class carrito : System.Web.UI.Page
    {
        NCarrito objC = new NCarrito();
        ECarrito objEC = new ECarrito();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarCarrito();
            }

        }
        protected void MostrarCarrito()
        {
            HttpCookie carritoCookie = Request.Cookies["Carrito"];

            // Verifica si la cookie existe y tiene datos.
            if (carritoCookie != null && !string.IsNullOrEmpty(carritoCookie.Value))
            {
                // Deserializa la cookie en una lista de productos.
                List<CarritoServicio> carrito = JsonConvert.DeserializeObject<List<CarritoServicio>>(carritoCookie.Value);

                // Asigna la lista al Repeater.
                Repeater1.DataSource = carrito;
                Repeater1.DataBind();
            }
            else
            {
                // Si la cookie está vacía, puedes mostrar un mensaje o dejar el Repeater vacío.
                Repeater1.Visible = false;
                Response.Write("El carrito está vacío.");
            }
        }

        protected void QuitarCarrito(object source, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Quitar")
                {
                    string[] argumentos = e.CommandArgument.ToString().Split('|');
                    string ids = argumentos[0];
                    string idc = argumentos[1];

                    int idServicio = int.Parse(ids);
                    int idCliente = int.Parse(idc);


                    HttpCookie carritoCookie = Request.Cookies["Carrito"];

                    // Deserializa la cookie en una lista de productos.
                    List<CarritoServicio> carrito = new List<CarritoServicio>();
                    if (carritoCookie != null && !string.IsNullOrEmpty(carritoCookie.Value))
                    {
                        carrito = JsonConvert.DeserializeObject<List<CarritoServicio>>(carritoCookie.Value);

                        // Buscar el índice del producto con la idServicio especificada
                        int index = carrito.FindIndex(item => item.Ids == idServicio);

                        // Verificar si se encontró el producto
                        if (index != -1)
                        {
                            // Eliminar el producto de la lista
                            carrito.RemoveAt(index);

                            // Serializa la lista de productos y actualiza la cookie.
                            carritoCookie.Value = JsonConvert.SerializeObject(carrito);
                            Response.Cookies.Set(carritoCookie);

                            Task.Run(() => EliminarCarritoBD(idCliente, idServicio));

                            List<CarritoServicio> carrito2 = new List<CarritoServicio>();
                            carrito2 = JsonConvert.DeserializeObject<List<CarritoServicio>>(carritoCookie.Value);
                            Repeater1.DataSource = carrito2;
                            Repeater1.DataBind();

                            ScriptManager.RegisterStartupScript(this, GetType(), "exito", "notiExito('Servicio quitado!','Se quito el servicio del carrito!');", true);
                        }
                    }
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "exito", "notiError('No eliminar el servicio del carrito!');", true);
            }
        }

        public async Task EliminarCarritoBD(int idc, int ids)
        {
            objEC.IDCliente = idc;
            objEC.IDServicio = ids;
            await Task.Run(() => objC.EliminarCarrito(objEC));
        }
    }
}