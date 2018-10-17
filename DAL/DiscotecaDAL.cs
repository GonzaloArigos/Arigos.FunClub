using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class DiscotecaDAL
    {
        public static void NuevaDiscoteca(string nombre, string usuario)
        {
            using (FunClubEntities db = new FunClubEntities())
            {
                int? maxid = db.Discotecas.Max(a => (int?)a.CodDiscoteca);

                int codigo = maxid != null ? (int)maxid + 1 : 1;

                var disconuevo = new Discoteca();

                disconuevo.UsuarioAlta = usuario;
                disconuevo.FechaAlta = DateTime.Now;

                disconuevo.CodDiscoteca = codigo;
                disconuevo.Descripcion = nombre;
                disconuevo.Usuario_Discotecas = new List<Usuario_Discotecas>();
                disconuevo.Usuario_Discotecas.Add(new Usuario_Discotecas()
                {
                    CodDiscoteca = codigo,
                    EmailUsuario = usuario
                });

                db.Discotecas.Add(disconuevo);
                db.SaveChanges();
            }

        }

        public static void EditarDisco(string cod, string nombre, bool prod)
        {
            using (FunClubEntities db = new FunClubEntities())
            {
                int codDisco = Convert.ToInt32(cod);
                var disco = db.Discotecas.Where(a=> a.CodDiscoteca == codDisco).FirstOrDefault();
                disco.Descripcion = nombre;
                disco.Productiva = prod;

                disco.FechaMod = DateTime.Now;
                disco.UsuarioMod = "Administrador";

                var entry2 = db.Entry(disco); // Gets the entry for entity inside context
                entry2.State = System.Data.Entity.EntityState.Modified; // Tell EF this entity has been modified

                db.SaveChanges();

            }
        }

        public static List<Discoteca> GetDiscotecasUsuario(string userid)
        {
            using (FunClubEntities db = new FunClubEntities())
            {
                var usuario_discotecas = db.Usuario_Discotecas.Where(a => a.EmailUsuario == userid).ToList();
                var discotecas = db.Discotecas
                    .Include("Usuario_Discotecas")
                    .Include("Usuario_Discotecas.AspNetUser")
                    .Include("Usuario_Discotecas.AspNetUser.AspNetRoles")
                    .Where(a => a.Usuario_Discotecas.Where(i => i.EmailUsuario == userid).Any());
                return discotecas.ToList();
            }
        }
    }
}
