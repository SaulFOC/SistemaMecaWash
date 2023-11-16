<%@ Page Title="" Language="C#" MasterPageFile="~/master/colaborador.Master" AutoEventWireup="true" CodeBehind="servicios.aspx.cs" Inherits="MecaWash.Proyecto.Presentacion.Colaborador.Administrador.servicios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="contedor1 pt-3 pb-3">
    <h4>Servicios</h4>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="mt-3 mb-3">
                <div class="row">
                    <div class="col-4">
                        buscar servicio
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
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" ShowFooter="True" CssClass="table" AllowPaging="True" DataKeyNames="IDServicio" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" EmptyDataText="No hay datos disponibles" PageSize="6">
                    <AlternatingRowStyle />
                    <Columns>
                        <asp:TemplateField HeaderText="COD">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtIdServicioE" ReadOnly="true" CssClass="form-control" runat="server" Text='<%# Bind("IDServicio") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" CssClass="text-truncate" runat="server" Text='<%# Bind("IDServicio") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:LinkButton ID="LinkButton2" CommandName="Insertar" runat="server" CssClass="btn btn-secondary w-100"><i class='bx bxs-user-plus'></i></asp:LinkButton>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Tipo de Servicio" ControlStyle-Width="140px">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtTipoDeServicioE" CssClass="form-control" runat="server" Text='<%# Bind("TipoServicio") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtTipoDeServicio" CssClass="form-control" placeholder="Tipo Servicio" runat="server"></asp:TextBox>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" CssClass="text-truncate" runat="server" Text='<%# Bind("TipoServicio") %>'></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="110px" />
                        </asp:TemplateField>



                        <asp:TemplateField HeaderText="Descripcion" ControlStyle-Width="140px">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDescripcionServicioE" CssClass="form-control" runat="server" Text='<%# Bind("DescripcionServicio") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtDescripcionServicio"  CssClass="form-control" placeholder="Descripcion" runat="server"></asp:TextBox>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" CssClass="text-truncate" runat="server" Text='<%# Bind("DescripcionServicio") %>'></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="110px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Precio" ControlStyle-Width="110px">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPrecioE" CssClass="form-control" runat="server" Text='<%# Bind("PrecioServicio") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtPrecio" placeholder="Precio" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label5" CssClass="text-truncate" runat="server" Text='<%# Bind("PrecioServicio") %>'></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="140px" />
                        </asp:TemplateField>

                       

                        <asp:CommandField />

                        <asp:CommandField ShowEditButton="true" CancelImageUrl="../../assets/img/cancelar.svg" UpdateImageUrl="../../assets/img/guardar.svg" EditImageUrl="../../assets/img/editar.svg" ButtonType="Image">

                            <ControlStyle CssClass="btn btn-warning" />
                        </asp:CommandField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton CommandArgument='<%# Eval("IDServicio") %>' CssClass="btn btn-danger" OnClientClick="return confirmaEliminar(this);" OnClick="Eliminar" runat="server"><i class='bx bxs-trash'></i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
</asp:Content>
