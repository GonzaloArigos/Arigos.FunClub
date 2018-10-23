using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class ConsumicionBLL
    {
        public static List<DAL.Consumicion> GetAllFromDisco(string usuario)
        {

            var disco = BLL.DiscotecaBLL.GetDiscotecasUsuario(usuario).Where(a => a.Productiva == true).FirstOrDefault();

            return DAL.ConsumicionDAL.GetAllFromDisco(disco);

        }

        public static void NuevaConsumicion(DAL.Consumicion consumicion, string usuario)
        {
            var disco = BLL.DiscotecaBLL.GetDiscotecasUsuario(usuario).Where(a => a.Productiva == true).FirstOrDefault();

            consumicion.CodDiscoteca = disco.CodDiscoteca;

            foreach (var item in consumicion.Consumicion_Bebida)
            {
                item.CodDiscoteca = disco.CodDiscoteca;
                item.CodBebida = item.Producto.CodBebida;
                item.Producto = null;
                item.FechaAlta = DateTime.Now;
                item.UsuarioAlta = usuario;
                item.TerminalAlta = "Servidor";
            }

            consumicion.FechaAlta = DateTime.Now;
            consumicion.UsuarioAlta = usuario;
            consumicion.TerminalAlta = "Servidor";
            consumicion.Estado = "Confirmado";
            DAL.ConsumicionDAL.NuevaConsumicion(consumicion);
        }
    }
}