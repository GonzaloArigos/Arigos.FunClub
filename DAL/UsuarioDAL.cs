using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class UsuarioDAL
    {
        public static void AsignarRol(string roleid, string mail)
        {
            using (FunClubEntities db = new FunClubEntities())
            {
                var rol = db.AspNetRoles.Where(a => a.Id == roleid).FirstOrDefault();
                var usuario = db.AspNetUsers.Where(a => a.Email == mail).FirstOrDefault();
                usuario.AspNetRoles.Add(rol);
                //db.AspNetUsers.Add(usuario);                

                var entry2 = db.Entry(usuario); // Gets the entry for entity inside context
                entry2.State = EntityState.Modified; // Tell EF this entity has been modified

                db.SaveChanges();
               

            }
        }

        public static void EliminarRol(string roleid, string email)
        {
            using (FunClubEntities db = new FunClubEntities())
            {
               
                var usuario = db.AspNetUsers.Include("AspNetRoles").Where(a => a.Email == email).FirstOrDefault();
                var rol = usuario.AspNetRoles.Where(a => a.Id == roleid).FirstOrDefault();

                usuario.AspNetRoles.Remove(rol);
                //db.AspNetUsers.Add(usuario);                

                var entry2 = db.Entry(usuario); // Gets the entry for entity inside context
                entry2.State = EntityState.Modified; // Tell EF this entity has been modified

                db.SaveChanges();


            }
        }
    }
}