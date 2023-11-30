using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MecaWash.Libreria.Negocio;
using MecaWash.Libreria.Entidad;
using System.Data;
using System.Web.Services;
using Newtonsoft.Json;

namespace MecaWash.Proyecto.Presentacion.Colaborador.Administrador
{
    public partial class citas : System.Web.UI.Page
    {
        NCita nC = new NCita();
        ECita eC = new ECita();
        NEmpleado nE = new NEmpleado();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                LlenarCitasNuevas();
            }
            
        }


        protected void LlenarCitasNuevas()
        {
            
            DataTable dt = nC.ListarCita();
            if (dt.Rows.Count > 0)
            {
                Repeater1.DataSource = "";
                Repeater1.DataBind();
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
            else
            {
                Repeater1.Visible = false;
                lblNoti.Text = "Aun no se agendan citas...";
            }
            
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

            NCita nC = new NCita();
            DataTable miDataTable = nC.ListarCitaAceptada();

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
                int id = int.Parse(eventId);
                eC.IDCita = id;
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

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DropDownList ddlOpciones = (DropDownList)e.Item.FindControl("ddlEmpleados");
                ddlOpciones.Items.Clear();
                ddlOpciones.Items.Insert(0, new ListItem("Elige Empleado", "0"));
                ddlOpciones.DataSource = nE.ListarEmpleados();
                
                ddlOpciones.DataTextField = "Nombre";
                ddlOpciones.DataValueField = "IDEmpleado";
                ddlOpciones.DataBind();

                // Puedes agregar un elemento predeterminado si es necesario

            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "AceptarCita")
                {
                    string[] argumentos = e.CommandArgument.ToString().Split('|');
                    string id = argumentos[0];
                    string fecha = argumentos[1];
                    string hora = argumentos[2];
                    int idc = int.Parse(id);
                    DropDownList ddlEmpleados = (DropDownList)e.Item.FindControl("ddlEmpleados");
                    int ide = int.Parse(ddlEmpleados.SelectedValue);


                    //para comprobar
                    eC.Fecha = fecha;
                    eC.Hora = hora;

                    eC.IDEmpleado = ide;
                    eC.IDCita = idc;

                    DataTable dt3 = nC.ComprobarDisponibilidad(eC);
                        if (dt3.Rows.Count == 0)
                        {
                            nC.AceptarCita(eC);

                            LlenarCitasNuevas();
                            ScriptManager.RegisterStartupScript(this, GetType(), "insertAlert", "mostrarCalendario();", true);
                            ScriptManager.RegisterStartupScript(this, GetType(), "insertAlert", "notiExito('Cita aceptada','La cita se agrego con exito!');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "insertAlert", "notiError('No hay personal disponible para la fecha!');", true);
                        }
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "insertAlert", "notiError('Ah ocurrido un grave!');", true);
            }
        }
    }
}