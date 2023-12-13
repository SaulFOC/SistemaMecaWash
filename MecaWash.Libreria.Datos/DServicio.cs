﻿using MecaWash.Libreria.Entidad;
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

        public List<EServicios> ListarServicio2()
        {
            List<EServicios> servicios = new List<EServicios>();

            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand("SP_LISTAR_SERVICIO", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EServicios servicio = new EServicios
                            {
                                IDServicio = Convert.ToInt32(reader["Id"]),
                                TipoServicio = Convert.ToString(reader["TipoServicio"]),
                                Descripcion= Convert.ToString(reader["DescripcionServicio"]),
                                PrecioServicio= Convert.ToDouble(reader["PrecioServicio"]),

                            };

                            servicios.Add(servicio);
                        }
                    }
                }
            }

            return servicios;
        }

        public int RegistrarServicio(EServicios obj)
        {
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
                resp = 1;
            }
            catch
            {
                resp = 0;

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
        public DataTable BuscarPrecioServicio(int id)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("BuscarPrecioServicio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
        }

    }
}
