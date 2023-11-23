using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MecaWash.Libreria.Entidad;

namespace MecaWash.Libreria.Datos
{
    public class DCita
    {
        public void agregarCita(ECita obj)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("insertarCitaDetalle", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@fecha", obj.Fecha);
                    cmd.Parameters.AddWithValue("@hora", obj.Hora);
                    cmd.Parameters.AddWithValue("@idc", obj.IDCliente);
                    cmd.Parameters.AddWithValue("@idv", obj.IDVehiculo);
                    cn.Open();

                    // Usa ExecuteNonQueryAsync en lugar de ExecuteNonQuery
                    cmd.ExecuteNonQuery();

                    cn.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public DataTable ListarCita()
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("listarCitaNueva", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }

        }
    }
}
