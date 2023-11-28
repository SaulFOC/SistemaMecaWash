<%@ Page Title="" Language="C#" MasterPageFile="~/master/colaborador.Master" AutoEventWireup="true" CodeBehind="carrito.aspx.cs" Inherits="MecaWash.Proyecto.Presentacion.Colaborador.Administrador.carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="contedor1 pt-3 pb-3">
        <h4>Empleado</h4>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="table-responsive">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" ShowFooter="True" CssClass="table" AllowPaging="True" DataKeyNames="IDCita" EmptyDataText="No hay datos disponibles" PageSize="6">
                        <AlternatingRowStyle />
                        <Columns>
                            <asp:TemplateField HeaderText="COD">

                                <ItemTemplate>
                                    <asp:Label ID="Label1" CssClass="text-truncate" runat="server" Text='<%# Bind("IDCita") %>'></asp:Label>
                                </ItemTemplate>

                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Servicio" ControlStyle-Width="110px">

                                <ItemTemplate>
                                    <asp:Label ID="Label2" CssClass="text-truncate" runat="server" Text='<%# Bind("TipoServicio") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total" ControlStyle-Width="110px">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" CssClass="text-truncate" runat="server" Text='<%# Bind("Total") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Descuento" ControlStyle-Width="140px">

                                <ItemTemplate>
                                    <asp:Label ID="Label5" CssClass="text-truncate" runat="server" Text='<%# Bind("Descuento") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="SubTotal" ControlStyle-Width="140px">

                                <ItemTemplate>
                                    <asp:Label ID="Label5" CssClass="text-truncate" runat="server" Text='<%# Bind("subtotal") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>




                            <%--      <asp:CommandField />

            <asp:CommandField ShowEditButton="true" CancelImageUrl="../../assets/img/cancelar.svg" UpdateImageUrl="../../assets/img/guardar.svg" EditImageUrl="../../assets/img/editar.svg" ButtonType="Image">

                <ControlStyle CssClass="btn btn-warning" />
            </asp:CommandField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton CommandArgument='<%# Eval("IDEmpleado") %>' CssClass="btn btn-danger" OnClientClick="return confirmaEliminar(this);" OnClick="Eliminar" runat="server"><i class='bx bxs-trash'></i></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>--%>
                        </Columns>
                    </asp:GridView>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>
