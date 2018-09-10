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
    }
}