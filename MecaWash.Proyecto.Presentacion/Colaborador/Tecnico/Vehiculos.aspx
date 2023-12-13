<%@ Page Title="" Language="C#" MasterPageFile="~/master/colaborador.Master" AutoEventWireup="true" CodeBehind="Vehiculos.aspx.cs" Inherits="MecaWash.Proyecto.Presentacion.Colaborador.Tecnico.Vehiculos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <style>
        .encima{
            z-index: 1000; 
        }
    </style>
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
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" ShowFooter="True" CssClass="table" AllowPaging="True" DataKeyNames="IDVehiculo" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" EmptyDataText="No hay datos disponibles" PageSize="6" OnRowDataBound="GridView1_RowDataBound" >
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
                                    <div class="container">
                                        <div class="row">
                                            <div class="col-6">
                                                <asp:Label ID="Label2" CssClass="text-truncate" runat="server" Text='<%# Bind("NumeroPlaca") %>'></asp:Label>
                                            </div>
                                            <div class="col-6">
                                                <asp:Button ID="Button1" CssClass="btn btn-success w-100" runat="server" Text="S+" CommandName="AgregarServicio" CommandArgument='<%# Eval("IDVehiculo") + "," + Eval("IDCliente") %>' OnCommand="addServicio" data-bs-toggle="modal" data-bs-target="#addServicio"/>
                                            </div>
                                        </div>
                                    </div>
                                    
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
                                    <asp:TextBox ID="txtAnnioE" CssClass="form-control" runat="server" TextMode="Number" Text='<%# Bind("Anio") %>'></asp:TextBox>
                                </edititemtemplate>
                                <footertemplate>
                                    <asp:TextBox ID="txtAnnio" placeholder="Año" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                                </footertemplate>
                                <itemtemplate>
                                    <asp:Label ID="Label5" CssClass="text-truncate" runat="server" Text='<%# Bind("Anio") %>'></asp:Label>
                                </itemtemplate>
                               
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Color" ControlStyle-Width="140px">
                                <edititemtemplate>
                                    <asp:TextBox ID="txtColorE" CssClass="form-control"  runat="server" Text='<%# Bind("Color") %>'></asp:TextBox>
                                </edititemtemplate>
                                <footertemplate>
                                    <asp:TextBox ID="txtColor" placeholder="Color" CssClass="form-control"  runat="server"></asp:TextBox>
                                </footertemplate>
                                <itemtemplate>
                                    <asp:Label ID="Label7" CssClass="text-truncate" runat="server" Text='<%# Bind("Color") %>'></asp:Label>
                                </itemtemplate>
                                
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Nombres" ControlStyle-Width="140px">
                                <edititemtemplate>
                                    
                                    <asp:DropDownList ID="ddlBuscarClienteE" AutoPostBack="true" runat="server" CssClass="js-example-basic-single w-100" AppendDataBoundItems="true" >
                                        <asp:ListItem Value="gg">buscar...</asp:ListItem>

                                    </asp:DropDownList>
                                        <asp:TextBox ID="txtIdClienteE" runat="server" CssClass="form-control" Visible="false" Text='<%# Bind("IDCliente") %>'></asp:TextBox>
                                </edititemtemplate>
                                <footertemplate>
                                    <asp:DropDownList ID="ddlBuscarCliente" AutoPostBack="true" runat="server" CssClass="js-example-basic-single w-100" AppendDataBoundItems="true">
                                        <asp:ListItem Value="gg">buscar...</asp:ListItem>
                                    </asp:DropDownList>
                                    <%--<asp:TextBox runat="server" ID="txtIdCliente" CssClass="form-control" placeholder="id"></asp:TextBox>--%>
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


        <div class="modal fade" id="addServicio" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Añadir Servicio</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <div class="row mb-2">

                                    <div class="col-6">

                                        <label>Fecha</label>
                                        <asp:TextBox ID="txtFechaServicio" runat="server" Enabled="false" CssClass="form-control w-100"></asp:TextBox>

                                    </div>

                                    <div class="col-6">
                                        <label>Hora</label>
                                        <asp:TextBox ID="txtHoraServicio" runat="server" Enabled="false" CssClass="form-control w-100"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row mb-2">
                                    <div class="col-6">
                                        <label class="w-100 text-truncate">Cliente</label>
                                        <asp:TextBox ID="txtClienteServicio" runat="server" Enabled="false" CssClass="form-control w-100"></asp:TextBox>
                                    </div>
                                    <div class="col-6">

                                        <label class="w-100 text-truncate">Vehiculo</label>
                                        <asp:TextBox ID="txtVehiculoServicio" runat="server" Enabled="false" CssClass="form-control w-100"></asp:TextBox>


                                    </div>
                                </div>

                                <div class="mb-2">
                                    <label>Empleado</label>
                                    <asp:TextBox ID="txtEmpleadoServicio" runat="server" CssClass="form-control w-50"></asp:TextBox>
                                </div>


                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" GridLines="None" ShowFooter="True" CssClass="table" AllowPaging="True" DataKeyNames="IDCita" EmptyDataText="No hay servicios registrados" PageSize="6">
                                    <Columns>


                                        <asp:TemplateField HeaderText="ID" ControlStyle-Width="30px" Visible="false">

                                            <ItemTemplate>
                                                <asp:Label ID="Label71" CssClass="text-truncate" runat="server" Text='<%# Bind("IDCita") %>'></asp:Label>


                                            </ItemTemplate>

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Fecha" ControlStyle-Width="90px">

                                            <ItemTemplate>
                                                <asp:Label ID="Label72" CssClass="text-truncate" runat="server" Text='<%# Bind("Fecha") %>'></asp:Label>
                                            </ItemTemplate>

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Hora" ControlStyle-Width="75px">

                                            <ItemTemplate>
                                                <asp:Label ID="Label73" CssClass="text-truncate" runat="server" Text='<%# Bind("Hora") %>'></asp:Label>
                                            </ItemTemplate>

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Nombre" ControlStyle-Width="100px" Visible="false">

                                            <ItemTemplate>
                                                <asp:Label ID="Label74" CssClass="text-truncate" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                                            </ItemTemplate>

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Numero Placa" ControlStyle-Width="80px" Visible="false">

                                            <ItemTemplate>
                                                <asp:Label ID="Label75" CssClass="text-truncate" runat="server" Text='<%# Bind("NumeroPlaca") %>'></asp:Label>
                                            </ItemTemplate>

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Empleado" ControlStyle-Width="150px">

                                            <ItemTemplate>
                                                <div class="container">
                                                    <div class="row">
                                                        <div class="col-6">
                                                            <asp:Label ID="Label76" CssClass="text-truncate" runat="server" Text='<%# Bind("Empleado") %>'></asp:Label>
                                                        </div>
                                                        <div class="col-6">
                                                            <asp:Button ID="Button3" runat="server" CommandArgument='<%# Bind("IDCita") %>'  CommandName="sendId" OnCommand="sendIdNew" CssClass="btn btn-success w-100" Text="->" PostBackUrl='<%# $"carrito.aspx?idCita={Eval("IDCita")}" %>'/>
                                                        </div>
                                                    </div>
                                                </div>

                                            </ItemTemplate>

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Empleado" ControlStyle-Width="80px" Visible="false">

                                            <ItemTemplate>
                                                <asp:Label ID="Label76" CssClass="text-truncate" runat="server" Text='<%# Bind("IDVehiculo") %>'></asp:Label>
                                            </ItemTemplate>

                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Cerrar</button>
                        <asp:Button ID="Button2" runat="server" Text="Registrar" CommandName="Insertarbd" OnCommand="agregabd" CssClass="btn btn-info" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
