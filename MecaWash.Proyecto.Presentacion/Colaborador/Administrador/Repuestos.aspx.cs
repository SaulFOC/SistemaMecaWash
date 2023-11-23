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
    public partial class Repuestos : System.Web.UI.Page
    {
         NInvetario objInventario = new NInvetario();
         EInventario objInventarioE = new EInventario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListarRespuestos();
                VaciarCombo();
                LlenarCombo();
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "Select2Script", "$('.js-example-basic-single').select2();", true);
        }

        //evento del botton
        protected void addInventario(object source, CommandEventArgs e)
        {
            if (e.CommandName== "AgregarInventario")
            {
                int itemId = Convert.ToInt32(e.CommandArgument);
                txtId.Text = itemId.ToString();
                //objInventarioE.IDInventario = itemId;
                //objInventarioE.Cantidad = int.Parse(txtCantidadInventario.Text);
                //objInventario.addInventario(objInventarioE);
                //itemId = 0;
            }
        }

        protected void agregabd(object source, CommandEventArgs e)
        {
            if (e.CommandName == "Insertarbd")
            {
                int item,cantidad;
                item = int.Parse(txtId.Text);
                cantidad= int.Parse(txtCantidadInventario.Text);
                objInventarioE.IDInventario = item;
                objInventarioE.Cantidad = cantidad;
                objInventario.addInventario(objInventarioE);
                txtCantidadInventario.Text = "";
                ListarRespuestos();
            }
        }


        protected void ListarRespuestos()
        {
            GridView1.DataSource = objInventario.listarInventario();
            GridView1.DataBind();
        }
        protected void LlenarCombo()
        {
            ddlBuscar.DataSource = objInventario.listarInventario();
            ddlBuscar.DataTextField = "NombreProducto";
            ddlBuscar.DataValueField = "IDProducto";
            ddlBuscar.DataBind();
        }
        protected void VaciarCombo()
        {
            ddlBuscar.Items.Clear();
            ddlBuscar.Items.Add(new ListItem("Buscar...", "gg"));
        }

        protected void BuscarInventario()
        {
            try
            {
                int id = int.Parse(ddlBuscar.SelectedValue);
                objInventarioE.IDInventario = id;
                GridView1.DataSource = objInventario.BuscarInventario(objInventarioE);
                GridView1.DataBind();
            }
            catch
            {
                ListarRespuestos();
            }
        }

        protected void ddlBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBuscar.Text != "Buscar...")
            {
                BuscarInventario();
            }
        }

        protected void btnMostrarE_Click(object sender, EventArgs e)
        {
            ddlBuscar.SelectedValue = "gg";
            ListarRespuestos();
        }

        protected void Eliminar(object sender, EventArgs e)
        {
            if (ddlBuscar.SelectedValue == "gg")
            {
                ListarRespuestos();
            }

            if (ddlBuscar.Text != "Buscar...")
            {
                BuscarInventario();
            }
            LinkButton btn = (LinkButton)sender;
            String idEmpleado = btn.CommandArgument;
            bool respuesta = objInventario.EliminarInventario(Convert.ToInt32(idEmpleado));

            if (respuesta)
            {
                VaciarCombo();
                LlenarCombo();
                ddlBuscar.SelectedValue = "gg";
                ListarRespuestos();
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ListarRespuestos();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            if (ddlBuscar.Text == "Buscar...")
            {
                ListarRespuestos();
            }
            else
            {
                BuscarInventario();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName=="Insertar")
                {
                    TextBox txtNombre = (TextBox)GridView1.FooterRow.FindControl("txtNombre");
                    TextBox txtDescripcion = (TextBox)GridView1.FooterRow.FindControl("txtDescripcion");
                    TextBox txtCantidad = (TextBox)GridView1.FooterRow.FindControl("txtCantidad");
                    TextBox txtPrecio = (TextBox)GridView1.FooterRow.FindControl("txtPrecio");

                    objInventarioE.NombreProducto = txtNombre.Text;
                    objInventarioE.Descripcion = txtDescripcion.Text;
                    objInventarioE.Cantidad = int.Parse(txtCantidad.Text);
                    objInventarioE.PrecioProducto = double.Parse(txtPrecio.Text);
                    objInventarioE.Estado = 1;
                    int resp= objInventario.RegistrarInventario(objInventarioE);
                    VaciarCombo();
                    LlenarCombo();
                    ddlBuscar.SelectedValue = "gg";
                    ListarRespuestos();
                    if (resp == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "insertAlert", "registroExitoso();", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Error", "notiError('x todos los campos!');", true);
                    }
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error", "notiError('Llenar todos los campos!');", true);
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            if (ddlBuscar.SelectedValue == "gg")
            {
                ListarRespuestos();
            }

            if (ddlBuscar.Text != "Buscar...")
            {
                BuscarInventario();
            }
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
                int n = e.RowIndex;
                int xcod = int.Parse(GridView1.DataKeys[n].Value.ToString());
                TextBox txtId= (TextBox)GridView1.Rows[n].FindControl("txtIdProductoE");
                TextBox txtNombre = (TextBox)GridView1.Rows[n].FindControl("txtNombreE");
                TextBox txtDescripcion = (TextBox)GridView1.Rows[n].FindControl("txtDescripcionE");
                TextBox txtCantidad = (TextBox)GridView1.Rows[n].FindControl("txtCantidadE");
                TextBox txtPrecio = (TextBox)GridView1.Rows[n].FindControl("txtPrecioE");

                objInventarioE.IDInventario =int.Parse(txtId.Text);
                objInventarioE.NombreProducto = txtNombre.Text;
                objInventarioE.Descripcion = txtDescripcion.Text;
                objInventarioE.Cantidad = int.Parse(txtCantidad.Text);
                objInventarioE.PrecioProducto = double.Parse(txtPrecio.Text);
                GridView1.EditIndex = -1;
                objInventario.EditarInventario(objInventarioE);
                VaciarCombo();
                LlenarCombo();
                ddlBuscar.SelectedValue = "gg";
                if (ddlBuscar.Text == "Buscar...")
                {
                    ListarRespuestos();
                }
                else
                {
                    BuscarInventario();
                }
                 ScriptManager.RegisterStartupScript(this, GetType(), "updateAlert", "actualizacionExitosa();", true);

        }
            
        } 
    
}