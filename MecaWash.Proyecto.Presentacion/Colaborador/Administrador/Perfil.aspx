<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Perfil_Usuario.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <link rel="stylesheet" href="Content/bootstrap.min.css">
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <title></title>
    <style type="text/css">
        .zoo-user-chat
        {
            cursor: pointer;
            background-color: #4d79f6;
            border-radius: 90%;
            width: 60px;
            height: 60px;
            display: inline-block;
            line-height: 60px;
            text-align: center;
            position: absolute;
            right: 1000px;
            left: 0;
            margin: 140px auto;
        }
        .zoo-user-chat i
        {
            transition: all .3s;
            color: #fff;
            font-size: 14px;
        }

        .uil-comment-dots:before 
        {
            content: '\e929';
            font-family: unicons;
            font-style: normal;
            font-weight: 400;
            display: inline-block;
            text-decoration: inherit;
            width: 1em;
            margin-right: 0.2em;
            text-align: center;
            font-variant: normal;
            text-transform: none;
            line-height: 1em;
            margin-left: 0.2em;
            -webkit-font-smoothing: antialiased
        }
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 381px;
        }
        .auto-style3 {
            width: 241px
        }
        .auto-style4 {
            margin-left: 81;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <table class="auto-style1">
                <tr>
                    <div class="row">
                        <div class="col-sm-4" style="margin-top: 50px;">
                    <td class="auto-style2" rowspan="9">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Image ID="Image1" runat="server" src="http://ssl.gstatic.com/accounts/ui/avatar_2x.png" class="avatar img-circle img-thumbnail" alt="avatar"/>
                        <span class="zoo-user-chat custom-cursor-on-hover">
                            <i type="file" class="uil uil-comment-dots custom-cursor-on-hover"></i>
                    </td>
                    </div>
              <div class="col-sm-8" style="margin-top: 50px;">
                  <ul class="nav nav-tabs">
                    <td class="auto-style3"><a data-toggle="tab" href="#home"> Perfil </a></td>
                    <td>&nbsp;</td>
                  </ul>
                </tr>
                <div>
                <tr>
                    <td class="auto-style3">ID</td>
                    <td>DNI</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDni" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Contraseña</td>
                    <td>Nombre</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="auto-style4"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Telefono</td>
                    <td>Correo</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtTelefono" runat="server" TextMode="Phone"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCorreo" runat="server" TextMode="Email"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Puesto</td>
                    <td>Estado</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtPuesto" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEstado" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Inoperativo</asp:ListItem>
                            <asp:ListItem>Operativo</asp:ListItem>
                        </asp:DropDownList>
              </div> 
                        </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
