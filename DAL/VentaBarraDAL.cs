using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public static class VentaBarraDAL
    {

        public static void GenerarVentaBarra(int disco, int codpago, List<DetalleVentaBarra> detalle, string email)
        {
            VentaBarra venta = new VentaBarra();

            venta.CodDiscoteca = disco;
            venta.CodPago = codpago;
            venta.Estado = "1";
            venta.DetalleVentaBarras = detalle;
            venta.FechaAlta = DateTime.Now;
            venta.UsuarioAlta = "1";
            venta.TerminalAlta = "1";

            using (FunClubEntities db = new FunClubEntities())
            {
                venta.CodVentaBarra = db.VentaBarras.Where(a => a.CodDiscoteca == disco).Any() ? db.VentaBarras.Where(a => a.CodDiscoteca == disco).Max(a => a.CodVentaBarra) + 1 : 1;
                db.VentaBarras.Add(venta);
                db.SaveChanges();
            }
        }

        public static List<VentaBarra> GetVentaBarraHoy(int disco, int take)
        {
            using (FunClubEntities db = new FunClubEntities())
            {
                var ventas = db.VentaBarras
                    .Include("Pago")
                    .Include("Pago.DetallePagoEfectivoes")
                    .Include("Pago.DetallePagoTarjetaCreditoes")
                    .Include("Pago.DetallePagoTarjetaDebitoes")
                    .Where(a => a.CodDiscoteca == disco).OrderByDescending(a => a.Pago.FechaPago).Take(take).ToList();
                return ventas;
            }
        }

        public static List<VentaBarra> GetVentaBarraFecha(Discoteca disco)
        {
            using (FunClubEntities db = new FunClubEntities())
            {
                var fechaayer = DateTime.Now.AddDays(-1);
                return db.VentaBarras
                    .Include("Pago")
                    .Include("Pago.DetallePagoEfectivoes")
                    .Include("Pago.DetallePagoTarjetaCreditoes")
                    .Include("Pago.DetallePagoTarjetaDebitoes")
                    .Where(a => a.FechaAlta <= DateTime.Now && a.FechaAlta >= fechaayer).ToList();
            }
        }

        public static string GetFacturacionHoy(Discoteca disco)
        {
            using (FunClubEntities db = new FunClubEntities())
            {
                var fechaayer = DateTime.Now.AddDays(-1);
                return db.VentaBarras.Where(a => a.FechaAlta <= DateTime.Now && a.FechaAlta >= fechaayer).Sum(a => a.Pago.Monto).ToString();
            }
        }

        public static string GetCantidadVendidaHoy(Discoteca disco)
        {
            using (FunClubEntities db = new FunClubEntities())
            {
                var fechaayer = DateTime.Now.AddDays(-1);
                return db.VentaBarras.Where(a => a.FechaAlta <= DateTime.Now && a.FechaAlta >= fechaayer).Count().ToString();
            }
        }

        public static void CancelarVentaBarra(int codventa, int coddisco)
        {
            using (FunClubEntities db = new FunClubEntities())
            {
                var venta = db.VentaBarras.Include("Pago").Where(a => a.CodVentaBarra == codventa && a.CodDiscoteca == coddisco).FirstOrDefault();
                if (venta != null)
                {
                    venta.Estado = "2";
                    venta.Pago.Estado = "2";
                    db.SaveChanges();
                }
            }
        }
    }
}
