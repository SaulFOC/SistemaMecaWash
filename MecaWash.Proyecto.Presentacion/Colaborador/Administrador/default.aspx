<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="MecaWash.Proyecto.Presentacion.Colaborador.Administrador._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="Content-Language" content="es">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Administrador</title>
    <link href='https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css' rel='stylesheet'>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/intro.js/7.2.0/introjs.min.css" rel="stylesheet">
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
                <span class="name">MecWash</span>
                <span class="profession">Administrador</span>
                <asp:Label ID="llbNombre" runat="server" CssClass="text-truncate"></asp:Label></span>
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

            

            <ul class="menu-links">
                <li class="nav-link first">
                    <a href="default.aspx" target="myFrame">
                        <i class='bx bxs-dashboard icon'></i>
                        <span class="text nav-text">Inicio</span>
                    </a>
                </li>

                <li class="nav-link second">
                    <a href="servicios.aspx" target="myFrame">
                        <i class='bx bxs-wrench icon'></i>
                        <span class="text nav-text">Servicios</span>
                    </a>
                </li>

                <li class="nav-link third">
                    <a href="empleados.aspx" target="myFrame">
                    <i class='bx bxs-user-detail icon'></i>
                        <span class="text nav-text">Empleados</span>
                    </a>
                </li>

                <li class="nav-link fourth">
                    <a href="Perfil.aspx" target="myFrame">
                        <i class='bx bx-user icon'></i>
                        <span class="text nav-text">Perfil</span>
                    </a>
                </li>

                <li class="nav-link five">
                    <a href="Clientes.aspx" target="myFrame">
                        <i class='bx bx-support icon'></i>
                        <span class="text nav-text">Clientes</span>
                    </a>
                </li>
                <li class="nav-link six">
                    <a href="Vehiculos.aspx" target="myFrame">
                    <i class='bx bx-search icon'></i>
                    <span class="text nav-text">Vehiculo</span>
                        </a>
                </li>

            </ul>
        </div>

        <div class="bottom-content ">
            <li class="nav-link seven">
                <a href="cerrar.aspx">
                    <i class='bx bx-log-out icon'></i>
                    <span class="text nav-text">Salir</span>
                </a>
            </li>

            <li class="mode eight">
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
    <script src="https://cdnjs.cloudflare.com/ajax/libs/intro.js/7.2.0/intro.min.js"></script>
        <script>
            introJs().setOptions({

                nextLabel: 'siguiente',
                prevLabel: 'atras',
                doneLabel: 'hecho',
                //esditar el texto de no mostrar de nuevo a español
                skipLabel: 'x',

                steps: [
                    {
                        title: 'Bienvenido',
                        intro: '👋 Bienvenido a la pagina de administrador, aqui podras ver los servicios que se ofrecen, los empleados que trabajan en la empresa, tu perfil y el soporte tecnico'
                    },
                    {
                        title: 'Dashboard  📊',
                        element: document.querySelector('.first'),
                        intro: 'Haciendo click aca podras ver las estadisiticas de la empresa'
                    },
                    {
                        title: 'Servicios 🔧',
                        element: document.querySelector('.second'),
                        intro: 'Haciendo click aca podras agregar los serivicios que se ofrecemos '
                    },
                    {
                        title: 'Empleados 👨‍🔧',
                        element: document.querySelector('.third'),
                        intro: 'En este apartado podras ver los empleados que trabajan en la empresa, agregarlos, editarlos y eliminarlos'
                    },
                    {
                        title: 'Perfil 👤',
                        element: document.querySelector('.fourth'),
                        intro: 'En este apartado podras ver tu perfil, editar tu informacion y cambiar tu contraseña'
                    },
                    {
                        title: 'Clientes 👨🏼‍🤝‍👨🏼',
                        element: document.querySelector('.five'),
                        intro: 'En este apartado podras ver los clientes que se han registrado en la empresa, agregarlos, editarlos y eliminarlos'
                    },
                    {
                        title: 'Vehiculos 🚗',
                        element: document.querySelector('.six'),
                        intro: 'En este apartado podras ver los vehiculos que se han registrado en la empresa, agregarlos, editarlos y eliminarlos'
                    }, 
                    {
                        title: 'Salir 🚪',
                        element: document.querySelector('.seven'),
                        intro: 'En este apartado podras cerrar sesion'
                    },
                    {
                        title: 'Dark mode y Light mode 🌙',
                        element: document.querySelector('.eight'),
                        intro: 'En este apartado podras cambiar el modo de la pagina entre claro y oscuro'
                    }

                ],
                showBullets: false,
                showProgress: true,
                disableInteraction: true,
                dontShowAgain: true,
            }).start();
        </script>
    </form>
</body>
</html>
