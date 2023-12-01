using MecaWash.Libreria.Entidad;
using MecaWash.Libreria.Negocio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MecaWash.Proyecto.Presentacion.Colaborador.Tecnico
{
    
    public partial class inicio : System.Web.UI.Page
    {
        NCita nC = new NCita();
        ECita eC = new ECita();
        NEmpleado nE = new NEmpleado();
        public static string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            string valoresSerializados = Request.Cookies["TecnicoCookie"].Value;

            // Deserializar los valores desde la cookie
            var valoresDeserializados = JsonConvert.DeserializeObject<dynamic>(valoresSerializados);
            string ide = valoresDeserializados.id;
            id = ide;
        }


        [WebMethod]
        public static string obtenerDatosCitasCalendar()
        {
            List<ECitaEven> eventos = ObtenerDatosCitasDesdeDB();

            return JsonConvert.SerializeObject(eventos);
        }

        public static List<ECitaEven> ObtenerDatosCitasDesdeDB()
        {
            // Aquí debes ejecutar tu consulta SQL y convertir los resultados a objetos Evento
            // Utiliza tu lógica de acceso a la base de datos preferida (Entity Framework, Dapper, etc.)

            int ide = int.Parse(id);
            NCita nC = new NCita();
            ECita eC2 = new ECita();
            eC2.IDEmpleado=ide;
            DataTable miDataTable = nC.ListarCitaAsignada(eC2);

            // Convierte el DataTable a una lista de objetos
            List<EDesdeBD> miLista = ConvertirDataTableALista<EDesdeBD>(miDataTable);

            // Ejemplo de resultados de la base de datos
            var resultadosDesdeDB = miLista;

            // Convierte los resultados a objetos Evento
            var eventos = new List<ECitaEven>();
            foreach (var resultado in resultadosDesdeDB)
            {
                eventos.Add(new ECitaEven
                {
                    Id = resultado.IDCita,
                    Title = resultado.Nombre,
                    Start = resultado.Fecha + "T" + resultado.Hora,
                    End = resultado.Fecha + "T" + resultado.Tiempo
                });
            }

            return eventos;
        }


        static List<T> ConvertirDataTableALista<T>(DataTable dataTable) where T : new()
        {
            // Creamos una lista para almacenar los objetos
            List<T> lista = new List<T>();

            // Iteramos a través de las filas del DataTable
            foreach (DataRow fila in dataTable.Rows)
            {
                // Creamos una instancia de la clase genérica
                T objeto = new T();

                // Iteramos a través de las columnas del DataTable
                foreach (DataColumn columna in dataTable.Columns)
                {
                    // Obtenemos el nombre de la propiedad
                    string nombrePropiedad = columna.ColumnName;

                    // Obtenemos el valor de la celda en la fila actual
                    object valorCelda = fila[columna];

                    // Asignamos el valor a la propiedad correspondiente en el objeto
                    typeof(T).GetProperty(nombrePropiedad)?.SetValue(objeto, valorCelda);
                }

                // Agregamos el objeto a la lista
                lista.Add(objeto);
            }

            return lista;
        }

        [WebMethod]
        public static string obtenerDetallesEvento(string eventId)
        {
            try
            {
                NCita nC = new NCita();
                ECita eC = new ECita();
                int id2 = int.Parse(eventId);
                eC.IDCita = id2;
                DataTable dt = nC.ListarDetalleCita(eC);
                List<EDetalleCita> miLista = ConvertirDataTableALista<EDetalleCita>(dt);

                return JsonConvert.SerializeObject(miLista);

            }
            catch (Exception ex)
            {
                // Manejar excepciones según tus necesidades
                return "Error al obtener detalles del evento: " + ex.Message;
            }
        }

    }
}