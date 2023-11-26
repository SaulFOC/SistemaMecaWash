using MecaWash.Libreria.Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaWash.Libreria.Datos
{
    public class DServicioPresencial
    {
        public DataTable listarCitaPresencial(ECita obj)
        {
                using (SqlConnection cn = new SqlConnection(Conexion.cn))
                {
                   DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("ListarCitaModal", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", obj.IDVehiculo);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    return dt;
                }  
        }

        public DataTable listarCita()
        {
            using(SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("ListarCita", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
        }

        public int InsertarServicioPresencial(ECita obj)
        {
            int resp = 0;
            try
            {
                
                using (SqlConnection cn = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("InsertarCitaModalVehiculo", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@fecha", obj.Fecha);
                    cmd.Parameters.AddWithValue("@hora", obj.Hora);
                    cmd.Parameters.AddWithValue("@IDCliente", obj.IDCliente);
                    cmd.Parameters.AddWithValue("@IDVehiculo", obj.IDVehiculo);
                    cmd.Parameters.AddWithValue("@IDEmpleado", obj.IDEmpleado);
                    cmd.Parameters.AddWithValue("@Estado", obj.Estado);
                    cn.Open();

                    cmd.ExecuteNonQuery();

                    cn.Close();
                   resp=1;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                resp=0;
            }
            return resp;
        }
    }
}
