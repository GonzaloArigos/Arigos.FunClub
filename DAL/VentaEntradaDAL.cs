using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class VentaEntradaDAL
    {

        public static Discoteca GetDiscotecaUsuario(string email)
        {
            using (FunClubEntities db = new FunClubEntities())
            {
                return db.Usuario_Discotecas.Include("Discoteca").Where(a => a.EmailUsuario == email && a.Discoteca.Productiva == true).FirstOrDefault().Discoteca;
            }
        }

        public static int GenerarPagoEfectivo(int disco, string email, int monto, DetallePagoEfectivo detalle)
        {
            Pago pago = new Pago();
            using (FunClubEntities db = new FunClubEntities())
            {
                int? codpago = db.Pagoes.ToList().Count;
                pago.CodPago = codpago != 0 ? db.Pagoes.ToList().LastOrDefault().CodPago + 1 : 1;
                pago.Estado = "1";
                pago.FechaAlta = DateTime.Now;
                pago.FechaPago = DateTime.Now;
                pago.TerminalAlta = "1";
                pago.Monto = monto;
                pago.DetallePagoEfectivoes = new List<DetallePagoEfectivo>();
                pago.DetallePagoEfectivoes.Add(detalle);

                db.Pagoes.Add(pago);

                db.SaveChanges();

                return pago.CodPago;

            }
        }

        public static void GenerarVentaEntrada(int disco, int codpago, List<DetalleVentaEntrada> detalle, string email)
        {
            VentaEntrada venta = new VentaEntrada();

            venta.CodDiscoteca = disco;
            venta.CodPago = codpago;
            venta.Estado = 1;
            venta.DetalleVentaEntradas = detalle;
            venta.FechaAlta = DateTime.Now;
            venta.UsuarioAlta = "1";
            venta.TerminalAlta = "1";

            using (FunClubEntities db = new FunClubEntities())
            {
                venta.CodVentaEntrada = db.VentaEntradas.Where(a => a.CodDiscoteca == disco).Any() ? db.VentaEntradas.Where(a => a.CodDiscoteca == disco).Max(a => a.CodVentaEntrada) + 1 : 1;
                db.VentaEntradas.Add(venta);
                db.SaveChanges();
            }
        }
    }
}
