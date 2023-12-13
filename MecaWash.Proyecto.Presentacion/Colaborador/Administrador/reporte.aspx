<%@ Page Title="" Language="C#" MasterPageFile="~/master/colaborador.Master" AutoEventWireup="true" CodeBehind="reporte.aspx.cs" Inherits="MecaWash.Proyecto.Presentacion.Colaborador.Administrador.reporte" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
    <div class = "container pt-3 pb-3" >
        <asp:Button ID="BtnCargar" runat="server" Text="Cliente " OnClick="BtnCargar_Click" CssClass="btn btn-info" />
        <asp:Button ID="Btnempleados" runat="server" CssClass="btn btn-secondary" OnClick="Btnempleados_Click" Text="Empleados " />
        <asp:Button ID="Btnvehiculo" runat="server" CssClass="btn btn-warning" OnClick="Btnvehiculo_Click" Text="Vehiculos " />
        <br />
        <div class="row">
            <div class="col-4">
                <label>Fecha Inicio</label>
        <asp:TextBox ID="TextBox1" CssClass="form-control"  TextMode="Date" runat="server"></asp:TextBox>
            </div>
            <div class="col-4">
                <label>Fecha Fin</label>
        <asp:TextBox ID="TextBox2" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
            </div>
            <div class="col-4">
                <label>Mostrar</label><br />
                <asp:Button ID="Button1" CssClass="btn btn-secondary" runat="server" Text="Reporte por fechas" OnClick="Button1_Click" />
            </div>
        </div>
        
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <center>
<rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="90%" Height="400px">
</rsweb:ReportViewer>
        </center>
</asp:Content>

