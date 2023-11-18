using MecaWash.Libreria.Entidad;
using MecaWash.Libreria.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MecaWash.Proyecto.Presentacion.Colaborador.Administrador
{
    public partial class Vehiculos : System.Web.UI.Page
    {
        EVehiculos objVehiculoE = new EVehiculos();
        NVehiculo objVehiculoN = new NVehiculo();

        protected void ListarVehiculos()
        {
            GridView1.DataSource = objVehiculoN.ListarVehiculo();
            GridView1.DataBind();
        }

        protected void Eliminar(object sender, EventArgs e)
        {
            if (ddlBuscar.SelectedValue == "gg")
            {
                ListarVehiculos();
            }

            if (ddlBuscar.Text != "Buscar...")
            {
                BuscarVehiculo();
            }
            LinkButton btn = (LinkButton)sender;
            String idVehiculo = btn.CommandArgument;
            bool respuesta = objVehiculoN.EliminarVehiculo(Convert.ToInt32(idVehiculo));

            if (respuesta)
            {
                VaciarCombo();
                LlenarCombo();
                ddlBuscar.SelectedValue = "gg";
                ListarVehiculos();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListarVehiculos();
                VaciarCombo();
                LlenarCombo();
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "Select2Script", "$('.js-example-basic-single').select2();", true);
        }
        protected void LlenarCombo()
        {
            ddlBuscar.DataSource = objVehiculoN.ListarVehiculo();
            ddlBuscar.DataTextField = "NumeroPlaca";
            ddlBuscar.DataValueField = "IDVehiculo";
            ddlBuscar.DataBind();
        }

        protected void VaciarCombo()
        {
            ddlBuscar.Items.Clear();
            ddlBuscar.Items.Add(new ListItem("Buscar...", "gg"));
        }

        protected void BuscarVehiculo()
        {
            try
            {
                int id = int.Parse(ddlBuscar.SelectedValue);
                objVehiculoE.IDVehiculo = id;
                GridView1.DataSource = objVehiculoN.BuscarVehiculo(objVehiculoE);
                GridView1.DataBind();
            }
            catch
            {
                ListarVehiculos();
            }

        }

        protected void ddlBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBuscar.Text != "Buscar...")
            {
                BuscarVehiculo();
            }
        }

        protected void btnMostrarE_Click(object sender, EventArgs e)
        {
            ddlBuscar.SelectedValue = "gg";
            ListarVehiculos();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ListarVehiculos();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            if (ddlBuscar.Text == "Buscar...")
            {
                ListarVehiculos();
            }
            else
            {
                BuscarVehiculo();
            }
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //try
            //{
            //    if (e.CommandName == "Insertar")
            //    {
            //        TextBox txtDni = (TextBox)GridView1.FooterRow.FindControl("txtDni");
            //        TextBox txtNombre = (TextBox)GridView1.FooterRow.FindControl("txtNombre");
            //        TextBox txtClave = (TextBox)GridView1.FooterRow.FindControl("txtClave");
            //        TextBox txtTelefono = (TextBox)GridView1.FooterRow.FindControl("txtTelefono");
            //        TextBox txtCorreo = (TextBox)GridView1.FooterRow.FindControl("txtCorreo");
            //        TextBox txtDireccion = (TextBox)GridView1.FooterRow.FindControl("txtDireccion");

            //        objClienteE.Dni = txtDni.Text;
            //        objClienteE.Nombre = txtNombre.Text;
            //        objClienteE.Telefono = txtTelefono.Text;
            //        objClienteE.CorreoElectronico = txtCorreo.Text;
            //        objClienteE.Direccion = txtDireccion.Text;
            //        objClienteE.clave = txtClave.Text;
            //        objClienteE.Estado = 1;
            //        int resp = objClienteN.RegistrarCliente(objClienteE);
            //        VaciarCombo();
            //        LlenarCombo();
            //        ddlBuscar.SelectedValue = "gg";
            //        ListarCliente();
            //        if (resp == 0)
            //        {
            //            ScriptManager.RegisterStartupScript(this, GetType(), "insertAlert", "registroExitoso();", true);
            //        }
            //        else
            //        {
            //            ScriptManager.RegisterStartupScript(this, GetType(), "Error", "notiError('Llenar todos los campos!');", true);
            //        }
            //    }
            //}
            //catch
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "Error", "notiError('Llenar todos los campos!');", true);
            //}
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        
    }
}