using DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FunClub.Controllers
{
    public class PuntosController : Controller
    {
        private FunClubEntities db = new FunClubEntities();
        // GET: Puntos
        public ActionResult Index()
        {
            return View();
        }

        public string AcreditarPuntosDNI(string disco, string dni)
        {
            int coddisco = Convert.ToInt32(disco);
            string discoteca = db.Discotecas.Where(a => a.CodDiscoteca == coddisco).FirstOrDefault().Descripcion;


            return JsonConvert.SerializeObject("Se creditaron 50 puntos de beneficio para la discoteca: "+ discoteca + " al DNI: " + dni + ".Muchas gracias por operar con FunClub!", Formatting.None,
             new JsonSerializerSettings()
             {
                 ReferenceLoopHandling = ReferenceLoopHandling.Ignore
             });
            
        }
    }
}