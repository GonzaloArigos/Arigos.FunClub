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
        public static Entities.CargaMasivaEntrada CargaMasivaEntrada(string FileName, byte[] Data)
        {
            var excelsl = new SL.Excel();
            var lectura = excelsl.Leer(FileName, Data);
            var objetos = new List<DAL.Entrada>();
            try
            {
                objetos = SL.DatarowToObjectMapper.ConvertEntradas(lectura);
            }
            catch
            {
                throw new Exception("Error de formato: Por favor verificar que las columnas ingresadas sean correctas y que los tipos de datos ingresados sean los requeridos.");
            }


            var excluidas = ExcluirEntradasExistentes(objetos);

            objetos = objetos.Except(excluidas).ToList();

            Entities.CargaMasivaEntrada Resultado = new Entities.CargaMasivaEntrada();

            Resultado.Error = new List<Entrada>();

            foreach (var item in objetos)
            {
                try
                {
                    DAL.EntradaDAL.CargaMasivaEntrada(item);
                }
                catch
                {
                    Resultado.Error.Add(item);
                }

            }

            objetos = objetos.Except(Resultado.Error).ToList();

            Resultado.Registradas = objetos;
            Resultado.Excluidas = excluidas;
            return Resultado;
        }

        private static List<Entrada> ExcluirEntradasExistentes(List<Entrada> objetos)
        {
            var retorno = new List<Entrada>();
            foreach (var item in objetos)
            {
                if (DAL.EntradaDAL.GetEntradaPorConsumicion(item.Discoteca_CodDiscoteca, item.CodConsumicion) != null)
                {
                    retorno.Add(item);
                }
            }

            return retorno;
        }
    }
}
