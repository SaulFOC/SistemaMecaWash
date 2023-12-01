<%@ Page Title="" Language="C#" MasterPageFile="~/master/colaborador.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="MecaWash.Proyecto.Presentacion.Colaborador.Tecnico.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .btnBuscar{
            position:absolute;
            right: 0.8rem;
            top:50%;
            transform: translateY(-50%);
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="contedor1 pt-3 pb-3">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <ContentTemplate>
    <div class="mt-3 mb-3">
       
    <div class="row">
        <div class="col-4">
            Buscar Cliente
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
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" ShowFooter="True" CssClass="table" AllowPaging="True" DataKeyNames="IDCliente" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" EmptyDataText="No hay datos disponibles" PageSize="6">
            <AlternatingRowStyle />
            <Columns>
                <asp:TemplateField HeaderText="COD">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtIdClienteE" ReadOnly="true" CssClass="form-control" runat="server" Text='<%# Bind("IDCliente") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" CssClass="text-truncate" runat="server" Text='<%# Bind("IDCliente") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%--<asp:Button ID="Button1" CommandName="Insertar" CssClass="btn btn-secondary w-100" runat="server" Text="Insertar" />--%>
                        <asp:LinkButton ID="LinkButton2" CommandName="Insertar" runat="server" CssClass="btn btn-secondary w-100"><i class='bx bxs-user-plus'></i></asp:LinkButton>
                    </FooterTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="DNI" ControlStyle-Width="110px">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtDniE" CssClass="form-control" ReadOnly="true" MaxLength="8" runat="server" Text='<%# Bind("DNI") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <div class="position-relative">
                             <asp:TextBox ID="txtDni" CssClass="form-control" MaxLength="8" placeholder="DNI" runat="server"></asp:TextBox>
                             <asp:LinkButton CssClass="btnBuscar text-dark" CommandName="BuscarNombre" ID="lnbBuscarDNI" OnClientClick="ocultarLinkButton()" runat="server"><i class='bx bx-search' ></i></asp:LinkButton>
                        </div>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" CssClass="text-truncate" runat="server" Text='<%# Bind("DNI") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Nombre" ControlStyle-Width="240px">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtNombreE" ReadOnly="true" CssClass="form-control" runat="server" Text='<%# Bind("Nombre") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtNombre" ReadOnly="true" placeholder="Nombre" TextMode="SingleLine" CssClass="form-control" runat="server"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" CssClass="text-truncate" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Clave" ControlStyle-Width="110px">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtClaveE"  CssClass="form-control" runat="server" Text='<%# Bind("clave") %>' ></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtClave" placeholder="Clave" TextMode="SingleLine" CssClass="form-control" runat="server"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" CssClass="text-truncate" runat="server" Text='<%# Bind("clave") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>



                <asp:TemplateField HeaderText="Direccion" ControlStyle-Width="140px">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtDireccionE" CssClass="form-control" runat="server" Text='<%# Bind("Direccion") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtDireccion" placeholder="Direccion" CssClass="form-control" runat="server"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" CssClass="text-truncate" runat="server" Text='<%# Bind("Direccion") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Celular" ControlStyle-Width="140px">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtTelefonoE" CssClass="form-control" MaxLength="9" runat="server" Text='<%# Bind("Telefono") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtTelefono" placeholder="Celular" CssClass="form-control" MaxLength="9" runat="server"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label7" CssClass="text-truncate" runat="server" Text='<%# Bind("Telefono") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Correo" ControlStyle-Width="250px">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtCorreoE" CssClass="form-control" runat="server" Text='<%# Bind("CorreoElectronico") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtCorreo" TextMode="Email" placeholder="correo@gmail.com" CssClass="form-control" runat="server"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label8" CssClass="text-truncate" runat="server" Text='<%# Bind("CorreoElectronico") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>



                <asp:CommandField />

                <asp:CommandField ShowEditButton="true" CancelImageUrl="../../assets/img/cancelar.svg" UpdateImageUrl="../../assets/img/guardar.svg" EditImageUrl="../../assets/img/editar.svg" ButtonType="Image">

                    <ControlStyle CssClass="btn btn-warning" />
                </asp:CommandField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton CommandArgument='<%# Eval("IDCliente") %>' CssClass="btn btn-danger" OnClientClick="return confirmaEliminar(this);" OnClick="Eliminar" runat="server"><i class='bx bxs-trash'></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
    </asp:GridView>
        </ContentTemplate>
        </asp:UpdatePanel>
</div>

</asp:Content>
