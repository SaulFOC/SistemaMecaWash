<%@ Page Title="" Language="C#" MasterPageFile="~/master/colaborador.Master" AutoEventWireup="true" CodeBehind="empleados.aspx.cs" Inherits="MecaWash.Proyecto.Presentacion.Colaborador.Administrador.empleados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contedor1 pt-3 pb-3">
        <h4>Empleado</h4>
        <div class="table-responsive">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" ShowFooter="True" CssClass="table" AllowPaging="True" DataKeyNames="IDEmpleado" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting">
                <AlternatingRowStyle />
                <Columns>
                    <asp:TemplateField HeaderText="COD">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtIdEmpleadoE" CssClass="form-control" runat="server" Text='<%# Bind("IDEmpleado") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" CssClass="text-truncate" runat="server" Text='<%# Bind("IDEmpleado") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:LinkButton ID="LinkButton2" CommandName="Insertar" runat="server" CssClass="btn btn-primary w-100"><i class='bx bxs-user-plus'></i></asp:LinkButton>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="DNI" ControlStyle-Width="110px">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtDniE" CssClass="form-control" runat="server" Text='<%# Bind("DNI") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtDni" CssClass="form-control" MaxLength="8" placeholder="DNI" runat="server"></asp:TextBox>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" CssClass="text-truncate" runat="server" Text='<%# Bind("DNI") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>



                    <asp:TemplateField HeaderText="Clave" ControlStyle-Width="110px">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtClaveE" CssClass="form-control" runat="server" Text='<%# Bind("Contraseña") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtClave" TextMode="Password" CssClass="form-control" placeholder="********" runat="server"></asp:TextBox>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" CssClass="text-truncate" runat="server" Text='<%# Bind("Contraseña") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Nombre" ControlStyle-Width="140px">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNombreE" CssClass="form-control" runat="server" Text='<%# Bind("Nombre") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtNombre" placeholder="Nombre" CssClass="form-control" runat="server"></asp:TextBox>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" CssClass="text-truncate" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Celular" ControlStyle-Width="140px">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtTelefonoE" CssClass="form-control" runat="server" Text='<%# Bind("Telefono") %>'></asp:TextBox>
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

                    <asp:TemplateField HeaderText="Puesto" ControlStyle-Width="160px">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPuestoE" Text='<%# Bind("Puesto") %>' CssClass="form-control" runat="server" Visible="False"></asp:TextBox>
                            <asp:DropDownList ID="ddlPuestoE" CssClass="form-select w-100" runat="server">
                                <asp:ListItem Selected="True">Seleccionar</asp:ListItem>
                                <asp:ListItem>Administrador</asp:ListItem>
                                <asp:ListItem>Tecnico</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:DropDownList ID="ddlPuesto" CssClass="form-select w-100" runat="server">
                                <asp:ListItem>Administrador</asp:ListItem>
                                <asp:ListItem>Tecnico</asp:ListItem>
                            </asp:DropDownList>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label9" CssClass="text-truncate" runat="server" Text='<%# Bind("Puesto") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>


                    <asp:CommandField />

                    <asp:CommandField ShowEditButton="True" CancelImageUrl="../../assets/img/cancelar.svg" UpdateImageUrl="../../assets/img/guardar.svg" EditImageUrl="../../assets/img/editar.svg" ButtonType="Image">

                        <ControlStyle CssClass="btn btn-warning" />
                    </asp:CommandField>
                    <asp:CommandField ButtonType="Image" CancelImageUrl="../../assets/img/cancelar.svg" DeleteImageUrl="../../assets/img/eliminar.svg" ShowDeleteButton="True">
                        <ControlStyle CssClass="btn btn-danger" />
                    </asp:CommandField>

                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
