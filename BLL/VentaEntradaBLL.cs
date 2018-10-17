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

            decimal monto = 0;

            monto = CalcularMonto(detalleventa, disco, monto);

            int codpago = BLL.PagoBLL.GenerarPagoEfectivo(disco, usuario, monto, pagoEfectivo);

            foreach (var item in detalleventa)
            {
                item.CodDiscoteca = disco;
                item.FechaAlta = DateTime.Now;
                item.TerminalAlta = null;
                item.UsuarioAlta = null;
            }

            DAL.VentaEntradaDAL.GenerarVentaEntrada(disco, codpago, detalleventa, usuario);

        }

        public static List<DAL.VentaEntrada> GetVentaEntradasHoy(string name, int take)
        {
            var disco = BLL.DiscotecaBLL.GetDiscotecasUsuario(name).Where(a => a.Productiva == true).FirstOrDefault().CodDiscoteca;
        return    DAL.VentaEntradaDAL.GetVentaEntradasHoy(disco, take);
        }

        public static void ConfirmarVentaDebito(List<DAL.DetalleVentaEntrada> detalleventa, DAL.DetallePagoTarjetaDebito pagodebito, string usuario)
        {
            var Venta = new DAL.VentaEntrada();

            Venta.Estado = 1;

            var disco = BLL.DiscotecaBLL.GetDiscotecasUsuario(usuario).Where(a => a.Productiva == true).FirstOrDefault().CodDiscoteca;

            decimal monto = 0;

            monto = CalcularMonto(detalleventa, disco, monto);

            int codpago = BLL.PagoBLL.GenerarPagoTarjetaDebito(disco, usuario, monto, pagodebito);

            foreach (var item in detalleventa)
            {
                item.CodDiscoteca = disco;
                item.FechaAlta = DateTime.Now;
                item.TerminalAlta = null;
                item.UsuarioAlta = null;
            }

            DAL.VentaEntradaDAL.GenerarVentaEntrada(disco, codpago, detalleventa, usuario);

        }

        private static decimal CalcularMonto(List<DAL.DetalleVentaEntrada> detalleventa, int disco, decimal monto)
        {
            foreach (var item in detalleventa)
            {
                var Entrada = new DAL.Entrada()
                {
                    CodEntrada = item.CodEntrada,
                    CodDiscoteca = disco
                };
                var precio = DAL.PrecioEntradaDAL.GetUltimoPrecio(Entrada).Precio;
                monto = (decimal)(monto + (precio * item.Cantidad));
            }

            return monto;
        }

        public static void CancelarVentaEntrada(int codventa, int coddisco)
        {
            DAL.VentaEntradaDAL.CancelarVentaEntrada(codventa,coddisco);
        }

        public static void ConfirmarVentaCredito (List<DAL.DetalleVentaEntrada> detalleventa, DAL.DetallePagoTarjetaCredito pagodebito, string usuario)
        {
            var Venta = new DAL.VentaEntrada();

            Venta.Estado = 1;

            var disco = BLL.DiscotecaBLL.GetDiscotecasUsuario(usuario).Where(a => a.Productiva == true).FirstOrDefault().CodDiscoteca;

            decimal monto = 0;

            monto = CalcularMonto(detalleventa, disco, monto);

            int codpago = BLL.PagoBLL.GenerarPagoTarjetaCredito(disco, usuario, monto, pagodebito);

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
