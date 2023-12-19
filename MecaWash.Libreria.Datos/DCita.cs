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
        public DataTable ListarCitaAceptada()
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("listarCitaAceptada", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }

        }

        public DataTable ListarDetalleCita(ECita obj)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("listarDetalleCita", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idc", obj.IDCita);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }

        }

        public void AceptarCita(ECita obj)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("aceptaCita", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idc", obj.IDCita);
                    cmd.Parameters.AddWithValue("@ide", obj.IDEmpleado);
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

        public DataTable ComprobarDisponibilidad(ECita obj)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("comprobarFecha", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ide", obj.IDEmpleado);
                cmd.Parameters.AddWithValue("@hora", obj.Hora);
                cmd.Parameters.AddWithValue("@fecha", obj.Fecha);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }

        }

        public void agregarCarritoColor(ECita obj)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("insertarCarritoColor", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idc", obj.IDCliente);
                    cmd.Parameters.AddWithValue("@ids", obj.IDServicio);
                    cmd.Parameters.AddWithValue("@color", obj.Color);
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

        public void insertarCitaColor(ECita obj)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("insertarPintado", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idcl", obj.IDCliente);
                    cmd.Parameters.AddWithValue("@idv", obj.IDVehiculo);
                    cmd.Parameters.AddWithValue("@fecha", obj.Fecha);
                    cmd.Parameters.AddWithValue("@hora", obj.Hora);
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

        public DataTable ListarCitaAsignada(ECita obj)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("listarCitaAsignada", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ide", obj.IDEmpleado);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }

        }

        public DataTable ReporteFechas(string fechI, string fechaF)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("reporteCitasFechas", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fechaI", fechI);
                cmd.Parameters.AddWithValue("@fechaF", fechaF);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }

        }

        public void RechazarCita(ECita obj)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                SqlCommand cmd = new SqlCommand("rechazarCita", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idc", obj.IDCita);
                cn.Open();

                // Usa ExecuteNonQueryAsync en lugar de ExecuteNonQuery
                cmd.ExecuteNonQuery();

                cn.Close();
            }

        }

        public DataTable ObtenerCorreo(ECita obj)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("obtenerCorreo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idc", obj.IDCita);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }

        }
    }
}
