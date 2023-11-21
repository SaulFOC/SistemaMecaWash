using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MecaWash.Libreria.Entidad;
using MecaWash.Libreria.Negocio;
using Newtonsoft.Json;

namespace MecaWash.Proyecto.Presentacion.Cliente
{
    public partial class servicios : System.Web.UI.Page
    {
        EServicios objE = new EServicios();
        NServicio objN = new NServicio();
        NCarrito objC = new NCarrito();
        ECarrito objEC = new ECarrito();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["ClienteCookie"] == null)
            {
                Response.Redirect("../");
            }
            if (!IsPostBack)
            {
                llenarServicios();

                //carrito en una session
                if (Request.Cookies["Carrito"] == null)
                {
                    HttpCookie carritoCookie = new HttpCookie("Carrito");
                    carritoCookie.Expires = DateTime.Now.AddDays(10); // Puedes ajustar la duración de la cookie.
                    Response.Cookies.Add(carritoCookie);
                }
            }
            
        }

        protected void llenarServicios()
        {
            Repeater1.DataSource = objN.ListarServicio();
            Repeater1.DataBind();
        }


        protected void AgregarCarrito(object source, CommandEventArgs e)
        {
            if (e.CommandName == "Agregar")
            {
                string[] argumentos = e.CommandArgument.ToString().Split('|');
                string ids = argumentos[0];
                string pre = argumentos[1];
                string imagen =argumentos[2];
                string nom =argumentos[3];
                

                //cookie
                string valoresSerializados = Request.Cookies["ClienteCookie"].Value;
                var valoresDeserializados = JsonConvert.DeserializeObject<dynamic>(valoresSerializados);
                string idc = valoresDeserializados.id;

                int idCliente = int.Parse(idc);
                int idServicio = int.Parse(ids);
                decimal precio = decimal.Parse(pre);

                CarritoServicio nuevoProducto = new CarritoServicio(idCliente, idServicio, precio, imagen, nom);


                HttpCookie carritoCookie = Request.Cookies["Carrito"];

                // Deserializa la cookie en una lista de productos.
                List<CarritoServicio> carrito = new List<CarritoServicio>();
                if (carritoCookie != null && !string.IsNullOrEmpty(carritoCookie.Value))
                {
                    carrito = JsonConvert.DeserializeObject<List<CarritoServicio>>(carritoCookie.Value);
                }

                if (!carrito.Exists(item => item.Ids == idServicio))
                {
                    // Agrega el nuevo producto al carrito.
                    carrito.Add(nuevoProducto);

                    // Serializa la lista de productos y actualiza la cookie.
                    carritoCookie.Value = JsonConvert.SerializeObject(carrito);
                    Response.Cookies.Set(carritoCookie);
                    Task.Run(() => insertarCarritoBD(idCliente, idServicio, precio));
                    ScriptManager.RegisterStartupScript(this, GetType(), "exito", "notiExito('Servicio agregado!','Se agrego el servicio al carrito');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "exito", "notiError('No puede volver a elegir, servicio ya agregado!');", true);
                }
                   
            }
        }

        public async Task insertarCarritoBD(int idc, int ids, decimal precio)
        {
            objEC.IDCliente = idc;
            objEC.IDServicio = ids;
            objEC.precio = precio;
            await Task.Run(() => objC.AgregarCarrritoAsync(objEC));
        }

    }
}