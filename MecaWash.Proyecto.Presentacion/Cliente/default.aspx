<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="MecaWash.Proyecto.Presentacion.Cliente._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Cliente</title>
    <link href='https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css' rel='stylesheet'>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.1/font/bootstrap-icons.css">
    <link rel="stylesheet" href="../assets/css/estilomenu.css">
</head>
<body>
    <form id="form1" runat="server">
        <nav class="sidebar close">
    <header>
        <div class="image-text">
            <span class="image">
                <img src="../assets/img/logo.png" alt="logo">
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
                    <a href="home.aspx" target="myFrame">
                        <i class='bx bx-home-alt icon'></i>
                        <span class="text nav-text">Inicio</span>
                    </a>
                </li>

                <li class="nav-link">
                    <a href="servicios.aspx" target="myFrame">
                        <i class="bi bi-wrench-adjustable icon"></i>
                        <span class="text nav-text">Servicios</span>
                    </a>
                </li>

                <li class="nav-link">
                    <a href="repuestos.aspx" target="myFrame">
                    <i class="bi bi-car-front-fill icon"></i>
                        <span class="text nav-text">Repuestos</span>
                    </a>
                </li>

                <li class="nav-link">
                    <a href="carrito.aspx" target="myFrame">
                        <i class="bi bi-basket-fill icon"></i>
                        <span class="text nav-text">Carrito</span>
                    </a>
                </li>

                <li class="nav-link">
                    <a href="perfil.aspx" target="myFrame">
                        <i class='bx bx-user icon'></i>
                        <span class="text nav-text">Perfil</span>
                    </a>
                </li>

            </ul>
        </div>

        <div class="bottom-content">
            <li>
                <a href="cerrar.aspx">
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
    <script src="../assets/js/funcionmenu.js"></script>
    </form>
</body>
</html>
