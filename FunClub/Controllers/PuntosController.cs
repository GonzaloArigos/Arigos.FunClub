using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FunClub.Controllers
{
    public class PuntosController : Controller
    {
        // GET: Puntos
        public ActionResult Index()
        {
            return View();
        }

        public string AcreditarPuntosDNI(string dni,string disco)
        {
            return "Se creditaron 50 puntos al DNI";
        }
    }
}