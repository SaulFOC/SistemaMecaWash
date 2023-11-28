using MecaWash.Libreria.Negocio;
using MecaWash.Libreria.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MecaWash.Proyecto.Presentacion.Colaborador.Administrador
{
    public partial class carrito : System.Web.UI.Page
    {
        NServicioPresencial negocio = new NServicioPresencial();
        EDetalleCita entidad = new EDetalleCita();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["idCita"] != null)
            {
                
                string idCita = Request.QueryString["idCita"];
                //convertir el idCita a entero
                int id = Convert.ToInt32(idCita);
                //llamar al metodo listarCita de la clase NServicioPresencial
                GridView1.DataSource = negocio.listarCita(id);
                GridView1.DataBind();      
            }
        }
    }
}