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
                entradaNew.Discoteca_CodDiscoteca = Convert.ToInt32(item["CodDiscoteca"].ToString());
                entradaNew.Estado = item["Estado"].ToString();
                entradaNew.FechaRegistro = DateTime.Now;

                retorno.Add(entradaNew);
            }
            return retorno;
        }
    }
}
