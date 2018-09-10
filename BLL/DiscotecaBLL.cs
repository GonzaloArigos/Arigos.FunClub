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
    }
}
