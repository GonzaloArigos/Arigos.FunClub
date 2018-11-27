using DAL;
<<<<<<< HEAD
using Newtonsoft.Json;
=======
>>>>>>> f00307a6ff828f3e319ab49bd4e84297c4486962
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FunClub.Controllers
{
    public class PuntosController : Controller
    {
<<<<<<< HEAD
=======

>>>>>>> f00307a6ff828f3e319ab49bd4e84297c4486962
        private FunClubEntities db = new FunClubEntities();
        // GET: Puntos
        public ActionResult Index()
        {
            return View();
        }

<<<<<<< HEAD
        public string AcreditarPuntosDNI(string disco, string dni)
        {
            int coddisco = Convert.ToInt32(disco);
            string discoteca = db.Discotecas.Where(a => a.CodDiscoteca == coddisco).FirstOrDefault().Descripcion;


            return JsonConvert.SerializeObject("Se creditaron 50 puntos de beneficio para la discoteca: "+ discoteca + " al DNI: " + dni + ".Muchas gracias por operar con FunClub!", Formatting.None,
             new JsonSerializerSettings()
             {
                 ReferenceLoopHandling = ReferenceLoopHandling.Ignore
             });
            
=======
        public string AcreditarPuntosDNI(string dni,string disco,string nombre,string apellido,string fechanac)
        {
            try
            {
                ClienteFichada fichada = new ClienteFichada();

                fichada.Dni = dni.Replace("DNI: ","");
                fichada.Nombre = nombre;
                fichada.Apellido = apellido;
                fichada.CodDisco = Convert.ToInt32(disco);
                fichada.FechaNac = fechanac;
                fichada.FechaHoraEntrada = DateTime.Now;
                fichada.Puntos = 50;

                int? puntos = db.ClienteFichadas.Where(a=> a.Dni == fichada.Dni).Sum(x => x.Puntos);
                puntos = puntos == null ? 0 : puntos;

                db.ClienteFichadas.Add(fichada);

                db.SaveChanges();

                return "Se creditaron " + fichada.Puntos  +" puntos al DNI: " + fichada.Dni + ". Acumulaste un total de: " + puntos.ToString();
            }
            catch (Exception ex)
            {
                return "Ocurrio un error inesperado: " + ex.Message;
            }

          

            
           
>>>>>>> f00307a6ff828f3e319ab49bd4e84297c4486962
        }
    }
}