using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public static class EntradaBLL
    {
        public static List<DAL.Entrada> GetAllFromDisco(string mail)
        {
            return DAL.EntradaDAL.GetAllFromDisco(mail);
        }
    }
}
