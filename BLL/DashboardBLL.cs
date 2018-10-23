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
            dash.EntradasVendidas = BLL.VentaEntradaBLL.GetVentaEntradasHoy(user, 5000);
            var disco = BLL.DiscotecaBLL.GetDiscotecasUsuario(user).FirstOrDefault();
            dash.Disco = disco != null ? disco.Descripcion : "No posee ninguna discoteca productiva.";
           // dash.CantidadEntradasVendidas = BLL.VentaEntradaBLL.GetCantidadVendidaHoy();
            return dash;
        }
    }
}
