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

        public string GetVentaEntradasHoy(int take)
        {
            return JsonConvert.SerializeObject(BLL.VentaEntradaBLL.GetVentaEntradasHoy(User.Identity.Name,take), Formatting.None,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

        }

        public string GetAllEntradas()
        {
          
            return JsonConvert.SerializeObject(BLL.EntradaBLL.GetAllFromDisco(User.Identity.Name), Formatting.None,
             new JsonSerializerSettings()
             {
                 ReferenceLoopHandling = ReferenceLoopHandling.Ignore
             });

        }
        [HttpPost]
        public void ProcesarPago(object item,int mediopago,object pago)
        {
           // System.Threading.Thread.Sleep(3000);
            List<DAL.DetalleVentaEntrada> detalleVenta = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DAL.DetalleVentaEntrada>>(item.ToString());

            if (mediopago == 1)
            {
                DAL.DetallePagoEfectivo detallepago = Newtonsoft.Json.JsonConvert.DeserializeObject<DAL.DetallePagoEfectivo>(pago.ToString());
                BLL.VentaEntradaBLL.ConfirmarVentaEfectivo(detalleVenta, detallepago, User.Identity.Name);
            }
            if (mediopago == 2)
            {
                DAL.DetallePagoTarjetaDebito detallepago = Newtonsoft.Json.JsonConvert.DeserializeObject<DAL.DetallePagoTarjetaDebito>(pago.ToString());
                BLL.VentaEntradaBLL.ConfirmarVentaDebito(detalleVenta, detallepago, User.Identity.Name);
            }

            if (mediopago == 3)
            {
                DAL.DetallePagoTarjetaCredito detallepago = Newtonsoft.Json.JsonConvert.DeserializeObject<DAL.DetallePagoTarjetaCredito>(pago.ToString());
                BLL.VentaEntradaBLL.ConfirmarVentaCredito(detalleVenta, detallepago, User.Identity.Name);
            }

        }

    }
}