<%@ Page Title="" Language="C#" MasterPageFile="~/master/colaborador.Master" AutoEventWireup="true" CodeBehind="reporte.aspx.cs" Inherits="MecaWash.Proyecto.Presentacion.Colaborador.Administrador.reporte" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class = "container pt-3 pb-3" >
        <asp:Button ID="BtnCargar" runat="server" Text="Cliente " OnClick="BtnCargar_Click" CssClass="btn btn-info" />
        <asp:Button ID="Btnempleados" runat="server" CssClass="btn btn-secondary" OnClick="Btnempleados_Click" Text="Empleados " />
        <asp:Button ID="Btnvehiculo" runat="server" CssClass="btn btn-warning" OnClick="Btnvehiculo_Click" Text="Vehiculos " />
        <center>
        <rsweb:ReportViewer Width="100%" Height="520px" ID="ReportViewer1" runat="server">
        </rsweb:ReportViewer>
            </center>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
</asp:Content>

