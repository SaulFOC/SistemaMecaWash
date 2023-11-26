using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MecaWash.Libreria.Entidad;
using MecaWash.Libreria.Negocio;
using System.Data;

namespace MecaWash.Proyecto.Presentacion.Colaborador.Administrador
{
    public partial class empleados : System.Web.UI.Page
    {
        EEmpleado objEmpleadoE = new EEmpleado();
        NEmpleado objEmpleadoN = new NEmpleado();
        apis nApi = new apis();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListarEmpleados();
                VaciarCombo();
                LlenarCombo();
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "Select2Script", "$('.js-example-basic-single').select2();", true);
        }

        protected void Eliminar(object sender, EventArgs e)
        {
            if (ddlBuscar.SelectedValue == "gg")
            {
                ListarEmpleados();
            }

            if (ddlBuscar.Text != "Buscar...")
            {
                BuscarEmpleados();
            }
            LinkButton btn = (LinkButton)sender;
            String idEmpleado = btn.CommandArgument;
            bool respuesta = objEmpleadoN.EliminarEmpleado(Convert.ToInt32(idEmpleado));

            if (respuesta)
            {
                VaciarCombo();
                LlenarCombo();
                ddlBuscar.SelectedValue = "gg";
                ListarEmpleados();
            }
        }

        protected void LlenarCombo()
        {
            ddlBuscar.DataSource = objEmpleadoN.ListarEmpleados();
            ddlBuscar.DataTextField = "Nombre";
            ddlBuscar.DataValueField = "IDEmpleado";
            ddlBuscar.DataBind();
        }
        protected void VaciarCombo()
        {
            ddlBuscar.Items.Clear();
            ddlBuscar.Items.Add(new ListItem("Buscar...", "gg"));
        }
        protected void ListarEmpleados()
        {
            GridView1.DataSource = objEmpleadoN.ListarEmpleados();
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Insertar")
                {
                    TextBox txtDni = (TextBox)GridView1.FooterRow.FindControl("txtDni");
                    TextBox txtClave = (TextBox)GridView1.FooterRow.FindControl("txtClave");
                    TextBox txtNombre = (TextBox)GridView1.FooterRow.FindControl("txtNombre");
                    TextBox txtTelefono = (TextBox)GridView1.FooterRow.FindControl("txtTelefono");
                    TextBox txtCorreo = (TextBox)GridView1.FooterRow.FindControl("txtCorreo");
                    DropDownList ddlPuesto = (DropDownList)GridView1.FooterRow.FindControl("ddlPuesto");
                    objEmpleadoE.Dni = txtDni.Text;
                    objEmpleadoE.Contrasena = txtClave.Text;
                    objEmpleadoE.Nombre = txtNombre.Text;
                    objEmpleadoE.Telefono = txtTelefono.Text;
                    objEmpleadoE.CorreoElectronico = txtCorreo.Text;
                    objEmpleadoE.Puesto = ddlPuesto.SelectedValue;
                    objEmpleadoE.Estado = 1;
                    int respuesta= objEmpleadoN.RegistrarEmpleado(objEmpleadoE);
                    VaciarCombo();
                    LlenarCombo();
                    ddlBuscar.SelectedValue = "gg";
                    ListarEmpleados();
                    if (respuesta == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "insertAlert", "registroExitoso();", true);
                    }else{
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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ListarEmpleados();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            if (ddlBuscar.SelectedValue == "gg")
            {
                ListarEmpleados();
            }
            
            if(ddlBuscar.Text != "Buscar..."){
                BuscarEmpleados();
            }
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int n = e.RowIndex;
            int xcod = int.Parse(GridView1.DataKeys[n].Value.ToString());

            TextBox txtId = (TextBox)GridView1.Rows[n].FindControl("txtIdEmpleadoE");
            TextBox txtDni = (TextBox)GridView1.Rows[n].FindControl("txtDniE");
            TextBox txtClave = (TextBox)GridView1.Rows[n].FindControl("txtClaveE");
            TextBox txtNombre = (TextBox)GridView1.Rows[n].FindControl("txtNombreE");
            TextBox txtTelefono = (TextBox)GridView1.Rows[n].FindControl("txtTelefonoE");
            TextBox txtCorreo = (TextBox)GridView1.Rows[n].FindControl("txtCorreoE");
            TextBox txtPuesto = (TextBox)GridView1.Rows[n].FindControl("txtPuestoE");
            DropDownList ddlPuesto = (DropDownList)GridView1.Rows[n].FindControl("ddlPuestoE");
            string p;
            if (ddlPuesto.SelectedValue == "Seleccionar")
            {
                p = txtPuesto.Text;
            }
            else
            {
                p = ddlPuesto.SelectedValue;
            }

            objEmpleadoE.IDEmpleado = int.Parse(txtId.Text);
            objEmpleadoE.Dni = txtDni.Text;
            objEmpleadoE.Contrasena = txtClave.Text;
            objEmpleadoE.Nombre = txtNombre.Text;
            objEmpleadoE.Telefono = txtTelefono.Text;
            objEmpleadoE.CorreoElectronico = txtCorreo.Text;
            objEmpleadoE.Puesto = p;
            GridView1.EditIndex = -1;
            objEmpleadoN.EditarEmpleado(objEmpleadoE);
            VaciarCombo();
            LlenarCombo();
            ddlBuscar.SelectedValue = "gg";
            if (ddlBuscar.Text == "Buscar...")
            {
                ListarEmpleados();
            }
            else
            {
                BuscarEmpleados();
            }
                ScriptManager.RegisterStartupScript(this, GetType(), "updateAlert", "actualizacionExitosa();", true);
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            if (ddlBuscar.Text == "Buscar...")
            {
                ListarEmpleados();
            }
            else
            {
                BuscarEmpleados();
            }
        }

        protected void ddlBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBuscar.Text != "Buscar...")
            {
                BuscarEmpleados();
            }
        }

        protected void BuscarEmpleados()
        {
            try
            {
                int id = int.Parse(ddlBuscar.SelectedValue);
                objEmpleadoE.IDEmpleado = id;
                GridView1.DataSource = objEmpleadoN.BuscarEmpleado(objEmpleadoE);
                GridView1.DataBind();
            }
            catch
            {
                ListarEmpleados();
            }
            
        }

        protected void btnMostrarE_Click(object sender, EventArgs e)
        {
            ddlBuscar.SelectedValue = "gg";
            ListarEmpleados();
        }

        
    }
}