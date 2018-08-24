using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CargarExcel()
        {
            var excelsl = new SL.Excel();
            excelsl.Leer(@"C:\users\garigos\Desktop\EL.xls");
        }
    }
}
