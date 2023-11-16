<%@ Page Title="" Language="C#" MasterPageFile="~/master/colaborador.Master" AutoEventWireup="true" CodeBehind="empleados.aspx.cs" Inherits="MecaWash.Proyecto.Presentacion.Colaborador.Administrador.empleados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
    <div class="contedor1 pt-3 pb-3">
        <h4>Empleado</h4>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="mt-3 mb-3">
                    <div class="row">
                        <div class="col-4">
                            Buscar Empleado
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
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" ShowFooter="True" CssClass="table" AllowPaging="True" DataKeyNames="IDEmpleado" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" EmptyDataText="No hay datos disponibles" PageSize="6">
                        <AlternatingRowStyle />
                        <Columns>
                            <asp:TemplateField HeaderText="COD">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtIdEmpleadoE" ReadOnly="true" CssClass="form-control" runat="server" Text='<%# Bind("IDEmpleado") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" CssClass="text-truncate" runat="server" Text='<%# Bind("IDEmpleado") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="LinkButton2" CommandName="Insertar" runat="server" CssClass="btn btn-secondary w-100"><i class='bx bxs-user-plus'></i></asp:LinkButton>
                                </FooterTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="DNI" ControlStyle-Width="110px">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDniE" CssClass="form-control" MaxLength="8" runat="server" Text='<%# Bind("DNI") %>'></asp:TextBox>
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
                                    <asp:TextBox ID="txtClaveE" CssClass="form-control" runat="server" Text='<%# Bind("decifrado") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtClave" TextMode="Password" CssClass="form-control" placeholder="********" runat="server"></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" CssClass="text-truncate" runat="server" Text='********'></asp:Label>
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

                            <asp:CommandField ShowEditButton="true" CancelImageUrl="../../assets/img/cancelar.svg" UpdateImageUrl="../../assets/img/guardar.svg" EditImageUrl="../../assets/img/editar.svg" ButtonType="Image">

                                <ControlStyle CssClass="btn btn-warning" />
                            </asp:CommandField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton CommandArgument='<%# Eval("IDEmpleado") %>' CssClass="btn btn-danger" OnClientClick="return confirmaEliminar(this);" OnClick="Eliminar" runat="server"><i class='bx bxs-trash'></i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
