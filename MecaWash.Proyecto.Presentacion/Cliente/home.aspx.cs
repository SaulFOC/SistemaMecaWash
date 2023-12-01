using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using MecaWash.Libreria.Entidad;
using MecaWash.Libreria.Negocio;
using System.Data;
using Newtonsoft.Json;

namespace MecaWash.Proyecto.Presentacion.Cliente
{
    public partial class home : System.Web.UI.Page
    {
        NVehiculo nV = new NVehiculo();
        EVehiculos eV = new EVehiculos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Cookies["ClienteCookie"] == null)
            {
                Response.Redirect("../");
            }
            if (!IsPostBack)
            {
                int idc = 0;
                if (Request.Cookies["ClienteCookie"] != null)
                {
                    string valoresSerializados = Request.Cookies["ClienteCookie"].Value;

                    // Deserializar los valores desde la cookie
                    var valoresDeserializados = JsonConvert.DeserializeObject<dynamic>(valoresSerializados);
                    string id = valoresDeserializados.id;
                    idc = int.Parse(id);
                }
                LlenarCombo(idc);
            }
        }
        protected void RegistrarCita(object source, CommandEventArgs e)
        {
            if (e.CommandName == "aggColor")
            {
                try
                {
                    NCita nC = new NCita();
                    ECita eC = new ECita();
                    string colorCa, colorAr, colorVe, f, h;

                    colorCa = txtColorB.Text;
                    colorAr = txtColorA.Text;
                    colorVe = txtColorV.Text;
                    f = fInicio.Text;
                    h = hor.Text;

                    string valoresSerializados = Request.Cookies["ClienteCookie"].Value;

                    // Deserializar los valores desde la cookie
                    var valoresDeserializados = JsonConvert.DeserializeObject<dynamic>(valoresSerializados);
                    string id = valoresDeserializados.id;
                    int idc = int.Parse(id);

                    int idv = int.Parse(DropDownList1.SelectedValue);

                    eC.IDCliente = idc;
                    eC.Fecha = f;
                    eC.Hora = h;
                    eC.IDVehiculo = idv;

                    nC.insertarCitaColor(eC);

                    // Conjunto para rastrear los servicios ya agregados al carrito
                    HashSet<int> serviciosAgregados = new HashSet<int>();

                    if (colorAr != "" && !serviciosAgregados.Contains(16))
                    {
                        eC.Color = colorAr;
                        eC.IDServicio = 16;
                        nC.agregarCarritoColor(eC);
                        serviciosAgregados.Add(16);
                    }
                    if (colorCa != "" && !serviciosAgregados.Contains(15))
                    {
                        eC.Color = colorCa;
                        eC.IDServicio = 15;
                        nC.agregarCarritoColor(eC);
                        serviciosAgregados.Add(15);
                    }
                    if (colorVe != "" && !serviciosAgregados.Contains(17))
                    {
                        eC.Color = colorVe;
                        eC.IDServicio = 17;
                        nC.agregarCarritoColor(eC);
                        serviciosAgregados.Add(17);
                    }

                    

                    ScriptManager.RegisterStartupScript(this, GetType(), "exito", "notiExito('Cita Agendada!','Se realizo la cita!');", true);
                }
                catch
                {
                    // Manejar excepciones según tus necesidades
                    ScriptManager.RegisterStartupScript(this, GetType(), "exito", "notiError('No se pudo agendar agregue un vehiculo!');", true);
                }
            }
            

        }

        protected void LlenarCombo(int idc)
        {
            try
            {
                eV.IDCliente = idc;
                DropDownList1.DataSource = nV.BuscarVehiculoCliente(eV);
                DropDownList1.DataTextField = "carro";
                DropDownList1.DataValueField = "IDVehiculo";
                DropDownList1.DataBind();
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "exito", "notiError('No ha registrado ningun vehiculo!');", true);
            }
        }
    }
}