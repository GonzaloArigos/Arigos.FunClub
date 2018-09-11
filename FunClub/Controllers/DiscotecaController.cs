using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Newtonsoft.Json;

namespace FunClub.Controllers
{
    public class DiscotecaController : Controller
    {
        public string GetDiscotecasUsuario()
        {
                        return JsonConvert.SerializeObject(DiscotecaBLL.GetDiscotecasUsuario(User.Identity.Name.ToString()), Formatting.None,
                         new JsonSerializerSettings()
                         {
                             ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                         });
        }
        // GET: Discoteca
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void NuevaDiscoteca(string nombre)
        {
            BLL.DiscotecaBLL.NuevaDiscoteca(nombre, User.Identity.Name);
        }

        [HttpPost]
        public void AsignarRol(string roleid,string email)
        {
            BLL.UsuarioBLL.AsignarRol(roleid, email);
        }

        [HttpPost]
        public void EliminarRol(string roleid, string email)
        {
            BLL.UsuarioBLL.EliminarRol(roleid, email);
        }

        [HttpPost]
        public void EditarDisco(string cod, string nombre,bool prod)
        {
            BLL.DiscotecaBLL.EditarDisco(cod, nombre, prod);
        }
    }
}