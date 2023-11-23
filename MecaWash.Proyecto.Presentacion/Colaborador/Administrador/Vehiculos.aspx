<%@ Page Title="" Language="C#" MasterPageFile="~/master/colaborador.Master" AutoEventWireup="true" CodeBehind="Vehiculos.aspx.cs" Inherits="MecaWash.Proyecto.Presentacion.Colaborador.Administrador.Vehiculos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="contedor1 pt-3 pb-3">
        <h4>Vehiculos</h4>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <contenttemplate>
                <div class="mt-3 mb-3">
                    <div class="row">
                        <div class="col-4">
                            buscar Vehiculo
                        </div>
                        <div class="col-5">
                            <asp:dropdownlist id="ddlBuscar" autopostback="true" runat="server" cssclass="js-example-basic-single w-100" appenddatabounditems="true" onselectedindexchanged="ddlBuscar_SelectedIndexChanged">
                                <asp:listitem value="gg">buscar...</asp:listitem>
                            </asp:dropdownlist>
                        </div>
                        <div class="col-3">
                            <asp:button id="btnmostrare" cssclass="btn btn-secondary" runat="server" text="listar todo" onclick="btnMostrarE_Click" />
                        </div>
                    </div>
                </div>
                <div class="table-responsive">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" ShowFooter="True" CssClass="table" AllowPaging="True" DataKeyNames="IDVehiculo" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" EmptyDataText="No hay datos disponibles" PageSize="6" >
                        <alternatingrowstyle />
                        <columns>
                            <asp:TemplateField HeaderText="COD">
                                <edititemtemplate>
                                    <asp:TextBox ID="txtIdVehiculoE" ReadOnly="true" CssClass="form-control" runat="server" Text='<%# Bind("IDVehiculo") %>'></asp:TextBox>
                                </edititemtemplate>
                                <itemtemplate>
                                    <asp:Label ID="Label1" CssClass="text-truncate" runat="server" Text='<%# Bind("IDVehiculo") %>'></asp:Label>
                                </itemtemplate>
                                <footertemplate>
                                    <%--<asp:Button ID="Button1" CommandName="Insertar" CssClass="btn btn-secondary w-100" runat="server" Text="Insertar" />--%>
                                    <asp:LinkButton ID="LinkButton2" CommandName="Insertar" runat="server" CssClass="btn btn-secondary w-100"><i class='bx bxs-user-plus'></i></asp:LinkButton>
                                </footertemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Numero de Placa" ControlStyle-Width="110px">
                                <edititemtemplate>
                                    <asp:TextBox ID="txtNumeroPlacaE" CssClass="form-control" MaxLength="8" runat="server" Text='<%# Bind("NumeroPlaca") %>'></asp:TextBox>
                                </edititemtemplate>
                                <footertemplate>
                                    <asp:TextBox ID="txtNumeroPlaca" CssClass="form-control" MaxLength="7" placeholder="Numero de Placa" runat="server"></asp:TextBox>
                                </footertemplate>
                                <itemtemplate>
                                    <asp:Label ID="Label2" CssClass="text-truncate" runat="server" Text='<%# Bind("NumeroPlaca") %>'></asp:Label>
                                </itemtemplate>
                               
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Marca" ControlStyle-Width="110px">
                                <edititemtemplate>
                                    <asp:TextBox ID="txtMarcaE" CssClass="form-control" runat="server" Text='<%# Bind("Marca") %>'></asp:TextBox>
                                </edititemtemplate>
                                <footertemplate>
                                    <asp:TextBox ID="txtMarca" placeholder="Marca" TextMode="SingleLine" CssClass="form-control" runat="server"></asp:TextBox>
                                </footertemplate>
                                <itemtemplate>
                                    <asp:Label ID="Label3" CssClass="text-truncate" runat="server" Text='<%# Bind("Marca") %>'></asp:Label>
                                </itemtemplate>
                                
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Modelo" ControlStyle-Width="110px">
                                <edititemtemplate>
                                    <asp:TextBox ID="txtModeloE" CssClass="form-control" runat="server" Text='<%# Bind("Modelo") %>' ></asp:TextBox>
                                </edititemtemplate>
                                <footertemplate>
                                    <asp:TextBox ID="txtModelo" placeholder="Modelo" TextMode="SingleLine" CssClass="form-control" runat="server"></asp:TextBox>
                                </footertemplate>
                                <itemtemplate>
                                    <asp:Label ID="Label4" CssClass="text-truncate" runat="server" Text='<%# Bind("Modelo") %>'></asp:Label>
                                </itemtemplate>
                                
                            </asp:TemplateField>



                            <asp:TemplateField HeaderText="Año" ControlStyle-Width="140px">
                                <edititemtemplate>
                                    <asp:TextBox ID="txtAnnioE" CssClass="form-control" runat="server" Text='<%# Bind("Anio") %>'></asp:TextBox>
                                </edititemtemplate>
                                <footertemplate>
                                    <asp:TextBox ID="txtAnnio" placeholder="Año" CssClass="form-control" runat="server"></asp:TextBox>
                                </footertemplate>
                                <itemtemplate>
                                    <asp:Label ID="Label5" CssClass="text-truncate" runat="server" Text='<%# Bind("Anio") %>'></asp:Label>
                                </itemtemplate>
                               
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Color" ControlStyle-Width="140px">
                                <edititemtemplate>
                                    <asp:TextBox ID="txtColorE" CssClass="form-control" MaxLength="9" runat="server" Text='<%# Bind("Color") %>'></asp:TextBox>
                                </edititemtemplate>
                                <footertemplate>
                                    <asp:TextBox ID="txtColor" placeholder="Color" CssClass="form-control" MaxLength="9" runat="server"></asp:TextBox>
                                </footertemplate>
                                <itemtemplate>
                                    <asp:Label ID="Label7" CssClass="text-truncate" runat="server" Text='<%# Bind("Color") %>'></asp:Label>
                                </itemtemplate>
                                
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Cliente" ControlStyle-Width="140px">
                                <edititemtemplate>
                                    <asp:TextBox ID="txtNombreClienteE" Text='<%# Bind("Nombre") %>' CssClass="form-control" runat="server" Visible="False"></asp:TextBox>
                                    <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
                                    
                                    <%-- <asp:DropDownList ID="ddlBuscarCLienteE" AutoPostBack="true" runat="server" CssClass="js-example-basic-single w-100" AppendDataBoundItems="true">
                                        <asp:ListItem Value="">buscar...</asp:ListItem>
                                    </asp:DropDownList>--%>
                                </edititemtemplate>
                                <footertemplate>
                                    <asp:DropDownList ID="DropDownList1" CssClass="js-example-basic-single w-100" runat="server">
                                    
                                    </asp:DropDownList>
                                    <%--<asp:DropDownList ID="ddlBuscarCLiente" AutoPostBack="true" runat="server" CssClass="js-example-basic-single w-100"  AppendDataBoundItems="true">
                                        <asp:ListItem Value="">buscar...</asp:ListItem>
                                    </asp:DropDownList>--%>
                                </footertemplate>
                                <itemtemplate>
                                    <asp:Label ID="Label9" CssClass="text-truncate" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                                </itemtemplate>
                                
                            </asp:TemplateField>


                            <asp:CommandField />

                            <asp:CommandField ShowEditButton="true" CancelImageUrl="../../assets/img/cancelar.svg" UpdateImageUrl="../../assets/img/guardar.svg" EditImageUrl="../../assets/img/editar.svg" ButtonType="Image">

                                <controlstyle cssclass="btn btn-warning" />
                            </asp:CommandField>
                            <asp:TemplateField>
                                <itemtemplate>
                                    <asp:LinkButton CommandArgument='<%# Eval("IDVehiculo") %>' CssClass="btn btn-danger" OnClientClick="return confirmaEliminar(this);" OnClick="Eliminar" runat="server"><i class='bx bxs-trash'></i></asp:LinkButton>
                                </itemtemplate>
                            </asp:TemplateField>


                        </columns>
                    </asp:GridView>
                </div>

            </contenttemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
