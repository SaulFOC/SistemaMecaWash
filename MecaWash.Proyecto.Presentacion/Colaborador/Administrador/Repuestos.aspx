<%@ Page Title="" Language="C#" MasterPageFile="~/master/colaborador.Master" AutoEventWireup="true" CodeBehind="Repuestos.aspx.cs" Inherits="MecaWash.Proyecto.Presentacion.Colaborador.Administrador.Repuestos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="contedor1 pt-3 pb-3">


        <h4>Repuestos</h4>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="mt-3 mb-3">
                    <div class="row">
                        <div class="col-4">
                            Buscar Repuesto
                        </div>
                        <div class="col-5">
                            <asp:DropDownList ID="ddlBuscar" AutoPostBack="true" runat="server" CssClass="js-example-basic-single w-100" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlBuscar_SelectedIndexChanged">
                                <asp:ListItem Value="gg">Buscar...</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-3">
                            <asp:Button ID="btnMostrarE" CssClass="btn btn-secondary" runat="server" Text="Listar Todo" OnClick="btnMostrarE_Click" />
                        </div>
                    </div>
                </div>


                <div class="table-responsive">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" ShowFooter="True" CssClass="table" AllowPaging="True" DataKeyNames="IDProducto" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" EmptyDataText="No hay datos disponibles" PageSize="6">
                        <AlternatingRowStyle />
                        <Columns>
                            <asp:TemplateField HeaderText="COD">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtIdProductoE" ReadOnly="true" CssClass="form-control" runat="server" Text='<%# Bind("IDProducto") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" CssClass="text-truncate" runat="server" Text='<%# Bind("IDProducto") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="LinkButton2" CommandName="Insertar" runat="server" CssClass="btn btn-secondary w-100"><i class='bx bxs-user-plus'></i></asp:LinkButton>
                                </FooterTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Nombre" ControlStyle-Width="250px">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtNombreE" CssClass="form-control"  runat="server" Text='<%# Bind("NombreProducto") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtNombre" CssClass="form-control"  placeholder="Nombre Producto" runat="server"></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" CssClass="text-truncate" runat="server" Text='<%# Bind("NombreProducto") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>



                            <asp:TemplateField HeaderText="Descripcion" ControlStyle-Width="400px">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDescripcionE" CssClass="form-control" runat="server" Text='<%# Bind("Descripcion") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtDescripcion" TextMode="SingleLine" CssClass="form-control" runat="server" placeholder="Descripcion"></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" CssClass="text-truncate" runat="server" Text='<%# Bind("Descripcion") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Cantidad" ControlStyle-Width="80px">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCantidadE" CssClass="form-control" runat="server" Text='<%# Bind("CantidadInventario") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtCantidad" placeholder="Cantidad" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <div class="container">
                                        <div class="row">
                                            <div class="col-6">
                                                <asp:Label ID="Label5" CssClass="text-truncate  w-100" runat="server" Text='<%# Bind("CantidadInventario") %>'></asp:Label>
                                            </div>
                                            <div class="col-6">
                                                <asp:Button ID="Button1" CssClass="btn btn-success w-100" runat="server" Text="+" CommandName="AgregarInventario" CommandArgument='<%# Eval("IDProducto") %>' OnCommand="addInventario" data-bs-toggle="modal" data-bs-target="#addInventarioModal"/>
                                            </div>
                                        </div>
                                    </div>

                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Precio" ControlStyle-Width="100px">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPrecioE" CssClass="form-control"  runat="server" Text='<%# Bind("PrecioPorUnidad") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtPrecio" placeholder="Precio" CssClass="form-control"  runat="server" TextMode="Number"></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label7" CssClass="text-truncate" runat="server" Text='<%# Bind("PrecioPorUnidad") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                          

                            <asp:CommandField />

                            <asp:CommandField ShowEditButton="true" CancelImageUrl="../../assets/img/cancelar.svg" UpdateImageUrl="../../assets/img/guardar.svg" EditImageUrl="../../assets/img/editar.svg" ButtonType="Image">

                                <ControlStyle CssClass="btn btn-warning" />
                            </asp:CommandField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton CommandArgument='<%# Eval("IDProducto") %>' CssClass="btn btn-danger" OnClientClick="return confirmaEliminar(this);" OnClick="Eliminar" runat="server"><i class='bx bxs-trash'></i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                           

                        </Columns>
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <div class="modal fade" id="addInventarioModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Añadir Stock</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-6">
                                        <label>ID</label>
                                        <asp:TextBox ID="txtId" CssClass="form-control" runat="server" Visible="false"></asp:TextBox>
                                    </div>
                                    <div class="col-6">
                                        <label>Añadir Cantidad</label>
                                        <asp:TextBox ID="txtCantidadInventario" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Cerrar</button>
                        <asp:Button ID="Button2" runat="server" Text="Button" CommandName="Insertarbd" OnCommand="agregabd" CssClass="btn btn-info"/>
                    </div>
                </div>
            </div>
        </div>


    </div>
</asp:Content>
