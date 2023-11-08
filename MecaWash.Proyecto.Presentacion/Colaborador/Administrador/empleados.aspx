<%@ Page Title="" Language="C#" MasterPageFile="~/master/colaborador.Master" AutoEventWireup="true" CodeBehind="empleados.aspx.cs" Inherits="MecaWash.Proyecto.Presentacion.Colaborador.Administrador.empleados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container w-100 pt-3 pb-3">
        <h4>Empleado</h4>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" ShowFooter="True" CssClass="table">
                <AlternatingRowStyle />
                <Columns>
                    <asp:TemplateField HeaderText="COD">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" Text='<%# Bind("IDEmpleado") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("IDEmpleado") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="DNI">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" Text='<%# Bind("DNI") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtDni" CssClass="form-control" MaxLength="8" placeholder="DNI" runat="server"></asp:TextBox>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("DNI") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Usuario">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server" Text='<%# Bind("Usuario") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtUsuario" CssClass="form-control" placeholder="Usuario" runat="server"></asp:TextBox>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Usuario") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Contraseña">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server" Text='<%# Bind("Contraseña") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtContraseña" CssClass="form-control" placeholder="********" runat="server"></asp:TextBox>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Contraseña") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Nombre">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox5" CssClass="form-control" runat="server" Text='<%# Bind("Nombre") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtNombre" placeholder="Nombre" CssClass="form-control" runat="server"></asp:TextBox>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Apellido">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox6" CssClass="form-control" runat="server" Text='<%# Bind("Apellido") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtApellido" placeholder="Apellido" CssClass="form-control" runat="server"></asp:TextBox>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("Apellido") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Celular">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox7" CssClass="form-control" runat="server" Text='<%# Bind("Telefono") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtTelefono" placeholder="Celular" CssClass="form-control" runat="server"></asp:TextBox>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("Telefono") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Correo">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox8" CssClass="form-control" runat="server" Text='<%# Bind("CorreoElectronico") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtCorreo" TextMode="Email" placeholder="correo@gmail.com" CssClass="form-control" runat="server"></asp:TextBox>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("CorreoElectronico") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Puesto">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox9" CssClass="form-control" runat="server" Text='<%# Bind("Puesto") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>  
                            <asp:DropDownList ID="ddlPuesto" CssClass="form-select w-100" runat="server">
                                <asp:ListItem>Administrador</asp:ListItem>
                                <asp:ListItem>Tecnico</asp:ListItem>
                            </asp:DropDownList>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label9" runat="server" Text='<%# Bind("Puesto") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Opciones">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" CssClass="btn btn-sm btn-warning"><i class='bx bxs-edit-alt'></i></asp:LinkButton>
                            <asp:LinkButton runat="server" CssClass="btn btn-sm btn-danger" OnClientClick="return confirm('¿Desea eliminar?)"><i class='bx bxs-trash-alt'></i></asp:LinkButton>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-primary w-100"><i class='bx bxs-user-plus'></i></asp:LinkButton>
                        </FooterTemplate>
                    </asp:TemplateField>

                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
    </div>
</asp:Content>
