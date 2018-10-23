using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FunClub.Controllers
{
    public class ConsumicionController : Controller
    {
        // GET: Consumicion
        public ActionResult Index()
        {
            return View();
        }

        public string GetAllFromDisco()
        {

            return JsonConvert.SerializeObject(BLL.ConsumicionBLL.GetAllFromDisco(User.Identity.Name), Formatting.None,
             new JsonSerializerSettings()
             {
                 ReferenceLoopHandling = ReferenceLoopHandling.Ignore
             });

        }

        [HttpPost]
        public void NuevaConsumicion(object consumicion)
        {
            DAL.Consumicion Consumicion = Newtonsoft.Json.JsonConvert.DeserializeObject<DAL.Consumicion>(consumicion.ToString());
            BLL.ConsumicionBLL.NuevaConsumicion(Consumicion, User.Identity.Name);
        }

        [HttpPost]
        public void EditarConsumicion(object consumicion)
        {
            DAL.Consumicion Consumicion = Newtonsoft.Json.JsonConvert.DeserializeObject<DAL.Consumicion>(consumicion.ToString());
            BLL.ConsumicionBLL.EditarConsumicion(Consumicion, User.Identity.Name);
        }
    }
}