using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
namespace FunClub.Controllers
{
    public class VentaBarraController : Controller
    {
        private FunClubEntities db = new FunClubEntities();
        // GET: VentaBarra
        public ActionResult Index()
        {
            return View();
        }

        public string GetVentaBarrasHoy(int take)
        {
            return JsonConvert.SerializeObject(BLL.VentaBarraBLL.GetVentaBarrasHoy(User.Identity.Name, take), Formatting.None,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

        }

        public string GetAllBarras()
        {

            return JsonConvert.SerializeObject(BLL.ConsumicionBLL.GetAllFromDisco(User.Identity.Name), Formatting.None,
             new JsonSerializerSettings()
             {
                 ReferenceLoopHandling = ReferenceLoopHandling.Ignore
             });

        }
        [HttpPost]
        public void ProcesarPago(object item, int mediopago, object pago)
        {
#if !DEBUG

           System.Threading.Thread.Sleep(2000);

#endif

            List<DAL.DetalleVentaBarra> detalleVenta = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DAL.DetalleVentaBarra>>(item.ToString());
            string mensajewsp = "";
            if (mediopago == 1)
            {
                DAL.DetallePagoEfectivo detallepago = Newtonsoft.Json.JsonConvert.DeserializeObject<DAL.DetallePagoEfectivo>(pago.ToString());
                BLL.VentaBarraBLL.ConfirmarVentaEfectivo(detalleVenta, detallepago, User.Identity.Name);
                mensajewsp = "Se realizó una venta de Barra!";
            }
            if (mediopago == 2)
            {
                DAL.DetallePagoTarjetaDebito detallepago = Newtonsoft.Json.JsonConvert.DeserializeObject<DAL.DetallePagoTarjetaDebito>(pago.ToString());
                BLL.VentaBarraBLL.ConfirmarVentaDebito(detalleVenta, detallepago, User.Identity.Name);
                mensajewsp = "Se realizó una venta de Barra!";
            }

            if (mediopago == 3)
            {
                DAL.DetallePagoTarjetaCredito detallepago = Newtonsoft.Json.JsonConvert.DeserializeObject<DAL.DetallePagoTarjetaCredito>(pago.ToString());
                BLL.VentaBarraBLL.ConfirmarVentaCredito(detalleVenta, detallepago, User.Identity.Name);
                mensajewsp = "Se realizó una venta de Barra!";
            }

            db.Bitacoras.Add(new Bitacora()
            {
                Descripcion = "Se  realizo una venta de consumiciones",
                FechaHora = DateTime.Now,
                Modulo = "VentaBarra",
                UserId = User.Identity.Name
            }
         );

            db.SaveChanges();

        }



        [HttpPost]
        public void CancelarVenta(int codventa, int coddisco)
        {
            BLL.VentaBarraBLL.CancelarVentaBarra(codventa, coddisco);
        }

    }
}