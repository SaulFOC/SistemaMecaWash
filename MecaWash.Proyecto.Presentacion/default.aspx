<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="MecaWash.Proyecto.Presentacion._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="Content-Language" content="es">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="Content/bootstrap.min.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/swiper@9/swiper-bundle.min.css" />
    <link rel="stylesheet" href="assets/css/cabecera.css">
    <link href='https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css' rel='stylesheet'>
    <title></title>
    <style>
        * {
            margin: 0;
            padding: 0;
        }

        .bg-b {
            background: var(--color-white);
            color: var(--text-color);
        }

        .bg-secundario {
            background: var(--body-color);
        }

        .btn-buscar {
            background: var(--primary-color);
            color: var(--color-white);
        }

        .imagen2 {
            height: 255px;
            width: 100%;
            object-fit: cover;
        }

        .cabecera .swiper {
            width: 100%;
            max-width: 1600px;
        }

        .cabecera .swiper-button-prev,
        .cabecera .swiper-button-next {
            --swiper-navigation-size: 20px;
            background: #383838;
            color: #fff;
            font-weight: bold;
            height: 70px;
            width: 50px;
            margin-top: -35px;
            opacity: 0;
            transition: opacity 0.3s;
        }

        .cabecera .swiper-button-prev {
            border-radius: 0 65px 65px 0;
            left: -10px;
        }

        .cabecera .swiper-button-next {
            border-radius: 65px 0 0 65px;
            right: -10px;
        }

        .cabecera .swiper:hover .swiper-button-prev,
        .cabecera .swiper:hover .swiper-button-next {
            opacity: 1;
        }

        .cabecera .swiper-pagination {
            /* Reeditando las clases de la libreria */
            --swiper-pagination-color: white;
            --swiper-pagination-bullet-size: 8px;
            --swiper-pagination-bullet-inactive-color: #000;
            --swiper-pagination-bullet-inactive-opacity: 0.25;
            --swiper-pagination-bullet-opacity: 1;
            --swiper-pagination-bullet-horizontal-gap: 4px;
            --swiper-pagination-bullet-vertical-gap: 6px;
        }

        .cabecera .swiper-pagination-bullet {
            box-shadow: inset 0 0 0 1px #fff;
        }

        .cabecera .swiper-pagination-bullet-active {
            box-shadow: 0 0 0 1px rgba(0, 0, 0, 0.25);
        }


        /* oferta */
        #oferta .swiper {
            width: 90%;
            max-width: 1600px;
        }

        #oferta .swiper-button-prev,
        #oferta .swiper-button-next {
            --swiper-navigation-size: 20px;
            background: #383838;
            color: #fff;
            font-weight: bold;
            height: 70px;
            width: 50px;
            margin-top: -35px;
            opacity: 0;
            transition: opacity 0.3s;
        }

        #oferta .swiper-button-prev {
            border-radius: 0 65px 65px 0;
            left: -10px;
        }

        #oferta .swiper-button-next {
            border-radius: 65px 0 0 65px;
            right: -10px;
        }

        #oferta .swiper:hover .swiper-button-prev,
        #oferta .swiper:hover .swiper-button-next {
            opacity: 1;
        }

        .img-card {
            width: 100%;
        }

        .tarjeta {
            width: 13.5rem;
            box-shadow: 0px 4px 4px rgba(0, 0, 0, 0.25);
        }

        .w-90 {
            width: 90%;
        }

        .nav-link {
            text-decoration: none !important;
        }

            .nav-link:hover, .nav-link:focus, .nav-link:active {
                color: var(--text-color) !important;
            }

        .form-control:focus {
            border-color: var(--primary-color);
            box-shadow: 0 0 0 0.25rem rgb(249 119 119 / 25%);
        }

        .text-success {
            color: #383838 !important;
        }

        .bg-black {
            background: #000 !important;
        }

        .text-container {
            color: #fff;
            display: flex;
            align-items: center;
        }
        .btn-transparente{
            background-color:transparent;
            border:none;
            color:#383838;
        }
        .btn-login{
            background:#383838 !important;
            color:#fff !important;
        }

        @media (min-width: 1024px) {
            .imagen {
                height: 340px;
            }
        }

        @media screen and (max-width: 720px) {
            .w-50 {
                width: 100% !important;
            }

            #oferta .swiper {
                width: 95%;
            }

            .text-container {
                margin: auto;
                width: 93.95%;
            }
        }
    </style>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script>
        function notiError(mensaje) {
            Swal.fire({
                title: "Ocurrio un error",
                text: mensaje,
                icon: "error"
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <nav class="navbar sticky-top navbar-expand-lg bg-secundario">
            <div class="container-fluid">
                <a class="navbar-brand text-oscuro" href="#">
                    <img src="assets/img/logo.png" width="45" height="45" class="d-inline-block align-text-top" alt="">
                </a>
                <label class="text-center fw-bold" for="">MecWash</label>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <i class='bx bx-grid-alt text-rosa fs-1'></i>
                </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav ms-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <a class="nav-link text-rosa" aria-current="page" href="#contenedorgeneral">Inicio</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link text-rosa" aria-current="page" href="#oferta">Servicios</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link text-rosa" aria-current="page" href="#ofertas1">Ofertas</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link text-rosa" aria-current="page" href="" data-bs-toggle="modal" data-bs-target="#frmLogin">Iniciar Sesion</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link text-rosa" aria-current="page" href="" data-bs-toggle="modal" data-bs-target="#frmRegistro">Registrarse</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>

        <div id="contenedorgeneral" class="mb-4">
            <section class="cabecera">
                <div class="swiper" id="banner">
                    <div class="swiper-wrapper">
                        <!-- para colocar elementos del slider -->
                        <div class="swiper-slide">
                            <img class="imagen2" src="assets/img/banner1.jpg" alt="">
                        </div>
                        <div class="swiper-slide">
                            <img class="imagen2" src="assets/img/banner1.jpg" alt="">
                        </div>
                        <div class="swiper-slide">
                            <img class="imagen2" src="assets/img/banner1.jpg" alt="">
                        </div>
                        <div class="swiper-slide">
                            <img class="imagen2" src="assets/img/banner1.jpg" alt="">
                        </div>
                    </div>
                    <!-- para la paginacion del slider (los puntitos) -->
                    <div class="swiper-pagination"></div>

                    <!-- para los botones de navegacion del slider (las flechas) -->
                    <div class="swiper-button-prev"></div>
                    <div class="swiper-button-next"></div>

                </div>
            </section>

            <section id="oferta" class="pt-3 mt-4 pb-3">

                <div class="swiper" id="ofertas">
                    <div class="swiper-wrapper mb-3">
                        <!-- para elementos del slider que mostraran algunos productos -->
                        <% for (int i = 1; i <= 8; i++)
                            { %>
                        <div class="swiper-slide tarjeta redondear bg-b">
                            <div class="container">
                                <img class="img-card mt-3" src="assets/img/cambioaceite.jpg" alt="">
                                <hr>
                                <div>
                                    <label class="fw-bold text-uppercase" for="">Cambio de aceite</label>
                                </div>
                                <div>
                                    <p>Se realiza el respectivo cambio de aceite al vehiculo</p>
                                </div>
                            </div>
                        </div>
                        <%} %>

                    </div>
                    <!-- para las flechistas que permiten avanzar y retroceder el slider -->
                    <div class="swiper-button-prev"></div>
                    <div class="swiper-button-next"></div>

                </div>
            </section>

            <!-- para la seccion de ofertas del dia -->
            <section id="ofertas1">
            <% for (int i = 1; i <= 4; i++)
                { %>
            <div class="container mb-3">
                <div class="row">
                    <div class="col-sm-12 col-md-6 col-lg-6 col-xl-6">
                        <img src="assets/img/pastilas.jpg" class="img-card" alt="">
                    </div>
                    <div class="col-sm-12 col-md-6 col-lg-6 col-xl-6 bg-black text-container">
                        <div class="p-3">
                            <p>OFERTAS DEL DIA</p>
                            <h3 class="text-wrap w-75">APROVECHA LAS MEJORES OFERTAS</h3>
                            <p>Ver Más ...</p>
                        </div>
                    </div>
                </div>
            </div>
            <%} %>
                </section>

            <!-- para los modales -->
        <!-- Para Login -->
        <div class="modal fade" id="frmLogin" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title text-success" id="exampleModalLabel">Login</h5>
                        <button type="button" class="btn-transparente" data-bs-dismiss="modal" aria-label="Close"><i class='bx bx-x fs-2'></i></button>
                    </div>
                    <div class="modal-body">
                        
                        <!--Aqui va el formulario de login-->
                            <div class="mb-3">
                                <label for="loginUser" class="form-label">Correo</label>
                                <asp:TextBox ID="txtCorreo" TextMode="Email" CssClass="form-control" placeholder="Correo" runat="server"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <label for="loginPassword" class="form-label">Contraseña</label>
                                <asp:TextBox ID="txtClave" CssClass="form-control" TextMode="Password" placeholder="********" runat="server"></asp:TextBox>
                            </div>
                        <asp:LinkButton ID="LinkButton1" CssClass="btn btn-login" CommandName="Loguear" OnCommand="LoguearCliente2" runat="server">Iniciar sesión</asp:LinkButton>

                    </div>
                    <div class="modal-footer">
                        <label for="" class="">Click aqui si eres <a href="Colaborador/" class="text-success">colaborador</a></label>
                        <div class="text-center container mt-4">
                            <a href="recuperar.aspx" class="text-success fz-100">¿Olvidaste tu contraseña?</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Para Registro -->
        <div class="modal fade" id="frmRegistro" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title text-success" id="exampleModalLabel">Registrarte</h5>
                        <button type="button" class="btn-transparente" data-bs-dismiss="modal" aria-label="Close"><i class='bx bx-x fs-2'></i></button>
                    </div>
                    <div class="modal-body">

                        <!--Aqui va el formulario de registro-->
                            <div class="row mb-2">
                                <div class="col-6">
                                    <label for="user" class="form-label">DNI</label>
                                    <input type="text" class="form-control" name="dni" maxlength="8" placeholder="DNI" required>
                                </div>
                                <div class="col-6">
                                    <label for="password" class="form-label">Celular</label>
                                    <input type="password" class="form-control" name="text" maxlength="9" placeholder="999999999" required>
                                </div>
                            </div>

                            <div class="row mb-2">
                                <div class="col-6">
                                    <label for="nombre" class="form-label mb-0 w-100 text-truncate">Nombre</label>
                                    <input type="text" class="form-control" name="nombre" placeholder="Nombre" required>
                                </div>
                                <div class="col-6">
                                    <label for="apellido" class="form-label mb-0 w-100 text-truncate">Apellidos</label>
                                    <input type="text" class="form-control" name="apellido" placeholder="Apellidos" required>
                                </div>
                            </div>

                            <div class="row mb-2">
                                <div class="col-8">
                                    <label for="correo" class="form-label">Correo</label>
                                    <input type="email" class="form-control" name="correo" placeholder="correo@gmail.com" required>
                                </div>
                                <div class="col-4">
                                    <label for="password" class="form-label">Contraseña</label>
                                    <input type="password" class="form-control" name="password" placeholder="Contraseña" required>
                                </div>
                            </div>

                            <div class="mb-3">
                                <label for="direccion" class="form-label">Dirección</label>
                                <input type="text" class="form-control" name="direccion" placeholder="Dirección" required>
                            </div>
                            <button id="btnRegistrar" class="btn btn-login">Registrarse</button>

                    </div>
                    <div class="modal-footer">
                        <label for="" class="">Click aqui si eres <a href="Colaborador/" class="text-success">colaborador</a></label>
                    </div>
                </div>
            </div>
        </div>


        </div>

        <script src="https://cdn.jsdelivr.net/npm/swiper@9/swiper-bundle.min.js"></script>
        <script>
            const banner = new Swiper('#banner', {
                // Parametros para el slider
                direction: 'horizontal',
                loop: true,
                autoplay: {
                    delay: 2500,
                    pauseOnMouseEnter: true,
                    disableOnInteraction: false,
                },

                // para la paginacion del slider (los puntitos)
                pagination: {
                    el: '.swiper-pagination',
                    clickable: true,
                    dynamicBullets: true,
                },

                // para los botones de navegacion del slider (las flechas)
                navigation: {
                    nextEl: '.swiper-button-next',
                    prevEl: '.swiper-button-prev',
                },
            });

            const ofertas = new Swiper('#ofertas', {
                // parametros para el slider
                slidesPerView: 'auto',
                spaceBetween: 25,
                direction: 'horizontal',
                loop: true,

                // para los botones de navegacion del slider (las flechas)
                navigation: {
                    nextEl: '.swiper-button-next',
                    prevEl: '.swiper-button-prev',
                },

            });
        </script>
        <script src="Scripts/bootstrap.min.js"></script>
        <script src="assets/js/menu/activarDarkmode.js"></script>
        <script>
            window.addEventListener('mouseover', initLandbot, { once: true });
            window.addEventListener('touchstart', initLandbot, { once: true });
            var myLandbot;
            function initLandbot() {
                if (!myLandbot) {
                    var s = document.createElement('script'); s.type = 'text/javascript'; s.async = true;
                    s.addEventListener('load', function () {
                        var myLandbot = new Landbot.Livechat({
                            configUrl: 'https://storage.googleapis.com/landbot.online/v3/H-1780368-J0PV95E99HHMQEFX/index.json',
                        });
                    });
                    s.src = 'https://cdn.landbot.io/landbot-3/landbot-3.0.0.js';
                    var x = document.getElementsByTagName('script')[0];
                    x.parentNode.insertBefore(s, x);
                }
            }
        </script>
    </form>
</body>
</html>
