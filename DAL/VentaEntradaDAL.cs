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
            venta.UsuarioAlta = null;
            venta.TerminalAlta = null;

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

        public static void CancelarVentaEntrada(int codventa, int coddisco)
        {
            using (FunClubEntities db = new FunClubEntities())
            {
                var venta = db.VentaEntradas.Where(a => a.CodVentaEntrada == codventa && a.CodDiscoteca == coddisco).FirstOrDefault();
                if (venta != null)
                {
                    venta.Estado = 2;
                    db.SaveChanges();
                }
            }
        }
    }
}
