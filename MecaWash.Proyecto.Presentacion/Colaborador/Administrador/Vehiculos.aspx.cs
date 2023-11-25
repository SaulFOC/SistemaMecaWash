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
        ECliente objClienteE = new ECliente();
        NCliente objClienteN = new NCliente();

        protected void ListarVehiculos()
        {
            GridView1.DataSource = objVehiculoN.ListarVehiculo();
            GridView1.DataBind();
        }

        protected void ActualizarComboCLiente()
        {
            if (IsPostBack)
            {
                LlenarComboCliente();
            }
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
            ActualizarComboCLiente();
           
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListarVehiculos();
                VaciarCombo();
                LlenarCombo(); 
                 
            }
            LlenarComboCliente();
            ScriptManager.RegisterStartupScript(this, GetType(), "Select2Script", "$('.js-example-basic-single').select2();", true);
        }
        protected void LlenarCombo()
        {
            ddlBuscar.DataSource = objVehiculoN.ListarVehiculo();
            ddlBuscar.DataTextField = "NumeroPlaca";
            ddlBuscar.DataValueField = "IDVehiculo";
            ddlBuscar.DataBind();
        }

        //funcion para llenar el combo con los clientes
        protected void LlenarComboCliente()
        {
            DropDownList ddlClienteInsertar = (DropDownList)GridView1.FooterRow.FindControl("ddlBuscarCliente");
            ddlClienteInsertar.DataSource = objClienteN.ListarClientes();
            ddlClienteInsertar.DataTextField = "Nombre";
            ddlClienteInsertar.DataValueField = "IDCliente";
            ddlClienteInsertar.DataBind();
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
            ActualizarComboCLiente();

        }

        protected void ddlBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBuscar.Text != "Buscar...")
            {
                BuscarVehiculo();
            }
            ActualizarComboCLiente();
        }

        protected void btnMostrarE_Click(object sender, EventArgs e)
        {
            ddlBuscar.SelectedValue = "gg";
            ListarVehiculos();
            ActualizarComboCLiente();
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
            ActualizarComboCLiente();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
           
            int n = e.RowIndex;
            int xcod = int.Parse(GridView1.DataKeys[n].Value.ToString());
            try
            {
                string marca, modelo, color, numeroPlaca, idVehiculo;
                string anio, idCliente;
                TextBox txtIdVehiculo = (TextBox)GridView1.Rows[n].FindControl("txtIdVehiculoE");
                TextBox txtNumeroDePlaca = (TextBox)GridView1.Rows[n].FindControl("txtNumeroPlacaE");
                TextBox txtMarca = (TextBox)GridView1.Rows[n].FindControl("txtMarcaE");
                TextBox txtModelo = (TextBox)GridView1.Rows[n].FindControl("txtModeloE");
                TextBox txtAnio = (TextBox)GridView1.Rows[n].FindControl("txtAnnioE");
                TextBox txtColor = (TextBox)GridView1.Rows[n].FindControl("txtColorE");
                DropDownList ddlCliente = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlBuscarClienteE");
                TextBox txtIdCliente = (TextBox)GridView1.Rows[n].FindControl("txtIdClienteE");

                string p;
                if (ddlCliente.SelectedValue == "gg")
                {
                    p = txtIdCliente.Text;
                }
                else
                {
                    p = ddlCliente.SelectedValue;
                }
                // Llenar el DropDownList con la función correspondiente
                //LlenarComboClienteEditar(ddlCliente);

                idVehiculo = txtIdVehiculo.Text;
                marca = txtMarca.Text;
                modelo = txtModelo.Text;
                color = txtColor.Text;
                numeroPlaca = txtNumeroDePlaca.Text;
                anio = txtAnio.Text;
                idCliente = txtIdCliente.Text;



                objVehiculoE.IDVehiculo = int.Parse(idVehiculo.ToString());
                objVehiculoE.NumeroPlaca = numeroPlaca;
                objVehiculoE.Marca = marca;
                objVehiculoE.Modelo = modelo;
                objVehiculoE.Anio = int.Parse(anio.ToString());
                objVehiculoE.Color = color;
                objVehiculoE.IDCliente =int.Parse(p.ToString());
                GridView1.EditIndex = -1;
                objVehiculoN.EditarVehiculo(objVehiculoE);
               
                VaciarCombo();
                LlenarCombo();
               
                ddlBuscar.SelectedValue = "gg";
                if (ddlBuscar.Text == "Buscar...")
                {
                    ListarVehiculos();
                }
                else
                {
                    BuscarVehiculo();
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "updateAlert", "actualizacionExitosa();", true);
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error", $"notiError('Error durante la actualización: {ex.Message}');", true);
            }
            ActualizarComboCLiente();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Insertar")
                {
                    
                    string marca, modelo, color, numeroPlaca;
                    string anio, idCliente;

                    TextBox txtNumeroDePlaca = (TextBox)GridView1.FooterRow.FindControl("txtNumeroPlaca");
                    TextBox txtMarca = (TextBox)GridView1.FooterRow.FindControl("txtMarca");
                    TextBox txtModelo = (TextBox)GridView1.FooterRow.FindControl("txtModelo");
                    TextBox txtAnio = (TextBox)GridView1.FooterRow.FindControl("txtAnnio");
                    TextBox txtColor = (TextBox)GridView1.FooterRow.FindControl("txtColor");
                    DropDownList ddlClienteInsertar = (DropDownList)GridView1.FooterRow.FindControl("ddlBuscarCliente");
                   

                    marca = txtMarca.Text;
                    modelo = txtModelo.Text;
                    color = txtColor.Text;
                    numeroPlaca = txtNumeroDePlaca.Text;
                    anio = txtAnio.Text;
                    idCliente = ddlClienteInsertar.SelectedValue;

                    objVehiculoE.NumeroPlaca = numeroPlaca;
                    objVehiculoE.Marca = marca;
                    objVehiculoE.Modelo = modelo;
                    objVehiculoE.Anio = int.Parse(anio.ToString());
                    objVehiculoE.Color = color;
                    objVehiculoE.IDCliente = int.Parse(idCliente.ToString());
                    objVehiculoE.Estado = 1;
                    int resp=objVehiculoN.RegistarVehiculo(objVehiculoE);
                    VaciarCombo();
                    LlenarCombo();
                    LlenarComboCliente();
                    ddlBuscar.SelectedValue = "gg";
                    ListarVehiculos();
                    if (resp == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "insertAlert", "registroExitoso();", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Error", "notiError('Llenar todos los campos!');", true);
                    }
                    ActualizarComboCLiente();

                }
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error", $"notiError('Error durante la inserción: {ex.Message}');", true);
                //ScriptManager.RegisterStartupScript(this, GetType(), "Error", "notiError('Llenar todos los campos!');", true);
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            if (ddlBuscar.SelectedValue == "gg")
            {
                ListarVehiculos();
            }

            if (ddlBuscar.Text != "Buscar...")
            {
                BuscarVehiculo();
            }
           ActualizarComboCLiente();
        }

        protected void LlenarComboClienteEditar(DropDownList ddlCliente)
        {
            ddlCliente.DataSource = objClienteN.ListarClientes();
            ddlCliente.DataTextField = "Nombre";
            ddlCliente.DataValueField = "IDCliente";
            ddlCliente.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                DropDownList ddlClienteEditar = (DropDownList)e.Row.FindControl("ddlBuscarClienteE");
                LlenarComboClienteEditar(ddlClienteEditar);
            }
        }

       
        
    }
}