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


        //public string AcreditarPuntosDNI(string disco, string dni)
        //{
        //    int coddisco = Convert.ToInt32(disco);
        //    string discoteca = db.Discotecas.Where(a => a.CodDiscoteca == coddisco).FirstOrDefault().Descripcion;


        //    return JsonConvert.SerializeObject("Se creditaron 50 puntos de beneficio para la discoteca: " + discoteca + " al DNI: " + dni + ".Muchas gracias por operar con FunClub!", Formatting.None,
        //     new JsonSerializerSettings()
        //     {
        //         ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        //     });

        //}
        public string AcreditarPuntosDNI(string disco, string dni, string nombre, string apellido, string fechanac)
        {
            try
            {
                int coddisco = Convert.ToInt32(disco);
                var objdisco = db.Discotecas.Where(x=> x.CodDiscoteca == coddisco).FirstOrDefault();

                if (objdisco == null)
                {
                    return "La discoteca escaneada no existe!";
                }

                ClienteFichada fichada = new ClienteFichada();

                fichada.Dni = dni.Replace("DNI: ", "");
                fichada.Nombre = nombre;
                fichada.Apellido = apellido;
                fichada.CodDisco = Convert.ToInt32(disco);
                fichada.FechaNac = fechanac;
                fichada.FechaHoraEntrada = DateTime.Now;
                fichada.Puntos = 50;

                
                db.ClienteFichadas.Add(fichada);

                db.SaveChanges();

                int? puntos = db.ClienteFichadas.Where(a => a.Dni == fichada.Dni).Sum(x => x.Puntos);
                puntos = puntos == null ? 0 : puntos;

                db.Bitacoras.Add(new Bitacora()
                {
                    Descripcion = "Se acreditaron puntos al dni: " + fichada.Dni,
                    FechaHora = DateTime.Now,
                    Modulo = "Android",
                    UserId = fichada.Dni
                }
                );

                db.SaveChanges();

                return "Se creditaron " + fichada.Puntos + " puntos al DNI: " + fichada.Dni + ". Acumulaste un total de: " + puntos.ToString() + " en la discoteca: " + objdisco.Descripcion;
            }
            catch (Exception ex)
            {
                return "Ocurrio un error inesperado: " + ex.Message;
            }
        }
          

        
    }
}