using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public static class EntradaBLL
    {
        public static List<DAL.Entrada> GetAllFromDisco(string mail)
        {
            var retorno = DAL.EntradaDAL.GetAllFromDisco(mail);

            ObtenerUltimoPrecio(retorno);

            return retorno;
        }

        private static void ObtenerUltimoPrecio(List<DAL.Entrada> retorno)
        {
            if(retorno != null) { 
            foreach (var x in retorno)
            {
                var ultimo_precio = DAL.PrecioEntradaDAL.GetUltimoPrecio(x);
                x.PrecioEntradas = new List<DAL.PrecioEntrada>();
                x.PrecioEntradas.Add(ultimo_precio);
            }
            }
        }
    }
}
