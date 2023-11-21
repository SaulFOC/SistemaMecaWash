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
        public async Task AgregarCarrritoAsync(ECarrito obj)
        {
            await Task.Run(() => datos.AgregarCarrritoAsync(obj));
        }

        public async Task EliminarCarrito(ECarrito obj)
        {
            await Task.Run(() => datos.EliminarCarrito(obj));
        }

        public DataTable listarCarrito(ECarrito obj)
        {
            return datos.listarCarrito(obj);
        }

    }
}
