<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="MecaWash.Proyecto.Presentacion.Colaborador.Administrador._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Administrador</title>
    <link href='https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css' rel='stylesheet'>
    <link rel="stylesheet" href="../../assets/css/estilomenu.css">
</head>
<body>
    <form id="form1" runat="server">
         <nav class="sidebar close">
    <header>
        <div class="image-text">
            <span class="image">
                <img src="../../assets/img/logo.png" alt="logo">
            </span>

            <div class="text logo-text">
                <span class="name">Boomerang</span>
                <span class="profession">Cliente</span>
            </div>
        </div>

        <!-- cambia el icono segun el dispositivo -->
            <% if (Request.Browser.IsMobileDevice)
            { %>
        <i class='bx bx-grid-small toggle'></i>
        <%}
            else
            { %>
            <i class='bx bx-chevron-right toggle'></i>
        <%} %>


    </header>

    <div class="menu-bar">
        <div class="menu">

            <li class="search-box">
                <i class='bx bx-search icon'></i>
                <input type="text" placeholder="Search...">
            </li>

            <ul class="menu-links">
                <li class="nav-link">
                    <a href="default.aspx" target="myFrame">
                        <i class='bx bx-home-alt icon'></i>
                        <span class="text nav-text">Inicio</span>
                    </a>
                </li>

                <li class="nav-link">
                    <a href="#" target="myFrame">
                        <i class='bx bx-bowl-rice icon'></i>
                        <span class="text nav-text">Ofertas</span>
                    </a>
                </li>

                <li class="nav-link">
                    <a href="empleados.aspx" target="myFrame">
                    <i class='bx bxs-user-detail icon'></i>
                        <span class="text nav-text">Empleados</span>
                    </a>
                </li>

                <li class="nav-link">
                    <a href="perfil2.php" target="myFrame">
                        <i class='bx bx-user icon'></i>
                        <span class="text nav-text">Perfil</span>
                    </a>
                </li>

                <li class="nav-link">
                    <a href="chatbot.php" target="myFrame">
                        <i class='bx bx-support icon'></i>
                        <span class="text nav-text">Soporte</span>
                    </a>
                </li>

            </ul>
        </div>

        <div class="bottom-content">
            <li class="">
                <a href="../backend/controller/cerrarSesionCliente.php">
                    <i class='bx bx-log-out icon'></i>
                    <span class="text nav-text">Salir</span>
                </a>
            </li>

            <li class="mode">
                <div class="sun-moon">
                    <i class='bx bx-moon icon moon'></i>
                    <i class='bx bx-sun icon sun'></i>
                </div>
                <span class="mode-text text">Dark mode</span>

                <div class="toggle-switch">
                    <span class="switch"></span>
                </div>
            </li>

        </div>
    </div>

</nav>

    <section class="home">
        <iframe src="home.aspx" name='myFrame' style="height: 100%; width: 100%; border: none;"></iframe>

        <!--<div class="text">Dashboard Sidebar</div>-->
    </section>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="../../assets/js/funcionmenu.js"></script>
    </form>
</body>
</html>
