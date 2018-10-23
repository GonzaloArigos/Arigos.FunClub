using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class VentaEntradaDAL
    {



        public static void GenerarVentaEntrada(int disco, int codpago, List<DetalleVentaEntrada> detalle, string email)
        {
            VentaEntrada venta = new VentaEntrada();

            venta.CodDiscoteca = disco;
            venta.CodPago = codpago;
            venta.Estado = 1;
            venta.DetalleVentaEntradas = detalle;
            venta.FechaAlta = DateTime.Now;
            venta.UsuarioAlta = email;
            venta.TerminalAlta = "Servidor";

            using (FunClubEntities db = new FunClubEntities())
            {
                venta.CodVentaEntrada = db.VentaEntradas.Where(a => a.CodDiscoteca == disco).Any() ? db.VentaEntradas.Where(a => a.CodDiscoteca == disco).Max(a => a.CodVentaEntrada) + 1 : 1;
                db.VentaEntradas.Add(venta);
                db.SaveChanges();
            }
        }

        public static List<VentaEntrada> GetVentaEntradasHoy(int disco, int take)
        {
            using (FunClubEntities db = new FunClubEntities())
            {
                var ventas = db.VentaEntradas
                    .Include("Pago")
                    .Include("Pago.DetallePagoEfectivoes")
                    .Include("Pago.DetallePagoTarjetaCreditoes")
                    .Include("Pago.DetallePagoTarjetaDebitoes")
                    .Where(a => a.CodDiscoteca == disco).OrderByDescending(a => a.Pago.FechaPago).Take(take).ToList();
                return ventas;
            }
        }

        public static List<VentaEntrada> GetVentaEntradasFecha(Discoteca disco)
        {
            using (FunClubEntities db = new FunClubEntities())
            {
                var fechaayer = DateTime.Now.AddDays(-1);
                return db.VentaEntradas
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
                return db.VentaEntradas.Where(a => a.FechaAlta <= DateTime.Now && a.FechaAlta >= fechaayer).Sum(a=> a.Pago.Monto).ToString();
            }
        }

        public static string GetCantidadVendidaHoy(Discoteca disco)
        {
            using (FunClubEntities db = new FunClubEntities())
            {
                var fechaayer = DateTime.Now.AddDays(-1);
                return db.VentaEntradas.Where(a => a.FechaAlta <= DateTime.Now && a.FechaAlta >= fechaayer).Count().ToString();
            }
        }

        public static void CancelarVentaEntrada(int codventa, int coddisco)
        {
            using (FunClubEntities db = new FunClubEntities())
            {
                var venta = db.VentaEntradas.Include("Pago").Where(a => a.CodVentaEntrada == codventa && a.CodDiscoteca == coddisco).FirstOrDefault();
                if (venta != null)
                {
                    venta.Estado = 2;
                    venta.Pago.Estado = "2";
                    db.SaveChanges();
                }
            }
        }
    }
}
