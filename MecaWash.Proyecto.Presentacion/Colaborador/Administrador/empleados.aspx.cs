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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            ListarEmpleados();
        }
        protected void ListarEmpleados()
        {
            GridView1.DataSource = objEmpleadoN.ListarEmpleados();
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
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
                objEmpleadoN.RegistrarEmpleado(objEmpleadoE);
                ListarEmpleados();
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
            ListarEmpleados();
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
            objEmpleadoN.EditarEmpleado(objEmpleadoE);
            ListarEmpleados();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int n = e.RowIndex;
            ListarEmpleados();
            int xcod = int.Parse(GridView1.DataKeys[n].Value.ToString());
            objEmpleadoN.EliminarEmpleado(xcod);
            ListarEmpleados();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            ListarEmpleados();
        }
    }
}