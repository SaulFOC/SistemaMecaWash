<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="grafico.aspx.cs" Inherits="MecaWash.Proyecto.Presentacion.Colaborador.Administrador.grafico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gráficos</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="../../Content/bootstrap.min.css">
    <link rel="stylesheet" href="../../assets/css/cabecera.css">
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript" src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
    <style>
        .h-mitad{
            height:50vh;
        }
    </style>
    <script type="text/javascript">
        google.charts.load('current', { packages: ['corechart'] });
        google.charts.setOnLoadCallback(drawCharts);

        function drawCharts() {
            obtenerDatosYDibujarGraficos();
        }

        function obtenerDatosYDibujarGraficos() {

            obtenerDatosGraficoDias();
            obtenerDatosGraficoMeses();
            obtenerDatosGraficoEmpleados();
            obtenerDatosGraficoServicio();
        }

        function obtenerDatosGraficoDias() {
            $.ajax({
                type: "POST",
                url: "Grafico.aspx/ObtenerDatosGraficoDias",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {

                    var data = JSON.parse(result.d);


                    if (Array.isArray(data)) {
               
                        var dataTable = new google.visualization.DataTable();
                        dataTable.addColumn('string', 'Día de la Semana');
                        dataTable.addColumn('number', 'Citas');

                        for (var i = 0; i < data.length; i++) {
                            var item = data[i];
                            dataTable.addRow([item.DiaSemana, item.Citas]);
                        }

                        var options = {
                            title: 'Gráfico de Barras - Citas por Día de la Semana',
                        };

                        var chart = new google.visualization.BarChart(document.getElementById('chartDias'));
                        chart.draw(dataTable, options);
                    } else {
                        console.error("La respuesta no es válida:", data);
                    }
                },
                error: function (error) {
                    console.error("Error al obtener datos de gráfico de días", error);
                }
            });
        }

        function obtenerDatosGraficoMeses() {
            $.ajax({
                type: "POST",
                url: "Grafico.aspx/ObtenerDatosGraficoMeses",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    var data = JSON.parse(result.d);


                    if (Array.isArray(data)) {
                        var dataTable = new google.visualization.DataTable();
                        dataTable.addColumn('string', 'Mes');
                        dataTable.addColumn('number', 'Citas');

                        for (var i = 0; i < data.length; i++) {
                            var item = data[i];
                            dataTable.addRow([item.Mes, item.Citas]);
                        }

                        var options = {
                            title: 'Gráfico de Líneas - Citas por Mes del Año'
                        };

                        var chart = new google.visualization.LineChart(document.getElementById('chartMeses'));
                        chart.draw(dataTable, options);
                    } else {
                        console.error("La respuesta no es válida:", data);
                    }
                },
                error: function (error) {
                    console.error("Error al obtener datos de gráfico de meses", error);
                }
            });
        }

        function obtenerDatosGraficoEmpleados() {
            $.ajax({
                type: "POST",
                url: "Grafico.aspx/ObtenerDatosGraficoEmpleados",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    var data = JSON.parse(result.d);

                    if (Array.isArray(data)) {
                        var dataTable = new google.visualization.DataTable();
                        dataTable.addColumn('string', 'Empleado');
                        dataTable.addColumn('number', 'Repeticiones');

                        for (var i = 0; i < data.length; i++) {
                            var item = data[i];
                            dataTable.addRow([item.Nombre, item.Repeticiones]);
                        }

                        var options = {
                            title: 'Gráfico de Pastel - Citas por Empleado'
                        };

                        var chart = new google.visualization.PieChart(document.getElementById('chartEmpleados'));
                        chart.draw(dataTable, options);
                    } else {
                        console.error("La respuesta no es válida:", data);
                    }
                },
                error: function (error) {
                    console.error("Error al obtener datos de gráfico de empleados", error);
                }
            });
        }

        function obtenerDatosGraficoServicio() {
            $.ajax({
                type: "POST",
                url: "Grafico.aspx/ObtenerDatosGraficoServicio",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    var data = JSON.parse(result.d);

                    if (Array.isArray(data)) {
                        var dataTable = new google.visualization.DataTable();
                        dataTable.addColumn('string', 'Tipo de Servicio');
                        dataTable.addColumn('number', 'Repeticiones');

                        for (var i = 0; i < data.length; i++) {
                            var item = data[i];
                            dataTable.addRow([item.TipoServicio, item.Repeticiones]);
                        }

                        var options = {
                            title: 'Gráfico de Pastel - Citas por Servicio',
                            colors: ['purple', 'orange', 'pink', 'brown'] 
                        };

                        var chart = new google.visualization.PieChart(document.getElementById('chartServicios'));
                        chart.draw(dataTable, options);
                    } else {
                        console.error("La respuesta no es válida:", data);
                    }
                },
                error: function (error) {
                    console.error("Error al obtener datos de gráfico de servicios", error);
                }
            });
        
        }

    </script>
</head>
<body>
    <div class="container pt-3 pb-3">
        <div class="row">
            <div class="col-sm-12 col-md-6 col-lg-6 col-xl-6 mb-3">
                <div class="container">
                    <div id="chartDias" class="h-mitad"></div>
                </div>     
            </div>
            <div class="col-sm-12 col-md-6 col-lg-6 col-xl-6 mb-3">
                <div class="container">
                    <div id="chartMeses" class="h-mitad"></div>
                </div>  
            </div>
            <div class="col-sm-12 col-md-6 col-lg-6 col-xl-6 mb-3">
                <div class="container">
                    <div id="chartEmpleados" class="h-mitad"></div>
                </div>
            </div>
            <div class="col-sm-12 col-md-6 col-lg-6 col-xl-6 mb-3">
                <div class="container">
                    <div id="chartServicios" class="h-mitad"></div>
                </div>
            </div>
        </div>
    </div>
    
    
    
    
</body>
</html>

