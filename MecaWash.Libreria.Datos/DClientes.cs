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
    }
}
