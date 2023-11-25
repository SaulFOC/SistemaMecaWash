<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="citas.aspx.cs" Inherits="MecaWash.Proyecto.Presentacion.Colaborador.Administrador.citas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title></title>
    <link rel="stylesheet" href="../../Content/bootstrap.min.css">
    <link rel="stylesheet" href="../../assets/css/cabecera.css">
    <script type="text/javascript" src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
    <script src='../../fullcalendar/dist/index.global.js'></script>
    <script>
        document.addEventListener('DOMContentLoaded', function () {
            
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
                    console.log(datos);
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
                        eventClick: function () {
                            $('#exampleModal').modal('show');
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
        });

    </script>
    <style>
        body {
    margin: 40px 10px;
    padding: 0;
    font-family: Arial, Helvetica Neue, Helvetica, sans-serif;
    font-size: 14px;
  }
        #calendar {
            max-width: 1100px;
            margin: 0 auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id='calendar'></div>
    </form>

    <!-- Modal -->
<div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-dialog-centered">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        ...
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button>
      </div>
    </div>
  </div>
</div>
    
    <script src="../../assets/js/activarDarkmode.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>
</body>
</html>
