using System;
using System.Linq;

namespace DAL
{
    public static class PrecioEntradaDAL
    {
        public static PrecioEntrada GetUltimoPrecio(Entrada x)
        {
            using (FunClubEntities db = new FunClubEntities())
            {
                //var prueba = db.PrecioEntradas.ToList();
                var precios = db.PrecioEntradas.Where(a => a.CodEntrada == x.CodEntrada && a.CodDiscoteca == x.CodDiscoteca && a.FechaInicio <= DateTime.Now && a.FechaFin >= DateTime.Now).FirstOrDefault();
                return precios;
            }
        }
     }
}