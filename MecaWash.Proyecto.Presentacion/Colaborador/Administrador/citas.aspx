<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="citas.aspx.cs" Inherits="MecaWash.Proyecto.Presentacion.Colaborador.Administrador.citas" %>

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
                url: "Citas.aspx/obtenerDatosCitasCalendar",
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
                url: "Citas.aspx/obtenerDetallesEvento",
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
                text: "Revice si hay disponibilidad para ese día.",
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

        var object1 = { status1: false, ele1: null };

        function confirmaEliminar1(ev) {
            if (object1.status1) {
                return true;
            }

            Swal.fire({
                title: "¿Desea rechazar la cita?",
                text: "Se rechazara la cita.",
                icon: "warning",
                showCancelButton: true,
                confirmButtonColor: "#3085d6",
                cancelButtonColor: "#d33",
                confirmButtonText: "Sí, Rechazar",
                cancelButtonText: "Cancelar",
                closeOnConfirm: true
            }).then((result) => {
                if (result.isConfirmed) {


                    // Establecer el estado a verdadero y hacer clic en el elemento
                    object1.status1 = true;
                    object1.ele1 = ev;
                    object1.ele1.click();
                    object1.status1 = false;
                }
            });

            return false;
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

         <div class="container">
        <div id="conP" class="container draggable h-80d pt-2 pb-2">
            
            <div class="container contenedor2">
                <h5 class="pt-2 pb-2 position-sticky top-0 bg-cabecera2"><spam>Aceptar Citas</spam> <i id="swith" class="bi bi-caret-up-fill o"></i></h5>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <contenttemplate>
                            <div id="contenedorCitas" class="row">
                                <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound" OnItemCommand="Repeater1_ItemCommand">
                                    <itemtemplate>
                                        <div class="col-12 mb-3">
                                            <div class="container bg-blanco2 redondear p-3">
                                                <div class="pb-2">
                                                    <label class="text-truncate w-100"><i class="bi bi-person-bounding-box"> </i><%#Eval("Nombre") %></label><br />
                                                </div>
                                                <div class="row pb-2">
                                                    <div class="col-6">
                                                        <label><i class="bi bi-calendar-date"></i> <%#Eval("Fecha") %></label>
                                                    </div>
                                                    <div class="col-6">
                                                        <label><i class="bi bi-watch"></i> <%#Eval("Hora") %></label>
                                                    </div>
                                                </div>
                                                <div class="pb-2">
                                                    <label><i class="bi bi-watch"></i> Hora termino aprox: <%#Eval("tiempo") %></label>
                                                </div>
                                                <div class="pb-2">
                                                    <asp:DropDownList ID="ddlEmpleados" CssClass="form-select" runat="server"></asp:DropDownList>
                                                </div>
                                                <div class="row pb-2">
                                                    <div class="col-6">
                                                        <asp:Button ID="btnAcepta" CommandName="AceptarCita" CommandArgument='<%# Eval("IDCita")+"|"+Eval("Fecha")+"|"+Eval("Hora")+"|"+Eval("Nombre") %>' OnClientClick="return confirmaEliminar(this);" CssClass="btn btn-success w-100" runat="server" Text="​✓" />
                                                    </div>
                                                    <div class="col-6">
                                                         <asp:Button ID="btnRechaza" CssClass="btn btn-danger w-100" runat="server" CommandName="RechazarCita" CommandArgument='<%# Eval("IDCita")+"|"+Eval("Nombre") %>' OnClientClick="return confirmaEliminar1(this);" Text="X" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </itemtemplate>
                                </asp:Repeater>
                            </div>
                            <asp:Label ID="lblNoti" runat="server" CssClass="form-label"></asp:Label>
                        </contenttemplate>
                    </asp:UpdatePanel>
                </div>
        </div>
    </div>


    <!-- Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
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
                    <button type="button" class="btn btn-success" id="btnImprimir">Imprimir</button>
                </div>
            </div>
        </div>
    </div>
        <script src="https://cdn.jsdelivr.net/npm/interactjs/dist/interact.min.js"></script>
        <!-- Incluir jsPDF desde CDN -->

        <script>
            $("#btnImprimir").click(function () {
                // Obtener el título y el contenido del cuerpo del modal
                var modalBody = $("#exampleModal .modal-body").html();

                // Crear un contenedor para el contenido del modal que incluye el título
                var printableContent = "<div><h2>" + "RESUMEN FINAL DE CITA" + "</h2>" + modalBody + "</div>";

                // Crear una nueva ventana emergente para imprimir
                var printWindow = window.open('', '_blank');

                // Establecer el contenido de la ventana emergente con el contenido del modal
                printWindow.document.open();
                printWindow.document.write('<html><head><title>' + "RESUMEN FINAL DE CITA" + '</title></head><body>');
                printWindow.document.write(printableContent);
                printWindow.document.write('</body></html>');
                printWindow.document.close();

                // Imprimir y cerrar la ventana emergente después de que se complete la impresión
                printWindow.print();
                printWindow.onafterprint = function () {
                    printWindow.close();
                };

                // Restaurar el contenido original del body
                setTimeout(function () {
                    document.body.innerHTML = originalContents;
                }, 100);
            });

        </script>
        <script>
            const position = { x: 0, y: 0 }

            interact('.draggable').draggable({
                listeners: {
                    start(event) {
                        console.log(event.type, event.target)
                    },
                    move(event) {
                        position.x += event.dx
                        position.y += event.dy

                        event.target.style.transform =
                            `translate(${position.x}px, ${position.y}px)`
                    },
                }
            })

            //para ocultar y mostrar
            var swith = document.getElementById('swith');
            var citas = document.getElementById('contenedorCitas');
            var cotenedor = document.getElementById('conP');

            //agregar la clase oculta si se hace click a swith y quitarla si se vuelve a hacer click
            swith.addEventListener('click', function () {
                citas.classList.toggle('oculta');
                //cambiar de icono
                if (swith.classList.contains('bi-caret-up-fill')) {
                    swith.classList.remove('bi-caret-up-fill');
                    swith.classList.add('bi-caret-down-fill');
                } else {
                    swith.classList.remove('bi-caret-down-fill');
                    swith.classList.add('bi-caret-up-fill');
                }
                //cambiar el tamaño contenedor
                if (cotenedor.classList.contains('h-80d')) {
                    cotenedor.classList.remove('h-80d');
                } else {
                    cotenedor.classList.add('h-80d');
                }

            });
        </script>
    </form>
    

   

    <script src="../../assets/js/activarDarkmode.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>
    
</body>
</html>
