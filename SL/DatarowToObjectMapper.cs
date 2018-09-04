using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System;

namespace SL
{
    public static class DatarowToObjectMapper
    {
        public static List<DAL.Entrada> ConvertEntradas (DataRowCollection rows)
        {
            List<DAL.Entrada> retorno = new List<DAL.Entrada>();
            foreach (DataRow item in rows)
            {
                var entradaNew = new DAL.Entrada();
                
                entradaNew.CodConsumicion = Convert.ToInt32(item["CodConsumicion"].ToString());
                entradaNew.Descripcion = item["Descripcion"].ToString();
                entradaNew.CodDiscoteca = Convert.ToInt32(item["CodDiscoteca"].ToString());
                entradaNew.Estado = item["Estado"].ToString();
                entradaNew.FechaRegistro = DateTime.Now;

                var precio = new DAL.PrecioEntrada();
                precio.CodDiscoteca = entradaNew.CodDiscoteca;
                precio.FechaAlta = DateTime.Now;
                precio.FechaInicio = Convert.ToDateTime(item["FechaInicioPrecio"].ToString());
                precio.FechaFin = Convert.ToDateTime(item["FechaFinPrecio"].ToString());
                precio.Precio = Convert.ToDecimal(item["Precio"].ToString()); 
                precio.Puntos = Convert.ToInt32(item["Puntos"].ToString());

                entradaNew.PrecioEntradas.Add(precio);

                retorno.Add(entradaNew);
            }
            return retorno;
        }
    }
}
