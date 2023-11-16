<%@ Page Title="" Language="C#" MasterPageFile="~/master/cliente.Master" AutoEventWireup="true" CodeBehind="servicios.aspx.cs" Inherits="MecaWash.Proyecto.Presentacion.Cliente.servicios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container pt-3 pb-3">
        <h4>Servicios</h4>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="row">
                <%for(int i = 0; i < 5; i++){ %>
                    <div class="col-sm-12 col-md-4 col-lg-4 col-xl-4 mb-3">

                    </div>
                <%} %>
                    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
