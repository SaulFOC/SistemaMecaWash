<%@ Page Title="" Language="C#" MasterPageFile="~/master/colaborador.Master" AutoEventWireup="true" CodeBehind="reporte.aspx.cs" Inherits="MecaWash.Proyecto.Presentacion.Colaborador.Administrador.reporte" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class = "container pt-3 pb-3" >
        <asp:Button ID="BtnCargar" runat="server" Text="Cliente " OnClick="BtnCargar_Click" CssClass="btn btn-info" />
        <asp:Button ID="Btnempleados" runat="server" CssClass="btn btn-secondary" OnClick="Btnempleados_Click" Text="Empleados " />
        <asp:Button ID="Btnvehiculo" runat="server" CssClass="btn btn-warning" OnClick="Btnvehiculo_Click" Text="Vehiculos " />
        <asp:Button ID="btnVentas" runat="server" Height="20px" OnClick="btnVentas_Click" Text="Ventas" Width="97px" />
        <asp:Button ID="btnCita" runat="server" Height="21px" OnClick="btnCita_Click" Text="Cita" Width="87px" />
        <br />
        <asp:TextBox ID="TextBox1" TextMode="Date" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox2" TextMode="Date" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Reporte por fechas" OnClick="Button1_Click" />
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="860px">
</rsweb:ReportViewer>
</asp:Content>

