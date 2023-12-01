using MecaWash.Libreria.Entidad;
using MecaWash.Libreria.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MecaWash.Proyecto.Presentacion.Colaborador.Tecnico
{
    public partial class Clientes : System.Web.UI.Page
    {
        ECliente objClienteE = new ECliente();
        NCliente objClienteN = new NCliente();
        apis nApi = new apis();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["TecnicoCookie"] == null)
            {
                Response.Redirect("../");
            }
            if (!IsPostBack)
            {
                ListarCliente();
                VaciarCombo();
                LlenarCombo();
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "Select2Script", "$('.js-example-basic-single').select2();", true);
        }
        protected void Eliminar(object sender, EventArgs e)
        {
            if (ddlBuscar.SelectedValue == "gg")
            {
                ListarCliente();
            }

            if (ddlBuscar.Text != "Buscar...")
            {
                BuscarCliente();
            }
            LinkButton btn = (LinkButton)sender;
            String idCliente = btn.CommandArgument;
            bool respuesta = objClienteN.EliminarCliente(Convert.ToInt32(idCliente));

            if (respuesta)
            {
                VaciarCombo();
                LlenarCombo();
                ddlBuscar.SelectedValue = "gg";
                ListarCliente();
            }
        }
        public void ListarCliente()
        {
            GridView1.DataSource = objClienteN.ListarClientes();
            GridView1.DataBind();
        }
        protected void LlenarCombo()
        {
            ddlBuscar.DataSource = objClienteN.ListarClientes();
            ddlBuscar.DataTextField = "DNI";
            ddlBuscar.DataValueField = "IDCliente";
            ddlBuscar.DataBind();
        }

        protected void VaciarCombo()
        {
            ddlBuscar.Items.Clear();
            ddlBuscar.Items.Add(new ListItem("Buscar...", "gg"));
        }

        protected void BuscarCliente()
        {
            try
            {
                int id = int.Parse(ddlBuscar.SelectedValue);
                objClienteE.IDCliente = id;
                GridView1.DataSource = objClienteN.BuscarCliente(objClienteE);
                GridView1.DataBind();
            }
            catch
            {
                ListarCliente();
            }

        }


        protected void ddlBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBuscar.Text != "Buscar...")
            {
                BuscarCliente();
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ListarCliente();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            if (ddlBuscar.Text == "Buscar...")
            {
                ListarCliente();
            }
            else
            {
                BuscarCliente();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Insertar")
                {
                    TextBox txtDni = (TextBox)GridView1.FooterRow.FindControl("txtDni");
                    TextBox txtNombre = (TextBox)GridView1.FooterRow.FindControl("txtNombre");
                    TextBox txtClave = (TextBox)GridView1.FooterRow.FindControl("txtClave");
                    TextBox txtTelefono = (TextBox)GridView1.FooterRow.FindControl("txtTelefono");
                    TextBox txtCorreo = (TextBox)GridView1.FooterRow.FindControl("txtCorreo");
                    TextBox txtDireccion = (TextBox)GridView1.FooterRow.FindControl("txtDireccion");

                    objClienteE.Dni = txtDni.Text;
                    objClienteE.Nombre = txtNombre.Text;
                    objClienteE.Telefono = txtTelefono.Text;
                    objClienteE.CorreoElectronico = txtCorreo.Text;
                    objClienteE.Direccion = txtDireccion.Text;
                    objClienteE.clave = txtClave.Text;
                    objClienteE.Estado = 1;
                    int resp = objClienteN.RegistrarCliente(objClienteE);
                    VaciarCombo();
                    LlenarCombo();
                    ddlBuscar.SelectedValue = "gg";
                    ListarCliente();
                    if (resp == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "insertAlert", "registroExitoso();", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Error", "notiError('Llenar todos los campos!');", true);
                    }
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error", "notiError('Llenar todos los campos!');", true);
            }

            try
            {

                if (e.CommandName == "BuscarNombre")
                {
                    TextBox txtDni = (TextBox)GridView1.FooterRow.FindControl("txtDni");
                    TextBox txtNombre = (TextBox)GridView1.FooterRow.FindControl("txtNombre");

                    if (txtDni.Text.Length == 8)
                    {
                        dynamic respuesta = nApi.Get("https://dniruc.apisperu.com/api/v1/dni/" + txtDni.Text + "?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6Im1hcnRpbmNhY2VyZXMyNTQzQGdtYWlsLmNvbSJ9.2L9dqF_KgPP7WLepsD50TlrK3w7i2VjDd0IekWz8cVE");
                        txtNombre.Text = respuesta.nombres.ToString() + " " + respuesta.apellidoPaterno.ToString() + " " + respuesta.apellidoMaterno.ToString();
                    }
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error", "notiError('Dni no existe!');", true);
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            if (ddlBuscar.SelectedValue == "gg")
            {
                ListarCliente();
            }

            if (ddlBuscar.Text != "Buscar...")
            {
                BuscarCliente();
            }
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int n = e.RowIndex;
            int xcod = int.Parse(GridView1.DataKeys[n].Value.ToString());

            TextBox txtIdCliente = (TextBox)GridView1.Rows[n].FindControl("txtIdClienteE");
            TextBox txtDni = (TextBox)GridView1.Rows[n].FindControl("txtDniE");
            TextBox txtClave = (TextBox)GridView1.Rows[n].FindControl("txtClaveE");
            TextBox txtNombre = (TextBox)GridView1.Rows[n].FindControl("txtNombreE");
            TextBox txtTelefono = (TextBox)GridView1.Rows[n].FindControl("txtTelefonoE");
            TextBox txtCorreo = (TextBox)GridView1.Rows[n].FindControl("txtCorreoE");
            TextBox txtDireccion = (TextBox)GridView1.Rows[n].FindControl("txtDireccionE");


            objClienteE.IDCliente = int.Parse(txtIdCliente.Text);
            objClienteE.Dni = txtDni.Text;
            objClienteE.Nombre = txtNombre.Text;
            objClienteE.Telefono = txtTelefono.Text;
            objClienteE.CorreoElectronico = txtCorreo.Text;
            objClienteE.Direccion = txtDireccion.Text;
            objClienteE.clave = txtClave.Text;
            GridView1.EditIndex = -1;
            objClienteN.EditarCliente(objClienteE);
            VaciarCombo();
            LlenarCombo();
            ddlBuscar.SelectedValue = "gg";
            if (ddlBuscar.Text == "Buscar...")
            {
                ListarCliente();
            }
            else
            {
                BuscarCliente();
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "updateAlert", "actualizacionExitosa();", true);
        }

        protected void btnMostrarE_Click(object sender, EventArgs e)
        {
            ddlBuscar.SelectedValue = "gg";
            ListarCliente();
        }
    }
}