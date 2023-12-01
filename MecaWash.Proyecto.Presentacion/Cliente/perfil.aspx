<%@ Page Title="" Language="C#" MasterPageFile="~/master/cliente.Master" AutoEventWireup="true" CodeBehind="perfil.aspx.cs" Inherits="MecaWash.Proyecto.Presentacion.Cliente.perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container pt-3 pb-3">
        <h3>PERFIL DEL USUARIO</h3>
        <img width="100%" src="/assets/img/banner2.jpg" />
        <div class="row">
            <div class="col-sm-12 col-md-6 col-lg-3 col-xl-3 mt-3">
                <label class="form-label">Mi código:</label>
                <asp:TextBox ID="txtIdm" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-sm-12 col-md-6 col-lg-3 col-xl-3 mt-3">
                <label class="form-label">Mi DNI:</label>
                <asp:TextBox ID="txtDniM" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-sm-12 col-md-6 col-lg-3 col-xl-3 mt-3">
                <label class="form-label">Mi Nombre:</label>
                <asp:TextBox ID="txtNombreM" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-sm-12 col-md-6 col-lg-3 col-xl-3 mt-3">
                <label class="form-label">Mi dirección:</label>
                <asp:TextBox ID="txtDireccionM" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-sm-12 col-md-6 col-lg-3 col-xl-3 mt-3">
                <label class="form-label">Mi correo:</label>
                <asp:TextBox ID="txtCorreoM" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-sm-12 col-md-6 col-lg-3 col-xl-3 mt-3">
                <label class="form-label">Estado:</label>
                <asp:TextBox ID="txtEstado" ReadOnly="true" CssClass="form-control" Text="ACTIVO" runat="server"></asp:TextBox>
            </div>
            
        </div>
        <div class="row mt-4">
            <h4>Opciones</h4>
            <div class="col-sm-12 col-md-6 col-lg-4 col-xl-4 mt-3">
                <asp:Button ID="Button1" CssClass="btn btn-secondary w-100" runat="server" Text="Actualizar" />
            </div>
            <div class="col-sm-12 col-md-6 col-lg-4 col-xl-4 mt-3">
                <button class="btn btn-secondary w-100" data-bs-toggle="modal" data-bs-target="#exampleModal" type="button">Agregar Vehiculo</button>
            </div>
        </div>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <!-- modal -->
                <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog modal-dialog-centered">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="exampleModalLabel">Agregar Vehiculo</h5>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <div class="row mb-3">
                                    <div class="col-6">
                                        <label class="focus-label">Numero de Placa</label>
                                        <asp:TextBox ID="txtPlacaN" MaxLength="7" placeholder="placa" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-6">
                                        <label class="focus-label">Marca</label>
                                        <asp:TextBox ID="txtMarcaN" placeholder="Marca" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row mb-3">
                                    <div class="col-6">
                                        <label class="focus-label">Color</label>
                                        <asp:TextBox ID="txtColorN" placeholder="color" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-6">
                                        <label class="focus-label">Año</label>
                                        <asp:TextBox ID="txtYear" placeholder="año" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="mb-3">
                                    <label class="focus-label">Modelo</label>
                                    <asp:TextBox ID="txtModeloN" placeholder="modelo" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="Button2" CssClass="btn btn-secondary" CommandName="aggVehiculo" OnCommand="AgregarVehiculo" data-bs-dismiss="modal" runat="server" Text="Agregar Vehiculo" />
                                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>


    </div>
</asp:Content>
