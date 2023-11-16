<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="MecaWash.Proyecto.Presentacion.Colaborador._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="Content-Language" content="es">
    <title>Colaborador</title>
    <link rel="stylesheet" href="../Content/bootstrap.min.css">
    <link rel="stylesheet" href="../assets/css/loginColaborador.css">
    <link rel="stylesheet" href="../assets/fonts/icomoon/style.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="d-lg-flex half">
            <div class="bg order-1 order-md-2 imagen" style="background-image: url('../assets/img/mecanico.jpg');"></div>
            <div class="contents order-2 order-md-1">

                <div class="container">
                    <div class="row align-items-center justify-content-center">
                        <div class="col-md-7">
                            <h3>Iniciar Sesión <strong>MecWash</strong></h3>
                            <p class="mb-4">Bienvenido nuestro valioso colaborador inicia sesión en el portal, para comenzar a laburar.</p>
                            
                                <div class="form-group first">
                                    <label for="username">Correo</label>
                                    <asp:TextBox ID="txtCorreo" runat="server" class="form-control" placeholder="correo@gmail.com"></asp:TextBox>
                                   
                                </div>
                                <div class="form-group last mb-3">
                                    <label for="password">Contraseña</label>
                                    <asp:TextBox ID="txtPassword" class="form-control" placeholder="Su contraseña" runat="server" TextMode="Password"></asp:TextBox>
                                    
                                </div>

                                <div class="d-flex mb-5 align-items-center">
                                    <label class="control control--checkbox mb-0">
                                        <span class="caption">Recuerdame</span>
                                        <input type="checkbox" checked="checked" />
                                        <div class="control__indicator"></div>
                                    </label>
                                    <span class="ml-auto"><a href="#" class="forgot-pass">Soporte</a></span>
                                </div>
                            <asp:Button ID="Button1" runat="server" Text="Iniciar Sesion"   class="btn text-decoration-none btn-secundario" OnClick="Button1_Click"/>
                            <%-- <a href="Administrador/" class="btn text-decoration-none btn-secundario">Iniciar Sesion</a>--%>
                            
                        </div>
                    </div>
                </div>
            </div>

            <script src="../Scripts/bootstrap.min.js"></script>
        </div>
    </form>
</body>
</html>
