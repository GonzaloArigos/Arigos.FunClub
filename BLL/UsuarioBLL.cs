using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public static class UsuarioBLL
    {
        public static void AsignarRol(string roleid,string email)
        {
            DAL.UsuarioDAL.AsignarRol(roleid,email);
        }

        public static void EliminarRol(string roleid, string email)
        {
            DAL.UsuarioDAL.EliminarRol(roleid, email);
        }
    }
}
