using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FunClub.Controllers
{
    public class VentaEntradaController : Controller
    {
        // GET: VentaEntrada
        public ActionResult Index()
        {
            return View();
        }

        public string GetAllEntradas()
        {
          
            return JsonConvert.SerializeObject(BLL.EntradaBLL.GetAllFromDisco(User.Identity.Name), Formatting.None,
             new JsonSerializerSettings()
             {
                 ReferenceLoopHandling = ReferenceLoopHandling.Ignore
             });

        }

    }
}