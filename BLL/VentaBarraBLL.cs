using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class VentaBarraBLL
    {
        public static void ConfirmarVentaEfectivo(List<DAL.DetalleVentaBarra> detalleventa, DAL.DetallePagoEfectivo pagoEfectivo, string usuario)
        {
            var Venta = new DAL.VentaBarra();

            Venta.Estado = "1";

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

            DAL.VentaBarraDAL.GenerarVentaBarra(disco, codpago, detalleventa, usuario);

        }

        internal static List<DAL.VentaBarra> GetVentaBarrasFecha(Discoteca disco)
        {
            return DAL.VentaBarraDAL.GetVentaBarraFecha(disco);
        }

        internal static string GetFacturacionHoy(Discoteca disco)
        {
            return DAL.VentaBarraDAL.GetFacturacionHoy(disco);
        }

        internal static string GetCantidadVendidaHoy(Discoteca disco)
        {
            return DAL.VentaBarraDAL.GetCantidadVendidaHoy(disco);
        }

        public static List<DAL.VentaBarra> GetVentaBarrasHoy(string name, int take)
        {
            var disco = BLL.DiscotecaBLL.GetDiscotecasUsuario(name).Where(a => a.Productiva == true).FirstOrDefault().CodDiscoteca;
            return DAL.VentaBarraDAL.GetVentaBarraHoy(disco, take);
        }

        public static void ConfirmarVentaDebito(List<DAL.DetalleVentaBarra> detalleventa, DAL.DetallePagoTarjetaDebito pagodebito, string usuario)
        {
            var Venta = new DAL.VentaBarra();

            Venta.Estado = "1";

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

            DAL.VentaBarraDAL.GenerarVentaBarra(disco, codpago, detalleventa, usuario);

        }

        private static decimal CalcularMonto(List<DAL.DetalleVentaBarra> detalleventa, int disco, decimal monto)
        {
            monto = 0;
            foreach (var item in detalleventa)
            {
                var Consumicion = new DAL.Consumicion()
                {
                    CodConsumicion = item.CodConsumicion,
                    CodDiscoteca = disco
                };
                var precio = DAL.PrecioConsumicionDAL.GetUltimoPrecio(Consumicion);

                if (precio != null)
                {
                    monto = (decimal)(monto + (precio.Precio * item.Cantidad));
                    
                }
          
            }

            return monto;

        }


    

    public static void CancelarVentaBarra(int codventa, int coddisco)
    {
        DAL.VentaBarraDAL.CancelarVentaBarra(codventa, coddisco);
    }

    public static void ConfirmarVentaCredito(List<DAL.DetalleVentaBarra> detalleventa, DAL.DetallePagoTarjetaCredito pagodebito, string usuario)
    {
        var Venta = new DAL.VentaBarra();

        Venta.Estado = "1";

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

        DAL.VentaBarraDAL.GenerarVentaBarra(disco, codpago, detalleventa, usuario);

    }
}
}


