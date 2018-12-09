using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class PrecioConsumicionDAL
    {
        public static PrecioConsumicion GetUltimoPrecio(Consumicion x)
        {
            using (FunClubEntities db = new FunClubEntities())
            {
                //var prueba = db.PrecioEntradas.ToList();
                var precios = db.PrecioConsumicions.Where(a => a.CodConsumicion == x.CodConsumicion && a.CodDiscoteca == x.CodDiscoteca && a.FechaVigencia <= DateTime.Now && a.FechaFin >= DateTime.Now).FirstOrDefault();
                return precios;
            }
        }
    }
}
