using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class CargaMasivaDAL
    {
        public static void CargaMasivaEntrada(Entrada entradas)
        {
            using (FunClubEntities db = new FunClubEntities())
            {
                int codigo = 0;
                int codprecio = 0;
                int? ultimaEntrada = db.Entradas.Where(a => a.CodDiscoteca == entradas.CodDiscoteca).Max(a => (int?)a.CodEntrada);
                int? ultimoPrecio = db.PrecioEntradas.Where(a => a.CodEntrada == entradas.CodEntrada && a.CodDiscoteca == entradas.CodDiscoteca).Max(a => (int?)a.Precio);

                codprecio = ultimoPrecio != null ? (int)ultimoPrecio + 1 : 1;
                codigo = ultimaEntrada != null ? (int)ultimaEntrada + 1 : 1;

                entradas.FechaRegistro = DateTime.Now;
            
                entradas.CodEntrada = codigo;
               // entradas.PrecioEntradas.ToList()[0].Precio = codprecio;
                entradas.PrecioEntradas.ToList()[0].CodEntrada = codigo;
                db.Entradas.Add(entradas);
                db.SaveChanges();
            }
        }

        public static void CargaMasivaEntrada(List<Entrada> entradas)
        {
            using (FunClubEntities db = new FunClubEntities())
            {
                db.Entradas.AddRange(entradas);
                db.SaveChanges();
            }
        }

        public static Entrada GetEntradaPorConsumicion(int codDisco, int codCons)
        {
            using (FunClubEntities db = new FunClubEntities())
            {
                return db.Entradas.Where(a => a.CodDiscoteca == codDisco && a.CodConsumicion == codCons).FirstOrDefault();
            }
        }
    }
}
