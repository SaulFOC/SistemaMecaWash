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
    public class DServicio
    {
        public DataTable ListarServicio()
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("SP_LISTAR_SERVICIO", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
        }

        public int RegistrarServicio(EServicios obj)
        {
            string error = "";
            int resp;
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("InsertarServicios", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TipoServicio", obj.TipoServicio);
                    cmd.Parameters.AddWithValue("@DescripcionServicio", obj.Descripcion);
                    cmd.Parameters.AddWithValue("@PrecioServicio", obj.PrecioServicio);
                    cmd.Parameters.AddWithValue("@Estado", obj.Estado);
                    cn.Open();
                    resp = cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                resp = 0;
                error = ex.Message;

            }
            return resp;
        }

        public bool EditarServicio(EServicios obj)
        {
            string error = "";
            bool resp = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("EditarServicios", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDServicio", obj.IDServicio);
                    cmd.Parameters.AddWithValue("@TipoServicio", obj.TipoServicio);
                    cmd.Parameters.AddWithValue("@DescripcionServicio", obj.Descripcion);
                    cmd.Parameters.AddWithValue("@PrecioServicio", obj.PrecioServicio);
                   
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

        public bool EliminarServicio(int id)
        {
            bool resp = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("EliminarServicios", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDServicio", id);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    resp = true;
                }
            }
            catch (SqlException ex)
            {
                resp = false;
                Console.WriteLine(ex.Message);
            }
            return resp;
        }

        public DataTable BuscarServicio(EServicios obj)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("BuscarServicio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", obj.IDServicio);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
        }
    }
}
