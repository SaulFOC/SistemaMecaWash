<%@ Page Title="" Language="C#" MasterPageFile="~/master/colaborador.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="MecaWash.Proyecto.Presentacion.Colaborador.Tecnico.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container pt-3 pb-3">
        <h3>PERFIL DEL TRABAJADOR</h3>
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
                <label class="form-label">Mi Puesto:</label>
                <asp:TextBox ID="txtDireccionM" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
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
</asp:Content>
