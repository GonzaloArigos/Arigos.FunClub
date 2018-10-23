using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class ConsumicionDAL
    {
        public static List<Consumicion> GetAllFromDisco(Discoteca disco)
        {
            using (FunClubEntities db = new FunClubEntities())
            {
                return db.Consumicions
                    .Include("PrecioConsumicions")
                    .Include("Consumicion_Bebida")
                    .Include("Consumicion_Bebida.Producto")
                    .Where(a => a.CodDiscoteca == disco.CodDiscoteca).ToList();
            }

        }

        public static void NuevaConsumicion(Consumicion consumicion)
        {
            using (FunClubEntities db = new FunClubEntities())
            {
                consumicion.CodConsumicion = db.Consumicions.Where(a => a.CodDiscoteca == consumicion.CodDiscoteca).Any() ? db.Consumicions.Where(a => a.CodDiscoteca == consumicion.CodDiscoteca).Max(a => a.CodConsumicion) + 1 : 1;
                db.Consumicions.Add(consumicion);
                db.SaveChanges();
            }
        }
    }
}
