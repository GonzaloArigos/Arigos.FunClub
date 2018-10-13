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
            venta.UsuarioAlta =null;
            venta.TerminalAlta =null;

            using (FunClubEntities db = new FunClubEntities())
            {
                venta.CodVentaEntrada = db.VentaEntradas.Where(a => a.CodDiscoteca == disco).Any() ? db.VentaEntradas.Where(a => a.CodDiscoteca == disco).Max(a => a.CodVentaEntrada) + 1 : 1;
                db.VentaEntradas.Add(venta);
                db.SaveChanges();
            }
        }
    }
}
