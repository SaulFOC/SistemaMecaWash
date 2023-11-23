<%@ Page Title="" Language="C#" MasterPageFile="~/master/cliente.Master" AutoEventWireup="true" CodeBehind="carrito.aspx.cs" Inherits="MecaWash.Proyecto.Presentacion.Cliente.carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container pt-3 pb-3">
        <h4>Carrito de Servicios</h4>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>

                <div class="row">
                    <asp:Repeater ID="Repeater1"  runat="server">
                        <ItemTemplate>

                            <div class="col-sm-12 col-md-4 col-lg-4 col-xl-4 mb-3">
                                <div class="container bg-white redondear">
                                    <div class="row">
                                        <div class="col-4 p-2">
                                            <asp:Image ID="Image1" ImageUrl='<%#"../"+Eval("Imagen")%>' CssClass="w-100" runat="server" />
                                        </div>
                                        <div class="col-8 p-2 align-items-center text-dark">
                                            <label class="w-100"><%#Eval("Nombre") %></label>
                                            <div class="row mt-2">
                                                <div class="col-8">
                                                    <span>
                                                        <i class='bx bxs-like'></i>
                                                        <label for="" class="fs-8">100</label>
                                                    </span>
                                                    <span>
                                                        <i class="bi bi-share-fill"></i>
                                                        <label for="" class="fs-8">100</label>
                                                    </span>
                                                </div>
                                                <div class="col-4 text-end">
                                                    <asp:Button ID="Button1" CommandName="Quitar" OnCommand="QuitarCarrito" CommandArgument='<%#Eval("Ids")+"|"+Eval("Idc") %>' CssClass="btn btn-dark text-light" runat="server" Text="-" />
                                                </div>
                                            </div>
                                            <label for="" class="text-precio fw-bold">S/ <%#Eval("Precio") %></label>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Label ID="lblNoti" runat="server" CssClass="form-label"></asp:Label>
                </div>
                <div class="row">
                    <div class="col-sm-6 col-md-6 col-lg-3 col-xl-3 mt-3">
                        <label class="form-label">Fecha de la cita</label>
                        <asp:TextBox ID="txtFechaC" TextMode="Date" CssClass="form-control w-100" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-6 col-md-6 col-lg-3 col-xl-3 mt-3">
                        <label class="form-label">Hora de la cita</label>
                        <asp:TextBox ID="txtHoraC" TextMode="Time" CssClass="form-control w-100" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-6 col-md-6 col-lg-3 col-xl-3 mt-3">
                        <label class="form-label">Selecciona vehiculo</label>
                        <asp:DropDownList ID="ddlCarro" CssClass="form-select w-100" runat="server">
                            <asp:ListItem Value="gg">Seleccionar...</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-6 col-md-6 col-lg-3 col-xl-3 mt-3">
                        <label class="form-label">Enviar</label>
                        <asp:Button ID="btnRegistrar" CommandName="Registrar" OnCommand="RegistrarCita" CssClass="btn btn-secondary w-100" runat="server" Text="Registrar" />
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
