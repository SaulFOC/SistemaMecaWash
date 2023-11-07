using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace MecaWash.Libreria.Negocio
{
    public class NEncriptacion
    {

        public static string Encriptar(string texto)
        {
            StringBuilder sb = new StringBuilder();

            using(SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach(Byte b in result)
                {
                    sb.Append(b.ToString("x2"));
                }
            }
            return sb.ToString();
        }
    }
}
