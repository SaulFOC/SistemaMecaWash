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
    public class DCarrito
    {
        public async Task AgregarCarrritoAsync(ECarrito obj)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("InsertarCarrito", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idc", obj.IDCliente);
                    cmd.Parameters.AddWithValue("@ids", obj.IDServicio);
                    cmd.Parameters.AddWithValue("@precio", obj.precio);
                    cn.Open();

                    // Usa ExecuteNonQueryAsync en lugar de ExecuteNonQuery
                    await cmd.ExecuteNonQueryAsync();

                    cn.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task EliminarCarrito(ECarrito obj)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("EliminarCarrito", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idc", obj.IDCliente);
                    cmd.Parameters.AddWithValue("@ids", obj.IDServicio);
                    cn.Open();

                    // Usa ExecuteNonQueryAsync en lugar de ExecuteNonQuery
                    await cmd.ExecuteNonQueryAsync();

                    cn.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public DataTable listarCarrito(ECarrito obj)
        {
                using (SqlConnection cn = new SqlConnection(Conexion.cn))
                {
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("listarCarrito", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idc", obj.IDCliente);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    return dt;
                }
        }

    }
}
