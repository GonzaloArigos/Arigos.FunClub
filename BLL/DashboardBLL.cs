using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class DashboardBLL
    {
        public static Entities.Dashboard GetDashBoard(string user)
        {
            var dash = new Entities.Dashboard();
            var disco = BLL.DiscotecaBLL.GetDiscotecasUsuario(user).FirstOrDefault();
            if (disco != null)
            {
                dash.Disco = disco.Descripcion;
                dash.EntradasVendidas = BLL.VentaEntradaBLL.GetVentaEntradasFecha(disco);
                dash.CantidadEntradasVendidas = BLL.VentaEntradaBLL.GetCantidadVendidaHoy(disco);
                dash.FacturacionEntradas = BLL.VentaEntradaBLL.GetFacturacionHoy(disco);
                dash.clienteFichadas = DAL.PuntosDAL.ObtenerFichadasHoy(disco);
                return dash;
            }
            return null;
        }
    }
}
