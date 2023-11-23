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
    public class NCita
    {
        DCita datos = new DCita();
        public void agregarCita(ECita obj)
        {
            datos.agregarCita(obj);
        }

    }
}
