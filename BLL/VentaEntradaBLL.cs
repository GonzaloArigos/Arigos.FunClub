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

            var disco = DAL.VentaEntradaDAL.GetDiscotecaUsuario(usuario).CodDiscoteca;


            int codpago = DAL.VentaEntradaDAL.GenerarPagoEfectivo(disco,usuario,1,pagoEfectivo);

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
