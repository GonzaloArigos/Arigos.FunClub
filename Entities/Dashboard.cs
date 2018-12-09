using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Dashboard
    {
        public string Disco { get; set; }
        public string CantidadEntradasVendidas { get; set; }
        public string FacturacionEntradas { get; set; }
        public string CantidadConsumicionesVendidas { get; set; }
        public string FacturacionConsumiciones { get; set; }
        public List<DAL.VentaEntrada> EntradasVendidas { get; set; }
        public List<DAL.VentaBarra> ConsumicionessVendidas { get; set; }
        public List<DAL.ClienteFichada> clienteFichadas { get; set; }
    }
}
