<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="MecaWash.Proyecto.Presentacion.Colaborador.Tecnico.inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title></title>
    <link rel="stylesheet" href="../../Content/bootstrap.min.css">
    <link rel="stylesheet" href="../../assets/css/cabecera.css">
    <script type="text/javascript" src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
    <script src='../../fullcalendar/dist/index.global.js'></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.2/font/bootstrap-icons.min.css">
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script>
        function mostrarCalendario () {

            // Llamada al WebMethod para obtener los datos
            $.ajax({
                type: "POST",
                url: "Inicio.aspx/obtenerDatosCitasCalendar",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    // Se obtienen los datos y se recorren
                    var datos = JSON.parse(response.d);
                    var events = [];
                    for (var i = 0; i < datos.length; i++) {
                        // Se crea el objeto con los datos de la cita
                        events.push({
                            id: datos[i].Id,
                            title: datos[i].Title,
                            start: datos[i].Start,
                            end: datos[i].End,
                            color: "#FFB900",
                            textColor: "#000000"
                        });
                    };

                    // Configuración y renderizado del calendario

                    var calendarEl = document.getElementById('calendar');

                    var calendar = new FullCalendar.Calendar(calendarEl, {
                        height: '100%',
                        expandRows: true,
                        slotMinTime: '08:00',
                        slotMaxTime: '20:00',
                        headerToolbar: {
                            left: 'prevYear,prev,next,nextYear today',
                            center: 'title',
                            right: 'dayGridMonth,dayGridWeek,dayGridDay',

                        },
                        buttonText: {
                            today: 'Hoy',
                            month: 'Mes',
                            week: 'Semana',
                            day: 'Día'
                        },
                        locale: 'es',
                        defaultDate: new Date(),
                        navLinks: true, // can click day/week names to navigate views
                        dayMaxEvents: true, // allow "more" link when too many events
                        eventStartEditable: false,
                        eventDurationEditable: false,
                        events: events,
                        eventClick: function (info) {
                            // Obtener la id del evento
                            var eventId = info.event.id;
                            let nom = info.event.title;
                            obtenerDetallesEvento(eventId, nom);
                        },
                        eventMouseEnter: function (info) {
                            info.el.style.backgroundColor = "black";
                        },
                        eventMouseLeave: function (info) {
                            info.el.style.backgroundColor = "transparent";
                        },
                    });
                    calendar.render();
                },
            });
        }

        function obtenerDetallesEvento(eventId, cliente) {
            $.ajax({
                type: "POST",
                url: "Inicio.aspx/obtenerDetallesEvento",
                data: JSON.stringify({ eventId: eventId }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    // La respuesta ya es un objeto JSON, no es necesario parsearla nuevamente
                    var datos = JSON.parse(response.d);

                    // Puedes realizar acciones adicionales con los detalles del evento si es necesario
                    // Mostrar el modal y pasar la id del evento
                    var texto = "";
                    var totalpagar = 0;
                    var empleado = "";
                    for (var i = 0; i < datos.length; i++) {
                        // Utiliza += para concatenar las líneas en lugar de +=
                        totalpagar += datos[i].subtotal;
                        empleado = datos[i].Nombre;
                        texto += "Nombre del servicio: " + datos[i].servicio + "<br>" +
                            "Precio del servicio: " + datos[i].precio + "<br>" +
                            "Descuento del servicio: " + datos[i].descuento + "<br>" +
                            "Detalle del servicio: " + datos[i].color + "<br>" +
                            "Subtotal del servicio: " + datos[i].subtotal + "<hr>";
                    }

                    $('#exampleModal').modal('show');
                    $('#exampleModal').find('.modal-header').find('.modal-title').html(cliente);
                    $('#exampleModal').find('.modal-body').html(texto + "<hr>" + "<strong>Empleado Asignado: " + empleado + "</strong><br>" + "Total a Pagar: " + totalpagar + " soles"); // Usa html en lugar de text para interpretar las etiquetas HTML
                },
                error: function (error) {
                    console.error("Error al obtener detalles del evento:", error);
                }
            });
        }

        mostrarCalendario();

        var object = { status: false, ele: null };

        function confirmaEliminar(ev) {
            if (object.status) {
                return true;
            }

            Swal.fire({
                title: "¿Desea aceptar la cita?",
                text: "Rivice si hay disponibilidad para ese día.",
                icon: "warning",
                showCancelButton: true,
                confirmButtonColor: "#3085d6",
                cancelButtonColor: "#d33",
                confirmButtonText: "Sí, Aceptar",
                cancelButtonText: "Cancelar",
                closeOnConfirm: true
            }).then((result) => {
                if (result.isConfirmed) {
                    

                    // Establecer el estado a verdadero y hacer clic en el elemento
                    object.status = true;
                    object.ele = ev;
                    object.ele.click();
                    object.status = false;
                }
            });

            return false;
        }

        function notiError(mensaje) {
            Swal.fire({
                title: "Ocurrio un error",
                text: mensaje,
                icon: "error"
            });
        }

        function notiExito(titulo, mensaje) {
            Swal.fire({
                title: titulo,
                text: mensaje,
                icon: "success"
            });
        }
    </script>
    <style>
        body {
            margin: 40px 10px;
            padding: 0;
            font-family: Arial, Helvetica Neue, Helvetica, sans-serif;
            font-size: 14px;
            overflow:hidden;
            user-select: none !important;
        }

        #calendar-container {
            position: fixed;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
        }

        .fc-header-toolbar {
            /*
    the calendar will be butting up against the edges,
    but let's scoot in the header's buttons
    */
            padding-top: 1em;
            padding-left: 1em;
            padding-right: 1em;
        }

        .modal-content {
            background: var(--body-color) !important;
            color: var(--color-tabla-text) !important;
        }
        .draggable {
            position: absolute;
            top: 5rem;
            left: 3rem;
            width: 24%;
            cursor: move;
            background: var(--body-color);
            border-radius: 10px;
            border: 2px solid #FFB900;
        }
        .h-80d{
            height:80vh;
        }
        .contenedor2{
            height:100%;
            width:auto;
            overflow-y: auto; 
            overflow-x: hidden;
        }

        .contenedor2::-webkit-scrollbar {
            width: 3px;
            border-radius: 25px;
        }

        .contenedor2::-webkit-scrollbar-track {
            background: gray;
        }

        .contenedor2::-webkit-scrollbar-thumb {
            background: #FFB900;
        }

        .contenedor2::-webkit-scrollbar-thumb:hover {
            background: #FFB900;
        }
        .bg-cabecera2{
            background: var(--body-color) !important;
        }
        .bg-blanco2{
            background: var(--sidebar-color) !important;
            color: var(--color-tabla-text) !important;
        }
        .o{
            cursor:pointer;
        }
        .oculta{
            display:none;
        }
        @media screen and (max-width: 720px) {
            .draggable {
                position: absolute;
                top: 5rem;
                left: 2%;
                width: 90%;
            }
            .h-80d{
                height:30%;
            }
            #calendar-container{
                width:100%;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id='calendar-container' class="pe-5 ps-5">
            <div id='calendar'></div>
        </div>

        <!-- Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel"></h5>
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">X</button>
                </div>
                <div class="modal-body">
                    ...
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    <button type="btnImprimir" class="btn btn-secondary" data-bs-dismiss="modal">Imprimir</button>
                </div>
            </div>
        </div>
    </div>
    </form>

    <script src="../../assets/js/activarDarkmode.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>
</body>
</html>
