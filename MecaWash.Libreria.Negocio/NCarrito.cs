using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MecaWash.Libreria.Datos;
using MecaWash.Libreria.Entidad;

namespace MecaWash.Libreria.Negocio
{
    public class NCarrito
    {
        DCarrito datos = new DCarrito();
        public int AgregarCarrrito(ECarrito obj)
        {
            return datos.AgregarCarrrito(obj);
        }

    }
}
