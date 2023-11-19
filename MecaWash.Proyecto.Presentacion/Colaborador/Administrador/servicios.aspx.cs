using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MecaWash.Libreria.Entidad;
using MecaWash.Libreria.Negocio;


namespace MecaWash.Proyecto.Presentacion.Colaborador.Administrador
{
    public partial class servicios : System.Web.UI.Page
    {
        EServicios objServiciosE = new EServicios();
        NServicio objServiciosN = new NServicio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VaciarCombo();
                LlenarCombo();
                ListarServicios();
                
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "Select2Script", "$('.js-example-basic-single').select2();", true);
        }
        protected void Eliminar(object sender, EventArgs e)
        {
            if (ddlBuscar.SelectedValue == "gg")
            {
                ListarServicios();
            }

            if (ddlBuscar.Text != "Buscar...")
            {
                buscarServicio();
            }
            LinkButton btn = (LinkButton)sender;
            String idServicio = btn.CommandArgument;
            bool respuesta = objServiciosN.EliminarServicio(Convert.ToInt32(idServicio));

            if (respuesta)
            {
                VaciarCombo();
                LlenarCombo();
                ddlBuscar.SelectedValue = "gg";
                ListarServicios();
            }
        }

        protected void LlenarCombo()
        {
            ddlBuscar.DataSource = objServiciosN.ListarServicio();
            ddlBuscar.DataTextField = "TipoServicio";
            ddlBuscar.DataValueField = "IDServicio";
            ddlBuscar.DataBind();
        }
        protected void VaciarCombo()
        {
            ddlBuscar.Items.Clear();
            ddlBuscar.Items.Add(new ListItem("Buscar...", "gg"));
        }

        protected void ListarServicios()
        {
            GridView1.DataSource = objServiciosN.ListarServicio();
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ListarServicios();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            if (ddlBuscar.SelectedValue == "gg")
            {
                ListarServicios();
            }

            if (ddlBuscar.Text != "Buscar...")
            {
                buscarServicio();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Insertar")
                {
                    TextBox txtTipoDeServicio = (TextBox)GridView1.FooterRow.FindControl("txtTipoDeServicio");
                    TextBox txtDescripcion = (TextBox)GridView1.FooterRow.FindControl("txtDescripcionServicio");
                    TextBox txtPrecio = (TextBox)GridView1.FooterRow.FindControl("txtPrecio");
                    objServiciosE.TipoServicio = txtTipoDeServicio.Text;
                    objServiciosE.Descripcion = txtDescripcion.Text;
                    objServiciosE.PrecioServicio = Convert.ToDouble(txtPrecio.Text);
                    objServiciosE.Estado = 1;
                    int respuesta = objServiciosN.RegistrarServicio(objServiciosE);

                    VaciarCombo();
                    LlenarCombo();
                    ddlBuscar.SelectedValue = "gg";
                    ListarServicios();

                    if (respuesta == 1)
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
        }

        protected void ddlBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBuscar.Text != "Buscar...")
            {
                buscarServicio();
            }
        }

        protected void buscarServicio()
        {
            try
            {
                int id = int.Parse(ddlBuscar.SelectedValue);
                objServiciosE.IDServicio = id;
                GridView1.DataSource = objServiciosN.BuscarServicio(objServiciosE);
                GridView1.DataBind();
            }
            catch
            {
                ListarServicios();
            }

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int n = e.RowIndex;
            int xcod = int.Parse(GridView1.DataKeys[n].Value.ToString());

            TextBox txtIdServicioE = (TextBox)GridView1.Rows[n].FindControl("txtIdServicioE");
            TextBox txtTipoDeServicio = (TextBox)GridView1.Rows[n].FindControl("txtTipoDeServicioE");
            TextBox txtDescripcion = (TextBox)GridView1.Rows[n].FindControl("txtDescripcionServicioE");
            TextBox txtPrecio = (TextBox)GridView1.Rows[n].FindControl("txtPrecioE");

            objServiciosE.IDServicio = Convert.ToInt32(txtIdServicioE.Text);
            objServiciosE.TipoServicio = txtTipoDeServicio.Text;
            objServiciosE.Descripcion = txtDescripcion.Text;
            objServiciosE.PrecioServicio = Convert.ToDouble(txtPrecio.Text);
           
            GridView1.EditIndex = -1;
            objServiciosN.EditarServicio(objServiciosE);



            VaciarCombo();
            LlenarCombo();
            ddlBuscar.SelectedValue = "gg";
            if (ddlBuscar.Text == "Buscar...")
            {
                ListarServicios();
            }
            else
            {
                buscarServicio();
            }

            ScriptManager.RegisterStartupScript(this, GetType(), "updateAlert", "actualizacionExitosa();", true);
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            if (ddlBuscar.Text == "Buscar...")
            {
                ListarServicios();
            }
            else
            {
                buscarServicio();
            }
        }

        protected void btnMostrarE_Click(object sender, EventArgs e)
        {
            ddlBuscar.SelectedValue = "gg";
            ListarServicios();
        }
    }
}