using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class VentaEntradaBLL
    {
        public static void ConfirmarVentaEfectivo(List<DAL.DetalleVentaEntrada> detalleventa, DAL.DetallePagoEfectivo pagoEfectivo, string usuario)
        {
            var Venta = new DAL.VentaEntrada();

            Venta.Estado = 1;

            var disco = BLL.DiscotecaBLL.GetDiscotecasUsuario(usuario).Where(a => a.Productiva == true).FirstOrDefault().CodDiscoteca;


            int codpago = BLL.PagoBLL.GenerarPagoEfectivo(disco, usuario, 1, pagoEfectivo);

            foreach (var item in detalleventa)
            {
                item.CodDiscoteca = disco;
                item.FechaAlta = DateTime.Now;
                item.TerminalAlta = null;
                item.UsuarioAlta = null;
            }

            DAL.VentaEntradaDAL.GenerarVentaEntrada(disco, codpago, detalleventa, usuario);

        }

        public static void ConfirmarVentaDebito(List<DAL.DetalleVentaEntrada> detalleventa, DAL.DetallePagoTarjetaDebito pagodebito, string usuario)
        {
            var Venta = new DAL.VentaEntrada();

            Venta.Estado = 1;

            var disco = BLL.DiscotecaBLL.GetDiscotecasUsuario(usuario).Where(a => a.Productiva == true).FirstOrDefault().CodDiscoteca;


            int codpago = BLL.PagoBLL.GenerarPagoTarjetaDebito(disco, usuario, 1, pagodebito);

            foreach (var item in detalleventa)
            {
                item.CodDiscoteca = disco;
                item.FechaAlta = DateTime.Now;
                item.TerminalAlta = null;
                item.UsuarioAlta = null;
            }

            DAL.VentaEntradaDAL.GenerarVentaEntrada(disco, codpago, detalleventa, usuario);

        }

        public static void ConfirmarVentaCredito (List<DAL.DetalleVentaEntrada> detalleventa, DAL.DetallePagoTarjetaCredito pagodebito, string usuario)
        {
            var Venta = new DAL.VentaEntrada();

            Venta.Estado = 1;

            var disco = BLL.DiscotecaBLL.GetDiscotecasUsuario(usuario).Where(a => a.Productiva == true).FirstOrDefault().CodDiscoteca;


            int codpago = BLL.PagoBLL.GenerarPagoTarjetaCredito(disco, usuario, 1, pagodebito);

            foreach (var item in detalleventa)
            {
                item.CodDiscoteca = disco;
                item.FechaAlta = DateTime.Now;
                item.TerminalAlta = null;
                item.UsuarioAlta = null;
            }

            DAL.VentaEntradaDAL.GenerarVentaEntrada(disco, codpago, detalleventa, usuario);

        }

    }
}
