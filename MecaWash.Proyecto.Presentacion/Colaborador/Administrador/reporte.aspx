<%@ Page Title="" Language="C#" MasterPageFile="~/master/colaborador.Master" AutoEventWireup="true" CodeBehind="reporte.aspx.cs" Inherits="MecaWash.Proyecto.Presentacion.Colaborador.Administrador.reporte" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class = "container" >
        <asp:Button ID="BtnCargar" runat="server" Text="Cliente " OnClick="BtnCargar_Click" BackColor="#6699FF" />
        <asp:Button ID="Btnempleados" runat="server" BackColor="#FFFF66" OnClick="Btnempleados_Click" Text="Empleados " />
        <asp:Button ID="Btnvehiculo" runat="server" BackColor="#66FF66" OnClick="Btnvehiculo_Click" Text="Vehiculos " />
        <rsweb:ReportViewer CssClass="w-100" ID="ReportViewer1" runat="server" Width="845px">
        </rsweb:ReportViewer>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
</asp:Content>

