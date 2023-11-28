using MecaWash.Libreria.Negocio;
using MecaWash.Libreria.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace MecaWash.Proyecto.Presentacion.Colaborador.Administrador
{
    public partial class carrito : System.Web.UI.Page
    {
        NServicioPresencial negocio = new NServicioPresencial();
        NServicio objServiciosN = new NServicio();
        EDetalleCita objDetalle = new EDetalleCita();

        double sumaSubtotales = 0.0;

        protected void LlenarCombo()
        {
            ddlServicios.DataSource = objServiciosN.ListarServicio();
            ddlServicios.DataTextField = "TipoServicio";
            ddlServicios.DataValueField = "IDServicio";
            ddlServicios.DataBind();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarCombo();
            }
            if (Request.QueryString["idCita"] != null)
            {
                
                string idCita = Request.QueryString["idCita"];
                //convertir el idCita a entero
                int id = Convert.ToInt32(idCita);
                txtIdCita.Text = idCita;
                //llamar al metodo listarCita de la clase NServicioPresencial
                GridView1.DataSource = negocio.listarCita(id);
                GridView1.DataBind();
                
            }
        }

        protected void ddlServicios_SelectedIndexChanged1(object sender, EventArgs e)
        {
           
                DataTable dt = new DataTable();
                dt = objServiciosN.BuscarPrecioServicio(Convert.ToInt32(ddlServicios.SelectedValue));

                if (dt.Rows.Count > 0)
                {
                    double precio = Convert.ToDouble(dt.Rows[0]["PrecioServicio"]);
                    txtTotal.Text = precio.ToString();
                }
                else
                {
                    txtTotal.Text = "0";
                }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                double total = Convert.ToDouble(txtTotal.Text);
                double descuento = Convert.ToDouble(txtDescuento.Text);
                int idcita = Convert.ToInt32(txtIdCita.Text);
                int servicio = Convert.ToInt32(ddlServicios.SelectedValue);

                objDetalle.IDCita = idcita;
                objDetalle.servicio = servicio;
                objDetalle.precio = Convert.ToDecimal(total);
                objDetalle.descuento = Convert.ToDecimal(descuento);

                negocio.insertarDetalleCitaPresencial(objDetalle);
                Response.Redirect("carrito.aspx?idCita=" + idcita);
                ScriptManager.RegisterStartupScript(this, GetType(), "insertAlert", "registroExitoso();", true);
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error", $"notiError('Error durante la inserción: {ex.Message}');", true);
            }
            
        }

        protected void Eliminar(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string[] args = btn.CommandArgument.Split(',');

            if (args.Length == 2)
            {
                int idCita = Convert.ToInt32(args[0]);
                int idServicio = Convert.ToInt32(args[1]);

                objDetalle.IDCita = idCita;
                objDetalle.servicio = idServicio;

                negocio.eliminarDetalleCitaPresencial(objDetalle);
                Response.Redirect("carrito.aspx?idCita=" + idCita);
                //imprimir las variables en una alerta de idCita y idServicio
                ScriptManager.RegisterStartupScript(this, GetType(), "consoleScript", $"console.log('idCita: {idCita}, idServicio: {idServicio}');", true);
                //llamar a la alerta de si estas seguro de eliminar
                ScriptManager.RegisterStartupScript(this, GetType(), "insertAlert", "eliminar();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error", $"notiError('Error al eliminar');", true);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Vehiculos.aspx");
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               
                double subtotal = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "subtotal"));

              
                sumaSubtotales += subtotal;
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
              
                Label lblSumaSubtotales = (Label)e.Row.FindControl("lblSumaSubtotales");
                lblSumaSubtotales.Text = sumaSubtotales.ToString("C"); 
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

                double subtotal = Convert.ToDouble(GridView1.DataKeys[e.RowIndex]["subtotal"]);

              
                sumaSubtotales -= subtotal;

               
                lblSumaSubtotales.Text = sumaSubtotales.ToString("C");  // Puedes personalizar el formato según tus necesidades

        }
        
    }
}