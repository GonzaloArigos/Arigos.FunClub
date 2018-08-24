using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public static class CargasMasivasBLL
    {
        public static Entities.CargaMasivaEntrada  CargaMasivaEntrada(string Ruta)
        {
            var excelsl = new SL.Excel();
            var lectura = excelsl.Leer(Ruta);
            var objetos = SL.DatarowToObjectMapper.ConvertEntradas(lectura);
            var excluidas = ExcluirEntradasExistentes(objetos);
            DAL.EntradaDAL.CargaMasivaEntrada(objetos);
            Entities.CargaMasivaEntrada Resultado = new Entities.CargaMasivaEntrada();
            Resultado.Registradas = objetos;
            Resultado.Excluidas = excluidas;
            return Resultado;
        }

        private static List<Entrada> ExcluirEntradasExistentes(List<Entrada> objetos)
        {
            var retorno = new List<Entrada>();
            foreach(var item in objetos)
            {
                if(DAL.EntradaDAL.GetOne(item.CodEntrada) != null)
                {
                    retorno.Add(item);
                    objetos.Remove(item);
                }
            }
            return retorno;
        }
    }
}
