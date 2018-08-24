using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class EntradaDAL
    {

        public static void CargaMasivaEntrada(List<Entrada> entradas)
        {
            using (FunClubEntities db = new FunClubEntities())
            {
                db.Entradas.AddRange(entradas);
                db.SaveChanges();
            }
        }

        public static Entrada GetOne(int cod)
        {
            using (FunClubEntities db = new FunClubEntities())
            {
                return db.Entradas.Where(a => a.CodEntrada == cod).FirstOrDefault();
            }
        }
    }
}
