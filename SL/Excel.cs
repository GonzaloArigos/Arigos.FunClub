using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL
{
    public class Excel
    {
        public DataRowCollection Leer(string FileName, byte[] Data)
        {
            string Ruta = @"C:\Users\garigos\Documents\GitHub\Arigos.FunClub\FunClub\CargasMasivas\" + FileName;
            File.WriteAllBytes(Ruta, Data);
            var ds = new System.Data.DataSet();
            var extension = Path.GetExtension(FileName).ToLower();
            using (var stream = new FileStream(Ruta, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                var sw = new Stopwatch();
                sw.Start();
                IExcelDataReader reader = null;
                if (extension == ".xls")
                {
                    reader = ExcelReaderFactory.CreateBinaryReader(stream);
                }
                else if (extension == ".xlsx")
                {
                    reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                }
                else if (extension == ".csv")
                {
                    reader = ExcelReaderFactory.CreateCsvReader(stream);
                }

                if (reader == null)
                    return null;

                var openTiming = sw.ElapsedMilliseconds;
                // reader.IsFirstRowAsColumnNames = firstRowNamesCheckBox.Checked;
                using (reader)
                {
                    ds = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        UseColumnDataType = false,
                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });
                }

                // toolStripStatusLabel1.Text = "Elapsed: " + sw.ElapsedMilliseconds.ToString() + " ms (" + openTiming.ToString() + " ms to open)";

                var tablenames = GetTablenames(ds.Tables);

                return ds.Tables[0].Rows;
                // sheetCombo.DataSource = tablenames;

                //if (tablenames.Count > 0)
                //    sheetCombo.SelectedIndex = 0;

                // dataGridView1.DataSource = ds;
                // dataGridView1.DataMember
            }
        }

        private static IList<string> GetTablenames(DataTableCollection tables)
        {
            var tableList = new List<string>();
            foreach (var table in tables)
            {
                tableList.Add(table.ToString());
            }

            return tableList;
        }
    }
}
