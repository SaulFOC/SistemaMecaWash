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
    public class DInventario
    {
        public DataTable ListarInventario()
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("listarInventario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
        }
        
        public DataTable BuscarInventario(EInventario obj)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("BuscarInventario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", obj.IDInventario);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
        }

        public int RegistrarInventario(EInventario obj)
        {
            int resp;
            string error = "";
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("InsertarInventario", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NombreProducto", obj.NombreProducto);
                    cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("@CantidadInventario", obj.Cantidad);
                    cmd.Parameters.AddWithValue("@PrecioPorUnidad", obj.PrecioProducto);
                    cmd.Parameters.AddWithValue("@Estado", obj.Estado);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    resp = 1;
                }
            }
            catch (SqlException ex)
            {
                resp = 0;
                error = ex.Message;
            }
            return resp;


        }

        public bool ActualizarInventario(EInventario obj)
        {
            string error = "";
            bool resp = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("EditarInventario", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDProducto", obj.IDInventario);
                    cmd.Parameters.AddWithValue("@NombreProducto", obj.NombreProducto);
                    cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("@CantidadInventario", obj.Cantidad);
                    cmd.Parameters.AddWithValue("@PrecioPorUnidad", obj.PrecioProducto);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    resp = true;
                }
            }
            catch (SqlException ex)
            {
                resp = false;
                error = ex.Message;
            }
            return resp;
        }

        public bool EliminarInventario(int id)
        {
            string error = "";
            bool resp = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("EliminarInventario", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDProducto", id);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    resp = true;
                }
            }
            catch (SqlException ex)
            {
                resp = false;
                error = ex.Message;
            }
            return resp;
        }

        public int AgregarInventario(EInventario obj)
        {
            int resp=1;
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("addInventario", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", obj.IDInventario);
                    cmd.Parameters.AddWithValue("@CantidadAgregar", obj.Cantidad);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    resp = 1;
                }
            }
            catch
            {
                resp = 0;
            }
            return resp;
        }
    }
}
