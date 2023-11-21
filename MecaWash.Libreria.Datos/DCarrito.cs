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
        public int AgregarCarrrito(ECarrito obj)
        {
            int resp;
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
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    resp = 1;
                }
            }
            catch (SqlException ex)
            {
                resp = 0;
                Console.WriteLine(ex.Message);
            }
            return resp;
        }
        
    }
}
