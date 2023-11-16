using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MecaWash.Libreria.Entidad;
using MecaWash.Libreria.Datos;
using System.Data;

namespace MecaWash.Libreria.Negocio
{
    public class NCliente
    {
        public DClientes datos = new DClientes();
        public DataTable LoguearCliente(ECliente obj)
        {
            return datos.LoguearCliente(obj);
        }
    }
}
