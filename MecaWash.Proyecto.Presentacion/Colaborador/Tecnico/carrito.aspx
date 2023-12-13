    <%@ Page Title="" Language="C#" MasterPageFile="~/master/colaborador.Master" AutoEventWireup="true" CodeBehind="carrito.aspx.cs" Inherits="MecaWash.Proyecto.Presentacion.Colaborador.Tecnico.carrito" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="contedor1 pt-3 pb-3">
            <h4>Agregar Servicios</h4>
             <asp:TextBox ID="txtIdCita" runat="server" Visible="false"></asp:TextBox>
            <div class="row">
                <div class="col-3 me-lg-5">
                    <label class="form-label">Servicio</label>
                    <asp:DropDownList ID="ddlServicios"  runat="server" CssClass="js-example-basic-single w-100" OnSelectedIndexChanged="ddlServicios_SelectedIndexChanged1"  AutoPostBack="true"></asp:DropDownList>
                </div>
                <div class="col-2 me-lg-5">
                    <label class="form-label">Total</label>
                    <asp:TextBox ID="txtTotal" runat="server" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-2 me-lg-5">
                    <label class="form-label">Descuento</label>
                    <asp:TextBox ID="txtDescuento" runat="server" Text="0"></asp:TextBox>
                </div>
                <div class="col-3 mt-4">
                
                    <asp:Button ID="Button1" runat="server" Text="Agregar" CssClass="btn btn-primary" CommandName="Insertar" OnClick="Button1_Click"/>
                    <asp:Button ID="Button2" runat="server" Text="Volver " CssClass="btn btn-warning" OnClick="Button2_Click"/>
                    
                </div>
            
            </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="table-responsive">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" ShowFooter="True" CssClass="table" AllowPaging="True" DataKeyNames="IDCita, IDServicio" EmptyDataText="No hay datos servicios registrados" PageSize="6" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting">
                        <AlternatingRowStyle />
                        <Columns>
                            <asp:TemplateField HeaderText="COD" Visible="false">

                                <ItemTemplate>
                                    <asp:Label ID="Label1" CssClass="text-truncate" runat="server" Text='<%# Bind("IDCita") %>'></asp:Label>
                                </ItemTemplate>

                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Servicio" ControlStyle-Width="180px" Visible="false">

                                <ItemTemplate>
                                    <asp:Label ID="Label25" CssClass="text-truncate" runat="server" Text='<%# Bind("IDServicio") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Servicio" ControlStyle-Width="280px">

                                <ItemTemplate>
                                    <asp:Label ID="Label2" CssClass="text-truncate" runat="server" Text='<%# Bind("TipoServicio") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Total" ControlStyle-Width="130px">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" CssClass="text-truncate" runat="server" Text='<%# Bind("Total") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Descuento" ControlStyle-Width="130px">

                                <ItemTemplate>
                                    <asp:Label ID="Label5" CssClass="text-truncate" runat="server" Text='<%# Bind("Descuento") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="SubTotal" ControlStyle-Width="130px">

                                <ItemTemplate>
                                    <asp:Label ID="Label7" CssClass="text-truncate" runat="server" Text='<%# Bind("subtotal") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotal" runat="server" Text="Total: "></asp:Label>
                                    <asp:Label ID="lblSumaSubtotales" runat="server"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>




                            <asp:CommandField />

                       
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton CommandArgument='<%# Eval("IDCita") + "," + Eval("IDServicio") %>' CssClass="btn btn-danger" OnClientClick="return confirmaEliminar(this);" OnClick="Eliminar" runat="server"><i class='bx bxs-trash'></i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    

                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
       

</asp:Content>
