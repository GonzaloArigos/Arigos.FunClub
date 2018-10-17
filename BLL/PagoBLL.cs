using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public static class PagoBLL
    {
        public static int GenerarPagoEfectivo(int disco,string usuario,decimal monto, DAL.DetallePagoEfectivo pagoEfectivo)
        {
            return DAL.PagoDAL.GenerarPagoEfectivo(disco, usuario, monto, pagoEfectivo);
        }

        public static int GenerarPagoTarjetaDebito(int disco, string usuario, decimal monto, DAL.DetallePagoTarjetaDebito pagodebito)
        {
            return DAL.PagoDAL.GenerarPagoTarjetaDebito(disco, usuario, monto, pagodebito);
        }

        public static int GenerarPagoTarjetaCredito(int disco, string usuario, decimal monto, DAL.DetallePagoTarjetaCredito pagocredito)
        {
            CalcularIntereses(pagocredito, monto);
            return DAL.PagoDAL.GenerarPagoTarjetaCredito(disco, usuario, monto, pagocredito);
        }

        private static void CalcularIntereses(DetallePagoTarjetaCredito pagocredito, decimal monto)
        {
            pagocredito.Cuotas = 1;
            pagocredito.PorcentajeInteres = (decimal)0.03;
            pagocredito.MontoInteres = pagocredito.PorcentajeInteres * monto;
            monto = (decimal)(monto + pagocredito.MontoInteres);
        }
    }
}
