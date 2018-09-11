using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class DiscotecaDAL
    {
        public static List<Discoteca> GetDiscotecasUsuario(string userid)
        {
            using (FunClubEntities db = new FunClubEntities())
            {
                var usuario_discotecas = db.Usuario_Discotecas.Where(a => a.EmailUsuario == userid).ToList();
                var discotecas = db.Discotecas
                    .Include("Usuario_Discotecas")
                    .Include("Usuario_Discotecas.AspNetUser")
                    .Include("Usuario_Discotecas.AspNetUser.AspNetRoles")
                    .Where(a =>a.Usuario_Discotecas.Where(i => i.EmailUsuario == userid).Any());
                return discotecas.ToList();
            }
        }
    }
}
