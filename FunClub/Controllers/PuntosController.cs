using DAL;
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

          

            
           
        }
    }
}