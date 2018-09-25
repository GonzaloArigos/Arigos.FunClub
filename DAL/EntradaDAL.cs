using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class EntradaDAL
    {
        public static List<Entrada> GetAllFromDisco(string email)
        {
            try
            {
                using (FunClubEntities db = new FunClubEntities())
                {
                    var disco = db.Usuario_Discotecas.Include("Discoteca").Where(a => a.EmailUsuario == email && a.Discoteca.Productiva == true).FirstOrDefault().Discoteca;
                    return db.Entradas.Where(a => a.CodDiscoteca == disco.CodDiscoteca).ToList();
            }
            }
            catch
            {
                return null;
            }           
                    
        } 
    }
}
