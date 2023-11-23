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
    public class DVehiculo
    {
        public DataTable listarVehiculo()
        {
            using(SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("listarVehiculos", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
        }

        public int RegistrarVehiculo(EVehiculos obj)
        {
            int resp;
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("InsertarVehiculo", cn);
                    cmd.Parameters.AddWithValue("@NumeroPlaca", obj.NumeroPlaca);
                    cmd.Parameters.AddWithValue("@Marca", obj.Marca);
                    cmd.Parameters.AddWithValue("@Modelo", obj.Modelo);
                    cmd.Parameters.AddWithValue("@Anio", obj.Anio);
                    cmd.Parameters.AddWithValue("@Color", obj.Color);
                    cmd.Parameters.AddWithValue("@IDCliente", obj.IDCliente);
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
                Console.WriteLine(ex.Message);
            }
            return resp;
        }

        public bool EditarVehiculo(EVehiculos obj)
        {
            bool resp = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("EditarVehiculo", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDVehiculo", obj.IDVehiculo);
                    cmd.Parameters.AddWithValue("@NumeroPlaca", obj.NumeroPlaca);
                    cmd.Parameters.AddWithValue("@Marca", obj.Marca);
                    cmd.Parameters.AddWithValue("@Modelo", obj.Modelo);
                    cmd.Parameters.AddWithValue("@Anio", obj.Anio);
                    cmd.Parameters.AddWithValue("@Color", obj.Color);
                    cmd.Parameters.AddWithValue("@IDCliente", obj.IDCliente);
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

        public bool ElimnarVehiculo(int id)
        {
            bool resp = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("EliminarVehiculo", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDVehiculo", id);
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

        public DataTable BuscarVehiculo(EVehiculos obj)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("BuscarVehiculo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", obj.IDVehiculo);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
        }
        public DataTable BuscarVehiculoCliente(EVehiculos obj)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("buscarVehiculop", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idc", obj.IDCliente);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
        }
    }
}
