using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class PuntosDAL
    {
        public static List<ClienteFichada> ObtenerFichadasHoy(Discoteca disco)
        {
            using (FunClubEntities db = new FunClubEntities())
            {
                var ayer = DateTime.Now.AddHours(-6);   
                return db.ClienteFichadas.Where(a => a.CodDisco == disco.CodDiscoteca && (a.FechaHoraEntrada <= DateTime.Now && a.FechaHoraEntrada >= ayer)).ToList();
            }
        }
    }
}
