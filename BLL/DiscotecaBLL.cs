using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;  

namespace BLL
{
    public static class DiscotecaBLL
    {
        public static List<Discoteca> GetDiscotecasUsuario(string userid)
        {
            return DAL.DiscotecaDAL.GetDiscotecasUsuario(userid);
        }

        public static void NuevaDiscoteca(string nombre,string usuario)
        {
            DAL.DiscotecaDAL.NuevaDiscoteca(nombre, usuario);
        }

        public static void EditarDisco(string cod, string nombre, bool prod)
        {
            DAL.DiscotecaDAL.EditarDisco(cod, nombre, prod);
        }
    }
}
