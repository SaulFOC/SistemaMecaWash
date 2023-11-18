using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MecaWash.Libreria.Entidad;

namespace MecaWash.Libreria.Datos
{
    public class DClientes
    {
        public DataTable LoguearCliente(ECliente obj)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("loginCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@correo", obj.CorreoElectronico);
                cmd.Parameters.AddWithValue("@clave", obj.clave);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable ListarClientes()
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("listarClientes", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
        }

        //forma de insertar que estoy tratando de implementar si se complica usar la segunda
        public int RegistrarCliente69(ECliente obj, out string Mensaje)
        {
            int resp=0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("InsertarCliente69", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DNI", obj.Dni);
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Direccion", obj.Direccion);
                    cmd.Parameters.AddWithValue("@Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("@CorreoElectronico", obj.CorreoElectronico);
                    cmd.Parameters.AddWithValue("@Estado", obj.Estado);
                    cmd.Parameters.AddWithValue("@Clave", obj.clave);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cn.Open();
                    cmd.ExecuteNonQuery();

                    resp = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = Convert.ToString(cmd.Parameters["Mensaje"].Value);
                    cn.Close();
                    resp = 1;
                }
            }
            catch(SqlException ex)
            {
                resp = 0;
                Mensaje = ex.Message;
            }
            return resp;
        }

        public int RegistrarCliente(ECliente obj)
        {
            int resp = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("InsertarCliente", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DNI", obj.Dni);
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Direccion", obj.Direccion);
                    cmd.Parameters.AddWithValue("@Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("@CorreoElectronico", obj.CorreoElectronico);
                    cmd.Parameters.AddWithValue("@Estado", obj.Estado);   
                    cmd.Parameters.AddWithValue("@Clave", obj.clave);
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



        public bool EditarCliente(ECliente obj)
        {
            bool resp = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("EditarCliente", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDCliente", obj.IDCliente);
                    cmd.Parameters.AddWithValue("@DNI", obj.Dni);
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Direccion", obj.Direccion);
                    cmd.Parameters.AddWithValue("@Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("@CorreoElectronico", obj.CorreoElectronico);
                    cmd.Parameters.AddWithValue("@Clave", obj.clave);
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

        public bool EliminarCliente(int id)
        {
            bool resp = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("EliminarCliente", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDCliente", id);
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


        public DataTable BuscarCliente(ECliente obj)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("buscarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", obj.IDCliente);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
        }
    }
}
