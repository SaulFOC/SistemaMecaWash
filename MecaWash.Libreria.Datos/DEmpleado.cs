using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MecaWash.Libreria.Entidad;
using System.Data;

namespace MecaWash.Libreria.Datos
{
    public class DEmpleado
    {
        
        public DataTable ListarEmpleado()
        {
            using(SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("SP_LISTAR_EMPLEADO", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
          
        }

        public DataTable ListarEmpleadosCompleto()
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("SP_LISTAR_EMPLEADO_COMPLETO", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
        }

        //metodo para registrar al empleado
        public int RegistrarEmpleado(EEmpleado obj)
        {
            int resp;
            try
            {
                using(SqlConnection cn = new SqlConnection(Conexion.cn)) {
                    SqlCommand cmd = new SqlCommand("InsertarEmpleado", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DNI", obj.Dni);
                    cmd.Parameters.AddWithValue("@Contrasena", obj.Contrasena);
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("@CorreoElectronico", obj.CorreoElectronico);
                    cmd.Parameters.AddWithValue("@Puesto", obj.Puesto);
                    cmd.Parameters.AddWithValue("@Estado", obj.Estado);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    resp = 1;
                }
            }
            catch(SqlException ex)
            {
                resp = 0;
                Console.WriteLine(ex.Message);
            }
            return resp;
        }

        public bool EditarEmpleado(EEmpleado obj) {             
            bool resp = false;
            try
            {
                using(SqlConnection cn = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("EditarEmpleado", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDEmpleado", obj.IDEmpleado);
                    cmd.Parameters.AddWithValue("@DNI", obj.Dni);
                    cmd.Parameters.AddWithValue("@Contrasena", obj.Contrasena);
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("@CorreoElectronico", obj.CorreoElectronico);
                    cmd.Parameters.AddWithValue("@Puesto", obj.Puesto);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    resp = true;
                }
            }
                       catch(SqlException ex)
            {
                resp = false;
                Console.WriteLine(ex.Message);
            }
            return resp;
        }


        public bool EliminarEmpleado(int id)
        {
            bool resp = false;
            try
            {
                using(SqlConnection cn = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("EliminarEmpleado", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDEmpleado", id);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    resp = true;
                }
            }
            catch(SqlException ex)
            {
                resp = false;
                Console.WriteLine(ex.Message);
            }
            return resp;
        }

        public DataTable BuscarEmpleado(EEmpleado obj)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("BuscarEmpleado", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", obj.IDEmpleado);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
        }

        //metodo para verificar usuario por correo
        public DataTable VerificarUsuario(EEmpleado obj)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("IngresarUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Correo", obj.CorreoElectronico);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
        }


    }
}
