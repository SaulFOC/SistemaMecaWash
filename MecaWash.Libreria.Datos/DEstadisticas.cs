using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaWash.Libreria.Datos
{
    public class DEstadisticas
    {
        public static DataTable ObtenerDatosGraficoEmpleados()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(Conexion.cn))
            {
                connection.Open();

                string query = "SELECT e.IDEmpleado, e.Nombre, COUNT(*) as Repeticiones " +
                               "FROM cita c " +
                               "INNER JOIN Empleados e ON c.IDEmpleado = e.IDEmpleado " +
                               "GROUP BY e.IDEmpleado, e.Nombre";

                SqlCommand cmd = new SqlCommand(query, connection);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            return dt;
        }
        public static DataTable ObtenerDatosGraficoServicio()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(Conexion.cn))
            {
                connection.Open();

                string query = "SELECT s.IDServicio, s.TipoServicio, s.DescripcionServicio, COUNT(*) as Repeticiones " +
                               "FROM detallecita d " +
                               "INNER JOIN Servicios s ON d.IDServicio = s.IDServicio " +
                               "GROUP BY s.IDServicio, s.TipoServicio, s.DescripcionServicio";

                SqlCommand cmd = new SqlCommand(query, connection);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            return dt;
        }
        public static DataTable ObtenerDatosGraficoDias()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(Conexion.cn))
            {
                connection.Open();

                string query = "SELECT DATENAME(WEEKDAY, Fecha) AS DiaSemana, COUNT(*) as Citas FROM cita GROUP BY DATENAME(WEEKDAY, Fecha)";
                SqlCommand cmd = new SqlCommand(query, connection);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            return dt;
        }

        public static DataTable ObtenerDatosGraficoMeses()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(Conexion.cn))
            {
                connection.Open();

                string query = "SELECT DATENAME(MONTH, Fecha) AS Mes, COUNT(*) as Citas FROM cita GROUP BY DATENAME(MONTH, Fecha)";
                SqlCommand cmd = new SqlCommand(query, connection);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            return dt;
        }
    }
}
