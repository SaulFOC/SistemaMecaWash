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
        EVehiculos eV = new EVehiculos();
        NVehiculo nV = new NVehiculo();
        ECita eCi = new ECita();
        NCita nCi = new NCita();

        protected void Page_Load(object sender, EventArgs e)
        {
            int idc=0;
            if (Request.Cookies["ClienteCookie"] != null)
            {
                string valoresSerializados = Request.Cookies["ClienteCookie"].Value;

                // Deserializar los valores desde la cookie
                var valoresDeserializados = JsonConvert.DeserializeObject<dynamic>(valoresSerializados);
                string id = valoresDeserializados.id;
                idc = int.Parse(id);
            }
            else
            {
                // La cookie no existe, redirige al usuario a la página de inicio de sesión
                Response.Redirect("../");
            }
            if (!IsPostBack)
            {
                MostrarCarrito();
                VaciarCombo();
                LlenarCombo(idc);
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
                lblNoti.Text = "El carrito esta vacio...";
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

        protected void LlenarCombo(int idc)
        {
            try
            {
                eV.IDCliente = idc;
                ddlCarro.DataSource = nV.BuscarVehiculoCliente(eV);
                ddlCarro.DataTextField = "carro";
                ddlCarro.DataValueField = "IDVehiculo";
                ddlCarro.DataBind();
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "exito", "notiError('No ha registrado ningun vehiculo!');", true);
            }
            
        }
        protected void VaciarCombo()
        {
            ddlCarro.Items.Clear();
            ddlCarro.Items.Add(new ListItem("Seleccionar...", "gg"));
        }
        protected void RegistrarCita(object source, CommandEventArgs e)
        {
            if(e.CommandName == "Registrar")
            {
                try
                {
                    if (ddlCarro.SelectedValue != null && txtFechaC.Text != "" && txtHoraC.Text != "")
                    {
                        string fecha, hora;
                        int idc, idv;
                        fecha = txtFechaC.Text;
                        hora = txtHoraC.Text;
                        idv = int.Parse(ddlCarro.SelectedValue.ToString());
                        string valoresSerializados = Request.Cookies["ClienteCookie"].Value;

                        // Deserializar los valores desde la cookie
                        var valoresDeserializados = JsonConvert.DeserializeObject<dynamic>(valoresSerializados);
                        string id = valoresDeserializados.id;
                        idc = int.Parse(id);

                        eCi.Fecha = fecha;
                        eCi.Hora = hora;
                        eCi.IDCliente = idc;
                        eCi.IDVehiculo = idv;
                        nCi.agregarCita(eCi);

                        if (Request.Cookies["Carrito"] != null)
                        {
                            Response.Cookies["Carrito"].Value = "";
                            Response.Cookies["Carrito"].Expires = DateTime.Now.AddDays(-1);
                        }

                        Repeater1.Visible = false;
                        lblNoti.Text = "El carrito esta vacio...";

                        ScriptManager.RegisterStartupScript(this, GetType(), "exito", "notiExito('Compra exitosa!','Se agendo la cita para tu servicio!');", true);

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "error", "notiError('llenar todos los datos!');", true);
                    }
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "notiError('No se pudo agendar agregue vehiculo!');", true);
                }
            }
        }

        protected void AgregarVehiculo(object source, CommandEventArgs e)
        {
            if(e.CommandName== "aggVehiculo")
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
                    VaciarCombo();
                    LlenarCombo(idCliente);
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