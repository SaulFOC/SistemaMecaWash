<%@ Page Title="" Language="C#" MasterPageFile="~/master/cliente.Master" AutoEventWireup="true" CodeBehind="servicios.aspx.cs" Inherits="MecaWash.Proyecto.Presentacion.Cliente.servicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container pt-3 pb-3">
        <h4>Servicios</h4>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>

                <div class="row">
                    <asp:Repeater ID="Repeater1"  runat="server">
                        <ItemTemplate>

                            <div class="col-sm-12 col-md-4 col-lg-4 col-xl-4 mb-3">
                                <div class="container bg-white redondear">
                                    <div class="row">
                                        <div class="col-4 p-2">
                                            <asp:Image ID="Image1" ImageUrl="../assets/img/sinImagen.png" CssClass="w-100" runat="server" />
                                        </div>
                                        <div class="col-8 p-2 align-items-center text-dark">
                                            <label class="w-100"><%#Eval("TipoServicio") %></label>
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
                                                    <asp:Button ID="Button1" CommandName="Agregar" OnCommand="AgregarCarrito" CommandArgument='<%#Eval("IDServicio")+"|"+Eval("PrecioServicio")+"|"+"assets/img/sinImagen.png"+ "|"+Eval("TipoServicio") %>' CssClass="btn btn-dark text-light" runat="server" Text="+" />
                                                </div>
                                            </div>
                                            <label for="" class="text-precio fw-bold">S/ <%#Eval("PrecioServicio") %></label>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
