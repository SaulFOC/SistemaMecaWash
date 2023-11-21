using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MecaWash.Libreria.Entidad;

namespace MecaWash.Libreria.Negocio
{
    public class CarritoServicio
    {
        public int Idc { get; set; }
        public int Ids { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
        public string Nombre { get; set; }
        public CarritoServicio(int idc, int ids, decimal precio, string img, string nom)
        {
            Idc = idc;
            Ids = ids;
            Precio = precio;
            Imagen = img;
            Nombre = nom;
        }
}
}
